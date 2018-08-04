using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.BusinessLayer;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.BusinessLayer.Transaction;
using System.Web.Security;

namespace HappyTripWebApp
{
    public partial class Payment_Screen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session.Count == 0)
			{
				Response.Redirect("~/Index.aspx");
			}
            if (Session["travelbooking"] != null)
            {
                lblHeaderDateSeparator.Visible = false;
                TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];
                FlightBooking bookingoneway = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);

                lblHeaderFromCity.Text = bookingoneway.TravelScheduleInfo.GetSchedules()[0].RouteInfo.FromCity.Name;
                lblHeaderToCity.Text = bookingoneway.TravelScheduleInfo.GetSchedules()[0].RouteInfo.ToCity.Name;
                lblAdults.Text = bookingoneway.NoOfSeats.ToString();

                lblHeaderDepart.Text = bookingoneway.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                if (travelbooking.IsReturnAvailable())
                {
                    lblHeaderDateSeparator.Visible = true;
                    FlightBooking bookingreturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);
                    lblHeaderReturn.Text = bookingreturn.DateOfJourney.ToString("ddd, dd MMM, yyyy");
                }
            }
			else
			{
				Response.Redirect("~/Index.aspx");
			}
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
			int happyMiles = 0;
			MembershipUser mUser = Membership.GetUser();
			decimal travelCost = 0;
            string userName="";
			
            try
            {
                int CardExpiryYear = Convert.ToInt16(ddlccExpirationYear.SelectedItem.Value);
                int CardExpiryMonth = Convert.ToInt16(ddlccExpirationMonth.SelectedItem.Value);
				int cardType = Convert.ToInt16(ddlccCardType.SelectedItem.Value);

                if (ValidatePaymentDetails(CardExpiryMonth, CardExpiryYear))
                {
                    TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];
                    Card _card = new Card() { CardNo = txtCard_no.Text, Cvv2No = txtCvv.Text, Name = txtcard_holder.Text, ExpiryYear = CardExpiryYear, ExpiryMonth = CardExpiryMonth, CardType=(CardTypes)cardType};

                    IBookingManager _bookingManager = BookingManagerFactory.GetInstance().Create();
                    TravelBooking travelbookingresult = null;

                    travelbookingresult = _bookingManager.ProcessAirTravelBooking(travelbooking, _card);

					if (Request.IsAuthenticated)
					{
                        //Added by Anand for updated travel miles
                        IHappyMiles travelMiles = new HappyMilesManager();

						List<int> theAirlines = new List<int>();

						//AirlineIDs for the onwared flights
						FlightBooking flightBookingOnward = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);
						if (flightBookingOnward != null)
						{
							theAirlines.Clear();
							List<Schedule> theSchedules = flightBookingOnward.TravelScheduleInfo.GetSchedules();
							if (theSchedules != null)
							{
								foreach (Schedule schedule in theSchedules)
								{
									theAirlines.Add(schedule.FlightInfo.AirlineForFlight.Id);
								}
								if (mUser != null)
								{
									userName = mUser.UserName;
									decimal insurance = 0;
									if (flightBookingOnward.Insurance != null)
									{
										insurance = flightBookingOnward.Insurance.Amount;
									}
									travelCost = travelbooking.GetBookingForTravel(TravelDirection.OneWay).TotalCost -  insurance;
									happyMiles += travelMiles.UpdateHappyMilesForUser(userName, theAirlines, (double)travelCost, flightBookingOnward.ReferenceNo);
								}
							}
						}

						if (travelbooking.IsReturnAvailable())
						{
							//AirlineIDs for the return flights
							theAirlines.Clear();
							FlightBooking flightBookingReturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);
							List<Schedule> theSchedules = flightBookingReturn.TravelScheduleInfo.GetSchedules();
							if (theSchedules != null)
							{
								foreach (Schedule schedule in theSchedules)
								{
									theAirlines.Add(schedule.FlightInfo.AirlineForFlight.Id);
								}
								if (mUser != null)
								{
									userName = mUser.UserName;
									decimal insurance = 0;
									if (flightBookingOnward.Insurance != null)
									{
										insurance = flightBookingOnward.Insurance.Amount;
									}
									travelCost = travelbooking.GetBookingForTravel(TravelDirection.Return).TotalCost - insurance;
									happyMiles += travelMiles.UpdateHappyMilesForUser(userName, theAirlines, (double)travelCost, flightBookingReturn.ReferenceNo);
								}
							}
						}

                        ((SiteMaster)Master).ShowHappyMilesForUser();
                        Session["happymiles"] = happyMiles;
					}

                    Session["travelbooking"] = travelbookingresult;
					
                    Response.Redirect("~/booking/Payment_Success.aspx");
                }
            }
            catch (HappyTrip.Model.BusinessLayer.Search.FlightSeatsAvailabilityException ex)
            {
                lblUnSuccessful.Visible = true;
                lblUnSuccessful.Text = ex.Message;
            }
            catch (PaymentProcessException ex)
            {
                lblUnSuccessful.Visible = true;
                lblUnSuccessful.Text = ex.Message;
            }
            catch (InvalidBookingTypeException ex)
            {
                lblUnSuccessful.Visible = true;
                lblUnSuccessful.Text = ex.Message;
            }
            catch (BookingException ex)
            {
                lblUnSuccessful.Visible = true;
                lblUnSuccessful.Text = ex.Message;
            }
            catch (Exception)
            {
                lblUnSuccessful.Visible = true;
                lblUnSuccessful.Text = "Unable to Book Tickets";
            }
        }

        private bool ValidatePaymentDetails(int CardExpiryMonth, int CardExpiryYear)
        {
            bool blnValid = true;
            lblUnSuccessful.Visible = false;
            lblUnSuccessful.Text = "";


            if (txtCard_no.Text.Trim().Length != 16)
            {
                lblUnSuccessful.Text += "Card number should have 16 digits<br/>";
                blnValid = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtcard_holder.Text, @"^[a-zA-Z ]+$"))
            {
                lblUnSuccessful.Text += "Card holder name should contain only alphabets";
                blnValid = false;
            }
            else if (txtCvv.Text.Trim().Length > 3)
            {
                lblUnSuccessful.Text += "CVV should not have more than 3 digits<br/>";
                blnValid = false;
            }
            else if ((CardExpiryYear < DateTime.Now.Year) || (CardExpiryYear == DateTime.Now.Year && CardExpiryMonth < DateTime.Now.Month))
            {
                lblUnSuccessful.Text += "Sorry! Your card has expired<br/>";
                blnValid = false;
            }


            if (blnValid == false)
            {
                lblUnSuccessful.Visible = true;
            }

            return blnValid;
        }
    }
}