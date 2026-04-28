using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
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
        }
        void GetPorts()
        {
            portNames = SerialPort.GetPortNames();
            PortsComboBox.Text = "";

            // Clear array each itteration
            PortsComboBox.Items.Clear();
            try
            {
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

        // ----------
        // PROGRAM LOGIC
        // ----------
        void Timer1Change(int value)
        {
            this.timer1.Interval = value * 100;
            this.TMR1_IntervalTextBox.Text = $"Timer 1 Duration: {this.timer1.Interval}ms";
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

        }
    }
}