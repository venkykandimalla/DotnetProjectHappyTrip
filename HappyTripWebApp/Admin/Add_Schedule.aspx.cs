using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTripWebApp.Admin
{
    public partial class Add_Schedule : System.Web.UI.Page
    {
        int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                clear();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //clear();
            Response.Redirect("~/Admin/home.aspx");
        }

        private void clear()
        {
            dpAirlineName.Items.Clear();
            dpFlightName.Items.Clear();
            dpDepartHours.Items.Clear();
            dpDepartMins.Items.Clear();
            dpArrivalHours.Items.Clear();
            dpArrivalMins.Items.Clear();

            dpDepartHours.Items.Add("None");
            dpArrivalHours.Items.Add("None");
            for (int i = 0; i < 24; i++)
            {
                dpDepartHours.Items.Add(i.ToString());
                dpArrivalHours.Items.Add(i.ToString());
            }

            //dpDepartMins.Items.Add("None");
            //dpArrivalMins.Items.Add("None");
            for (int i = 0; i <= 59; i+=10)
            {
                dpDepartMins.Items.Add(i.ToString());
                dpArrivalMins.Items.Add(i.ToString());
            }

            txtDuration.Enabled = false;

            txtDuration.Text = "";
            chkStatus.Checked = false;

            IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
            try
            {
                List<Route> routes = routeManager.GetRoutes();
                dpRoute.Items.Add(new ListItem("Select Route...", "-1"));
                foreach (Route route in routes)
                {
                    string r = route.FromCity.Name + " (" + route.FromCity.StateInfo.Name + ")" + "  ==>  " + route.ToCity.Name + " (" + route.ToCity.StateInfo.Name + ")";
                    string v = route.ID.ToString();
                    dpRoute.Items.Add(new ListItem(r, v));
                }
            }
            catch (RouteManagerException e)
            {
                ctlAdminMaster.ErrorMessage = e.Message;
            }


            IAirLineManager airlineManager = (IAirLineManager)AirTravelManagerFactory.Create("AirlineManager");
            try
            {
                List<Airline> airlines = airlineManager.GetAirLines();

                dpAirlineName.Items.Add("None");
                foreach (Airline c in airlines)
                {
                    ListItem item = new ListItem(c.Name, c.Id.ToString());
                    dpAirlineName.Items.Add(item);
                }
                dpAirlineName.DataBind();
            }
            catch (AirlineManagerException e)
            {
                ctlAdminMaster.ErrorMessage = e.Message;
            }

            ShowDefaultClasses();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            IScheduleManager scheduleManager = (IScheduleManager)AirTravelManagerFactory.Create("ScheduleManager");

            Schedule schedule = new Schedule();

            Route route = null;

            if (dpAirlineName.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Airline Name";
                dpAirlineName.Focus();
            }
            else if (dpFlightName.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Flight Name";
                dpFlightName.Focus();
            }
            else if (dpDepartHours.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Departure Hours";
                dpDepartHours.Focus();
            }
            else if (dpDepartMins.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Departure Minutes";
                dpDepartMins.Focus();
            }
            else if (dpArrivalHours.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Arrival Hours";
                dpArrivalHours.Focus();
            }
            else if (dpArrivalMins.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select Arrival Minutes";
                dpArrivalMins.Focus();
            }
            else
            {
                string rid = dpRoute.SelectedValue;
                if (rid.Equals("-1"))
                {
                    ctlAdminMaster.ErrorMessage = "Select a route";
                    return;
                }
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
                    //dpFromCity.Focus();
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

                    schedule.RouteInfo = route;
                    schedule.FlightInfo = flight;
                    schedule.DepartureTime = TimeSpan.Parse(dpDepartHours.SelectedItem.ToString() + ":" + dpDepartMins.SelectedItem.ToString());
                    schedule.ArrivalTime = TimeSpan.Parse(dpArrivalHours.SelectedItem.ToString() + ":" + dpArrivalMins.SelectedItem.ToString());
                    schedule.DurationInMins = total;
                    schedule.IsActive = chkStatus.Checked;

                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label lblclassname = (Label)item.FindControl("ClassName");
                        TextBox txtcost = (TextBox)item.FindControl("txtCostPerTicket");
                        decimal cost = 0;
                        try
                        {
                            cost = Convert.ToDecimal(txtcost.Text);
                        }
                        catch (FormatException)
                        {
                            ctlAdminMaster.ErrorMessage = "Cost should be a positive currency value";
                            txtcost.Focus();
                            return;
                        }
                        if (cost <= 0)
                        {
                            ctlAdminMaster.ErrorMessage = "Cost should be a positive currency value";
                            txtcost.Focus();
                            return;
                        }
                        else
                        {
                            if (txtcost != null || lblclassname != null)
                            {
                                string classname = lblclassname.Text;
                                string val = txtcost.Text;

                                FlightCost fc = new FlightCost();
                                fc.Class = (TravelClass)Enum.Parse(typeof(TravelClass), classname);
                                fc.CostPerTicket = decimal.Parse(txtcost.Text);

                                schedule.AddFlightCost(fc);
                            }

                        }
                    }

                    //Extracted from the loop preventing a potential exception
                    try
                    {

                        scheduleManager.AddSchedule(schedule);
                        ctlAdminMaster.ErrorMessage = "Schedule Added Successfully";
                        //Response.Redirect("~/Admin/Home.aspx");
                    }
                    catch (ScheduleManagerException ex)
                    {
                        ctlAdminMaster.ErrorMessage = ex.Message;
                    }
                }
            }
        }

        protected void dpAirlineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpAirlineName.Text.Equals("None") == false)
            {
                dpFlightName.Items.Clear();
                IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
                try
                {
                    List<Flight> flightlist = flightManager.GetFlightsForAirLine(int.Parse(dpAirlineName.SelectedValue));

                    dpFlightName.Items.Add("None");
                    foreach (Flight c in flightlist)
                    {
                        ListItem item = new ListItem(c.Name, c.ID.ToString());
                        dpFlightName.Items.Add(item);
                    }
                    dpFlightName.DataBind();
                }
                catch (FlightManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
            }
        }
        protected void dpFlightName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpFlightName.Text.Equals("None") == false)
            {
                IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
                try
                {
                    Flight flight = flightManager.GetFlight(int.Parse(dpFlightName.SelectedValue));
                    List<TravelClass> flightClasses = new List<TravelClass>();

                    foreach (FlightClass fc in flight.GetClasses())
                    {
                        flightClasses.Add(fc.ClassInfo);
                    }

                    Repeater1.DataSource = flightClasses;
                    Repeater1.DataBind();
                }
                catch (FlightManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
            }
            else
            {
                ShowDefaultClasses();
            }
        }

        protected void dpArrivalMins_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan t1 = TimeSpan.Parse(dpArrivalHours.SelectedItem.ToString() + ":" + dpArrivalMins.SelectedItem.ToString());
                TimeSpan t2 = TimeSpan.Parse(dpDepartHours.SelectedItem.ToString() + ":" + dpDepartMins.SelectedItem.ToString());
                total = int.Parse((t1 - t2).TotalMinutes.ToString());
                if (total == 0)
                {
                    ctlAdminMaster.ErrorMessage = "The departure time and the arrival time cannot be same";
                    txtDuration.Text = "0";
                    return;
                }
                else
                {
                    ctlAdminMaster.ErrorMessage = "";
                }
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

        private void ShowDefaultClasses()
        {
            var travelClassvalues = Enum.GetValues(typeof(TravelClass)).Cast<TravelClass>();
            Repeater1.DataSource = travelClassvalues;
            Repeater1.DataBind();
        }
    }
}