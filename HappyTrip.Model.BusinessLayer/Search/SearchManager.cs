using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Search;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to manage the activities related to search of flights on the portal
    /// </summary>
    public class SearchManager : HappyTrip.Model.BusinessLayer.Search.ISearchManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        ISearchDAO searchDAO = null;

        public ISearchDAO SearchDAO
        {
            get { return searchDAO; }
            set { searchDAO = value; }
        }

        public SearchManager()
        {
            searchDAO = SearchDAOFactory.GetInstance().Create();
        }

        public SearchManager(ISearchDAO searchDAO)
        {
            this.searchDAO = searchDAO;
        }

        #region Methods to search for flights and return the search results based on the search criteria
        /// <summary>
        /// Gets the flight schedules based on the search criteria. 
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <exception cref="FlightsNotAvailableException">Thorws an exception when unable to retrieve flights</exception>
        /// <returns>Returns a search log to the caller</returns>
        public SearchLog SearchForFlights(SearchInfo searchInformation)
        {
            SearchResult result = null; ;
            SearchLog log = new SearchLog();
            try
            {
                result = GetSearchResult(searchInformation);

                //Add the result to searchlog based on it being Onward or Return
                AddSearchResultToLog(TravelDirection.OneWay, result, log);

                if (searchInformation.Direction == TravelDirection.Return)
                {
                    SearchInfo info = new SearchInfo();
                    info.Class = searchInformation.Class;
                    info.FromCity = searchInformation.ToCity;
                    info.ToCity = searchInformation.FromCity;

                    result = GetSearchResult(info);
                    AddSearchResultToLog(TravelDirection.Return, result, log);
                }
                
            }
            catch (FlightsNotAvailableException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FlightsNotAvailableException("Unable to Retrieve Flights" ,ex);
            }

            //5. Return Log
            return log;
        }

        /// <summary>
        /// Gets the search result for the search criteria
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <exception cref="FlightsNotAvailableException">Thorws the exception when flights are not available for the given search information</exception>
        /// <returns>Returns the search result for the given search information</returns>
        private SearchResult GetSearchResult(SearchInfo searchInformation)
        {
            SearchResult result = new SearchResult();

            try
            {
                //Get the Schedules from the database based on the search information
                Schedules scheduleCollection = searchDAO.SearchForFlight(searchInformation);
                if (scheduleCollection == null)
                    throw new FlightsNotAvailableException("Flights not available");

                //Add search result for direct flights from the schedules obtained from database
                //based on the search criteria
                try
                {
                    AddSearchResultForDirectFlights(searchInformation, scheduleCollection, result);
                }
                catch (DirectFlightsNotAvailableException)
                {

                }

                //Add search result for connecting flights from the schedules obtained from database
                //based on the search criteria
                try
                {
                    AddSearchResultForConnectingFlights(searchInformation, scheduleCollection, result);
                }
                catch (ConnectingFlightsNotAvailableException)
                {

                }

            }
            catch (SearchFlightDAOException ex)
            {
                throw new FlightsNotAvailableException("Unable to Retrieve Flights", ex);
            }
            catch (FlightsNotAvailableException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new FlightsNotAvailableException("Unable to Retrieve Flights", ex);
            }
            

            return result;
        }

        /// <summary>
        /// Adds the search result for direct flights into the schedule for travel
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <param name="scheduleCollection"></param>
        /// <param name="result"></param>
        /// <exception cref="DirectFlightsNotAvailableException">Throws the exception when direct flights are not available for given search information</exception>
        private void AddSearchResultForDirectFlights(SearchInfo searchInformation, Schedules scheduleCollection, SearchResult result)
        {
            TravelSchedule scheduleForTravel = null;

            foreach (Schedule s in scheduleCollection)
            {
                if (s.RouteInfo.FromCity.CityId == searchInformation.FromCity.CityId && s.RouteInfo.ToCity.CityId == searchInformation.ToCity.CityId)
                {
                    //Check if the schedule to be sent back is valid
                    if (CheckIfScheduleIsValid(s, searchInformation))
                    {
                        //Create a new TravelSchedule
                        scheduleForTravel = CreateTravelSchedule(ScheduleType.Direct);

                        //Add schedules to Travel Schedule
                        AddScheduleForTravel(scheduleForTravel, s);

                        //Compute total cost for the Travel Schedule
                        CalculateTotalCostForTravel(scheduleForTravel);

                        //Add the travel schedule defined to the search result
                        AddTravelScheduleToResult(scheduleForTravel, result);
                    }
                }
            }

            if (scheduleForTravel == null)
                throw new DirectFlightsNotAvailableException("Direct Flights Not Available");
        }

        /// <summary>
        /// Adds the search result for connecting flights in the schedule
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <param name="scheduleCollection"></param>
        /// <param name="result"></param>
        /// <exception cref="ConnectingFlightsNotAvailableException">Throws the exception when connecting flights are not available for given search information</exception>
        private void AddSearchResultForConnectingFlights(SearchInfo searchInformation, Schedules scheduleCollection, SearchResult result)
        {
            Schedules connectingSchedules = null;
            bool isConnecting = false;
            TravelSchedule scheduleForTravel = null;

            foreach (Schedule s in scheduleCollection)
            {
                connectingSchedules = null;
                isConnecting = false;

                if (s.RouteInfo.FromCity.CityId == searchInformation.FromCity.CityId && s.RouteInfo.ToCity.CityId != searchInformation.ToCity.CityId)
                {
                    //Create connecting schedules collection and add the current schedule
                    connectingSchedules = new Schedules();
                    connectingSchedules.AddSchedule(s);

                    isConnecting = FindFlightSchedule(searchInformation.ToCity, scheduleCollection, s, connectingSchedules);
                    if (isConnecting)
                    {
                        bool isValid = false;

                        foreach (Schedule sch in connectingSchedules)
                        {
                            isValid = CheckIfScheduleIsValid(s, searchInformation);
                            if (!isValid)
                                break;
                        }

                        if (isValid)
                        {
                            //Create a new TravelSchedule
                            scheduleForTravel = CreateTravelSchedule(ScheduleType.Connecting);

                            //Add schedules to Travel Schedule
                            AddScheduleForTravel(scheduleForTravel, connectingSchedules);

                            //Compute total cost for the Travel Schedule
                            CalculateTotalCostForTravel(scheduleForTravel);

                            //Add the travel schedule defined to the search result
                            AddTravelScheduleToResult(scheduleForTravel, result);
                        }
                    }
                }
            }

            if (scheduleForTravel == null)
                throw new ConnectingFlightsNotAvailableException("Connecting Flights Not Available");
        }

        /// <summary>
        /// Method to check if a schedule to be returned is valid
        /// </summary>
        /// <param name="s"></param>
        /// <param name="searchInformation"></param>
        /// <returns></returns>
        private bool CheckIfScheduleIsValid(Schedule s, SearchInfo searchInformation)
        {
            bool isValid = false;
            try
            {
                isValid = CheckIfDateTimeHasExpired(s, searchInformation);

                if (isValid)
                    isValid = GetAvailabilityForSchedule(s, searchInformation.NoOfSeats, searchInformation.OnwardDateOfJourney, searchInformation.Class);
            }
            catch (ScheduleExpiredException) { }
            catch (FlightSeatsAvailabilityException) { }

            return isValid;
        }

        /// <summary>
        /// Method to check if a schedule departure time has crossed the current date time
        /// </summary>
        /// <param name="s"></param>
        /// <param name="searchInformation"></param>
        /// <returns></returns>
        private bool CheckIfDateTimeHasExpired(Schedule s, SearchInfo searchInformation)
        {
            bool isValid = true;

            TimeSpan currentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            TimeSpan departureTime = new TimeSpan(s.DepartureTime.Hours, s.DepartureTime.Minutes, 0);

            TimeZone zone = TimeZone.CurrentTimeZone;
            DateTime currentDate = zone.ToUniversalTime(DateTime.Now);
            if (currentDate.Date.Equals(searchInformation.OnwardDateOfJourney.Date))
                if (departureTime.Subtract(currentTime).Hours < 3)
                    throw new ScheduleExpiredException("Schedule Departure Time Has Expired");

            return isValid;
        }

        /// <summary>
        /// Adds the search result to log
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="result"></param>
        /// <param name="log"></param>
        private void AddSearchResultToLog(TravelDirection direction, SearchResult result, SearchLog log)
        {
            log.AddSearchResultToLog(direction, result);
        }

        /// <summary>
        /// Gets the connecting flight schedules for a given schedule
        /// </summary>
        /// <param name="toCity"></param>
        /// <param name="schCollection"></param>
        /// <param name="s"></param>
        /// <param name="connectingSchedules"></param>
        /// <returns>Returns the status of whether the connecting schedules were found or not</returns>
        private bool FindFlightSchedule(City toCity, Schedules schCollection, Schedule s, Schedules connectingSchedules)
        {
            bool isConnecting = false;

            foreach (Schedule cs in schCollection)
            {
                if (cs.RouteInfo.FromCity.CityId == s.RouteInfo.ToCity.CityId)
                {
                    connectingSchedules.AddSchedule(cs);

                    if (cs.RouteInfo.ToCity.CityId == toCity.CityId)
                    {
                        isConnecting = true;
                        break;
                    }
                    else
                        isConnecting = FindFlightSchedule(toCity, schCollection, cs, connectingSchedules);
                }
            }

            return isConnecting;
        }

        /// <summary>
        /// Creates a travel schedule based on the type of schedule
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Returns a TravelSchedule object for a given type</returns>
        private TravelSchedule CreateTravelSchedule(ScheduleType type)
        {
            TravelSchedule scheduleForTravel = new TravelSchedule();
            scheduleForTravel.Type = type;

            return scheduleForTravel;

        }

        /// <summary>
        /// Adds the schedule to the travel schedule for direct flight
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="schedule"></param>
        private void AddScheduleForTravel(TravelSchedule scheduleForTravel, Schedule schedule)
        {
            scheduleForTravel.AddSchedule(schedule);
        }

        /// <summary>
        /// Adds the schedule to the travel schedule for connecting flights
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="schedules"></param>
        private void AddScheduleForTravel(TravelSchedule scheduleForTravel, Schedules schedules)
        {
            foreach(Schedule s in schedules)
                scheduleForTravel.AddSchedule(s);
        }

        /// <summary>
        /// Calculates the total cost for each travel schedule
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        private void CalculateTotalCostForTravel(TravelSchedule scheduleForTravel)
        {
            foreach (Schedule s in scheduleForTravel.GetSchedules())
            {
                scheduleForTravel.TotalCostPerTicket += s.GetFlightCosts().FirstOrDefault().CostPerTicket;
            }
        }

        /// <summary>
        /// Adds the travel schedule to search result
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="result"></param>
        private void AddTravelScheduleToResult(TravelSchedule scheduleForTravel, SearchResult result)
        {
            result.AddTravelSchedule(scheduleForTravel);
        }
        #endregion

        #region Method to get all the cities with state information
        /// <summary>
        /// Gets the cities in the database
        /// </summary>
        /// <exception cref="CitiesNotAvailableException">Thorws exception when cities are not available to be returned</exception>
        /// <returns>List of cities</returns>
        public List<City> GetCities()
        {
            List<City> cities = null;

            try
            {
                cities = searchDAO.GetCities();
            }
            catch (DataAccessLayer.Common.CityDAOException ex)
            {
                throw new CitiesNotAvailableException("Unable to get cities", ex);
            }

            return cities;
        }
        #endregion

        #region Method to get the availability for a travel schedule
        /// <summary>
        /// Gets the availability of seats for a given travel schedule
        /// </summary>
        /// <param name="scheduleForAvailability"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="tClass"></param>
        /// <returns>Returns true if seats are available, else false</returns>
        public bool GetAvailabilityForSchedule(Schedule scheduleForAvailability, int numberOfSeats, DateTime dateOfJourney, TravelClass tClass)
        {
            bool isAvailable = false;

            try
            {
                isAvailable = searchDAO.GetAvailabilityForSchedule(scheduleForAvailability, numberOfSeats, dateOfJourney, tClass);
            }
            catch (FlightAvailabilityDAOException fadex)
            {
                throw new FlightSeatsAvailabilityException("Unable to check flight availability", fadex);
            }
            catch (Exception ex)
            {
                throw new FlightSeatsAvailabilityException("Unable to check flight availability", ex);
            }
            

            return isAvailable;
        }

        #endregion

        #region Methods to search for user booking history
        /// <summary>
        /// Get all user booking history
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>List of bookings</returns>
        public System.Collections.Generic.List<HappyTrip.Model.Entities.Transaction.FlightBooking> GetUserBookings(string UserID)
        {
            return SearchUserBookings(UserID, null, null);
        }

        /// <summary>
        /// Search for user booking history
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BookingsFrom"></param>
        /// <param name="BookingsTo"></param>
        /// <returns>List of bookings</returns>
        public System.Collections.Generic.List<HappyTrip.Model.Entities.Transaction.FlightBooking> SearchUserBookings(string UserID, string BookingsFrom, string BookingsTo)
        {
            List<HappyTrip.Model.Entities.Transaction.FlightBooking> Bookings = null;

            try
            {
                DateTime dtFrom = string.IsNullOrWhiteSpace(BookingsFrom) ? DateTime.MinValue : DateTime.Parse(BookingsFrom);
                DateTime dtTo = string.IsNullOrWhiteSpace(BookingsTo) ? DateTime.MaxValue : DateTime.Parse(BookingsTo);
                Bookings = searchDAO.SearchUserBookings(UserID, dtFrom, dtTo);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Bookings", ex);
            }

            return Bookings;
        }
        #endregion
    }
}
