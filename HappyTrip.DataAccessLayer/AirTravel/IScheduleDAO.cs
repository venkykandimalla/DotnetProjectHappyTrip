using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the schedule operations to be performed on the database
    /// </summary>
    public interface IScheduleDAO : IAirTravelDAO
    {
        /// <summary>
        /// Gets the route id for a schedule from the database
        /// </summary>
        /// <parameter name="ScheduleInfo"></parameter>
        /// <returns>Returns the route id for a given schedule</returns>
        int GetRouteID(Model.Entities.AirTravel.Schedule scheduleInfo);

        /// <summary>
        /// Gets the schedules from the database
        /// </summary>
        /// <returns>Returns the list of schedules from the database<Schedule></returns>
        List<Schedule> GetSchedules();

        /// <summary>
        /// Add the schedule for the database
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <returns>Returns the number of rows affected by the insert</returns>
        int AddSchedule(Schedule scheduleInfo);

        /// <summary>
        /// Update the existing schedule for the database
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <returns>Returns the number of rows affected by the update</returns>
        int UpdateSchedule(Schedule scheduleInfo);

        /// <summary>
        /// Update the existing flight cost for the specific schedule id for the database
        /// </summary>
        /// <parameter name="flightCostInfo"></parameter>
        /// <parameter name="scheduleInfo"></parameter>
        /// <returns>Returns the number of rows affected by the update</returns>
        int UpdateScheduleFlightCost(long ScheduleId, FlightCost flightCostInfo);

        /// <summary>
        /// Get the schedule details for a given schedule id from the database
        /// </summary>
        /// <parameter name="scheduleId"></parameter>
        /// <returns>A Schedule for a given schedule id<Schedule></returns>
        Schedule GetSchedule(int scheduleId);

		/// <summary>
		/// Method to get the travel inventory for the day
		/// </summary>
		/// <returns>Dataset containg the travel inventory</returns>
		DataSet GetTravelInventory();
    }
}
