using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlohaGenerator.Controls;
using AlohaGenerator.Generator;
using AlohaGenerator.Senders;

namespace AlohaGenerator.Integrations
{
    public abstract class IntegrationBase : IDisposable
    {
        #region Fields

        public event Action<string> StatusUpdate;
        public event Action<string> MessageUpdate;

        private SettingControlBase _control;
        private ISender _sender;
        private IGenerator _generator;
        private bool _initalized = false;

        #endregion

        public abstract string DisplayName { get; }

        public override string ToString()
        {
            return DisplayName;
        }

        public abstract Type ControlType { get; }

        public UserControl Control { get { return _control; } }

        public abstract Type SenderType { get; }

        public ISender Sender { get { return _sender; } }

        public abstract Type GeneratorType { get; }

        public IGenerator Generator { get { return _generator; } }

        public void LoadUI(UserControl panel)
        {
            _control = (SettingControlBase)Activator.CreateInstance(ControlType);
            
            panel.Controls.Clear();
            this.Control.Location = new Point(0, 0);
            panel.Controls.Add(this.Control);
        }

        public void Connect()
        {
            initialize();

            _sender.Connect(_control.ConnectInfo);
            writeStatus("Connected to " + _sender.SenderInfo + ".");
        }

        public void Disconnect()
        {
            initialize();

            _sender.Disconnect();
            writeStatus("Disconnected from " + _sender.SenderInfo + ".");
        }

        public void Send()
        {
            initialize();

            byte[] data = _generator.GetMessage();

            string message = Encoding.ASCII.GetString(data);
            writeMessage(message);
            writeStatus("Sent: " + message);

            _sender.Send(data);
        }

        public void Dispose()
        {
            _sender.Dispose();
            _generator.Dispose();
            _control.Dispose();
        }

        protected void writeStatus(string message)
        {
            if (StatusUpdate != null)
            {
                StatusUpdate(message);
            }
        }

        protected void writeMessage(string message)
        {
            if (MessageUpdate != null)
            {
                MessageUpdate(message);
            }
        }

        private void initialize()
        {
            if (!_initalized)
            {
                _sender = (ISender) Activator.CreateInstance(SenderType);
                _generator = (IGenerator)Activator.CreateInstance(GeneratorType);
                _initalized = true;
            }
        }
    }
}
