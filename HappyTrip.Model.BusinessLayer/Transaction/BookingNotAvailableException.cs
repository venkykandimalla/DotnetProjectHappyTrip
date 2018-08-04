using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent an exception when invalid booking type is encountered
    /// </summary>
    public class BookingNotAvailableException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BookingNotAvailableException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public BookingNotAvailableException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public BookingNotAvailableException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
