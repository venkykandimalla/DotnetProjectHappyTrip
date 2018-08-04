using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.BusinessLayer.Log;
using System.IO;
using System.Web;


namespace HappyTripFileLogger
{
	public class FileLogger : ILogger
	{
		string logFile;

		public FileLogger()
		{
		}

		public FileLogger(object param)
		{
			logFile = param.ToString();
		}

		#region ILogger Members

		public bool WriteToLog(HappyTrip.Model.Entities.Log.LogMessage message)
		{
			bool isSuccessful = true;

            try
            {
                HttpContext httpContext = HttpContext.Current;

                string lf = httpContext.Server.MapPath("~/Log/") + logFile;

                StreamWriter sw = new StreamWriter(lf, true);

                StringBuilder sb = new StringBuilder();

                sb.Append("=====HappyTripLog: Start=======\n");
                sb.AppendFormat("Message: {0}\n", message.Message);
                sb.AppendFormat("Class Name: {0}\n", message.ClassName);
                sb.AppendFormat("Method Name: {0}\n", message.MethodName);
                sb.AppendFormat("Time of Log: {0}\n", message.MessageDateTime.ToLongTimeString() + ", " + message.MessageDateTime.ToLongDateString());
                sb.Append("=====HappyTripLog: End=======\n");

                string logMessage = sb.ToString();

                sw.WriteLine(logMessage);

                sw.Close();
                sw.Dispose();
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
