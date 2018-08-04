using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HappyTrip.Model.BusinessLayer.Hotel;
using HappyTrip.Model.Entities.Hotel;
using HappyTrip.Model.BusinessLayer.Search;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class EditHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				SearchManagerFactory sf = SearchManagerFactory.GetInstance();
				List<City> cities = sf.Create().GetCities();
				
				foreach (City c in cities)
				{
					ListItem item = new ListItem(c.Name, c.CityId.ToString());
					dpCity.Items.Add(item);
				}

				long hotelId = Convert.ToInt64(Request.QueryString["hotelid"]);

				Hotel hotel = GetHotelByIdFromDataset(hotelId);
				if (hotel != null)
				{
					txtHotelId.Text = hotel.HotelId.ToString();
					txtHotelName.Text = hotel.HotelName;
					txtBrief.Text = hotel.BriefNote;
					txtAddress.Text = hotel.Address;

					for (int i = 0; i < cities.Count; ++i)
					{
						if (hotel.CityID == cities[i].CityId)
						{
							dpCity.SelectedIndex = i;
							break;
						}
					}

					dpStarRanking.SelectedIndex = hotel.StarRanking;
					txtPincode.Text = hotel.Pincode;
					txtContact.Text = hotel.ContactNo;
					txtEMail.Text = hotel.Email;
					txtPhoto.Text = hotel.PhotoUrl;
					txtWebsite.Text = hotel.WebsiteURL;
				}				
			}
        }

		protected Hotel GetHotelByIdFromDataset(long hotelid)
		{
			Hotel hotel = null;
			if (Session["HOTELDS"] != null)
			{
				DataSet hotelDS = (DataSet)Session["HOTELDS"];

				foreach (DataRow row in hotelDS.Tables[0].Rows)
				{
					if (Convert.ToInt64(row["HotelId"]) == hotelid)
					{
						hotel = new Hotel();
						hotel.HotelId = Convert.ToInt64(row["HotelId"]) ;		
						hotel.HotelName = row["HotelName"].ToString() ;		
						hotel.Address = row["Address"].ToString() ;		
						hotel.BriefNote = row["BriefNote"].ToString() ;		
						hotel.CityID = Convert.ToInt32(row["CityId"]) ;			
						hotel.PhotoUrl = row["PhotoURL"].ToString() ;		
						hotel.ContactNo = row["ContactNo"].ToString() ;		
						hotel.Email = row["EMail"].ToString() ;			
						hotel.Pincode = row["Pincode"].ToString() ;		
						hotel.StarRanking = Convert.ToInt32(row["StarRanking"]) ;
						hotel.WebsiteURL = row["WebsiteURL"].ToString() ;
						break;
					}
				}
			}
			return hotel;
		}

		protected void btnClear_Click(object sender, EventArgs e)
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

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			HotelManager hm = new HotelManager();
			Hotel hotel = new Hotel();
			ICityManager cm = (ICityManager)BusinessObjectManager.GetCityManager();
			hotel.HotelId = Convert.ToInt64(txtHotelId.Text);
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

			hm.UpdateHotel(hotel);

			ResetHotelDataSet();

			Response.Redirect("~/Admin/ViewHotel.aspx");
		}

		private void ResetHotelDataSet()
		{
			HotelManager hm = new HotelManager();
			DataSet hotelDS = hm.GetAllHotels();
			Session["HOTELDS"] = hotelDS;
		}
    }
}