using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.ServiceModel;

namespace HappyTrip.Model.PaymentService
{
    /// <summary>
    /// Class to represent the implementation of the payment activities
    /// </summary>
    class PaymentManager : HappyTrip.Model.PaymentService.IPaymentManager
    {
        /// <summary>
        /// Fields of the class - Instance created - Sigleton
        /// </summary>
        private static PaymentManager instance = new PaymentManager();


        /// <summary>
        /// Default Private Constructor - To avoid instantiation from outside
        /// </summary>
        private PaymentManager()
        {

        }
        
        /// <summary>
        /// Gets the instance of PaymentManager to perform payment activities
        /// </summary>
        /// <returns></returns>
        public static PaymentManager GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Makes the payment by contacting the payment gateway
        /// </summary>
        /// <param name="cardForPayment"></param>
        /// <param name="amount"></param>
        /// <param name="status"></param>
        /// <exception cref="PaymentNotProcessedFromServiceException">Thrown when unable to process the payment</exception>
        /// <returns>Returns the payment reference number</returns>
        public string MakePayment(Card cardForPayment, decimal amount, out PaymentStatus status)
        {
            //PaymentGateway.PaymentServiceClient proxy = new PaymentGateway.PaymentServiceClient();
            PaymentGateway.PaymentService proxy = new PaymentGateway.PaymentService();
            PaymentGateway.Card card = new PaymentGateway.Card {
                CardNo = cardForPayment.CardNo, 
                Cvv2No = cardForPayment.Cvv2No,
                ExpiryMonth = cardForPayment.ExpiryMonth,
                ExpiryYear = cardForPayment.ExpiryYear,
                Name = cardForPayment.Name,
				Type = (PaymentGateway.CardType)cardForPayment.CardType
            };
            PaymentGateway.PaymentInfo paymentInfo;
            string referenceNo = string.Empty;
            try
            {
                if (proxy.VerifyCard(card))
                {
                    paymentInfo = proxy.MakePayment(card, (double)amount);
                    status = PaymentStatus.Success;
                    referenceNo = paymentInfo.ReferenceNo;
                }
                else
                {
                    status = PaymentStatus.InvalidCardNo;
                }
            }
            catch (FaultException ex)
            {
                throw new PaymentNotProcessedFromServiceException(ex.Message);
            }

            return referenceNo;
        }
    }
}
