using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.Search;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ISearchManager Manager = SearchManagerFactory.GetInstance().Create();
            City From = new City();
            From.CityId = 32;
            From.Name = "Bangalore";

            City To = new City();
            To.CityId = 58;
            To.Name = "Bangalore";

            SearchInfo info = new SearchInfo();
            info.FromCity = From; 
            info.ToCity = To;
            info.Direction = TravelDirection.Return;
            info.Class = TravelClass.Economy;

            Manager.SearchForFlights(info);

            
        }
    }
}
