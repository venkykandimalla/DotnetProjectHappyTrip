using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AirlinesMilesProgramService
{
    /// <summary>
    /// Summary description for TravelMilesProgram
    /// </summary>
    [WebService(Namespace = "http://happymilesprogram.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HappyMilesProgram : System.Web.Services.WebService
    {
		static List<HappyMilesData> lstHappyMiles = new List<HappyMilesData>()
		{
			new HappyMilesData(2, 2000, 0),
			new HappyMilesData(5, 4000, 1000),
			new HappyMilesData(6, 5000, 0),
			new HappyMilesData(7, 3000, 1000),
			new HappyMilesData(8, 2000, 1000)
		};
        public HappyMilesProgram()
        {
            
        }

        /// <summary>
        /// Method to add airlines for participating in the happymiles program temporarily
        /// </summary>
        /// <param name="airlineID">Airline ID</param>
        /// <param name="minBookingAmt">Minimum Booking Amout</param>
        /// <param name="amtExempted">Amount Exempted from calculating the happy miles</param>
        /// <returns>A boolean value if the addtion is successful</returns>
        public bool AddAirline(int airlineID, double minBookingAmt, double amtExempted)
        {
            lstHappyMiles.Add(new HappyMilesData(airlineID, minBookingAmt, amtExempted));
            return true;
        }

        /// <summary>
        /// Method to retrive the happy miles data for a given airline
        /// </summary>
        /// <param name="airlineID">Airline ID</param>
        /// <param name="hmData">HappyMiles Data containing the </param>
        /// <returns></returns>
        [WebMethod]
        public HappyMilesData GetHappyMilesDataForAirline(int airlineID)
        {
            foreach (HappyMilesData hmd in lstHappyMiles)
            {
                if (hmd.AirlineId == airlineID)
                {
                    return hmd;
                }
            }
            return null;
        }

		/// <summary>
		/// Method to get all the airlines happy miles data
		/// </summary>
		/// <returns>List of happy miles data</returns>
		public List<HappyMilesData> GetHappyMilesDataForAllAirlines()
		{
			return lstHappyMiles;
		}
    }
}
