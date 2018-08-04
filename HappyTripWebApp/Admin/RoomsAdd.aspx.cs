using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Hotel;
using HappyTrip.Model.BusinessLayer.Hotel;

namespace HappyTripWebApp.Admin
{
    public partial class RoomsAdd : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Save_Click_Click(object sender, EventArgs e)
		{
			RoomType roomtype = new RoomType();
			roomtype.Title = TxtTitle.Text;
			roomtype.Description = TxtDesc.Text;
			roomtype.Code = Txtcode.Text;
			roomtype.IsActive = CheckActive.Checked;
			HotelManager hotelmanager = new HotelManager();
			try
			{
				if (hotelmanager.SaveRoomTypes(roomtype))
				{
					Button2_Click(sender, e);
					lblErrors.ForeColor = System.Drawing.Color.Green;
					lblErrors.Text = "Hotel Type Added successfully";

				}
				else
				{
					lblErrors.ForeColor = System.Drawing.Color.Red;
					lblErrors.Text = "Hotel Type already exists";
				}
			}
			catch (HotelManagerException ex)
			{
				throw ex;
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Txtcode.Text = "";
			TxtDesc.Text = "";
			TxtTitle.Text = "";
			lblErrors.Text = "";
			CheckActive.Checked = false;
		}
    }
}