using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.Entities.Hotel
{
    public class HotelReview
    {
        public Review ReviewForHotel { get; set; }
        public byte Rating { get; set; }
        public string UserName { get; set; }
    }
}
