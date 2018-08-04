using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Class to represent the payment information returned by the gateway
    /// </summary>
    [DataContract]
    public class PaymentInfo
    {
        /// <summary>
        /// Payment reference number
        /// </summary>
        [DataMember]
        public string ReferenceNo { get; set; }

        /// <summary>
        /// Status of the payment made
        /// </summary>
        [DataMember]
        public PaymentStatus Status { get; set; }
    }
}
