using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;


namespace HappyTripWebApp.Admin
{
    public partial class ManageAirlines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
            if (!IsPostBack)
            {
                ctlAdminMaster.BuildPager(grdAirline);
            }
            else
            {
                ctlAdminMaster.EditIndex = grdAirline.EditIndex;
            }
        }

        protected void sdsAirline_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                if (e.Exception.Message.IndexOf("UNIQUE KEY") > 0)
                { ctlAdminMaster.ErrorMessage = "Cannot update airline. There is another airline with same name."; }
                else
                { ctlAdminMaster.ErrorMessage = "Unable to update airline with empty field"; }
                e.ExceptionHandled = true;
            }
            else if (e.AffectedRows == -1)
            { ctlAdminMaster.ErrorMessage = "Cannot update airline. There is another airline with same airline code."; }
            else
            {
                ctlAdminMaster.ErrorMessage = "";
            }
        }

        protected void grdAirline_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Edit) && (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Cells[1].Controls.OfType<TextBox>().First().MaxLength = 50;
                e.Row.Cells[2].Controls.OfType<TextBox>().First().MaxLength = 10;
            }
        }

        protected void grdAirline_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string AirlineName = (e.NewValues["AirlineName"] == null) ? "" : e.NewValues["AirlineName"].ToString();
            string AirlineCode = (e.NewValues["AirlineCode"] == null) ? "" : e.NewValues["AirlineCode"].ToString();

            if (string.IsNullOrWhiteSpace(AirlineName))
            {
                ctlAdminMaster.ErrorMessage = "Airline Name Can't be Empty";
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(AirlineCode))
            {
                ctlAdminMaster.ErrorMessage = "Airline Code Can't be Empty";
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(AirlineName, @"^[a-zA-Z -]+$"))
            {
                ctlAdminMaster.ErrorMessage = "Airline name can contain only alphabets and hyphen(-)";
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(AirlineCode, @"^[a-zA-Z0-9 -]+$"))
            {
                ctlAdminMaster.ErrorMessage = "Airline code can contain only alphabets, digits and hyphen(-)";
                e.Cancel = true;
            }
            else
            {
                ctlAdminMaster.ErrorMessage = "";
            }
            //if(e.NewValues[""]
        }

        protected void grdAirline_PageIndexChanged(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
        }

        protected void lbtPreviousPage_Click(object sender, EventArgs e)
        {
            ctlAdminMaster.BuildPager(grdAirline);
        }
        protected void lbtNextPage_Click(object sender, EventArgs e)
        {
            ctlAdminMaster.BuildPager(grdAirline);
        }
    }
}
