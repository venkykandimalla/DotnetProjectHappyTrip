using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the search result when searched for flights
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Fields of the class - List of travel schedules for a given search
        /// </summary>
        private List<TravelSchedule> travelSchedules = new List<TravelSchedule>();


        #region Methods of the class

        /// <summary>
        /// Gets all the travel schedules from the result
        /// </summary>
        /// <returns>Returns the list of travel schedules from the result</returns>
        public List<TravelSchedule> GetTravelSchedules()
        {
            return travelSchedules;
        }

        /// <summary>
        /// Adds a travel schedule into the result
        /// </summary>
        /// <param name="newTravelSchedule"></param>
        public void AddTravelSchedule(TravelSchedule newTravelSchedule)
        {
            travelSchedules.Add(newTravelSchedule);
        }

        #endregion

    }
}
