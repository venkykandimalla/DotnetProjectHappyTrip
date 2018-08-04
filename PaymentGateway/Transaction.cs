using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Class to represent the transaction being made
    /// </summary>
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public Card CardForPayment { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
    }
}
