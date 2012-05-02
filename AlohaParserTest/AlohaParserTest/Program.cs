using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AlohaParserTest
{
    class Program
    {
        private static AlohaParser _parser = new AlohaParser();

        static void Main(string[] args)
        {
            //ArraySegment<byte> arraySegment = new ArraySegment<byte>();
            //arraySegment.

            //LinkedList<ArraySegment<byte>> linkedList = new LinkedList<ArraySegment<byte>>();

            byte[] bytes = _parser.GetMessage();
            string test = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("Converted ({0}): {1}", test.Length, test);
            _parser.ParseBytes1(bytes);
            
            _parser.ParseBytes2(bytes);

            Console.ReadLine();
        }

        private static void DoSomething()
        {
            using (MemoryStream ms = new MemoryStream())
            {

            }
        }
    }
}
