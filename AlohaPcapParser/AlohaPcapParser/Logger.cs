using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlohaPcapParser
{
    class Logger
    {
        private static object _lock = new object();
        private static string _logFile = "log.txt";

        ~Logger()
        {
            if (File.Exists(_logFile))
            {
                File.Delete(_logFile);
            }
        }

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

        public static void WriteConsole(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
