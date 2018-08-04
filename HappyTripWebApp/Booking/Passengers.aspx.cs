using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;
using System.Web.Security;
using HappyTrip.Model.Entities.UserAccount;

namespace HappyTripWebApp
{
    public partial class Passengers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session.Count == 0)
			{
				Response.Redirect("~/Index.aspx");
			}

            if (!IsPostBack)
            {
                decimal TotalCost = 0;
				if (Session["travelbooking"] != null)
				{
					TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];
					FlightBooking bookingoneway = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);
					int NoOfSeats = bookingoneway.NoOfSeats;

					List<Passenger> lstPassenger = new List<Passenger>();
					for (int i = 0; i < NoOfSeats; i++)
					{
						lstPassenger.Add(new Passenger { Name = string.Empty, Gender = ' ' });
					}

					rptrPassengerInfo.DataSource = lstPassenger;
					rptrPassengerInfo.DataBind();

					rptrOnwardFlightInfo.DataSource = bookingoneway.TravelScheduleInfo.GetSchedules();
					rptrOnwardFlightInfo.DataBind();

					TotalCost = bookingoneway.TotalCost;


					lblHeaderFromCity.Text = bookingoneway.TravelScheduleInfo.GetSchedules()[0].RouteInfo.FromCity.Name;
					lblHeaderToCity.Text = bookingoneway.TravelScheduleInfo.GetSchedules()[0].RouteInfo.ToCity.Name;
					lblAdults.Text = bookingoneway.NoOfSeats.ToString();

					lblHeaderDepart.Text = bookingoneway.DateOfJourney.ToString("ddd, dd MMM, yyyy");

					lblHeaderDateSeparator.Visible = false;

					if (Membership.GetUser() != null)
					{
						ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());

						txtName.Text = com.Personal.FullName;
						txtAddress.Text = com.Contact.Address;
						txtCity.Text = com.Contact.City;
						txtState.Text = com.Contact.State;
						txtMobile.Text = com.Contact.MobileNo;
                        txtEmailId.Text = Membership.GetUser().UserName;
					}

					bool isReturnAvailable = travelbooking.IsReturnAvailable();
					FlightBooking bookingreturn = null;
					if (isReturnAvailable)
					{
						bookingreturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);

						rptrReturnFlightInfo.DataSource = bookingreturn.TravelScheduleInfo.GetSchedules();
						rptrReturnFlightInfo.DataBind();

						divReturn.Visible = true;

						TotalCost = TotalCost + bookingreturn.TotalCost;

						lblHeaderReturn.Text = bookingreturn.DateOfJourney.ToString("ddd, dd MMM, yyyy");

						lblHeaderDateSeparator.Visible = true;

					}

					#region Insurance for air travel------------------------
					if (bookingoneway.Insurance != null)
					{
						InsuranceOption.Checked = true;
					}

					decimal insuranceValue = 0;
					//Original Implementation
					insuranceValue = bookingoneway.TravelScheduleInfo.TotalCostPerTicket * 15 / 100;

					if (insuranceValue < 250)
						insuranceValue = 250;
					else if (insuranceValue > 500)
						insuranceValue = 500;
					lblOnwardInsuranceValue.Text = insuranceValue.ToString();

					if (isReturnAvailable)
					{
						//Original Implementation
						insuranceValue = bookingreturn.TravelScheduleInfo.TotalCostPerTicket * 15 / 100;
						//insuranceValue = bookingreturn.TravelScheduleInfo.TotalCostPerTicket;
						if (insuranceValue < 250)
							insuranceValue = 250;
						else if (insuranceValue > 500)
							insuranceValue = 500;

						lblReturnInsuranceValue.Text = insuranceValue.ToString();
						lblReturnInsuranceValue.Visible = true;
						lblINR.Visible = true;
					}
					#endregion Insurance for air travel------------------------
				}
				else
				{
					Response.Redirect("~/Index.aspx");
				}

                lblTotalPrice.Text = TotalCost.ToString();
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["travelbooking"] != null)
                {
                    TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];

                    FlightBooking travelbookingoneway = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);
                    travelbookingoneway.GetPassengers().Clear();

                    FlightBooking travelbookingReturn = null;
                    bool isReturnAvailable = false;
                    if (travelbooking.IsReturnAvailable())
                    {
                        isReturnAvailable = true;
                        travelbookingReturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);
                        travelbookingReturn.GetPassengers().Clear();
                    }

                    foreach (RepeaterItem item in rptrPassengerInfo.Items)
                    {
                        TextBox Name = (TextBox)item.FindControl("AdultFname");
                        DropDownList Gender = (DropDownList)item.FindControl("ddlGender");
                        TextBox DOB = (TextBox)item.FindControl("txtDOB");

                        DateTime dtDOB;
                        if (DateTime.TryParse(DOB.Text, out dtDOB) == false)
                        {
                            lblError.Text = "Invalid Date of Birth";
                            return;
                        }
                        else
                        {
							if (dtDOB > DateTime.Now)
							{
								lblError.Text = "Birthday is in the future.";
								return;
							}
                            lblError.Text = "";
                        }

                        travelbookingoneway.AddPassenger(new Passenger { Name = Name.Text, DateOfBirth = dtDOB, Gender = Gender.SelectedItem.Value.ToCharArray()[0] });
                        if (isReturnAvailable)
                            travelbookingReturn.AddPassenger(new Passenger { Name = Name.Text, DateOfBirth = dtDOB, Gender = Gender.SelectedItem.Value.ToCharArray()[0] });
                    }

                    //Insurance captured if user has selected insurance
                    if (InsuranceOption.Checked)
                    {
						FlightBooking bookingoneway =  (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);
                        TravelInsurance insurance = new TravelInsurance();
                        insurance.Amount = Convert.ToDecimal(lblOnwardInsuranceValue.Text) * bookingoneway.NoOfSeats;
                        travelbookingoneway.Insurance = insurance;

                        if (isReturnAvailable)
                        {
							FlightBooking bookingReturh = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);
                            TravelInsurance insuranceReturn = new TravelInsurance();
                            insuranceReturn.Amount = Convert.ToDecimal(lblReturnInsuranceValue.Text) * bookingReturh.NoOfSeats;
                            travelbookingReturn.Insurance = insuranceReturn;
                        }
                    }
                    //-------------------------------------------------

                    BookingContact bookingcontact = new BookingContact();
                    bookingcontact.Address = txtAddress.Text;
                    bookingcontact.City = txtCity.Text;
                    bookingcontact.ContactName = txtName.Text;
                    bookingcontact.Email = txtEmailId.Text;
                    bookingcontact.MobileNo = txtMobile.Text;
                    bookingcontact.PhoneNo = txtPhoneNumber.Text;
                    bookingcontact.State = txtState.Text;

                    travelbookingoneway.Contact = bookingcontact;
                    travelbooking.AddBookingForTravel(TravelDirection.OneWay, travelbookingoneway);

                    if (isReturnAvailable)
                    {
                        travelbookingReturn.Contact = bookingcontact;
                        travelbooking.AddBookingForTravel(TravelDirection.Return, travelbookingReturn);
                    }


                    Session["travelbooking"] = travelbooking;
                }

                Response.Redirect("~/booking/confirmation.aspx");
            }
            catch (Exception)
            {
                lblError.Text = "Please check the information entered";
            }
        }
    }
}