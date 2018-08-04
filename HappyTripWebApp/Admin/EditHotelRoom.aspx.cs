using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;
using System.Data;
using HappyTrip.Model.Entities.Hotel;

namespace HappyTripWebApp.Admin
{
    public partial class EditHotelRoom : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				HotelManager hm = new HotelManager();
				try
				{
					string hotelId = Request.QueryString["hotelid"];
					string typeId = Request.QueryString["typeid"];
					DataSet ds = hm.GetHotelsById(Convert.ToInt64(hotelId));

					txtHotelName.Text = ds.Tables[0].Rows[0]["HotelName"].ToString();
					ds = hm.GetHotelRooms(Convert.ToInt32(hotelId));

					foreach (DataRow item in ds.Tables[0].Rows)
					{
						if (item["TypeId"].ToString().Equals(typeId))
						{
							txtTypeId.Text = item[1].ToString();
							txtTitle.Text = item[2].ToString();
							txtCostPerDay.Text = item[3].ToString();
							txtNoOfRooms.Text = item[4].ToString();
						}
					}

				}
				catch (HotelManagerException ex)
				{
					throw ex;
				}

			}
		}

		protected void btnEdit_Click(object sender, EventArgs e)
		{
			HotelManager hm = new HotelManager();
			HotelRoom hotelRm = new HotelRoom();
			hotelRm.RoomType = new RoomType();
			
			int hotelId = Int32.Parse(Request.QueryString["hotelid"]);
			hotelRm.RoomType.Title = txtTitle.Text;
			hotelRm.RoomType.TypeId = Int32.Parse(txtTypeId.Text);
			hotelRm.CostPerDay = Convert.ToSingle(txtCostPerDay.Text);
			hotelRm.NoOfRooms = Int32.Parse(txtNoOfRooms.Text);
			bool edit = hm.EditHotelRooms(hotelRm, hotelId);
			if (edit == true)
				updtmsg.Text = "Updated successfully";
			else
				updtmsg.Text = "Update not successful";

			txtTypeId.Text = txtTitle.Text = txtCostPerDay.Text = txtNoOfRooms.Text = string.Empty;
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("EditHotelRoom.aspx");
		}
    }
}