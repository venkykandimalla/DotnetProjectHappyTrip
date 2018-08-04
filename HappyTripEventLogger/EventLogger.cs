using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.BusinessLayer.Log;
using System.Diagnostics;

namespace HappyTripEventLogger
{
	public class EventLogger : ILogger
	{

		public EventLogger()
		{
		}

		public EventLogger(object param)
		{
		}

		#region ILogger Members

		public bool WriteToLog(HappyTrip.Model.Entities.Log.LogMessage message)
		{
			EventLog evt = new EventLog();
			StringBuilder sb = new StringBuilder();
            bool isSuccessful = true;
            try
            {
                sb.Append("=====HappyTripLog: Start=======\n");
                sb.AppendFormat("Message: {0}\n", message.Message);
                sb.AppendFormat("Class Name: {0}\n", message.ClassName);
                sb.AppendFormat("Method Name: {0}\n", message.MethodName);
                sb.AppendFormat("Time of Log: {0}\n", message.MessageDateTime.ToLongTimeString() + ", " + message.MessageDateTime.ToLongDateString());
                sb.Append("=====HappyTripLog: End=======\n");

                string logMessage = sb.ToString();

                evt.Source = "Application";
                evt.WriteEntry(logMessage, EventLogEntryType.Error);
            }
            catch (Exception)
            {
                isSuccessful = false;
            }

            return isSuccessful;
		}

		#endregion
	}
}
