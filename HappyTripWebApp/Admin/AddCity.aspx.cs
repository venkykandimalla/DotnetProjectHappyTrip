using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                clear();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
            if (cityNameValidator.IsValid)
            {
                if (txtCrCity.Text.Trim().Length == 0)
                {
                    ctlAdminMaster.ErrorMessage = "City Name Can't be Empty";
                    txtCrCity.Focus();
                }
                else if (dpStateCity.Text.Equals("None") == true)
                {
                    ctlAdminMaster.ErrorMessage = "Select the State";
                    dpStateCity.Focus();
                }
                else
                {
                    string CityName = txtCrCity.Text;

                    State _state = new State();
                    _state.StateId = long.Parse(dpStateCity.SelectedItem.Value);

                    City _city = new City();
                    _city.Name = CityName;
                    _city.StateInfo = _state;

                    ICityManager cityManger = (ICityManager)BusinessObjectManager.GetCityManager();

                    try
                    {
                        if (cityManger.AddCity(_city))
                        {
                            ctlAdminMaster.ErrorMessage = "City Added Successfully";
                        }
                        else
                        {
                            ctlAdminMaster.ErrorMessage = "City already exists";
                        }
                    }

                    catch (CityManagerException ex)
                    {
                        ctlAdminMaster.ErrorMessage = ex.Message;
                    }
                }
            }
        }

        public void clear()
        {
            txtCrCity.Text = "";
            ctlAdminMaster.ErrorMessage = "";
            dpStateCity.Items.Clear();

			ICityManager cityManager = (ICityManager)BusinessObjectManager.GetCityManager();
            List<State> stateList = cityManager.GetStates();

            dpStateCity.Items.Add("None");
            foreach (State s in stateList)
            {
                ListItem item = new ListItem(s.Name, s.StateId.ToString());
                dpStateCity.Items.Add(item);
            }
            dpStateCity.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //clear();
            Response.Redirect("~/Admin/Home.aspx");
        }
    }
}