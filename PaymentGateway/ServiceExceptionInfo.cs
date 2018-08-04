using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PaymentGateway
{
    /// <summary>
    /// Class to represent the exceptions thrown by the payment gateway
    /// </summary>
    [DataContract]
    public class ServiceExceptionInfo
    {
        [DataMember]public int ErrorCode { get; set; }
        [DataMember]public string Description { get; set; }
        [DataMember]public string HelpURL { get; set; }
        [DataMember]public DateTime When { get; set; }
    }
}
