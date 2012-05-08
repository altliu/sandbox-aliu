using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AlohaGenerator
{
    public enum EventTypes
    {
        [Description("Aloha Serial")]
        AlohaSerial,
        [Description("Aloha Tcp")]
        AlohaTcp
    }

    //public enum BaudRate {B2400, B4800, B9600, B19200, B38400, B57600}
}
