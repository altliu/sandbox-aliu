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
            this._totalButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this._voidButton = new System.Windows.Forms.Button();
            this._taxButton = new System.Windows.Forms.Button();
            this._clockInButton = new System.Windows.Forms.Button();
            this._breakEndButton = new System.Windows.Forms.Button();
            this._clockOutButton = new System.Windows.Forms.Button();
            this._checkLabel = new System.Windows.Forms.Label();
            this._sourceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _addItemButton
            // 
            this._addItemButton.Location = new System.Drawing.Point(93, 68);
            this._addItemButton.Name = "_addItemButton";
            this._addItemButton.Size = new System.Drawing.Size(75, 23);
            this._addItemButton.TabIndex = 0;
            this._addItemButton.Text = "Add Item";
            this._addItemButton.UseVisualStyleBackColor = true;
            this._addItemButton.Click += new System.EventHandler(this._addItemButton_Click);
            // 
            // _closeCheckButton
            // 
            this._closeCheckButton.Location = new System.Drawing.Point(93, 184);
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
            this._channelCb.Location = new System.Drawing.Point(111, 12);
            this._channelCb.Name = "_channelCb";
            this._channelCb.Size = new System.Drawing.Size(138, 21);
            this._channelCb.TabIndex = 2;
            // 
            // _breakStartButton
            // 
            this._breakStartButton.Location = new System.Drawing.Point(12, 68);
            this._breakStartButton.Name = "_breakStartButton";
            this._breakStartButton.Size = new System.Drawing.Size(75, 23);
            this._breakStartButton.TabIndex = 3;
            this._breakStartButton.Text = "Start Break";
            this._breakStartButton.UseVisualStyleBackColor = true;
            this._breakStartButton.Click += new System.EventHandler(this._breakStartButton_Click);
            // 
            // _checkTextbox
            // 
            this._checkTextbox.Location = new System.Drawing.Point(111, 39);
            this._checkTextbox.Name = "_checkTextbox";
            this._checkTextbox.Size = new System.Drawing.Size(138, 20);
            this._checkTextbox.TabIndex = 4;
            // 
            // _totalButton
            // 
            this._totalButton.Location = new System.Drawing.Point(93, 155);
            this._totalButton.Name = "_totalButton";
            this._totalButton.Size = new System.Drawing.Size(75, 23);
            this._totalButton.TabIndex = 5;
            this._totalButton.Text = "Total";
            this._totalButton.UseVisualStyleBackColor = true;
            this._totalButton.Click += new System.EventHandler(this._totalButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // _voidButton
            // 
            this._voidButton.Location = new System.Drawing.Point(93, 97);
            this._voidButton.Name = "_voidButton";
            this._voidButton.Size = new System.Drawing.Size(75, 23);
            this._voidButton.TabIndex = 8;
            this._voidButton.Text = "Void";
            this._voidButton.UseVisualStyleBackColor = true;
            this._voidButton.Click += new System.EventHandler(this._voidButton_Click);
            // 
            // _taxButton
            // 
            this._taxButton.Location = new System.Drawing.Point(93, 126);
            this._taxButton.Name = "_taxButton";
            this._taxButton.Size = new System.Drawing.Size(75, 23);
            this._taxButton.TabIndex = 9;
            this._taxButton.Text = "Tax";
            this._taxButton.UseVisualStyleBackColor = true;
            this._taxButton.Click += new System.EventHandler(this._taxButton_Click);
            // 
            // _clockInButton
            // 
            this._clockInButton.Location = new System.Drawing.Point(12, 126);
            this._clockInButton.Name = "_clockInButton";
            this._clockInButton.Size = new System.Drawing.Size(75, 23);
            this._clockInButton.TabIndex = 12;
            this._clockInButton.Text = "Clock In";
            this._clockInButton.UseVisualStyleBackColor = true;
            this._clockInButton.Click += new System.EventHandler(this._clockInButton_Click);
            // 
            // _breakEndButton
            // 
            this._breakEndButton.Location = new System.Drawing.Point(12, 97);
            this._breakEndButton.Name = "_breakEndButton";
            this._breakEndButton.Size = new System.Drawing.Size(75, 23);
            this._breakEndButton.TabIndex = 11;
            this._breakEndButton.Text = "End Break";
            this._breakEndButton.UseVisualStyleBackColor = true;
            this._breakEndButton.Click += new System.EventHandler(this._breakEndButton_Click);
            // 
            // _clockOutButton
            // 
            this._clockOutButton.Location = new System.Drawing.Point(12, 155);
            this._clockOutButton.Name = "_clockOutButton";
            this._clockOutButton.Size = new System.Drawing.Size(75, 23);
            this._clockOutButton.TabIndex = 10;
            this._clockOutButton.Text = "Clock Out";
            this._clockOutButton.UseVisualStyleBackColor = true;
            this._clockOutButton.Click += new System.EventHandler(this._clockOutButton_Click);
            // 
            // _checkLabel
            // 
            this._checkLabel.AutoSize = true;
            this._checkLabel.Location = new System.Drawing.Point(12, 42);
            this._checkLabel.Name = "_checkLabel";
            this._checkLabel.Size = new System.Drawing.Size(81, 13);
            this._checkLabel.TabIndex = 13;
            this._checkLabel.Text = "Check Number:";
            // 
            // _sourceLabel
            // 
            this._sourceLabel.AutoSize = true;
            this._sourceLabel.Location = new System.Drawing.Point(12, 15);
            this._sourceLabel.Name = "_sourceLabel";
            this._sourceLabel.Size = new System.Drawing.Size(93, 13);
            this._sourceLabel.TabIndex = 14;
            this._sourceLabel.Text = "Terminal (Source):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 262);
            this.Controls.Add(this._sourceLabel);
            this.Controls.Add(this._checkLabel);
            this.Controls.Add(this._clockInButton);
            this.Controls.Add(this._breakEndButton);
            this.Controls.Add(this._clockOutButton);
            this.Controls.Add(this._taxButton);
            this.Controls.Add(this._voidButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._totalButton);
            this.Controls.Add(this._checkTextbox);
            this.Controls.Add(this._breakStartButton);
            this.Controls.Add(this._channelCb);
            this.Controls.Add(this._closeCheckButton);
            this.Controls.Add(this._addItemButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button _totalButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button _voidButton;
        private System.Windows.Forms.Button _taxButton;
        private System.Windows.Forms.Button _clockInButton;
        private System.Windows.Forms.Button _breakEndButton;
        private System.Windows.Forms.Button _clockOutButton;
        private System.Windows.Forms.Label _checkLabel;
        private System.Windows.Forms.Label _sourceLabel;
    }
}

