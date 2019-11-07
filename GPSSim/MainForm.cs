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

namespace GPSSim
{
	public partial class Form1 : Form
	{
		string selectedComPort = "NONE";

		private SerialPort serialPort;
		private bool connected;
		int loop = 0;

		//byte[] sout = new byte[1000];
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
//			serialPort.BaudRate = 9600;
            serialPort.BaudRate = 4800;

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
				int len = 0;
				sout[len++] = (char)0x02;	// STX

				try
				{
					// A - LAT
					sout[len++] = 'A';
					tbPayload1.Text.CopyTo(0, sout, len, 9);
					len += 9;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// B - LON
					sout[len++] = 'B';
					tbPayload2.Text.CopyTo(0, sout, len, 10);
					len += 10;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// C - TRACK
					sout[len++] = 'C';
					tbPayload3.Text.CopyTo(0, sout, len, 3);
					len += 3;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// D - GROUND SPEED
					sout[len++] = 'D';
					tbPayload4.Text.CopyTo(0, sout, len, 3);
					len += 3;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// E - DISTANCE TO WAYPOINT
					sout[len++] = 'E';
					tbPayload5.Text.CopyTo(0, sout, len, 5);
					len += 5;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// G - CROSS TRACK ERROR
					sout[len++] = 'G';
					tbPayload6.Text.CopyTo(0, sout, len, 5);
					len += 5;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// I - DESIRED TRACK
					sout[len++] = 'I';
					tbPayload7.Text.CopyTo(0, sout, len, 4);
					len += 4;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// K - WAYPOINT ID
					sout[len++] = 'K';
					// tbPayload8.Text.CopyTo(0, sout, len, 5);
					try { sout[len] = Convert.ToChar(tbPayload8.Text.Substring(0, 1)); len++; } catch { }
					try { sout[len] = Convert.ToChar(tbPayload8.Text.Substring(1, 1)); len++; } catch { }
					try { sout[len] = Convert.ToChar(tbPayload8.Text.Substring(2, 1)); len++; } catch { }
					try { sout[len] = Convert.ToChar(tbPayload8.Text.Substring(3, 1)); len++; } catch { }
					try { sout[len] = Convert.ToChar(tbPayload8.Text.Substring(4, 1)); len++; } catch { }
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// L - BEARING TO WAYPOINT
					sout[len++] = 'L';
					tbPayload9.Text.CopyTo(0, sout, len, 4);
					len += 4;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// Q - MAGVAR
					sout[len++] = 'Q';
					tbPayload10.Text.CopyTo(0, sout, len, 5);
					len += 5;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					//// S - NAV STATUS
					//sout[len++] = 'S';
					//tbPayload11.Text.CopyTo(0, sout, len, 5);
					//len += 5;
					//sout[len++] = (char)0x0d;   // CR
					//if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// T - NAV STATUS
					sout[len++] = 'T';
					tbPayload11.Text.CopyTo(0, sout, len, 5);
					len += 5;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)

					// l - DISTANCE TO DEST
					sout[len++] = 'l';
					tbPayload12.Text.CopyTo(0, sout, len, 5);
					len += 5;
					sout[len++] = (char)0x0d;   // CR
					if (cbAddLf.Checked) sout[len++] = (char)0x0a;  // LF)


					sout[len++] = (char)0x03;   // ETX


					// Output to port
					serialPort.Write(sout, 0, len);

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

					// Slew
					if (cbSlewTrack.Checked)
					{
						int track, increment, updated;
						int.TryParse(tbPayload3.Text, out track);
						int.TryParse(tbSlewRate.Text, out increment);
						updated = track + increment;
						if (updated > 360)
							updated = 0;
						tbPayload3.Text = (updated).ToString("000");
					}

				}
				catch
				{
					btTx.BackColor = Color.Gray;
				}
			}

				

		}

		private void cbComPort_SelectedIndexChanged(object sender, EventArgs e)
		{

			selectedComPort = cbComPort.Text;
		}
	}
}
