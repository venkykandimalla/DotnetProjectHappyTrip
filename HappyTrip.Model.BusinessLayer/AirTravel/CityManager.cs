using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to operation of flight in different cities
    /// </summary>
    class CityManager : HappyTrip.Model.BusinessLayer.AirTravel.ICityManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        ICityDAO cityDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CityManager()
        {
            cityDAO = CityDAOFactory.GetInstance().CreateCity();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="cityDAO"></param>
        public CityManager(ICityDAO cityDAO)
        {
            this.cityDAO = cityDAO;
        }


        #region Method to get all the operation of flight in different cities
        /// <summary>
        /// Gets all the cities which is operational for flights
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable get cities</exception>
        /// <returns>Returns collection of cities</returns>
        public List<City> GetCities()
        {
            
            try
            {
                DataSet citiesDS = cityDAO.GetCities();

                var cities = from city in citiesDS.Tables[0].AsEnumerable().Distinct()
                             orderby city["CityName"]
                             select new City
                             {
                                 CityId = Convert.ToInt64(city["CityId"]),
                                 Name = city["CityName"].ToString(),
                                 StateInfo = new State 
                                 {
                                        StateId = Convert.ToInt64(city["StateId"]),
                                        Name = city["StateName"].ToString()
                                 }
                             };

                return cities.ToList<City>();
            }
            catch(CityDAOException ex)
            {
                throw new CityManagerException("Unable to get cities", ex);
            }

            
            
        }
        #endregion

		#region Method to get city by id
		/// <summary>
		/// Method to get city by id
		/// </summary>
		/// <param name="cityId">The id of the city whose details has to be retrieved</param>
		/// <returns>A valid city object or null</returns>
		public City GetCityById(long cityId)
		{
			City city = null;

			try
			{
				city = cityDAO.GetCityById(cityId);
				return city;
			}
            catch (CityDAOException ex)
            {
                throw new CityManagerException("Unable to get city by id", ex);
            }
		}
		#endregion

		#region Method to Add all cities
		/// <summary>
        /// Adds a city to the database
        /// </summary>
        /// <param name="city"></param>
        /// <exception cref="CityManagerException">Thrown when unable to add city</exception>
        /// <returns>Returns the status of insertion to be done</returns>
        public bool AddCity(City city)
        {
            bool isAdded = false;

            try 
            { 
                isAdded = cityDAO.AddCity(city);
            }
            catch (CityDAOException ex)
            {
                throw new CityManagerException("Unable to add the city", ex);
            }
            

            return isAdded;
        }
        #endregion

        #region Method to Update the existing the Cities
        /// <summary>
        /// Update the existing city information
        /// </summary>
        /// <param name="city"></param>
        /// <exception cref="CityManagerException">Thrown when unable to update city information</exception></exception>
        /// <returns>Returns the status of the update</returns>
        public bool UpdateCity(City city)
        {
            bool isUpdated = false;

            try
            {
                isUpdated = cityDAO.UpdateCity(city);
            }
            catch (CityDAOException ex)
            {
                throw new CityManagerException("Unable to update city information", ex);
            }
            

            return isUpdated;
        }
        #endregion

        #region Method to get all the states
        /// <summary>
        /// Gets all the states
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable to get states</exception>
        /// <returns>Returns the list of states from database</returns>
        public List<State> GetStates()
        {
			try
			{
				DataSet ds = cityDAO.GetStates();
                var states = from state in ds.Tables[0].AsEnumerable().Distinct()
                             orderby state["StateName"]
                             select new State
                             {
                                 StateId = Convert.ToInt64(state["StateId"]),
                                 Name = state["StateName"].ToString()
                             };

                return states.ToList<State>();
			}
			catch (CityDAOException ex)
			{
				throw new CityManagerException("Unable to get states", ex);
			}
        }
        #endregion

    }
}