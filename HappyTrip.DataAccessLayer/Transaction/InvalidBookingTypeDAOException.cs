using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent an exception when an invalid booking type is passed
    /// </summary>
    public class InvalidBookingTypeDAOException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InvalidBookingTypeDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public InvalidBookingTypeDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public InvalidBookingTypeDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
