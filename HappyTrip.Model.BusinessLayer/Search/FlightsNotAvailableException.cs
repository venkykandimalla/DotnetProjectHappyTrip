using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to represent the flights not available exception
    /// </summary>
    public class FlightsNotAvailableException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FlightsNotAvailableException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public FlightsNotAvailableException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public FlightsNotAvailableException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
