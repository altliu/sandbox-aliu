using System;
using System.Collections.Generic;
using System.Text;

namespace Tamir.IPLib.Packets
{
    class SNAOverEthernetProtocol
    {
        public static byte GetDSAP(byte[] bytes)
        {
           return bytes[0];
        }

        public static byte GetSSAP(byte[] bytes)
        {
            return bytes[1];
        }

        public static int GetControlField(byte[] bytes)
        {
            return (bytes[2] << 8) + bytes[1];
        }

        public static bool IsSNAPacket(int lLen, byte[] bytes)
        {
            if(bytes.Length < 15)
            {
                return false;
            }
            byte dsap = GetDSAP(bytes);
            byte ssap = GetSSAP(bytes);
            return (dsap == 0x04) && (ssap == 0x04);
        }

        public static byte GetDestinationAddress(byte[] bytes)
        {
            byte[] snaHeader = GetSNAHeader(bytes);
            return snaHeader[2];          
        }

        public static byte GetOriginAddress(byte[] bytes)
        {
            byte[] snaHeader = GetSNAHeader(bytes);
            return snaHeader[3];
        }

        public static int GetSequenceNumber(byte[] bytes)
        {
            byte[] snaHeader = GetSNAHeader(bytes);
            return (snaHeader[4] << 8) + snaHeader[5];
        }

        public static bool IsFirstInChain(byte[] bytes)
        {
            byte[] snaHeader = GetSNAHeader(bytes);
            byte requestResponseByteZero = snaHeader[6];
            return (requestResponseByteZero & 0x02) > 0;
        }

        public static bool IsLastInChain(byte[] bytes)
        {
            byte[] snaHeader = GetSNAHeader(bytes);
            byte requestResponseByteZero = snaHeader[6];
            return (requestResponseByteZero & 0x01) > 0;
        }

        public static byte[] GetSNAHeader(byte[] bytes)
        {
            return GetSubArray(bytes, 4, 12);
        }
    
        public static byte[] GetSNAPacketData(byte[] bytes)
        {
            return GetSubArray(bytes, 13, bytes.Length - 1);
        }

        public static byte[] GetSubArray(byte[] inputBytes, int startindex, int endindex)
        {
            if (startindex > endindex || 
                startindex >= inputBytes.Length || 
                endindex >= inputBytes.Length || 
                startindex < 0 || endindex <= 0)
            {
                return null;
            }
            byte[] newArray = new byte[endindex - startindex + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = inputBytes[i + startindex];
            }
            return newArray;
        }
    }
}