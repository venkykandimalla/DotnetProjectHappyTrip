using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Log;

namespace HappyTrip.Model.BusinessLayer.Log
{
	public interface ILogger
	{
		bool WriteToLog(LogMessage message);
	}
}
