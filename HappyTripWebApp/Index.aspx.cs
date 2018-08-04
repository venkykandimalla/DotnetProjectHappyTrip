using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using HappyTrip.Model.BusinessLayer.Search;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        /// <summary>
        /// Page Load Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Array itemValues = System.Enum.GetValues(typeof(TravelClass));
            Array itemNames = System.Enum.GetNames(typeof(TravelClass));

            for (int i = 0; i <= itemNames.Length - 1; i++)
            {
                ListItem item = new ListItem(itemNames.GetValue(i).ToString(), itemValues.GetValue(i).ToString());
                ddlClass.Items.Add(item);
            }

           
            //remove previous sessions
            Session.RemoveAll();
        }

        /// <summary>
        /// method to get cities based on the input search term
        /// </summary>
        /// <param name="searchterm"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetCities(string searchterm)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            ISearchManager searchmanager = SearchManagerFactory.GetInstance().Create();

            return jss.Serialize(searchmanager.GetCities().Where(e => e.Name.ToLower().Contains(searchterm.ToLower())));
        }

        protected void button_flight_search_Click(object sender, EventArgs e)
        {
            bool blnIsValid = false;

            if (origin_autocomplete.Text.Length == 0)
            {
                lblError.Text = "From City can't be empty";
                origin_autocomplete.Focus();
            }
            else if (destination_autocomplete.Text.Length == 0)
            {
                lblError.Text = "To City can't be empty";
                destination_autocomplete.Focus();
            }
            else if (string.Compare(hdnFrom.Value, hdnTo.Value) == 0)
            {
                lblError.Text = "'From City' and 'To City' can't be the same";
                destination_autocomplete.Focus();
            }
            else
            {
                DateTime dtDeparture;
                DateTime dtReturn;
                bool blnValidDepartureDate = DateTime.TryParseExact(dpt_date.Text.Trim(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dtDeparture);
                bool blnValidReturnDate = DateTime.TryParseExact(rtn_date.Text.Trim(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dtReturn);

                if (!blnValidDepartureDate)
                {
                    lblError.Text = "Please enter a valid departure date";
                    dpt_date.Focus();
                }
                else if ((multi_city.Checked) && (!blnValidReturnDate))
                {
                    lblError.Text = "Please enter a valid return date";
                    rtn_date.Focus();
                }
                else if (dtDeparture < DateTime.Now.Date)
                {
                    lblError.Text = "Departure date cannot be a past date";
                    dpt_date.Focus();
                    return;
                }
                else if ((multi_city.Checked) && (DateTime.Compare(dtReturn, dtDeparture) < 0))
                {
                    lblError.Text = "Return date should be greater than departure date";
                    rtn_date.Focus();
                }
                else
                {
					if (dtDeparture > DateTime.Now.AddDays(90) || dtReturn > DateTime.Now.AddDays(90))
					{
						lblError.Text = "Departure date cannot be beyond 90 from the date of booking";
						dpt_date.Focus();
						return;
					}
                    blnIsValid = true;
                }
            }

            if (blnIsValid)
            {
                string departdate = dpt_date.Text;
                string returndate = rtn_date.Text;

                string querystringdate = "&depart_date=" + departdate;

                int td = (int)TravelDirection.OneWay;// travel direction
                if (!one_way.Checked)
                {
                    querystringdate = querystringdate + "&return_date=" + returndate;
                    td = (int)TravelDirection.Return;
                }

                Response.Redirect("~/results.aspx?fromid=" + hdnFrom.Value + "&toid=" + hdnTo.Value + "&class=" + ddlClass.SelectedValue + "&td=" + td + querystringdate + "&adults=" + adults.Value);
            }
        }
    }
}