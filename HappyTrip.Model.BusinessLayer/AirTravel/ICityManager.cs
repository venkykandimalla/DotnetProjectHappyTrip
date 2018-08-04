using System;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public interface ICityManager : IAirTravelManager
    {
        /// <summary>
        /// Adds a city to the database
        /// </summary>
        /// <param name="city"></param>
        /// <exception cref="CityManagerException">Thrown when unable to add city</exception>
        /// <returns>Returns the status of insertion to be done</returns>
        bool AddCity(HappyTrip.Model.Entities.Common.City city);

        /// <summary>
        /// Gets all the cities which is operational for flights
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable get cities</exception>
        /// <returns>Returns collection of cities</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.Common.City> GetCities();

        /// <summary>
        /// Method to get city by id
        /// </summary>
        /// <param name="cityId">The id of the city whose details has to be retrieved</param>
        /// <returns>A valid city object or null</returns>
        HappyTrip.Model.Entities.Common.City GetCityById(long cityId);

        /// <summary>
        /// Gets all the states
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable to get states</exception>
        /// <returns>Returns the list of states from database</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.Common.State> GetStates();

        /// <summary>
        /// Update the existing city information
        /// </summary>
        /// <param name="city"></param>
        /// <exception cref="CityManagerException">Thrown when unable to update city information</exception></exception>
        /// <returns>Returns the status of the update</returns>
        bool UpdateCity(HappyTrip.Model.Entities.Common.City city);
    }
}
