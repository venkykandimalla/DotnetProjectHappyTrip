using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using System.Data;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTripWebApp
{
    public partial class Rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ShowRoomTypesGridView();
            
        }

        private void ShowRoomTypesGridView()
        {
            HotelManager hotelManager = new HotelManager();
            RoomTypesGridView.DataSource = hotelManager.GetRoomTypes();
            RoomTypesGridView.DataBind();
        }

        /// <summary>
        /// Adds Room Type to the DataSet and updates the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    RoomType roomType = new RoomType();
        //    roomType.Title = txtClassName.Text;
        //    HotelManager hotelManager = new HotelManager();
        //    hotelManager.SaveRoomTypes(roomType);
        //    ShowRoomTypesGridView();

        //}

      
       
    }
}