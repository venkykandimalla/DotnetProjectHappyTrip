using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent the exception for the database activities related to AirTravel
    /// </summary>
    public class AirTravelBookingException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AirTravelBookingException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public AirTravelBookingException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public AirTravelBookingException(string message, Exception ex) : base(message, ex)
        {

        }

    }
}
