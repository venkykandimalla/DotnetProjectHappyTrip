using System;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.Model.PaymentService
{
    /// <summary>
    /// Interface to expose the abstraction to make a payment
    /// </summary>
    public interface IPaymentManager
    {
        /// <summary>
        /// Makes the payment by contacting the payment gateway
        /// </summary>
        /// <param name="cardForPayment"></param>
        /// <param name="amount"></param>
        /// <param name="status"></param>
        /// <exception cref="PaymentNotProcessedFromServiceException">Thrown when unable to process the payment</exception>
        /// <returns>Returns the payment reference number</returns>
        string MakePayment(HappyTrip.Model.Entities.Transaction.Card cardForPayment, decimal amount, out PaymentStatus status);
    }
}
