using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AlohaGenerator.Integrations;

namespace AlohaGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Array eventTypes = Enum.GetValues(typeof (EventTypes));

            //foreach (EventTypes eventType in eventTypes)
            //{
            //    _typeCombo.Items.Add(eventType);
            //}
            //_typeCombo.SelectedItem = _typeCombo.Items[1];
            //_typeCombo.SelectedItem = _typeCombo.Items[0];

            List<Type> types = GetClasses(typeof (IntegrationBase));
            foreach (Type type in types)
            {
                _typeCombo.Items.Add(Activator.CreateInstance(type));
            }
        }

        private void _typeCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EventTypes type = (EventTypes)_typeCombo.SelectedItem;

            switch (type)
            {
                case EventTypes.AlohaSerial:
                    AlohaSerialControl control = new AlohaSerialControl();
                    _settingsPanel.Controls.Add(control);
                    break;
                case EventTypes.AlohaTcp:
                    break;
            }
        }

        private static List<Type> GetClasses(Type baseType)
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(type => type.IsSubclassOf(baseType)).ToList();
        }
    }
}
