using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TCP_Listener;

namespace TCPListener_Program
{
    public partial class Form1 : Form
    {
        private delegate void updateGenericBox(string mstr, int boxNum);

        private static string _savePath = "log.txt";
        private static TCPListener _tcpListener;
        private static string _myAddress;

        public Form1()
        {
            InitializeComponent();

            // get and fill ip
            IPHostEntry ihe = Dns.GetHostEntry(Dns.GetHostName());
            _myAddress = ihe.AddressList[0].ToString();
            ipTextBox.Text = _myAddress;

            portTextBox.Text = "7112";

            // init listview box
            msgListView.View = View.Details;
            msgListView.Columns.Add("Message", msgListView.Width-4, HorizontalAlignment.Left);

            // init status list view
            statusListView.View = View.Details;
            statusListView.Columns.Add("Status", msgListView.Width - 4, HorizontalAlignment.Left);            
            
            ackCB.Checked = false;
            _nullCB.Checked = true;

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == "Connect")
            {
                // TODO: look at not disposing this everytime
                _tcpListener = new TCPListener(int.Parse(portTextBox.Text), ackCB.Checked, tcpListenerCallback);
                _tcpListener.LoggingCallback = tcpStatusCallback;
                _tcpListener.Start();
                connectButton.Text = "Disconnect";
            }
            else if (connectButton.Text == "Disconnect")
            {
                _tcpListener.Stop();
                connectButton.Text = "Connect";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            msgListView.Clear();
            statusListView.Clear();
            byteRichTextBox.Text = string.Empty;
            charRichTextBox.Text = string.Empty;

            // init listview box
            msgListView.View = View.Details;
            msgListView.Columns.Add("Message", msgListView.Width - 4, HorizontalAlignment.Left);

            // init status list view
            statusListView.View = View.Details;
            statusListView.Columns.Add("Status", msgListView.Width - 4, HorizontalAlignment.Left);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
        }


        private void msgListView_ItemActivate(object sender, EventArgs e)
        {
            MessageBox.Show(msgListView.SelectedItems[0].Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void statusListView_ItemActivate(object sender, EventArgs e)
        {
            MessageBox.Show(statusListView.SelectedItems[0].Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tcpListenerCallback(byte[] bytes)
        {
            string mstr = Encoding.ASCII.GetString(bytes);

            mstr = _nullCB.Checked ? mstr.Replace("\0", "<null>") : mstr.Replace("\0", "");
            
            updateGenericBoxThread(mstr, 1);
            updateGenericBoxThread(mstr, 2);

            getAndPrintByteString(bytes);
        }

        private void tcpStatusCallback(string msg)
        {
            updateGenericBoxThread(msg, 3);
        }

        private void getAndPrintByteString(byte[] bytes)
        {
            string byteString = "";
            foreach (byte dataByte in bytes)
            {
                byteString = byteString + String.Format("{0:X2}", int.Parse(dataByte.ToString())) + " ";
                if (dataByte.ToString() == "10")
                {
                    byteString = byteString + "\n";
                }
            }
            updateGenericBoxThread(byteString, 0);
        }

        private void updateGenericBoxThread(string mstr, int boxNum)
        {
            if (InvokeRequired)
            {
                Invoke(new updateGenericBox(updateGenericBoxThread), mstr, boxNum);
            }
            else
            {
                // boxNum Key
                // 0 = byteRichTextBox
                // 1 = charRichTextBox
                // 2 = msgListView
                // 3 = statusListView
                // 4 = writeToFile
                switch (boxNum)
                {
                    case 0:
                        {
                            byteRichTextBox.Text = mstr;
                            break;
                        }
                    case 1:
                        {
                            charRichTextBox.Text = mstr;
                            break;
                        }
                    case 2:
                        {
                            msgListView.Items.Add(mstr);
                            msgListView.EnsureVisible(msgListView.Items.Count - 1);
                            break;
                        }
                    case 3:
                        {
                            statusListView.Items.Insert(0, mstr);
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                File.AppendAllText(_savePath, mstr + "\n\n");
                            }
                            catch (Exception ex)
                            {
                                updateGenericBoxThread(ex.ToString(), 3);
                            }
                            break;
                        }
                    default:
                        {
                            statusListView.Items.Insert(0, "You did something wrong and hit the default case in the updateGenericThread().");
                            break;
                        }
                }
            }
        }

        private void ackCB_CheckedChanged(object sender, EventArgs e)
        {
            if (_tcpListener != null)
            {
                _tcpListener.Ack = ackCB.Checked;
            }
        }
    }
}