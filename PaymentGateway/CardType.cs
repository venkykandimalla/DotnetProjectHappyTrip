using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Class to represent the type of card
    /// </summary>
    [DataContract]
    public enum CardType
    {
        [EnumMember]
        Visa = 1,
        [EnumMember]
        MasterCard
    }
}
