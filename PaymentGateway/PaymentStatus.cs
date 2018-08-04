using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Enum to represent the status of the payment
    /// </summary>
    [DataContract]
    public enum PaymentStatus
    {
        [EnumMember]
        Success = 1,
        [EnumMember]
        InvalidCardHolder,
        [EnumMember]
        InsufficientFunds,
        [EnumMember]
        InvalidExpiryDate,
        [EnumMember]
        Declined
    }
}
