using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Transaction;

namespace HappyTrip.Model.BusinessLayer.Transaction
{
	/// <summary>
	/// Manager class for handling travel miles
	/// </summary>
    public class HappyMilesManager : IHappyMiles
    {
		/// <summary>
		/// Method to retrieve the travel miles for users
		/// </summary>
		/// <param name="userName">name of the user whose travel miles needs to be retrieved</param>
		/// <returns>The number of travel miles accumulated</returns>
        public int GetHappyMilesForUser(string userName)
        {
            IHappyMilesDAO happyMilesDAO = HappyMilesFactory.CreateHappyMilesDAO();
            int happyMiles = 0;

            try
            {
				happyMiles = happyMilesDAO.GetHappyMilesForUser(userName);
            }
            catch (Exception)
            {
                throw;
            }

            return happyMiles;
        }

        
		/// <summary>
		/// Method to update the travel miles for a user
		/// </summary>
		/// <param name="userName">The name of the user</param>
		/// <param name="travelMiles">the number of miles to be updated</param>
		/// <returns>The boolean status of the result</returns>
		public int UpdateHappyMilesForUser(string userName, List<int> airlines, double ticketCost, string bookingRefNo)
        {
			IHappyMilesDAO happyMilesDAO = HappyMilesFactory.CreateHappyMilesDAO();
			int happyMiles = 0;
			bool isSucceeded = false;

			try
			{
				//Logic to calculate the happy miles
				HappyMilesService.HappyMilesData hmData = null;
				HappyMilesService.HappyMilesProgram hmProgram = new HappyMilesService.HappyMilesProgram();

				foreach (int airline in airlines)
				{
                    hmData = hmProgram.GetHappyMilesDataForAirline(airline);
					if (hmData != null)
					{
						if (hmData.MinimumAmount <= ticketCost)
						{
                            //Original Implementation
                            double actualAmoutInConsideration = ticketCost - hmData.ExemptedAmount;
                            //double actualAmoutInConsideration = ticketCost;
							happyMiles += (int)actualAmoutInConsideration ;
						}
					}
				}

				isSucceeded = happyMilesDAO.UpdateHappyMilesForUser(userName, happyMiles, bookingRefNo);
			}
			catch (Exception)
			{
				throw;
			}
			return happyMiles;
        }


        public int GetHappyMilesForBookingReference(string bookingRefNo)
        {
            try
            {
                IHappyMilesDAO happyMilesDAO = HappyMilesFactory.CreateHappyMilesDAO();
                return happyMilesDAO.GetHappyMilesForBookingReference(bookingRefNo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
