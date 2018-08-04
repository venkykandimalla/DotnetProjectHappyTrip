using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.UserAccount
{
    /// <summary>
    /// Class to hold the user's personal information
    /// </summary>
    [Serializable]
    public class Personal
    {
        #region Properties of the class

        public string FullName {get;set;}
        public char Gender {get;set;}
        public DateTime DateOfBirth {get;set;}
        
        #endregion
    }
}
