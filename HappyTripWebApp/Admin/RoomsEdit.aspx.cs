using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTripWebApp.Admin
{
    public partial class RoomsEdit : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				HotelManager hm = new HotelManager();
				string typeid = Request.QueryString.Get("typeid");   // To update the roomtype depending 

				List<RoomType> roomtype = new List<RoomType>();
				roomtype = hm.GetRoomTypes();
				foreach (RoomType item in roomtype)
				{
					if (item.TypeId == int.Parse(typeid))
					{
						txtTitle.Text = item.Title;
						txtDescription.Text = item.Description;
						txtCode.Text = item.Code;
						chkIsActive.Checked = item.IsActive;
					}
				}
			}
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			try
			{
				HotelManager hm = new HotelManager();
				RoomType roomtype = new RoomType();
				string typeid = Request.QueryString.Get("typeid");
				roomtype.TypeId = Int32.Parse(typeid);
				roomtype.Title = txtTitle.Text;
				roomtype.Code = txtCode.Text;
				roomtype.Description = txtDescription.Text;
				roomtype.IsActive = chkIsActive.Checked;
				bool status = hm.EditRoomTypes(roomtype, Int32.Parse(typeid));
				if (status == true)
				{
					lblUpdateResult.ForeColor = System.Drawing.Color.Green;
					lblUpdateResult.Text = "Updated successfully";
				}
				else
				{
					lblUpdateResult.ForeColor = System.Drawing.Color.Red;
					lblUpdateResult.Text = "Updatation failed";
				}
			}
			catch (HotelManagerException ex)
			{
				lblUpdateResult.Text = ex.Message;
			}
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("Rooms.aspx");
		}
    }
}