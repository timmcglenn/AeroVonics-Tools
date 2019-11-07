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
using System.Reflection;

using CalTool;

namespace AhrsMonitor
{
	public partial class MainForm : Form
	{

		private const int randomMove = 20;
		public CalTool.LruCom lru0;
		private bool firstConnect = true;
		private int dataSource = 0;
		public bool freeGyroMode = false;
		public bool dgMotionEnabled = false;
		private bool dgRightSide = true;
		private bool dgSlowInit = false;
		private int dgCycleCount = 0;
		private bool randomEnabled = false;
		public double timeInFreeMode = 0;

		public enum SOURCE { NONE, RPY, GYRO_RAW0, GYRO_RAW1, ACCEL_RAW0, ACCEL_RAW1, WEIGHT, GYRO_CAL, ACCEL_CAL, GYRO_SUM, STATS1, ADC, HEATERS, AIRRAW, RATES }

		class DoubleBufferedPanel : Panel
		{
			public DoubleBufferedPanel() : base() { DoubleBuffered = true; }
		}

		public MainForm()
		{
			InitializeComponent();

			// Give classes access to mainform
			Chart.setParentForm(this);
			PosFixture.setPort("COM40");

			// Create LRU Instances
			lru0 = new CalTool.LruCom(0);
			// Need to add dropdown box for this
			lru0.selectedComPort = "COM50";

			// Default scale
			Chart.MAX_RATE = 100;
			Chart.MIN_RATE = -100;



		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			lru0.update();

			// Setup outputs
			if ((lru0.unitConnected) && firstConnect)
			{
				lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				firstConnect = false;
			}

			//btGyroZRaw.Text = lru0.dataParam[(int)PARAM.BTEMP].ToString();
			//btVolts.Text = lru0.dataParam[(int)PARAM.VOLTS].ToString();


			switch (dataSource)
			{
				case (int)SOURCE.GYRO_RAW0:
					// Gyro display
					lbSource.Text = "Gyro 0 Raw";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.GYROXR0], lru0.dataParam[(int)PARAM.GYROYR0], lru0.dataParam[(int)PARAM.GYROZR0]);
					btParmX.Text = lru0.dataParam[(int)PARAM.GYROXR0].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.GYROYR0].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.GYROZR0].ToString("0.00000");
					btParmA.Text = lru0.dataParam[(int)PARAM.FIFOCOUNT].ToString("000");
					break;

				case (int)SOURCE.GYRO_RAW1:
					// Gyro display
					lbSource.Text = "Gyro 1 Raw";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.GYROXR1], lru0.dataParam[(int)PARAM.GYROYR1], lru0.dataParam[(int)PARAM.GYROZR1]);
					btParmX.Text = lru0.dataParam[(int)PARAM.GYROXR1].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.GYROYR1].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.GYROZR1].ToString("0.00000");
					btParmA.Text = lru0.dataParam[(int)PARAM.FIFOCOUNT].ToString("000");
					break;

				case (int)SOURCE.GYRO_CAL:
					// Gyro display
					lbSource.Text = "Cal Gyro";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.GYROXC], lru0.dataParam[(int)PARAM.GYROYC], lru0.dataParam[(int)PARAM.GYROZC]);
					btParmX.Text = lru0.dataParam[(int)PARAM.GYROXC].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.GYROYC].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.GYROZC].ToString("0.00000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.GYRO_SUM:
					// Gyro sum display
					//Chart.addNewPoint(lru0.dataParam[(int)PARAM.GYROXSUM], lru0.dataParam[(int)PARAM.GYROYSUM], lru0.dataParam[(int)PARAM.GYROZSUM]);
					//btParmX.Text = lru0.dataParam[(int)PARAM.GYROXSUM].ToString("000.00");
					//btParmY.Text = lru0.dataParam[(int)PARAM.GYROYSUM].ToString("000.00");
					//btParmZ.Text = lru0.dataParam[(int)PARAM.GYROZSUM].ToString("000.00");
					lbSource.Text = "Gyro Bias";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.OI0], lru0.dataParam[(int)PARAM.OI1], lru0.dataParam[(int)PARAM.OI2]);
					btParmX.Text = lru0.dataParam[(int)PARAM.OI0].ToString("0.0000");
					btParmY.Text = lru0.dataParam[(int)PARAM.OI1].ToString("0.0000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.OI2].ToString("0.0000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.ACCEL_RAW0:
					// Accel display
					lbSource.Text = "Accel 0 Raw";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.ACCELXR0], lru0.dataParam[(int)PARAM.ACCELYR0], lru0.dataParam[(int)PARAM.ACCELZR0]);
					btParmX.Text = lru0.dataParam[(int)PARAM.ACCELXR0].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.ACCELYR0].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.ACCELZR0].ToString("0.00000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.ACCEL_RAW1:
					// Accel display
					lbSource.Text = "Accel 1 Raw";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.ACCELXR1], lru0.dataParam[(int)PARAM.ACCELYR1], lru0.dataParam[(int)PARAM.ACCELZR1]);
					btParmX.Text = lru0.dataParam[(int)PARAM.ACCELXR1].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.ACCELYR1].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.ACCELZR1].ToString("0.00000");
					btParmA.Text = ("-");
					break;


				case (int)SOURCE.ACCEL_CAL:
					// Accel display
					lbSource.Text = "Accel Cal";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.ACCELXC], lru0.dataParam[(int)PARAM.ACCELYC], lru0.dataParam[(int)PARAM.ACCELZC]);
					btParmX.Text = lru0.dataParam[(int)PARAM.ACCELXC].ToString("0.00000");
					btParmY.Text = lru0.dataParam[(int)PARAM.ACCELYC].ToString("0.00000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.ACCELZC].ToString("0.00000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.RPY:
					// Roll Pitch Yaw
					lbSource.Text = "Roll Pitch Yaw";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.ROLL], lru0.dataParam[(int)PARAM.PITCH], lru0.dataParam[(int)PARAM.YAW]);
					btParmX.Text = lru0.dataParam[(int)PARAM.ROLL].ToString("000.000");
					btParmY.Text = lru0.dataParam[(int)PARAM.PITCH].ToString("000.000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.YAW].ToString("000.000");
					btParmA.Text = lru0.dataParam[(int)PARAM.YAWT].ToString("000.000");

					break;

				case (int)SOURCE.WEIGHT:
					// Weighting
					lbSource.Text = "Weight";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.RPYWEIGHT], lru0.dataParam[(int)PARAM.BIASWEIGHT], lru0.dataParam[(int)PARAM.AHRSRPYGATE]);
					btParmX.Text = lru0.dataParam[(int)PARAM.RPYWEIGHT].ToString("00.0");
					btParmY.Text = lru0.dataParam[(int)PARAM.BIASWEIGHT].ToString("00.0");
					btParmZ.Text = lru0.dataParam[(int)PARAM.AHRSRPYGATE].ToString("0.000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.STATS1:
					// Status Group 1
					Chart.addNewPoint(0, lru0.dataParam[(int)PARAM.BATVOLTS], 0);
					lbSource.Text = "Stats Group 1";
					btParmX.Text = lru0.dataParam[(int)PARAM.UPDATERATE].ToString("00.0");
					btParmY.Text = lru0.dataParam[(int)PARAM.BATVOLTS].ToString("00.0");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.ADC:
					// Air Data
					Chart.addNewPoint(0, lru0.dataParam[(int)PARAM.IAS], lru0.dataParam[(int)PARAM.VS]);
					lbSource.Text = "Air Data";
					btParmX.Text = (lru0.dataParam[(int)PARAM.BCA] * 10).ToString("00,000.0");  // Scaled
					btParmY.Text = lru0.dataParam[(int)PARAM.IAS].ToString("000.0");
					btParmZ.Text = lru0.dataParam[(int)PARAM.AOA].ToString("000.0");

					btParmA.Text = ("-");
					break;

				case (int)SOURCE.HEATERS:
					// Heaters
					lbSource.Text = "Heater Temps";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.TEMPP], lru0.dataParam[(int)PARAM.TEMPS], 0);
					btParmX.Text = lru0.dataParam[(int)PARAM.TEMPP].ToString("00.0");
					btParmY.Text = lru0.dataParam[(int)PARAM.TEMPS].ToString("00.0");
					btParmZ.Text = lru0.dataParam[(int)PARAM.OATRAW].ToString("0000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.AIRRAW:
					// Heaters
					lbSource.Text = "Air Data Raw";
					//Chart.addNewPoint(lru0.dataParam[(int)PARAM.TEMPP], lru0.dataParam[(int)PARAM.TEMPS], 0);
					btParmX.Text = lru0.dataParam[(int)PARAM.SENP].ToString("0000.0");
					btParmY.Text = lru0.dataParam[(int)PARAM.SENS].ToString("0000.0");
					btParmZ.Text = lru0.dataParam[(int)PARAM.OATRAW].ToString("0000");
					btParmA.Text = ("-");
					break;

				case (int)SOURCE.RATES:
					// Heaters
					lbSource.Text = "AHRS Rates";
					Chart.addNewPoint(lru0.dataParam[(int)PARAM.ROLLRATE], lru0.dataParam[(int)PARAM.PITCHRATE], lru0.dataParam[(int)PARAM.YAWRATE]);
					btParmX.Text = lru0.dataParam[(int)PARAM.ROLLRATE].ToString("000.000");
					btParmY.Text = lru0.dataParam[(int)PARAM.PITCHRATE].ToString("000.000");
					btParmZ.Text = lru0.dataParam[(int)PARAM.YAWRATE].ToString("000.000");
					btParmA.Text = ("-");
					break;

			}

			// Status
			int status = (int)lru0.dataParam[(int)PARAM.STATUS];

			// Pitot Stable
			if ((status & 0x01) == 0x01)
			{
				btPitotHeatStable.BackColor = Color.ForestGreen;
			}
			else
			{
				btPitotHeatStable.BackColor = Color.DarkGray;
			}

			// Static Stable
			if ((status & 0x02) == 0x02)
			{
				btStaticHeatStable.BackColor = Color.ForestGreen;
			}
			else
			{
				btStaticHeatStable.BackColor = Color.DarkGray;
			}

			// AHRS Stable
			if ((status & 0x04) == 0x04)
			{
				btAhrsStable.BackColor = Color.ForestGreen;
			}
			else
			{
				btAhrsStable.BackColor = Color.DarkGray;
			}

			// AHRS Align Complete
			if ((status & 0x08) == 0x08)
			{
				btAhrsAlignComplete.BackColor = Color.ForestGreen;
			}
			else
			{
				btAhrsAlignComplete.BackColor = Color.DarkGray;
			}

			//// Source Display
			//if (dataSource == (int)SOURCE.GYRO_RAW)
			//	lbSource.Text = "G RAW";
			//if (dataSource == (int)SOURCE.RPY)
			//	lbSource.Text = "RPY";


			// Chart min max labels
			lbMaxChartVal.Text = Chart.MAX_RATE.ToString();
			lbMinChartVal.Text = Chart.MIN_RATE.ToString();
			lbTrgTemp.Text = Chart.TRG_RATE.ToString();
			lbTrgTemp.Top = (int)Chart.rateToYLoc(Chart.TRG_RATE) + 20;

			this.Invalidate();

			if (freeGyroMode == true)
			{
				timeInFreeMode += 0.10;
				lbTimeInFreeMode.Text = timeInFreeMode.ToString("000.0") + " Sec";
			}


			// Positioning Fixture Random Motion
			if (randomEnabled)
			{
				if (!PosFixture.getInMotion())
				{

					Random r = new Random();
					int r1 = r.Next(-tbRandomScaleY.Value, +tbRandomScaleY.Value);
					int r2 = r.Next(-tbRandomScaleR.Value, +tbRandomScaleR.Value);
					int r3 = r.Next(-tbRandomScaleP.Value, +tbRandomScaleP.Value);
					if (cbRandomXEnabled.Checked != true) r1 = 0;
					if (cbRandomYEnabled.Checked != true) r2 = 0;
					if (cbRandomZEnabled.Checked != true) r3 = 0;
					PosFixture.setPosition("X" + r1.ToString() + " Y" + r2.ToString() + " Z" + r3.ToString());
				}
			}
			else
			{
				//PosFixture.setPosition("X0 Y0 Z0");
			}

			// DG Motion Test
			if (dgMotionEnabled)
			{
				if (!PosFixture.getInMotion())
				{
					//if (!dgSlowInit)
					//{
					//	// Slow
					//	PosFixture.sendCommand("$xvm=35"); // xMax rate (mm/min)
					//	PosFixture.sendCommand("$yvm=35"); // yMax rate (mm/min)
					//	PosFixture.sendCommand("$zvm=35"); // zMax rate (mm/min)
					//	PosFixture.sendCommand("$xjm=.1");   // xMax jerk (mm/min)
					//	PosFixture.sendCommand("$yjm=.1");   // yMax jerk (mm/min)
					//	PosFixture.sendCommand("$zjm=.1");   // zMax jerk (mm/min)
					//	System.Threading.Thread.Sleep(2000);
					//	dgSlowInit = true;
					//}

					// Toggle between left and right
					if (dgCycleCount < 6)
					{
						// Cycle 1
						if (dgRightSide)
						{
							PosFixture.setPosition("X7.5 Y7.5 Z7.5");
							dgRightSide = false;
	
						}
						else
						{
							PosFixture.setPosition("X-7.5 Y-7.5 Z-7.5");
							dgRightSide = true;
							//dgCycleCount++;
						}
					}
					else
					{
						// Cycle 2
						if (dgRightSide)
						{
							PosFixture.setPosition("X7.5 Y-7.5 Z-7.5");
							dgRightSide = false;
	
						}
						else
						{
							PosFixture.setPosition("X-7.5 Y7.5 Z-7.5");
							dgRightSide = true;
							dgCycleCount++;
						}
					}
					if (dgCycleCount > 12)
					{
						dgCycleCount = 0;
					}
					System.Threading.Thread.Sleep(100);
				}
			}

			PosFixture.update();

			//// Trend
			//lbOmegaITrend0.Text = lru0.dataParam[(int)PARAM.OIT0].ToString("0000.00");
			//lbOmegaITrend1.Text = lru0.dataParam[(int)PARAM.OIT1].ToString("0000.00");
			//lbOmegaITrend2.Text = lru0.dataParam[(int)PARAM.OIT2].ToString("0000.00");

		}

		//private void pbTempGraph_Paint(object sender, PaintEventArgs e)
		//{
		//    Chart.drawChartTempPb(sender, e);
		//}

		//private void pbCmdGraph_Paint(object sender, PaintEventArgs e)
		//{
		//    Chart.drawChartCmdPb(sender, e);
		//}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			Chart.drawChartTempPb(sender, e);
		}


		private void btMaxScale_Click(object sender, EventArgs e)
		{
			Chart.MAX_RATE = 100;
			Chart.MIN_RATE = -100;
		}

		private void btMidScale_Click(object sender, EventArgs e)
		{
			Chart.MAX_RATE = 10;
			Chart.MIN_RATE = -10;
		}

		private void btMicroScale_Click(object sender, EventArgs e)
		{
			Chart.MAX_RATE = 1;
			Chart.MIN_RATE = -1;
		}

		private void btMilliScale_Click(object sender, EventArgs e)
		{
			Chart.MAX_RATE = 0.1;
			Chart.MIN_RATE = -.1;
		}

		private void btUltraScale_Click(object sender, EventArgs e)
		{
			Chart.MAX_RATE = 1000;
			Chart.MIN_RATE = -1000;
		}

		private void btShowGyroRaw0_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.GYRO_RAW0;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.GYROXR0, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.GYROYR0, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.GYROZR0, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.FIFOCOUNT, RATE.RATE_25HZ);
			lbP1.Text = "Gyro X Raw";
			lbP2.Text = "Gyro Y Raw";
			lbP3.Text = "Gyro Z Raw";
			lbPA.Text = "Gyro FIFO Cnt";
		}

		private void btShowGyroRaw1_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.GYRO_RAW1;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.GYROXR1, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.GYROYR1, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.GYROZR1, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.FIFOCOUNT, RATE.RATE_25HZ);
			lbP1.Text = "Gyro X Raw";
			lbP2.Text = "Gyro Y Raw";
			lbP3.Text = "Gyro Z Raw";
			lbPA.Text = "Gyro FIFO Cnt";
		}


		private void btShowAccelRaw0_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.ACCEL_RAW0;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.ACCELXR0, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELYR0, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELZR0, RATE.RATE_50HZ);
			lbP1.Text = "Accel X Raw";
			lbP2.Text = "Accel Y Raw";
			lbP3.Text = "Accel Z Raw";
		}

		private void btShowAccelRaw1_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.ACCEL_RAW1;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.ACCELXR1, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELYR1, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELZR1, RATE.RATE_50HZ);
			lbP1.Text = "Accel X Raw";
			lbP2.Text = "Accel Y Raw";
			lbP3.Text = "Accel Z Raw";
		}

		private void btShowRpy_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.RPY;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.YAW, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.YAWT, RATE.RATE_25HZ);
			lbP1.Text = "Roll";
			lbP2.Text = "Pitch";
			lbP3.Text = "Yaw";
			lbPA.Text = "Yaw Target";

		}

		private void btShowWeights_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.WEIGHT;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_5HZ);
			lru0.setParameterReq((int)PARAM.RPYWEIGHT, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.BIASWEIGHT, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.AHRSRPYGATE, RATE.RATE_25HZ);
			lbP1.Text = "RPY Weight";
			lbP2.Text = "Bias Weight";
			lbP3.Text = "RPY Gate";

		}

		private void btFreeGyroMode_Click(object sender, EventArgs e)
		{
			if (freeGyroMode == true)
			{
				freeGyroMode = false;
				Chart.freeGyroMode = false;
				btFreeGyroMode.Text = "FREE GYRO OFF";
				// Send mode command
				lru0.setEngWriteF(ENG.FRGM, 0.0);
				Chart.rollMarker = lru0.dataParam[(int)PARAM.ROLL];
				Chart.pitchMarker = lru0.dataParam[(int)PARAM.PITCH];

			}
			else
			{
				freeGyroMode = true;
				Chart.freeGyroMode = true;
				btFreeGyroMode.Text = "FREE GYRO ON";
				timeInFreeMode = 0;
				// Send mode command
				lru0.setEngWriteF(ENG.FRGM, 1.0);
				Chart.rollMarker = lru0.dataParam[(int)PARAM.ROLL];
				Chart.pitchMarker = lru0.dataParam[(int)PARAM.PITCH];
			}
		}

		private void btShowGyroCal_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.GYRO_CAL;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.GYROXC, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.GYROYC, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.GYROZC, RATE.RATE_50HZ);
			lbP1.Text = "Gyro X Cal";
			lbP2.Text = "Gyro Y Cal";
			lbP3.Text = "Gyro Z Cal";
		}

		private void btShowAccelCal_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.ACCEL_CAL;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.ACCELXC, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELYC, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.ACCELZC, RATE.RATE_50HZ);
			lbP1.Text = "Accel X Cal";
			lbP2.Text = "Accel Y Cal";
			lbP3.Text = "Accel Z Cal";

		}

		private void btAhrsReset_Click(object sender, EventArgs e)
		{
			// Send mode command
			lru0.setEngWriteF(ENG.ARES, 0.0);
		}

		private void btStartRandom_Click(object sender, EventArgs e)
		{
			randomEnabled = true;
			// Start motion to enable motion stop for normal logic above
			Random r = new Random();
			int r1 = r.Next(-tbRandomScaleY.Value, +tbRandomScaleY.Value);
			int r2 = r.Next(-tbRandomScaleR.Value, +tbRandomScaleR.Value);
			int r3 = r.Next(-tbRandomScaleP.Value, +tbRandomScaleP.Value);
			if (cbRandomXEnabled.Checked != true) r1 = 0;
			if (cbRandomYEnabled.Checked != true) r2 = 0;
			if (cbRandomZEnabled.Checked != true) r3 = 0;
			PosFixture.setPosition("X" + r1.ToString() + " Y" + r2.ToString() + " Z" + r3.ToString());
		}

		private void btStopRandom_Click(object sender, EventArgs e)
		{
			randomEnabled = false;
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void btMoveRoll30_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y30 Z0");
		}

		private void btMoveRoll0_Click(object sender, EventArgs e)
		{
			PosFixture.setPosition("X0 Y0 Z0");
		}

		private void btShowGyroSum_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.GYRO_SUM;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			//lru0.setParameterReq((int)PARAM.GYROXSUM, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.GYROYSUM, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.GYROZSUM, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.OI0, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.OI1, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.OI2, RATE.RATE_50HZ);
			lbP1.Text = "Gyro X Bias";
			lbP2.Text = "Gyro Y Bias";
			lbP3.Text = "Gyro Z Bias";
		}

		private void btClearGyroSum_Click(object sender, EventArgs e)
		{
			// Send clear command
			lru0.setEngWriteF(ENG.SCLR, 0.0);
		}

		private void btShowStats1_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.STATS1;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.UPDATERATE, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.BATVOLTS, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.BATPERC, RATE.RATE_50HZ);
