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
using System.Xml;

namespace ReadSerialLiDAR
{
    public partial class SerialLiDAR_Form : Form
    {
        // ----------
        // VARIABLES
        // ----------
        string[] portNames;
        string filePath = "..\\..\\logs";
        int bytes;

        // ----------
        // STARTUP
        // ----------
        public SerialLiDAR_Form()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.serialPort1.DataReceived += SerialPort1DataReceived;
            SetDefaults();
            GetPorts();
        }
        void SetDefaults()
        {
            this.ReadTimer.Enabled = true;
            //this.ReadTimer.Interval = 1000;

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
                }
                if (portNames.Length > 0)
                {
                    // If array length is greater than 0, set index at 0
                    PortsComboBox.SelectedIndex = 0;

                    // Connect to port at index 0
                    SerialConnect(PortsComboBox.SelectedItem.ToString());
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
                if (serialPort1.IsOpen)
                {
                    // Display selected port
                    CommPortStatusLabel.Text = $"Active Port: {serialPort1.PortName} - Open: {serialPort1.IsOpen} |";
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
        void LogDataToFile(string[] data)
        {
            try
            {
                // Creates log files based on the hour - resets/creates new file every hour
                string path = $"{filePath}\\{DateTime.Now:yyyyMMdd.HH00}_DataSample.log";

                using (StreamWriter currentFile = File.AppendText(path))
                {
                    //string hex = BitConverter.ToString(data);
                    foreach (string line in data)
                    {
                        if (line.ToString() != "Split packet - disregard")
                        {
                            this.DisplayTextBox.Text = line;
                            string formattedData = $"ACQ: {DateTime.Now:yyyyMMdd.HHmm}:{DateTime.Now.Millisecond} | DATA:\n{line}\n\n";
                            currentFile.WriteLine(formattedData);
                        }
                        //DisplayTextBox.Text += formattedData;
                    }
                }
            }
            catch (Exception ex)
            {
                //ClusterControl(true);
                MessageBox.Show(ex.Message);
            }
        }

        // ----------
        // EVENT HANDLERS
        // ----------
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
            bytes = serialPort1.BytesToRead;
            DataLengthStatusLabel.Text = $"Bytes Read: {bytes}";
        }
        private void ReadTimer_Tick(object sender, EventArgs e)
        {
            int offset = serialPort1.BytesToRead;
            byte[] buffer = new byte[offset];
            serialPort1.Read(buffer, 0, offset);

            // Converts Rx'd data into Hexadecimal values
            string hex = BitConverter.ToString(buffer);

            // Replaces dashes with blank spaces for file
            hex = hex.Replace("-", " ");

            // Stores packet header for file/display format
            string[] chars = { "AA 55" };

            // Split/remove header from format
            string[] temp = hex.Split(chars, StringSplitOptions.None);
            
            for (int i = 0; i < temp.GetUpperBound(0)-1; i++)
            {
                if (i != 0)
                {
                    // Concat "AA 55" header
                    temp[i] = "AA 55" + temp[i];
                }
                else
                {
                    temp[i] = "Split packet - disregard";
                }
            }
            LogDataToFile(temp);
        }
    }
}