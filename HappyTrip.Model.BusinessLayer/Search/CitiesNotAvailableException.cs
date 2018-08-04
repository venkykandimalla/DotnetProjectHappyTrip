using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to represent exception when trying to get citites from the database
    /// </summary>
    public class CitiesNotAvailableException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CitiesNotAvailableException()
        {

        }

        /// <summary>
        /// Paramterized Constructor - To accept a message
        /// </summary>
        /// <param name="message"></param>
        public CitiesNotAvailableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Paramterized Constructor - To accept message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public CitiesNotAvailableException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}
