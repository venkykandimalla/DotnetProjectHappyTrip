using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Common;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to routes of the flight
    /// </summary>
    class RouteManager : HappyTrip.Model.BusinessLayer.AirTravel.IRouteManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        IRouteDAO routeDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteManager()
        {
            routeDAO = (IRouteDAO)AirTravelDAOFactory.GetInstance().Create("routeDAO");
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="routeDAO"></param>
        public RouteManager(IRouteDAO routeDAO)
        {
            this.routeDAO = routeDAO;
        }

        #region Method to get all the flight routes
        /// <summary>
        /// Gets the flight routes
        /// </summary>
        /// <exception cref="RouteManagerException">Thrown when unable to get routes</exception>
        /// <returns>Returns a list with all the route information</returns>
        public List<Route> GetRoutes()
        {
           
			try
			{
				DataSet dsDS = routeDAO.GetRoutes();


                var routes = from route in dsDS.Tables[0].AsEnumerable().Distinct()
                             orderby route["DistanceInKms"]
                             select new Route
                             {
                                 ID = Convert.ToInt64(route["RouteId"]),
                                 //FromCity = CityDAOFactory.GetInstance().CreateCity().GetCityById(Convert.ToInt64(route["FromCityId"])),
                                 //ToCity = CityDAOFactory.GetInstance().CreateCity().GetCityById(Convert.ToInt64(route["ToCityId"])),
                                 FromCity = new City() { CityId = (long)route["FromCityId"], Name = (string)route["FromCityName"], StateInfo = new State() { StateId = (long)route["FromStateId"], Name = (string)route["FromStateName"] } },
                                 ToCity = new City() { CityId = (long)route["ToCityId"], Name = (string)route["ToCityName"], StateInfo = new State() { StateId = (long)route["ToStateId"], Name = (string)route["ToStateName"] } },
                                 DistanceInKms = Convert.ToDouble(route["DistanceInKms"]),
                                 IsActive = Convert.ToBoolean(route["Status"])
                             };

    			return routes.ToList<Route>();
			}
			catch (RouteDAOException ex)
			{
				throw new RouteManagerException("Unable to get routes", ex);
			}
        }
        #endregion

		#region Methods to Add a flight route
		/// <summary>
        /// Add a route to the database
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to add a route</exception>
        /// <returns>Returns the status of the insertion</returns>
        public int AddRoute(Route routeInfo)
        {
			try
			{
				return routeDAO.AddRoute(routeInfo);
			}
			catch (RouteDAOException ex)
			{
				throw new RouteManagerException("Unable to add route", ex);
			}
        }
        #endregion

        #region Methods to Update existing Flight route for a given route
        /// <summary>
        /// Update existing flight route for a given route
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to modify a route</exception>
        /// <returns>Returns the status of the update</returns>
        public int UpdateRoute(Route routeInfo)
        {
			try
			{
				return routeDAO.UpdateRoute(routeInfo);
			}
			catch (RouteDAOException ex)
			{
				throw new RouteManagerException("Unable to update route", ex);
			}
        }
        #endregion

        #region Method to get the route id for a given route
        /// <summary>
        /// Get the route id for a given route id
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to get route</exception>
        /// <returns>int</returns>
        public int GetRouteID(Route routeInfo)
        {
			try
			{
				return routeDAO.GetRouteID(routeInfo);
			}
			catch (RouteDAOException ex)
			{
				throw new RouteManagerException("Unable to get route id", ex);
			}
        }
        #endregion
    }
}