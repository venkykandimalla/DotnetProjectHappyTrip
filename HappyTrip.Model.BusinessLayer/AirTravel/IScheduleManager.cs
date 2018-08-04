using System;
using System.Data;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public interface IScheduleManager : IAirTravelManager
    {
        /// <summary>
        /// Add the schedules for the flight
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to add the schedule</exception>
        /// <returns>Returns the number of rows being affected by the insertion</returns>
        int AddSchedule(HappyTrip.Model.Entities.AirTravel.Schedule ScheduleInfo);

        /// <summary>
        /// Get the route id for a given schedule
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the route for a given schedule</exception>
        /// <returns>Returns the route id</returns>
        int GetRouteID(HappyTrip.Model.Entities.AirTravel.Schedule scheduleInfo);

        /// <summary>
        /// Get the schedule details for a given schedule id
        /// </summary>
        /// <parameter name="scheduleId"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedule</exception>
        /// <returns>Returns a schedule for a given schedule id</returns>
        HappyTrip.Model.Entities.AirTravel.Schedule GetSchedule(int scheduleId);

        /// <summary>
        /// Gets all the schedules
        /// </summary>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedules from the database</exception>
        /// <returns>Returns the list of schedules></returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.AirTravel.Schedule> GetSchedules();

        /// <summary>
        /// Update the existing the schedule details
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        int UpdateSchedule(HappyTrip.Model.Entities.AirTravel.Schedule ScheduleInfo);

        /// <summary>
        /// Update the existing flight cost for a given schedule
        /// </summary>
        /// <parameter name="flightcost"></parameter>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule cost</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        int UpdateScheduleFlightCost(long ScheduleId, HappyTrip.Model.Entities.AirTravel.FlightCost flightCostInfo);

		/// <summary>
		/// Method to get the travel inventory for the day
		/// </summary>
		/// <returns>Dataset containg the travel inventory</returns>
		DataSet GetTravelInventory();
    }
}
