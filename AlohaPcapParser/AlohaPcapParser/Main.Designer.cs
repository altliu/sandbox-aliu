namespace AlohaPcapParser
{
    partial class Main
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
            this._startButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this._statusBox = new System.Windows.Forms.RichTextBox();
            this._sendCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _startButton
            // 
            this._startButton.Location = new System.Drawing.Point(12, 12);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(75, 23);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _stopButton
            // 
            this._stopButton.Location = new System.Drawing.Point(12, 41);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(75, 23);
            this._stopButton.TabIndex = 1;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
            // 
            // _statusBox
            // 
            this._statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._statusBox.Location = new System.Drawing.Point(12, 70);
            this._statusBox.Name = "_statusBox";
            this._statusBox.Size = new System.Drawing.Size(516, 355);
            this._statusBox.TabIndex = 2;
            this._statusBox.Text = "";
            // 
            // _sendCheckbox
            // 
            this._sendCheckbox.AutoSize = true;
            this._sendCheckbox.Checked = true;
            this._sendCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._sendCheckbox.Location = new System.Drawing.Point(321, 18);
            this._sendCheckbox.Name = "_sendCheckbox";
            this._sendCheckbox.Size = new System.Drawing.Size(92, 17);
            this._sendCheckbox.TabIndex = 3;
            this._sendCheckbox.Text = "Send via TCP";
            this._sendCheckbox.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 437);
            this.Controls.Add(this._sendCheckbox);
            this.Controls.Add(this._statusBox);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._startButton);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.RichTextBox _statusBox;
        private System.Windows.Forms.CheckBox _sendCheckbox;
    }
}

