using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Class to represent the card information
    /// </summary>
    [DataContract]
    public class Card
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CardNo { get; set; }
        [DataMember]
        public string Cvv2No { get; set; }
        [DataMember]
        public int ExpiryMonth { get; set; }
        [DataMember]
        public int ExpiryYear { get; set; }
        [DataMember]
        public CardType Type { get; set; }
    }
}
