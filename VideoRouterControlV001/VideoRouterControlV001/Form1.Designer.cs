namespace VideoRouterControlV001
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
            this.button1 = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.ChannelInputTextBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.RadioInput = new System.Windows.Forms.RadioButton();
            this.RadioOutput = new System.Windows.Forms.RadioButton();
            this.ButtonLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(595, 561);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(595, 586);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(676, 586);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // ChannelInputTextBox
            // 
            this.ChannelInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChannelInputTextBox.Location = new System.Drawing.Point(99, 568);
            this.ChannelInputTextBox.Name = "ChannelInputTextBox";
            this.ChannelInputTextBox.Size = new System.Drawing.Size(258, 38);
            this.ChannelInputTextBox.TabIndex = 4;
            this.ChannelInputTextBox.TextChanged += new System.EventHandler(this.ChannelInputTextBox_TextChanged);
            this.ChannelInputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeys);
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(363, 568);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 38);
            this.EnterButton.TabIndex = 5;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // RadioInput
            // 
            this.RadioInput.AutoSize = true;
            this.RadioInput.Location = new System.Drawing.Point(444, 566);
            this.RadioInput.Name = "RadioInput";
            this.RadioInput.Size = new System.Drawing.Size(54, 17);
            this.RadioInput.TabIndex = 6;
            this.RadioInput.TabStop = true;
            this.RadioInput.Text = "Inputs";
            this.RadioInput.UseVisualStyleBackColor = true;
            this.RadioInput.CheckedChanged += new System.EventHandler(this.RadioInput_CheckedChanged);
            // 
            // RadioOutput
            // 
            this.RadioOutput.AutoSize = true;
            this.RadioOutput.Location = new System.Drawing.Point(444, 589);
            this.RadioOutput.Name = "RadioOutput";
            this.RadioOutput.Size = new System.Drawing.Size(62, 17);
            this.RadioOutput.TabIndex = 7;
            this.RadioOutput.TabStop = true;
            this.RadioOutput.Text = "Outputs";
            this.RadioOutput.UseVisualStyleBackColor = true;
            // 
            // ButtonLabel
            // 
            this.ButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLabel.Location = new System.Drawing.Point(4, 565);
            this.ButtonLabel.Name = "ButtonLabel";
            this.ButtonLabel.Size = new System.Drawing.Size(113, 45);
            this.ButtonLabel.TabIndex = 8;
            this.ButtonLabel.Text = "C-00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(3, 24);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(184, 33);
            this.StatusLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(763, 621);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ChannelInputTextBox);
            this.Controls.Add(this.ButtonLabel);
            this.Controls.Add(this.RadioOutput);
            this.Controls.Add(this.RadioInput);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.TextBox ChannelInputTextBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.RadioButton RadioInput;
        private System.Windows.Forms.RadioButton RadioOutput;
        private System.Windows.Forms.Label ButtonLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label StatusLabel;
    }
}