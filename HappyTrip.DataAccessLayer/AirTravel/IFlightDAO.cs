using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the flight operations to be performed on the database
    /// </summary>
    public interface IFlightDAO : IAirTravelDAO
    {
        /// <summary>
        /// Get the flight details from the database
        /// </summary>
        /// <exception cref="FlightDAOException">Thorws an exception when unable to get flights</exception>
        /// <returns>Returns the list of flights from the database</returns>
        List<Flight> GetFlights();

        /// <summary>
        /// Add the flight details for the database
        /// </summary>
        /// <parameter name="flight"></parameter>
        /// <returns>Returns the status of the insert</returns>
        bool AddFlight(Flight flight);

        /// <summary>
        /// Update the existing flight details for a given flight id for the database
        /// </summary>
        /// <parameter name="flight"></parameter>
        /// <returns>Returns the number of rows affected by the update</returns>
        int UpdateFlight(Flight flight);

        /// <summary>
        /// Update the existing flight class seats for a given flight id for the database
        /// </summary>
        /// <parameter name="flight"></parameter>
        /// <parameter name="flightClass"></parameter>
        /// <returns>Returns the number of rows affected by the insert</returns>
        int UpdateFlightClass(Flight flight, FlightClass flightClass);

        /// <summary>
        /// Get the flights details for a given flight from the database
        /// </summary>
        /// <parameter name="FlightId"></parameter>
        /// <returns>Returns the flight for a given id from the database</returns>
        Flight GetFlight(int flightId);
    }
}
