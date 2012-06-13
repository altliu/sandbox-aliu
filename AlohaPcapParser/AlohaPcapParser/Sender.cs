using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tamir.IPLib;
using Tamir.IPLib.Packets;

namespace AlohaPcapParser
{
    class Sender
    {
        private Thread _workerThread;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private bool _kill = false;

        private string source = "192.168.10.17";
        private string destination = "192.168.10.210";
        private string filePath = @"D:\Aloha\Data\7.pcap";
        private string _path = @"D:\Aloha\Data";

        private AlohaParser _parser = new AlohaParser();
        private Dictionary<string, ConnectionData> _connectionDatas = new Dictionary<string, ConnectionData>();
        private int _counter;

        public Sender()
        {
            _workerThread = new Thread(worker);
        }

        public void Start()
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect("10.10.2.208", 7118);
            _networkStream = _tcpClient.GetStream();
            
            _workerThread.Start();
        }

        public void Stop()
        {
            _kill = true;

            // TODO:
        }

        private void worker()
        {
            string[] files = Directory.GetFiles(_path);

            foreach (string file in files)
            {
                if (!file.EndsWith(".pcap"))
                {
                    continue;
                }

                _connectionDatas.Clear();

                PcapOfflineDevice device = SharpPcap.GetPcapOfflineDevice(file);
                device.PcapOpen();

                Packet packet;
                do
                {
                    packet = device.PcapGetNextPacket();

                    TCPPacket tcpPacket = packet as TCPPacket;
                    if (tcpPacket == null)
                    {
                        continue;
                    }

                    if (!tcpPacket.SourceAddress.Equals(source) || !tcpPacket.DestinationAddress.Equals(destination))
                    {
                        continue;
                    }

                    ConnectionData connectionData;
                    if (!_connectionDatas.TryGetValue(getPacketId(tcpPacket), out connectionData))
                    {
                        connectionData = new ConnectionData();
                        _connectionDatas.Add(getPacketId(tcpPacket), connectionData);
                    }

                    //Logger.WriteConsole("Got Packet: " + packet);)
                    if (tcpPacket.Data.Length > 0)
                    {
                        if (tcpPacket.SequenceNumber != connectionData.Sequence && connectionData.Sequence != -1)
                        {
                            connectionData.PacketCache.Add(tcpPacket);
                        }
                        else if (connectionData.Sequence == -1 || connectionData.Sequence == tcpPacket.SequenceNumber)
                        {
                            sendBytes(tcpPacket.Data);
                            connectionData.Sequence = tcpPacket.SequenceNumber + tcpPacket.PayloadDataLength;

                            List<TCPPacket> remove = new List<TCPPacket>();
                            foreach (TCPPacket outOfOrderPacket in connectionData.PacketCache)
                            {
                                if (connectionData.Sequence == outOfOrderPacket.SequenceNumber)
                                {
                                    remove.Add(outOfOrderPacket);
                                    sendBytes(outOfOrderPacket.Data);
                                    connectionData.Sequence = outOfOrderPacket.SequenceNumber + outOfOrderPacket.PayloadDataLength;
                                }
                            }

                            foreach (TCPPacket tcpPacket1 in remove)
                            {
                                connectionData.PacketCache.Remove(tcpPacket1);
                            }
                        }

                    }
                } while (packet != null);

                foreach (KeyValuePair<string, ConnectionData> connectionData in _connectionDatas)
                {
                    Logger.Log("Remaining packets: " + connectionData.Value.PacketCache.Count);
                    foreach (TCPPacket tcpPacket in connectionData.Value.PacketCache)
                    {
                        Logger.WriteConsole("SN: " + tcpPacket.SequenceNumber);
                    }
                }
            }
        }

        private string getPacketId(TCPPacket packet)
        {
            return string.Format("{0}:{1} - {2}:{3}", packet.SourceAddress, packet.SourcePort, packet.DestinationAddress, packet.DestinationPort);
        }

        private void sendBytes(byte[] bytes)
        {
            _networkStream.Write(bytes, 0, bytes.Length);
            Console.WriteLine("Sent: " + _counter++);
            Thread.Sleep(2000);
        }

        private void parseBuffer(ConnectionData connectionData)
        {
            if (connectionData.Buffer.Length > 3)
            {
                int length = connectionData.Buffer.PeekInt();
                Logger.WriteConsole("Length is: " + length);

                if (length > 200)
                {
                    throw new Exception("BLAHHHHHH");
                }

                if (connectionData.Buffer.Length >= length + 4)
                {
                    byte[] lengthBytes = new byte[4];
                    connectionData.Buffer.Read(lengthBytes, 0, lengthBytes.Length);

                    byte[] data = new byte[length];
                    connectionData.Buffer.Read(data, 0, data.Length);
                    //_parser.ParseByMarshal(data);
                    _parser.ParseByRead(data);
                    parseBuffer(connectionData);
                }
            }
        }

        private class ConnectionData
        {
            public FifoBuffer Buffer = new FifoBuffer();
            public long Sequence = -1;
            public List<TCPPacket> PacketCache = new List<TCPPacket>();
        }
    }
}
