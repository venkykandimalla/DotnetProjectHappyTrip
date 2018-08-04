using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Hotel
{
    /// <summary>
    /// Class to represent an exception which can occur while performing hotel related database operations
    /// </summary>
    public class HotelDAOException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotelDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public HotelDAOException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public HotelDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
