using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Hotel;

namespace HappyTripWebApp.Admin
{
    public partial class ManageHotels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server
            Exception exc = Server.GetLastError();
            // Pass the error on to the Generic Error page
            Server.Transfer("~/GenericErrorPage.aspx?err=" + exc.Message, true);
        }
    }
}