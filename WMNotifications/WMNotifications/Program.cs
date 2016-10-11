using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMNotifications.Models.orders;

namespace WMNotifications
{
    class Program
    {
        static void Main(string[] args)
        {
            var wb = new Utility.WebrequestHelper();

            var orders = wb.DoWebRequest<WMOrder>("orders?createdStartDate=2016-08-16");
        }
      
    }
}
