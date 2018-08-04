using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using HappyTrip.DataAccessLayer.Common;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Class to represent the factory that would create all the data access objects needed
    /// to perform database related activities for air travel
    /// </summary>
   public class AirTravelDAOFactory
    {
        /// <summary>
        /// Fields of the class - Instance of the factory created - Singleton
        /// </summary>
        private static AirTravelDAOFactory instance = new AirTravelDAOFactory();

        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private AirTravelDAOFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the AirTravelDAOFactory
        /// </summary>
        /// <returns></returns>
        public static AirTravelDAOFactory GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// Returns the instance of the Airline data access object as an interface
        /// </summary>
        /// <returns></returns>
        public IAirlineDAO CreateAirline()
        {
            return new AirlineDAO();
        }

        /// <summary>
        /// Returns the instance of the Flight data access object as an interface
        /// </summary>
        /// <returns></returns>
        public IFlightDAO CreateFlight()
        {
            return new FlightDAO();
        }

        /// <summary>
        /// Returns the instance of the Schedule data access object as an interface
        /// </summary>
        /// <returns></returns>
        public IScheduleDAO CreateSchedule()
        {
            return new ScheduleDAO();
        }


        /// <summary>
        /// Returns the instance of the Route data access object as an interface
        /// </summary>
        /// <returns></returns>
        public IRouteDAO CreateRoute()
        {
            return new RouteDAO();
        }

	   /// <summary>
	   /// Factory method to construct various business manager objects
	   /// </summary>
	   /// <param name="managerType">String that represents the DAO type</param>
	   /// <returns></returns>
		public IAirTravelDAO Create(string managerType)
		{
			try
			{
				IAirTravelDAO airTravelDAO = null;
				AppSettingsReader asr = new AppSettingsReader();

				string className = asr.GetValue(managerType, typeof(string)).ToString();

				Assembly asm = Assembly.GetExecutingAssembly();

				object objDAO = asm.CreateInstance(className);
				airTravelDAO = (IAirTravelDAO)objDAO;

				return airTravelDAO;
			}
			catch (AirlineDAOException ae)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

    }
}
