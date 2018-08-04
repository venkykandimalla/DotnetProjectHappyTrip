using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the cost for a flight for a given class
    /// </summary>
    public class FlightCost
    {
        #region Properties of the class

        public TravelClass Class { get; set; }
        public decimal CostPerTicket { get; set; }

        #endregion
    }
}
