using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Search
{
    /// <summary>
    /// Class to construct the SearchDAO to execute the database activities related to search
    /// </summary>
    public class SearchDAOFactory
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private static SearchDAOFactory instance = new SearchDAOFactory();
        
        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private SearchDAOFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the SearchDAO
        /// </summary>
        /// <returns></returns>
        public static SearchDAOFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Returns the instance of the SearchDAO object as an interface
        /// </summary>
        /// <returns></returns>
        public ISearchDAO Create()
        {
            return SearchDAO.GetInstance();
        }
    }
}
