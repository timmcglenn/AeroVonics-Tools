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

namespace UATSim
{
	public partial class Form1 : Form
	{
		string selectedComPort = "NONE";

		private SerialPort serialPort;
		private bool connected;
		int loop = 0;
		byte[] sout = new byte[1000];
		double trackRotate = 0;

		public Form1()
		{
			InitializeComponent();
			connected = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Load Initial Serial Ports
			string[] ports = SerialPort.GetPortNames();
			cbComPort.Items.Clear();
			cbComPort.Items.Add("Select");
			cbComPort.Items.AddRange(ports);
			btTx.BackColor = Color.Gray;

		}

		private void cbComPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedComPort = cbComPort.Text;
		}

		private void btConnect_Click(object sender, EventArgs e)
		{

			// Try to connect to selected port
			serialPort = new SerialPort();
			serialPort.PortName = selectedComPort;
			serialPort.BaudRate = 9600;
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

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				serialPort.Close();
			}
			catch { };
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			timer.Enabled = true;
		}

		private void btStop_Click(object sender, EventArgs e)
		{
			timer.Enabled = false;
			btTx.BackColor = Color.Gray;

		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (connected)
			{
				int len = 0;

				// Heartbeat
				if (cbHbEnable.Checked)
				{
					sout[len++] = (byte)0x7E;
					sout[len++] = (byte)0x00;
					sout[len++] = (byte)0x81;
					sout[len++] = (byte)0x41;
					sout[len++] = (byte)0xdb;
					sout[len++] = (byte)0xd0;
					sout[len++] = (byte)0x08;
					sout[len++] = (byte)0x02;
					sout[len++] = (byte)0xb3;
					sout[len++] = (byte)0x8b;
					sout[len++] = (byte)0x7E;
				}

				// Ownship
				if (cbOwnEnable.Checked)
				{
					// Header
					sout[len++] = (byte)0x7E;
					// Report Type
					sout[len++] = (byte)10;	// Ownship
					// st
					sout[len++] = (byte)0x00;	
					// aa
					sout[len++] = (byte)0xAB;
					sout[len++] = (byte)0x45;
					sout[len++] = (byte)0x49;
					// ll
					double fLat = double.Parse(tbOwnLat.Text);
					if (fLat > 90.0) fLat = 90.0;
					if (fLat < -90.0) fLat = -90.0;
					fLat *= (0x800000 / 180);
					int iLat = (int)(fLat);
					if (iLat < 0) iLat = (0x1000000 + iLat) & 0xffffff;
					sout[len++] = (byte)((iLat & 0x00ff0000) >> 16);
					sout[len++] = (byte)((iLat & 0x0000ff00) >> 8);
					sout[len++] = (byte)((iLat & 0x000000ff));
					// nn
					double fLon = double.Parse(tbOwnLon.Text);
					if (fLon > 180.0) fLon = 180.0;
					if (fLon < -180.0) fLon = -180.0;
					fLon *= (0x800000 / 180);
					int iLon = (int)(fLon);
					if (iLon < 0) iLon = (0x1000000 + iLon) & 0xffffff;
					sout[len++] = (byte)((iLon & 0x00ff0000) >> 16);
					sout[len++] = (byte)((iLon & 0x0000ff00) >> 8);
					sout[len++] = (byte)((iLon & 0x000000ff));
					// dd
					sout[len++] = (byte)0x0F;
					// dm
					sout[len++] = (byte)0x09;
					// ia
					sout[len++] = (byte)0xA9;
					// hh
					sout[len++] = (byte)0x07;
					// hv
					sout[len++] = (byte)0xB0;
					// vv
					sout[len++] = (byte)0x01;
					// tt - Track
					double fTrack = double.Parse(tbOwnTrk.Text);
					fTrack /= (360.0 / 256.0);
					byte bTrack = (byte)(fTrack);
					sout[len++] = bTrack;
					// ee
					sout[len++] = (byte)0x01;
					// cc
					sout[len++] = (byte)0x4E;
					sout[len++] = (byte)0x38;
					sout[len++] = (byte)0x32;
					sout[len++] = (byte)0x35;
					sout[len++] = (byte)0x56;
					sout[len++] = (byte)0x20;
					sout[len++] = (byte)0x20;
					sout[len++] = (byte)0x20;
					// px
					sout[len++] = (byte)0x00;
					// Footer
					sout[len++] = (byte)0x7E;

				}

				// Target #1
				if (cbTrg1Enable.Checked)
				{

					// Header
					sout[len++] = (byte)0x7E;
					// Report Type
					sout[len++] = (byte)20;	// Target
					// st
					sout[len++] = (byte)0x00;
					// aa
					sout[len++] = (byte)0xAB;
					sout[len++] = (byte)0x45;
					sout[len++] = (byte)0x49;
					// ll
					double fLat = double.Parse(tbTrg1Lat.Text);
					if (fLat > 90.0) fLat = 90.0;
					if (fLat < -90.0) fLat = -90.0;
					fLat *= (0x800000 / 180);
					int iLat = (int)(fLat);
					if (iLat < 0) iLat = (0x1000000 + iLat) & 0xffffff;
					sout[len++] = (byte)((iLat & 0x00ff0000) >> 16);
					sout[len++] = (byte)((iLat & 0x0000ff00) >> 8);
					sout[len++] = (byte)((iLat & 0x000000ff));
					// nn
					double fLon = double.Parse(tbTrg1Lon.Text);
					if (fLon > 180.0) fLon = 180.0;
					if (fLon < -180.0) fLon = -180.0;
					fLon *= (0x800000 / 180);
					int iLon = (int)(fLon);
					if (iLon < 0) iLon = (0x1000000 + iLon) & 0xffffff;
					sout[len++] = (byte)((iLon & 0x00ff0000) >> 16);
					sout[len++] = (byte)((iLon & 0x0000ff00) >> 8);
					sout[len++] = (byte)((iLon & 0x000000ff));
					// dd
					sout[len++] = (byte)0x0F;
					// dm
					sout[len++] = (byte)0x09;
					// ia
					sout[len++] = (byte)0xA9;
					// hh
					sout[len++] = (byte)0x07;
					// hv
					sout[len++] = (byte)0xB0;
					// vv
					sout[len++] = (byte)0x01;
					// tt - Track
					//double fTrack = double.Parse(tbTrg1Trk.Text);

					double fTrack = trackRotate;
					trackRotate += 45;
					if (trackRotate > 180) trackRotate = -180;

					fTrack /= (360.0 / 256.0);
					byte bTrack = (byte)(fTrack);
					sout[len++] = bTrack;
					// ee
					sout[len++] = (byte)0x01;
					// cc
					sout[len++] = (byte)0x4E;
					sout[len++] = (byte)0x38;
					sout[len++] = (byte)0x32;
					sout[len++] = (byte)0x35;
					sout[len++] = (byte)0x56;
					sout[len++] = (byte)0x20;
					sout[len++] = (byte)0x20;
					sout[len++] = (byte)0x20;
					// px
					sout[len++] = (byte)0x00;
					// Footer
					sout[len++] = (byte)0x7E;


					//sout[len++] = (byte)0x7E;
					//sout[len++] = (byte)20;
					//sout[len++] = (byte)0x00;
					//sout[len++] = (byte)0xAB;
					//sout[len++] = (byte)0x45;
					//sout[len++] = (byte)0x49;
					//sout[len++] = (byte)0x1F;
					//sout[len++] = (byte)0xEF;
					//sout[len++] = (byte)0x15;
					//sout[len++] = (byte)0xA8;
					//sout[len++] = (byte)0x89;
					//sout[len++] = (byte)0x78;
					//sout[len++] = (byte)0x0F;
					//sout[len++] = (byte)0x09;
					//sout[len++] = (byte)0xA9;
					//sout[len++] = (byte)0x07;
					//sout[len++] = (byte)0xB0;
					//sout[len++] = (byte)0x01;
					//sout[len++] = (byte)0x20;
					//sout[len++] = (byte)0x01;
					//sout[len++] = (byte)0x4E;
					//sout[len++] = (byte)0x38;
					//sout[len++] = (byte)0x32;
					//sout[len++] = (byte)0x35;
					//sout[len++] = (byte)0x56;
					//sout[len++] = (byte)0x20;
					//sout[len++] = (byte)0x20;
					//sout[len++] = (byte)0x20;
					//sout[len++] = (byte)0x00;
					//sout[len++] = (byte)0x7E;

				}


				// Add encoding here

				// Output to port
				serialPort.Write(sout, 0, len);

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




}
