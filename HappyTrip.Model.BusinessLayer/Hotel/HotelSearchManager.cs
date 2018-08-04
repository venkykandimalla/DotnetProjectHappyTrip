using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Hotel
{
	public class HotelSearchManager
	{
		/// <summary>
		/// Hotel Search Manager (Business Layer). Gets the hotels from our database
		/// </summary>
		/// <param name="hsQuery"></param>
		/// <returns></returns>
		public HappyTrip.Model.Entities.Hotel.SearchResult SearchForHotels(HappyTrip.Model.Entities.Hotel.SearchInfo hsQuery)
		{
			// Added a comment
			HappyTrip.Model.Entities.Hotel.SearchResult hsr = null;

			HappyTrip.DataAccessLayer.Hotel.IHotelSearchDAO hotelDao = HappyTrip.DataAccessLayer.Hotel.HotelDAOFactory.GetInstance().Create();

			hsr = hotelDao.SearchForHotels(hsQuery);

			return hsr;
		}
	}
}
