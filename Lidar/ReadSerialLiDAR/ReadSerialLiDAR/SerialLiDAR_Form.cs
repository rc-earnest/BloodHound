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
        // Variables
        // ----------
        int selectedIndex;

        // ----------
        // Startup
        // ----------
        public SerialLiDAR_Form()
        {
            InitializeComponent();
            SetDefaults();
            GetPorts();
        }
        void SetDefaults()
        {

        }
        void GetPorts()
        {

            SetPortName();
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
    }
}