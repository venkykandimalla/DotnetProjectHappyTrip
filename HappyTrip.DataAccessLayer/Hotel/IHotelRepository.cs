using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTrip.DataAccessLayer.Hotel
{
    public interface IHotelRepository
    {
        DataSet GetHotelsByCity(int cityID);
        DataSet GetHotelById(long hotelID);
        bool EditHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel);
        bool SaveHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel);
        bool DeleteHotel(HappyTrip.Model.Entities.Hotel.Hotel hotel);
        DataSet GetAllHotelsInfo();
        DataSet GetAllHotels();
        DataSet GetRoomTypes();
        DataSet GetHotelTypes();
        bool SaveRoomTypes(DataSet roomTypesDS);
        bool AddRoomsForHotel(int hotelID, int roomTypeID, float costPerDay, int noOfRooms);
        DataSet GetHotelRooms(int hotelID);
        bool EditHotelRooms(HotelRoom hotelRoom,int hotelId);
		bool EditRoomTypes(RoomType room, int typeID);
    }
}
