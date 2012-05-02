using System;
using System.Collections.Generic;
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
        private const string _time = "13:34:79";
        private const string _employee = "Employee";
        private const string _manager = "Manager";
        private const string _description = "Description";
        private byte[] _messageBytes = new byte[] {};

        public byte[] GetMessage()
        {
            HeaderMessage headerMessage = new HeaderMessage();
            headerMessage.blberProtocol = 0x01;
            headerMessage.uTermId = 12345;
            headerMessage.MsgType = 0x01;
            headerMessage.uCRC = 678;

            SpyMessage spyMessage = new SpyMessage();
            spyMessage.HeaderMsg = headerMessage;
            spyMessage.szTime = _time;
            spyMessage.nEmployeeId = 111222;
            spyMessage.szEmployeeName = _employee;
            spyMessage.nManagerId = 333444;
            spyMessage.szManagerName = _manager;
            spyMessage.nTableId = 555666;
            spyMessage.nCheckId = 777888;
            spyMessage.nTransactionType = 19;
            spyMessage.szDescription = _description;
            spyMessage.dAmount = 12.34;
            spyMessage.nQuantity = 5;

            int size = Marshal.SizeOf(spyMessage);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(spyMessage, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            return bytes;
        }

        public void ParseBytes1(byte[] bytes)
        {
            SpyMessage spyMessage = new SpyMessage();

            int size = Marshal.SizeOf(spyMessage);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(bytes, 0, ptr, size);

            spyMessage = (SpyMessage)Marshal.PtrToStructure(ptr, spyMessage.GetType());
            Marshal.FreeHGlobal(ptr);

            printMessage(spyMessage);  
        }

        public void ParseBytes2(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader br = new BinaryReader(ms))
            {
                Console.WriteLine("Protocol: " + br.ReadByte());
                Console.WriteLine("Term ID: " + br.ReadUInt32());
                Console.WriteLine("Message Type: " + br.ReadByte());
                Console.WriteLine("UCRC: " + br.ReadUInt16());

                Console.WriteLine("Time: " + Encoding.ASCII.GetString(br.ReadBytes(9)));
                Console.WriteLine("Employee ID: " + br.ReadUInt64());
                Console.WriteLine("Employee: " + Encoding.ASCII.GetString(br.ReadBytes(40)));
                Console.WriteLine("Manager ID: " + br.ReadInt64());
                Console.WriteLine("Manager: " + Encoding.ASCII.GetString(br.ReadBytes(40)));
                Console.WriteLine("Table ID: " + br.ReadUInt64());
                Console.WriteLine("Check ID: " + br.ReadUInt64());
                Console.WriteLine("Transaction Type: " + getType(br.ReadInt32()));
                Console.WriteLine("Description: " + Encoding.ASCII.GetString(br.ReadBytes(40)));

                Console.WriteLine("ALL: " + BitConverter.ToString(bytes));
                byte[] amountBytes = br.ReadBytes(8);
                Console.WriteLine("HEX1: " + BitConverter.ToString(amountBytes));
                //Array.Reverse(amountBytes);
                //Console.WriteLine("HEX2: " + BitConverter.ToString(amountBytes));
                Console.WriteLine("Amount: " + BitConverter.ToDouble(amountBytes, 0));
                
                Console.WriteLine("Quantity: " + br.ReadInt16());    
                Console.WriteLine();
            }

        }

        private string getType(int typeId)
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
            Console.WriteLine("Transaction Type: " + getType(spyMessage.nTransactionType));
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
