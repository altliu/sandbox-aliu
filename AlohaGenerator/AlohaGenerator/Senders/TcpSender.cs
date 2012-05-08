using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AlohaGenerator
{
    class TcpSender
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;

        public TcpSender()
        {

        }

        public void Start(IPEndPoint endPoint)
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
            }

            _tcpClient = new TcpClient(endPoint);
            _stream = _tcpClient.GetStream();
        }

        public void SendBytes(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }

        public void SendString(string message, Encoding encoding)
        {
            byte[] data = encoding.GetBytes(message);
            _stream.Write(data, 0, data.Length);
        }

        public void Stop()
        {
            if (_stream != null)
                _stream.Close();

            if (_tcpClient != null)
                _tcpClient.Close();
        }
    }
}
