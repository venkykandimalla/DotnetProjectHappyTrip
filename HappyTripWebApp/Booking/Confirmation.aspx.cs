using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session.Count == 0)
			{
				Response.Redirect("~/Index.aspx");
			}
            if (!IsPostBack)
            {
                try
                {
                    #region Obtain the bookingObjects From Session
                    decimal totalCost = 0;
                    TravelBooking _travelBooking = null;
                    FlightBooking flightbookingonward = null;
                    FlightBooking flightbookingreturn = null;
                    if (Session["travelbooking"] != null)
                    {
                        _travelBooking = (TravelBooking)Session["travelbooking"];
                        flightbookingonward = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.OneWay);
                        flightbookingreturn = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.Return);
                    }
					else
					{
						Response.Redirect("~/Index.aspx");
					}
                    if (flightbookingonward != null)
                    {
						int NoOfSeats = flightbookingonward.NoOfSeats;

                        List<Passenger> lstPassenger = flightbookingonward.GetPassengers(); ;

                        rptrPassengerInfo.DataSource = lstPassenger;
                        rptrPassengerInfo.DataBind();

                        rptrOnwardFlightInfo.DataSource = flightbookingonward.TravelScheduleInfo.GetSchedules();
                        rptrOnwardFlightInfo.DataBind();

                        totalCost = flightbookingonward.TotalCost;

                        lblHeaderFromCity.Text = flightbookingonward.TravelScheduleInfo.GetSchedules()[0].RouteInfo.FromCity.Name;
                        lblHeaderToCity.Text = flightbookingonward.TravelScheduleInfo.GetSchedules()[0].RouteInfo.ToCity.Name;
                        lblAdults.Text = flightbookingonward.NoOfSeats.ToString();

                        lblHeaderDepart.Text = flightbookingonward.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                        lblHeaderDateSeparator.Visible = false;
                        if (_travelBooking.IsReturnAvailable())
                            lblHeaderDateSeparator.Visible = true;

                        //Fill Contacts details
                        lblName.Text = flightbookingonward.Contact.ContactName;
                        lblAddressline1.Text = flightbookingonward.Contact.MobileNo;
                        lblState.Text = flightbookingonward.Contact.State;
                        lblCity.Text = flightbookingonward.Contact.City;
                        lblEmail.Text = flightbookingonward.Contact.Email;
                        lblMobno.Text = flightbookingonward.Contact.MobileNo;
                        lblPhno.Text = flightbookingonward.Contact.PhoneNo;
                    }

                    if (flightbookingreturn != null)
                    {
                        int NoOfSeats = flightbookingreturn.NoOfSeats;

                        rptrReturnFlightInfo.DataSource = flightbookingreturn.TravelScheduleInfo.GetSchedules();
                        rptrReturnFlightInfo.DataBind();

                        divReturn.Visible = true;

                        totalCost = totalCost + flightbookingreturn.TotalCost;

                        lblHeaderReturn.Text = flightbookingreturn.DateOfJourney.ToString("ddd, dd MMM, yyyy");
                    }

                    //Insurance Display
                    decimal insuranceOnwardAmount = 0;
                    decimal insuranceReturnAmount = 0;
                    if (flightbookingonward.Insurance != null)
                    {
                        insuranceOnwardAmount = flightbookingonward.Insurance.Amount;

                        if (flightbookingreturn != null && flightbookingreturn.Insurance != null)
                            insuranceReturnAmount = flightbookingreturn.Insurance.Amount;

                        lblInsuranceText.Text = "You have opted to go for travel insurance for the amount : ";
                        lblInsuranceValue.Text = "Onward Journey : INR " + (insuranceOnwardAmount / flightbookingonward.NoOfSeats) + " /- Per Passenger ";

                        if(insuranceReturnAmount > 0)
                            lblInsuranceValue.Text += "-- Return Journey : INR " + (insuranceReturnAmount / flightbookingreturn.NoOfSeats) + " /- Per Passenger ";

                        lblInsuranceText.Visible = true;
                        lblInsuranceValue.Visible = true;

                    }
                    else
                    {
                        lblInsuranceValue.Text = "INR 0.0";
                        lblInsuranceValue.Visible = true;
                    }

                    lblTotalPrice.Text = "INR " + totalCost.ToString();

					lblGrandTotal.Text = "INR " + (totalCost + insuranceOnwardAmount + insuranceReturnAmount).ToString();

                    #endregion
                }
                catch (Exception)
                {
                    lblHeaderDepart.Text = "Sorry !!! Unable to display details";
                }
            }
            
            
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/booking/Payment_Screen.aspx");
        }
    }
}