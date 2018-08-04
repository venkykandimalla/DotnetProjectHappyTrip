using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using System.Data;

namespace HappyTripWebApp.Admin
{
    public partial class EditSchedule : System.Web.UI.Page
    {
        Schedule schedule;
        int total;
        string scheduleid;

        public void BindData()
        {

            scheduleid = Request.QueryString["scheduleid"].ToString();

			IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");
			schedule = scheduleManager.GetSchedule(int.Parse(scheduleid));

            FlightCost flightclass = new FlightCost();

            GridView1.DataSource = schedule.GetFlightCosts();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessageLocal.InnerText = "";

            if (!IsPostBack)
            {
                clear();
                txtDuration.Enabled = false;

                try
                {
                    scheduleid = Request.QueryString["scheduleid"].ToString();
                    IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");
                    schedule = scheduleManager.GetSchedule(int.Parse(scheduleid));

                    if (schedule == null)
                    {
                        Response.Redirect("~/Error.aspx");
                    }


                    //dpFromCity.SelectedValue = schedule.RouteInfo.FromCity.CityId.ToString();
                    //dpToCity.SelectedValue = schedule.RouteInfo.ToCity.CityId.ToString();

                    dpRoute.SelectedValue = schedule.RouteInfo.ID.ToString();
                    txtDuration.Text = schedule.DurationInMins.ToString();
                    TimeSpan dptime = schedule.DepartureTime;
                    dpDepartHours.SelectedValue = dptime.Hours.ToString();
                    dpDepartMins.SelectedValue = dptime.Minutes.ToString();
                    TimeSpan dpMinutes = schedule.ArrivalTime;
                    dpArrivalHours.SelectedValue = dpMinutes.Hours.ToString();
                    dpArrivalMins.SelectedValue = dpMinutes.Minutes.ToString();

                    dpAirlineName.SelectedValue = schedule.FlightInfo.AirlineForFlight.Id.ToString();
                    ListItem item = new ListItem(schedule.FlightInfo.Name.ToString(), schedule.FlightInfo.ID.ToString());
                    dpFlightName.Items.Add(item);
                    chkStatus.Checked = schedule.IsActive;

                    BindData();
                }
                catch (ScheduleManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
        }

        private void clear()
        {
            dpAirlineName.Items.Clear();
            dpFlightName.Items.Clear();
            dpDepartHours.Items.Clear();
            dpDepartMins.Items.Clear();
            dpArrivalHours.Items.Clear();
            dpArrivalMins.Items.Clear();

            for (int i = 0; i < 24; i++)
            {
                dpDepartHours.Items.Add(i.ToString());
                dpArrivalHours.Items.Add(i.ToString());
            }
            
            for (int i = 0; i <= 59; i+=10)
            {
                dpDepartMins.Items.Add(i.ToString());
                dpArrivalMins.Items.Add(i.ToString());
            }

            txtDuration.Enabled = false;

            txtDuration.Text = "";
            chkStatus.Checked = false;

            try
            {
                IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
                try
                {
                    List<Route> routes = routeManager.GetRoutes();
                    //dpRoute.Items.Add(new ListItem("Select Route...", "-1"));
                    foreach (Route route in routes)
                    {
                        string r = route.FromCity.Name + "  ==>  " + route.ToCity.Name;
                        string v = route.ID.ToString();
                        dpRoute.Items.Add(new ListItem(r, v));
                    }
                }
                catch (RouteManagerException e)
                {
                    ctlAdminMaster.ErrorMessage = e.Message;
                }

                AirLineManager objairline = new AirLineManager();
                List<Airline> airlines = objairline.GetAirLines();

                foreach (Airline a in airlines)
                {
                    ListItem item = new ListItem(a.Name, a.Id.ToString());
                    dpAirlineName.Items.Add(item);
                }
                dpAirlineName.DataBind();
            }
            catch (CityManagerException ex)
            {
                ctlAdminMaster.ErrorMessage = ex.Message;
            }
            catch (AirlineManagerException ex)
            {
                ctlAdminMaster.ErrorMessage = ex.Message;
            }
        }

        
        protected void dpAirlineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dpFlightName.Items.Clear();
				IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
				List<Flight> flightlist = flightManager.GetFlightsForAirLine(int.Parse(dpAirlineName.SelectedValue));

                foreach (Flight c in flightlist)
                {
                    ListItem item = new ListItem(c.Name, c.ID.ToString());
                    dpFlightName.Items.Add(item);
                }
                dpFlightName.DataBind();
            }
            catch (FlightManagerException exc)
            {
                ctlAdminMaster.ErrorMessage = exc.Message;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Schedule _flight = e.Item.DataItem as Schedule;
                Repeater innerDataList = e.Item.FindControl("dlFlightCost") as Repeater;
                innerDataList.DataSource = _flight.GetFlightCosts();
                innerDataList.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater c = e.Item.FindControl("RepeaterInner") as Repeater;
            
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            /*clear();
            txtDuration.Enabled = false;

            scheduleid = Request.QueryString["scheduleid"].ToString();

            try
            {
				IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");
				schedule = scheduleManager.GetSchedule(int.Parse(scheduleid));

                txtDuration.Text = schedule.DurationInMins.ToString();
                TimeSpan dptime = schedule.DepartureTime;
                dpDepartHours.SelectedValue = dptime.Hours.ToString();
                dpDepartMins.SelectedValue = dptime.Minutes.ToString();
                TimeSpan dpMinutes = schedule.ArrivalTime;
                dpArrivalHours.SelectedValue = dpMinutes.Hours.ToString();
                dpArrivalMins.SelectedValue = dpMinutes.Hours.ToString();

                dpAirlineName.SelectedValue = schedule.FlightInfo.AirlineForFlight.Id.ToString();
                ListItem item = new ListItem(schedule.FlightInfo.Name.ToString(), schedule.FlightInfo.ID.ToString());
                dpFlightName.Items.Add(item);
                chkStatus.Checked = schedule.IsActive;

            }
            catch (ScheduleManagerException ex)
            {
                throw ex;
            }*/
            Response.Redirect("~/Admin/Schedule_Flight.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Route route = null;
				IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");

                Schedule schedule = new Schedule();

                string rid = dpRoute.SelectedValue;
                IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
                try
                {
                    List<Route> routes = routeManager.GetRoutes();
                    foreach (Route r in routes)
                    {
                        if (r.ID == Convert.ToInt32(rid))
                        {
                            route = r;
                            break;
                        }
                    }

                }
                catch (RouteManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }

                schedule.RouteInfo = route;
				if (scheduleManager.GetRouteID(schedule) == 0)
                {
                    ctlAdminMaster.ErrorMessage = "Select the Existing Route";
                }
                else if (dpFlightName.SelectedItem == null)
                {
                    ctlAdminMaster.ErrorMessage = "Please select a Flight name";
                }
                else
                {
                    TimeSpan t1 = TimeSpan.Parse(dpArrivalHours.SelectedItem.ToString() + ":" + dpArrivalMins.SelectedItem.ToString());
                    TimeSpan t2 = TimeSpan.Parse(dpDepartHours.SelectedItem.ToString() + ":" + dpDepartMins.SelectedItem.ToString());
                    total = int.Parse((t1 - t2).TotalMinutes.ToString());
                    if (total == 0)
                    {
                        ctlAdminMaster.ErrorMessage = "The departure time and the arrival time cannot be same";
                        return;
                    }

                    if (total < 0)
                    {
                        total = (24 * 60) + total;
                    }
                    txtDuration.Text = total.ToString();


                    Flight flight = new Flight();
                    flight.ID = long.Parse(dpFlightName.SelectedItem.Value);
                    flight.Name = dpFlightName.SelectedItem.Text;

                    scheduleid = Request.QueryString["scheduleid"].ToString();
                    schedule.ID = long.Parse(scheduleid);
                    schedule.RouteInfo = route;
                    schedule.FlightInfo = flight;
                    schedule.DepartureTime = TimeSpan.Parse(dpDepartHours.SelectedItem.ToString() + ":" + dpDepartMins.SelectedItem.ToString());
                    schedule.ArrivalTime = TimeSpan.Parse(dpArrivalHours.SelectedItem.ToString() + ":" + dpArrivalMins.SelectedItem.ToString());
                    schedule.DurationInMins = total;
                    schedule.IsActive = chkStatus.Checked;

					scheduleManager.UpdateSchedule(schedule);
                    Response.Redirect("~/Admin/Schedule_Flight.aspx");
				}
            }
            catch (ScheduleManagerException ex)
            {
                ctlAdminMaster.ErrorMessage = ex.Message;
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                TextBox txtCost = (TextBox)row.FindControl("txtCost");
                decimal decCost = 0;

                if (!decimal.TryParse(txtCost.Text, out decCost))
                {
                    lblErrorMessageLocal.InnerText = "Cost should be a positive currency value";
                    txtCost.Focus();
                }
                else if (decCost <= 0)
                {
                    lblErrorMessageLocal.InnerText = "Cost should be a positive currency value";
                    txtCost.Focus();
                }
                else
                {

                    string txtClass = ((TextBox)row.FindControl("txtClass")).Text;
                    FlightCost _class = new FlightCost();

                    switch (txtClass)
                    {
                        case "Economy": _class.Class = TravelClass.Economy; break;
                        case "Business": _class.Class = TravelClass.Business; break;
                        default:
                            break;
                    }
                    _class.CostPerTicket = decCost;

					IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");
                    //Schedule schedule = new Schedule();
                    //Route route = null;

                    //string rid = dpRoute.SelectedValue;
                    //IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
                    //try
                    //{
                    //    List<Route> routes = routeManager.GetRoutes();
                    //    foreach (Route r in routes)
                    //    {
                    //        if (r.ID == Convert.ToInt32(rid))
                    //        {
                    //            route = r;
                    //            break;
                    //        }
                    //    }

                    //}
                    //catch (RouteManagerException ex)
                    //{
                    //    ctlAdminMaster.ErrorMessage = ex.Message;
                    //}

                    //Flight flight = new Flight();
                    //flight.ID = long.Parse(dpFlightName.SelectedItem.Value);
                    //flight.Name = dpFlightName.SelectedItem.Text;

                    scheduleid = Request.QueryString["scheduleid"].ToString();
                    //schedule.ID = long.Parse(scheduleid);
                    //schedule.RouteInfo = route;
                    //schedule.FlightInfo = flight;

                    scheduleManager.UpdateScheduleFlightCost(long.Parse(scheduleid), _class);

                    e.Cancel = true;
                    GridView1.EditIndex = -1;
                    BindData();

                    //lblErrorMessageLocal.InnerText = "Flight Cost Updated";
                }
            }
            catch (ScheduleManagerException ex)
            {
                lblErrorMessageLocal.InnerText = ex.Message;
            }
        }

        protected void dpArrivalMins_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan t1 = TimeSpan.Parse(dpArrivalHours.SelectedItem.ToString() + ":" + dpArrivalMins.SelectedItem.ToString());
                TimeSpan t2 = TimeSpan.Parse(dpDepartHours.SelectedItem.ToString() + ":" + dpDepartMins.SelectedItem.ToString());
                total = int.Parse((t1 - t2).TotalMinutes.ToString());

                if (total < 0)
                {
                    total = (24 * 60) + total;
                }
                txtDuration.Text = total.ToString();
            }
            catch (Exception)
            {
            }
        }
    }
}