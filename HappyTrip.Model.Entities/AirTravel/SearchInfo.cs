using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the flight search related information
    /// </summary>
    public class SearchInfo
    {
        #region Properties of the class

        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public DateTime OnwardDateOfJourney { get; set; }
        public DateTime ReturnDateOfJourney { get; set; }
        public int NoOfSeats { get; set; }
        public TravelClass Class { get; set; }
        public TravelDirection Direction { get; set; }

        #endregion
    }
}
