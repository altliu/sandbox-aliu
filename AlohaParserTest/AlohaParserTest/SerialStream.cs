using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlohaParserTest
{
    public class SerialStream
    {
        #region Fields

        public event Action<byte[]> DataReceived;
        private SerialPort _serialPort;

        #endregion

        public SerialStream(string serialPort, int baudRate)
        {

            _serialPort = new SerialPort(serialPort);
            _serialPort.BaudRate = baudRate;
            //_serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), TransactionManager.Instance.GetSettingValue("parity", (int)channelId));
            //_serialPort.DataBits = int.Parse(TransactionManager.Instance.GetSettingValue("dataBits", (int)channelId));
            //_serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), TransactionManager.Instance.GetSettingValue("stopBits", (int)channelId));
            //_serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), TransactionManager.Instance.GetSettingValue("handshake", (int)channelId));
            //_serialPort.ReadTimeout = int.Parse(TransactionManager.Instance.GetSettingValue("readTimeout", (int)channelId));
        }

        public void Start()
        {
            if (_serialPort != null)
            {
                try
                {
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                    _serialPort.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _serialPort.BytesToRead;
            byte[] data = new byte[dataLength];
            int bytesRead = _serialPort.Read(data, 0, dataLength);
            if (bytesRead == 0)
                return;

            // Send data to whom ever interested
            if (DataReceived != null)
                DataReceived(data);
        }

        public void Stop()
        {
            if (_serialPort != null)
            {
                //_runListener = false;
                //_thread.Join();
                _serialPort.Close();
            }
        }
    }
}
