namespace AlohaGenerator
{
    partial class AlohaSerialControl
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
            this._portCombo = new System.Windows.Forms.ComboBox();
            this._portLabel = new System.Windows.Forms.Label();
            this._baudCombo = new System.Windows.Forms.ComboBox();
            this._baudLabel = new System.Windows.Forms.Label();
            this._sendButton = new System.Windows.Forms.Button();
            this._connectButton = new System.Windows.Forms.Button();
            this._disconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _portCombo
            // 
            this._portCombo.FormattingEnabled = true;
            this._portCombo.Location = new System.Drawing.Point(70, 3);
            this._portCombo.Name = "_portCombo";
            this._portCombo.Size = new System.Drawing.Size(121, 21);
            this._portCombo.TabIndex = 0;
            // 
            // _portLabel
            // 
            this._portLabel.AutoSize = true;
            this._portLabel.Location = new System.Drawing.Point(7, 6);
            this._portLabel.Name = "_portLabel";
            this._portLabel.Size = new System.Drawing.Size(55, 13);
            this._portLabel.TabIndex = 1;
            this._portLabel.Text = "Serial Port";
            // 
            // _baudCombo
            // 
            this._baudCombo.FormattingEnabled = true;
            this._baudCombo.Location = new System.Drawing.Point(70, 30);
            this._baudCombo.Name = "_baudCombo";
            this._baudCombo.Size = new System.Drawing.Size(121, 21);
            this._baudCombo.TabIndex = 2;
            // 
            // _baudLabel
            // 
            this._baudLabel.AutoSize = true;
            this._baudLabel.Location = new System.Drawing.Point(7, 33);
            this._baudLabel.Name = "_baudLabel";
            this._baudLabel.Size = new System.Drawing.Size(32, 13);
            this._baudLabel.TabIndex = 3;
            this._baudLabel.Text = "Baud";
            // 
            // _sendButton
            // 
            this._sendButton.Location = new System.Drawing.Point(10, 115);
            this._sendButton.Name = "_sendButton";
            this._sendButton.Size = new System.Drawing.Size(181, 23);
            this._sendButton.TabIndex = 4;
            this._sendButton.Text = "Send";
            this._sendButton.UseVisualStyleBackColor = true;
            this._sendButton.Click += new System.EventHandler(this._sendButton_Click);
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(10, 57);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(181, 23);
            this._connectButton.TabIndex = 5;
            this._connectButton.Text = "Connect";
            this._connectButton.UseVisualStyleBackColor = true;
            this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
            // 
            // _disconnectButton
            // 
            this._disconnectButton.Location = new System.Drawing.Point(10, 86);
            this._disconnectButton.Name = "_disconnectButton";
            this._disconnectButton.Size = new System.Drawing.Size(181, 23);
            this._disconnectButton.TabIndex = 6;
            this._disconnectButton.Text = "Disconnect";
            this._disconnectButton.UseVisualStyleBackColor = true;
            // 
            // AlohaSerialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._disconnectButton);
            this.Controls.Add(this._connectButton);
            this.Controls.Add(this._sendButton);
            this.Controls.Add(this._baudLabel);
            this.Controls.Add(this._baudCombo);
            this.Controls.Add(this._portLabel);
            this.Controls.Add(this._portCombo);
            this.Name = "AlohaSerialControl";
            this.Size = new System.Drawing.Size(399, 223);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _portCombo;
        private System.Windows.Forms.Label _portLabel;
        private System.Windows.Forms.ComboBox _baudCombo;
        private System.Windows.Forms.Label _baudLabel;
        private System.Windows.Forms.Button _sendButton;
        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.Button _disconnectButton;
    }
}
