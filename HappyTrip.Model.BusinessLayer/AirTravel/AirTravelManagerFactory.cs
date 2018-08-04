using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
	public static class AirTravelManagerFactory
	{
		/// <summary>
		/// Method to create the manager objects using reflections and config file
		/// </summary>
		/// <param name="manager">String that represents the manager</param>
		/// <returns></returns>
		public static IAirTravelManager Create(string manager)
		{
			try
			{
				IAirTravelManager airtravelManager = null;
				AppSettingsReader asr = new AppSettingsReader();

				string mgrClassName = asr.GetValue(manager, typeof(string)).ToString();

				Assembly asm = Assembly.GetExecutingAssembly();
				object objManager = asm.CreateInstance(mgrClassName);
				airtravelManager = (IAirTravelManager)objManager;

				return airtravelManager;
			}
			catch (AirlineManagerException ae)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw;
			}

		}
	}
}
