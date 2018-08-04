using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the information regarding Flight and its Class of seats
    /// </summary>
    public class FlightClass
    {
        #region Properties of a class

        public TravelClass ClassInfo { get; set; }
        public int NoOfSeats { get; set; }

        #endregion
    }
}
