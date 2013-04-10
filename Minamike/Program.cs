using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace Minamike
{
    class Program
    {
        const string DEFAULT_TARGET_URL = "https://aeon-test.jdadelivers.com/Citrix/XenApp/media/CitrixXenApp.png";
        const int DEFAULT_RETRY_COUNT = 50;
        const int DEFAULT_INTERVALIN_MSEC = 1000;
        static void Main(string[] args)
        {
            Thread.GetDomain().UnhandledException += new
        UnhandledExceptionEventHandler(Application_UnhandledException);
            
            string targetURL = DEFAULT_TARGET_URL;
            int retryCount = DEFAULT_RETRY_COUNT;
            int interval = DEFAULT_INTERVALIN_MSEC;

            if (args.Length > 0)
            {
                targetURL = args[0];
            }
            if (args.Length > 1)
            {
                retryCount = int.Parse(args[1]);
            }
            if (args.Length > 2)
            {
                interval = int.Parse(args[2]);
            }

            if (args.Length > 1)
            {
                retryCount = int.Parse(args[1]);
            }

            System.Console.Out.WriteLine("Target:" + targetURL);
            System.Console.Out.WriteLine("Retry Count:" + retryCount);
            System.Console.Out.WriteLine("Interval:" + interval + "msec");
            System.Console.Out.WriteLine("Current Time:" + DateTime.Now);

            System.Console.Out.WriteLine("Bytes Received, Time Taken");
            for (int currentcount = 0; currentcount < retryCount; currentcount++)
            {
                string dummy = "?dummy=" + Guid.NewGuid().ToString();
                WebClient wc = new WebClient();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                byte[] data = wc.DownloadData(targetURL + dummy);
                sw.Stop();

                TimeSpan ts = sw.Elapsed;
                System.Console.Out.WriteLine(data.Length + "," + ts);
                //System.Console.Out.WriteLine(targetURL + dummy);
                System.Threading.Thread.Sleep(interval);
            }
            //System.Console.ReadLine();
        }

        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                Console.Out.WriteLine("Application_UnhandledException");
            }
        }
    }
}
