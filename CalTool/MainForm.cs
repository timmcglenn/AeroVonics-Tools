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
using System.Drawing.Imaging;
using System.Drawing.Printing;


namespace CalTool
{
	public partial class MainForm : Form
	{



		// State variables
		string PfSelectedPort = "NONE";
		public static string AdSelectedPort = "NONE";

		public static string cbLru0SelectedPort = "NONE";
		public static string cbLru1SelectedPort = "NONE";
		public static string cbLru2SelectedPort = "NONE";
		public static string cbLru3SelectedPort = "NONE";

		public LruCom lru0;
		public LruCom lru1;
		public LruCom lru2;
		public LruCom lru3;

		public int selectedGyro = 0;
		public bool idWasRequested = false;

		public double rollOffset = 0;
		public double pitchOffset = 0;

		public MainForm()
		{
			InitializeComponent();
		}



		private void MainForm_Load(object sender, EventArgs e)
		{


			// Load Initial Serial Ports
			string[] ports = SerialPort.GetPortNames();
			cbPfPortSel.Items.Clear();
			cbPfPortSel.Items.Add("Select");
			cbPfPortSel.Items.AddRange(ports);

			cbAdPortSel.Items.Clear();
			cbAdPortSel.Items.Add("Select");
			cbAdPortSel.Items.AddRange(ports);

			cbLru0PortSel.Items.Clear();
			cbLru0PortSel.Items.Add("Select");
			cbLru0PortSel.Items.AddRange(ports);

			cbLru1PortSel.Items.Clear();
			cbLru1PortSel.Items.Add("Select");
			cbLru1PortSel.Items.AddRange(ports);

			cbLru2PortSel.Items.Clear();
			cbLru2PortSel.Items.Add("Select");
			cbLru2PortSel.Items.AddRange(ports);

			cbLru3PortSel.Items.Clear();
			cbLru3PortSel.Items.Add("Select");
			cbLru3PortSel.Items.AddRange(ports);

			// Create LRU Instances
			lru0 = new LruCom(0);
			lru1 = new LruCom(1);
			lru2 = new LruCom(2);
			lru3 = new LruCom(3);

			// Set defaut com ports to default field text values
			lru0.selectedComPort = cbLru0PortSel.Text;
			lru1.selectedComPort = cbLru1PortSel.Text;
			lru2.selectedComPort = cbLru2PortSel.Text;
			lru3.selectedComPort = cbLru3PortSel.Text;

			AdSelectedPort = cbAdPortSel.Text;
			PfSelectedPort = cbPfPortSel.Text;

			// Kick off timer 
			formUpdateTimer.Enabled = true;

		}

		// Accessors - these allow support functions to get UI states
		// Positioning Fixture COM Port
		public string getPfPort()
		{
			return PfSelectedPort;
			//if (this.cbPfPortSel.SelectedIndex > -1)
			//	return (this.cbPfPortSel.SelectedItem.ToString());
			//else
			//	return ("NONE");
		}

		// Console output
		public void setConsoleText(string src, string msg)
		{
			if (src == "PF" && cbPfConsoleOn.Checked)
				tbConsole.AppendText(msg + "\n");
			if (src == "AD" && cbAdConsoleOn.Checked)
				tbConsole.AppendText(msg + "\n");

		}


