using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentGateway
{
	public class InternalCard
	{
		public InternalCard()
		{
		}

		public InternalCard(string cno, string mname, double bal, int em, int ey, string cvv, CardType cardType)
		{
			CardNo = cno;
			MemberName = mname;
			Balance = bal;
			ExpMonth = em;
			ExpYear = ey;
			CVV = cvv;
			CardType = cardType;
		}

		public string CardNo { get; set; }
		public string MemberName { get; set; }
		public double Balance { get; set; }
		public int ExpMonth { get; set; }
		public int ExpYear { get; set; }
		public string CVV { get; set; }
		public CardType CardType { get; set; }
	}
}
