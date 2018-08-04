using System;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.Model.BusinessLayer.UserAccount
{
    /// <summary>
    /// Interface defined to manage the activities of a user
    /// </summary>
    public interface IAccountManager
    {
        BookingHistory GetBookingHistoryForUser(string UserName);
    }
}
