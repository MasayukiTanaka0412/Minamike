using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chiaki
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetFile = @"C:\Users\j1013187\Documents\AEON\20130404\Citrix Performance\Tool\result_AEON.txt";
            if (args.Length > 0)
            {
                targetFile = args[0];
            }

            StreamReader sr = new StreamReader(targetFile);

            String recTime = null;
            int recCount = 0;
            double sumSeconds = double.Epsilon;
            String line = sr.ReadLine();
            while (sr.Peek() >= 0)
            {
                if (line.StartsWith("Target:"))
                {
                    //Console.Out.WriteLine("Count=" + recCount);
                    if (sumSeconds > double.Epsilon)
                    {
                        Console.Out.WriteLine(recTime + "," + sumSeconds / (recCount - 1));
                    }
                    sr.ReadLine();
                    sr.ReadLine();
                    recTime = null;
                    recCount = 0;
                    sumSeconds = double.Epsilon;
                }
                else if (line.StartsWith("Current Time:"))
                {
                    recTime = line.Substring(13);
                    sr.ReadLine();
                    //Console.Out.WriteLine(recTime);
                }
                else
                {
                    String[] elements = line.Split(",".ToCharArray());
                    if (recCount > 0)
                    {
                        //Console.Out.WriteLine(elements[1]);
                        TimeSpan ts = TimeSpan.Parse(elements[1]);
                        //Console.Out.WriteLine(ts.TotalSeconds);
                        sumSeconds = sumSeconds + ts.TotalSeconds;
                    }
                    recCount++;
                }
                
                line = sr.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
