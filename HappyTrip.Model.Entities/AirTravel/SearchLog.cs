using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the log of search results when searched by a user
    /// </summary>
    public class SearchLog
    {
        #region Fields of the class

        /// <summary>
        /// Represents all the search results for different travel directions
        /// </summary>
        private Dictionary<TravelDirection, SearchResult> schedulesLog = new Dictionary<TravelDirection, SearchResult>();

        #endregion


        #region Methods of the class

        /// <summary>
        /// Gets the search result for a specific direction of travel
        /// </summary>
        /// <param name="Direction"></param>
        /// <returns>Returns the search result object for a given travel direction</returns>
        public SearchResult GetSearchResult(TravelDirection direction)
        {
            return schedulesLog[direction];
        }

        /// <summary>
        /// Adds the search result to the log
        /// </summary>
        /// <param name="result"></param>
        /// <param name="direction"></param>
        public void AddSearchResultToLog(TravelDirection direction, SearchResult result)
        {
            if (schedulesLog.ContainsKey(direction))
                schedulesLog[direction] = result;
            else
                schedulesLog.Add(direction, result);
        }

        #endregion

    }
}
