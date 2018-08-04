using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;

namespace HappyTripWebApp.Admin
{
    public partial class RouteUI : System.Web.UI.Page
    {
        private void BindData()
        {
            try
            {
				IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
				DataTable dt = new DataTable();
				List<Route> routes = routeManager.GetRoutes();

				dt.Columns.Add("RouteId", typeof(long));
				dt.Columns.Add("FromCityName", typeof(string));
				dt.Columns.Add("ToCityName", typeof(string));
				dt.Columns.Add("DistanceInKms", typeof(decimal));
				dt.Columns.Add("status", typeof(bool));

				foreach (Route r in routes)
				{
					DataRow rw = dt.NewRow();
					rw["RouteId"] = r.ID;
                    rw["FromCityName"] = r.FromCity.Name + " (" + r.FromCity.StateInfo.Name + ")";
                    rw["ToCityName"] = r.ToCity.Name + " (" + r.ToCity.StateInfo.Name + ")";
					rw["DistanceInKms"] = r.DistanceInKms;
					rw["status"] = r.IsActive;

					dt.Rows.Add(rw);
				}

				GridView1.DataSource = dt;
                ctlAdminMaster.BuildPager(GridView1);
            }
            catch (RouteManagerException ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox txtDist = (TextBox)row.Cells[3].Controls[1];

            if (txtDist != null)
            {
                long lngDistance = 0;
                if ((!long.TryParse(txtDist.Text, out lngDistance)) || (lngDistance <= 0))
                {
                    ctlAdminMaster.ErrorMessage = "Distance should be a positive number";
                    txtDist.Focus();
                }
                else
                {
                    try
                    {
                        IRouteManager routeManager = (IRouteManager)BusinessObjectManager.GetRouteManager();
                        Route route = new Route();
                        route.ID = long.Parse(((Label)row.Cells[0].Controls.OfType<Label>().First()).Text);
                        route.DistanceInKms = lngDistance;
                        //route.IsActive = ((CheckBox)(row.Cells[4].Controls[0])).Checked;
                        route.IsActive = true;

                        routeManager.UpdateRoute(route);

                        e.Cancel = true;
                        GridView1.EditIndex = -1;
                        BindData();

                        ctlAdminMaster.ErrorMessage = "Route Updated";
                    }
                    catch (RouteManagerException ex)
                    {
                        throw ex;
                    }
                }
            }
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