using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent passenger information
    /// </summary>
    [Serializable]
    public class Passenger
    {
        #region Properties of the class

        public long PassengerId { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        #endregion
    }
}
