using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentGateway.WebHost
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			PaymentGateway.PaymentService pm = new PaymentGateway.PaymentService();
			grdCards.DataSource = pm.GetCards();
			grdCards.DataBind();
        }
    }
}
