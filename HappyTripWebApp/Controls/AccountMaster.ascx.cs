using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyTripWebApp.Controls
{
    public partial class AccountMaster : System.Web.UI.UserControl
    {
        public string ViewControlClientID
        {
            get
            {
                return hlkViewProfile.ClientID;
            }
        }
        //public string UpdateControlClientID
        //{
        //    get
        //    {
        //        return hlkUpdateProfile.ClientID;
        //    }
        //}
        public Control Content { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            phContent.Controls.Add(Content);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}