using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace AlohaPcapParser
{
    class TcpSender : IDisposable
    {
        private const string IpAddress = "10.10.2.208";
        private readonly int Port = 7118;


        private TcpClient _tcpClient = null;
        private NetworkStream _networkStream = null;

        public TcpSender()
        {
        }

        public void Connect()
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect(IpAddress, Port);
            _networkStream = _tcpClient.GetStream();
        }

        public void Send(byte[] data)
        {
            _networkStream.Write(data, 0, data.Length);
        }

        public void Disconnect()
        {
            Dispose();
        }

        #region IDisposable

        public void Dispose()
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
            }

            if (_networkStream != null)
            {
                _networkStream.Close();
            }
        }

        #endregion

        
    }
}
