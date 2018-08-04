using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
	static class BusinessObjectManager
	{
		// Updated Version
		public static IAirTravelManager GetCityManager()
		{
			HttpContext context = HttpContext.Current;
			ICityManager cm = (ICityManager)context.Session["CITYMANAGER"];
			if (cm == null)
			{
				cm = (ICityManager)AirTravelManagerFactory.Create("CityManager");
				context.Session["CITYMANAGER"] = cm;
			}
			return cm;
		}

		public static IAirTravelManager GetRouteManager()
		{
			HttpContext context = HttpContext.Current;
			IRouteManager rm = (IRouteManager)context.Session["ROUTEMANAGER"];
			if (rm == null)
			{
				rm = (IRouteManager)AirTravelManagerFactory.Create("RouteManager");
				context.Session["ROUTEMANAGER"] = rm;
			}
			return rm;
		}
	}
}