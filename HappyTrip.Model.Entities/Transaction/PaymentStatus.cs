using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Enum to represent the status of payment made
    /// </summary>
    public enum PaymentStatus
    {
        Success = 1,
        InvalidCardHolder,
        InvalidCardNo,
        InsufficientFunds,
        InvalidExpiryDate,
        Declined
    }
}
