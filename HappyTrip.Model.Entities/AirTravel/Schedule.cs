using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent schedule for flights flying in different routes with time information
    /// </summary>
    public class Schedule
    {
        #region Fields of the class

        /// <summary>
        /// List of cost information for a given schedule based on the class
        /// </summary>
        private List<FlightCost> flightCosts = new List<FlightCost>();
        #endregion

        #region Properties of the class

        public long ID { get; set; }
        public Flight FlightInfo { get; set; }
        public Route RouteInfo { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int DurationInMins { get; set; }
        public bool IsActive { get; set; }
        
        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets the flight costs for a schedule
        /// </summary>
        /// <returns>Returns the list of flight costs</returns>
        public List<FlightCost> GetFlightCosts()
        {
            return flightCosts;
        }

        /// <summary>
        /// Adds a flight cost for a schedule
        /// </summary>
        /// <param name="newFlightCost"></param>
        public void AddFlightCost(FlightCost newFlightCost)
        {
            flightCosts.Add(newFlightCost);
        }
        #endregion
    }
}
