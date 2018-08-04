using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.Configuration;
using System.Reflection;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to construct the implementation object for a type of booking
    /// </summary>
    class BookingDAOImplFactory
    {
        /// <summary>
        /// Field of the class - Having a static instance. Singleton
        /// </summary>
        private static BookingDAOImplFactory instance = new BookingDAOImplFactory();
		static IDictionary<BookingTypes, IBookingDAOImpl> s_bookingDAOs = new Dictionary<BookingTypes, IBookingDAOImpl>();

		static BookingDAOImplFactory()
		{
			AppSettingsReader asr = new AppSettingsReader();
			string bookingConfig = asr.GetValue("bookingDAOTypes", typeof(string)).ToString() ;

			string[] tokens = bookingConfig.Split(':');

			for(int i = 0; i < tokens.Length;)
			{
				BookingTypes bt = (BookingTypes)Convert.ToInt32(tokens[i]);
				string className = tokens[i + 1];

				Assembly asm = Assembly.GetExecutingAssembly();
				object objBookingDAO = asm.CreateInstance(className);

				IBookingDAOImpl bookingDAOImpl = (IBookingDAOImpl)objBookingDAO;

				s_bookingDAOs.Add(bt, bookingDAOImpl);

				i += 2;
			}
		}

		/// <summary>
		/// Making the constructor private so that object is not created
		/// </summary>
		private BookingDAOImplFactory()
        {

        }
        /// <summary>
        /// Gets the instance of BookingDAOImplFactory
        /// </summary>
        /// <returns>Instance of BookingDAOImplFactory</returns>
        public static BookingDAOImplFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Creates an object of a Data Access Implementor
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="InvalidBookingTypeDAOException</exception>
        /// <returns>Returns an interface for one the booking types supplied</returns>
        public IBookingDAOImpl Create(BookingTypes type)
        {
			IBookingDAOImpl bookings = null;

			bookings = s_bookingDAOs[type];

			return bookings;
        }
    }
}
