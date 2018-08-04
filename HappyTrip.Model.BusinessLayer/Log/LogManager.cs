using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Log;

namespace HappyTrip.Model.BusinessLayer.Log
{
	public static class LogManager
	{
		public static void WriteToLog(LogMessage message)
		{
			LogFactory.Create().WriteToLog(message);
		}
	}
}
