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

using CalTool;

namespace AhrsDisplayDemo
{

	public partial class MainForm : Form
	{
		public CalTool.LruCom lru0;
		public static string selectedPort;

		private double currentHeading = 0;
		private double accumHeading = 0;

		public MainForm()
		{
			InitializeComponent();
			//AhrsCom.setParentForm(this);

			// Create LRU Instance
			lru0 = new CalTool.LruCom(0);
			lru0.selectedComPort = "COM10";

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Load Initial Serial Ports
			string[] ports = SerialPort.GetPortNames();
			cbSerialPort.Items.Clear();
			cbSerialPort.Items.Add("Select");
			cbSerialPort.Items.AddRange(ports);
			selectedPort = "NONE";
		}

		// Get port
		public string getPfPort()
		{
			return selectedPort;
		}

		// Console output
		public void setConsoleText(string msg)
		{
			tbConsole.AppendText(msg + "\n");
		}


		private void cbSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbSerialPort.SelectedIndex > 0)
				selectedPort = this.cbSerialPort.SelectedItem.ToString();
			else
			{
				// Set to none and shutdown controller if it was connected
				selectedPort = "NONE";
				lru0.setDisconnect();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{


			double heading;
			double SCALE = 2000;

			lru0.update();
			btRoll.Text = lru0.dataParam[(int)PARAM.ROLL].ToString("F2");
			btPitch.Text = lru0.dataParam[(int)PARAM.PITCH].ToString("F2");
			BtVolts.Text = lru0.dataParam[(int)PARAM.VOLTS].ToString("F1");
			btMagX.Text = lru0.dataParam[(int)PARAM.MAGX].ToString("F1");
			btMagY.Text = lru0.dataParam[(int)PARAM.MAGY].ToString("F1");
			btMagZ.Text = lru0.dataParam[(int)PARAM.MAGZ].ToString("F1");
			btIas.Text = lru0.dataParam[(int)PARAM.IAS].ToString("F1");
			double alt = lru0.dataParam[(int)PARAM.BCA] * 10;
			btBca.Text = alt.ToString("F1");
			btOat.Text = lru0.dataParam[(int)PARAM.OATRAW].ToString("F1");
			btTas.Text = lru0.dataParam[(int)PARAM.TAS].ToString("F1");
			btAoa.Text = lru0.dataParam[(int)PARAM.AOA].ToString("F1");


			btMagXMin.BackColor = Color.Transparent;
			btMagYMin.BackColor = Color.Transparent;
			btMagZMin.BackColor = Color.Transparent;
			btMagXMax.BackColor = Color.Transparent;
			btMagYMax.BackColor = Color.Transparent;
			btMagZMax.BackColor = Color.Transparent;
			btMagXNorm.BackColor = Color.Transparent;
			btMagYNorm.BackColor = Color.Transparent;
			btMagZNorm.BackColor = Color.Transparent;

			if ((lru0.dataParam[(int)PARAM.MAGX] != 0) &&
					(lru0.dataParam[(int)PARAM.MAGY] != 0) &&
				(lru0.dataParam[(int)PARAM.MAGZ] != 0))
			{
				// Mag Min
				if (lru0.dataParam[(int)PARAM.MAGX] < double.Parse(btMagXMin.Text))
				{
					btMagXMin.Text = (lru0.dataParam[(int)PARAM.MAGX]).ToString("F1");
					btMagXMin.BackColor = Color.DarkGreen;
				}
				if (lru0.dataParam[(int)PARAM.MAGY]  < double.Parse(btMagYMin.Text))
				{
					btMagYMin.Text = (lru0.dataParam[(int)PARAM.MAGY] ).ToString("F1");
					btMagYMin.BackColor = Color.DarkGreen;
				}
				if (lru0.dataParam[(int)PARAM.MAGZ]  < double.Parse(btMagZMin.Text))
				{
					btMagZMin.Text = (lru0.dataParam[(int)PARAM.MAGZ] ).ToString("F1");
					btMagZMin.BackColor = Color.DarkGreen;
				}

				// Mag Max
				if (lru0.dataParam[(int)PARAM.MAGX]  > double.Parse(btMagXMax.Text))
				{ 
					btMagXMax.Text = (lru0.dataParam[(int)PARAM.MAGX] ).ToString("F1");
					btMagXMax.BackColor = Color.DarkGreen;
				}
				if (lru0.dataParam[(int)PARAM.MAGY] > double.Parse(btMagYMax.Text))
					{ 
					btMagYMax.Text = (lru0.dataParam[(int)PARAM.MAGY] ).ToString("F1");
					btMagYMax.BackColor = Color.DarkGreen;
				}
				if (lru0.dataParam[(int)PARAM.MAGZ]  > double.Parse(btMagZMax.Text))
						{ 
					btMagZMax.Text = (lru0.dataParam[(int)PARAM.MAGZ] ).ToString("F1");
					btMagZMax.BackColor = Color.DarkGreen;
				}

				btMagXDelta.Text = Math.Abs(double.Parse(btMagXMax.Text) - double.Parse(btMagXMin.Text)).ToString("F1");
				btMagYDelta.Text = Math.Abs(double.Parse(btMagYMax.Text) - double.Parse(btMagYMin.Text)).ToString("F1");
				btMagZDelta.Text = Math.Abs(double.Parse(btMagZMax.Text) - double.Parse(btMagZMin.Text)).ToString("F1");

				btMagXOffset.Text = (-double.Parse(btMagXMin.Text) - (double.Parse(btMagXDelta.Text) / 2)).ToString("F2");
				btMagYOffset.Text = (-double.Parse(btMagYMin.Text) - (double.Parse(btMagYDelta.Text) / 2)).ToString("F2");
				btMagZOffset.Text = (-double.Parse(btMagZMin.Text) - (double.Parse(btMagZDelta.Text) / 2)).ToString("F2");

				btMagXCent.Text = (lru0.dataParam[(int)PARAM.MAGX] + double.Parse(btMagXOffset.Text)).ToString("F3");
				btMagYCent.Text = (lru0.dataParam[(int)PARAM.MAGY] + double.Parse(btMagYOffset.Text)).ToString("F3");
				btMagZCent.Text = (lru0.dataParam[(int)PARAM.MAGZ] + double.Parse(btMagZOffset.Text)).ToString("F3");

				btMagXNorm.Text = (double.Parse(btMagXCent.Text) / (double.Parse(btMagXDelta.Text) / 2)).ToString("F3");
				btMagYNorm.Text = (double.Parse(btMagYCent.Text) / (double.Parse(btMagYDelta.Text) / 2)).ToString("F3");
				btMagZNorm.Text = (double.Parse(btMagZCent.Text) / (double.Parse(btMagZDelta.Text) / 2)).ToString("F3");

				if (Math.Abs(double.Parse(btMagXNorm.Text)) > 0.98)
					btMagXNorm.BackColor = Color.DarkGreen;
				if (Math.Abs(double.Parse(btMagYNorm.Text)) > 0.98)
					btMagYNorm.BackColor = Color.DarkGreen;
				if (Math.Abs(double.Parse(btMagZNorm.Text)) > 0.98)
					btMagZNorm.BackColor = Color.DarkGreen;


				// Computed Heading
				heading = Math.Atan2(double.Parse(btMagYNorm.Text), double.Parse(btMagXNorm.Text));
				if (heading < 0)
				{
					heading += 2 * 3.14;
				}
				heading *= 180 / 3.14;

				if ((heading > 0) && (heading < 360))
				{
					heading = 360.0 - heading;
					currentHeading = accumHeading / 10;
					accumHeading += heading - currentHeading;
				}

				btHeading.Text = currentHeading.ToString("F2");

				//heading = Math.Atan2(AhrsCom.magY / SCALE, AhrsCom.magX / SCALE);
				//if (heading < 0)
				//{
				//	heading += 2 * 3.14;
				//}
				//heading *= 180 / 3.14;
				//btHeading.Text = heading.ToString("F1");


			}

			this.Invalidate();

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void btMagY_Click(object sender, EventArgs e)
		{

		}

		private void tabControl1_SelectedIndexchanged(object sender, EventArgs e)
		{
			switch ((sender as TabControl).SelectedIndex)
			{
				case 0:


					break;
				case 1:
					// Tab 1 Ahrs Internal Data
					//AhrsCom.setCommand("$out=00,00\n\r");
					break;
			}
		}

		private void btConnect_Click(object sender, EventArgs e)
		{

			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_50HZ);

			lru0.setParameterReq((int)PARAM.BCA, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.IAS, RATE.RATE_1HZ);


			lru0.setParameterReq((int)PARAM.TAS, RATE.RATE_1HZ);
			//lru0.setParameterReq((int)PARAM.MAGX, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.MAGY, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.MAGZ, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.VOLTS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.AOA, RATE.RATE_1HZ);
		}

		private void btResetMinMax_Click_1(object sender, EventArgs e)
		{
			btMagXMin.Text = "9999.0";
			btMagYMin.Text = "9999.0";
			btMagZMin.Text = "9999.0";

			btMagXMax.Text = "-9999.0";
			btMagYMax.Text = "-9999.0";
			btMagZMax.Text = "-9999.0";
		}


		// Paint
		private void MainForm_Paint(object sender, PaintEventArgs e)
		{

			Bitmap buffer = new Bitmap(pbCompass.Size.Width, pbCompass.Size.Height);
			System.Drawing.Pen myPen;
			myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
			myPen.Width = 2;
			System.Drawing.Graphics g = Graphics.FromImage(buffer);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			int centerX = pbCompass.Size.Width / 2;
			int centerY = pbCompass.Size.Height / 2;
			double hdgDeg = double.Parse(btHeading.Text) - 180.0;
			double hdgRad = hdgDeg * (3.14 / 180);

			g.DrawLine(myPen, centerX, centerY,
				centerX - (float)Math.Sin(hdgRad) * (centerX),
						centerY + (float)Math.Cos(hdgRad) * (centerY));

			pbCompass.Image = buffer;
			myPen.Dispose();
			g.Dispose();
		}




	}


}
