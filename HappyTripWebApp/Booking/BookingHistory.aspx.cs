using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer.Search;
using System.Data;
using HappyTrip.Model.Entities.Transaction;
using System.Web.Security;

namespace HappyTripWebApp.Booking
{
    public partial class BookingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlBookingHistory.Visible = true;
            pnlNoBookingHistory.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    string UserID = ((Guid)Membership.GetUser().ProviderUserKey).ToString();
                    List<FlightBooking> Bookings = new List<FlightBooking>();
                    ISearchManager searchmanager = SearchManagerFactory.GetInstance().Create();

                    if ((string.IsNullOrWhiteSpace(Request.QueryString["from"])) && (string.IsNullOrWhiteSpace(Request.QueryString["to"])))
                    {
                        genDateCriteria.InnerText = "Showing all bookings";
                        Bookings = searchmanager.GetUserBookings(UserID);
                    }
                    else
                    {
                        if ((!string.IsNullOrWhiteSpace(Request.QueryString["from"])) && (!string.IsNullOrWhiteSpace(Request.QueryString["to"])))
                        { genDateCriteria.InnerText = "Showing bookings made between " + Request.QueryString["from"] + " and " + Request.QueryString["to"]; }
                        else if (string.IsNullOrWhiteSpace(Request.QueryString["from"]))
                        { genDateCriteria.InnerText = "Showing bookings made till " + Request.QueryString["to"]; }
                        else
                        { genDateCriteria.InnerText = "Showing bookings made since " + Request.QueryString["from"]; }

                        Bookings = searchmanager.SearchUserBookings(UserID, Request.QueryString["from"], Request.QueryString["to"]);
                    }

                    if (Bookings.Count > 0)
                    {
                        drpBookings.DataSource = Bookings;
                        drpBookings.DataBind();
                    }
                    else
                    {
                        pnlBookingHistory.Visible = false;
                        pnlNoBookingHistory.Visible = true;
                    }

                    lblResultsType.InnerText = genDateCriteria.InnerText;
                }
                catch (Exception)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
        }

        protected void drpBookings_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            }
        }

        protected string GetStatus(object IsCancelled, object JourneyDate)
        {
            string strDiv = "";
            if ((bool)IsCancelled == true)
            {
                strDiv = "Cancelled";
            }
            else if (((DateTime)JourneyDate) < DateTime.Now.Date)
            {
                strDiv = "Used";
            }
            else
            {
                strDiv = "Booked";
            }

            return strDiv;
        }

        protected string BuildCancellationDiv(object BookingReferenceNumber, object IsCancelled, object JourneyDate)
        {
            string strDiv = "";
            if ((bool)IsCancelled == false && ((DateTime)JourneyDate) >= DateTime.Now.Date)
            {
                strDiv = "<div class='pb_content'><input type='button' value='Cancel Booking' style='width:100%' onclick=\"javascript:return showBookingCancellation('" + BookingReferenceNumber + "')\" /></div>";
            }
            return strDiv;
        }
    }
}