using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent route for air travel
    /// </summary>
    public class Route
    {
        #region Fields of the class

        /// <summary>
        /// List of schedules for a route
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();

        #endregion

        #region Properties of the class

        public long ID { get; set; }
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public double DistanceInKms { get; set; }
        public bool IsActive { get; set; }

        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets all the schedules for a route
        /// </summary>
        /// <returns>Returns list of schedules</returns>
        public List<Schedule> GetSchedules()
        {
            return schedules;
        }

        /// <summary>
        /// Adds a schedule for a route
        /// </summary>
        /// <param name="newSchedule"></param>
        public void AddSchedule(Schedule newSchedule)
        {
            schedules.Add(newSchedule);
        }

        #endregion

    }
}
