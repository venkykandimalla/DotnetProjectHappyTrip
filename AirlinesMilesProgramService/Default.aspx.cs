using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlinesMilesProgramService
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				HappyMilesProgram hmp = new HappyMilesProgram();
				grdAirlines.DataSource = hmp.GetHappyMilesDataForAllAirlines();
				grdAirlines.DataBind();
			}
		}

		protected void btnAddAirlines_Click(object sender, EventArgs e)
		{
			HappyMilesProgram hmp = new HappyMilesProgram();
			int aid = Convert.ToInt32(txtAirlineID.Text);
			double mAmt = Convert.ToDouble(txtMinAmt.Text);
			double eAmt = Convert.ToDouble(txtExmptAmt.Text);

			hmp.AddAirline(aid, mAmt, eAmt);

			grdAirlines.DataSource = hmp.GetHappyMilesDataForAllAirlines();
			grdAirlines.DataBind();
		}
	}
}