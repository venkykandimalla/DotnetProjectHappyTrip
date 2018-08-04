using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.PaymentService
{
    /// <summary>
    /// Class to represent an exception when unable to process payment
    /// </summary>
    public class PaymentNotProcessedFromServiceException : ApplicationException
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PaymentNotProcessedFromServiceException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public PaymentNotProcessedFromServiceException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public PaymentNotProcessedFromServiceException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
