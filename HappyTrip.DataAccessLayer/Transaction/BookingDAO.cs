using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Transaction;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to implement Booking related database activities for different types of booking
    /// </summary>
    class BookingDAO : DataAccessLayer.Common.DAO, HappyTrip.DataAccessLayer.Transaction.IBookingDAO
    {
        /// <summary>
        /// Field of the class - Having a static instance. Singleton
        /// </summary>
        private static BookingDAO instance = new BookingDAO();

        /// <summary>
        /// Type of Booking implementation for a booking. AirTravel or Hotel, etc..
        /// </summary>
        private static IBookingDAOImpl daoImpl = null;

        /// <summary>
        /// Default Constructor - Made private to avoid construction from outside
        /// </summary>
        private BookingDAO()
        {
            
        }

        #region Method to get the instance of BookingDAO
        /// <summary>
        /// Gets the instance of Booking Data Access Object as this a singleton
        /// </summary>
        /// <exception cref="InvalidBookingTypeDAOException">Throws an exception if an invalid booking type</exception>
        /// <returns>Instance of the Booking Data Access Object</returns>
        public static BookingDAO GetInstance(BookingTypes type)
        {
            try
            {
                daoImpl = BookingDAOImplFactory.GetInstance().Create(type);
            }
            catch (InvalidBookingTypeDAOException)
            {
                throw;
            }

            return instance;
        }
        #endregion


        /// <summary>
        /// Inserts into database the booking information for different types
        /// </summary>
        /// <param name="newBooking"></param>
        /// <exception cref="BookingDAOException">Throws the BookingDAOException, if unable to store a booking</exception>
        /// <returns>Returns the booking reference number</returns>
        public string MakeBooking(HappyTrip.Model.Entities.Transaction.Booking newBooking)
        {
            IDbTransaction tran = null;
            string bookingReferenceNo = string.Empty;

            try
            {
                //Get the database connection from DAO class that is inherited
                using (IDbConnection dbConnection = GetConnection())
                {
                    tran = dbConnection.BeginTransaction();

                    //Delegate to the corresponding dao implementation created during call to get instance
                    bookingReferenceNo = daoImpl.MakeBooking(newBooking, dbConnection, tran);

                    if (!newBooking.UserName.Equals("Anonymous", StringComparison.OrdinalIgnoreCase))
                    {
                        StoreBookingForUser(bookingReferenceNo, newBooking.UserName, dbConnection, tran);
                    }

                    tran.Commit();
                    dbConnection.Close();
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to store Booking Information", ex);
            }
            catch (BookingDAOException)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw;
            }
            catch (AirTravelBookingException ex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to store Air Travel Booking Information", ex);
            }
            catch (DbException ex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to store Booking Information", ex);
            }
            catch (Exception ex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to store Booking Information", ex);
            }

            return bookingReferenceNo;
        }

        /// <summary>
        /// Stores booking for a user
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="userName"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="BookingDAOException">Throws the BookingDAOException, if unable to store a booking</exception>
        private void StoreBookingForUser(string bookingRefernceNo, string userName, IDbConnection dbConnection, IDbTransaction tran)
        {
            try
            {
                //Write code to store data into database
                ExecuteStoredProcedure(dbConnection, tran, "InsertBookingForUser",
                    new SqlParameter() { ParameterName = "@BookingReferenceNumber", DbType = DbType.String, Value = bookingRefernceNo },
                    new SqlParameter() { ParameterName = "@UserName", DbType = DbType.String, Value = userName }
                );
            }
            catch (DbException ex)
            {
                throw new BookingDAOException("Unable to insert booking for user", ex);
            }
            catch (Exception ex)
            {
                throw new BookingDAOException("Unable to insert booking for user", ex);
            }
        }

        //public FlightBooking GetFlightBooking(string bookingRefNo)
        //{
        //    try
        //    {
        //        IDbConnection conn = this.GetConnection();
        //        conn.Open();
        //        IDbCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "SELECT * FROM BOOKINGS WHERE BookingReferenceNo = @bookingrefno and IsCanceled=0";
        //        IDbDataParameter p1 = cmd.CreateParameter();
        //        p1.ParameterName = "@bookingrefno";
        //        p1.Value = bookingRefNo;
        //        cmd.Parameters.Add(p1);
        //        FlightBooking booking = null;
        //        using (IDataReader reader = cmd.ExecuteReader())
        //        {

        //            while (reader.Read())
        //            {
        //                booking = new FlightBooking();
        //                booking.BookingId = long.Parse(reader["BookingId"].ToString());
        //                booking.BookingType = BookingTypes.Flight;
        //                booking.BookingDate = DateTime.Parse(reader["BookingDate"].ToString());
        //                booking.ReferenceNo = reader["BookingReferenceNo"].ToString();
        //                booking.TotalCost = decimal.Parse(reader["TotalCost"].ToString());
        //                booking.IsCanceled = bool.Parse(reader["IsCanceled"].ToString());
        //            }
        //            if (booking == null)
        //                throw new BookingDAOException("No such booking available for the given reference number");
        //        }
        //        cmd.CommandText = "SELECT * FROM FLIGHTBOOKINGS WHERE BOOKINGID = @BOOKINGID";
        //        cmd.CommandType = CommandType.Text;
        //        IDbDataParameter p2 = cmd.CreateParameter();
        //        p2.ParameterName = "@BOOKINGID";
        //        p2.Value = booking.BookingId;
        //        cmd.Parameters.Add(p2);
        //        using (IDataReader reader2 = cmd.ExecuteReader())
        //        {
        //            while (reader2.Read())
        //            {
        //                booking.DateOfJourney = DateTime.Parse(reader2["DateOfJourney"].ToString());
        //                booking.NoOfSeats = int.Parse(reader2["NoOfSeats"].ToString());

        //            }
        //        }
        //        return booking;
        //    }
        //    catch (Exception)
        //    {

        //        throw new BookingDAOException("Unable to get booking info, database error");
        //    }
        //    finally
        //    {
               
        //    }
        //}

        /// <summary>
        /// Gets the Flight Booking for a given booking reference number
        /// </summary>
        /// <param name="bookingRefNo"></param>
        /// <returns></returns>
        public DataSet GetFlightBooking(string bookingRefNo, Guid CurrentUserId)
        {
            IDbConnection db = null;
            DataSet dataset = new DataSet();

            try
            {
                using (db = GetConnection())
                {
                    bool isAvailableForCancel = true;

                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetFlightBookingByBookingReferenceNo",
                        new SqlParameter() { ParameterName = "@BookingReferenceNo", DbType = DbType.String, Value = bookingRefNo },
                        new SqlParameter() { ParameterName = "@CurrentUserId", DbType = DbType.Guid, Value = CurrentUserId },
                        new SqlParameter() { ParameterName = "@IsCancelAvailable", DbType = DbType.Boolean, Value = 1, Direction = ParameterDirection.Output }
                    ))
                    {
                        DataTable booking = dataset.Tables.Add("FlightBooking");

                        booking.Columns.Add("BookingId", typeof(long));
                        booking.Columns.Add("BookingDate", typeof(DateTime));
                        booking.Columns.Add("BookingReferenceNo", typeof(string));
                        booking.Columns.Add("Remarks", typeof(string));
                        booking.Columns.Add("TotalCost", typeof(decimal));
                        booking.Columns.Add("IsCanceled", typeof(bool));
                        booking.Columns.Add("ClassId", typeof(int));
                        booking.Columns.Add("DateOfJourney", typeof(DateTime));
                        booking.Columns.Add("NoOfSeats", typeof(int));
                        booking.Columns.Add("ScheduleId", typeof(int));
                        booking.Columns.Add("CostPerTicket", typeof(decimal));

                        booking.Columns.Add("DepartureTime", typeof(DateTime));
                        booking.Columns.Add("ArrivalTime", typeof(DateTime));
                        booking.Columns.Add("DurationInMins", typeof(int));
                        booking.Columns.Add("FlightId", typeof(int));
                        booking.Columns.Add("FlightName", typeof(string));
                        booking.Columns.Add("AirlineId", typeof(int));
                        booking.Columns.Add("AirlineName", typeof(string));
                        booking.Columns.Add("AirlineCode", typeof(string));
                        booking.Columns.Add("AirlineLogo", typeof(string));
                        booking.Columns.Add("DistanceInKms", typeof(int));
                        booking.Columns.Add("FromCityId", typeof(int));
                        booking.Columns.Add("FromCityName", typeof(string));
                        booking.Columns.Add("ToCityId", typeof(int));
                        booking.Columns.Add("ToCityName", typeof(string));

                        booking.Columns.Add("ClassType", typeof(string));

                        while (reader.Read())
                        {
                            DataRow rw = booking.NewRow();

                            rw["BookingId"] = reader["BookingId"];
                            rw["BookingDate"] = reader["BookingDate"];
                            rw["BookingReferenceNo"] = reader["BookingReferenceNo"];
                            rw["Remarks"] = reader["Remarks"];
                            rw["TotalCost"] = reader["TotalCost"];
                            rw["IsCanceled"] = reader["IsCanceled"];
                            rw["ClassId"] = reader["ClassId"];
                            rw["DateOfJourney"] = reader["DateOfJourney"];
                            rw["NoOfSeats"] = reader["NoOfSeats"];
                            rw["CostPerTicket"] = reader["CostPerTicket"];
                            rw["ScheduleId"] = reader["ScheduleId"];
                            rw["CostPerTicket"] = reader["CostPerTicket"];
                            rw["DepartureTime"] = reader["DepartureTime"];
                            rw["ArrivalTime"] = reader["ArrivalTime"];
                            rw["DurationInMins"] = reader["DurationInMins"];
                            rw["FlightId"] = reader["FlightId"];
                            rw["FlightName"] = reader["FlightName"];
                            rw["AirlineName"] = reader["AirlineName"];
                            rw["AirlineCode"] = reader["AirlineCode"];
                            rw["AirlineLogo"] = reader["AirlineLogo"];
                            rw["DistanceInKms"] = reader["DistanceInKms"];
                            rw["FromCityId"] = reader["FromCityId"];
                            rw["FromCityName"] = reader["FromCityName"];
                            rw["ToCityId"] = reader["ToCityId"];
                            rw["ToCityName"] = reader["ToCityName"];

                            rw["ClassType"] = reader["ClassType"];

                            booking.Rows.Add(rw);
                        }

                        if (!isAvailableForCancel)
                        { return null; }
                        
                        return dataset;
                    }
                }
            }
            catch (Common.ConnectToDatabaseException dbex)
            {
                throw new Exception("Unable to connect to database server", dbex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsBookingsAvailable(string bookingRefNo)
        {
            try
            {
                int isFound = (int)ExecuteQueryScalar("SELECT COUNT(*) FROM BOOKINGS WHERE BookingReferenceNo = '" + bookingRefNo + "'");
                return isFound >= 1;
            }
            catch (SqlException sqlex)
            {
                throw new BookingDAOException("Unable to get booking availability", sqlex);
            }
            catch (Exception ex)
            {
                throw new BookingDAOException("Unable to get booking availability", ex);
            }
        }

        public bool CancelBooking(Cancelation cancelation)
        {
            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                using (conn = this.GetConnection())
                {
                    tran = conn.BeginTransaction();



                    IDbCommand cmd1 = conn.CreateCommand();
                    cmd1.Transaction = tran;
                    cmd1.CommandText = "insert into bookingcancelations values (@bookingid, @cancelationdate, @refoundamount)";
                    cmd1.CommandType = CommandType.Text;

                    IDbDataParameter p1 = cmd1.CreateParameter();
                    p1.ParameterName = "@bookingid";
                    p1.Value = cancelation.BookingID;
                    cmd1.Parameters.Add(p1);

                    IDbDataParameter p2 = cmd1.CreateParameter();
                    p2.ParameterName = "@cancelationdate";
                    p2.Value = cancelation.CancelationDate;
                    cmd1.Parameters.Add(p2);

                    IDbDataParameter p3 = cmd1.CreateParameter();
                    p3.ParameterName = "@refoundamount";
                    p3.Value = cancelation.RefundAmount;
                    cmd1.Parameters.Add(p3);

                    cmd1.ExecuteNonQuery();



                    IDbCommand cmd2 = conn.CreateCommand();
                    cmd2.Transaction = tran;
                    cmd2.CommandText = "update bookings set iscanceled = 1 where bookingid = @bookingid";
                    cmd2.CommandType = CommandType.Text;

                    IDbDataParameter p4 = cmd2.CreateParameter();
                    p4.ParameterName = "@bookingid";
                    p4.Value = cancelation.BookingID;
                    cmd2.Parameters.Add(p4);

                    cmd2.ExecuteNonQuery();



                    ExecuteStoredProcedure(conn, tran, "DeductHappyMilesForCancellation",
                        new SqlParameter() { ParameterName = "@bookingrefno", DbType = DbType.String, Value = cancelation.BookingReferenceNo },
                        new SqlParameter() { ParameterName = "@username", DbType = DbType.String, Value = cancelation.UserName }
                    );

                    tran.Commit();
                    conn.Close();
                    return true;
                }
            }
            catch (SqlException sqlex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to cancel the bookings", sqlex);
            }
            catch (Exception ex)
            {
                RollbackTransactionAndCloseConnection(tran);
                throw new BookingDAOException("Unable to cancel the bookings", ex);
            }
        }
    }
}
