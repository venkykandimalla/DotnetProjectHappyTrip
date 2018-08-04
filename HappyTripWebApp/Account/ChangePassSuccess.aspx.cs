using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyTripWebApp.Account
{
    public partial class ChangePassSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {

        }

        protected void ContinuePushButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}