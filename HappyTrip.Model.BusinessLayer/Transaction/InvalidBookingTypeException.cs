using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent an exception when invalid booking type is encountered
    /// </summary>
    public class InvalidBookingTypeException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InvalidBookingTypeException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public InvalidBookingTypeException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public InvalidBookingTypeException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
