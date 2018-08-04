using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the route operations to be performed on the database
    /// </summary>
    public interface IRouteDAO : IAirTravelDAO
    {
        /// <summary>
        /// Gets the routes from the database
        /// </summary>
        /// <returns>DataSet with all Routes</returns>
        DataSet GetRoutes();

        /// <summary>
        /// Add the routes to the database
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <returns>Returns the number of rows affected by the insert</returns>
        int AddRoute(Route routeInfo);

        /// <summary>
        /// Update the existing routes to the database
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <returns>Returns the number of rows affected by the update</returns>
        int UpdateRoute(Route routeInfo);

        /// <summary>
        /// Gets the route id for a route from the database
        /// </summary>
        /// <parameter name="routeInfo"></parameter>
        /// <returns>Returns the route id for given route with city information</returns>
        int GetRouteID(Route routeInfo);
    }
}
