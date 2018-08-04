using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Transaction;
using HappyTrip.Model.Entities.Transaction;
using System.Data;

namespace HappyTripWebApp.Cancellation
{
    public partial class CancellationRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrMsg.Text = "";
            Page.MaintainScrollPositionOnPostBack = false;

            if (!IsPostBack)
            {
                string refNo = Request.QueryString["refnum"];
                if (!string.IsNullOrWhiteSpace(refNo))
                {
                    txtRefNo.ReadOnly = true;
                    btnProcedeForCancel.Visible = false;
                    txtRefNo.Text = refNo;
                    btnProcedeForCancel_Click(this, EventArgs.Empty);
                }
            }
        }

        protected void btnProcedeForCancel_Click(object sender, EventArgs e)
        {
            try
            {
                IBookingManager bookingManager = BookingManagerFactory.GetInstance().Create();
                DataSet booking = bookingManager.GetFlightBooking(txtRefNo.Text.ToUpper(), (Guid)System.Web.Security.Membership.GetUser().ProviderUserKey);
                DataRow row = booking.Tables[0].Rows[0];
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;

                lblBookingID.Text = row["BookingId"].ToString();
                lblRefNo.Text = row["BookingReferenceNo"].ToString();
                lblSeats.Text = row["NoOfSeats"].ToString();
                lblCost.Text = row["CostPerTicket"].ToString();
                lblDate.Text = DateTime.Parse(row["DateOfJourney"].ToString()).Date.ToLongDateString();
                lblDeptTime.Text = DateTime.Parse(row["DepartureTime"].ToString()).TimeOfDay.ToString();
                lblArrivalTime.Text = DateTime.Parse(row["ArrivalTime"].ToString()).TimeOfDay.ToString();
                lblAirlineName.Text = row["AirlineName"].ToString();
                lblFlightName.Text = row["FlightName"].ToString();
                lblFromCity.Text = row["FromCityName"].ToString();
                lblToCity.Text = row["ToCityName"].ToString();
                lblClassType.Text = row["ClassType"].ToString();
                lblHappyMiles.Text = GetHappyMiles(lblRefNo.Text).ToString();
                btnCancel.Enabled = true;
            }
            catch (BookingNotAvailableException bnex)
            {
                lblErrMsg.Text = bnex.Message;
                PlaceHolder1.Visible = false;
            }
            catch (IndexOutOfRangeException)
            {
                lblErrMsg.Text = "Either booking is already canceled or the the reference number is invalid";
                PlaceHolder1.Visible = false;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Sorry !!! Unable to cancel the booking. Please Try Again";
                PlaceHolder1.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                IBookingManager bookingManager = BookingManagerFactory.GetInstance().Create();
                Cancelation cancelation = new Cancelation();
                cancelation.BookingID = int.Parse(lblBookingID.Text);
                cancelation.CancelationDate = DateTime.Parse(lblDate.Text);
                int noOfSeats = int.Parse(lblSeats.Text);
                decimal ticketCost = decimal.Parse(lblCost.Text);
                decimal totalCost = noOfSeats * ticketCost;
                cancelation.RefundAmount = totalCost;
                cancelation.NoOfSeats = noOfSeats;
                cancelation.CostPerTicket = ticketCost;
                cancelation.UserName = User.Identity.Name;
                cancelation.Miles = GetHappyMiles(lblRefNo.Text);
                cancelation.BookingReferenceNo = lblRefNo.Text;

                DateTime dateOfJourney = DateTime.Parse(lblDate.Text);
                TimeSpan timeOfJourney = TimeSpan.Parse(lblDeptTime.Text);
                if (bookingManager.CancelAirTravelBooking(cancelation, dateOfJourney, timeOfJourney))
                {
                    lblSuccessMessage.Text = "Cancelation done successfully";
                    btnCancel.Enabled = false;
                    PlaceHolder2.Visible = true;
                    Page.MaintainScrollPositionOnPostBack = true;

                    lblCancelationDate.Text = DateTime.Now.ToLongDateString();
                    lblRefundAmount.Text = cancelation.RefundAmount.ToString();
                }
            }
            catch (CancelationException cex)
            {
                lblErrMsg.Text = cex.Message;
                PlaceHolder2.Visible = false;
            }
            catch (Exception)
            {
                lblErrMsg.Text = "Sorry !!! Unable to cancel the booking. Please Try Again";
                PlaceHolder2.Visible = false;
            }
        }

        private int GetHappyMiles(string refno)
        {
            IHappyMiles happyMilesMgr = new HappyMilesManager();
            return happyMilesMgr.GetHappyMilesForBookingReference(refno);
        }
    }
}