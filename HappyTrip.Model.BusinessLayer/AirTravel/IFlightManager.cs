using System;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public interface IFlightManager : IAirTravelManager
    {
        /// <summary>
        /// Add the flight with seats for different travel class
        /// </summary>
        /// <param name="flight"></param>
        /// <exception cref="FlightManagerException">Thorwn when unable to add a flight</exception>
        /// <returns>Returns the status of adding a flight</returns>
        bool AddFlight(HappyTrip.Model.Entities.AirTravel.Flight flight);

        /// <summary>
        /// Get the flight details for a given flight id
        /// </summary>
        /// <parameter name="flightId"></parameter>
        /// <exception cref="FlightManagerException">Thorwn when unable to get flights</exception>
        /// <returns>Returns a flight for a given flight id</returns>
        HappyTrip.Model.Entities.AirTravel.Flight GetFlight(int flightId);

        /// <summary>
        /// Gets all the flights
        /// </summary>
        /// <exception cref="FlightManagerException">Thorwn when unable to get flights</exception>
        /// <returns>Returns list of flights</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.AirTravel.Flight> GetFlights();

        /// <summary>
        /// Gets the flight details for a given airline id
        /// </summary>
        /// <parameter name="airlineId"></parameter>
        /// <exception cref="FlightManagerException">Thorwn when unable to get flights for a given airline</exception>
        /// <returns>Returns list of flights for an airline</returns>
        System.Collections.Generic.List<HappyTrip.Model.Entities.AirTravel.Flight> GetFlightsForAirLine(int airlineId);

        /// <summary>
        /// Update the existing flight details
        /// </summary>
        /// <exception cref="FlightManagerException">Thorwn when unable to update a flight</exception>
        /// <param name="flight"></param>
        /// <returns>Retruns the status of the update of a flight</returns>
        int UpdateFlight(HappyTrip.Model.Entities.AirTravel.Flight flight);

        /// <summary>
        /// Update the existing flight details along with seats and class
        /// </summary>
        /// <parameter name="flightClassInfo"></parameter>
        /// <parameter name="flightInfo"></parameter>
        /// <exception cref="FlightManagerException">Thorwn when unable to update flight class</exception>
        /// <returns>Returns the status of the update</returns>
        int UpdateFlightClass(HappyTrip.Model.Entities.AirTravel.Flight flightInfo, HappyTrip.Model.Entities.AirTravel.FlightClass flightClassInfo);
    }
}
