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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSerialPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.DisplayTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommPortStatusLabel,
            this.DataLengthStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 32);
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSerialPortsToolStripMenuItem,
            this.PortsComboBox});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(85, 32);
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
            this.DisplayTextBox.Size = new System.Drawing.Size(800, 382);
            this.DisplayTextBox.TabIndex = 7;
            this.DisplayTextBox.Text = "";
            // 
            // SerialLiDAR_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshSerialPortsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox PortsComboBox;
        private System.Windows.Forms.ToolStripStatusLabel DataLengthStatusLabel;
        private System.Windows.Forms.RichTextBox DisplayTextBox;
    }
}

