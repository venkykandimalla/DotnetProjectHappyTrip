using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Transaction
{
    public interface IHappyMilesDAO
    {
        int GetHappyMilesForUser(string userName);
        bool UpdateHappyMilesForUser(string userName, int happyMiles, string bookingRefNo);
        int GetHappyMilesForBookingReference(string bookingRefNo);
    }
}
