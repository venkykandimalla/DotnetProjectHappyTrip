using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to represent an exception that would be thrown while performing flight related operations
    /// </summary>
	public class FlightManagerException : ApplicationException
	{
		/// <summary>
        /// Default Constructor
        /// </summary>
        public FlightManagerException()
        {

        }

        /// <summary>
        /// Paramterized Constructor - To accept a message
        /// </summary>
        /// <param name="message"></param>
        public FlightManagerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Paramterized Constructor - To accept message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public FlightManagerException(string message, Exception ex)
            : base(message, ex)
        {
            
        }
	}
}
