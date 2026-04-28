using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadSerialLiDAR
{
    public partial class SerialLiDAR_Form : Form
    {
        // ----------
        // VARIABLES
        // ----------
        int selectedIndex;
        string[] portNames;
        string filePath = "..\\..\\logs";
        //byte[] LiDARdata;
        private List<int> dataBuffer = new List<int>();

        // ----------
        // STARTUP
        // ----------
        public SerialLiDAR_Form()
        {
            InitializeComponent();
            SetDefaults();
            GetPorts();
        }
        void SetDefaults()
        {
            this.timer1.Enabled = false;
            this.Timer1DurationTrackbar.Value = 1;
            Timer1Change(1);
            CheckDirectory();
        }
        void GetPorts()
        {
            // Populates 1D array with all available serial ports
            portNames = SerialPort.GetPortNames();

            // Starts with blank text
            PortsComboBox.Text = "";

            // Clear array each itteration
            PortsComboBox.Items.Clear();
            try
            {
                // Populate combobox with the contents of the 1D array
                foreach (string portName in portNames)
                {
                    PortsComboBox.Items.Add(portName);
                    SerialConnect(portName);
                }
                if (portNames.Length > 0)
                {
                    // If array length is greater than 0, set index at 0
                    PortsComboBox.SelectedIndex = 0;
                }
                else
                {
                    // Clear items and add "empty" indicator
                    PortsComboBox.Items.Clear();
                    PortsComboBox.Items.Add("None");
                    PortsComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Clear ComboBox items
                PortsComboBox.Items.Clear();

                // Display error message
                Console.WriteLine($"{ex.Message}\n\nPress 'Cancel' to exit program or 'OK' to continue.",
                    "ERROR", MessageBoxButtons.OKCancel);
                if (DialogResult == DialogResult.Cancel)
                {
                    // FORCE QUIT the program
                    Environment.Exit(0);
                }
            }
            SetPortName();
        }
        void SerialConnect(string portName)
        {
            serialPort1.Close();
            try
            {
                // Tx/Rx settings ----------
                // Baud rate - the number of Bits/sec
                //serialPort1.StopBits = System.IO.Ports.StopBits.None;
                serialPort1.PortName = portNames[selectedIndex];
                serialPort1.BaudRate = 115_200;
                serialPort1.Parity = Parity.None;

                if (!serialPort1.IsOpen)
                {
                    // If port is not open, open it!
                    serialPort1.Open();
                }
            }
            catch (Exception ex)
            {
                // Show error message in console for debugging
                Console.WriteLine(ex.Message);
            }
        }
        void SetPortName()
        {
            try
            {
                // Translate selected index on combo box to selected port
                selectedIndex = PortsComboBox.SelectedIndex;
                if (serialPort1.IsOpen)
                {
                    // Display selected port
                    CommPortStatusLabel.Text = $"Active Port: {serialPort1.PortName}";
                }
                else
                {
                    // Display that NO port has been selected
                    CommPortStatusLabel.Text = "Active Port: None";
                }
            }
            catch
            {
                // Show error message for debugging
                Console.WriteLine("No ports available");
            }
        }
        void CheckDirectory()
        {
            // If directory does NOT exist, create before saving
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        // ----------
        // PROGRAM LOGIC
        // ----------
        void Timer1Change(int value)
        {
            // Track bar has a range of 100ms - 1000ms (1s)
            // Multiply the value of the track bar by 100, apply to timer interval propert
            this.timer1.Interval = value * 100;

            // Update visual indicator
            this.TMR1_IntervalTextBox.Text = $"Timer 1 Duration: {this.timer1.Interval}ms";
        }
        void LogDataToFile(byte[] data)
        {
            try
            {
                // Creates log files based on the hour - resets/creates new file every hour
                string path = $"{filePath}\\{DateTime.Now:yyMMddhh}_DataSample.log";
                using (StreamWriter currentFile = File.AppendText(path))
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        // Write the contents of the 1D array line-by-line to a file
                        currentFile.WriteLine($"ACQ TIME: {timer1.Interval.ToString()}ms | DATA: {data[i]}");
                    }
                }
            }
            catch (Exception ex)
            {
                ClusterControl(true);
                MessageBox.Show(ex.Message);
            }
        }
        void ClusterControl(bool value)
        {
            timer1.Enabled = !value;
            StartButton.Enabled = Timer1DurationTrackbar.Enabled = value;
        }
        byte[] GetData()
        {
            // Create a new 1D byte array with a length of the number of readable bytes
            byte[] LiDARdata = new byte[0];
            if (serialPort1.IsOpen)
            {
                // Flush old bytes from receive buffer to remove old data
                serialPort1.DiscardInBuffer();

                // Make array the size of the input buffer
                LiDARdata = new byte[serialPort1.BytesToRead];

                // Read input buffer with NO offset
                serialPort1.Read(LiDARdata, 0, LiDARdata.Length);
            }
            return LiDARdata;
        }

        // ----------
        // EVENT HANDLERS
        // ----------
        private void Timer1DurationTrackbar_Scroll(object sender, EventArgs e)
        {
            Timer1Change(Timer1DurationTrackbar.Value);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Disable timer and enable controls
            ClusterControl(true);

            // Sequentially retrieve and store/write received data
            LogDataToFile(GetData());
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Clear receive buffer
            serialPort1.DiscardInBuffer();

            // Enable timer and disable controls
            ClusterControl(false);
        }
        private void RecheckSerialPorts(object sender, EventArgs e)
        {
            GetPorts();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            this.Dispose();
        }
    }
}