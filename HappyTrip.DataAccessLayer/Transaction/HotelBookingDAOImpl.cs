using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.Data;

namespace HappyTrip.DataAccessLayer.Transaction
{
    class HotelBookingDAOImpl : IBookingDAOImpl
    {
        #region IBookingDAOImpl Members

        public string MakeBooking(Booking NewBooking, IDbConnection DbConnection, IDbTransaction tran)
        {
            //Downcast to flight booking
            NewBooking = (HotelBooking)NewBooking;

            //Write code to store data into database



            return null;
        }

        #endregion
    }
}
