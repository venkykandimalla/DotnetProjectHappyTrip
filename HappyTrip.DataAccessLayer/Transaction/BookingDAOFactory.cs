using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent the factory that constructs a BookingDAO object
    /// </summary>
    public class BookingDAOFactory
    {
        /// <summary>
        /// Field of the class - Having a static instance. Singleton
        /// </summary>
        private static BookingDAOFactory instance = new BookingDAOFactory();

        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private BookingDAOFactory()
        {

        }

        /// <summary>
        /// Gets the instance of the BookingDAOFactory
        /// </summary>
        /// <returns>Returns the instance of BookingDAOFactory</returns>
        public static BookingDAOFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Returns the instance of the BookingDAO object as an interface
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="InvalidBookingTypeDAOException">Throws an exception if booking type is invalid</exception>
        /// <returns>An Interface for Booking Data Access Objects</returns>
        public IBookingDAO Create(BookingTypes type)
        {
            IBookingDAO bookDAO = null;

            try
            {
                bookDAO = BookingDAO.GetInstance(type);
            }
            catch (InvalidBookingTypeDAOException)
            {
                throw;
            }

            return bookDAO;
        }
    }
}
