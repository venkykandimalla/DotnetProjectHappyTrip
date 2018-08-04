using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.Model.BusinessLayer.UserAccount
{
    class AccountManager : IAccountManager
    {
        #region Method to get all the bookings made by the user
        /// <summary>
        /// Gets the booking history for a user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public BookingHistory GetBookingHistoryForUser(string UserName)
        {
            BookingHistory Bookings = null;


            return Bookings;
        }
        #endregion
    }
}
