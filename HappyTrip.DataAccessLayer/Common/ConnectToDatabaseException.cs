using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Exception to be thrown when unable to connect to database
    /// </summary>
    internal class ConnectToDatabaseException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConnectToDatabaseException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public ConnectToDatabaseException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public ConnectToDatabaseException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
