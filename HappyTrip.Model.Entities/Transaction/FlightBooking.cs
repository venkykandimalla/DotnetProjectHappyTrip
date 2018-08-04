using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent flight booking information
    /// </summary>
    public class FlightBooking : Booking
    {
        #region Fields of the class

        private List<Passenger> passengers = new List<Passenger>();

        #endregion

        #region Properties of the class

        public TravelSchedule TravelScheduleInfo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public int NoOfSeats { get; set; }
        public FlightClass Class { get; set; }
        public TravelInsurance Insurance { get; set; }

        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets all the passengers for a booking
        /// </summary>
        /// <returns></returns>
        public List<Passenger> GetPassengers()
        {
            return passengers;
        }

        /// <summary>
        /// Adds a passenger for a booking
        /// </summary>
        /// <param name="newPassenger"></param>
        public void AddPassenger(Passenger newPassenger)
        {
            passengers.Add(newPassenger);
        }

        #endregion
    }
}
