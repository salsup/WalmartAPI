using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WMNotifications.Models;

namespace WMNotifications.Utility
{
    public enum WMMethods
    {
        Orders
    }
    public class WebrequestHelper
    {
        string _BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public T DoWebRequest<T>(string method)
        {
            try
            {
                var url = string.Concat(_BaseUrl, method);
                var webRequest = System.Net.WebRequest.Create(new Uri(url));
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    var creds = SecurityHelper.KeyFile(url);
                    webRequest.Headers.Add("WM_SVC.NAME", WMCredentials.ServiceName);
                    webRequest.Headers.Add("WM_SEC.AUTH_SIGNATURE", creds.AccessKey);
                    webRequest.Headers.Add("WM_CONSUMER.ID", WMCredentials.ConsumerId);
                    webRequest.Headers.Add("WM_CONSUMER.CHANNEL.TYPE", WMCredentials.ChannelType);

                    webRequest.Headers.Add("WM_SEC.TIMESTAMP", creds.Timestamp.ToString());
                    webRequest.Headers.Add("WM_QOS.CORRELATION_ID", WMCredentials.CorrelationId);

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                            return JsonConvert.DeserializeObject<T>(jsonResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return default(T);
        }
     
    }
}