//			lru0.setParameterReq((int)PARAM.BTEMP, RATE.RATE_50HZ);
			lbP1.Text = "Display Update Rate";
			lbP2.Text = "Battery Volts";
			lbP3.Text = "Battery Perc";
//			lbP3.Text = "Board Temp";
		}

		private void btGoChrono_Click(object sender, EventArgs e)
		{
			// Send page show command
			lru0.setEngWriteF(ENG.PAGE, 1.0);
		}

		private void btGoCntUp_Click(object sender, EventArgs e)
		{
			lru0.setEngWriteF(ENG.PAGE, 2.0);
		}

		//private void btGoCntDn_Click(object sender, EventArgs e)
		//{
		//	lru0.setEngWriteF(ENG.PAGE, 3.0);
		//}

		private void btGoAoa_Click(object sender, EventArgs e)
		{
			lru0.setEngWriteF(ENG.PAGE, 3.0);
		}

		private void btGoTraf_Click(object sender, EventArgs e)
		{
			lru0.setEngWriteF(ENG.PAGE, 4.0);
		}

		private void btGoAi_Click(object sender, EventArgs e)
		{
			lru0.setEngWriteF(ENG.PAGE, 5.0);
		}

		private void btShowAirData_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.ADC;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.BCA, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.IAS, RATE.RATE_50HZ);
			//lru0.setParameterReq((int)PARAM.VS, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.AOA, RATE.RATE_50HZ);

			lbP1.Text = "BCA";
			lbP2.Text = "IAS";
			//			lbP3.Text = "VS";
			lbP3.Text = "AOA";

		}

		private void btShowHeaters_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.HEATERS;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.TEMPP, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.TEMPS, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.OATRAW, RATE.RATE_25HZ);
			lbP1.Text = "P TEMP";
			lbP2.Text = "S TEMP";
			lbP3.Text = "OAT A/D";
		}

		private void btShowAirRaw_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.AIRRAW;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.SENP, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.SENS, RATE.RATE_50HZ);
			lru0.setParameterReq((int)PARAM.OATRAW, RATE.RATE_50HZ);
			lbP1.Text = "P PRES";
			lbP2.Text = "S PRES";
			lbP3.Text = "OAT A/D";
		}

		private void btShowRates_Click(object sender, EventArgs e)
		{
			dataSource = (int)SOURCE.RATES;
			lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			lru0.setParameterReq((int)PARAM.ROLLRATE, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.PITCHRATE, RATE.RATE_25HZ);
			lru0.setParameterReq((int)PARAM.YAWRATE, RATE.RATE_25HZ);
			lbP1.Text = "ROLL RATE";
			lbP2.Text = "PITCH RATE";
			lbP3.Text = "YAW RATE";
		}

		private void btStartDg_Click(object sender, EventArgs e)
		{
			dgMotionEnabled = true;
			PosFixture.setPosition("X0 Y0 Z0");
			// Slow
			PosFixture.sendCommand("$xvm=200"); // xMax rate (mm/min)
			PosFixture.sendCommand("$yvm=200"); // yMax rate (mm/min)
			PosFixture.sendCommand("$zvm=200"); // zMax rate (mm/min)
			PosFixture.sendCommand("$xjm=.15");   // xMax jerk (mm/min)
			PosFixture.sendCommand("$yjm=.15");   // yMax jerk (mm/min)
			PosFixture.sendCommand("$zjm=.15");   // zMax jerk (mm/min)
			System.Threading.Thread.Sleep(2000);
		}

		private void btStopDg_Click(object sender, EventArgs e)
		{
			dgMotionEnabled = false;
			PosFixture.setPosition("X0 Y0 Z0");
			// Normal
			PosFixture.sendCommand("$xvm=2000"); // xMax rate (mm/min)
			PosFixture.sendCommand("$yvm=2000"); // yMax rate (mm/min)
			PosFixture.sendCommand("$zvm=2000"); // zMax rate (mm/min)
			PosFixture.sendCommand("$xjm=20");   // xMax jerk (mm/min)
			PosFixture.sendCommand("$yjm=20");   // yMax jerk (mm/min)
			PosFixture.sendCommand("$zjm=20");   // zMax jerk (mm/min)
			System.Threading.Thread.Sleep(2000);

		}
	}
}
