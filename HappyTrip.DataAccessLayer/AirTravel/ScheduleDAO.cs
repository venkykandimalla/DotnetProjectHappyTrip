using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;
using HappyTrip.Model.Entities.Common;
using System.Data.SqlClient;
using System.Data.Common;

namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to schedule operations for fetch,add,update
	/// </summary>
	class ScheduleDAO : DAO, IScheduleDAO
	{
		IDbConnection db;

		#region Making the constructor public
		public ScheduleDAO()
		{

		}
		#endregion

		#region Method to get the schedules from the database
		/// <summary>
		/// Gets the schedules from the database
		/// </summary>
		/// <returns>Returns the list of schedules from the database<Schedule></returns>
		public List<Model.Entities.AirTravel.Schedule> GetSchedules()
		{
			List<Schedule> schedules = new List<Schedule>();

			try
			{
                using (db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetScheduleFlightsAndCosts"))
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = new Schedule();

                            schedule.ID = long.Parse(reader["ScheduleId"].ToString());

                            Airline airline = new Airline();
                            airline.Id = int.Parse(reader["AirlineId"].ToString());
                            airline.Name = reader["AirlineName"].ToString();

                            Flight flight = new Flight();
                            flight.ID = long.Parse(reader["FlightId"].ToString());
                            flight.AirlineForFlight = airline;
                            flight.Name = reader["FlightName"].ToString();

                            schedule.FlightInfo = flight;

                            City fromCity = new City();
                            fromCity.CityId = long.Parse(reader["FromId"].ToString());
                            fromCity.Name = reader["FromCity"].ToString();

                            City toCity = new City();
                            toCity.CityId = long.Parse(reader["ToId"].ToString());
                            toCity.Name = reader["ToCity"].ToString();

                            Route route = new Route();
                            route.ID = long.Parse(reader["RouteId"].ToString());
                            route.FromCity = fromCity;
                            route.ToCity = toCity;

                            route.DistanceInKms = long.Parse(reader["DistanceInKms"].ToString());
                            schedule.RouteInfo = route;

                            DateTime dtime = Convert.ToDateTime(reader["DepartureTime"]);
                            TimeSpan dTS = new TimeSpan(dtime.Hour, dtime.Minute, dtime.Second);

                            DateTime atime = Convert.ToDateTime(reader["ArrivalTime"]);
                            TimeSpan aTS = new TimeSpan(atime.Hour, atime.Minute, atime.Second);

                            schedule.DepartureTime = dTS;
                            schedule.ArrivalTime = aTS;

                            schedule.DurationInMins = int.Parse(reader["DurationInMins"].ToString());
                            schedule.IsActive = bool.Parse(reader["Status"].ToString());

                            schedules.Add(schedule);
                        }

                        Schedule CurrentSchedule = new Schedule();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            FlightCost classCost = new FlightCost();
                            int classid = int.Parse(reader["ClassId"].ToString());
                            classCost.Class = (TravelClass)classid;
                            classCost.CostPerTicket = Convert.ToDecimal(reader["CostPerTicket"]);

                            if (CurrentSchedule.ID != (int)reader["ClassId"])
                            {
                                CurrentSchedule = schedules.Where(s => s.ID == (long)reader["ScheduleId"]).First();
                            }
                            CurrentSchedule.AddFlightCost(classCost);
                        }
                    }
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get schedules");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get schedules");
			}

			return schedules;
		}
		#endregion

		#region Method to get the route id for a schedule from the database
		/// <summary>
		/// Gets the route id for a schedule from the database
		/// </summary>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>Returns the route id for a given schedule</returns>
		public int GetRouteID(Model.Entities.AirTravel.Schedule ScheduleInfo)
		{
			try
			{
                db = GetConnection();
				int RouteId = 0;

                using (IDataReader Reader = ExecuteStoredProcedureResults(db, "getRouteId",
                    new SqlParameter() { ParameterName = "@fromcity", DbType = DbType.Int64, Value = ScheduleInfo.RouteInfo.FromCity.CityId },
                    new SqlParameter() { ParameterName = "@tocity", DbType = DbType.Int64, Value = ScheduleInfo.RouteInfo.ToCity.CityId }
                ))
                {

                    if (Reader.Read())
                    { RouteId = int.Parse(Reader["RouteId"].ToString()); }

                    return RouteId;
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get route id");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get route id");
			}
		}
		#endregion

		#region Method to add the schedule for the database
		/// <summary>
		/// Add the schedule for the database
		/// </summary>
		/// <parameter name="scheduleInfo"></parameter>
		/// <returns>Returns the number of rows affected by the insert</returns>
		public int AddSchedule(Model.Entities.AirTravel.Schedule scheduleInfo)
		{
            int numberOfRows = 0;
            IDbTransaction tran = null;

			try
			{
                using (db = GetConnection())
                {
                    int routeId = 0;

                    using (IDataReader reader = ExecuteStoredProcedureResults(GetConnection(), "getRouteId",
                        new SqlParameter() { ParameterName = "@fromcity", DbType = DbType.Int64, Value = scheduleInfo.RouteInfo.FromCity.CityId },
                        new SqlParameter() { ParameterName = "@tocity", DbType = DbType.Int64, Value = scheduleInfo.RouteInfo.ToCity.CityId }
                    ))
                    {
                        if (reader.Read())
                        { routeId = int.Parse(reader["RouteId"].ToString()); }
                    }

                    tran = db.BeginTransaction();
                    int ScheduleID = 0;
                    
                    //using (IDataReader reader = GetDatabaseConnection().ExecuteReader("InsertSchedule", scheduleInfo.FlightInfo.ID, routeId, Convert.ToDateTime(scheduleInfo.DepartureTime.ToString()), Convert.ToDateTime(scheduleInfo.ArrivalTime.ToString()), scheduleInfo.DurationInMins, scheduleInfo.IsActive))
                    ScheduleID = Convert.ToInt32(ExecuteStoredProcedureScalar(db, tran, "InsertSchedule",
                        new SqlParameter() { ParameterName = "@flightid", DbType = DbType.Int32, Value = scheduleInfo.FlightInfo.ID },
                        new SqlParameter() { ParameterName = "@routeid", DbType = DbType.Int32, Value = routeId },
                        new SqlParameter() { ParameterName = "@departuretime", DbType = DbType.DateTime, Value = Convert.ToDateTime(scheduleInfo.DepartureTime.ToString()) },
                        new SqlParameter() { ParameterName = "@arrivaltime", DbType = DbType.DateTime, Value = Convert.ToDateTime(scheduleInfo.ArrivalTime.ToString()) },
                        new SqlParameter() { ParameterName = "@dur", DbType = DbType.Int32, Value = scheduleInfo.DurationInMins },
                        new SqlParameter() { ParameterName = "@isactive", DbType = DbType.Boolean, Value = scheduleInfo.IsActive }
                    ));
                    if (ScheduleID > 0)
                    {
                        numberOfRows++;
                        foreach (FlightCost item in scheduleInfo.GetFlightCosts())
                        {
                            int ClassId = (int)item.Class;
                            string query = "insert into FlightCosts(ScheduleID,ClassID,CostPerTicket) values(" + ScheduleID + "," + ClassId + "," + item.CostPerTicket + ")";
                            numberOfRows += ExecuteQuery(db, tran, query);
                        }
                    }

                    tran.Commit();
                    db.Close();
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
                RollbackTransactionAndCloseConnection(tran);
				throw new ScheduleDAOException("Unable to add schedule");
			}
			catch (Exception)
			{
                RollbackTransactionAndCloseConnection(tran);
				throw new ScheduleDAOException("Unable to add schedule");
			}

			return numberOfRows;
		}
		#endregion

		#region Method to update the existing schedule for the database
		/// <summary>
		/// Update the existing schedule for the database
		/// </summary>
		/// <parameter name="scheduleInfo"></parameter>
		/// <returns>Returns the number of rows affected by the update</returns>
		public int UpdateSchedule(Model.Entities.AirTravel.Schedule scheduleInfo)
		{
			try
			{
				db = GetConnection();
				int routeId = 0;

                using (IDataReader Reader = ExecuteStoredProcedureResults(db, "getRouteId",
                    new SqlParameter() { ParameterName = "@fromcity", DbType = DbType.Int64, Value = scheduleInfo.RouteInfo.FromCity.CityId },
                    new SqlParameter() { ParameterName = "@tocity", DbType = DbType.Int64, Value = scheduleInfo.RouteInfo.ToCity.CityId }
                ))
				{
                    if (Reader.Read())
                    { routeId = int.Parse(Reader["RouteId"].ToString()); }
				}

                byte IsActive = (scheduleInfo.IsActive) ? (byte)1 : (byte)0;
                return ExecuteStoredProcedure(db, "UpdateSchedule",
                    new SqlParameter() { ParameterName = "@scheduleid", DbType = DbType.Int32, Value = scheduleInfo.ID },
                    new SqlParameter() { ParameterName = "@flightid", DbType = DbType.Int32, Value = scheduleInfo.FlightInfo.ID },
                    new SqlParameter() { ParameterName = "@routeid", DbType = DbType.Int32, Value = routeId },
                    new SqlParameter() { ParameterName = "@departuretime", DbType = DbType.DateTime, Value = Convert.ToDateTime(scheduleInfo.DepartureTime.ToString()) },
                    new SqlParameter() { ParameterName = "@arrivaltime", DbType = DbType.DateTime, Value = Convert.ToDateTime(scheduleInfo.ArrivalTime.ToString()) },
                    new SqlParameter() { ParameterName = "@durationinmins", DbType = DbType.Int32, Value = scheduleInfo.DurationInMins },
                    new SqlParameter() { ParameterName = "@isactive", DbType = DbType.Boolean, Value = IsActive }
                );
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to update schedule");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to update schedule");
			}
		}
		#endregion

		#region Method to update the existing flight cost for the specific schedule id for the database
		/// <summary>
		/// Update the existing flight cost for the specific schedule id for the database
		/// </summary>
		/// <parameter name="flightCostInfo"></parameter>
		/// <parameter name="scheduleInfo"></parameter>
		/// <returns>Returns the number of rows affected by the update</returns>
        public int UpdateScheduleFlightCost(long ScheduleId, FlightCost flightCostInfo)
		{
			try
			{
                return ExecuteStoredProcedure("UpdateFlightCost",
                    new SqlParameter() { ParameterName = "@scheduleid", DbType = DbType.Int32, Value = ScheduleId },
                    new SqlParameter() { ParameterName = "@classid", DbType = DbType.Int32, Value = flightCostInfo.Class },
                    new SqlParameter() { ParameterName = "@cost", DbType = DbType.Decimal, Value = flightCostInfo.CostPerTicket }
                );
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to update schedule flight cost");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to update schedule flight cost");
			}
		}
		#endregion

		#region Method to get the schedule details for a given schedule id from the database
		/// <summary>
		/// Get the schedule details for a given schedule id from the database
		/// </summary>
		/// <parameter name="scheduleId"></parameter>
		/// <returns>A Schedule for a given schedule id<Schedule></returns>
		public Model.Entities.AirTravel.Schedule GetSchedule(int scheduleId)
		{
            Schedule schedule = null;

			try
			{
                using (db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetScheduleFlightAndCosts",
                        new SqlParameter() { ParameterName = "@scheduleid", DbType = DbType.Int32, Value = scheduleId }
                    ))
                    {
                        reader.Read();

                        schedule = new Schedule();
                        schedule.ID = long.Parse(reader["ScheduleId"].ToString());

                        Airline airline = new Airline();
                        airline.Id = int.Parse(reader["AirlineId"].ToString());
                        airline.Name = reader["AirlineName"].ToString();

                        Flight flight = new Flight();
                        flight.ID = long.Parse(reader["FlightId"].ToString());
                        flight.AirlineForFlight = airline;
                        flight.Name = reader["FlightName"].ToString();

                        schedule.FlightInfo = flight;

                        City fromCity = new City();
                        fromCity.CityId = long.Parse(reader["FromId"].ToString());
                        fromCity.Name = reader["FromCity"].ToString();

                        City toCity = new City();
                        toCity.CityId = long.Parse(reader["ToId"].ToString());
                        toCity.Name = reader["ToCity"].ToString();

                        Route route = new Route();
                        route.ID = long.Parse(reader["RouteId"].ToString());
                        route.FromCity = fromCity;
                        route.ToCity = toCity;
                        route.DistanceInKms = long.Parse(reader["DistanceInKms"].ToString());
                        schedule.RouteInfo = route;
                        DateTime dtime = Convert.ToDateTime(reader["DepartureTime"]);
                        TimeSpan dTS = new TimeSpan(dtime.Hour, dtime.Minute, dtime.Second);

                        DateTime atime = Convert.ToDateTime(reader["ArrivalTime"]);
                        TimeSpan aTS = new TimeSpan(atime.Hour, atime.Minute, atime.Second);

                        schedule.DepartureTime = dTS;
                        schedule.ArrivalTime = aTS;

                        schedule.DurationInMins = int.Parse(reader["DurationInMins"].ToString());
                        schedule.IsActive = bool.Parse(reader["Status"].ToString());

                        reader.NextResult();
                        while (reader.Read())
                        {
                            FlightCost classCost = new FlightCost();
                            int classid = int.Parse(reader["ClassId"].ToString());
                            classCost.Class = (TravelClass)classid;
                            classCost.CostPerTicket = Convert.ToDecimal(reader["CostPerTicket"].ToString());
                            schedule.AddFlightCost(classCost);
                        }
                    }
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get the schedule details");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get the schedule details");
			}

			return schedule;
		}
		#endregion

		/// <summary>
		/// Method to get the travel inventory for the day
		/// </summary>
		/// <returns>Dataset containg the travel inventory</returns>
		public DataSet GetTravelInventory()
		{
			DataSet dsTravelInventory = new DataSet();

			try
			{
				int i = 3;
				IDbConnection conn = GetConnection();
                dsTravelInventory = ExecuteStoredProcedureDataSet(conn, "GetTravelInventoryDetails");

				foreach (DataRow row in dsTravelInventory.Tables[0].Rows)
				{
                    DataTable dtClasses = dsTravelInventory.Tables[1].Clone();
                    //foreach (var rw in dsTravelInventory.Tables[1].Select("ScheduleId=" + row["scheduleid"]))
                    //{
                    //    dtClasses.Rows.Add(rw);
                    //}
                    dsTravelInventory.Tables[1].Select("ScheduleId=" + row["scheduleid"]).CopyToDataTable(dtClasses, LoadOption.OverwriteChanges);

					DataTable dtTemp = dtClasses.Copy();
                    dtTemp.TableName = "Classes" + i;
                    dtTemp.Columns.Add("totalbooked");
                    dtTemp.Columns.Add("totalavailable");

					int j = 0;
                    foreach (DataRow rw in dtClasses.Rows)
					{
                        DataRow[] arrRows = dsTravelInventory.Tables[2].Select("ScheduleId=" + row["scheduleid"].ToString() + " and classid=" + rw["classid"].ToString());
                        //object o = dsTravelInventory.Tables[2].Select("ScheduleId=" + row["scheduleid"].ToString() + " and classid=" + rw["classid"].ToString())[0]["TotalBookings"];

						int totalbooked = 0;
                        if (arrRows.Length > 0)
						{
                            totalbooked = (int)arrRows[0]["TotalBookings"];
						}
						dtTemp.Rows[j]["totalbooked"] = totalbooked;					

						int totalSeats = Convert.ToInt32(dtTemp.Rows[j]["noofseats"]);
						dtTemp.Rows[j]["totalavailable"] = totalSeats - totalbooked;

						j++;
					}
					
					dsTravelInventory.Tables.Add(dtTemp);
					i++;
				}
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get schedules");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get schedules");
			}

			return dsTravelInventory;
		}
	}
}
