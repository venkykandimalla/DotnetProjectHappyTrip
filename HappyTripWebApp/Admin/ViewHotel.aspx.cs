using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using System.Data;

namespace HappyTripWebApp.Admin
{
    public partial class ViewHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!Page.IsPostBack)
			{
				HotelManager hotelManager = new HotelManager();
				DataSet hotelDS = hotelManager.GetAllHotels();

				if (Session["HOTELDS"] == null)
				{
					Session["HOTELDS"] = hotelDS;
				}

				HotelGridView.AutoGenerateColumns = true;
				HotelGridView.DataSource = hotelDS;
				HotelGridView.DataBind();
			}
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server
            Exception exc = Server.GetLastError();

           
           
                // Pass the error on to the Generic Error page
                Server.Transfer("~/GenericErrorPage.aspx?err=" + exc.Message, true);
        }
    


        protected void HotelGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hotelID = int.Parse(HotelGridView.SelectedRow.Cells[1].Text);
            int cityID = int.Parse(HotelGridView.SelectedRow.Cells[10].Text);
            string hotelName = HotelGridView.SelectedRow.Cells[2].Text;
            string cityName = HotelGridView.SelectedRow.Cells[11].Text;
            string queryString = "?hotelID=" + hotelID + "&cityID=" + cityID + "&hotelName=" + hotelName + "&cityName=" + cityName;
            Response.Redirect("AddHotelRooms.aspx" + queryString);
        }
    

		protected void HotelGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			HotelGridView.PageIndex = e.NewPageIndex;
			if (Session["HOTELDS"] != null)
			{
				DataSet dsHotel = (DataSet)Session["HOTELDS"];
				HotelGridView.DataSource = dsHotel;
				HotelGridView.DataBind();
			}
		}
    }
}
