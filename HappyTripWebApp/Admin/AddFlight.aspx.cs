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
    public partial class AddFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                try
                {
                    ddlAirLine.Items.Add("None");
                    ddlAirLine.DataSource = new AirLineManager().GetAirLines();
                    ddlAirLine.DataTextField = "Name";
                    ddlAirLine.DataValueField = "Id";
                    ddlAirLine.DataBind();
                }             
                catch (AirlineManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }

                var travelClassvalues = Enum.GetValues(typeof(TravelClass)).Cast<TravelClass>();
                dlClass.DataSource = travelClassvalues;
                dlClass.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Home.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    ctlAdminMaster.ErrorMessage = "Flight Name Can't be Empty";
                    txtName.Focus();
                }
                else if (ddlAirLine.Text.Equals("None") == true)
                {
                    ctlAdminMaster.ErrorMessage = "Select Airline Name";
                    ddlAirLine.Focus();
                }
                else
                {
                    string flightName = txtName.Text;
                    int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
                    string airlinename = ddlAirLine.SelectedItem.Text;
                    Flight _flight = new Flight() { Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };
                    IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
                    bool blnSeatsValid = true;

                    try
                    {
                        foreach (RepeaterItem item in dlClass.Items)
                        {
                            TextBox txtNoOfSeats = (TextBox)item.FindControl("txtNoOfSeats");
                            Label lblClass = (Label)item.FindControl("lblClass");
                            int intNumberOfSeats = 0;

                            if ((!int.TryParse(txtNoOfSeats.Text, out intNumberOfSeats)) || (intNumberOfSeats <= 0))
                            {
                                txtNoOfSeats.Focus();
                                ctlAdminMaster.ErrorMessage = "Seat count should be a positive number";
                                blnSeatsValid = false;
                                break;
                            }
                            else
                            {
                                if (txtNoOfSeats != null)
                                {
                                    TravelClass travelClass = (TravelClass)Enum.Parse(typeof(TravelClass), lblClass.Text.Trim());
                                    FlightClass _class = new FlightClass() { ClassInfo = travelClass, NoOfSeats = intNumberOfSeats };
                                    _flight.AddClass(_class);
                                }
                            }
                        }
                        if (blnSeatsValid)
                        {
                            if (flightManager.AddFlight(_flight) == false)
                            {
                                ctlAdminMaster.ErrorMessage = "Flight Name already exists";
                            }
                            else
                            {
                                ctlAdminMaster.ErrorMessage = "Flight Added Successfully";
                            }
                        }
                    }
                    catch (FlightManagerException exc)
                    {
                        ctlAdminMaster.ErrorMessage = exc.Message;
                    }
                }
            }
        }
    }
}