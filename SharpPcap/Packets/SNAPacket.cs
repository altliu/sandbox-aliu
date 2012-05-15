using System;
using System.Collections.Generic;
using System.Text;
using Tamir.IPLib.Packets.Util;


namespace Tamir.IPLib.Packets
{
    [Serializable]
    public class SNAPacket : EthernetPacket, IComparable
    {
        #region private fields
        private byte[] _data;
        private int _SNADataLength;
        private bool _firstInChain;
        private bool _lastInChain;
        private int _sequenceNumber;
        private int _destinationAddress;
        private int _originAddress;
        #endregion

        #region lifetime
        
        public SNAPacket(int lLen, byte[] bytes): base(lLen, bytes)
        {
            if (!SNAOverEthernetProtocol.IsSNAPacket(lLen, EthernetData))
            {
                throw new Exception("This is not an SNA over Ethernet Packet.");
            }
            
            DestinationAddress = SNAOverEthernetProtocol.GetDestinationAddress(EthernetData);
            OriginAddress = SNAOverEthernetProtocol.GetOriginAddress(EthernetData);
            SequenceNumber = SNAOverEthernetProtocol.GetSequenceNumber(EthernetData);
            FirstInChain = SNAOverEthernetProtocol.IsFirstInChain(EthernetData);
            LastInChain = SNAOverEthernetProtocol.IsLastInChain(EthernetData);
            Data = SNAOverEthernetProtocol.GetSNAPacketData(EthernetData);
            SNADataLength = Data.Length;
        }
        
        #endregion

        #region properties
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public bool FirstInChain
        {
            get { return _firstInChain; }
            set { _firstInChain = value; }
        }

        public bool LastInChain
        {
            get { return _lastInChain; }
            set { _lastInChain = value; }
        }

        public int SequenceNumber
        {
            get { return _sequenceNumber; }
            set { _sequenceNumber = value; }
        }

        public int DestinationAddress
        {
            get { return _destinationAddress; }
            set { _destinationAddress = value; }
        }

        public int OriginAddress
        {
            get { return _originAddress; }
            set { _originAddress = value; }
        }

        public int SNADataLength
        {
            get { return _SNADataLength; }
            set { _SNADataLength = value; }
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is SNAPacket)
            {
                SNAPacket packetInfo = (SNAPacket)obj;
                int compareResult = SequenceNumber.CompareTo(packetInfo.SequenceNumber);
                if (compareResult == 0)
                {
                    return -(SNADataLength.CompareTo(packetInfo.SNADataLength));
                }
                return compareResult;
            }
            throw new ArgumentException("Object is not of type PacketInfo");
        }

        #endregion
    }
}
