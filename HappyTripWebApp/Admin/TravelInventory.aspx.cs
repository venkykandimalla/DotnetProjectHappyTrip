using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using System.Data;

namespace HappyTripWebApp.Admin
{
	public partial class TravelInventory : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ctlAdminMaster.ErrorMessage = "";
			if (!IsPostBack)
			{
                try
                {
                    IScheduleManager scm = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");
                    DataSet dsTI = scm.GetTravelInventory();
                    gridTravelInventory.DataSource = dsTI.Tables[0];
                    gridTravelInventory.DataBind();

                    if (dsTI.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 3; i < dsTI.Tables.Count; ++i)
                        {
                            GridView gridClass = (GridView)gridTravelInventory.Rows[i - 3].FindControl("gridClassDetails");
                            gridClass.DataSource = dsTI.Tables[i];
                            gridClass.DataBind();
                            gridClass.Visible = true;
                        }
                    }
                    else
                    {
                        //ctlAdminMaster.ErrorMessage = "Sorry !!! No Bookings Done For The Day";
                    }
                }
                catch (ScheduleManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
                catch (Exception)
                {
                    ctlAdminMaster.ErrorMessage = "Sorry !!! Unable to get travel inventory";
                }
			}
		}
	}
}