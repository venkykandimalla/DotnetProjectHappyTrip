using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Hotel;
using System.Data;
using HappyTrip.Model.BusinessLayer.Log;
using HappyTrip.Model.Entities.Log;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTrip.Model.BusinessLayer.Hotel
{
    /// <summary>
    /// Manages the hotel information
    /// </summary>
    public class HotelManager
    {
        private IHotelRepository hotelRepository = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotelManager()
        {
            hotelRepository = HotelRepositoryFactory.GetInstance().Create();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="hotelRepository"></param>
        public HotelManager(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        /// <summary>
        /// Gets hotels for a given city
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns>DataSet with hotels information</returns>
        public DataSet GetHotelsByCity(int cityID)
        {
            try
            {
                return hotelRepository.GetHotelsByCity(cityID);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to get hotels for a city", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to get hotels for a city", ex);
            }
        }

		/// <summary>
		/// Gets hotels for a given Id
		/// </summary>
		/// <param name="hotelId"></param>
		/// <returns>DataSet with hotels information</returns>
		public DataSet GetHotelsById(long hotelId)
		{
			try
			{
				return hotelRepository.GetHotelById(hotelId);
			}
			catch (HotelDAOException ex)
			{
				throw new HotelManagerException("Unable to get hotels by Id", ex);
			}
			catch (Exception ex)
			{
				throw new HotelManagerException("Unable to get hotels by Id", ex);
			}
		}

        /// <summary>
        /// Gets all the hotels information
        /// </summary>
        /// <returns>DataSet with hotels information</returns>
        public DataSet GetAllHotelsInfo()
        {
            try
            {
                return hotelRepository.GetAllHotelsInfo();
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to get all hotels info", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to get all hotels info", ex);
            }
        }

        /// <summary>
        /// Updates the hotel information
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status of the update</returns>
        public bool UpdateHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel)
        {
            try
            {
                return hotelRepository.EditHotel(hotel);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to update hotel information", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to update hotel information", ex);
            }
        }

        /// <summary>
        /// Inserts a given hotel information into the database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status of the insert operation</returns>
        public bool SaveHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel)
        {
            try
            {
                ValidateHotelInfo(hotel);
                return hotelRepository.SaveHotel(hotel);
            }
            catch (HotelDAOException ex)
            {
                LogMessage message = new LogMessage();
                message.Message = ex.Message;
                message.ClassName = "HotelManager.cs";
                message.MethodName = "SaveHotel(Hotel hotel)";
                message.MessageDateTime = DateTime.Now;
                LogFactory.Create().WriteToLog(message);

                throw new HotelManagerException("Unable to insert hotel information", ex);
            }
            catch (Exception ex)
            {
                LogMessage message = new LogMessage();
                message.Message = ex.Message;
                message.ClassName = "HotelManager.cs";
                message.MethodName = "SaveHotel(Hotel hotel)";
                message.MessageDateTime = DateTime.Now;
                LogFactory.Create().WriteToLog(message);

                throw new HotelManagerException("Unable to insert hotel information", ex);
            }
        }

		private void ValidateHotelInfo(HappyTrip.Model.Entities.Hotel.Hotel hotel)
		{

		}

        /// <summary>
        /// Deletes the hotel information from the database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status of the delete operation</returns>
        public bool DeleteHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel)
        {
            try
            {
                return hotelRepository.DeleteHotel(hotel);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to delete hotel information", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to delete hotel information", ex);
            }
        }

        /// <summary>
        /// Gets all hotels from the database
        /// </summary>
        /// <returns>DataSet with all hotels information</returns>
        public DataSet GetAllHotels()
        {
            try
            {
                return hotelRepository.GetAllHotels();
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to get hotels information", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to get hotels information", ex);
            }
        }

        /// <summary>
        /// Gets all the different room types
        /// </summary>
        /// <returns>DataSet with all room types in the database</returns>
        public List<RoomType> GetRoomTypes()
        {
            try
            {
                List<RoomType> roomTypes = new List<RoomType>();
                DataSet roomTypeDS = hotelRepository.GetRoomTypes();
                
                foreach (DataRow row in roomTypeDS.Tables[0].Rows)
                {
                    RoomType roomType = new RoomType();
                    roomType.TypeId = (int)row["TypeId"];
                    roomType.Title = row["Title"].ToString();
                    roomType.Code = row["Code"].ToString();
                    roomType.Description = row["Description"].ToString();
                    roomType.IsActive = bool.Parse(row["IsActive"].ToString());
                    roomTypes.Add(roomType);
                }
                return roomTypes.ToList<RoomType>();
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to get room types information", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to get room types information", ex);
            }
        }

        /// <summary>
        /// Inserts room types into the database
        /// </summary>
        /// <param name="roomTypesDS"></param>
        /// <returns>Status of the insert operation</returns>
        public bool SaveRoomTypes(RoomType roomType)
        {
            try
            {
                DataSet roomTypeDS = hotelRepository.GetRoomTypes();
                DataRow row = roomTypeDS.Tables[0].NewRow();
                row["TypeId"] = roomType.TypeId;
                row["Title"] = roomType.Title;
                row["Description"] = roomType.Description;
                row["Code"] = roomType.Code;
                row["IsActive"] = roomType.IsActive;
                roomTypeDS.Tables[0].Rows.Add(row);
                return hotelRepository.SaveRoomTypes(roomTypeDS);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to insert room types information", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to insert room types information", ex);
            }
        }

        /// <summary>
        /// Adds rooms for a given hotel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="roomTypeID"></param>
        /// <param name="costPerDay"></param>
        /// <param name="noOfRooms"></param>
        /// <returns>Status of the insert operation</returns>
        public bool AddRoomsForHotel(int hotelID, int roomTypeID, float costPerDay, int noOfRooms)
        {
            try
            {
                return hotelRepository.AddRoomsForHotel(hotelID, roomTypeID, costPerDay, noOfRooms);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to insert room information for a hotel", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to insert room information for a hotel", ex);
            }
        }

        /// <summary>
        /// Gets rooms for a given hotel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns>DataSet with hotel rooms information</returns>
        public DataSet GetHotelRooms(int hotelID)
        {
            try
            {
                return hotelRepository.GetHotelRooms(hotelID);
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to get room information for a hotel", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to get room information for a hotel", ex);
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
                hotelRepository.EditHotelRooms(hotelRoom, hotelId);
                return true;
            }
            catch (HotelDAOException ex)
            {
                throw new HotelManagerException("Unable to update room information for a hotel", ex);
            }
            catch (Exception ex)
            {
                throw new HotelManagerException("Unable to update room information for a hotel", ex);
            }
        }

		/// <summary>
		/// Method to edit the room type information for given Room
		/// </summary>
		/// <param name="room"></param>
		/// <param name="typeid"></param>
		/// <returns></returns>
		public bool EditRoomTypes(RoomType room, int typeid)
		{
			try
			{
				hotelRepository.EditRoomTypes(room, typeid);
				return true;
			}
			catch (HotelDAOException ex)
			{
				throw new HotelManagerException("Unable to update room type information", ex);
			}
			catch (Exception ex)
			{
				throw new HotelManagerException("Unable to update room type information", ex);
			}
		}
    }
}
