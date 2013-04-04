using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kana
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetFile = @"C:\Users\j1013187\Documents\AEON\20130404\Citrix Performance\Tool\pingResult_AEON.txt";
            if (args.Length > 0)
            {
                targetFile = args[0];
            }

            StreamReader sr = new StreamReader(targetFile);
            String line = sr.ReadLine();
            String rectime = "";
            while (sr.Peek() >= 0)
            {
                if (line == null || line.Equals(string.Empty))
                {
                }
                else if (line.StartsWith("Pinging") || line.StartsWith("Reply") || line.StartsWith("Request"))
                {
                }
                else if (line.StartsWith("Ping statistics") || line.StartsWith("    Packets:") || line.StartsWith("Approximate"))
                {
                }
                else if (line.StartsWith("    Minimum"))
                {
                    //Console.Out.WriteLine(line);
                    line = line.Trim();
                    line = line.Replace("ms", "");
                    line = line.Replace("=", "");
                    line = line.Replace(" ", "");
                    line = line.Replace("Minimum", "");
                    line = line.Replace("Maximum", "");
                    line = line.Replace("Average", "");
                    Console.Out.WriteLine(rectime + "," + line);
                    //String min, max, ave;


                }
                else
                {
                    rectime = line.Trim();
                }

                line = sr.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
