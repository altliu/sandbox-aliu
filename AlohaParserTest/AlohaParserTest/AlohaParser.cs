using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace AlohaParserTest
{
    class AlohaParser
    {
        private byte[] _headerBytes = new byte[] {0x01, 0x01, 0x02, 0x03, 0x04, 0x01, 0x00, 0x01};
        private byte[] _messageBytes = new byte[] {};

        public void ParseByMarshal(byte[] bytes)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            SpyMessage spyMessage = new SpyMessage();

            int size = Marshal.SizeOf(spyMessage);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(bytes, 0, ptr, size);

            spyMessage = (SpyMessage)Marshal.PtrToStructure(ptr, spyMessage.GetType());
            Marshal.FreeHGlobal(ptr);

            sw.Stop();
            Console.WriteLine("Elapse: " + sw.ElapsedMilliseconds);

            printMessage(spyMessage);  
        }

        public void ParseByRead(byte[] bytes)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms))
            {
                HeaderMessage headerMessage = new HeaderMessage();
                headerMessage.blberProtocol = br.ReadByte();
                headerMessage.uTermId = br.ReadUInt32();
                headerMessage.MsgType = br.ReadByte();
                headerMessage.uCRC = br.ReadUInt16();

                SpyMessage spyMessage = new SpyMessage();
                spyMessage.HeaderMsg = headerMessage;
                spyMessage.szTime = Encoding.ASCII.GetString(br.ReadBytes(9));
                spyMessage.nEmployeeId = br.ReadUInt64();
                spyMessage.szEmployeeName = Encoding.ASCII.GetString(br.ReadBytes(40));
                spyMessage.nManagerId = (ulong) br.ReadInt64();
                spyMessage.szManagerName = Encoding.ASCII.GetString(br.ReadBytes(40));
                spyMessage.nTableId = br.ReadUInt64();
                spyMessage.nCheckId = br.ReadUInt64();
                spyMessage.nTransactionType = br.ReadInt32();
                spyMessage.szDescription = Encoding.ASCII.GetString(br.ReadBytes(40));
                //byte[] amountBytes = br.ReadBytes(8);
                //spyMessage.dAmount = BitConverter.ToDouble(amountBytes, 0);
                spyMessage.dAmount = br.ReadDouble();
                spyMessage.nQuantity = br.ReadInt16();

                Console.WriteLine("PARSE BY READ:");
                //Console.WriteLine("Protocol: " + br.ReadByte());
                //Console.WriteLine("Term ID: " + br.ReadUInt32());
                //Console.WriteLine("Message Type: " + br.ReadByte());
                //Console.WriteLine("UCRC: " + br.ReadUInt16());

                //Console.WriteLine("Time: " + Encoding.ASCII.GetString(br.ReadBytes(9)));
                //Console.WriteLine("Employee ID: " + br.ReadUInt64());
                //Console.WriteLine("Employee: " + Encoding.ASCII.GetString(br.ReadBytes(40)));
                //Console.WriteLine("Manager ID: " + br.ReadInt64());
                //Console.WriteLine("Manager: " + Encoding.ASCII.GetString(br.ReadBytes(40)));
                //Console.WriteLine("Table ID: " + br.ReadUInt64());
                //Console.WriteLine("Check ID: " + br.ReadUInt64());
                //Console.WriteLine("Transaction Type: " + getAlohaType(br.ReadInt32()));
                //Console.WriteLine("Description: " + Encoding.ASCII.GetString(br.ReadBytes(40)));

                //Console.WriteLine("ALL: " + BitConverter.ToString(bytes));
                //byte[] amountBytes = br.ReadBytes(8);
                //Console.WriteLine("HEX1: " + BitConverter.ToString(amountBytes));
                //Array.Reverse(amountBytes);
                //Console.WriteLine("HEX2: " + BitConverter.ToString(amountBytes));
                //Console.WriteLine("Amount: " + BitConverter.ToDouble(amountBytes, 0));
                
                //Console.WriteLine("Quantity: " + br.ReadInt16());    
                //Console.WriteLine();
                printMessage(spyMessage);  
            }
            sw.Stop();
            Console.WriteLine("Elapse: " + sw.ElapsedMilliseconds);
        }

        private string getAlohaType(int typeId)
        {
            if (!Enum.IsDefined(typeof(TransactionTypes), typeId))
            {
                typeId = 0;
            }

            TransactionTypes transactionType = (TransactionTypes)typeId;
            string returnVal = transactionType.ToString();
            returnVal = returnVal.Replace("_", " ");
            return returnVal;
        }

        private void printMessage(SpyMessage spyMessage)
        {
            Console.WriteLine("Protocol: " + spyMessage.HeaderMsg.blberProtocol);
            Console.WriteLine("Term ID: " + spyMessage.HeaderMsg.uTermId);
            Console.WriteLine("Message Type: " + spyMessage.HeaderMsg.MsgType);
            Console.WriteLine("UCRC: " + spyMessage.HeaderMsg.uCRC);

            Console.WriteLine("Time: " + spyMessage.szTime);
            Console.WriteLine("Employee ID: " + spyMessage.nEmployeeId);
            Console.WriteLine("Employee: " + spyMessage.szEmployeeName);
            Console.WriteLine("Manager ID: " + spyMessage.nManagerId);
            Console.WriteLine("Manager: " + spyMessage.szManagerName);
            Console.WriteLine("Table ID: " + spyMessage.nTableId);
            Console.WriteLine("Check ID: " + spyMessage.nCheckId);
            Console.WriteLine("Transaction Type: " + getAlohaType(spyMessage.nTransactionType));
            Console.WriteLine("Description: " + spyMessage.szDescription);
            Console.WriteLine("Amount: " + spyMessage.dAmount);
            Console.WriteLine("Quantity: " + spyMessage.nQuantity);
            Console.WriteLine();
        }


        //Header Message
        //typedef struct
        //{
        //byte bIberProtocol; // Iber Protocol of this message; always 1
        //UINT32 uTermId; // Sending term ID
        //byte MsgType; // Message Type; always 1
        //UINT16 uCRC; // CRC Check; unused
        //} headerMessage;

        //Spy Message
        //typedef struct
        //{
        //headerMessage HeaderMsg;
        //char szTime[9]; // time in HH:MM:SS\0
        //unsigned nEmployeeId; // Employee ID
        //char szEmployeeName[40]; // Employee's Name
        //unsigned nManagerId; // Manager ID
        //char szManagerName[40]; // Manager's Name
        //unsigned long nTableId; // Table ID
        //unsigned long nCheckId; // Check ID
        //int nTransactionType; // Transaction – see below
        //char szDescription[40]; // Description of the Message
        //double dAmount; // Transaction Amount - dollar value
        //int nQuantity; // Quantity of the Transaction
        //} spyMessage;

        protected void handleData(string transactionData)
        {
            //// TODO: move to another thread

            //XmlDocument document = new XmlDocument();
            //document.LoadXml(transactionData);

            //Dictionary<string, string> metadataValues = new Dictionary<string, string>(_patternOutputByMetadataName.Count);
            //foreach (KeyValuePair<string, PatternOutputPair[]> kvp in _patternOutputByMetadataName)
            //{
            //    string metadataValue = string.Empty;
            //    foreach (PatternOutputPair patternOutputPair in kvp.Value)
            //    {
            //        string xmlvalue = getXpathValue(document, patternOutputPair.Pattern);
            //        if (!string.IsNullOrEmpty(xmlvalue))
            //        {
            //            metadataValue += patternOutputPair.Output.Replace("_", xmlvalue);
            //        }
            //    }

            //    metadataValues[kvp.Key] = metadataValue;
            //}

            ////_numberOfReceivedTransactions++;
            //bool committed = false;
            //notifyTransaction(metadataValues, false, ref committed);

            //// if we didn't commit then send to unmapped channel(s)
            //if (!committed)
            //{
            //    notifyUnmapped(metadataValues, true, ref committed);
            //}
        }
    }
}
