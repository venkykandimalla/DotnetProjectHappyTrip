using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class ViewHotelRooms : System.Web.UI.Page
    {
		HotelManager hotelManager = null;
		ICityManager cityManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
			hotelManager = new HotelManager();
			cityManager = (ICityManager)BusinessObjectManager.GetCityManager();

            if (!Page.IsPostBack)
            {
               
                dpCity.DataSource = cityManager.GetCities();
                dpCity.DataTextField = "Name";
                dpCity.DataValueField = "CityId";
                dpCity.DataBind();
                dpCity.Items.Insert(0,"--- Select City ---");
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string queryString = "?hotelID=" + dpHotel.SelectedValue + "&cityID=" + dpCity.SelectedValue + "&hotelName=" + dpHotel.SelectedItem.Text + "&cityName=" + dpCity.SelectedItem.Text;

            
            Response.Redirect("AddHotelRooms.aspx" + queryString);
        }

        protected void dpCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityID = int.Parse(dpCity.SelectedValue);
           
            dpHotel.DataSource = hotelManager.GetHotelsByCity(cityID);
            dpHotel.DataTextField = "HotelName";
            dpHotel.DataValueField = "HotelId";
            dpHotel.DataBind();
            dpHotel.Items.Insert(0, "--- Select Hotel ---");
        }

        protected void dpHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hotelID = int.Parse(dpHotel.SelectedValue);
            grdRoom.DataSource = hotelManager.GetHotelRooms(hotelID);
            grdRoom.DataBind();
        }
    }
}