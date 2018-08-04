using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.UserAccount
{
    /// <summary>
    /// Class to represent contact information of a user
    /// </summary>
    [Serializable]
    public class Contact
    {
        #region Properties of the class

        public string Address {get;set;}
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string MobileNo {get;set;}
        public string Email {get;set; }

        #endregion
    }
}
