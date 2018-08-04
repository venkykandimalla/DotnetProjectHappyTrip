using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the schedule information based on the travel information provided
    /// </summary>
    public class TravelSchedule
    {
        #region Fields of the class
        /// <summary>
        /// List of schedules for the given travel plan by user
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();
        #endregion

        #region Properties of the class
        public ScheduleType Type { get; set; }
        public decimal TotalCostPerTicket { get; set; }
        #endregion

        #region Methods of the class
        /// <summary>
        /// Gets all the schedules for a flight
        /// </summary>
        /// <returns>Returns the list of schedules</returns>
        public List<Schedule> GetSchedules()
        {
            return schedules;
        }

        /// <summary>
        /// Adds a schedule for a flight
        /// </summary>
        /// <param name="newSchedule"></param>
        public void AddSchedule(Schedule newSchedule)
        {
            schedules.Add(newSchedule);
        }
        #endregion
    }
}
