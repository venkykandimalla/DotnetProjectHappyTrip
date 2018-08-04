using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    public interface IHappyMiles
    {
        int GetHappyMilesForUser(string userName);
        int UpdateHappyMilesForUser(string userName, List<int> airlines, double ticketCost, string bookingRefNo);
        int GetHappyMilesForBookingReference(string bookingRefNo);
    }
}
