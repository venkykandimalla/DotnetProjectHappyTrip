using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Class to represent a factory that constructs the manager to perform booking operations
    /// </summary>
    public class BookingManagerFactory
    {
        /// <summary>
        /// Fields of the class - Instance of the factory
        /// </summary>
        private static BookingManagerFactory Instance = new BookingManagerFactory();
        
        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private BookingManagerFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the class
        /// </summary>
        /// <returns>Instance of the class to call other methods</returns>
        public static BookingManagerFactory GetInstance()
        {
            return Instance;
        }

        /// <summary>
        /// Creates the manager class to perform booking related operations
        /// </summary>
        /// <returns>A booking Manager as an interface reference</returns>
        public IBookingManager Create()
        {
            return new BookingManager();
        }
    }
}
