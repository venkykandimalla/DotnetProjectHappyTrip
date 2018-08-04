using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using System.Data;
using System.Data.SqlClient;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to routes operations for fetch,add,update
	/// </summary>
	class RouteDAO : DAO, IRouteDAO
	{

		#region Making the constructor public
		public RouteDAO()
		{

		}
		#endregion

        IDbConnection db;
        IDbCommand cmd = null;

		#region Method to get the routes from the database
		/// <summary>
		/// Gets the routes from the database
		/// </summary>
		/// <returns>DataSet with all Routes</returns>
		public System.Data.DataSet GetRoutes()
		{
			DataSet dataset = new DataSet();
			try
			{
                using (IDbConnection conn = GetConnection())
                {
                    using (IDataReader reader = ExecuteStoredProcedureResults(conn, "GetRoutes"))
                    {
                        List<Route> lstroute = new List<Route>();
                        DataTable routedt = dataset.Tables.Add("Routes");

                        routedt.Columns.Add("RouteId", typeof(long));
                        routedt.Columns.Add("FromCityName", typeof(string));
                        routedt.Columns.Add("FromCityId", typeof(long));
                        routedt.Columns.Add("ToCityName", typeof(string));
                        routedt.Columns.Add("ToCityId", typeof(long));
                        routedt.Columns.Add("DistanceInKms", typeof(decimal));
                        routedt.Columns.Add("status", typeof(bool));
                        routedt.Columns.Add("FromStateId", typeof(long));
                        routedt.Columns.Add("FromStateName", typeof(string));
                        routedt.Columns.Add("ToStateId", typeof(long));
                        routedt.Columns.Add("ToStateName", typeof(string));

                        while (reader.Read())
                        {
                            DataRow rw = routedt.NewRow();
                            rw["RouteId"] = reader["RouteId"];
                            rw["FromCityName"] = reader["FromCityName"];
                            rw["FromCityId"] = reader["FromCityId"];
                            rw["ToCityName"] = reader["ToCityName"];
                            rw["ToCityId"] = reader["ToCityId"];
                            rw["DistanceInKms"] = reader["DistanceInKms"];
                            rw["status"] = reader["status"];
                            rw["FromStateId"] = reader["FromStateId"];
                            rw["FromStateName"] = reader["FromStateName"];
                            rw["ToStateId"] = reader["ToStateId"];
                            rw["ToStateName"] = reader["ToStateName"];

                            routedt.Rows.Add(rw);
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

		#region Method to add the routes to the database
		/// <summary>
		/// Add the routes to the database
		/// </summary>
		/// <parameter name="routeInfo"></parameter>
		/// <returns>Returns the number of rows affected by the insert</returns>
		public int AddRoute(Model.Entities.AirTravel.Route routeInfo)
		{
			try
			{
                return ExecuteStoredProcedure("InsertRoute",
                    new SqlParameter() { ParameterName = "@fromcityID", DbType = DbType.Int32, Value = routeInfo.FromCity.CityId },
                    new SqlParameter() { ParameterName = "@toCityID", DbType = DbType.Int32, Value = routeInfo.ToCity.CityId },
                    new SqlParameter() { ParameterName = "@dis", DbType = DbType.Decimal, Value = routeInfo.DistanceInKms },
                    new SqlParameter() { ParameterName = "@st", DbType = DbType.Boolean, Value = routeInfo.IsActive }
                );
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new RouteDAOException("Unable to add route");
			}
			catch (Exception)
			{
				throw new RouteDAOException("Unable to add route");
			}
		}
		#endregion

		#region Method to update the existing routes to the database
		/// <summary>
		/// Update the existing routes to the database
		/// </summary>
		/// <parameter name="routeInfo"></parameter>
		/// <returns>Returns the number of rows affected by the update</returns>
		public int UpdateRoute(Model.Entities.AirTravel.Route routeInfo)
		{
			try
			{
                return ExecuteStoredProcedure("UpdateRoutes",
                    new SqlParameter() { ParameterName = "@ID", DbType = DbType.Int64, Value = routeInfo.ID },
                    new SqlParameter() { ParameterName = "@DisInKms", DbType = DbType.Decimal, Value = routeInfo.DistanceInKms },
                    new SqlParameter() { ParameterName = "@Status", DbType = DbType.Boolean, Value = routeInfo.IsActive }
                );
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new RouteDAOException("Unable to update route");
			}
			catch (Exception)
			{
				throw new RouteDAOException("Unable to update route");
			}
		}
		#endregion

		#region Method to get the route id for a route from the database
		/// <summary>
		/// Gets the route id for a route from the database
		/// </summary>
        /// <parameter name="routeInfo"></parameter>
		/// <returns>Returns the route id for given route with city information</returns>
		public int GetRouteID(Route routeInfo)
		{
			try
			{
				int routeId = 0;

                using (IDbConnection conn = GetConnection())
                {
                    using (IDataReader Reader = ExecuteStoredProcedureResults(conn, "getRouteId",
                        new SqlParameter() { ParameterName = "@fromcity", DbType = DbType.Int64, Value = routeInfo.FromCity.CityId },
                        new SqlParameter() { ParameterName = "@tocity", DbType = DbType.Int64, Value = routeInfo.ToCity.CityId }
                    ))
                    {
                        if (Reader.Read())
                        { routeId = int.Parse(Reader["RouteId"].ToString()); }

                        return routeId;
                    }
                }
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new RouteDAOException("Unable to get route id");
			}
			catch (Exception)
			{
				throw new RouteDAOException("Unable to get route id");
			}
		}
		#endregion
	}
}
