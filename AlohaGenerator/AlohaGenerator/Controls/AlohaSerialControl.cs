using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlohaGenerator.Controls;
using AlohaGenerator.Senders;

namespace AlohaGenerator
{
    public partial class AlohaSerialControl : SettingControlBase
    {
        private SerialSender _sender = new SerialSender();
        private AlohaMessageGenerator _generator = new AlohaMessageGenerator();

        public AlohaSerialControl()
        {
            InitializeComponent();

            _baudCombo.Items.Add(2400);
            _baudCombo.Items.Add(4800);
            _baudCombo.Items.Add(9600);
            _baudCombo.Items.Add(19200);
            _baudCombo.Items.Add(38400);
            _baudCombo.SelectedItem = _baudCombo.Items[0];


            string[] ports = _sender.AvailablePorts;
            foreach (string port in ports)
            {
                _portCombo.Items.Add(port);
            }
            _portCombo.SelectedItem = _portCombo.Items[0];
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            byte[] bytes = _generator.GetMessage();
            _sender.SendBytes(bytes);
        }

        private void _connectButton_Click(object sender, EventArgs e)
        {
            //_portCombo
            string port = (string)_portCombo.SelectedItem;
            int baud = (int)_baudCombo.SelectedItem;

            _sender.Start(port, baud);
        }

        #region Overrides of SettingControlBase

        public override ConnectionInfo ConnectInfo
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
