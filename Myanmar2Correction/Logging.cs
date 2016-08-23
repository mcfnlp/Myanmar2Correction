using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myanmar2Correction
{
    class Logging
    {
        public static String logger;

        public static void WriteLog()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:/log.txt");
            sw.WriteLine(logger);
            sw.Close();
        }
    }
}
