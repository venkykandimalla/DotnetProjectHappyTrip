using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Web;

namespace HappyTrip.Model.BusinessLayer.Log
{
	public class LogFactory
	{
		public static ILogger Create()
		{
			AppSettingsReader asr = new AppSettingsReader();

			string currentReader = (string)asr.GetValue("CurrentLogger", typeof(string));
			string loggerNode = (string)asr.GetValue(currentReader.ToString(), typeof(string));
			string[] tokens = loggerNode.Split(',');

			string assemblyName = tokens[0];
			string className = tokens[1];
			string param = string.Empty;

			if (tokens.Length > 2)
			{
				param = tokens[2];
			}

			HttpContext httpContext = HttpContext.Current;
			

			Assembly asm = Assembly.LoadFrom(httpContext.Server.MapPath("~/bin/")+assemblyName);
			object oLogger = asm.CreateInstance(className, false, BindingFlags.Default, null, new object[]{param}, null, null); ;
			ILogger logger = (ILogger)oLogger;

			return logger;

		}
	}
}
