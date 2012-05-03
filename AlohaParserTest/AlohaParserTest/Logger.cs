using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlohaParserTest
{
    class Logger
    {
        private static object _lock = new object();
        private static string _logFile = "log.txt";
        
        public static void Log(string message)
        {
            lock (_lock)
            {
                using (StreamWriter sw = new StreamWriter(_logFile, true))
                {
                    Console.WriteLine(message);
                    sw.WriteLine(message);
                }
            }
        }
    }
}
