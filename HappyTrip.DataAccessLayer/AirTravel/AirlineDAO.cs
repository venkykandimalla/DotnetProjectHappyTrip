using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Class to represent the database related activities  
    /// with respect to airline operations for fetch
    /// </summary>
    class AirlineDAO:DAO,IAirlineDAO
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AirlineDAO()
        {

        }

        #region Method to get the airlines details from the database
        /// <summary>
        /// Gets the airlines from the database
        /// </summary>
        /// <exception cref="AirlineDAOException">Throws an exception if unable to get airlines</exception>
        /// <returns>Returns a data set of airlines from the database</returns>
        public DataSet GetAirlines()
        {
            DataSet dataset = new DataSet();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(conn, "GetAirlines"))
                    {
                        DataTable airlnedt = dataset.Tables.Add("Airlines");

                        airlnedt.Columns.Add("AirlineId", typeof(long));
                        airlnedt.Columns.Add("AirlineName", typeof(string));
                        airlnedt.Columns.Add("AirlineCode", typeof(string));
                        airlnedt.Columns.Add("AirlineLogo", typeof(string));

                        while (reader.Read())
                        {
                            DataRow rw = airlnedt.NewRow();
                            rw["AirlineId"] = reader["AirlineId"];
                            rw["AirlineName"] = reader["AirlineName"];
                            rw["AirlineCode"] = reader["AirlineCode"];
                            rw["AirlineLogo"] = reader["AirlineLogo"];

                            airlnedt.Rows.Add(rw);
                        }

                    }
                }
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new RouteDAOException("Unable to get routes");
            }
            catch (Exception)
            {
                throw new RouteDAOException("Unable to get routes");
            }

            return dataset;
        }
        #endregion
    }
}
        