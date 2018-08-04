using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to flight operations for fetch,add,update
	/// </summary>
	class FlightDAO : DAO, IFlightDAO
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public FlightDAO()
		{

		}

		#region Method to get the flight details from the database
		/// <summary>
		/// Get the flight details from the database
		/// </summary>
        /// <exception cref="FlightDAOException">Thorws an exception when unable to get flights</exception>
		/// <returns>Returns the list of flights from the database</returns>
		public List<Flight> GetFlights()
		{
			List<Flight> flights = new List<Flight>();

			try
			{
                using (IDbConnection conn = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(conn, "GetFlightsAndFlightClasses"))
                    {
                        while (reader.Read())
                        {
                            Flight flight = new Flight();

                            flight.ID = long.Parse(reader["FlightId"].ToString());
                            flight.Name = reader["FlightName"].ToString();
                            flight.AirlineForFlight = new Airline();
                            flight.AirlineForFlight.Id = int.Parse(reader["AirlineId"].ToString());
                            flight.AirlineForFlight.Name = reader["AirlineName"].ToString();
                            flight.AirlineForFlight.Code = reader["AirlineCode"].ToString();

                            flights.Add(flight);
                        }

                        Flight CurrentFlight = new Flight();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            FlightClass _class = new FlightClass();
                            int classid = int.Parse(reader["ClassId"].ToString());
                            _class.ClassInfo = (TravelClass)classid;
                            _class.NoOfSeats = int.Parse(reader["NoOfSeats"].ToString());

                            if (CurrentFlight.ID != (long)reader["FlightId"])
                            {
                                CurrentFlight = flights.Where(f => f.ID == (long)reader["FlightId"]).First();
                            }
                            CurrentFlight.AddClass(_class);
                        }
                    }
                }
			}
            catch (ConnectToDatabaseException ex)
			{
                throw new FlightDAOException("Unable to connect to database", ex);
			}
			catch (Exception ex)
			{
				throw new FlightDAOException("Unable to get flights", ex);
			}

			return flights;
		}
		#endregion

		#region Method to get the flight details for a given flight id from the database
		/// <summary>
		/// Get the flights details for a given flight from the database
		/// </summary>
		/// <parameter name="FlightId"></parameter>
		/// <returns>Returns the flight for a given id from the database</returns>
		public Flight GetFlight(int flightId)
		{
            Flight flight = null;

			try
			{
                using (IDbConnection conn = GetConnection())
                {
                    using (IDataReader Reader = ExecuteStoredProcedureResults(conn, "GetFlightAndClasses",
                        new SqlParameter() { ParameterName = "@FlightID", DbType = DbType.Int32, Value = flightId }
                    ))
                    {
                        Reader.Read();

                        flight = new Flight();

                        flight.ID = long.Parse(Reader["FlightId"].ToString());
                        flight.Name = Reader["FlightName"].ToString();
                        flight.AirlineForFlight = new Airline();
                        flight.AirlineForFlight.Id = int.Parse(Reader["AirlineId"].ToString());
                        flight.AirlineForFlight.Name = Reader["AirlineName"].ToString();
                        flight.AirlineForFlight.Code = Reader["AirlineCode"].ToString();

                        Reader.NextResult();
                        while (Reader.Read())
                        {
                            FlightClass fClass = new FlightClass();
                            int classId = int.Parse(Reader["ClassId"].ToString());
                            fClass.ClassInfo = (TravelClass)classId;

                            fClass.NoOfSeats = int.Parse(Reader["NoOfSeats"].ToString());
                            flight.AddClass(fClass);
                        }
                    }
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new FlightDAOException("Unable to get the flight details");
			}
			catch (Exception)
			{
				throw new FlightDAOException("Unable to get the flight details");
			}
			return flight;
		}
		#endregion

		#region Method to Add the flight details for the database
		/// <summary>
		/// Add the flight details for the database
		/// </summary>
		/// <parameter name="flight"></parameter>
		/// <returns>Returns the status of the insert</returns>
		public bool AddFlight(Flight flight)
		{
			long flightId = 0;
			bool flag = false;

            IDbTransaction tran = null;

			try
			{
                using (IDbConnection db = GetConnection())
                {
                    if ((int)ExecuteQueryScalar(db, "select count(*) as CityCount from flights where FlightName = '" + flight.Name + "' and AirlineId = " + flight.AirlineForFlight.Id) > 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        tran = db.BeginTransaction();

                        flightId = Convert.ToInt32(ExecuteStoredProcedureScalar(db, tran, "AddFlight",
                            new SqlParameter() { ParameterName = "@FlightName", DbType = DbType.String, Value = flight.Name },
                            new SqlParameter() { ParameterName = "@AirLineId", DbType = DbType.Int32, Value = flight.AirlineForFlight.Id }
                        ));

                        foreach (FlightClass item in flight.GetClasses())
                        {
                            int ClassId = (int)item.ClassInfo;
                            int NoOfSeats = item.NoOfSeats;
                            string query = "INSERT INTO FlightClasses (FlightId, ClassId, NoOfSeats) VALUES ('" + flightId + "','" + ClassId + "','" + NoOfSeats + "')";
                            ExecuteQuery(db, tran, query);
                        }

                        tran.Commit();
                        db.Close();
                        return true;
                    }
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
                RollbackTransactionAndCloseConnection(tran);
				throw new FlightDAOException("Unable to add flight");
			}
			catch (Exception)
			{
                RollbackTransactionAndCloseConnection(tran);
				throw new FlightDAOException("Unable to add flight");
			}

			return flag;
		}
		#endregion

		#region Method to update the existing flight details for a given flight id for the database
		/// <summary>
		/// Update the existing flight details for a given flight id for the database
		/// </summary>
		/// <parameter name="flight"></parameter>
		/// <returns>Returns the number of rows affected by the update</returns>
		public int UpdateFlight(Flight flight)
		{
            IDbConnection db = null;
			int flag = 0;
			try
			{
                db = GetConnection();

                if ((int)ExecuteQueryScalar(db, "select count(*) from flights where FlightName = '" + flight.Name + "' and AirlineId = " + flight.AirlineForFlight.Id) > 0)
                {
                    flag = 1;
                }
                else
                {
                    ExecuteStoredProcedure(db, "UpdateFlight",
                        new SqlParameter() { ParameterName = "@flightid", DbType = DbType.Int32, Value = flight.ID },
                        new SqlParameter() { ParameterName = "@flightname", DbType = DbType.String, Value = flight.Name },
                        new SqlParameter() { ParameterName = "@airlineId", DbType = DbType.Int32, Value = flight.AirlineForFlight.Id }
                    );
                    flag = 0;
                }

                return flag;
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new FlightDAOException("Unable to update flight");
			}
			catch (Exception)
			{
				throw new FlightDAOException("Unable to update flight");
			}
		}
		#endregion

		#region Method to update the existing flight class seats for a given flight id for the database
		/// <summary>
		/// Update the existing flight class seats for a given flight id for the database
		/// </summary>
		/// <parameter name="flight"></parameter>
		/// <parameter name="flightClass"></parameter>
		/// <returns>Returns the number of rows affected by the insert</returns>
		public int UpdateFlightClass(Flight flight, FlightClass flightClass)
		{
			try
			{
                return ExecuteStoredProcedure("UpdateFlightClass",
                    new SqlParameter() { ParameterName = "@flightId", DbType = DbType.Int32, Value = flight.ID },
                    new SqlParameter() { ParameterName = "@classId", DbType = DbType.Int32, Value = flightClass.ClassInfo },
                    new SqlParameter() { ParameterName = "@noOfSeats", DbType = DbType.Int32, Value = flightClass.NoOfSeats }
                );
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new FlightDAOException("Unable to update flight class");
			}
			catch (Exception)
			{
				throw new FlightDAOException("Unable to update flight class");
			}
		}
		#endregion
	}
}
