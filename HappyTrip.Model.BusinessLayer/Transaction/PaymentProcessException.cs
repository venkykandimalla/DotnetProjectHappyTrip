using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent exception while processing a payment
    /// </summary>
    public class PaymentProcessException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PaymentProcessException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public PaymentProcessException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public PaymentProcessException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
