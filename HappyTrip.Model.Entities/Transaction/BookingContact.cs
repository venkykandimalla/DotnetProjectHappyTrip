using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.UserAccount;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent the booking contact information
    /// </summary>
    [Serializable]
    public class BookingContact : Contact
    {
        #region Properties of the class

        public string ContactName { get; set; }
        public string PhoneNo { get; set; }

        #endregion
    }
}
