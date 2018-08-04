using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.Data;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
    /// <summary>
    /// Interface to represent the abstractions for Booking
    /// </summary>
    public interface IBookingManager
    {
        /// <summary>
        /// Processes a booking to be made - flight 
        /// </summary>
        /// <param name="newTravelBooking"></param>
        /// <param name="cardForBooking"></param>
        /// <returns>Returns a travel booking object updated with all the booking information</returns>
        TravelBooking ProcessAirTravelBooking(HappyTrip.Model.Entities.Transaction.TravelBooking NewTravelBooking, HappyTrip.Model.Entities.Transaction.Card CardForBooking);
        bool CancelAirTravelBooking(Cancelation cancelation, DateTime dateOfJourney, TimeSpan departureTime);
        DataSet GetFlightBooking(string bookingRefNo, Guid CurrentUserId);
        bool IsBookingsAvailable(string bookingRefNo);
        
    }
}
