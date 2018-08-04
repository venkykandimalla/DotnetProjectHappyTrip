using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent airline information for air travel
    /// </summary>
    public class Airline
    {
        #region Fields of the class
        /// <summary>
        /// Flights for an airline
        /// </summary>
        private List<Flight> flights = new List<Flight>();
        
        #endregion

        #region Properties of the class
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Logo { get; set; }

        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets all the flights of an airline
        /// </summary>
        /// <returns>Returns the list of the flights for an airline</returns>
        public List<Flight> GetFlights()
        {
            return flights;
        }

        /// <summary>
        /// Adds a flight for an airline 
        /// </summary>
        /// <param name="NewFlight"></param>
        public void AddFlight(Flight newFlight)
        {
            flights.Add(newFlight);
        }

        #endregion
    }
}
