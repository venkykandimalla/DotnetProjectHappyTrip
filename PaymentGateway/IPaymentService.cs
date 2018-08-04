using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PaymentGateway
{
    /// <summary>
    /// Interface to represent abstractions exposed by the payment gateway
    /// </summary>
    [ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface IPaymentService
    {
        /// <summary>
        /// Verifies the card to be used for payment
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <returns>True if card information is valid</returns>
        [OperationContract]
        bool VerifyCard(Card cardInfo);

        /// <summary>
        /// Makes the payment for a given transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Returns the payment processed information</returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionInfo))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PaymentInfo MakePayment(Card cardInfo, double amount);

		/// <summary>
		/// Refunds the payment to a specific card
		/// </summary>
		/// <param name="cardInfo">The card to which the payment is made</param>
		/// <param name="amount"></param>
		/// <returns></returns>
		[OperationContract]
		[FaultContract(typeof(ServiceExceptionInfo))]
		[TransactionFlow(TransactionFlowOption.Allowed)]
		PaymentInfo MakeRefund(Card cardInfo, double amount);
    }
}
