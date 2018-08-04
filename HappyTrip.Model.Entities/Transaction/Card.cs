using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent card information to be processed while making a payment
    /// </summary>
    public class Card
    {
        #region Properties of the class

        public string CardNo { get; set; }
        public string Name { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Cvv2No { get; set; }
		public CardTypes CardType { get; set; }

        #endregion
    }
}
