using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlinesMilesProgramService
{
	/// <summary>
	/// Entity class to be shared with the HappyTrip web Application
	/// </summary>
	[Serializable]
	public class HappyMilesData
	{
		/// <summary>
		/// Parameterless constructor required for serialization
		/// </summary>
		public HappyMilesData()
		{
		}

		/// <summary>
		/// Parametereized constructor required for list construction
		/// </summary>
		/// <param name="airlineId"></param>
		/// <param name="minAmt"></param>
		/// <param name="exemptAmt"></param>
		public HappyMilesData(int airlineId, double minAmt, double exemptAmt)
		{
			AirlineId = airlineId;
			MinimumAmount = minAmt;
			ExemptedAmount = exemptAmt;
		}

		public int AirlineId { get; set; }
		public double MinimumAmount { get; set; }
		public double ExemptedAmount { get; set; }
	}
}
