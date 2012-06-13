using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AlohaPcapParser
{
    class AlohaManager
    {
        private const int Delay = 1000;

        private const string PcapPath = @"D:\Aloha\Data";

        private Thread _workerThread;
        private AlohaParser _alohaParser = new AlohaParser();
        private FifoBuffer _buffer = new FifoBuffer();
        private TcpSender _tcpSender = new TcpSender();
        private PcapParser _currentPcapParser;
        private bool _send;

        public event Action<string> StatusUpdate;

        public void Start(bool send)
        {
            _send = send;

            string[] files = Directory.GetFiles(PcapPath);

            if (send)
            {
                _tcpSender.Connect();
            }

            _currentPcapParser = new PcapParser();
            _currentPcapParser.DataCallback += new Action<byte[]>(handleData);
            _currentPcapParser.Start(files);
        }

        public void Stop()
        {
            _currentPcapParser.DataCallback -= new Action<byte[]>(handleData);
            _currentPcapParser.Stop();
            _tcpSender.Disconnect();
        }

        private void handleData(byte[] data)
        {
            if (_send)
            {
                sendData(data);
            }
            else
            {
                writeData(data);
            }
        }

        //private void doWork()
        //{
        //    string[] files = Directory.GetFiles(PcapPath);

        //    foreach (string file in files)
        //    {
        //        if (file.EndsWith(".pcap"))
        //        {
        //            Logger.Log(file);
        //            PcapParser parser = new PcapParser(file);
        //            //parser.DataCallback += new Action<byte[]>(handleData);
        //            parser.DataCallback += new Action<byte[]>(sendData);

        //            parser.Process();
        //        }
        //    }
        //}

        private void writeData(byte[] data)
        {
            //Logger.Log("Received " + data.Length + " bytes.");
            //Logger.Log(BitConverter.ToString(data));

            _buffer.Write(data, 0, data.Length);

            int length = _buffer.PeekInt();
            //Logger.Log("Length is: " + length);
            
            while (length < _buffer.Length)
            {
                if (_buffer.Length >= length + 4)
                {
                    byte[] lengthBytes = new byte[4];
                    _buffer.Read(lengthBytes, 0, lengthBytes.Length);

                    byte[] body = new byte[length];
                    _buffer.Read(body, 0, body.Length);
                    //_alohaParser.ParseByMarshal(data);
                    string output = _alohaParser.ParseByRead(body);

                    if (StatusUpdate != null)
                    {
                        StatusUpdate(output);
                    }

                    Logger.Log(output);
                }

                if (_buffer.Length > 3)
                {
                    length = _buffer.PeekInt();

                    if (length != 169)
                    {
                        throw new Exception("received invalid length");
                    }

                    //Logger.Log("Length is: " + length);
                }
                else
                {
                    length = int.MaxValue;
                }
            }
        }

        private void sendData(byte[] data)
        {
            try
            {
                if (StatusUpdate != null)
                {
                    StatusUpdate(BitConverter.ToString(data));
                }

                _tcpSender.Send(data);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Thread.Sleep(Delay);
            }
        }

        private void sendFormattedData(byte[] data)
        {
            //Logger.Log("Received " + data.Length + " bytes.");
            //Logger.Log(BitConverter.ToString(data));

            _buffer.Write(data, 0, data.Length);

            int length = _buffer.PeekInt();
            //Logger.Log("Length is: " + length);

            while (length < _buffer.Length)
            {
                if (_buffer.Length >= length + 4)
                {
                    byte[] messageBytes = new byte[4 + length];
                    _buffer.Read(messageBytes, 0, 4);

                    _buffer.Read(messageBytes, 3, messageBytes.Length - 4);
                }

                if (_buffer.Length > 3)
                {
                    length = _buffer.PeekInt();

                    if (length != 169)
                    {
                        throw new Exception("received invalid length");
                    }

                    //Logger.Log("Length is: " + length);
                }
                else
                {
                    length = int.MaxValue;
                }
            }
        }


    }
}
