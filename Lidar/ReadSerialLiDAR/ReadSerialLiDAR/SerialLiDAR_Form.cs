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
        List<byte> dataBuffer = new List<byte>();

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
            //Timer1Change(1);
            CheckDirectory();
            DataLengthStatusLabel.Text = $"Bytes Read: 0";
            this.Text = "LiDAR Serial Data Logger";
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
                    //SerialConnect(portName);
                }
                if (portNames.Length > 0)
                {
                    // If array length is greater than 0, set index at 0
                    PortsComboBox.SelectedIndex = 0;
                    StartButton.Enabled = true;
                    SerialConnect(PortsComboBox.SelectedItem.ToString());
                }
                else
                {
                    // Clear items and add "empty" indicator
                    PortsComboBox.Items.Clear();
                    PortsComboBox.Items.Add("None");
                    PortsComboBox.SelectedIndex = 0;
                    StartButton.Enabled = false;
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
                // ----------
                // Tx/Rx SETTINGS
                // ----------
                // Baud rate - the number of Bits/sec
                serialPort1.PortName = portName;
                serialPort1.BaudRate = 115_200;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;

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
                    CommPortStatusLabel.Text = $"Active Port: {serialPort1.PortName}  |";
                }
                else
                {
                    // Display that NO port has been selected
                    CommPortStatusLabel.Text = "Active Port: None  |";
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
        void LogDataToFile(byte[] data)
        {
            try
            {
                // Creates log files based on the hour - resets/creates new file every hour
                string path = $"{filePath}\\{DateTime.Now:yyyyMMdd.HH00}_DataSample.log";
                using (StreamWriter currentFile = File.AppendText(path))
                {
                    string hex = BitConverter.ToString(data);
                    currentFile.WriteLine($"ACQ TIME: {timer1.Interval.ToString()}ms | DATA: {hex}");
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
            StartButton.Enabled = Timer1DurationTrackbar.Enabled = value;
        }
        byte[] GetData()
        {
            // Create a new 1D byte array with a length of the number of readable bytes
            byte[] newData = new byte[0];
            if (serialPort1.IsOpen)
            {
                // Make array the size of the input buffer
                newData = new byte[serialPort1.BytesToRead];

                // Update label for debugging
                DataLengthStatusLabel.Text = $"Bytes Read: {newData.Length}";

                // Read input buffer with NO offset
                serialPort1.Read(newData, 0, newData.Length);
            }
            return newData;
        }
        void ProcessBuffer()
        {
            while (dataBuffer.Count >= 4)
            {
                // Check if packet header is present
                if (dataBuffer[0] == 0xAA && dataBuffer[1] == 0x55)
                {
                    int length = dataBuffer[2];
                    if (dataBuffer.Count >= length)
                    {
                        byte[] packet = dataBuffer.Take(length).ToArray();

                        LogDataToFile(packet);

                        dataBuffer.RemoveRange(0, length);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    dataBuffer.RemoveAt(0);
                }
            }
        }

        // ----------
        // EVENT HANDLERS
        // ----------
        //private void Timer1DurationTrackbar_Scroll(object sender, EventArgs e)
        //{
        //    Timer1Change(Timer1DurationTrackbar.Value);
        //}
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    byte[] newData = GetData();
        //    //dataBuffer.AddRange(newData);

        //    //// Sequentially retrieve and store/write received data
        //    ////LogDataToFile(GetData());
        //    //ProcessBuffer();

        //    if (newData.Length > 0)
        //    {
        //        LogDataToFile(newData);
        //    }
        //}
        //private void StartButton_Click(object sender, EventArgs e)
        //{
        //    // Connect to the serial port
        //    SerialConnect(PortsComboBox.SelectedItem.ToString());

        //    // Clear receive buffer
        //    serialPort1.DiscardInBuffer();

        //    // Wait for buffer to fully clear
        //    Thread.Sleep(100);

        //    // Disable controls and enable timer
        //    //ClusterControl(false);
        //    StartButton.Enabled = false;
        //    timer1.Enabled = true;
        //}
        private void RecheckSerialPorts(object sender, EventArgs e)
        {
            GetPorts();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            this.Dispose();
        }
        private void SerialPort1DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = serialPort1.BytesToRead;
            byte[] buffer = new byte[bytes];

            serialPort1.Read(buffer, 0, bytes);

            LogDataToFile(buffer);
        }
    }
}