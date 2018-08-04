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
    public partial class ManageCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            try
            {
				ICityManager cityManger = (ICityManager)BusinessObjectManager.GetCityManager();
                List<City> cities = cityManger.GetCities();
				if (cities.Count > 0)
				{
					grdCity.DataSource = cities;
                    ctlAdminMaster.BuildPager(grdCity);
				}
				else
				{
					grdCity.Visible = false;
				}
            }
            catch (CityManagerException ex)
            {
                ctlAdminMaster.ErrorMessage = ex.Message;
            }
        }

        protected void grdCity_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
            grdCity.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void grdCity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (IsValid)
            {
                GridViewRow row = grdCity.Rows[e.RowIndex];

                HiddenField hdnStateId = (HiddenField)row.FindControl("hdnStateId");
                TextBox txtState = (TextBox)row.FindControl("txtState");
                TextBox txtCityName = (TextBox)row.FindControl("txtCityName");

                if (string.IsNullOrWhiteSpace(txtCityName.Text))
                {
                    ctlAdminMaster.ErrorMessage = "City Name Can't be Empty";
                    txtCityName.Focus();
                }
                else
                {
                    int cityId = Int32.Parse(grdCity.DataKeys[e.RowIndex].Value.ToString());

                    string CityName = txtCityName.Text;
                    string StateName = txtState.Text;

                    City _city = new City()
                    {
                        CityId = cityId,
                        Name = CityName,
                        StateInfo = new State()
                        {
                            StateId = long.Parse(hdnStateId.Value),
                            Name = StateName
                        }
                    };

                    try
                    {
                        ICityManager cityManger = (ICityManager)BusinessObjectManager.GetCityManager();

                        if (cityManger.UpdateCity(_city))
                        {
                            ctlAdminMaster.ErrorMessage = "City Updated Successfully";
                        }
                        else
                        {
                            ctlAdminMaster.ErrorMessage = "City already exists";
                        }
                        grdCity.EditIndex = -1;
                        BindData();
                    }
                    catch (CityManagerException ex)
                    {
                        ctlAdminMaster.ErrorMessage = ex.Message;
                    }
                }
            }
        }

        protected void grdCity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdCity.EditIndex = -1;
            BindData();
        }

        protected void grdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCity.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void lbtPreviousPage_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void lbtNextPage_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}