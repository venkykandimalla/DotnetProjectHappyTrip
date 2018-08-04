using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;

namespace HappyTripWebApp.Admin
{
    public partial class AddHotelRooms : System.Web.UI.Page
    {
        HotelManager hotelManager = new HotelManager();
        int hotelID;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hotelID = int.Parse(Request.QueryString["hotelID"]);
                int cityID = int.Parse(Request.QueryString["cityID"]);
                string hotelName = Request.QueryString["hotelName"];
                string cityName = Request.QueryString["cityName"];
                lblCity.Text = cityName;
                lblHotelName.Text = hotelName;
                dpRoomType.DataSource = hotelManager.GetRoomTypes();
                dpRoomType.DataTextField = "Title";
                dpRoomType.DataValueField = "TypeId";
                dpRoomType.DataBind();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                hotelID = int.Parse(Request.QueryString["hotelID"]);
                int roomTypeID = int.Parse(dpRoomType.SelectedValue);
                float costPerDay = float.Parse(txtCostPerDay.Text);
                int noOfRooms = int.Parse(txtNoOfRooms.Text);
                hotelManager.AddRoomsForHotel(hotelID, roomTypeID, costPerDay, noOfRooms);
                lblError.Text = "Rooms added to the hotel successfully";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}