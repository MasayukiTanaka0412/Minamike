using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Haruka
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

            int recCount = 0;
            String line = sr.ReadLine();
            while (sr.Peek() >= 0)
            {
                if (line.StartsWith("Target:"))
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    recCount = 0;
                                    }
                else if (line.StartsWith("Current Time:"))
                {
                    sr.ReadLine();
                                    }
                else
                {
                    String[] elements = line.Split(",".ToCharArray());
                    if (recCount > 0)
                    {
                        TimeSpan ts = TimeSpan.Parse(elements[1]);
                        Console.Out.WriteLine(ts.TotalSeconds);
                    }
                    recCount++;
                }
                line = sr.ReadLine();
            }

            //Console.ReadLine();
        }
    }
}
