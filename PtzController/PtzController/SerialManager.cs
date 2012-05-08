using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace PtzController
{
    class SerialManager
    {
        private SerialPort _serialPort;
        private int _address = (byte) 1;

        public SerialManager()
        {            
        }

        public string[] ComPorts
        {
            get { return SerialPort.GetPortNames(); }    
        }

        public void Connect(string serialPort)
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
            }

            _serialPort = new SerialPort(serialPort, 2400);
            int baudRate = _serialPort.BaudRate;
            _serialPort.RtsEnable = true;
            _serialPort.Handshake = Handshake.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DtrEnable = true;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.Open();
        }

        public void Disconnect()
        {
            if (_serialPort != null)
                _serialPort.Close();    
        }

        public void Send(Command command)
        {            
            //_serialPort.Open();
            int hex = (int) command;

            List<byte> list = new List<byte>();

            byte c1 = (byte)((hex & 0xFF00) >> 8);
            byte c2 = (byte)(hex & 0xFF);

            byte v1 = list.Count > 0 ? list[0] : (byte)0;
            byte v2 = list.Count > 1 ? list[1] : (byte)0;

            //_serialPort.DiscardInBuffer();
            byte[] message = encode(new byte[] {c1, c2, v1, v2});
            _serialPort.Write(message, 0, message.Length);
            //_serialPort.Close();
        }

        private byte[] encode(IEnumerable<byte> command)
        {
            List<byte> encoded = new List<byte>();
            encoded.Add(0xFF);
            encoded.Add((byte)_address);
            encoded.AddRange(command);

            int checksum = 0;
            for (int i = 1; i < encoded.Count; i++)
            {
                checksum += encoded[i];
            }
            encoded.Add((byte)(checksum & 0xFF));

            return encoded.ToArray();
        }
    }
}
