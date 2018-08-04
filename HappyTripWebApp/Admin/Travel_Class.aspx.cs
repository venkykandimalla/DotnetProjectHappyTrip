using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class Travel_Class : System.Web.UI.Page
    {
        //TravelClassManager obj = new TravelClassManager();

        public void BindData()
        {
            
          /*  GridView1.DataSource = obj.GetTravelClass();
            GridView1.DataBind();*/
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                BindData();
                Panel1.Enabled = false;
            }*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Panel1.Enabled = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //txtClassName.Text = "";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            /*GridView1.EditIndex = e.NewEditIndex;
            BindData();*/
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            /*e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();*/
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*GridViewRow row = GridView1.Rows[e.RowIndex];

            obj.UpdateTravelClass(Convert.ToInt32(((TextBox)(row.Cells[0].Controls[0])).Text), ((TextBox)(row.Cells[1].Controls[0])).Text);*/
            
        }

        
    }
}