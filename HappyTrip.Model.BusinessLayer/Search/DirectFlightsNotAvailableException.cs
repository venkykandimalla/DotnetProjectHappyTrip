using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to represent an exception when direct flights are not available
    /// </summary>
    class DirectFlightsNotAvailableException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectFlightsNotAvailableException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public DirectFlightsNotAvailableException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public DirectFlightsNotAvailableException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
