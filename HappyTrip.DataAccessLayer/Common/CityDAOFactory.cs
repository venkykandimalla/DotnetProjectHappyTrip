using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Class to construct the Data Access Object to work with database related activities for states
    /// </summary>
    public class CityDAOFactory
    {
        /// <summary>
        /// Fields of the class - Instance of the factory
        /// </summary>
        private static CityDAOFactory instance = new CityDAOFactory();

        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private CityDAOFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the CityDAOFactory
        /// </summary>
        /// <returns></returns>
        public static CityDAOFactory GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// Returns the instance of the CityDAO object as an interface
        /// </summary>
        /// <returns>Returns the Data Access Object as an interface reference</returns>
        public ICityDAO CreateCity()
        {
            return new CityDAO();
        }

       
    }
}
