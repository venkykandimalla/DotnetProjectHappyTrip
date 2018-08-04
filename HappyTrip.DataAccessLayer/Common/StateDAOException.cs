using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Exception class to be thrown when there is an exception while performing state related database activities
    /// </summary>
	public class StateDAOException : ApplicationException
	{
		/// <summary>
        /// Default Constructor
        /// </summary>
        public StateDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public StateDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public StateDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
	}
}
