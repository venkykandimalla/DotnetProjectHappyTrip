using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTripWebApp.Admin;

namespace HappyTripWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ICityManager cityManager = (ICityManager)BusinessObjectManager.GetCityManager();
                    ddlCities.DataSource = cityManager.GetCities();
                    //ddlCities.DataMember = "CityId";
                    ddlCities.DataValueField = "CityId";
                    ddlCities.DataTextField = "Name";
                    ddlCities.DataBind();
                }
                catch (CityManagerException)
                {

                }
                catch (Exception)
                {
                }
            }
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            HotelManager hotelManager = new HotelManager();
            int cityID = int.Parse(ddlCities.SelectedValue);
            gvCities.DataSource = hotelManager.GetHotelsByCity(cityID);
            gvCities.DataBind();
        }
    }
}