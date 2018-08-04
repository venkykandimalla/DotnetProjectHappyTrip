using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class AddRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
            if (!IsPostBack)
            {
                try
                {
					ICityManager cityManager = (ICityManager)BusinessObjectManager.GetCityManager();
                    List<City> cities = cityManager.GetCities();

                    dpFromCity.Items.Add("None");
                    foreach (City c in cities)
                    {
                        ListItem item = new ListItem(c.Name + " (" + c.StateInfo.Name + ")", c.CityId.ToString());
                        dpFromCity.Items.Add(item);
                    }
                    dpFromCity.DataBind();

                    dpToCity.Items.Add("None");
                    foreach (City c in cities)
                    {
                        ListItem item = new ListItem(c.Name + " (" + c.StateInfo.Name + ")", c.CityId.ToString());
                        dpToCity.Items.Add(item);
                    }
                    dpToCity.DataBind();
                }
                catch (CityManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int intDistance = 0;

            if (dpFromCity.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select From City";
                dpFromCity.Focus();
            }
            else if (dpToCity.Text.Equals("None") == true)
            {
                ctlAdminMaster.ErrorMessage = "Select To City";
                dpToCity.Focus();
            }
            else if (dpFromCity.SelectedItem.Text.Equals(dpToCity.SelectedItem.Text))
            {
                ctlAdminMaster.ErrorMessage = "From City & To City Cannot be Same";
                dpFromCity.Focus();
            }
            else if (txtDistance.Text.Length == 0)
            {
                ctlAdminMaster.ErrorMessage = "Enter the Distance between Routes";
                txtDistance.Focus();
            }
            else if (!int.TryParse(txtDistance.Text, out intDistance) || (intDistance <= 0))
            {
                ctlAdminMaster.ErrorMessage = "Distance should be a valid positive number";
                txtDistance.Focus();
            }
            else
            {
                try
                {
                    Route route = new Route();
                    IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
                    City fromcity = new City();
                    fromcity.CityId = long.Parse(dpFromCity.SelectedItem.Value);
                    fromcity.Name = dpFromCity.SelectedItem.Text;
                    route.FromCity = fromcity;

                    City tocity = new City();
                    tocity.CityId = long.Parse(dpToCity.SelectedItem.Value);
                    tocity.Name = dpToCity.SelectedItem.Text;
                    route.ToCity = tocity;

                    if (routeManager.GetRouteID(route) > 0)
                    {
                        ctlAdminMaster.ErrorMessage = "Already route exists";
                        dpFromCity.Focus();
                    }
                    else
                    {
                        route.DistanceInKms = double.Parse(txtDistance.Text);
                        route.IsActive = chkActive.Checked;
                        routeManager.AddRoute(route);
                        ctlAdminMaster.ErrorMessage = "Route Added Successfully";
                        //Response.Redirect("~/Admin/Home.aspx");
                    }
                }
                catch (RouteManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*dpFromCity.SelectedIndex = 0;
            dpToCity.SelectedIndex = 0;
            txtDistance.Text = "";
            chkActive.Checked = false;
            ctlAdminMaster.ErrorMessage = "";
             */
            Response.Redirect("~/Admin/Home.aspx");
        }
    }
}