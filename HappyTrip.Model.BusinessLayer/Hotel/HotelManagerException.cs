using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Hotel
{
    /// <summary>
    /// Class to represent exception related to hotel activities
    /// </summary>
    public class HotelManagerException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotelManagerException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public HotelManagerException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public HotelManagerException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
