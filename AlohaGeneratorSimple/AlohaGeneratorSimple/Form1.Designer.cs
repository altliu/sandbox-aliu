namespace AlohaGeneratorSimple
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
            this._addItemButton = new System.Windows.Forms.Button();
            this._closeCheckButton = new System.Windows.Forms.Button();
            this._channelCb = new System.Windows.Forms.ComboBox();
            this._breakStartButton = new System.Windows.Forms.Button();
            this._checkTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _addItemButton
            // 
            this._addItemButton.Location = new System.Drawing.Point(12, 65);
            this._addItemButton.Name = "_addItemButton";
            this._addItemButton.Size = new System.Drawing.Size(75, 23);
            this._addItemButton.TabIndex = 0;
            this._addItemButton.Text = "Add Item";
            this._addItemButton.UseVisualStyleBackColor = true;
            this._addItemButton.Click += new System.EventHandler(this._addItemButton_Click);
            // 
            // _closeCheckButton
            // 
            this._closeCheckButton.Location = new System.Drawing.Point(12, 94);
            this._closeCheckButton.Name = "_closeCheckButton";
            this._closeCheckButton.Size = new System.Drawing.Size(75, 23);
            this._closeCheckButton.TabIndex = 1;
            this._closeCheckButton.Text = "Close Check";
            this._closeCheckButton.UseVisualStyleBackColor = true;
            this._closeCheckButton.Click += new System.EventHandler(this._closeCheckButton_Click);
            // 
            // _channelCb
            // 
            this._channelCb.FormattingEnabled = true;
            this._channelCb.Location = new System.Drawing.Point(12, 12);
            this._channelCb.Name = "_channelCb";
            this._channelCb.Size = new System.Drawing.Size(121, 21);
            this._channelCb.TabIndex = 2;
            // 
            // _breakStartButton
            // 
            this._breakStartButton.Location = new System.Drawing.Point(12, 123);
            this._breakStartButton.Name = "_breakStartButton";
            this._breakStartButton.Size = new System.Drawing.Size(75, 23);
            this._breakStartButton.TabIndex = 3;
            this._breakStartButton.Text = "Start Break";
            this._breakStartButton.UseVisualStyleBackColor = true;
            this._breakStartButton.Click += new System.EventHandler(this._breakStartButton_Click);
            // 
            // _checkTextbox
            // 
            this._checkTextbox.Location = new System.Drawing.Point(12, 39);
            this._checkTextbox.Name = "_checkTextbox";
            this._checkTextbox.Size = new System.Drawing.Size(121, 20);
            this._checkTextbox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._checkTextbox);
            this.Controls.Add(this._breakStartButton);
            this.Controls.Add(this._channelCb);
            this.Controls.Add(this._closeCheckButton);
            this.Controls.Add(this._addItemButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _addItemButton;
        private System.Windows.Forms.Button _closeCheckButton;
        private System.Windows.Forms.ComboBox _channelCb;
        private System.Windows.Forms.Button _breakStartButton;
        private System.Windows.Forms.TextBox _checkTextbox;
    }
}

