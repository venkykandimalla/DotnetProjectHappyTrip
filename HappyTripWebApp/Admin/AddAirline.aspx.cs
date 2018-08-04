using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class AddAirline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlAdminMaster.ErrorMessage = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    if (txtcrAirlineName.Text.Length == 0)
                    {
                        ctlAdminMaster.ErrorMessage = "Airline Name Can't be Empty";
                        txtcrAirlineName.Focus();
                    }
                    else if (txtcrAirlineCode.Text.Length == 0)
                    {
                        ctlAdminMaster.ErrorMessage = "Airline Code Can't be Empty";
                        txtcrAirlineCode.Focus();
                    }
                    else
                    {

                        string airlineCode = txtcrAirlineCode.Text;
                        string logoPath = "Images/air_logos/air_logos3.gif";
                        string airlineName = txtcrAirlineName.Text;

                        sdsAirline.InsertParameters["AirlineName"].DefaultValue = airlineName;
                        sdsAirline.InsertParameters["AirlineCode"].DefaultValue = airlineCode;
                        sdsAirline.InsertParameters["AirlineLogo"].DefaultValue = logoPath;
                        if (sdsAirline.Insert() > 0)
                        {
                            ctlAdminMaster.ErrorMessage = "Airlines Added Successfully";
                        }
                        else
                        {
                            ctlAdminMaster.ErrorMessage = "Cannot add new airline, Airlines code already exists";
                        }

                        //Response.Redirect("~/Admin/Home.aspx");
                    }
                }
                catch (AirlineManagerException ex)
                {
                    ctlAdminMaster.ErrorMessage = ex.Message;
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("UNIQUE KEY") > 0)
                    { ctlAdminMaster.ErrorMessage = "Cannot add new airline, Airline already exists."; }
                    else
                    { ctlAdminMaster.ErrorMessage = "Cannot add new airline, please try again."; }
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            /*txtcrAirlineCode.Text = "";
            txtcrAirlineName.Text = "";
            txtcrAirlineLogoPath.Text = "";
            ctlAdminMaster.ErrorMessage = "";
             */
            Response.Redirect("~/Admin/Home.aspx");
        }
    }
}