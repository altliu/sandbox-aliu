using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AlohaGeneratorSimple
{
    public partial class Form1 : Form
    {
        private string _ipAddress = "10.10.2.208";
        private int _port = 7118;

        private AlohaMessage _message = new AlohaMessage();

        public Form1()
        {
            InitializeComponent();
            _channelCb.Items.Add((uint)1);
            _channelCb.Items.Add((uint)2);
            _channelCb.Items.Add((uint)3);
            _channelCb.SelectedIndex = 0;

            _checkTextbox.Text = "1234";
        }

        private void write(AlohaTransactionType type)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(_ipAddress, _port);

                    using (NetworkStream ns = client.GetStream())
                    {
                        uint terminal = uint.Parse(_channelCb.Text);
                        uint check = uint.Parse(_checkTextbox.Text);
                        byte[] bytes = _message.GetMessage(type, check, terminal);
                        byte[] lengthBytes = BitConverter.GetBytes((uint) bytes.Length);
                        ns.Write(lengthBytes, 0, lengthBytes.Length);
                        ns.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Sending: " + ex);
            }
        }

        private void _breakStartButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Break_Start);
        }

        private void _breakEndButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Break_End);
        }

        private void _clockInButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Clock_In);
        }

        private void _clockOutButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Clock_Out);
        }

        private void _addItemButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Add_Item);
        }

        private void _closeCheckButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Close_Check);
        }

        private void _voidButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Void_Item);
        }

        private void _taxButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Tax);
        }

        private void _totalButton_Click(object sender, EventArgs e)
        {
            write(AlohaTransactionType.Total);
        }

        
    }
}
