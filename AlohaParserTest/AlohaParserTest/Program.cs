using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using TCP_Listener;

namespace AlohaParserTest
{
    class Program
    {
        private static bool IsSerial = false;

        private static AlohaMessageGenerator _messageGenerator = new AlohaMessageGenerator();
        private static AlohaParser _parser = new AlohaParser();

        private static TCPListener _tcpListener;
        private static SerialStream _serialStream;
        private static FifoBuffer _buffer = new FifoBuffer();


        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            //byte[] bytes = _messageGenerator.GetMessage();
            //string byteString = BitConverter.ToString(bytes);

            if (IsSerial)
            {
                _serialStream = new SerialStream("COM1", 2400);
                _serialStream.Start();
            }
            else
            {
                _tcpListener = new TCPListener(7118, false, callBack);
                _tcpListener.Start();
            }
            Console.WriteLine("Listening...");

            Console.ReadLine();
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            _buffer.Close();
            _tcpListener.Stop();
        }

        private static void callBack(byte[] bytes)
        {
            Logger.Log("Received " + bytes.Length + " bytes.");
            Logger.Log(BitConverter.ToString(bytes));

            _buffer.Write(bytes, 0, bytes.Length);

            int length = 0;
            while (length < _buffer.Length)
            {
                length = _buffer.PeekByte();
                Logger.Log("Length is: " + length);
                if (_buffer.Length >= length + 1)
                {
                    _buffer.ReadByte();
                    byte[] data = new byte[length];
                    _buffer.Read(data, 0, data.Length);
                    _parser.ParseByMarshal(data);
                    _parser.ParseByRead(data);
                }
            }
        }
    }
}
