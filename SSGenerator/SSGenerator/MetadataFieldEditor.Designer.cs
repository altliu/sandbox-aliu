namespace SSGenerator
{
    partial class MetadataFieldEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._valueTextbox = new System.Windows.Forms.TextBox();
            this._label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _valueTextbox
            // 
            this._valueTextbox.Location = new System.Drawing.Point(89, 3);
            this._valueTextbox.Name = "_valueTextbox";
            this._valueTextbox.Size = new System.Drawing.Size(100, 20);
            this._valueTextbox.TabIndex = 0;
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(3, 6);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(38, 13);
            this._label.TabIndex = 1;
            this._label.Text = "Name:";
            // 
            // MetadataFieldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._label);
            this.Controls.Add(this._valueTextbox);
            this.Name = "MetadataFieldEditor";
            this.Size = new System.Drawing.Size(193, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _valueTextbox;
        private System.Windows.Forms.Label _label;
    }
}
