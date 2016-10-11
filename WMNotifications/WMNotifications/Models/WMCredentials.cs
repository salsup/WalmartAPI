using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMNotifications.Models
{
    public static class WMCredentials
    {
        public static string AuthSignature { get { return ConfigurationManager.AppSettings["WMAuthSignature"];  } }

        public static string ConsumerId { get { return ConfigurationManager.AppSettings["WMConsumerId"]; } }

        public static string ServiceName { get { return ConfigurationManager.AppSettings["WMName"]; } }

        public static string ChannelType { get { return ConfigurationManager.AppSettings["WMChannelType"]; } }

        public static string CorrelationId { get { return Guid.NewGuid().ToString(); } }
    }
}
