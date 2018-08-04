using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using System.Data;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.Transaction
{
	/// <summary>
	/// DAO class for handling travel miles for a user
	/// </summary>
    class HappyMilesDAO : DAO, IHappyMilesDAO
    {
        IDbConnection conn = null;
        IDbCommand cmd = null;
        IDbDataAdapter dataAdapter = null;

		/// <summary>
		/// Method to retrieve the travel miles for a user
		/// </summary>
		/// <param name="userName">The user name</param>
		/// <returns>The number of miles accumulated</returns>
        public int GetHappyMilesForUser(string userName)
        {
            int travelMiles = 0;

            try
            {
                travelMiles = (int)ExecuteStoredProcedureScalar("GetTravelMilesForUser",
                    new SqlParameter() { ParameterName = "@username", DbType = DbType.String, Value = userName }
                );
            }
            catch (Exception)
            {
                travelMiles = 0;
            }

            return travelMiles;
        }

		/// <summary>
		/// Method to update the travel miles for a user
		/// </summary>
		/// <param name="userName">The name of the user</param>
		/// <param name="travelMiles">The number of miles to accumulated</param>
		/// <returns>boolean status</returns>
        public bool UpdateHappyMilesForUser(string userName, int travelMiles, string bookingRefNo)
        {
			bool isSucceeded = false;

			try
			{
                ExecuteStoredProcedure("UpdateTravelMiles",
                    new SqlParameter() { ParameterName = "@username", DbType = DbType.String, Value = userName },
                    new SqlParameter() { ParameterName = "@travelmiles", DbType = DbType.String, Value = travelMiles },
                    new SqlParameter() { ParameterName = "@bookingrefno", DbType = DbType.String, Value = bookingRefNo }
                );

				isSucceeded = true;
			}
			catch (Exception)
			{
				throw;
			}

			return isSucceeded;
        }

        public int GetHappyMilesForBookingReference(string bookingRefNo)
        {
            try
            {
                int happyMiles = 0;
                happyMiles = (int)ExecuteStoredProcedureScalar("GetHappyMilesForBookingReference",
                    new SqlParameter() { ParameterName = "@bookingrefno", DbType = DbType.String, Value = bookingRefNo }
                );

                return happyMiles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
