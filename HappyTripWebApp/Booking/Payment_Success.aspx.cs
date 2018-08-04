using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Booking
{
    public partial class Payment_Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			
            #region Obtain the bookingObjects From Session
            if (!IsPostBack)
            {
                decimal TotalCost = 0;
                TravelBooking _travelBooking = null;
                FlightBooking flightbookingonward = null;
                FlightBooking flightbookingreturn = null;
                if (Session["travelBooking"] != null)
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
                    FlightBooking flightbooking = flightbookingonward;
                    int NoOfSeats = flightbooking.NoOfSeats;
                    lblHeaderDepart.Text = flightbooking.DateOfJourney.ToString("ddd, dd MMM, yyyy");
                    lblAdults.Text = NoOfSeats.ToString();

                    List<Passenger> lstPassenger = flightbooking.GetPassengers(); ;

                    rptrPassengerInfo.DataSource = lstPassenger;
                    rptrPassengerInfo.DataBind();

                    rptrOnwardFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                    rptrOnwardFlightInfo.DataBind();

                    TotalCost = flightbooking.TotalCost;

                    lblHeaderDateSeparator.Visible = false;


                    //Fill Contacts details
                    lblName.Text = flightbooking.Contact.ContactName;
                    lblAddressline1.Text = flightbooking.Contact.MobileNo;
                    lblState.Text = flightbooking.Contact.State;
                    lblCity.Text = flightbooking.Contact.City;
                    lblEmail.Text = flightbooking.Contact.Email;
                    lblMobno.Text = flightbooking.Contact.MobileNo;
                    lblPhno.Text = flightbooking.Contact.PhoneNo;

                    lblHeaderFromCity.Text = flightbooking.TravelScheduleInfo.GetSchedules()[0].RouteInfo.FromCity.Name;
                    lblHeaderToCity.Text = flightbooking.TravelScheduleInfo.GetSchedules()[0].RouteInfo.ToCity.Name;

                    lblOnwardTicketNo.Text = flightbooking.ReferenceNo;

                }

                if (flightbookingreturn != null)
                {
                    FlightBooking flightbooking = flightbookingreturn;
                    int NoOfSeats = flightbooking.NoOfSeats;
                    lblHeaderReturn.Text = flightbooking.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                    rptrReturnFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                    rptrReturnFlightInfo.DataBind();

                    divReturn.Visible = true;

                    TotalCost = TotalCost + flightbooking.TotalCost;

                    lblHeaderDateSeparator.Visible = true;

                    pnlReturnTicketNo.Visible = true;
                    lblReturnTicketNo.Text = flightbooking.ReferenceNo;
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

                    if (insuranceReturnAmount > 0)
						lblInsuranceValue.Text += "-- Return Journey : INR " + (insuranceReturnAmount / flightbookingreturn.NoOfSeats) + " /- Per Passenger ";

                    lblInsuranceText.Visible = true;
                    lblInsuranceValue.Visible = true;

                }
                else
                {
                    lblInsuranceValue.Text = "INR 0.0";
                    lblInsuranceValue.Visible = true;
                }

				lblTotalPrice.Text = "INR " + (TotalCost - (insuranceOnwardAmount + insuranceReturnAmount)).ToString();

                lblGrandTotal.Text = "INR " + TotalCost.ToString();


				if (Session["happymiles"] != null)
				{
					int happyMiles = (int)Session["happymiles"];
					lblHappyMiles.Text = "Happy miles earned in this transaction is " + happyMiles.ToString();
				}
            }
			//Clean up the session
			Session.Clear();

            #endregion
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
           
        }

        //protected void btnPrintTicket_Click(object sender, EventArgs e)
        //{

        //}
    }
}