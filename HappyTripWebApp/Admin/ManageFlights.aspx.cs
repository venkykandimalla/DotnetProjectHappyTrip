using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class ManageFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsGet();
            }
        }

        private void ItemsGet()
        {
            // Read sample item info from XML document into a DataSet
            try
            {
                // Populate the repeater control with the Items DataSet
				IFlightManager flightManger = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
                PagedDataSource objPds = new PagedDataSource();
				List<Flight> flights = flightManger.GetFlights();
				if (flights.Count > 0)
				{
					objPds.DataSource = flights;
					objPds.AllowPaging = true;
					objPds.PageSize = 3;

                    ctlAdminMaster.BuildPager(objPds);

					dlFlight.DataSource = objPds;
					dlFlight.DataBind();
				}
				else
				{
					dlFlight.Visible = false;
				}
            }
            catch (FlightManagerException ex)
            {
                throw ex;
            }
        }

        protected void dlFlight_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Flight _flight = e.Item.DataItem as Flight;
                Repeater innerDataList = e.Item.FindControl("dlFlightClass") as Repeater;
                innerDataList.DataSource = _flight.GetClasses();
                innerDataList.DataBind();
            }
        }

        protected void commandPrevious_Click(object sender, EventArgs e)
        {
            // Reload control
            ItemsGet();
        }

        protected void commandNext_Click(object sender, EventArgs e)
        {
            // Reload control
            ItemsGet();
        }

        protected void dlFlight_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label b = (Label)e.Item.FindControl("lblflightid");
            Response.Redirect("EditFlight.aspx?flightid=" + b.Text);
        }
    }
}