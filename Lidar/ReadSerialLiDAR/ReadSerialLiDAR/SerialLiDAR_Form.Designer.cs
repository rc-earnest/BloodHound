namespace ReadSerialLiDAR
{
    partial class SerialLiDAR_Form
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CommPortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataLengthStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReadTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSerialPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.DisplayTextBox = new System.Windows.Forms.RichTextBox();
            this.LogFileCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ReceivedBytesThreshold = 40;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommPortStatusLabel,
            this.DataLengthStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 191);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(424, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CommPortStatusLabel
            // 
            this.CommPortStatusLabel.Name = "CommPortStatusLabel";
            this.CommPortStatusLabel.Size = new System.Drawing.Size(146, 25);
            this.CommPortStatusLabel.Text = "CommPortStatus";
            // 
            // DataLengthStatusLabel
            // 
            this.DataLengthStatusLabel.Name = "DataLengthStatusLabel";
            this.DataLengthStatusLabel.Size = new System.Drawing.Size(103, 25);
            this.DataLengthStatusLabel.Text = "DataLength";
            // 
            // ReadTimer
            // 
            this.ReadTimer.Tick += new System.EventHandler(this.ReadTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(424, 36);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSerialPortsToolStripMenuItem,
            this.PortsComboBox});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // refreshSerialPortsToolStripMenuItem
            // 
            this.refreshSerialPortsToolStripMenuItem.Name = "refreshSerialPortsToolStripMenuItem";
            this.refreshSerialPortsToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.refreshSerialPortsToolStripMenuItem.Text = "Refresh Serial Ports";
            this.refreshSerialPortsToolStripMenuItem.Click += new System.EventHandler(this.RecheckSerialPorts);
            // 
            // PortsComboBox
            // 
            this.PortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsComboBox.Name = "PortsComboBox";
            this.PortsComboBox.Size = new System.Drawing.Size(121, 33);
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayTextBox.Location = new System.Drawing.Point(0, 36);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.ReadOnly = true;
            this.DisplayTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.DisplayTextBox.Size = new System.Drawing.Size(424, 155);
            this.DisplayTextBox.TabIndex = 7;
            this.DisplayTextBox.Text = "";
            // 
            // LogFileCheckBox
            // 
            this.LogFileCheckBox.AutoSize = true;
            this.LogFileCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogFileCheckBox.Location = new System.Drawing.Point(0, 167);
            this.LogFileCheckBox.Name = "LogFileCheckBox";
            this.LogFileCheckBox.Size = new System.Drawing.Size(424, 24);
            this.LogFileCheckBox.TabIndex = 8;
            this.LogFileCheckBox.Text = "Log Raw Data to file?";
            this.LogFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // SerialLiDAR_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 223);
            this.Controls.Add(this.LogFileCheckBox);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "SerialLiDAR_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiDAR Data Logger";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CommPortStatusLabel;
        private System.Windows.Forms.Timer ReadTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshSerialPortsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox PortsComboBox;
        private System.Windows.Forms.ToolStripStatusLabel DataLengthStatusLabel;
        private System.Windows.Forms.RichTextBox DisplayTextBox;
        private System.Windows.Forms.CheckBox LogFileCheckBox;
    }
}

