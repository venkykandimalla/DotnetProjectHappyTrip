using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent payment related information for a transaction
    /// </summary>
    public class Payment
    {
        #region Properties of the class

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNo { get; set; }

        #endregion
    }
}
