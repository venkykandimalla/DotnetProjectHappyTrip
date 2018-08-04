using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class EditFlight : System.Web.UI.Page
    {
        Flight flight;
        string flightid;

        public void BindData()
        {
            try
            {
                ddlAirLine.DataSource = new AirLineManager().GetAirLines();
                ddlAirLine.DataTextField = "Name";
                ddlAirLine.DataValueField = "Id";
                ddlAirLine.DataBind();

                flightid = Request.QueryString["flightid"].ToString();

                IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");
                flight = flightManager.GetFlight(int.Parse(flightid));

                FlightClass flightclass = new FlightClass();


                txtName.Text = flight.Name;
				hdnName.Value = flight.Name;
                ddlAirLine.SelectedValue = flight.AirlineForFlight.Id.ToString();
                GridView1.DataSource = flight.GetClasses();
                GridView1.DataBind();

            }
            catch (FlightManagerException ex)
            {
                Response.Redirect("~/Error.aspx");
            }
            catch (AirlineManagerException exc2)
            {
                Response.Redirect("~/Error.aspx");
            }
            catch (NullReferenceException ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ctlAdminMaster.ErrorMessage = "Flight Name Can't be Empty";
                txtName.Focus();
            }
            else
            {
				if (!hdnName.Value.Equals(txtName.Text))
				{
					string flightName = txtName.Text;
					int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
					string airlinename = ddlAirLine.SelectedItem.Text;
					flightid = Request.QueryString["flightid"].ToString();
					Flight _flight = new Flight() { ID = int.Parse(flightid), Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };
					IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");

					if (flightManager.UpdateFlight(_flight) > 0)
					{
                        ctlAdminMaster.ErrorMessage = "Flight with the same name already exists in the target Airline";
					}
					else
					{
                        ctlAdminMaster.ErrorMessage = "Flight Updated";
						Response.Redirect("~/Admin/ManageFlights.aspx");
					}
				}
				else
				{
                    ctlAdminMaster.ErrorMessage = "No changes made to the flight";
				}
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                TextBox txtNoOfSeats = (TextBox)row.FindControl("txtNoOfSeats");
                int intNoOfSeats = Convert.ToInt32((txtNoOfSeats.Text.ToString()));

                if ((!int.TryParse(txtNoOfSeats.Text, out intNoOfSeats)) || (intNoOfSeats <= 0))
                {
                    ctlAdminMaster.ErrorMessage = "Seat count should be a positive number";
                    txtNoOfSeats.Focus();
                }
                else
                {
                    string txtClass = ((TextBox)row.FindControl("txtClass")).Text;

                    FlightClass _class = new FlightClass();
                    switch (txtClass)
                    {
                        case "Economy": _class.ClassInfo = TravelClass.Economy; break;
                        case "Business": _class.ClassInfo = TravelClass.Business; break;
                        default:
                            break;
                    }
                    _class.NoOfSeats = intNoOfSeats;

					IFlightManager flightManager = (IFlightManager)AirTravelManagerFactory.Create("FlightManager");

                    string flightName = txtName.Text;
                    int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
                    string airlinename = ddlAirLine.SelectedItem.Text;
                    flightid = Request.QueryString["flightid"].ToString();
                    Flight _flight = new Flight() { ID = int.Parse(flightid), Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };

                    flightManager.UpdateFlightClass(_flight, _class);

                    e.Cancel = true;
                    GridView1.EditIndex = -1;
                    BindData();

                    ctlAdminMaster.ErrorMessage = "Flight Seats Updated";
                }
            }
            catch (FlightManagerException ex)
            {
                ctlAdminMaster.ErrorMessage = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ddlAirLine.Items.Clear();
            //BindData();
            Response.Redirect("~/Admin/ManageFlights.aspx");
        }
    }
}