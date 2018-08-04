using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    public class BookingHistory
    {
        #region Fields of the class
        private Dictionary<BookingTypes, List<Booking>> bookings = new Dictionary<BookingTypes, List<Booking>>();
        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets all the bookings for a particular booking type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Booking> GetBookings(BookingTypes type)
        {
            return bookings[type];
        }

        /// <summary>
        /// Adds a booking to the collection
        /// </summary>
        /// <param name="NewBooking"></param>
        /// <param name="type"></param>
        public void AddBooking(Booking NewBooking, BookingTypes type)
        {
            if (bookings[type] == null)
            {
                List<Booking> TempBookings = new List<Booking>();
                TempBookings.Add(NewBooking);

                bookings.Add(type, TempBookings);
            }
            else
            {
                bookings[type].Add(NewBooking);
            }
        }
        #endregion
    }
}
