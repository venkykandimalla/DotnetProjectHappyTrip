using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Search
{
    /// <summary>
    /// Class to represent an exception that occurs when an exception is thrown while searching for flights
    /// </summary>
    public class SearchFlightDAOException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchFlightDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public SearchFlightDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public SearchFlightDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
