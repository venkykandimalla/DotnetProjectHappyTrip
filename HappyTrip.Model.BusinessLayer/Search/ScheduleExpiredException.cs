using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to represent an exception which indicates that the departure time has crossed the current date and time
    /// </summary>
    class ScheduleExpiredException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ScheduleExpiredException()
        {

        }

        /// <summary>
        /// Paramterized Constructor - To accept a message
        /// </summary>
        /// <param name="message"></param>
        public ScheduleExpiredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Paramterized Constructor - To accept message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public ScheduleExpiredException(string message, Exception ex)
            : base(message, ex)
        {
            
        }
    }
}
