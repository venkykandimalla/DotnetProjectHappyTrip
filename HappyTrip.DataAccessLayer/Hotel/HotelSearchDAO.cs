using System;
using System.Data;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.Hotel
{
	class HotelSearchDAO : DataAccessLayer.Common.DAO, IHotelSearchDAO
	{
		private static HotelSearchDAO searchDAO = new HotelSearchDAO();

		private HotelSearchDAO()
		{
		}

		public static HotelSearchDAO GetInstance()
		{
			return searchDAO;
		}


		#region IHotelSearchDAO Members
        /// <summary>
        /// Gets the search result for hotel search information
        /// </summary>
        /// <param name="hsi"></param>
        /// <returns></returns>
        public Model.Entities.Hotel.SearchResult SearchForHotels(Model.Entities.Hotel.SearchInfo hsi)
        {
            HappyTrip.Model.Entities.Hotel.SearchResult hsr = new HappyTrip.Model.Entities.Hotel.SearchResult();

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetHotels",
                        new SqlParameter() { ParameterName = "@xxx", DbType = DbType.String, Value = hsi.DesitinationCity.CityId },
                        new SqlParameter() { ParameterName = "@xxx", DbType = DbType.String, Value = hsi.CheckInDate },
                        new SqlParameter() { ParameterName = "@xxx", DbType = DbType.String, Value = hsi.CheckOutDate },
                        new SqlParameter() { ParameterName = "@xxx", DbType = DbType.String, Value = hsi.NoOfPeople },
                        new SqlParameter() { ParameterName = "@xxx", DbType = DbType.String, Value = hsi.NoOfRooms })
                    )
                    {
                        while (reader.Read())
                        {
                            HappyTrip.Model.Entities.Hotel.Hotel h = new HappyTrip.Model.Entities.Hotel.Hotel();
                            h.HotelId = Convert.ToInt64(reader["HotelId"]);
                            h.HotelName = reader["HotelName"].ToString();
                            h.PhotoUrl = reader["PhotoUrl"].ToString();
                            h.StarRanking = Convert.ToInt32(reader["StarRanking"]);

                            hsr.AddHotel(h);
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new HotelDAOException("Unable to search for hotels", ex);
            }
            catch (Exception ex)
            {
                throw new HotelDAOException("Unable to search for hotels", ex);
            }

            return hsr;
        }
		#endregion
	}
}
