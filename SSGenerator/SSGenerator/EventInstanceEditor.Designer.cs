namespace SSGenerator
{
    partial class EventInstanceEditor
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
            this._cancelButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._panel = new System.Windows.Forms.Panel();
            this._deltaTextbox = new System.Windows.Forms.TextBox();
            this._nameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(197, 397);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(12, 397);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 1;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _panel
            // 
            this._panel.Location = new System.Drawing.Point(12, 64);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(260, 327);
            this._panel.TabIndex = 2;
            // 
            // _deltaTextbox
            // 
            this._deltaTextbox.Location = new System.Drawing.Point(172, 38);
            this._deltaTextbox.Name = "_deltaTextbox";
            this._deltaTextbox.Size = new System.Drawing.Size(100, 20);
            this._deltaTextbox.TabIndex = 3;
            // 
            // _nameTextbox
            // 
            this._nameTextbox.Location = new System.Drawing.Point(172, 12);
            this._nameTextbox.Name = "_nameTextbox";
            this._nameTextbox.Size = new System.Drawing.Size(100, 20);
            this._nameTextbox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Delta:";
            // 
            // EventInstanceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 434);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._nameTextbox);
            this.Controls.Add(this._deltaTextbox);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._cancelButton);
            this.Name = "EventInstanceEditor";
            this.Text = "EventInstanceEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.TextBox _deltaTextbox;
        private System.Windows.Forms.TextBox _nameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}