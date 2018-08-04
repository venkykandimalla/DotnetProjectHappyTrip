using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.Model.PaymentService
{
    /// <summary>
    /// Class to construct the object that would help doing the payment operations
    /// </summary>
    public class PaymentManagerFactory
    {
        /// <summary>
        /// Fields of the class - Instance of the factory
        /// </summary>
        private static PaymentManagerFactory instance = new PaymentManagerFactory();

        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private PaymentManagerFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the class
        /// </summary>
        /// <returns>Returns an instance of the class</returns>
        public static PaymentManagerFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Creates the object of the manager class to process a payment
        /// </summary>
        /// <returns>Returns an instance of the business object to help process the payment</returns>
        public IPaymentManager Create()
        {
            return PaymentManager.GetInstance();
        }
    }
}
