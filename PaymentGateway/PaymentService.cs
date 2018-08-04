using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PaymentGateway
{
    /// <summary>
    /// Class to implement the payment gateway operations
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PaymentService : IPaymentService
    {
        #region IPaymentService Members

        static List<InternalCard> cards = new List<InternalCard>()
		{
            new InternalCard("4485368438131870", "Tester One", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4556697879214260", "Tester Two", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4024007168552240", "Tester Three", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4716424110786040", "Tester Four", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4916224241548930", "Tester Five", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4929400584013620", "Tester Six", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4024007101176900", "Tester Seven", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4916335270851650", "Tester Eight", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4485579898577740", "Tester Nine", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4626956357313030", "Tester Ten", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4912116114112250", "Tester Eleven", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4929282824707840", "Tester Twelve", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4797118560514670", "Tester Thirteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4024007192547550", "Tester Fourteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4539824044385680", "Tester Fifteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4024007130830290", "Tester Sixteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4929506814993220", "Tester Seventeen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4485200072278130", "Tester Eighteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("4485639593528510", "Tester Nineteen", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("4916851388751990", "Tester Twenty", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5335453311435620", "Tester TwentyOne", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5156906515577320", "Tester TwentyTwo", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5418354037744330", "Tester TwentyThree", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5507687633516590", "Tester TwentyFour", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5267533257167079", "Tester TwentyFive", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5350605084331160", "Tester TwentySix", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5155675297631839", "Tester TwentySeven", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5515737673318720", "Tester TwentyEight", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5132792448639319", "Tester TwentyNine", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5327336240499970", "Tester Thirty", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5534396073586450", "Tester ThirtyOne", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5308422479004680", "Tester ThirtyTwo", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5360788677284370", "Tester ThirtyThree", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5373855238992720", "Tester ThirtyFour", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5195198397576230", "Tester ThirtyFive", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5421205482842370", "Tester ThirtySix", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5293311377072580", "Tester ThirtySeven", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5446213704855370", "Tester ThirtyEight", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true)),
            new InternalCard("5207535086467500", "Tester ThirtyNine", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "VISA", true)),
            new InternalCard("5240658262099970", "Tester Fourty", 50000, 10, 2015, "123", (CardType)Enum.Parse(typeof(CardType), "MASTERCARD", true))
		};

		static InternalCard s_card = null;
		double cardBal;

		/// <summary>
		/// Method to return the list of all the cards
		/// </summary>
		/// <returns>card list</returns>
		public List<InternalCard> GetCards()
		{
			return cards;
		}
		/// <summary>
		/// Verifies the card to be used for payment
		/// </summary>
		/// <param name="cardInfo"></param>
		/// <returns>True if card information is valid</returns>
		public bool VerifyCard(Card cardInfo)
        {
            string cardNo = null;
            string cvvNo = null;
			string mName = null;
			CardType cardType = CardType.Visa ;
            
            int cardExpMonth = 0;
            int cardExpYear = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].CardNo == cardInfo.CardNo)
                {
					mName = cards[i].MemberName;
					cardNo = cards[i].CardNo;
                    cvvNo = cards[i].CVV;
                    cardBal = cards[i].Balance;
                    cardExpMonth = cards[i].ExpMonth;
                    cardExpYear = cards[i].ExpYear;
					cardType = cards[i].CardType;
					s_card = cards[i];
                    break;
                }
            }
			if (cardNo == null)
			{
				throw new FaultException("Invalid Card Number or no such card number exists");
			}
			if (cvvNo == null)
			{
				throw new FaultException("Invalid CVV Number");
			}
			if (cardType != cardInfo.Type)
			{
				throw new FaultException("Invalid Card Type");
			}
			if (cvvNo != cardInfo.Cvv2No)
			{
				throw new FaultException("Invalid CVV Number");
			}
			if (mName != cardInfo.Name)
			{
				throw new FaultException("Invalid Member Name");
			}

			if (cardExpMonth != cardInfo.ExpiryMonth)
			{
				throw new FaultException("Invalid Card Expiry Month");
			}
			if (cardExpYear != cardInfo.ExpiryYear)
			{
				throw new FaultException("Invalid Card Expiry Year");
			}
			if (cardExpYear < DateTime.Now.Year)
			{
				throw new FaultException("Card Expired");
			}
            //if (cardExpYear == DateTime.Now.Year && cardExpMonth <= DateTime.Now.Month)
			//{
            //    throw new FaultException("Card Expired");
			//}

            return true;
        }

        /// <summary>
        /// Makes the payment for a given transaction
        /// </summary>
		/// <param name="cardInfo">The Card from where the payment needs to be made</param>
        /// <param name="amount">The amount to be deducted</param>
        /// <returns>Returns the payment processed information</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public PaymentInfo MakePayment(Card cardInfo, double amount)
        {
            //Logic
            //Use the cardinfo for payment.
			if (VerifyCard(cardInfo))
			{
				ServiceExceptionInfo info = new ServiceExceptionInfo();

				if (amount <= 0)
				{
					info.ErrorCode = 101;
					info.Description = "Invalid amount";
					info.When = DateTime.Now;
					//throw new FaultException<ServiceExceptionInfo>(info, new FaultReason("Error in MakePayment, invalid amount"));
					throw new FaultException("Error in MakePayment, invalid amount");
				}

				//Original Code Commented To Induce Bug - Not Checking for Balance
				if (cardBal < amount)
				{
					info.ErrorCode = 102;
					info.Description = "Insufficient balance in the card";
					info.When = DateTime.Now;
					//throw new FaultException<ServiceExceptionInfo>(info, new FaultReason("Error in MakePayment, insufficient balance in the card"));
					throw new FaultException("Error in MakePayment, insufficient balance in the card");
				}
				cardBal -= amount;
				s_card.Balance = cardBal;
				s_card = null;
				return new PaymentInfo() { ReferenceNo = Guid.NewGuid().ToString(), Status = PaymentStatus.Success };
			}
			return null;
        }

        #endregion




		//#region Validation Helper Methods
		///// <summary>
		///// To check if the card number is valid
		///// </summary>
		///// <param name="cardNumber"></param>
		///// <returns>Returns true if valid</returns>
		//private bool IsCardNumberValid(string cardNumber)
		//{
		//    string cardNo = cardCVVNumbers.First(cn => cn == cardNumber);
		//    if (cardNo == null)
		//        throw new FaultException("Invalid Card Number");
		//    return true;
		//}

		///// <summary>
		///// To verify the cvv2 number of the card
		///// </summary>
		///// <param name="cvv"></param>
		///// <returns>Returns true if valid</returns>
		//private bool IsCVVNumberProvided(string cvv)
		//{
		//    return (cvv != null) && (cvv.Length == 3);
		//}

		///// <summary>
		///// To verify if the expiry date is valid
		///// </summary>
		///// <param name="month"></param>
		///// <param name="year"></param>
		///// <returns>Rerurns true if valid</returns>
		//private bool IsExpiryDateValid(int month, int year)
		//{
		//    return (year >= DateTime.Now.Year && month <= 12);
		//}

		//#endregion

		#region IPaymentService Members

		/// <summary>
		/// Makes the refund for a given transaction
		/// </summary>
		/// <param name="cardInfo">The Card into which the payment needs to be refunded</param>
		/// <param name="amount">The amount to refund</param>
		/// <returns>Returns the payment processed information</returns>
		[OperationBehavior(TransactionScopeRequired = true)]
		public PaymentInfo MakeRefund(Card cardInfo, double amount)
		{
			if (VerifyCard(cardInfo))
			{
				ServiceExceptionInfo info = new ServiceExceptionInfo();

				if (amount <= 0)
				{
					info.ErrorCode = 101;
					info.Description = "Invalid amount";
					info.When = DateTime.Now;
					//throw new FaultException<ServiceExceptionInfo>(info, new FaultReason("Error in MakePayment, invalid amount"));
					throw new FaultException("Error in MakePayment, invalid amount");
				}

				for (int i = 0; i < cards.Count; i++)
				{
					if (cards[i].CardNo == cardInfo.CardNo)
					{
						cards[i].Balance += amount;
						break;
					}
				}
				return new PaymentInfo() { ReferenceNo = Guid.NewGuid().ToString(), Status = PaymentStatus.Success };
			}
			return null;
		}

		#endregion
	}
}
