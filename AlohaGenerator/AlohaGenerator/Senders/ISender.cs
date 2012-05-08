using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlohaGenerator.Senders
{
    public interface ISender : IDisposable
    {
        string SenderInfo { get; }

        void Connect(ConnectionInfo connectionInfo);
        void Disconnect();
        void Send(byte[] data);
    }
}
