using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent the database activities related to AirTravel Booking
    /// </summary>
    class AirTravelBookingDAOImpl : Common.DAO, IBookingDAOImpl
    {
        #region Method to store booking details for an air travel

        /// <summary>
        /// Inserts into database the booking for air travel
        /// </summary>
        /// <param name="newBooking"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="AirTravelBookingException">Throws the AirTravelBookingException, if unable to store a booking</exception>
        /// <returns>Returns the booking reference number</returns>
        public string MakeBooking(Booking newBooking, IDbConnection dbConnection, IDbTransaction tran)
        {
            string bookingReferenceNo = string.Empty;

            //Downcast to flight booking
            FlightBooking airBooking = (FlightBooking)newBooking;

            try
            {
                //Write code to store data into database
                IDbCommand command = CreateCommand(dbConnection, "BookFlightTicket", CommandType.StoredProcedure, tran);

                command.Parameters.Add(new SqlParameter() { ParameterName = "@TypeID", DbType = DbType.Int32, Value = (int)airBooking.BookingType});
                command.Parameters.Add(new SqlParameter() { ParameterName = "@DateOfJourney", DbType = DbType.DateTime, Value = airBooking.DateOfJourney });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@NoOfSeats", DbType = DbType.Int32, Value = airBooking.NoOfSeats });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@ClassID", DbType = DbType.Int32, Value = (int)airBooking.Class.ClassInfo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@ContactName", DbType = DbType.String, Value = airBooking.Contact.ContactName });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@Address", DbType = DbType.String, Value = airBooking.Contact.Address });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@City", DbType = DbType.String, Value = airBooking.Contact.City });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@State", DbType = DbType.String, Value = airBooking.Contact.State });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@PinCode", DbType = DbType.String, Value = "000000" });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@Email", DbType = DbType.String, Value = airBooking.Contact.Email });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@PhoneNo", DbType = DbType.String, Value = airBooking.Contact.PhoneNo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@MobileNo", DbType = DbType.String, Value = airBooking.Contact.MobileNo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@PaymentRefernceNo", DbType = DbType.String, Value = airBooking.PaymentInfo.ReferenceNo });
                command.Parameters.Add(new SqlParameter() { ParameterName = "@TotalCost", DbType = DbType.Decimal, Value = airBooking.TotalCost });
                if (airBooking.Insurance != null)
                { command.Parameters.Add(new SqlParameter() { ParameterName = "@Insurance", DbType = DbType.Decimal, Value = airBooking.Insurance.Amount }); }
                else
                { command.Parameters.Add(new SqlParameter() { ParameterName = "@Insurance", DbType = DbType.Decimal, Value = 0 }); }

                //Concatenate to send to database as a single string
                string passengerDetails = String.Empty;
                string name = String.Empty;
                string gender = String.Empty;
                string dob = String.Empty;

                foreach (Passenger p in airBooking.GetPassengers())
                {
                    name = p.Name;
                    gender = p.Gender.ToString();
                    dob = p.DateOfBirth.ToShortDateString();

                    passengerDetails += name + "|" + gender + "|" + dob + ";";
                }

                command.Parameters.Add(new SqlParameter() { ParameterName = "@PassengerDetails", DbType = DbType.String, Value = passengerDetails });

                SqlParameter prmBookingReferenceNumber = new SqlParameter() { ParameterName = "@BookingReferenceNumber", DbType = DbType.String, Size = 100, Value = 100, Direction = ParameterDirection.Output };
                command.Parameters.Add(prmBookingReferenceNumber);

                SqlParameter prmLastBookingID = new SqlParameter() { ParameterName = "@LastBookingID", DbType = DbType.Int64, Value = 0, Direction = ParameterDirection.Output };
                command.Parameters.Add(prmLastBookingID);

                //Execute the command
                command.ExecuteNonQuery();

                //Get the values from the database
                bookingReferenceNo = prmBookingReferenceNumber.Value.ToString();
                long bookingId = Convert.ToInt64(prmLastBookingID.Value);

                //Insert the schedules for a booking
                foreach (Schedule s in airBooking.TravelScheduleInfo.GetSchedules())
                {
                    InsertBookingSchedule(bookingId, s.ID, s.GetFlightCosts().FirstOrDefault().CostPerTicket, dbConnection, tran);
                }
            }
            catch(AirTravelBookingException)
            {
                throw;
            }
            catch (DbException ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel booking", ex);
            }
            catch (Exception ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel booking", ex);
            }

            return bookingReferenceNo;
        }

        /// <summary>
        /// Inserts the schedule for a booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="costPerTicket"></param>
        /// <param name="dbConnection"></param>
        /// <returns></returns>
        private bool InsertBookingSchedule(long bookingId, long scheduleId, decimal costPerTicket, IDbConnection dbConnection, IDbTransaction tran)
        {
            bool isStored = false;

            try
            {
                //Write code to store data into database
                ExecuteStoredProcedure(dbConnection, tran, "InsertFlightTicketSchedule",
                    new SqlParameter() { ParameterName = "@BookingId", DbType = DbType.Int64, Value = bookingId },
                    new SqlParameter() { ParameterName = "@ScheduleId", DbType = DbType.Int64, Value = scheduleId },
                    new SqlParameter() { ParameterName = "@CostPerTicket", DbType = DbType.Decimal, Value = costPerTicket }
                );

                isStored = true;
            }
            catch (DbException ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
            }
            catch (Exception ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
            }

            return isStored;
        }
        #endregion
    }
}
