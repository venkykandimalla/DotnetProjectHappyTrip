using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities;
using System.Data.Common;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.DataAccessLayer.Search
{
    /// <summary>
    /// Class to represent the database related activities with respect to searching of a 
    /// flight for the given parameters
    /// </summary>
    class SearchDAO : DataAccessLayer.Common.DAO, HappyTrip.DataAccessLayer.Search.ISearchDAO
    {
        /// <summary>
        /// Instance of the class created. To make it a singleton class
        /// </summary>
        private static SearchDAO instance = new SearchDAO();

        /// <summary>
        /// Default Constructor being made private
        /// </summary>
        private SearchDAO()
        {

        }


        #region Method to get the instance of SearchDAO
        /// <summary>
        /// Gets the instance of SearchDAO as this a singleton
        /// </summary>
        /// <returns></returns>
        public static SearchDAO GetInstance()
        {
            return instance;
        }
        #endregion

        #region Method to get the flights for the search made by a user
        /// <summary>
        /// Gets the flight schedules for the search made by the user
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <exception cref="SearchFlightDAOException">Throws SearchFlightDAOException if flights are not available or if there is any other exception</exception>
        /// <returns>Returns the schedules for the given search - which is a custom collection</returns>
        public Schedules SearchForFlight(SearchInfo searchInformation)
        {
            Schedules schCollection = null;

            try
            {
                TimeSpan ts;
                int hours = 0;
                int minutes = 0;
                int seconds = 0;

                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetFlightSchedules",
                        new SqlParameter() { ParameterName = "@FromCityId", DbType = DbType.Int32, Value = searchInformation.FromCity.CityId },
                        new SqlParameter() { ParameterName = "@ToCityId", DbType = DbType.Int32, Value = searchInformation.ToCity.CityId },
                        new SqlParameter() { ParameterName = "@ClassId", DbType = DbType.Int32, Value = (int)searchInformation.Class })
                    )
                    {
                        schCollection = new Schedules();

                        while (reader.Read())
                        {
                            Schedule sch = new Schedule();
                            sch.ID = Convert.ToInt64(reader["ScheduleId"]);

                            hours = Convert.ToDateTime(reader["ArrivalTime"]).Hour;
                            minutes = Convert.ToDateTime(reader["ArrivalTime"]).Minute;
                            seconds = Convert.ToDateTime(reader["ArrivalTime"]).Second;
                            ts = new TimeSpan(hours, minutes, seconds);
                            sch.ArrivalTime = ts;

                            hours = Convert.ToDateTime(reader["DepartureTime"]).Hour;
                            minutes = Convert.ToDateTime(reader["DepartureTime"]).Minute;
                            seconds = Convert.ToDateTime(reader["DepartureTime"]).Second;
                            ts = new TimeSpan(hours, minutes, seconds);
                            sch.DepartureTime = ts;

                            sch.DurationInMins = Convert.ToInt16(reader["DurationInMins"]);
                            sch.IsActive = Convert.ToBoolean(reader["IsActive"]);

                            Airline objAirlineForFlight = new Airline();
                            objAirlineForFlight.Code = reader["AirlineCode"].ToString();
                            objAirlineForFlight.Id = Convert.ToInt16(reader["AirlineId"]);
                            objAirlineForFlight.Logo = reader["AirlineLogo"].ToString();
                            objAirlineForFlight.Name = reader["AirlineName"].ToString();

                            Flight objFlight = new Flight();
                            objFlight.ID = Convert.ToInt16(reader["FlightId"]);
                            objFlight.Name = reader["FlightName"].ToString();
                            objFlight.AirlineForFlight = objAirlineForFlight;
                            FlightClass fc = new FlightClass();
                            fc.ClassInfo = (TravelClass)(Convert.ToInt16(reader["ClassId"]));
                            fc.NoOfSeats = Convert.ToInt32(reader["NoOfSeats"]);
                            objFlight.AddClass(fc);

                            FlightCost objFlightCost = new FlightCost();
                            objFlightCost.CostPerTicket = Convert.ToDecimal(reader["CostPerTicket"]);
                            objFlightCost.Class = (TravelClass)(Convert.ToInt16(reader["ClassId"]));

                            City objFromCity = new City();
                            objFromCity.CityId = Convert.ToInt64(reader["FromCityId"]);
                            objFromCity.Name = reader["FromCityName"].ToString();

                            City objToCity = new City();
                            objToCity.CityId = Convert.ToInt64(reader["ToCityId"]);
                            objToCity.Name = reader["ToCityName"].ToString();

                            Route objRoute = new Route();
                            objRoute.DistanceInKms = Convert.ToDouble(reader["DistanceInKms"]);
                            objRoute.FromCity = objFromCity;
                            objRoute.ToCity = objToCity;

                            sch.FlightInfo = objFlight;
                            sch.AddFlightCost(objFlightCost);
                            sch.RouteInfo = objRoute;

                            schCollection.AddSchedule(sch);
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new SearchFlightDAOException("Unable to Search for Flight", ex);
            }
            catch (Exception ex)
            {
                throw new SearchFlightDAOException("Unable to Search for Flight", ex);
            }

            return schCollection;
        }
        #endregion

        #region Method to get all the cities with state information
        /// <summary>
        /// Gets the cities in the database
        /// </summary>
        /// <exception cref="CityDAOException">CityDAO Exception is thrown if not able to get from database</exception>
        /// <returns>The list of cities after fetching from the database</returns>
        public List<City> GetCities()
        {
            List<City> cities = null;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetCities"))
                    {
                        cities = new List<City>();

                        while (reader.Read())
                        {
                            City city = new City();
                            city.CityId = Convert.ToInt64(reader["CityId"]);
                            city.Name = reader["CityName"].ToString();

                            State state = new State();
                            state.StateId = Convert.ToInt64(reader["StateId"]);
                            state.Name = reader["StateName"].ToString();

                            city.StateInfo = state;

                            cities.Add(city);
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new Common.CityDAOException("Unable to Get Cities", ex);
            }
            catch (Exception ex)
            {
                throw new Common.CityDAOException("Unable to Get Cities", ex);
            }

            return cities;
        }
        #endregion

        #region Method to get the availability for a given schedule
        /// <summary>
        /// Gets the availability of schedule for the given information
        /// </summary>
        /// <param name="scheduleForAvailability"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="tClass"></param>
        /// <exception cref="FlightAvailabilityDAOException">Thorws when flights not available</exception>
        /// <returns>True if avalable. False if not available</returns>
        public bool GetAvailabilityForSchedule(Schedule scheduleForAvailability, int numberOfSeats, DateTime dateOfJourney, TravelClass tClass)
        {
            bool isAvailable = false;

            try
            {
                //Write code to store data into database
                IDbConnection dbConnection = GetConnection();
                SqlParameter prmIsAvailable = new SqlParameter() { ParameterName = "@IsAvailable", DbType = DbType.Boolean, Value = 0, Direction = ParameterDirection.Output };

                ExecuteStoredProcedure("CheckAvailabilityOfSchedule",
                    new SqlParameter() { ParameterName = "@ScheduleId", DbType = DbType.Int64, Value = scheduleForAvailability.ID },
                    new SqlParameter() { ParameterName = "@NoOfSeats", DbType = DbType.Int32, Value = numberOfSeats },
                    new SqlParameter() { ParameterName = "@DateOfJourney", DbType = DbType.DateTime, Value = dateOfJourney },
                    new SqlParameter() { ParameterName = "@ClassId", DbType = DbType.Int32, Value = (int)tClass },
                    prmIsAvailable
                );
                
                isAvailable = Convert.ToBoolean(prmIsAvailable.Value);
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new FlightAvailabilityDAOException("Unable to get availability of flights", ex);
            }
            catch (Exception ex)
            {
                throw new FlightAvailabilityDAOException("Unable to get availability of flights", ex);
            }

            return isAvailable;
        }
        #endregion

        #region Method to get the availability for a given schedule
        /// <summary>
        /// Search for user booking history
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BookingsFrom"></param>
        /// /// <param name="BookingsTo"></param>
        /// <returns>Returns the list of bookings between given dates</returns>
        public System.Collections.Generic.List<HappyTrip.Model.Entities.Transaction.FlightBooking> SearchUserBookings(string UserID, DateTime BookingsFrom, DateTime BookingsTo)
        {
            List<FlightBooking> lstBookings = null;

            try
            {
                string strSQL = "select bookings.BookingId, Bookings.BookingReferenceNo, bookings.BookingDate, bookings.TotalCost, bookings.IsCanceled, FlightBookings.DateOfJourney, f.CityId \"FromCityId\", f.CityName \"FromCity\", t.CityId \"ToCityId\",  t.CityName \"ToCity\", airlines.AirlineId, airlines.AirlineLogo, airlines.AirlineName, flights.FlightId, flights.FlightName, Routes.RouteId, Routes.Status, Schedules.ScheduleId from dbo.Bookings join dbo.FlightBookings on dbo.Bookings.BookingId = dbo.FlightBookings.BookingId join dbo.FlightBookingSchedules on dbo.Bookings.BookingId = dbo.FlightBookingSchedules.BookingId join dbo.Schedules on dbo.FlightBookingSchedules.ScheduleId = dbo.Schedules.ScheduleId join dbo.Routes on dbo.Schedules.RouteId = dbo.Routes.RouteId join dbo.Cities f on dbo.Routes.FromCityId = f.CityId join dbo.Cities t on dbo.Routes.ToCityId = t.CityId join dbo.Flights on dbo.Schedules.FlightId = dbo.Flights.FlightId join dbo.Airlines on dbo.Flights.AirlineId = dbo.Airlines.AirlineId join dbo.UserBookings on dbo.UserBookings.BookingId = dbo.Bookings.BookingId where dbo.UserBookings.UserId = '" + UserID + "' ";

                /* This temporary SQL can be used to fetch some results **************************/
                //strSQL = "select Bookings.BookingId, Bookings.BookingReferenceNo, bookings.BookingDate, bookings.TotalCost, bookings.IsCanceled, FlightBookings.DateOfJourney, f.CityId \"FromCityId\", f.CityName \"FromCity\", t.CityId \"ToCityId\",  t.CityName \"ToCity\", airlines.AirlineId, airlines.AirlineLogo, airlines.AirlineName, flights.FlightId, flights.FlightName, Routes.RouteId, Routes.Status, Schedules.ScheduleId from dbo.Bookings join dbo.FlightBookings on dbo.Bookings.BookingId = dbo.FlightBookings.BookingId join dbo.FlightBookingSchedules on dbo.Bookings.BookingId = dbo.FlightBookingSchedules.BookingId join dbo.Schedules on dbo.FlightBookingSchedules.ScheduleId = dbo.Schedules.ScheduleId join dbo.Routes on dbo.Schedules.RouteId = dbo.Routes.RouteId join dbo.Cities f on dbo.Routes.FromCityId = f.CityId join dbo.Cities t on dbo.Routes.ToCityId = t.CityId join dbo.Flights on dbo.Schedules.FlightId = dbo.Flights.FlightId join dbo.Airlines on dbo.Flights.AirlineId = dbo.Airlines.AirlineId ";

                TimeSpan Span = new TimeSpan(23, 59, 59);
                if (BookingsFrom != DateTime.MinValue && BookingsTo != DateTime.MaxValue)
                {
                    strSQL += " and Bookings.BookingDate between '" + BookingsFrom.ToShortDateString() + "' and '" + BookingsTo.Add(Span).ToString() + "'";
                }
                else if (BookingsFrom != DateTime.MinValue)
                {
                    strSQL += " and Bookings.BookingDate >= '" + BookingsFrom.ToShortDateString() + "'";
                }
                else if (BookingsTo != DateTime.MaxValue)
                {
                    strSQL += " and Bookings.BookingDate <= '" + BookingsTo.Add(Span).ToString() + "'";
                }

                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteQueryResults(db, strSQL))
                    {
                        lstBookings = new List<FlightBooking>();
                        while (reader.Read())
                        {
                            City FromCity = new City() { CityId = (long)reader["FromCityId"], Name = (string)reader["FromCity"] };
                            City ToCity = new City() { CityId = (long)reader["ToCityId"], Name = (string)reader["ToCity"] };
                            Route RouteInfo = new Route() { ID = (long)reader["RouteId"], IsActive = (bool)reader["Status"], FromCity = FromCity, ToCity = ToCity };

                            Airline AirlineInfo = new Airline() { Id = (int)reader["AirlineId"], Logo = (string)reader["AirlineLogo"], Name = (string)reader["AirlineName"] };
                            Flight FlightInfo = new Flight() { ID = (long)reader["FlightId"], Name = (string)reader["FlightName"], AirlineForFlight = AirlineInfo };

                            Schedule ScheduleInfo = new Schedule() { ID = (long)reader["ScheduleId"], RouteInfo = RouteInfo, FlightInfo = FlightInfo };

                            TravelSchedule TravelScheduleInfo = new TravelSchedule();
                            TravelScheduleInfo.AddSchedule(ScheduleInfo);

                            FlightBooking Booking = new FlightBooking()
                            {
                                BookingId = (long)reader["BookingId"],
                                BookingDate = (DateTime)reader["BookingDate"],
                                ReferenceNo = (string)reader["BookingReferenceNo"],
                                TotalCost = (decimal)reader["TotalCost"],
                                IsCanceled = (bool)reader["IsCanceled"],

                                DateOfJourney = (DateTime)reader["DateOfJourney"],

                                TravelScheduleInfo = TravelScheduleInfo
                            };

                            lstBookings.Add(Booking);
                        }

                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new Exception("Unable to Get Bookings", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Get Bookings", ex);
            }

            return lstBookings;
        }
        #endregion
    }
}
