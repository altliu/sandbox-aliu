using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AlohaParserTest
{
    // Length: 8
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HeaderMessage
    {
        public byte blberProtocol;  // Iber Protocol of this message; always 1
        public UInt32 uTermId;      // Sending term ID
        public byte MsgType;        // Message Type; always 1
        public UInt16 uCRC;         // CRC Check; unused
    }

    // Length: 185
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct SpyMessage
    {
        public HeaderMessage HeaderMsg;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=9)]
        public string szTime;                   // time in HH:MM:SS\0
        public UInt32 nEmployeeId;               // Employee ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string szEmployeeName;           // Employee's Name
        public UInt32 nManagerId;                // Manager ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string szManagerName;            // Manager's Name5
        public UInt32 nTableId;                  // Table ID
        public UInt32 nCheckId;                  // Check ID
        public int nTransactionType;            // Transaction – see below
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string szDescription;            // Description of the Message
        public double dAmount;                  // Transaction Amount - dollar value
        public int nQuantity;                   // Quantity of the Transaction
    }

    // NOTE: ORIGINAL
    //// Length: 185
    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //struct SpyMessage
    //{
    //    public HeaderMessage HeaderMsg;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
    //    public string szTime;                   // time in HH:MM:SS\0
    //    public ulong nEmployeeId;               // Employee ID
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    //    public string szEmployeeName;           // Employee's Name
    //    public ulong nManagerId;                // Manager ID
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    //    public string szManagerName;            // Manager's Name
    //    public ulong nTableId;                  // Table ID
    //    public ulong nCheckId;                  // Check ID
    //    public int nTransactionType;            // Transaction – see below
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    //    public string szDescription;            // Description of the Message
    //    public double dAmount;                  // Transaction Amount - dollar value
    //    public int nQuantity;                   // Quantity of the Transaction
    //}

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
}
