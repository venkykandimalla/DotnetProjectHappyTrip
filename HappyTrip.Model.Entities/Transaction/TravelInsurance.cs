using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent the insurance available for air travel
    /// </summary>
    public class TravelInsurance
    {
        #region Properties of the class
        public string Name { get; set; }
        public decimal Amount { get; set; }
        #endregion
    }
}
