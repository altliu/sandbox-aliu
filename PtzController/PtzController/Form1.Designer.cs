namespace PtzController
{
    partial class Form1
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
            this._zoomInButton = new System.Windows.Forms.Button();
            this._zoomOutButton = new System.Windows.Forms.Button();
            this._serialPortCombo = new System.Windows.Forms.ComboBox();
            this._disconnectButton = new System.Windows.Forms.Button();
            this._connectButton = new System.Windows.Forms.Button();
            this._sendButton = new System.Windows.Forms.Button();
            this._commandCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _zoomInButton
            // 
            this._zoomInButton.Enabled = false;
            this._zoomInButton.Location = new System.Drawing.Point(93, 199);
            this._zoomInButton.Name = "_zoomInButton";
            this._zoomInButton.Size = new System.Drawing.Size(75, 23);
            this._zoomInButton.TabIndex = 0;
            this._zoomInButton.Text = "Zoom In";
            this._zoomInButton.UseVisualStyleBackColor = true;
            // 
            // _zoomOutButton
            // 
            this._zoomOutButton.Enabled = false;
            this._zoomOutButton.Location = new System.Drawing.Point(174, 199);
            this._zoomOutButton.Name = "_zoomOutButton";
            this._zoomOutButton.Size = new System.Drawing.Size(75, 23);
            this._zoomOutButton.TabIndex = 1;
            this._zoomOutButton.Text = "Zoom Out";
            this._zoomOutButton.UseVisualStyleBackColor = true;
            // 
            // _serialPortCombo
            // 
            this._serialPortCombo.FormattingEnabled = true;
            this._serialPortCombo.Location = new System.Drawing.Point(13, 12);
            this._serialPortCombo.Name = "_serialPortCombo";
            this._serialPortCombo.Size = new System.Drawing.Size(259, 21);
            this._serialPortCombo.TabIndex = 2;
            // 
            // _disconnectButton
            // 
            this._disconnectButton.Location = new System.Drawing.Point(94, 39);
            this._disconnectButton.Name = "_disconnectButton";
            this._disconnectButton.Size = new System.Drawing.Size(75, 23);
            this._disconnectButton.TabIndex = 3;
            this._disconnectButton.Text = "Disconnect";
            this._disconnectButton.UseVisualStyleBackColor = true;
            this._disconnectButton.Click += new System.EventHandler(this._disconnectButton_Click);
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(13, 39);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(75, 23);
            this._connectButton.TabIndex = 4;
            this._connectButton.Text = "Connect";
            this._connectButton.UseVisualStyleBackColor = true;
            this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
            // 
            // _sendButton
            // 
            this._sendButton.Location = new System.Drawing.Point(12, 95);
            this._sendButton.Name = "_sendButton";
            this._sendButton.Size = new System.Drawing.Size(75, 23);
            this._sendButton.TabIndex = 5;
            this._sendButton.Text = "Send";
            this._sendButton.UseVisualStyleBackColor = true;
            this._sendButton.Click += new System.EventHandler(this._sendButton_Click);
            // 
            // _commandCombo
            // 
            this._commandCombo.FormattingEnabled = true;
            this._commandCombo.Location = new System.Drawing.Point(12, 68);
            this._commandCombo.Name = "_commandCombo";
            this._commandCombo.Size = new System.Drawing.Size(259, 21);
            this._commandCombo.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._commandCombo);
            this.Controls.Add(this._sendButton);
            this.Controls.Add(this._connectButton);
            this.Controls.Add(this._disconnectButton);
            this.Controls.Add(this._serialPortCombo);
            this.Controls.Add(this._zoomOutButton);
            this.Controls.Add(this._zoomInButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _zoomInButton;
        private System.Windows.Forms.Button _zoomOutButton;
        private System.Windows.Forms.ComboBox _serialPortCombo;
        private System.Windows.Forms.Button _disconnectButton;
        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.Button _sendButton;
        private System.Windows.Forms.ComboBox _commandCombo;
    }
}

