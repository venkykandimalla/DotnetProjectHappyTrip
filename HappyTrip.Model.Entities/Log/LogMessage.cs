using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Log
{
	[Serializable]
	public class LogMessage
	{
		public string Message { get; set; }
		public string ClassName { get; set; }
		public string MethodName { get; set; }
		public DateTime MessageDateTime { get; set; }
		public String ExceptionType { get; set; }
	}
}
