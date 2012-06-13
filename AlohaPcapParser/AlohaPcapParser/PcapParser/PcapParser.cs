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
    public class PcapParser
    {
        public event Action<byte[]> DataCallback;

        private string source = "192.168.10.17";
        private string destination = "192.168.10.210";
        private string _path = @"D:\Aloha\Data";

        //private AlohaParser _parser = new AlohaParser();
        private Dictionary<string, ConnectionData> _connectionDatas = new Dictionary<string, ConnectionData>();
        //private int _counter;
        private Thread _thread;
        private bool _working = false;
        private string[] _files;

        public void Start(string[] files)
        {
            _files = files;
            _working = true;
            _connectionDatas.Clear();

            _thread = new Thread(workerThread);
            _thread.Name = "Pcap Parser Worker Thread";
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Stop()
        {
            _working = false;
        }

        private void workerThread()
        {
            foreach (string file in _files)
            {
                if (!file.EndsWith(".pcap"))
                {
                    continue;
                }

                Logger.Log("Processing PCAP file: " + file);

                _connectionDatas.Clear();

                PcapOfflineDevice device = SharpPcap.GetPcapOfflineDevice(file);
                device.PcapOpen();

                int outOfOrderCount = 0;
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
                            outOfOrderCount++;
                            connectionData.PacketCache.Add(tcpPacket);
                        }
                        else if (connectionData.Sequence == -1 || connectionData.Sequence == tcpPacket.SequenceNumber)
                        {
                            handleBytes(tcpPacket.Data);
                            connectionData.Sequence = tcpPacket.SequenceNumber + tcpPacket.PayloadDataLength;

                            List<TCPPacket> remove = new List<TCPPacket>();
                            foreach (TCPPacket outOfOrderPacket in connectionData.PacketCache)
                            {
                                if (connectionData.Sequence == outOfOrderPacket.SequenceNumber)
                                {
                                    remove.Add(outOfOrderPacket);
                                    handleBytes(outOfOrderPacket.Data);
                                    connectionData.Sequence = outOfOrderPacket.SequenceNumber + outOfOrderPacket.PayloadDataLength;
                                }
                            }

                            foreach (TCPPacket tcpPacket1 in remove)
                            {
                                connectionData.PacketCache.Remove(tcpPacket1);
                            }
                        }

                    }
                } while (packet != null && _working);

                Logger.WriteConsole("Out of Order Count: " + outOfOrderCount);

                foreach (KeyValuePair<string, ConnectionData> connectionData in _connectionDatas)
                {
                    Logger.Log("(" + connectionData.Key + ") Remaining packets: " + connectionData.Value.PacketCache.Count);
                    foreach (TCPPacket tcpPacket in connectionData.Value.PacketCache)
                    {
                        Logger.WriteConsole("\tSN: " + tcpPacket.SequenceNumber);
                    }
                }

                Logger.WriteConsole(string.Empty);
            }
        }

        private string getPacketId(TCPPacket packet)
        {
            return string.Format("{0}:{1} - {2}:{3}", packet.SourceAddress, packet.SourcePort, packet.DestinationAddress, packet.DestinationPort);
        }

        private void handleBytes(byte[] bytes)
        {
            if (DataCallback != null)
            {
                DataCallback(bytes);
            }

            //_networkStream.Write(bytes, 0, bytes.Length);
            //Console.WriteLine("Sent: " + _counter++);
            //Thread.Sleep(2000);
        }

        private class ConnectionData
        {
            public FifoBuffer Buffer = new FifoBuffer();
            public long Sequence = -1;
            public List<TCPPacket> PacketCache = new List<TCPPacket>();
        }
    }
}
