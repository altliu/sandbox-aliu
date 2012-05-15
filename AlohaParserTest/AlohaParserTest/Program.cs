using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
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

            SpyMessage spyMessage = new SpyMessage();
            Console.WriteLine("Size: " + Marshal.SizeOf(spyMessage));

            if (IsSerial)
            {
                string[] ports = SerialPort.GetPortNames();

                _serialStream = new SerialStream("COM16", 2400);
                _serialStream.DataReceived += new Action<byte[]>(callBack);
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

            int length = _buffer.PeekInt();
            Logger.Log("Length is: " + length);
            while (length < _buffer.Length)
            {
                if (_buffer.Length >= length + 4)
                {
                    byte[] lengthBytes = new byte[4];
                    _buffer.Read(lengthBytes, 0, lengthBytes.Length);

                    byte[] data = new byte[length];
                    _buffer.Read(data, 0, data.Length);
                    _parser.ParseByMarshal(data);
                    _parser.ParseByRead(data);
                }

                if (_buffer.Length > 3)
                {
                    length = _buffer.PeekInt();
                    Logger.Log("Length is: " + length);
                }
                else
                {
                    length = int.MaxValue;
                }
            }
        }
    }
}
