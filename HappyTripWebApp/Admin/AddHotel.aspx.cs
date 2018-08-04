using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer;
using HappyTrip.Model.BusinessLayer.Search;
using HappyTrip.Model.BusinessLayer.Hotel;
using HappyTrip.Model.Entities.Hotel;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class AddHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				SearchManagerFactory sf = SearchManagerFactory.GetInstance();
				List<City> cities = sf.Create().GetCities();
				dpCity.Items.Add("None");
				foreach (City c in cities)
				{
					ListItem item = new ListItem(c.Name, c.CityId.ToString());
					dpCity.Items.Add(item);
				}
				dpCity.DataBind();
			}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                HotelManager hm = new HotelManager();
                Hotel hotel = new Hotel();
				ICityManager cm = (ICityManager)BusinessObjectManager.GetCityManager();

                hotel.HotelName = txtHotelName.Text;
                hotel.Address = txtAddress.Text;
                hotel.City = cm.GetCityById(Convert.ToInt64(dpCity.SelectedValue));
                hotel.CityID = Convert.ToInt32(dpCity.SelectedValue);
                hotel.BriefNote = txtBrief.Text;
                hotel.Email = txtEMail.Text;
                hotel.ContactNo = txtContact.Text;
                hotel.Pincode = txtPincode.Text;
                hotel.StarRanking = Convert.ToInt32(dpStarRanking.SelectedValue);
                hotel.PhotoUrl = txtPhoto.Text;
                hotel.WebsiteURL = txtWebsite.Text;

                hm.SaveHotel(hotel);

				//Resetting the session to invalidate the hotels
				Session["HOTELDS"] = null;

                Response.Redirect("~/Admin/ViewHotel.aspx");
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }
        }

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			foreach (Control c in this.Controls)
			{
				if (c is TextBox)
				{
					TextBox t = (TextBox)c;
					t.Text = "";
				}
			}

			dpCity.SelectedIndex = -1;
			dpStarRanking.SelectedIndex = -1;
		}
	}
}