using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to represent an exception to be thrown when the flights seats are not available
    /// </summary>
    public class FlightSeatsAvailabilityException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FlightSeatsAvailabilityException()
        {

        }

        /// <summary>
        /// Paramterized Constructor - To accept a message
        /// </summary>
        /// <param name="message"></param>
        public FlightSeatsAvailabilityException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Paramterized Constructor - To accept message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public FlightSeatsAvailabilityException(string message, Exception ex)
            : base(message, ex)
        {
            
        }
    }
}
