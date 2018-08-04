using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Web.Security;

namespace HappyTripWebApp.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl);
            }

            RegisterHyperLink.NavigateUrl = "~/Account/Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            if (System.Web.Security.Roles.IsUserInRole(LoginUser.UserName, "Administrator"))
            {
                Response.Redirect("~/Admin/Home.aspx");
            }
        }
    }
}
