using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AlohaGeneratorSimple
{
    class AlohaMessage
    {
        private const string _time = "13:34:79";
        private const string _employee = "Employee";
        private const string _manager = "Manager";
        private const string _description = "Description";

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

        public byte[] GetMessage(AlohaTransactionType type, uint check, uint terminal)
        {
            return GetMessage(type, check, terminal, 0.00D);
        }

        public byte[] GetMessage(AlohaTransactionType type, uint check, uint terminal, double amount)
        {
            HeaderMessage headerMessage = new HeaderMessage();
            headerMessage.blberProtocol = 0x01;
            headerMessage.uTermId = terminal;
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
            spyMessage.nCheckId = check;
            spyMessage.nTransactionType = (int) type;
            spyMessage.szDescription = _description;
            spyMessage.dAmount = amount;
            spyMessage.nQuantity = 5;

            int size = Marshal.SizeOf(spyMessage);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(spyMessage, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            return bytes;
        }

        public byte[] GetRandomMessage()
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
    }
}
