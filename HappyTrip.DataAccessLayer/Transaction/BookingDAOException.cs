using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent exception related to Booking database activities
    /// </summary>
    public class BookingDAOException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BookingDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public BookingDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public BookingDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
