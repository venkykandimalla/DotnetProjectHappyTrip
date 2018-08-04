using System;
namespace HappyTrip.DataAccessLayer.Search
{
    /// <summary>
    /// Interface to the represent the search operations to be performed on the database
    /// </summary>
    public interface ISearchDAO
    {
        /// <summary>
        /// Gets the availability of schedule for the given information
        /// </summary>
        /// <param name="scheduleForAvailability"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="tClass"></param>
        /// <exception cref="FlightAvailabilityDAOException">Thorws when flights not available</exception>
        /// <returns>True if avalable. False if not available</returns>
        bool GetAvailabilityForSchedule(HappyTrip.Model.Entities.AirTravel.Schedule scheduleForAvailability, int numberOfSeats, DateTime dateOfJourney, HappyTrip.Model.Entities.AirTravel.TravelClass tClass);

        /// <summary>
        /// Gets the cities in the database
        /// </summary>
        /// <exception cref="CityDAOException">CityDAO Exception is thrown if not able to get from database</exception>
        /// <returns>The list of cities after fetching from the database</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.Common.City> GetCities();

        /// <summary>
        /// Gets the flight schedules for the search made by the user
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <exception cref="SearchFlightDAOException">Throws SearchFlightDAOException if flights are not available or if there is any other exception</exception>
        /// <returns>Returns the schedules for the given search - which is a custom collection</returns>
        HappyTrip.Model.Entities.AirTravel.Schedules SearchForFlight(HappyTrip.Model.Entities.AirTravel.SearchInfo searchInformation);

        /// <summary>
        /// Search for user booking history
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BookingsFrom"></param>
        /// /// <param name="BookingsTo"></param>
        /// <returns>Returns the list of bookings between given dates</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.Transaction.FlightBooking> SearchUserBookings(string UserID, DateTime BookingsFrom, DateTime BookingsTo);
    }
}
