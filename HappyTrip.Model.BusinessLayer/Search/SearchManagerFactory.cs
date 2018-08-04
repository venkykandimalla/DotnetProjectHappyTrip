using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to construct the manager to perform search related activities
    /// </summary>
    public class SearchManagerFactory
    {
        /// <summary>
        /// Fields of the class - Instance of the factory
        /// </summary>
        private static SearchManagerFactory instance = new SearchManagerFactory();


        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private SearchManagerFactory()
        {

        }

        /// <summary>
        /// Gets the instance of SearchManagerFactory
        /// </summary>
        /// <returns>Returns the instance of the class</returns>
        public static SearchManagerFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Creates the manager class to perform search related activities
        /// </summary>
        /// <returns>An object to perform search operations as the ISearchManager interface</returns>
        public ISearchManager Create()
        {
            return new SearchManager();
        }
    }
}
