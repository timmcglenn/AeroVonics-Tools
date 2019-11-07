using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ApaSim
{
    public partial class Form1 : Form
    {
        string selectedComPort = "NONE";

        private SerialPort serialPort;
        private bool connected;
        int loop = 0;

        private int rollDir = 1;
        private int pitchDir = 1;
        private int yawDir = 1;
        private int hdgDatumDir = 5;
        private int crsDatumDir = 1;

        char[] sout = new char[1000];

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load Initial Serial Ports
            string[] ports = SerialPort.GetPortNames();
            cbComPort.Items.Clear();
            cbComPort.Items.Add("Select");
            cbComPort.Items.AddRange(ports);

        }

        public Form1()
        {
            InitializeComponent();
        }



        private void btConnect_Click(object sender, EventArgs e)
        {

            // Try to connect to selected port
            serialPort = new SerialPort();
            serialPort.PortName = selectedComPort;
            serialPort.BaudRate = 38400;
            serialPort.DataBits = 8;
            serialPort.Parity = 0;
            serialPort.ReadTimeout = 0;
            serialPort.WriteTimeout = 10;
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;

            try
            {
                serialPort.Open();
                connected = true;
            }
            catch
            {
                connected = false;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (connected)
            {

                // Output AV Format Data
                int len = 0;

                // Autoslew
                if (cbAutoSlew.Checked)
                {

                    if ((sliderRoll.Value >= 4095) || ((sliderRoll.Value <= 0)))
                    {
                        rollDir *= -1;
                    }
                    sliderRoll.Value += rollDir;
                    if ((sliderPitch.Value >= 4095) || ((sliderPitch.Value <= 0)))
                    {
                        pitchDir *= -1;
                    }
                    sliderPitch.Value += pitchDir;
                    if ((sliderYaw.Value >= 4095) || ((sliderYaw.Value <= 0)))
                    {
                        yawDir *= -1;
                    }
                    sliderYaw.Value += yawDir;
                    if ((sliderHdgDatum.Value >= 4095) || ((sliderHdgDatum.Value <= 0)))
                    {
                        hdgDatumDir *= -1;
                    }
                    sliderHdgDatum.Value += hdgDatumDir;

                    if ((sliderCrsDatum.Value >= 4095) || ((sliderCrsDatum.Value <= 0)))
                    {
                        crsDatumDir *= -1;
                    }
                    sliderCrsDatum.Value += crsDatumDir;
                }

                // sout[len++] = (char)0x02;   // STX

                try
                {
                    // Status (10)
                    if (cbSendStatus.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '0'; sout[len++] = '=';
                        tbStatus.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }

                    // Roll (11)
                    if (cbSendRoll.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '1'; sout[len++] = '=';
                        tbRoll.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }

                    // Pitch (12)
                    if (cbSendPitch.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '2'; sout[len++] = '=';
                        tbPitch.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }

                    // Yaw (13)
                    if (cbSendYaw.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '3'; sout[len++] = '=';
                        tbYaw.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }

                    // Hdg Datum (14)
                    if (cbSendHdgDatum.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '4'; sout[len++] = '=';
                        tbHdgDatum.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }

                    // Crs Datum (15)
                    if (cbSendCrsDatum.Checked)
                    {
                        sout[len++] = '1'; sout[len++] = '5'; sout[len++] = '=';
                        tbCrsDatum.Text.CopyTo(0, sout, len, 4);
                        len += 4;
                        sout[len++] = (char)0x0d;  // CR
                        sout[len++] = (char)0x0a;  // LF
                    }


                    //sout[len++] = (char)0x03;   // ETX

                    // Null Terminate
                    sout[len++] = (char)0x00;

                    // Output String
                    string tempString = new string(sout);
                    tempString = tempString.Replace('\u000D', ' ');
                    tempString = tempString.Replace('\u000A', ' ');
                    tbOutputString.Text = tempString;


                    // Output to port
                    serialPort.Write(sout, 0, len - 1);


                }
                catch
                {
                    btTx.BackColor = Color.Gray;
                }


                if (loop == 1)
                {
                    btTx.BackColor = Color.Gray;
                    loop = 0;
                }
                else
                {
                    btTx.BackColor = Color.Green;
                    loop = 1;
                }
            }



        }

        private void cbComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedComPort = cbComPort.Text;

            // Try to connect to selected port
            serialPort = new SerialPort();
            serialPort.PortName = selectedComPort;
            serialPort.BaudRate = 38400;
            serialPort.DataBits = 8;
            serialPort.Parity = 0;
            serialPort.ReadTimeout = 0;
            serialPort.WriteTimeout = 10;
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;

            try
            {
                serialPort.Open();
                connected = true;
            }
            catch
            {
                connected = false;
            }

        }

        //private void SliderRoll_Scroll(object sender, EventArgs e)
        //{
        //    selectedComPort = cbComPort.Text;
        //}

        private void SliderRoll_ValueChanged(object sender, EventArgs e)
        {
            tbRoll.Text = String.Format("{0:0000}", sliderRoll.Value);
        }

        private void SliderPitch_ValueChanged(object sender, EventArgs e)
        {
            tbPitch.Text = String.Format("{0:0000}", sliderPitch.Value);
        }

        private void SliderYaw_ValueChanged(object sender, EventArgs e)
        {
            tbYaw.Text = String.Format("{0:0000}", sliderYaw.Value);
        }
        private void SliderHdgDatum_ValueChanged(object sender, EventArgs e)
        {
            tbHdgDatum.Text = String.Format("{0:0000}", sliderHdgDatum.Value);
        }
        private void SliderCrsDatum_ValueChanged(object sender, EventArgs e)
        {
            tbCrsDatum.Text = String.Format("{0:0000}", sliderCrsDatum.Value);
        }
    }
}
