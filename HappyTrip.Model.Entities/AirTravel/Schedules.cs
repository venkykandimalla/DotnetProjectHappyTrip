using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent a collection of Schedule information
    /// </summary>
    public class Schedules : IEnumerable
    {
        #region Fields of the class
        /// <summary>
        /// Fields of the class - List of schedules
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Enumerates through the list of schedules and returns each schedule
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (Schedule s in schedules)
                yield return s;
        }

        #endregion

        #region Methods of the class
        /// <summary>
        /// Adds a new schedule to the collection
        /// </summary>
        /// <param name="newSchedule"></param>
        public void AddSchedule(Schedule newSchedule)
        {
            schedules.Add(newSchedule);
        }

        #endregion

        #region Properties of the class
        public int Count
        {
            get 
            {
                return schedules.Count;
            }
        }
        #endregion
    }
}
