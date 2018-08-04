using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent the hotel booking information
    /// </summary>
    public class HotelBooking : Booking
    {

        #region Fields of the class

        private List<HotelRoom> HotelRooms = new List<HotelRoom>();

        #endregion

        #region Properties of the class
        
        public Hotel.Hotel HotelForBooking { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfPeople { get; set; }
        public int NoOfRooms { get; set; }
        
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