		// Main Timer Update
		private void formUpdateTimer_Tick(object sender, EventArgs e)
		{

			// Update components
			PosFixture.setParentForm(this);
			PosFixture.update();

			CalAccel.setParentForm(this);
			CalAccel.update();

			AdtsCom.setParentForm(this);
			AdtsCom.update();

			CycleAdc.setParentForm(this);
			CycleAdc.update();

			CalAdc.setParentForm(this);
			CalAdc.update();

			AtpAdc.setParentForm(this);
			AtpAdc.update();

			SerialNum.setParentForm(this);
			SerialNum.update();

			CalAccel.setParentForm(this);
			CalAccel.update();

			CalGyro.setParentForm(this);
			CalGyro.update();

			AtpGyro.setParentForm(this);
			AtpGyro.update();

			//CalMag.setParentForm(this);
			//CalMag.update();

			BrdTest.setParentForm(this);
			BrdTest.update();

			Mops.setParentForm(this);
			Mops.update();

			// Update LRUs if enabled
			if (cbLru0Use.Checked)
				lru0.update();

			if (cbLru1Use.Checked)
				lru1.update();

			if (cbLru2Use.Checked)
				lru2.update();

			if (cbLru3Use.Checked)
				lru3.update();


			// LRU port status

			// Scan for any new ports if cb is not dropped down
			//if (!cbLru0PortSel.DroppedDown)
			//{
			//	string[] ports = SerialPort.GetPortNames();
			//	cbLru0PortSel.Items.Clear();
			//	cbLru0PortSel.Items.Add("Disconnect");
			//	cbLru0PortSel.Items.AddRange(ports);
			//}
			//if (!cbLru1PortSel.DroppedDown)
			//{
			//	string[] ports = SerialPort.GetPortNames();
			//	cbLru1PortSel.Items.Clear();
			//	cbLru1PortSel.Items.Add("Disconnect");
			//	cbLru1PortSel.Items.AddRange(ports);
			//}
			//if (!cbLru2PortSel.DroppedDown)
			//{
			//	string[] ports = SerialPort.GetPortNames();
			//	cbLru2PortSel.Items.Clear();
			//	cbLru2PortSel.Items.Add("Disconnect");
			//	cbLru2PortSel.Items.AddRange(ports);
			//}
			//if (!cbLru3PortSel.DroppedDown)
			//{
			//	string[] ports = SerialPort.GetPortNames();
			//	cbLru3PortSel.Items.Clear();
			//	cbLru3PortSel.Items.Add("Disconnect");
			//	cbLru3PortSel.Items.AddRange(ports);
			//}




			// Position Fixture port status indications
			if (PosFixture.getPortStatus())
			{
				btPfPortStatus.Text = "CONNECTED";
				btPfPortStatus.BackColor = Color.Green;
			}
			else
			{
				btPfPortStatus.Text = "NOT CONNECTED";
				btPfPortStatus.BackColor = Color.Red;

				// Scan for any new ports if cb is not dropped down
				if (!cbPfPortSel.DroppedDown)
				{
					string[] ports = SerialPort.GetPortNames();
					cbPfPortSel.Items.Clear();
					cbPfPortSel.Items.Add("Disconnect");
					cbPfPortSel.Items.AddRange(ports);
				}
			}


			// Unit Status
			if (cbLru0Use.Checked && lru0.getUnitConnected())
			{
				int status = (int)lru0.dataParam[(int)PARAM.STATUS];
				if ((status & STATUS.AHRS_STABLE) != 0)
					btLru0AhrsStable.BackColor = Color.ForestGreen;
				else
					btLru0AhrsStable.BackColor = Color.DarkGray;
				if ((status & STATUS.PITOT_TEMP_STABLE) != 0)
					btLru0PHeat.BackColor = Color.ForestGreen;
				else
					btLru0PHeat.BackColor = Color.DarkGray;
				if ((status & STATUS.STATIC_TEMP_STABLE) != 0)
					btLru0SHeat.BackColor = Color.ForestGreen;
				else
					btLru0SHeat.BackColor = Color.DarkGray;
			}
			else
			{
				btLru0AhrsStable.BackColor = Color.DarkGray;
				btLru0PHeat.BackColor = Color.DarkGray;
				btLru0SHeat.BackColor = Color.DarkGray;

			}

			if (cbLru1Use.Checked && lru1.getUnitConnected())
			{
				int status = (int)lru1.dataParam[(int)PARAM.STATUS];
				if ((status & STATUS.AHRS_STABLE) != 0)
					btLru1AhrsStable.BackColor = Color.ForestGreen;
				else
					btLru1AhrsStable.BackColor = Color.DarkGray;
				if ((status & STATUS.PITOT_TEMP_STABLE) != 0)
					btLru1PHeat.BackColor = Color.ForestGreen;
				else
					btLru1PHeat.BackColor = Color.DarkGray;
				if ((status & STATUS.STATIC_TEMP_STABLE) != 0)
					btLru1SHeat.BackColor = Color.ForestGreen;
				else
					btLru1SHeat.BackColor = Color.DarkGray;
			}
			else
			{
				btLru1AhrsStable.BackColor = Color.DarkGray;
				btLru1PHeat.BackColor = Color.DarkGray;
				btLru1SHeat.BackColor = Color.DarkGray;

			}

			if (cbLru2Use.Checked && lru2.getUnitConnected())
			{
				int status = (int)lru2.dataParam[(int)PARAM.STATUS];
				if ((status & STATUS.AHRS_STABLE) != 0)
					btLru2AhrsStable.BackColor = Color.ForestGreen;
				else
					btLru2AhrsStable.BackColor = Color.DarkGray;
				if ((status & STATUS.PITOT_TEMP_STABLE) != 0)
					btLru2PHeat.BackColor = Color.ForestGreen;
				else
					btLru2PHeat.BackColor = Color.DarkGray;
				if ((status & STATUS.STATIC_TEMP_STABLE) != 0)
					btLru2SHeat.BackColor = Color.ForestGreen;
				else
					btLru2SHeat.BackColor = Color.DarkGray;
			}
			else
			{
				btLru2AhrsStable.BackColor = Color.DarkGray;
				btLru2PHeat.BackColor = Color.DarkGray;
				btLru2SHeat.BackColor = Color.DarkGray;

			}

			if (cbLru3Use.Checked && lru3.getUnitConnected())
			{
				int status = (int)lru3.dataParam[(int)PARAM.STATUS];
				if ((status & STATUS.AHRS_STABLE) != 0)
					btLru3AhrsStable.BackColor = Color.ForestGreen;
				else
					btLru3AhrsStable.BackColor = Color.DarkGray;
				if ((status & STATUS.PITOT_TEMP_STABLE) != 0)
					btLru3PHeat.BackColor = Color.ForestGreen;
				else
					btLru3PHeat.BackColor = Color.DarkGray;
				if ((status & STATUS.STATIC_TEMP_STABLE) != 0)
					btLru3SHeat.BackColor = Color.ForestGreen;
				else
					btLru3SHeat.BackColor = Color.DarkGray;
			}
			else
			{
				btLru3AhrsStable.BackColor = Color.DarkGray;
				btLru3PHeat.BackColor = Color.DarkGray;
				btLru3SHeat.BackColor = Color.DarkGray;

			}

			// Air Data port status indications
			if (AdtsCom.getPortStatus())
			{
				btAdPortStatus.Text = "CONNECTED";
				btAdPortStatus.BackColor = Color.Green;
				bStatusIasActual.Text = AdtsCom.actualIas.ToString("F1");
				bStatusBcaActual.Text = AdtsCom.actualBca.ToString();
				//bADCTestPointNum.Text = BcaCalPoints.currentCalPoint.ToString() + " OF " + BcaCalPoints.bcaCalPoint.Length.ToString();
				lbStableCount.Text = AdtsCom.stableCount.ToString();
				lbSampleCount.Text = CalAdc.sampleCount.ToString();
				lbWriteCount.Text = CalAdc.writeCount.ToString();

				// Cal button text
				if (CalAdc.getCalRunningState())
					bStartAdcCal.Text = "ADC Cal Stop";
				else
					bStartAdcCal.Text = "ADC Cal Start";

				// Program button text
				if (CalAdc.getPrgRunningState())
					bStartAdcPrg.Text = "ADC Prg Stop";
				else
					bStartAdcPrg.Text = "ADC Prg Start";



				if (!AdtsCom.vented)
				{
					bStatusBcaTarget.Text = AdtsCom.targetBca.ToString();
					bStatusIasTarget.Text = AdtsCom.targetIas.ToString();
				}
				else
				{
					bStatusBcaTarget.Text = "VENT";
					bStatusIasTarget.Text = "VENT";

				}


				// IAS Color Match
				if (AdtsCom.actualIas == AdtsCom.targetIas)
				{
					bStatusIasTarget.BackColor = Color.Green;
					//					bStatusIasActual.BackColor = Color.Green;
				}
				else
				{
					bStatusIasTarget.BackColor = Color.Blue;
					//					bStatusIasActual.BackColor = Color.Blue;
				}
				// BCA Color match
				if (AdtsCom.actualBca == AdtsCom.targetBca)
				{
					bStatusBcaTarget.BackColor = Color.Green;
					//				bStatusBcaActual.BackColor = Color.Green;
				}
				else
				{
					bStatusBcaTarget.BackColor = Color.Blue;
					//			bStatusBcaActual.BackColor = Color.Blue;
				}

			}
			else
			{
				btAdPortStatus.Text = "NOT CONNECTED";
				btAdPortStatus.BackColor = Color.Red;
				bStatusBcaTarget.BackColor = Color.Gray;
				//bStatusBcaActual.BackColor = Color.Gray;
				bStatusIasTarget.BackColor = Color.Gray;
				//bStatusIasActual.BackColor = Color.Gray;

				// Scan for any new ports if cb is not dropped down
				if (!cbAdPortSel.DroppedDown)
				{
					string[] ports = SerialPort.GetPortNames();
					cbAdPortSel.Items.Clear();
					cbAdPortSel.Items.Add("Disconnect");
					cbAdPortSel.Items.AddRange(ports);
				}
			}

			//
			// Lru 0 Port Status
			//
			if (cbLru0Use.Checked)
			{
				if (lru0.getPortConnected())
				{
					btLru0PortStatus.BackColor = Color.Green;
					// Get basic status from units
					if (CalAdc.getIdle())
						this.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				else
				{
					if (cbLru0Use.Checked)
						btLru0PortStatus.BackColor = Color.Red;
					else
						btLru0PortStatus.BackColor = Color.Gray;

					// Scan for any new ports if cb is not dropped down
					if (!cbLru0PortSel.DroppedDown)
					{
						string[] ports = SerialPort.GetPortNames();
						cbLru0PortSel.Items.Clear();
						cbLru0PortSel.Items.Add("Disconnect");
						cbLru0PortSel.Items.AddRange(ports);
					}
				}

				if (lru0.getUnitConnected())
				{
					btLru0LruStatus.BackColor = Color.Green;
				}
				else
				{
					if (cbLru0Use.Checked)
						btLru0LruStatus.BackColor = Color.Red;
					else
						btLru0LruStatus.BackColor = Color.Gray;
				}
			}
			else
			{
				btLru0PortStatus.BackColor = Color.Gray;
				btLru0LruStatus.BackColor = Color.Gray;
			}

			//
			// Lru 1 Port Status
			//
			if (cbLru1Use.Checked)
			{
				if (lru1.getPortConnected())
				{
					btLru1PortStatus.BackColor = Color.Green;
					// Get basic status from units
					if (CalAdc.getIdle())
						this.lru1.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				else
				{
					if (cbLru1Use.Checked)
						btLru1PortStatus.BackColor = Color.Red;
					else
						btLru1PortStatus.BackColor = Color.Gray;

					// Scan for any new ports if cb is not dropped down
					if (!cbLru1PortSel.DroppedDown)
					{
						string[] ports = SerialPort.GetPortNames();
						cbLru1PortSel.Items.Clear();
						cbLru1PortSel.Items.Add("Disconnect");
						cbLru1PortSel.Items.AddRange(ports);
					}
				}

				if (lru1.getUnitConnected())
				{
					btLru1LruStatus.BackColor = Color.Green;
				}
				else
				{
					if (cbLru1Use.Checked)
						btLru1LruStatus.BackColor = Color.Red;
					else
						btLru1LruStatus.BackColor = Color.Gray;
				}
			}
			else
			{
				btLru1PortStatus.BackColor = Color.Gray;
				btLru1LruStatus.BackColor = Color.Gray;
			}



			//
			// Lru 2 Port Status
			//
			if (cbLru2Use.Checked)
			{
				if (lru2.getPortConnected())
				{
					btLru2PortStatus.BackColor = Color.Green;
					// Get basic status from units
					if (CalAdc.getIdle())
						this.lru2.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				else
				{
					if (cbLru2Use.Checked)
						btLru2PortStatus.BackColor = Color.Red;
					else
						btLru2PortStatus.BackColor = Color.Gray;

					// Scan for any new ports if cb is not dropped down
					if (!cbLru2PortSel.DroppedDown)
					{
						string[] ports = SerialPort.GetPortNames();
						cbLru2PortSel.Items.Clear();
						cbLru2PortSel.Items.Add("Disconnect");
						cbLru2PortSel.Items.AddRange(ports);
					}
				}

				if (lru2.getUnitConnected())
				{
					btLru2LruStatus.BackColor = Color.Green;
				}
				else
				{
					if (cbLru2Use.Checked)
						btLru2LruStatus.BackColor = Color.Red;
					else
						btLru2LruStatus.BackColor = Color.Gray;
				}
			}
			else
			{
				btLru2PortStatus.BackColor = Color.Gray;
				btLru2LruStatus.BackColor = Color.Gray;
			}


			//
			// Lru 3 Port Status
			//
			if (cbLru3Use.Checked)
			{
				if (lru3.getPortConnected())
				{
					btLru3PortStatus.BackColor = Color.Green;
					// Get basic status from units
					if (CalAdc.getIdle())
						this.lru3.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				else
				{
					if (cbLru3Use.Checked)
						btLru3PortStatus.BackColor = Color.Red;
					else
						btLru3PortStatus.BackColor = Color.Gray;

					// Scan for any new ports if cb is not dropped down
					if (!cbLru3PortSel.DroppedDown)
					{
						string[] ports = SerialPort.GetPortNames();
						cbLru3PortSel.Items.Clear();
						cbLru3PortSel.Items.Add("Disconnect");
						cbLru3PortSel.Items.AddRange(ports);
					}
				}

				if (lru3.getUnitConnected())
				{
					btLru3LruStatus.BackColor = Color.Green;
				}
				else
				{
					if (cbLru3Use.Checked)
						btLru3LruStatus.BackColor = Color.Red;
					else
						btLru3LruStatus.BackColor = Color.Gray;
				}
			}
			else
			{
				btLru3PortStatus.BackColor = Color.Gray;
				btLru3LruStatus.BackColor = Color.Gray;
			}


            //
            // ADC Cal tab realtime sensor values
            //
            if (cbLru0Use.Checked)
            {
                btLru0AValue.Text = lru0.dataParam[(int)PARAM.SENP].ToString("F2");
                btLru0BValue.Text = lru0.dataParam[(int)PARAM.SENS].ToString("F2");
            }
            else
            {
                btLru0AValue.Text =  "N/A";
                btLru0BValue.Text =  "N/A";
            }

            if (cbLru1Use.Checked)
            {
                btLru1AValue.Text = lru1.dataParam[(int)PARAM.SENP].ToString("F2");
                btLru1BValue.Text = lru1.dataParam[(int)PARAM.SENS].ToString("F2");
            }
            else
            {
                btLru1AValue.Text = "N/A";
                btLru1BValue.Text = "N/A";
            }
			if (cbLru2Use.Checked)
			{
				btLru2AValue.Text = lru2.dataParam[(int)PARAM.SENP].ToString("F2");
				btLru2BValue.Text = lru2.dataParam[(int)PARAM.SENS].ToString("F2");
			}
			else
			{
				btLru2AValue.Text = "N/A";
				btLru2BValue.Text = "N/A";
			}
			if (cbLru3Use.Checked)
			{
				btLru3AValue.Text = lru3.dataParam[(int)PARAM.SENP].ToString("F2");
				btLru3BValue.Text = lru3.dataParam[(int)PARAM.SENS].ToString("F2");
			}
			else
			{
				btLru3AValue.Text = "N/A";
				btLru3BValue.Text = "N/A";
			}
			//// ADC Cal tab running status
			//if (CalAdc.getCalRunningState())
			//{
			//	lbAdcCalRunning.Text = "CAL RUNNING";
			//	//lbAdcCalRunning.ForeColor = Color.Green;
			//	//bStartAdcCal.BackColor = Color.Red;
			//}
			//else
			//{
			//	lbAdcCalRunning.Text = "CAL STOPPED";
			//	//lbAdcCalRunning.ForeColor = Color.Red;
			//	//bStartAdcCal.BackColor = Color.Transparent;

			//}


			//// Feedback
			//if (idWasRequested == true)
			//{
			//	if (lru0.returnReady)
			//	{
			//		tbReadId.Text = lru0.senBoardFbValI.ToString("0000");
			//		idWasRequested = false;
			//	}
			//}

		}







		// FORM EVENTS


		// Positioning Fixture Combo Box - Value Changed
		// LRU 0
		private void cbLru0PortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbLru0PortSel.SelectedIndex > 0)
			{
				lru0.selectedComPort = this.cbLru0PortSel.SelectedItem.ToString();
				lru0.setDisconnect();    // Force re-connection
			}
			else
			{
				cbLru0SelectedPort = "NONE";
			}
		}
		// LRU 1
		private void cbLru1PortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbLru1PortSel.SelectedIndex > 0)
			{
				cbLru1SelectedPort = this.cbLru1PortSel.SelectedItem.ToString();
				lru1.setDisconnect();    // Force re-connection
			}
			else
			{
				cbLru1SelectedPort = "NONE";
			}
		}
		// LRU 2
		private void cbLru2PortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbLru2PortSel.SelectedIndex > 0)
			{
				cbLru2SelectedPort = this.cbLru2PortSel.SelectedItem.ToString();
				lru2.setDisconnect();    // Force re-connection
			}
			else
			{
				cbLru2SelectedPort = "NONE";
			}
		}
		// LRU 3
		private void cbLru3PortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbLru3PortSel.SelectedIndex > 0)
			{
				cbLru3SelectedPort = this.cbLru3PortSel.SelectedItem.ToString();
				lru3.setDisconnect();    // Force re-connection
			}
			else
			{
				cbLru3SelectedPort = "NONE";
			}
		}


		// Positioning Fixture Combo Box - Value Changed
		private void cbPfPortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbPfPortSel.SelectedIndex > 0)
				PfSelectedPort = this.cbPfPortSel.SelectedItem.ToString();
			else
			{
				// Set to none and shutdown controller if it was connected
				PfSelectedPort = "NONE";
				PosFixture.setDisconnect();
			}
		}
		// Air Data Combo Box - Value Changed
		private void cbAdPortSel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbAdPortSel.SelectedIndex > 0)
				AdSelectedPort = this.cbAdPortSel.SelectedItem.ToString();
			else
			{
				// Set to none and shutdown controller if it was connected
				AdSelectedPort = "NONE";
				AdtsCom.setDisconnect();
			}
		}


		private void btStartAgCal_Click(object sender, EventArgs e)
		{

		}

		private void btStartAdcCal_Click(object sender, EventArgs e)
		{
			CalAdc.setCalRunningSate(true);
		}

		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void button10_Click(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		//private void button12_Click(object sender, EventArgs e)
		//{
		//	CalAdc.setRunningSate(true);
		//}

		private void bStartAdcCal_Click(object sender, EventArgs e)
		{
			if (CalAdc.getCalRunningState())
			{
				// Running - stop it   
				CalAdc.setCalRunningSate(false);
			}
			else
			{
				// Stopped - start it
				MessageBox.Show("Ensure Vents Are Closed On Air Data Tester");
				CalAdc.setCalRunningSate(true);
			}


		}

		private void bStartAgCal_Click(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void button15_Click(object sender, EventArgs e)
		{
			// Go to zero zero zero
			PosFixture.setPosition("X0 Y0 Z0");

		}

		private void button12_Click(object sender, EventArgs e)
		{
			PosFixture.setStop();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			// Roll + 30
			PosFixture.setPosition("X0 Y30 Z0");
		}

		private void button13_Click(object sender, EventArgs e)
		{
			// Pitch - 30
			PosFixture.setPosition("X0 Y0 Z30");
		}

		private void button17_Click(object sender, EventArgs e)
		{
			// Pitch + 30
			PosFixture.setPosition("X0 Y0 Z-30");
		}

		private void button16_Click(object sender, EventArgs e)
		{
			// Roll - 30
			PosFixture.setPosition("X0 Y-30 Z0");
		}

		private void bStartAdcPrg_Click(object sender, EventArgs e)
		{
			if (CalAdc.getPrgRunningState())
			{
				// Running - stop it   
				CalAdc.setPrgRunningState(false);
			}
			else
			{
				// Stopped - start it
				CalAdc.setPrgRunningState(true);
			}


		}

		private void dgAdcLru0Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}


		private void btLruRead_Click(object sender, EventArgs e)
		{
			CalAdc.setReadRunningState(true);
		}

		private void bStartAdcAtp_Click(object sender, EventArgs e)
		{
			AtpAdc.setAtpBcaRunningSate(true);
		}

		private void bStartCycleSens_Click(object sender, EventArgs e)
		{
			if (CycleAdc.cycleRunning)
			{
				CycleAdc.setCycleRunningSate(false);
			}
			else
			{
				MessageBox.Show("Ensure Vents Are Closed On Air Data Tester");
				CycleAdc.setCycleRunningSate(true);
			}
		}

		private void btStartAdcRead_Click(object sender, EventArgs e)
		{
			if (CalAdc.readPointsRunning)
			{
				CalAdc.setReadRunningState(false);
			}
			else
			{
				CalAdc.setReadRunningState(true);
			}
		}

		private void btLru0PrgSn_Click(object sender, EventArgs e)
		{
			SerialNum.setSerialNum(0, Convert.ToInt32(tbLru0SetSn.Text));
		}

		private void btLru0SetCalDef_Click(object sender, EventArgs e)
		{
			CalAdc.setDefaultValues(0);
		}

		private void btLru0Prog_Click(object sender, EventArgs e)
		{
			CalAdc.setPrgRunningState(true);
		}

		private void btLru0ReadSn_Click(object sender, EventArgs e)
		{
			SerialNum.setSerialNumRead(0);
		}


		//private void btControllerInit_Click(object sender, EventArgs e)
		//{
		//	PosFixture.setControllerInit();
		//}

		private void btMoveTest_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0");
		}

		private void btMoveTest2_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X15 Y15");
		}

		//private void btHomeFixture_Click(object sender, EventArgs e)
		//{
		//	PosFixture.setHomeStart();
		//}

		private void btStartAccelCal_Click(object sender, EventArgs e)
		{
			if (CalAccel.getCalRunningState())
			{
				// Running - stop it   
				CalAccel.setCalRunningSate(false);
			}
			else
			{
				// Stopped - start it
				CalAccel.setCalRunningSate(true);
			}
		}

		private void btStartAccelProg_Click(object sender, EventArgs e)
		{
			//if (CalAccel.getPrgRunningState())
			//{
			//	// Running - stop it   
			//	CalAccel.setPrgRunningState(false);
			//}
			//else
			//{
			//	// Stopped - start it
			//	CalAccel.setPrgRunningState(true);
			//}
		}

		private void btAccelCalRead_Click(object sender, EventArgs e)
		{
			this.cbChainAccelToGyro.Checked = false;
			CalAccel.setReadRunningState(true);
		}

		private void btStartGyroCal_Click(object sender, EventArgs e)
		{
			if (CalGyro.getCalRunningState())
			{
				// Running - stop it   
				CalGyro.setBiasRunningSate(false);
			}
			else
			{
				// Stopped - start it
				CalGyro.setBiasRunningSate(true);
			}
		}

		private void btGyroCalRead_Click(object sender, EventArgs e)
		{
			this.cbChainGyroToAtp.Checked = false;
			if (CalGyro.getCalRunningState())
			{
				CalGyro.setReadRunningState(false);
			}
			else
			{
				CalGyro.setReadRunningState(true);
			}
		}

		private void btHomeFixture_Click_1(object sender, EventArgs e)
		{
			PosFixture.setHomeStart();
		}

		private void btControllerInit_Click_1(object sender, EventArgs e)
		{
			PosFixture.setControllerInit();
			System.Windows.Forms.MessageBox.Show("Wait Until Controller Re-Starts!");
		}

		private void btStartAhrsAtp_Click(object sender, EventArgs e)
		{
			if (AtpGyro.atpPointsRunning)
			{
				AtpGyro.setAhrsAtpRunningSate(false);
			}
			else
			{
				AtpGyro.setAhrsAtpRunningSate(true);
			}
		}

		//private void btStartMagCal_Click(object sender, EventArgs e)
		//{
		//	if (CalMag.getMagCalRunningState())
		//	{
		//		CalMag.setMagCalRunningState(false);
		//	}
		//	else
		//	{
		//		CalMag.setMagCalRunningState(true);
		//	}
		//}

		private void button1_Click(object sender, EventArgs e)
		{
			//CalMag.setMagCalReset();
		}

		private void btLru0GyroParmValue_Click(object sender, EventArgs e)
		{

		}

		private void btBrdConnect_Click(object sender, EventArgs e)
		{
			BrdTest.connect();
		}

		private void btBrdDisconnect_Click(object sender, EventArgs e)
		{
			BrdTest.disconnect();
		}

		private void label41_Click(object sender, EventArgs e)
		{

		}

		private void btBrdSetDefaults_Click(object sender, EventArgs e)
		{

			lru0.setPrefWriteI(PREF.PREF_VERSION, (int)(0x0001));
			lru0.setPrefWriteI(PREF.PREF_SN, (int)(0x0000));
			lru0.setPrefWriteI(PREF.PREF_PAGE_ENA, (int)(0xffff));
			lru0.setPrefWriteI(PREF.PREF_VOICE_ENA, (int)(0xff));
			lru0.setPrefWriteI(PREF.PREF_VOLUME, (int)(5));
			lru0.setPrefWriteI(PREF.PREF_AOA_HIGH, (int)(20));
			lru0.setPrefWriteI(PREF.PREF_AOA_LOW, (int)(0));
			lru0.setPrefWriteI(PREF.PREF_MISC, (int)(0xff));        // BLUE
			lru0.setPrefWriteI(PREF.PREF_AI_OFFSET, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_LAST_PAGE, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_CHRONO_VIEW, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_AOA_VIEW, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_TRAF_RANGE, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_OAT_CAL, (int)(0x00));
			lru0.setPrefWriteI(PREF.PREF_GLIMIT_HIGH, (int)(2));
			lru0.setPrefWriteI(PREF.PREF_GLIMIT_LOW, (int)(-2));


		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void btStartAccelRead_Click(object sender, EventArgs e)
		{
			if (CalAccel.readPointsRunning)
			{
				// Running - stop it   
				CalAccel.setReadRunningState(false);
			}
			else
			{
				// Stopped - start it
				CalAccel.setReadRunningState(true);
			}
		}


		private void btBrdClearFlash_Click(object sender, EventArgs e)
		{
			BrdTest.setBoardDefaults();
		}

		private void btStartGyroProg_Click(object sender, EventArgs e)
		{

		}

		private void btStartGyroRead_Click(object sender, EventArgs e)
		{

		}


		private void btNoiseRefresh_Click(object sender, EventArgs e)
		{

			//BrdTest.noiseRefresh();

		}

		private void NoiseToggleTimer_Tick(object sender, EventArgs e)
		{
			//// Toggle gyro being viewed
			//if (selectedGyro == 1)
			//{
			//	lru0.setEngWriteF(ENG.SG0, 0);
			//	System.Threading.Thread.Sleep(500);
			//	selectedGyro = 0;
			//}
			//else
			//{
			//	lru0.setEngWriteF(ENG.SG1, 0);
			//	System.Threading.Thread.Sleep(500);
			//	selectedGyro = 1;
			//}


		}

		private void label48_Click(object sender, EventArgs e)
		{

		}

		private void label50_Click(object sender, EventArgs e)
		{

		}

		private void btGyroZ0_Click(object sender, EventArgs e)
		{

		}

		private void btProgramId_Click(object sender, EventArgs e)
		{


			//int userVal;
			//if (int.TryParse(tbWriteId.Text, out userVal))
			//{
			//	if ((userVal >= 0) && (userVal < 65535))
			//		lru0.setPrefWriteI(PREF.PREF_SN, int.Parse(tbWriteId.Text));
			//	else
			//		MessageBox.Show("Value out of Range");

			//}
			//else
			//{
			//	MessageBox.Show("ID Must be an number");
			//}

		}

		private void btReadId_Click(object sender, EventArgs e)
		{
			lru0.setPrefReadI(PREF.PREF_SN);
			idWasRequested = true;

		}

		private void btAudioTest_Click(object sender, EventArgs e)
		{
			lru0.setEngWriteF(ENG.TA, 0);   // Test Audo
		}

		private void btAdcVent_Click(object sender, EventArgs e)
		{
			AdtsCom.setGround();
			AdtsCom.setMeasure();
		}



		//private void btOoatCalNeg_Click(object sender, EventArgs e)
		//{
		//	btOatCalVal.Text = (int.Parse(btOatCalVal.Text) - 2).ToString();
		//	lru0.setPrefWriteI(PREF.PREF_OAT_H_CAL, int.Parse(btOatCalVal.Text));
		//}

		//private void btOatCalPos_Click(object sender, EventArgs e)
		//{
		//	btOatCalVal.Text = (int.Parse(btOatCalVal.Text) + 2).ToString();
		//	lru0.setPrefWriteI(PREF.PREF_OAT_H_CAL, int.Parse(btOatCalVal.Text));
		//}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btMopsBcaStart_Click(object sender, EventArgs e)
		{
			Mops.setMopsAtpBcaRunningSate(true);
		}

		private void btMopsBcaStop_Click(object sender, EventArgs e)
		{
			Mops.setMopsAtpBcaRunningSate(false);
		}

		private void btMopsIasStart_Click(object sender, EventArgs e)
		{
			Mops.setMopsAtpIasRunningSate(true);
		}

		private void btMopsIasStop_Click(object sender, EventArgs e)
		{
			Mops.setMopsAtpIasRunningSate(false);
		}

		private void tabChanged(object sender, EventArgs e)
		{
			
			// Board Test
			if (tfMain.SelectedTab == tfMain.TabPages[1])
			{
				BrdTest.connect();
			}

			// MOPS
			if (tfMain.SelectedTab == tfMain.TabPages[7])
			{
				Mops.connect();
			}

			// ADC Cal
			if (tfMain.SelectedTab == tfMain.TabPages[2])
			{
				CalAdc.connect();
			}


		}

		private void BtMopsReconnect_Click(object sender, EventArgs e)
		{
			Mops.connect();
		}

		private void BtMopsMove0r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void BtMopsMove0r15p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z15");
		}

		private void BtMopsMove15r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y15 Z0");
		}

		private void BtMopsMove0rn15p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z-15");
		}

		private void BtMopsMoven15r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y-15 Z0");
		}

		private void BtMopsMove30r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y30 Z0");
		}

		private void BtMopsMove60r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y60 Z0");
		}

		private void BtMopsMoven30r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y-30 Z0");
		}

		private void BtMopsMoven60r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y-60 Z0");
		}

		private void BtMopsMove0r30p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z30");
		}

		private void BtMopsMove0r60p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z60");
		}

		private void BtMopsMove0rn30p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z-30");
		}

		private void BtMopsMove0rn60p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z-60");
		}

		private void BtMopsMove0r0p2_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void BtMopsMoven8r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y-8 Z0");
		}

		private void BtMopsMoven7r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y-7 Z0");
		}

		private void BtMopsMove0r0p3_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void BtMopsMove7r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y7 Z0");
		}

		private void BtMopsMove8r0p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y8 Z0");
		}

		private void BtMopsMove0r0p30y_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X30 Y0 Z0");
		}

		private void BtMopsMove0r0pn30y_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X-30 Y0 Z0");
		}

		private void BtMopsSetRPOffset_Click(object sender, EventArgs e)
		{
			// Capture current values
			rollOffset = this.lru0.dataParam[(int)PARAM.ROLL];
			pitchOffset = this.lru0.dataParam[(int)PARAM.PITCH];

		}

		private void BtMopsClearRPOffset_Click(object sender, EventArgs e)
		{
			rollOffset = 0;
			pitchOffset = 0;
		}

		private void BtMopsMove0rn5p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z-5");
		}

		private void BtMopsMove0r0p4_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void BtMopsMove0r10P_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z10");
		}

		private void BtMopsMove0r15P2_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z15");
		}

		private void BtMopsMove0r20p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z20");
		}

		private void BtMopsMove0r25p_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z25");
		}

		private void BtMopsAdts0f_Click(object sender, EventArgs e)
		{
			AdtsCom.setIas(0);
			AdtsCom.setBca(0);
		}

		private void BtMopsAdts5000f_Click(object sender, EventArgs e)
		{
			AdtsCom.setIas(0);
			AdtsCom.setBca(5000);
		}

		private void BtMopsAdts20000f_Click(object sender, EventArgs e)
		{
			AdtsCom.setIas(0);
			AdtsCom.setBca(20000);
		}

		private void BtMopsAdts25000f_Click(object sender, EventArgs e)
		{
			AdtsCom.setIas(0);
			AdtsCom.setBca(25000);
		}

		private void BtMopsStopAndVent_Click(object sender, EventArgs e)
		{
			AdtsCom.setGround();
			AdtsCom.setMeasure();
		}

		private void BtMopsPrint_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.Doc_PrintMopsPage;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		
		private void Doc_PrintMopsPage(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			//Bitmap bmp = new Bitmap(this.tabPage3.Width, this.tabPage3.Height);
			//this.tabPage3.DrawToBitmap(bmp, new Rectangle(0, 0, this.tabPage3.Width, this.tabPage3.Height));
			//gbMopsBca
			Bitmap bmp = new Bitmap(this.gbMopsBca.Width, this.gbMopsBca.Height);
			this.gbMopsBca.DrawToBitmap(bmp, new Rectangle(0, 0, this.gbMopsBca.Width, this.gbMopsBca.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}
		

		//
		// LRU 0 ATP Reports
		//
		private void btPrintLru0AdcReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru0AdcReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru0AdcReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.gbAtpLru0.Width, this.gbAtpLru0.Height);
			this.gbAtpLru0.DrawToBitmap(bmp, new Rectangle(0, 0, this.gbAtpLru0.Width, this.gbAtpLru0.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}
			
		private void BtPrintLru0AhrsReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru0AhrsReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru0AhrsReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.dgAhrsAtpLru0Data.Width, this.dgAhrsAtpLru0Data.Height);
			this.dgAhrsAtpLru0Data.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgAhrsAtpLru0Data.Width, this.dgAhrsAtpLru0Data.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}


		//
		// LRU 1 ATP Reports
		//
		private void btPrintLru1AdcReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru1AdcReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru1AdcReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.gbAtpLru1.Width, this.gbAtpLru1.Height);
			this.gbAtpLru1.DrawToBitmap(bmp, new Rectangle(0, 0, this.gbAtpLru1.Width, this.gbAtpLru1.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}

		private void BtPrintLru1AhrsReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru1AhrsReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru1AhrsReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.dgAhrsAtpLru1Data.Width, this.dgAhrsAtpLru1Data.Height);
			this.dgAhrsAtpLru1Data.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgAhrsAtpLru1Data.Width, this.dgAhrsAtpLru1Data.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}


		//
		// LRU 2 ATP Reports
		//
		private void btPrintLru2AdcReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru2AdcReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru2AdcReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.gbAtpLru2.Width, this.gbAtpLru2.Height);
			this.gbAtpLru2.DrawToBitmap(bmp, new Rectangle(0, 0, this.gbAtpLru2.Width, this.gbAtpLru2.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}

		private void BtPrintLru2AhrsReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru2AhrsReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru2AhrsReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.dgAhrsAtpLru2Data.Width, this.dgAhrsAtpLru2Data.Height);
			this.dgAhrsAtpLru2Data.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgAhrsAtpLru2Data.Width, this.dgAhrsAtpLru2Data.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}


		//
		// LRU 3 ATP Reports
		//
		private void btPrintLru3AdcReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru3AdcReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru3AdcReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.gbAtpLru3.Width, this.gbAtpLru3.Height);
			this.gbAtpLru3.DrawToBitmap(bmp, new Rectangle(0, 0, this.gbAtpLru3.Width, this.gbAtpLru3.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}

		private void BtPrintLru3AhrsReport_Click(object sender, EventArgs e)
		{
			PrintDocument doc = new PrintDocument();
			doc.PrintPage += this.PrintLru3AhrsReport;
			PrintDialog dlgSettings = new PrintDialog();
			dlgSettings.Document = doc;
			if (dlgSettings.ShowDialog() == DialogResult.OK)
			{
				doc.Print();
			}
		}
		private void PrintLru3AhrsReport(object sender, PrintPageEventArgs e)
		{
			float x = e.MarginBounds.Left;
			float y = e.MarginBounds.Top;
			Bitmap bmp = new Bitmap(this.dgAhrsAtpLru3Data.Width, this.dgAhrsAtpLru3Data.Height);
			this.dgAhrsAtpLru3Data.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgAhrsAtpLru3Data.Width, this.dgAhrsAtpLru3Data.Height));
			e.Graphics.DrawImage((Image)bmp, x, y);
		}

		private void BtBrdTestClear_Click(object sender, EventArgs e)
		{
			BrdTest.clearNoise();
		}

		private void BtBrdClearCal_Click(object sender, EventArgs e)
		{
			CalAccel.clearAccelCalData();
		}
	}
}
