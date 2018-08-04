using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Hotel
{
	public class HotelDAOFactory
	{
		private static HotelDAOFactory factory = new HotelDAOFactory();

		private HotelDAOFactory()
		{
		}

		public static HotelDAOFactory GetInstance()
		{
			return factory;
		}

		public IHotelSearchDAO Create()
		{
			return HotelSearchDAO.GetInstance();
		}
	}
}
