namespace TCPListener_Program
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
            this.msgListView = new System.Windows.Forms.ListView();
            this.connectButton = new System.Windows.Forms.Button();
            this.statusListView = new System.Windows.Forms.ListView();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.byteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.charRichTextBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.charLabel = new System.Windows.Forms.Label();
            this.byteLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.messagesLabel = new System.Windows.Forms.Label();
            this.ackCB = new System.Windows.Forms.CheckBox();
            this._nullCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // msgListView
            // 
            this.msgListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.msgListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgListView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgListView.GridLines = true;
            this.msgListView.Location = new System.Drawing.Point(12, 52);
            this.msgListView.Name = "msgListView";
            this.msgListView.Size = new System.Drawing.Size(1248, 170);
            this.msgListView.TabIndex = 0;
            this.msgListView.UseCompatibleStateImageBehavior = false;
            this.msgListView.ItemActivate += new System.EventHandler(this.msgListView_ItemActivate);
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(301, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // statusListView
            // 
            this.statusListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusListView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusListView.GridLines = true;
            this.statusListView.Location = new System.Drawing.Point(12, 817);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(1248, 97);
            this.statusListView.TabIndex = 3;
            this.statusListView.UseCompatibleStateImageBehavior = false;
            this.statusListView.ItemActivate += new System.EventHandler(this.statusListView_ItemActivate);
            // 
            // ipTextBox
            // 
            this.ipTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTextBox.Location = new System.Drawing.Point(12, 10);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(177, 23);
            this.ipTextBox.TabIndex = 4;
            // 
            // portTextBox
            // 
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.Location = new System.Drawing.Point(195, 10);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 23);
            this.portTextBox.TabIndex = 5;
            // 
            // byteRichTextBox
            // 
            this.byteRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.byteRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.byteRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byteRichTextBox.Location = new System.Drawing.Point(487, 243);
            this.byteRichTextBox.Name = "byteRichTextBox";
            this.byteRichTextBox.Size = new System.Drawing.Size(773, 568);
            this.byteRichTextBox.TabIndex = 6;
            this.byteRichTextBox.Text = "";
            // 
            // charRichTextBox
            // 
            this.charRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.charRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charRichTextBox.Location = new System.Drawing.Point(12, 243);
            this.charRichTextBox.Name = "charRichTextBox";
            this.charRichTextBox.Size = new System.Drawing.Size(469, 568);
            this.charRichTextBox.TabIndex = 7;
            this.charRichTextBox.Text = "";
            // 
            // clearButton
            // 
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(382, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // charLabel
            // 
            this.charLabel.AutoSize = true;
            this.charLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charLabel.Location = new System.Drawing.Point(12, 225);
            this.charLabel.Name = "charLabel";
            this.charLabel.Size = new System.Drawing.Size(42, 15);
            this.charLabel.TabIndex = 9;
            this.charLabel.Text = "Chars";
            // 
            // byteLabel
            // 
            this.byteLabel.AutoSize = true;
            this.byteLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byteLabel.Location = new System.Drawing.Point(487, 225);
            this.byteLabel.Name = "byteLabel";
            this.byteLabel.Size = new System.Drawing.Size(42, 15);
            this.byteLabel.TabIndex = 10;
            this.byteLabel.Text = "Bytes";
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(463, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // messagesLabel
            // 
            this.messagesLabel.AutoSize = true;
            this.messagesLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesLabel.Location = new System.Drawing.Point(12, 36);
            this.messagesLabel.Name = "messagesLabel";
            this.messagesLabel.Size = new System.Drawing.Size(63, 15);
            this.messagesLabel.TabIndex = 12;
            this.messagesLabel.Text = "Messages";
            // 
            // ackCB
            // 
            this.ackCB.AutoSize = true;
            this.ackCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ackCB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ackCB.Location = new System.Drawing.Point(1216, 9);
            this.ackCB.Name = "ackCB";
            this.ackCB.Size = new System.Drawing.Size(44, 19);
            this.ackCB.TabIndex = 14;
            this.ackCB.Text = "Ack";
            this.ackCB.UseVisualStyleBackColor = true;
            this.ackCB.CheckedChanged += new System.EventHandler(this.ackCB_CheckedChanged);
            // 
            // _nullCB
            // 
            this._nullCB.AutoSize = true;
            this._nullCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._nullCB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nullCB.Location = new System.Drawing.Point(1077, 9);
            this._nullCB.Name = "_nullCB";
            this._nullCB.Size = new System.Drawing.Size(107, 19);
            this._nullCB.TabIndex = 15;
            this._nullCB.Text = "Replace Null";
            this._nullCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1272, 926);
            this.Controls.Add(this._nullCB);
            this.Controls.Add(this.ackCB);
            this.Controls.Add(this.messagesLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.byteLabel);
            this.Controls.Add(this.charLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.charRichTextBox);
            this.Controls.Add(this.byteRichTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.statusListView);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.msgListView);
            this.MinimumSize = new System.Drawing.Size(1280, 960);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "TCP Listener";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView msgListView;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListView statusListView;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.RichTextBox byteRichTextBox;
        private System.Windows.Forms.RichTextBox charRichTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label charLabel;
        private System.Windows.Forms.Label byteLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messagesLabel;
        private System.Windows.Forms.CheckBox ackCB;
        private System.Windows.Forms.CheckBox _nullCB;
    }
}

