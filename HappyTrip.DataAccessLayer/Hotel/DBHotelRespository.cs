using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using System.Data;
using System.Data.SqlClient;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTrip.DataAccessLayer.Hotel
{
    /// <summary>
    /// Class to represent all the database related operations for hotel and rooms
    /// </summary>
    partial class DBHotelRespository :DAO, IHotelRepository
    {
        DataSet hotelDS = null;
        IDbConnection conn = null;
        IDbCommand cmd = null;
        IDbDataAdapter dataAdapter = null;

		#region Method to retrive Hotel types
		/// <summary>
		/// Method to retrieve Hotel types
		/// </summary>
		/// <returns>A valid dataset containing the hotel types</returns>
		public DataSet GetHotelTypes()
		{
            try
            {
                hotelDS = new DataSet("HotelsTypes");
                hotelDS = ExecuteQueryDataSet("select * from roomtypes");
                
                return hotelDS;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotel types", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotel types", e);
            }
		}
		#endregion

        /// <summary>
        /// Method to get hotel information for a given hotel id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>A DataSet with Hotel Information for a given hotel id</returns>
		public DataSet GetHotelById(long hotelId)
		{
            try
            {
                hotelDS = new DataSet("Hotels");

                using (IDbConnection conn = GetConnection())
                {
                    hotelDS = ExecuteQueryDataSet(conn, "select * from hotels where hotelid = @hotelid",
                        new SqlParameter() { ParameterName = "@hotelid", DbType = DbType.Int32, Value = hotelId }
                    );
                }

                return hotelDS;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotel for a given hotel id", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotel for a given hotel id", e);
            }
		}

        /// <summary>
        /// Method to get all hotels for a given city
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns>DataSet with all the hotels information</returns>
        public System.Data.DataSet GetHotelsByCity(int cityID)
        {
            try
            {
                hotelDS = new DataSet("Hotels");

                using (IDbConnection conn = GetConnection())
                {
                    hotelDS = ExecuteQueryDataSet(conn, "select * from hotels where cityid = @cityid",
                        new SqlParameter() { ParameterName = "@cityid", DbType = DbType.Int32, Value = cityID }
                    );
                }

                return hotelDS;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotels for a given city", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotel for a given city", e);
            }
        }
        

        /// <summary>
        /// Returns all hotel information from database
        /// </summary>
        /// <returns>DataSet with all hotels information from the database</returns>
        public DataSet GetAllHotels()
        {
            try
            {
                hotelDS = new DataSet("Hotels");

                using (IDbConnection conn = GetConnection())
                {
                    hotelDS = ExecuteQueryDataSet("SELECT * FROM HOTELS");
                }

                return hotelDS;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotels", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotels", e);
            }
        }


        /// <summary>
        /// Returns all hotel information from database
        /// </summary>
        /// <returns>DataSet with all hotels information</returns>
        public DataSet GetAllHotelsInfo()
        {
            try
            {
                hotelDS = new DataSet("Hotels");

                using (IDbConnection conn = GetConnection())
                {
                    hotelDS = ExecuteStoredProcedureDataSet("GetHotels");
                }

                return hotelDS;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotels info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotels info", e);
            }
        }

        /// <summary>
        /// For Update operations
        /// </summary>
        /// <param name="hotelDS"></param>
        /// <returns>Status of the edit operation on a hotel</returns>
        public bool EditHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel)
        {
            bool isUpdated = true;

            try
            {
                DataSet hotelDS = this.GetHotelById(hotel.HotelId);

                DataRow row = hotelDS.Tables[0].Rows[0];
                row["HotelId"] = hotel.HotelId;
                row["HotelName"] = hotel.HotelName;
                row["Address"] = hotel.Address;
                row["BriefNote"] = hotel.BriefNote;
                row["CityId"] = hotel.CityID;
                row["PhotoURL"] = hotel.PhotoUrl;
                row["ContactNo"] = hotel.ContactNo;
                row["EMail"] = hotel.Email;
                row["Pincode"] = hotel.Pincode;
                row["StarRanking"] = hotel.StarRanking;
                row["WebsiteURL"] = hotel.WebsiteURL;

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter as SqlDataAdapter);
                dataAdapter.Update(hotelDS);
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to edit hotel info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to edit hotel info", e);
            }

            return isUpdated;
        }

       
        /// <summary>
        /// Inserts hotel information into database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status of the insert operation of the hotel</returns>
        public bool SaveHotel(Model.Entities.Hotel.Hotel hotel)
        {
            bool isSaved = true;
            try
            {
                DataSet hotelDS = this.GetAllHotels();

                DataColumn[] pkColumn = new DataColumn[1];
                pkColumn[0] = hotelDS.Tables[0].Columns["HotelId"];
                hotelDS.Tables[0].PrimaryKey = pkColumn;

                DataRow row = hotelDS.Tables[0].NewRow();
                row["HotelId"] = hotel.HotelId;
                row["HotelName"] = hotel.HotelName;
				row["Address"] = hotel.Address;
				row["BriefNote"] = hotel.BriefNote;
				row["CityId"] = hotel.CityID;
                row["PhotoURL"] = hotel.PhotoUrl;
				row["ContactNo"] = hotel.ContactNo;
				row["EMail"] = hotel.Email;
				row["Pincode"] = hotel.Pincode;
				row["StarRanking"] = hotel.StarRanking;
				row["WebsiteURL"] = hotel.WebsiteURL;

                hotelDS.Tables[0].Rows.Add(row);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter as SqlDataAdapter);
                dataAdapter.Update(hotelDS);
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to insert hotel info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to insert hotel info", e);
            }

            return isSaved;

        }

        /// <summary>
        /// Deletes hotel information from database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status of the delete operation of a hotel</returns>
        public bool DeleteHotel(Model.Entities.Hotel.Hotel hotel)
        {
            bool isDeleted = true;
            try
            {
                DataSet hotelDS = this.GetAllHotels();
                DataColumn[] pkColumn = new DataColumn[1];
                pkColumn[0] = hotelDS.Tables[0].Columns["HotelId"];
                hotelDS.Tables[0].PrimaryKey = pkColumn;
                hotelDS.Tables[0].Rows.Find(hotel.HotelId).Delete();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter as SqlDataAdapter);
                dataAdapter.Update(hotelDS);
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to delete hotel info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to delete hotel info", e);
            }

            return isDeleted;

        }

        /// <summary>
        /// Returns RoomType information as DataSet
        /// </summary>
        /// <returns>DataSet with all RoomTypes information</returns>
        public DataSet GetRoomTypes()
        {
            try
            {
                DataSet roomTypesDS = new DataSet("RoomTypes");
                conn = this.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ROOMTYPES";
                cmd.CommandType = CommandType.Text;
                
                dataAdapter = new SqlDataAdapter(cmd as SqlCommand);
                dataAdapter.Fill(roomTypesDS);
                return roomTypesDS; ;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve rooms info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve rooms info", e);
            }
        }

        /// <summary>
        /// Saves Room types into database
        /// </summary>
        /// <param name="roomTypesDS"></param>
        /// <returns>Status of the update operation</returns>
        public bool SaveRoomTypes(DataSet roomTypesDS)
        {
            bool isUpdated = true;
            try
            {
                conn = this.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ROOMTYPES";
                cmd.CommandType = CommandType.Text;

                dataAdapter = new SqlDataAdapter(cmd as SqlCommand);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter as SqlDataAdapter);
                dataAdapter.Update(roomTypesDS);
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to save room types", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to save room types", e);
            }

            return isUpdated;
        }

        /// <summary>
        /// Add Rooms for a hotel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="roomTypeID"></param>
        /// <param name="costPerDay"></param>
        /// <param name="noOfRooms"></param>
        /// <returns>Status of the insert operation</returns>
        public bool AddRoomsForHotel(int hotelID, int roomTypeID, float costPerDay, int noOfRooms)
        {
            bool isInserted = true;
            try
            {
                conn = this.GetConnection();
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO HOTELROOMS VALUES(@HotelId,@TypeId,@CostPerDay,@NoOfRooms)";
                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@HotelId";
                p1.Value = hotelID;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@TypeId";
                p2.Value = roomTypeID;
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@CostPerDay";
                p3.Value = costPerDay;
                cmd.Parameters.Add(p3);

                IDataParameter p4 = cmd.CreateParameter();
                p4.ParameterName = "@NoOfRooms";
                p4.Value = noOfRooms;
                cmd.Parameters.Add(p4);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to insert hotel info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to insert hotel info", e);
            }
            finally
            {
                conn.Close();
            }

            return isInserted;
        }

        /// <summary>
        /// Method to get rooms for a given hotel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns>DataSet with rooms for a hotel</returns>
        public DataSet GetHotelRooms(int hotelID)
        {
            try
            {
                DataSet hotelRoomsDS = new DataSet("HotelRooms");
                conn = this.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT h.HotelId, r.TypeId,r.Title, h.CostPerDay, h.NoOfRooms FROM HOTELROOMS h, RoomTypes r WHERE h.HOTELID = @HotelID and h.typeid = r.typeid";
                cmd.CommandType = CommandType.Text;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@HotelID";
                p1.Value = hotelID;
                cmd.Parameters.Add(p1);

                dataAdapter = new SqlDataAdapter(cmd as SqlCommand);
                dataAdapter.Fill(hotelRoomsDS);
                return hotelRoomsDS; ;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to retrieve hotel rooms info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to retrieve hotel rooms info", e);
            }
        }

        /// <summary>
        /// Method to edit hotel rooms for a given hotel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns>DataSet with rooms for a hotel</returns>
        public bool EditHotelRooms(HotelRoom hotelRoom, int hotelId)
        {
            try
            {
                
                conn = this.GetConnection();
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE HOTELROOMS SET CostPerDay = @CostPerDay, NoOfRooms = @NoOfRooms WHERE HotelId = @HotelId AND TypeId = @TypeId";
                cmd.CommandType = CommandType.Text;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@CostPerDay";
                p1.Value = hotelRoom.CostPerDay;
                cmd.Parameters.Add(p1);


                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@NoOfRooms";
                p2.Value = hotelRoom.NoOfRooms;
                cmd.Parameters.Add(p2);


                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@HotelId";
                p3.Value = hotelId;
                cmd.Parameters.Add(p3);

                IDataParameter p4 = cmd.CreateParameter();
                p4.ParameterName = "@TypeId";
                p4.Value = hotelRoom.RoomType.TypeId;
                cmd.Parameters.Add(p4);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw new HotelDAOException("Unable to update hotel rooms info", ex);
            }
            catch (Exception e)
            {
                throw new HotelDAOException("Unable to update hotel rooms info", e);
            }
        }

		/// <summary>
		/// Method to update room types
		/// </summary>
		/// <param name="room">room type</param>
		/// <param name="typeID">type id</param>
		/// <returns>boolean</returns>
		public bool EditRoomTypes(RoomType room, int typeID)
		{
			try
			{
				conn = this.GetConnection();
				conn.Open();
				cmd = conn.CreateCommand();
				cmd.CommandText = "UPDATE ROOMTYPES SET Title = @Title, Description = @Description,Code=@Code,IsActive=@IsActive WHERE TypeId = @TypeId";
				cmd.CommandType = CommandType.Text;

				IDataParameter p1 = cmd.CreateParameter();
				p1.ParameterName = "@Title";
				p1.Value = room.Title;
				cmd.Parameters.Add(p1);

				IDataParameter p2 = cmd.CreateParameter();
				p2.ParameterName = "@Description";
				p2.Value = room.Description;
				cmd.Parameters.Add(p2);

				IDataParameter p3 = cmd.CreateParameter();
				p3.ParameterName = "@Code";
				p3.Value = room.Code;
				cmd.Parameters.Add(p3);

				IDataParameter p4 = cmd.CreateParameter();
				p4.ParameterName = "@IsActive";
				p4.Value = room.IsActive;
				cmd.Parameters.Add(p4);

				IDataParameter p5 = cmd.CreateParameter();
				p5.ParameterName = "@TypeId";
				p5.Value = room.TypeId;
				cmd.Parameters.Add(p5);

				cmd.ExecuteNonQuery();
				return true;
			}
			catch (SqlException ex)
			{
				throw new HotelDAOException("Unable to update  roomtype info", ex);
			}
			catch (Exception e)
			{
				throw new HotelDAOException("Unable to update roomtype info", e);
			}

		}
    }
}
