using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Common
{
    /// <summary>
    /// Class to represent city information
    /// </summary>
    public class City
    {
        #region Properties of the class

        public long CityId {get;set;}
        public string Name {get;set; }
        public State StateInfo { get; set; }

        #endregion
    }
}
