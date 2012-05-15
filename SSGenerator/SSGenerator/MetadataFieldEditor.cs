using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SSGenerator
{
    public partial class MetadataFieldEditor : UserControl
    {
        private MetadataWrapper _metadataWrapper;

        //public MetadataFieldEditor(string name)
        //    : this(name, string.Empty)
        //{
        //}

        public MetadataFieldEditor(string name, MetadataWrapper metadataWrapper)
        {
            InitializeComponent();
            _label.Text = name;
            _valueTextbox.Text = metadataWrapper.Value;
            _metadataWrapper = metadataWrapper;
        }
        
        public void Save()
        {
            _metadataWrapper.Value = _valueTextbox.Text;
        }
    }
}
