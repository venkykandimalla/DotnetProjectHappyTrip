using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent an exception which can occur while storing a booking into database
    /// </summary>
    public class StoreBookingInDatabaseException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StoreBookingInDatabaseException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public StoreBookingInDatabaseException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public StoreBookingInDatabaseException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
