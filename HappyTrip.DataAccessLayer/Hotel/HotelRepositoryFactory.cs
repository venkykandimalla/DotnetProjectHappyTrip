using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Hotel
{
    /// <summary>
    /// Class to construct the Data Access Object to work with database related activities for hotels
    /// </summary>
    public class HotelRepositoryFactory
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private static HotelRepositoryFactory factory = new HotelRepositoryFactory();

        /// <summary>
        /// Private Constructor
        /// </summary>
        private HotelRepositoryFactory()
		{
		}

        /// <summary>
        /// Gets the instance of the HotelRepositoryFactory
        /// </summary>
        /// <returns></returns>
		public static HotelRepositoryFactory GetInstance()
		{
			return factory;
		}

        /// <summary>
        /// Gets the instance of the DBHotelRespository object as an interface
        /// </summary>
        /// <returns>Returns IHotelRepository interface</returns>
		public IHotelRepository Create()
		{
            return new DBHotelRespository();
		}
    }
}
