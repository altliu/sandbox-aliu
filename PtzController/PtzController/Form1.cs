using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PtzController
{
    public partial class Form1 : Form
    {
        private SerialManager _serialManager;

        public Form1()
        {
            InitializeComponent();
            _serialManager = new SerialManager();
            string[] serialPorts = _serialManager.ComPorts;

            foreach (string serialPort in serialPorts)
            {
                _serialPortCombo.Items.Add(serialPort);
            }

            Array enumValues = Enum.GetValues(typeof (Command));
            foreach (var enumValue in enumValues)
            {
                Command command = (Command) enumValue;
                _commandCombo.Items.Add(command);
            }
        }

        private void _connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string serialPort = (String) _serialPortCombo.SelectedItem;
                _serialManager.Connect(serialPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void _disconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                _serialManager.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                Command command = (Command) _commandCombo.SelectedItem;
                _serialManager.Send(Command.ZoomWide);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
