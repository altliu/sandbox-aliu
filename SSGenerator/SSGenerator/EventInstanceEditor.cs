using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSGenerator
{
    public partial class EventInstanceEditor : Form
    {
        private EventDataWrapper _eventData;
        private List<MetadataFieldEditor> _metadataFileEditor = new List<MetadataFieldEditor>();

        public EventInstanceEditor(EventDataWrapper eventData)
        {
            _eventData = eventData;

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _nameTextbox.Text = eventData.Name;
            _deltaTextbox.Text = eventData.Delta.ToString();

            //Create setting controls
            int count = 0;
            foreach (MetadataField metadataField in _eventData.EventDefinition.MetadataFields)
            {
                MetadataFieldEditor control = new MetadataFieldEditor(metadataField.Name, _eventData.MetadataValues[count]);
                _metadataFileEditor.Add(control);
                _panel.Controls.Add(control);
                count++;
            }

            if (_metadataFileEditor.Count > 0)
            {
                _metadataFileEditor[0].Location = new Point(0 + 16, 0 + 2);
                for (int i = 1; i < _metadataFileEditor.Count; i++)
                {
                    _metadataFileEditor[i].Location = new Point(0 + 16, _metadataFileEditor[i - 1].Bottom + 2);
                }
            }
        }

        #region Properties

        public EventDataWrapper Event
        {
            get { return _eventData; }
        }

        #endregion

        #region Private Methods

        private void _saveButton_Click(object sender, EventArgs e)
        {
            _eventData.Name = _nameTextbox.Text ?? "null";
            int delta;
            if (int.TryParse(_deltaTextbox.Text, out delta))
            {
                _eventData.Delta = delta;
            }

            foreach (MetadataFieldEditor metadataFieldEditor in _metadataFileEditor)
            {
                metadataFieldEditor.Save();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}