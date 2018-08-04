using System;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public interface IRouteManager : IAirTravelManager
    {
        /// <summary>
        /// Add a route to the database
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to add a route</exception>
        /// <returns>Returns the status of the insertion</returns>
        int AddRoute(HappyTrip.Model.Entities.AirTravel.Route routeInfo);

        /// <summary>
        /// Get the route id for a given route id
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to get route</exception>
        /// <returns>int</returns>
        int GetRouteID(HappyTrip.Model.Entities.AirTravel.Route routeInfo);

        /// <summary>
        /// Gets the flight routes
        /// </summary>
        /// <exception cref="RouteManagerException">Thrown when unable to get routes</exception>
        /// <returns>Returns a list with all the route information</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.AirTravel.Route> GetRoutes();

        /// <summary>
        /// Update existing flight route for a given route
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <exception cref="RouteManagerException">Thrown when unable to modify a route</exception>
        /// <returns>Returns the status of the update</returns>
        int UpdateRoute(HappyTrip.Model.Entities.AirTravel.Route routeInfo);
    }
}
