using System;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public interface IAirLineManager : IAirTravelManager
    {
        /// <summary>
        /// Gets all the airlines from the database
        /// </summary>
        /// <exception cref="AirlineManagerException">Throws the exception when airlines is not available</exception>
        /// <returns>Returns the list of airlines</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.AirTravel.Airline> GetAirLines();
    }
}
