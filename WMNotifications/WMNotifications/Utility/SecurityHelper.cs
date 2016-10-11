using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMNotifications.Models;

namespace WMNotifications.Utility
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Pass in URL of Method you would like to get a signed signautre for. You will need java installed on your machine.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WMEncryption KeyFile(string url)
        {
            string logsDirectory = Path.Combine(Environment.CurrentDirectory, "Resource");

            string stdOutput;
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = logsDirectory;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "java.exe";
            p.StartInfo.Arguments = string.Format("-cp wm.jar javadsds.SHA256WithRSAAlgo {0} {1} {2}", WMCredentials.ConsumerId, url, WMCredentials.AuthSignature);
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            var arr = output.Split(new string[] {"|SPLIT|" }, StringSplitOptions.RemoveEmptyEntries);

            return new WMEncryption { AccessKey = arr[1], Timestamp = Convert.ToInt64(arr[0]) };


        }
    }
}
