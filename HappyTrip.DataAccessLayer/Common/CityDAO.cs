using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.Common;
using System.Data;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Class to represent the database related activities  
    /// with respect to cities operations for fetch,add,update
    /// </summary>
    class CityDAO : DAO, ICityDAO
    {

        #region Making the constructor public
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CityDAO()
        {

        }
        #endregion

        #region Method to get the states from the database
        /// <summary>
        /// Gets the states from the database
        /// </summary>
        /// <exception cref="StateDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>DataSet of States from the database</returns>
        public DataSet GetStates()
        {
            DataSet dataset = new DataSet();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "getStates"))
                    {
                        DataTable statedt = dataset.Tables.Add("States");

                        statedt.Columns.Add("StateId", typeof(long));
                        statedt.Columns.Add("StateName", typeof(string));

                        while (reader.Read())
                        {
                            DataRow rw = statedt.NewRow();
                            rw["StateId"] = reader["StateId"];
                            rw["StateName"] = reader["StateName"];

                            statedt.Rows.Add(rw);
                        }

                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new StateDAOException("Unable to get states", ex);
            }
            catch (Exception ex)
            {
                throw new StateDAOException("Unable to get states", ex);
            }

            return dataset;
        }
        #endregion


        #region Method to get the cities from the database
        /// <summary>
        /// Gets the cities from the database
        /// </summary>
        /// <exception cref="CityDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>Returns DataSet cities from the database</returns>
        public DataSet GetCities()
        {
            DataSet dataset = new DataSet();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetCities"))
                    {
                        DataTable citydt = dataset.Tables.Add("Cities");

                        citydt.Columns.Add("CityId", typeof(long));
                        citydt.Columns.Add("CityName", typeof(string));
                        citydt.Columns.Add("StateId", typeof(long));
                        citydt.Columns.Add("StateName", typeof(string));

                        while (reader.Read())
                        {
                            DataRow rw = citydt.NewRow();
                            rw["CityId"] = reader["CityId"];
                            rw["CityName"] = reader["CityName"];
                            rw["StateId"] = reader["StateId"];
                            rw["StateName"] = reader["StateName"];

                            citydt.Rows.Add(rw);
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }

            return dataset;
        }
        #endregion

		#region Method to get city by id
		/// <summary>
		/// Method to get city by its Id
		/// </summary>
		/// <param name="id">The Id of the city</param>
		/// <returns>City object based on id or null</returns>
		public City GetCityById(long id)
		{
            City city = new City();

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(db, "GetCitiyById"))
                    {
                        reader.Read();

                        city.CityId = Convert.ToInt64(reader["CityId"]);
                        city.Name = reader["CityName"].ToString();

                        State state = new State();
                        state.StateId = Convert.ToInt64(reader["StateId"]);
                        state.Name = reader["StateName"].ToString();

                        city.StateInfo = state;
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }

            return city;
		}
		#endregion

        #region Method to get the list of cities from the database
        /// <summary>
        /// Gets the list of cities from the database
        /// </summary>
        /// <exception cref="CityDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>Returns a list of cities from the database</returns>
        public List<Model.Entities.Common.City> GetListOfCities()
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
                throw new CityDAOException("Unable to get cities", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }

            return cities;
        }
        #endregion

		#region Method to add cities to the database
		/// <summary>
        /// Add cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to add a city</exception>
        /// <returns>Returns the status of the add activity. True if successfully added</returns>
        public bool AddCity(City city)
        {
            bool flag = true;
            string query = "INSERT INTO Cities (CityName, StateId) VALUES ('" + city.Name + "','" + city.StateInfo.StateId + "')";// StateId Must Be Sent

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    if ((int)ExecuteQueryScalar(db, "select count(*) from cities where CityName = '" + city.Name + "' and StateId=" + city.StateInfo.StateId) > 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        ExecuteQuery(db, query);
                        flag = true;
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to add city", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to add city", ex);
            }

            return flag;
        }
        #endregion

        #region Method to update the existing cities to the database
        /// <summary>
        /// Update the existing cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to update a city</exception>
        /// <returns>Returns the status of update activity. True if it has been successfully updated</returns>
        public bool UpdateCity(City city)
        {
            bool flag = true;
            string query = "UPDATE    Cities SET   CityName ='" + city.Name + "' Where CityId=" + city.CityId + "";

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    if ((int)ExecuteQueryScalar(db, "select count(*) from cities where CityId<>" + city.CityId + " and (CityName='" + city.Name + "' and StateId=" + city.StateInfo.StateId + ")") > 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        ExecuteQuery(db, query);
                        flag = true;
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to update the city", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to update the city", ex);
            }

            return flag;
        }
        #endregion
    }
}
