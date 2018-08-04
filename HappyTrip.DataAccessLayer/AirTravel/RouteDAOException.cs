using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Class to represent an exception which can occur while performing route related database operations
    /// </summary>
	public class RouteDAOException : ApplicationException
	{
		/// <summary>
        /// Default Constructor
        /// </summary>
        public RouteDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public RouteDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public RouteDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
	}
}
