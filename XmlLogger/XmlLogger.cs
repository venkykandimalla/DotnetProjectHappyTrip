using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.BusinessLayer.Log;
using System.Xml.Serialization;
using HappyTrip.Model.Entities.Log;
using System.Web;
using System.IO;

namespace HappyTripXmlLogger
{
	public class XmlLogger : ILogger
	{
		string xmlLogFile;
		public XmlLogger()
		{
		}

		public XmlLogger(object param)
		{
			xmlLogFile = param.ToString();
		}

		#region ILogger Members

		public bool WriteToLog(LogMessage message)
		{
			bool isSuccessful = true;

            try
            {
                HttpContext httpContext = HttpContext.Current;

                string lf = httpContext.Server.MapPath("~/Log/") + xmlLogFile;

                StreamWriter sw = new StreamWriter(lf, true);

                XmlSerializer xs = new XmlSerializer(typeof(LogMessage));
                xs.Serialize(sw, message);
                sw.Close();
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
