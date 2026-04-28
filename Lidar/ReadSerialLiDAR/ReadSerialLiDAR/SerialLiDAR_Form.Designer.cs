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
            this.PortsComboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CommPortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer1DurationTrackbar = new System.Windows.Forms.TrackBar();
            this.TMR1_IntervalTextBox = new System.Windows.Forms.TextBox();
            this.CommPortLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSerialPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Timer1DurationTrackbar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortsComboBox
            // 
            this.PortsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsComboBox.FormattingEnabled = true;
            this.PortsComboBox.Location = new System.Drawing.Point(67, 335);
            this.PortsComboBox.Name = "PortsComboBox";
            this.PortsComboBox.Size = new System.Drawing.Size(143, 28);
            this.PortsComboBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommPortStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 32);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CommPortStatusLabel
            // 
            this.CommPortStatusLabel.Name = "CommPortStatusLabel";
            this.CommPortStatusLabel.Size = new System.Drawing.Size(187, 25);
            this.CommPortStatusLabel.Text = "CommPortStatusLabel";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Timer1DurationTrackbar
            // 
            this.Timer1DurationTrackbar.Location = new System.Drawing.Point(387, 306);
            this.Timer1DurationTrackbar.Minimum = 1;
            this.Timer1DurationTrackbar.Name = "Timer1DurationTrackbar";
            this.Timer1DurationTrackbar.Size = new System.Drawing.Size(246, 69);
            this.Timer1DurationTrackbar.TabIndex = 2;
            this.Timer1DurationTrackbar.Value = 1;
            this.Timer1DurationTrackbar.Scroll += new System.EventHandler(this.Timer1DurationTrackbar_Scroll);
            // 
            // TMR1_IntervalTextBox
            // 
            this.TMR1_IntervalTextBox.Location = new System.Drawing.Point(387, 367);
            this.TMR1_IntervalTextBox.Name = "TMR1_IntervalTextBox";
            this.TMR1_IntervalTextBox.ReadOnly = true;
            this.TMR1_IntervalTextBox.Size = new System.Drawing.Size(246, 26);
            this.TMR1_IntervalTextBox.TabIndex = 3;
            // 
            // CommPortLabel
            // 
            this.CommPortLabel.AutoSize = true;
            this.CommPortLabel.Location = new System.Drawing.Point(63, 306);
            this.CommPortLabel.Name = "CommPortLabel";
            this.CommPortLabel.Size = new System.Drawing.Size(160, 20);
            this.CommPortLabel.TabIndex = 4;
            this.CommPortLabel.Text = "Detected Serial Ports";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(248, 367);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(92, 38);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSerialPortsToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // refreshSerialPortsToolStripMenuItem
            // 
            this.refreshSerialPortsToolStripMenuItem.Name = "refreshSerialPortsToolStripMenuItem";
            this.refreshSerialPortsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.refreshSerialPortsToolStripMenuItem.Text = "Refresh Serial Ports";
            this.refreshSerialPortsToolStripMenuItem.Click += new System.EventHandler(this.RecheckSerialPorts);
            // 
            // SerialLiDAR_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CommPortLabel);
            this.Controls.Add(this.TMR1_IntervalTextBox);
            this.Controls.Add(this.Timer1DurationTrackbar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PortsComboBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerialLiDAR_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiDAR Serial Reader";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Timer1DurationTrackbar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PortsComboBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CommPortStatusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar Timer1DurationTrackbar;
        private System.Windows.Forms.TextBox TMR1_IntervalTextBox;
        private System.Windows.Forms.Label CommPortLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshSerialPortsToolStripMenuItem;
    }
}

