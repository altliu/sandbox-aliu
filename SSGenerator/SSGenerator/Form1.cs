using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EventDefinitionManager.InitializeEventDefinition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EventsEditor eventsEditor = new EventsEditor())
            {
                eventsEditor.ShowInTaskbar = false;
                eventsEditor.MaximizeBox = false;
                eventsEditor.MinimizeBox = false;
                eventsEditor.FormBorderStyle = FormBorderStyle.FixedSingle;

                eventsEditor.StartPosition = FormStartPosition.CenterParent;
                eventsEditor.ShowDialog();
            }
        }
    }
}