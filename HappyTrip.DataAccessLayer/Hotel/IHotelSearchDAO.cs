using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTrip.DataAccessLayer.Hotel
{
	public interface IHotelSearchDAO
	{
		SearchResult SearchForHotels(SearchInfo hsQuery);
	}
}
