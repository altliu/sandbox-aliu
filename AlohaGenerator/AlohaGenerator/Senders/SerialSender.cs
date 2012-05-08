using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace AlohaGenerator
{
    class SerialSender
    {
        private SerialPort _serialPort;

        public SerialSender()
        {
            
        }

        public string[] AvailablePorts
        {
            get { return SerialPort.GetPortNames(); }
        }

        public void Start(string port, int baud)
        {
            if (_serialPort != null)
                _serialPort.Close();

            _serialPort = new SerialPort(port, baud);
            _serialPort.Handshake = Handshake.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.DtrEnable = true;
            _serialPort.RtsEnable = true;
            _serialPort.Open();
        }

        public void SendBytes(byte[] data)
        {
            _serialPort.Write(data, 0, data.Length);
        }

        public void Stop()
        {
            if (_serialPort != null)
                _serialPort.Close();
        }
    }
}
