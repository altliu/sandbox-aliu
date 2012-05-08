namespace AlohaGenerator
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._typeCombo = new System.Windows.Forms.ComboBox();
            this._settingsPanel = new System.Windows.Forms.Panel();
            this._messageRtb = new System.Windows.Forms.RichTextBox();
            this._statusListview = new System.Windows.Forms.ListView();
            this._rtbPanel = new System.Windows.Forms.Panel();
            this._rtbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _typeCombo
            // 
            this._typeCombo.FormattingEnabled = true;
            this._typeCombo.Location = new System.Drawing.Point(12, 12);
            this._typeCombo.Name = "_typeCombo";
            this._typeCombo.Size = new System.Drawing.Size(260, 21);
            this._typeCombo.TabIndex = 0;
            this._typeCombo.SelectionChangeCommitted += new System.EventHandler(this._typeCombo_SelectionChangeCommitted);
            // 
            // _settingsPanel
            // 
            this._settingsPanel.Location = new System.Drawing.Point(12, 39);
            this._settingsPanel.Name = "_settingsPanel";
            this._settingsPanel.Size = new System.Drawing.Size(669, 211);
            this._settingsPanel.TabIndex = 1;
            // 
            // _messageRtb
            // 
            this._messageRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._messageRtb.Location = new System.Drawing.Point(0, 0);
            this._messageRtb.Name = "_messageRtb";
            this._messageRtb.Size = new System.Drawing.Size(667, 163);
            this._messageRtb.TabIndex = 2;
            this._messageRtb.Text = "";
            // 
            // _statusListview
            // 
            this._statusListview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._statusListview.GridLines = true;
            this._statusListview.Location = new System.Drawing.Point(12, 427);
            this._statusListview.Name = "_statusListview";
            this._statusListview.Size = new System.Drawing.Size(669, 218);
            this._statusListview.TabIndex = 3;
            this._statusListview.UseCompatibleStateImageBehavior = false;
            // 
            // _rtbPanel
            // 
            this._rtbPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._rtbPanel.Controls.Add(this._messageRtb);
            this._rtbPanel.Location = new System.Drawing.Point(12, 256);
            this._rtbPanel.Name = "_rtbPanel";
            this._rtbPanel.Size = new System.Drawing.Size(669, 165);
            this._rtbPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 657);
            this.Controls.Add(this._rtbPanel);
            this.Controls.Add(this._statusListview);
            this.Controls.Add(this._settingsPanel);
            this.Controls.Add(this._typeCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this._rtbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _typeCombo;
        private System.Windows.Forms.Panel _settingsPanel;
        private System.Windows.Forms.RichTextBox _messageRtb;
        private System.Windows.Forms.ListView _statusListview;
        private System.Windows.Forms.Panel _rtbPanel;

    }
}

