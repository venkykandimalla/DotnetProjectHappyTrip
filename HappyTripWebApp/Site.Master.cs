using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.UserAccount;
using System.Web.Security;
using HappyTrip.Model.BusinessLayer.Transaction;

namespace HappyTripWebApp
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsersCount.Text = Application["OnlineUsersCount"].ToString();

            if (!IsPostBack)
            {
                ShowHappyMilesForUser();
            }
        }

        public void ShowHappyMilesForUser()
        {
            if (Request.IsAuthenticated)
            {
                lblMiles.Text = "Miles to redeem: ";
                try
                {
                    MembershipUser mUser = Membership.GetUser();
                    string userName = mUser.UserName;
                    HappyMilesManager tmm = new HappyMilesManager();
                    int tm = tmm.GetHappyMilesForUser(userName);
                    lblMiles.Text += tm.ToString();
                }
                catch (Exception)
                {
                    lblMiles.Text += "Error!";
                }
            }
        }
    }
}

