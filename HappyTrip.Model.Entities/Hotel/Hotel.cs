using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.Entities.Hotel
{
    public class Hotel
    {
        #region Fields of the class

        private List<HotelRoom> HotelRooms = new List<HotelRoom>();

        #endregion

        #region Properties of the class

        public long HotelId { get; set; }
        public string HotelName { get; set; }
        public string PhotoUrl { get; set; }
        public string BriefNote { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int CityID { get; set; }
        public string Pincode { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public int StarRanking { get; set; }

        #endregion


        /// <summary>
        /// Gets all the rooms for the hotel
        /// </summary>
        /// <returns></returns>
        public List<HotelRoom> GetHotelRooms()
        {
            return HotelRooms;
        }

        /// <summary>
        /// Adds a room for a hotel
        /// </summary>
        /// <param name="NewHotelRoom"></param>
        public void AddHotelRoom(HotelRoom NewHotelRoom)
        {
            HotelRooms.Add(NewHotelRoom);
        }
    }
}
