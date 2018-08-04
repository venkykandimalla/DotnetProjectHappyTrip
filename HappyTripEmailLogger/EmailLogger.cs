using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using HappyTrip.Model.BusinessLayer.Log;

namespace HappyTripEmailLogger 
{
	public class EmailLogger : ILogger
	{
		string mailParams;

		public EmailLogger()
		{
		}

		public EmailLogger(object param)
		{
			mailParams = param.ToString();
		}

		#region ILogger Members

		public bool WriteToLog(HappyTrip.Model.Entities.Log.LogMessage message)
		{
			bool isSuccessful = true;
			HttpContext httpContext = HttpContext.Current;
			StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("\n\n=====HappyTripLog: Start=======\n");
                sb.AppendFormat("Message: {0}\n", message.Message);
                sb.AppendFormat("Class Name: {0}\n", message.ClassName);
                sb.AppendFormat("Method Name: {0}\n", message.MethodName);
                sb.AppendFormat("Time of Log: {0}\n", message.MessageDateTime.ToLongTimeString() + ", " + message.MessageDateTime.ToLongDateString());
                sb.Append("=====HappyTripLog: End=======\n\n\n");
                sb.Append("PS: This is an auto generated mail. Please DO NOT REPLY to this mail\n");

                string logMessage = sb.ToString();


                string[] tokens = mailParams.Split('#');
                string fromAddress = tokens[0].Split(':')[1];
                string toAddress = tokens[1].Split(':')[1];
                string smtpAddress = tokens[2].Split(':')[1];

                SmtpClient sc = new SmtpClient();
                if (smtpAddress.Equals("=dir"))
                {
                    sc.PickupDirectoryLocation = httpContext.Server.MapPath("~/LogMail/");
                    sc.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                }

                MailMessage mm = new MailMessage(fromAddress, toAddress);
                mm.Subject = "Email Log for HappyTrip";
                mm.Body = logMessage;

                sc.Send(mm);
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
