namespace SSGenerator
{
    partial class EventsEditor
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
            this._inactiveButton = new System.Windows.Forms.Button();
            this._activeButton = new System.Windows.Forms.Button();
            this._newButton = new System.Windows.Forms.Button();
            this._editButton = new System.Windows.Forms.Button();
            this._activeListbox = new System.Windows.Forms.ListBox();
            this._inactiveListbox = new System.Windows.Forms.ListBox();
            this._deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _inactiveButton
            // 
            this._inactiveButton.Location = new System.Drawing.Point(245, 12);
            this._inactiveButton.Name = "_inactiveButton";
            this._inactiveButton.Size = new System.Drawing.Size(23, 23);
            this._inactiveButton.TabIndex = 2;
            this._inactiveButton.Text = ">";
            this._inactiveButton.UseVisualStyleBackColor = true;
            this._inactiveButton.Click += new System.EventHandler(this._inactiveButton_Click);
            // 
            // _activeButton
            // 
            this._activeButton.Location = new System.Drawing.Point(245, 41);
            this._activeButton.Name = "_activeButton";
            this._activeButton.Size = new System.Drawing.Size(23, 23);
            this._activeButton.TabIndex = 3;
            this._activeButton.Text = "<";
            this._activeButton.UseVisualStyleBackColor = true;
            this._activeButton.Click += new System.EventHandler(this._activeButton_Click);
            // 
            // _newButton
            // 
            this._newButton.Location = new System.Drawing.Point(12, 220);
            this._newButton.Name = "_newButton";
            this._newButton.Size = new System.Drawing.Size(75, 23);
            this._newButton.TabIndex = 4;
            this._newButton.Text = "New";
            this._newButton.UseVisualStyleBackColor = true;
            this._newButton.Click += new System.EventHandler(this._newButton_Click);
            // 
            // _editButton
            // 
            this._editButton.Location = new System.Drawing.Point(93, 220);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(75, 23);
            this._editButton.TabIndex = 5;
            this._editButton.Text = "Edit";
            this._editButton.UseVisualStyleBackColor = true;
            this._editButton.Click += new System.EventHandler(this._editButton_Click);
            // 
            // _activeListbox
            // 
            this._activeListbox.FormattingEnabled = true;
            this._activeListbox.Location = new System.Drawing.Point(12, 12);
            this._activeListbox.Name = "_activeListbox";
            this._activeListbox.Size = new System.Drawing.Size(227, 95);
            this._activeListbox.TabIndex = 6;
            // 
            // _inactiveListbox
            // 
            this._inactiveListbox.FormattingEnabled = true;
            this._inactiveListbox.Location = new System.Drawing.Point(274, 12);
            this._inactiveListbox.Name = "_inactiveListbox";
            this._inactiveListbox.Size = new System.Drawing.Size(227, 95);
            this._inactiveListbox.TabIndex = 7;
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(174, 220);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(75, 23);
            this._deleteButton.TabIndex = 8;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // EventsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 449);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._inactiveListbox);
            this.Controls.Add(this._activeListbox);
            this.Controls.Add(this._editButton);
            this.Controls.Add(this._newButton);
            this.Controls.Add(this._activeButton);
            this.Controls.Add(this._inactiveButton);
            this.Name = "EventsEditor";
            this.Text = "Event Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _inactiveButton;
        private System.Windows.Forms.Button _activeButton;
        private System.Windows.Forms.Button _newButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.ListBox _activeListbox;
        private System.Windows.Forms.ListBox _inactiveListbox;
        private System.Windows.Forms.Button _deleteButton;
    }
}