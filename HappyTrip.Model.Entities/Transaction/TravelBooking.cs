using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent the travel booking related information
    /// </summary>
    public class TravelBooking
    {
        #region Fields of the class
        private Dictionary<AirTravel.TravelDirection, Booking> bookings = new Dictionary<AirTravel.TravelDirection, Booking>();
        #endregion


        /// <summary>
        /// Checks if the return journey booking details is available
        /// </summary>
        /// <returns></returns>
        public bool IsReturnAvailable()
        {
            bool isAvailable = false;
            try
            {
                if (bookings[AirTravel.TravelDirection.Return] != null)
                    isAvailable = true;
            }
            catch (KeyNotFoundException ex)
            {
                isAvailable=false;
            }
                            
            
            return isAvailable;
        }

        /// <summary>
        /// Gets the booking information for a travel direction given
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Booking GetBookingForTravel(AirTravel.TravelDirection direction)
        {
            Booking bookingForTravel = null;
            try
            {
                bookingForTravel = bookings[direction];
            }
            catch (KeyNotFoundException ex)
            {
            }

            return bookingForTravel;
        }

        /// <summary>
        /// Adds a booking for travel
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool AddBookingForTravel(AirTravel.TravelDirection direction, Booking booking)
        {
            if (!bookings.ContainsKey(direction))
            {
                bookings.Add(direction, booking);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the travel directions available for a booking
        /// </summary>
        /// <returns></returns>
        public List<AirTravel.TravelDirection> GetBookingTravelDirections()
        {
            if (bookings.Keys.Count == 0)
                throw new BookingTravelDirectionException("Booking Travel Direction Not Available");

            List<AirTravel.TravelDirection> travelDirections = new List<AirTravel.TravelDirection>();

            foreach (AirTravel.TravelDirection Direction in bookings.Keys)
            {
                travelDirections.Add(Direction);
            }

            return travelDirections;
        }
    }
}
