using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AlohaPcapParser
{
    class AlohaParser
    {
        private HashSet<TransactionTypes> _excludedTypes = new HashSet<TransactionTypes>();

        private byte[] _headerBytes = new byte[] { 0x01, 0x01, 0x02, 0x03, 0x04, 0x01, 0x00, 0x01 };
        private byte[] _messageBytes = new byte[] { };

        public AlohaParser()
        {
            _excludedTypes.Add(TransactionTypes.ACCEPT_TABLE);
            _excludedTypes.Add(TransactionTypes.ADD_CHECK);
            _excludedTypes.Add(TransactionTypes.ASSIGN_DRAWER);
            _excludedTypes.Add(TransactionTypes.BREAK_END);
            _excludedTypes.Add(TransactionTypes.BREAK_START);
            _excludedTypes.Add(TransactionTypes.CLEAR_PASSWORD);
            _excludedTypes.Add(TransactionTypes.CURRENT_TIME);
            _excludedTypes.Add(TransactionTypes.DRAWER_CLOSED);
            _excludedTypes.Add(TransactionTypes.DRAWER_OPEN);
            _excludedTypes.Add(TransactionTypes.GET_CHECK);
            _excludedTypes.Add(TransactionTypes.HOLD_ITEM);
            _excludedTypes.Add(TransactionTypes.LOG_IN);
            _excludedTypes.Add(TransactionTypes.LOG_OUT);
            _excludedTypes.Add(TransactionTypes.OPEN_TABLE_TAB);
            _excludedTypes.Add(TransactionTypes.OPEN_ITEM);
            _excludedTypes.Add(TransactionTypes.PAID_IN);
            _excludedTypes.Add(TransactionTypes.PAID_OUT);
            _excludedTypes.Add(TransactionTypes.PRINT_CHECK);
            _excludedTypes.Add(TransactionTypes.PRINT_CHECKOUT);
            _excludedTypes.Add(TransactionTypes.REPORT_RAN);
            _excludedTypes.Add(TransactionTypes.SELECT_ORDER);
        }

        public string ParseByMarshal(byte[] bytes)
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

            Logger.Log("PARSE BY MARSHAL (" + sw.ElapsedTicks + ")");
            return getSpyMessageSummary(spyMessage);
        }

        public string ParseByRead(byte[] bytes)
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
                spyMessage.nEmployeeId = br.ReadUInt32();
                spyMessage.szEmployeeName = Encoding.ASCII.GetString(br.ReadBytes(40));
                spyMessage.nManagerId = br.ReadUInt32();
                spyMessage.szManagerName = Encoding.ASCII.GetString(br.ReadBytes(40));
                spyMessage.nTableId = br.ReadUInt32();
                spyMessage.nCheckId = br.ReadUInt32();
                spyMessage.nTransactionType = br.ReadInt32();
                spyMessage.szDescription = Encoding.ASCII.GetString(br.ReadBytes(40));
                //byte[] amountBytes = br.ReadBytes(8);
                //spyMessage.dAmount = BitConverter.ToDouble(amountBytes, 0);
                spyMessage.dAmount = br.ReadDouble();
                spyMessage.nQuantity = br.ReadInt16();

                sw.Stop();
                //Logger.Log("PARSE BY READ (" + sw.ElapsedTicks + ")");
                return getSpyMessageSummary(spyMessage).Replace("\0", "");
            }
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

        private string getSpyMessageSummary(SpyMessage spyMessage)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Protocol: " + spyMessage.HeaderMsg.blberProtocol);
            sb.AppendLine("Term ID: " + spyMessage.HeaderMsg.uTermId);
            sb.AppendLine("Message Type: " + spyMessage.HeaderMsg.MsgType);
            sb.AppendLine("UCRC: " + spyMessage.HeaderMsg.uCRC);

            sb.AppendLine("Time: " + spyMessage.szTime);
            sb.AppendLine("Employee ID: " + spyMessage.nEmployeeId);
            sb.AppendLine("Employee: " + spyMessage.szEmployeeName);
            sb.AppendLine("Manager ID: " + spyMessage.nManagerId);
            sb.AppendLine("Manager: " + spyMessage.szManagerName);
            sb.AppendLine("Table ID: " + spyMessage.nTableId);
            sb.AppendLine("Check ID: " + spyMessage.nCheckId);
            sb.AppendLine("Transaction Type: " + getAlohaType(spyMessage.nTransactionType));
            sb.AppendLine("Description: " + spyMessage.szDescription);
            sb.AppendLine("Amount: " + spyMessage.dAmount);
            sb.AppendLine("Quantity: " + spyMessage.nQuantity);
            sb.AppendLine();

            return sb.ToString();
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
