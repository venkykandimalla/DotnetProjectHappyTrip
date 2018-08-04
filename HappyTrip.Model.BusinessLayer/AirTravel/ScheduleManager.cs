using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to scheduling of flights
    /// </summary>
    class ScheduleManager : HappyTrip.Model.BusinessLayer.AirTravel.IScheduleManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        IScheduleDAO scheduleDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ScheduleManager()
        {
            scheduleDAO = (IScheduleDAO)AirTravelDAOFactory.GetInstance().Create("scheduleDAO");
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="scheduleDAO"></param>
        public ScheduleManager(IScheduleDAO scheduleDAO)
        {
            this.scheduleDAO = scheduleDAO;
        }


        #region Method to get all the schedules
        /// <summary>
        /// Gets all the schedules
        /// </summary>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedules from the database</exception>
        /// <returns>Returns the list of schedules></returns>
        public List<Schedule> GetSchedules()
        {
			try
			{
                return scheduleDAO.GetSchedules();
			}
			catch (ScheduleDAOException ex)
			{
				throw new ScheduleManagerException("Unable to get schedule" ,ex);
			}
        }
        #endregion

        #region Method to get the route id for a given schedule
        /// <summary>
        /// Get the route id for a given schedule
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the route for a given schedule</exception>
        /// <returns>Returns the route id</returns>
        public int GetRouteID(Schedule scheduleInfo)
        {
			try
			{
                return scheduleDAO.GetRouteID(scheduleInfo);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to get route id", ex);
			}
        }
        #endregion

        #region Method to get the schedule details for a given schedule id
        /// <summary>
        /// Get the schedule details for a given schedule id
        /// </summary>
        /// <parameter name="scheduleId"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedule</exception>
        /// <returns>Returns a schedule for a given schedule id</returns>
        public Schedule GetSchedule(int scheduleId)
        {
			try
			{
                return scheduleDAO.GetSchedule(scheduleId);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to get schedule details for a given schedule id", ex);
			}
        }
        #endregion

        #region Method to add the schedule for the flight
        /// <summary>
        /// Add the schedules for the flight
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to add the schedule</exception>
        /// <returns>Returns the number of rows being affected by the insertion</returns>
        public int AddSchedule(Schedule scheduleInfo)
        {
            try
            {
                CheckIfScheduleAlreadyExists(scheduleInfo, "Add");               

                return scheduleDAO.AddSchedule(scheduleInfo);
            }
            catch (ScheduleManagerException)
            {
                throw;
            }
            catch (ScheduleDAOException ex)
            {
                throw new ScheduleManagerException("Unable to add schedule", ex);
            }
        }
        #endregion

        #region Method to update the existing the schedule details
        /// <summary>
        /// Update the existing the schedule details
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        public int UpdateSchedule(Schedule ScheduleInfo)
        {
			try
			{
                CheckIfScheduleAlreadyExists(ScheduleInfo, "Edit");

                return scheduleDAO.UpdateSchedule(ScheduleInfo);
			}
            catch (ScheduleManagerException)
            {
                throw;
            }
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to update schedule", ex);
			}
        }

        /// <summary>
        /// Method to check if schedule already exists with the same departure time
        /// </summary>
        /// <param name="scheduleInfo"></param>
        /// <exception cref="ScheduleManagerException">Thorwn when schedule already exists for the given departure time</exception>
        /// <param name="action"></param>
        private void CheckIfScheduleAlreadyExists(Schedule scheduleInfo, string action)
        {
            List<Schedule> schedules = GetSchedules();
            if (action == "Add")
            {
                foreach (Schedule sch in schedules)
                {
                    if (sch.FlightInfo.ID == scheduleInfo.FlightInfo.ID &&
                        sch.DepartureTime == scheduleInfo.DepartureTime)
                    {
                        throw new ScheduleManagerException("Schedule already exists for the selected time and flight");
                    }
                }
            }
            else if (action == "Edit")
            {
                foreach (Schedule sch in schedules)
                {
                    if (sch.ID != scheduleInfo.ID &&
                        sch.FlightInfo.ID == scheduleInfo.FlightInfo.ID &&
                        sch.DepartureTime == scheduleInfo.DepartureTime)
                    {
                        throw new ScheduleManagerException("Schedule already exists for the selected time and flight");
                    }
                }
            }
        }
        #endregion

        #region Method to update the existing flight cost for a given schedule
        /// <summary>
        /// Update the existing flight cost for a given schedule
        /// </summary>
        /// <parameter name="flightcost"></parameter>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule cost</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        public int UpdateScheduleFlightCost(long ScheduleId, FlightCost flightCostInfo)
        {
			try
			{
                return scheduleDAO.UpdateScheduleFlightCost(ScheduleId, flightCostInfo);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to update schedule flight cost", ex);
			}
        }
        #endregion


		/// <summary>
		/// Method to get the travel inventory for the day
		/// </summary>
		/// <returns>Dataset containg the travel inventory</returns>
		public DataSet GetTravelInventory()
		{
			try
			{
				return scheduleDAO.GetTravelInventory();
			}
			catch (ScheduleDAOException ex)
			{
				throw new ScheduleManagerException("Unable to get schedule inventory", ex);
			}
		}
    }
}

