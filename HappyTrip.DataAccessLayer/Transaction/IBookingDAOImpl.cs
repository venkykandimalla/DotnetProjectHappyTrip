using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Interface to define the booking related database implementation of different types
    /// </summary>
    interface IBookingDAOImpl
    {
        /// <summary>
        /// Inserts into database the booking information for different types
        /// </summary>
        /// <param name="newBooking"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="AirTravelBookingException">Throws the AirTravelBookingException, if unable to store a booking</exception>
        /// <returns>Returns the booking reference number</returns>
        string MakeBooking(HappyTrip.Model.Entities.Transaction.Booking newBooking, IDbConnection dbConnection, IDbTransaction tran);
    }
}
