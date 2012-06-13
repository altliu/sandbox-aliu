using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.IPLib;
using Tamir.IPLib.Packets;

namespace AlohaPcapParser
{
    public partial class Main : Form
    {
        private AlohaManager _manager = new AlohaManager();

        public Main()
        {
            InitializeComponent();
            _manager.StatusUpdate += new Action<string>(statusUpdate);
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            _manager.Start(_sendCheckbox.Checked);
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            _manager.Stop();
        }        
        
        private void statusUpdate(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(statusUpdate), message);
            }
            else
            {
                _statusBox.Text = message;
            }
        }
    }
}
