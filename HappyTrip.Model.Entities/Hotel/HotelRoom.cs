using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Hotel
{
	public class HotelRoom
	{
        public RoomType RoomType { get; set; }
		public float CostPerDay { get; set; }
		public int NoOfRooms { get; set; }
	}
}
