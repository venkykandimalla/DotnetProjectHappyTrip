using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent an exception while performing Booking operations
    /// </summary>
    public class BookingException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BookingException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public BookingException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public BookingException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
