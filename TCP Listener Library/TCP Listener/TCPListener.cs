using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCP_Listener
{
    public delegate void TCPListenerResultCallback(byte[] bytes);
    public delegate void TCPListenerLogCallback (string msg);

    public class TCPListener
    {
        private const string PingMessage = "ping";
        private const int MaxPingTimeouts = 2;

        private TcpListener _server;
        private int _port;
        private Encoding _encoding = Encoding.ASCII;
        private TCPListenerResultCallback _resultCallback;
        private static TCPListenerLogCallback _logCallback;
        private List<TcpConnection> _tcpConnections;
        private bool _closing = false;
        private static bool _sendAck = false;

        private AutoResetEvent _isRunningWaitHandle = new AutoResetEvent(false);

        private static int _numberOfReceivedTransactions = 0;
        private static bool _commitCounter = false;

        public TCPListener(int port, bool sendAck, TCPListenerResultCallback resultCallback)
        {
            try
            {
            _port = port;                
            _sendAck = sendAck;
            _resultCallback = resultCallback;
            _server = new TcpListener(IPAddress.Any, _port);
            _tcpConnections = new List<TcpConnection>();
            }
            catch (Exception ex)
            {
                Log("TcpTransactionStream Init() failed: " + ex);
            }
        }

        public bool Ack
        {
            set { _sendAck = value; }
        }

        public string ID
        {
            get
            {
                return _port.ToString();
            }
        }

        public void Start()
        {
            try
            {
                _server.Start();
                _server.BeginAcceptSocket(acceptSocketCallback, _server);
            }
            catch (Exception ex)
            {
                Log("Exception in TcpTransactionStream.Start(): " + ex);
            }
        }

        public void Stop()
        {
            _closing = true;
            _server.Stop();
            lock (_tcpConnections)
            {
                foreach (TcpConnection connection in _tcpConnections)
                {
                    if (connection.Connected())
                    {
                        Log("Closing connection from " + connection.getRemoteEndpoint() + ".");
                    }
                    connection.Close();
                }
                _tcpConnections.Clear();
            }
        }

        public void SetEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        public TCPListenerLogCallback LoggingCallback
        {
            set { _logCallback = value; }
        }

        private static void Log(string msg)
        {
            if (_logCallback != null)
            {
                _logCallback(msg);
            }
        }

        private void acceptSocketCallback(IAsyncResult ar)
        {
            if (_closing)
            {
                return;
            }

            lock (_tcpConnections)
            {
                try
                {
                    Socket socket = _server.EndAcceptSocket(ar);
                    Log("Connection accepted from " + socket.RemoteEndPoint + ".");
                    _tcpConnections.Add(new TcpConnection(socket, this));
                    _numberOfReceivedTransactions++;
                }
                catch (Exception ex)
                {
                    Log("Exception in TcpTransactionStream.acceptSocketCallback(): " + ex);
                    //Monitor.KillProcess("Error accepting new socket connections");
                }
            }
            try
            {
                _server.BeginAcceptSocket(acceptSocketCallback, _server);
            }
            catch (Exception ex)
            {
                Log("Exception in TcpTransactionStream.acceptSocketCallback(): " + ex);
            }
        }

        private void handleData(byte[] data)
        {
            _resultCallback.BeginInvoke(data, null, null);
        }

        private void receivedPingMessage()
        {
            _isRunningWaitHandle.Set();
            // we added a transaction for this connection but it was really only the ping message
            _numberOfReceivedTransactions--;
        }

        private void removeConnection(TcpConnection connection)
        {
            lock (_tcpConnections)
            {
                try
                {
                    if (connection.Connected())
                    {
                        Log("Closing connection from " + connection.getRemoteEndpoint() + ".");
                    }
                    connection.Close();
                    _tcpConnections.Remove(connection);
                }
                catch (Exception ex)
                {
                    Log("Error removing TcpConnection: " + ex);
                }
            }
        }

        private class TcpConnection
        {
            Socket _socket;
            byte[] _receiveBuffer = new byte[1024];
            TCPListener _owner;

            public TcpConnection(Socket socket, TCPListener owner)
            {
                _socket = socket;
                _owner = owner;

                try
                {
                    _socket.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, receiveCallback, null);
                }
                catch (ObjectDisposedException)
                {
                    // ignore this exception because it only happens when we reset the plugin
                }
                catch (Exception ex)
                {
                    Log("Socket beginreceive failed : " + ex);
                }
            }

            public void Close()
            {
                _socket.Close();
            }

            public bool Connected()
            {
                return _socket.Connected;
            }

            public string getRemoteEndpoint()
            {
                return _socket.RemoteEndPoint.ToString();
            }

            private void receiveCallback(IAsyncResult ar)
            {
                int bytesReceived = 0;

                try
                {
                    bytesReceived = _socket.EndReceive(ar);
                }
                catch (ObjectDisposedException)
                {
                    // ignore this exception because it only happens when we reset the plugin
                }
                catch (SocketException ex)
                {
                    Log("Socket endreceive failed: " + ex);
                }

                if (bytesReceived <= 0)
                {
                    // if the other end is done with the socket, we'll just get a 0
                    // response.
                    _owner.removeConnection(this);
                    return;
                }

                try
                {
                    // add option for continous data stream
                    //_data += _owner._encoding.GetString(_receiveBuffer, 0, bytesReceived);

                    byte[] _data = new byte[bytesReceived];
                    Buffer.BlockCopy(_receiveBuffer, 0, _data, 0, bytesReceived);


                    if (_sendAck)
                    {
                        // TODO: check ack works
                        Byte[] ackBytes = { 0x02, 0x30, 0x30, 0x30, 0x30, 0x30, 0x06, 0x0d };
                        Buffer.BlockCopy(_data, 7, ackBytes, 1, 5);
                        _socket.Send(ackBytes);
                    }

                    _owner.handleData(_data);

                }
                catch (Exception ex)
                {
                    Log("Error parsing data: " + ex);
                }

                try
                {
                    _socket.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, receiveCallback, null);
                }
                catch (ObjectDisposedException)
                {
                    // ignore this exception because it only happens when we reset the plugin
                }
                catch (Exception ex)
                {
                    Log("Socket beginreceive failed: " + ex);
                }
            }
        }
    }
}
