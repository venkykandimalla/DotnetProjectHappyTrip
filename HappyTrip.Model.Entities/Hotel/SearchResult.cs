using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Hotel
{
    /// <summary>
    /// Class to represent the search result when user searches for hotels
    /// </summary>
    public class SearchResult
    {
        List<Hotel> Hotels = new List<Hotel>();

        /// <summary>
        /// To add hotel into the result
        /// </summary>
        /// <param name="NewHotel"></param>
        public void AddHotel(Hotel NewHotel)
        {
            Hotels.Add(NewHotel);
        }

        /// <summary>
        /// To get hotels from the result
        /// </summary>
        /// <returns></returns>
        public List<Hotel> GetHotels()
        {
            return Hotels;
        }
    }
}
