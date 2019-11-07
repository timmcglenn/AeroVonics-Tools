using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace CalTool
{
	class CalMag
	{
		// Constants
		private const int SAMPLE_COUNT = 5;
		private const int FLASH_LOC_MAG_CAL_START = 100;    // Start of cal table in sensor board flash memory
		private const int NUM_CAL_POINTS = 6;               // 3 offset, 3 scale

		// State machine sates
		enum BIAS_STATE { SET_BIAS, WAIT_BIAS, GET_BIAS, PROG_BIAS };
		enum SCALE_STATE { SET_SCALE, WAIT_SCALE, GET_SCALE, END_SCALE };
		enum PRG_STATE { PRG_SCALE };
		enum READ_STATE { READ_POINT, WAIT_POINT };
		enum CAL_POINT { BIASX };

		public static string[] movePoints = { "X-90 Y0 Z0", "X90 Y0 Z0", "X0 Y90 Z0", "X0 Y-90 Z0", "X0 Y0 Z-90", "X0 Y0 Z90", "X0 Y0 Z0" };
		public static string[] movePointDesc = { "X BIAS +", "X BIAS -", "X BIAS -", "X BIAS -", "X BIAS -", "X BIAS -", "X BIAS -" };

		// State variables
		static MainForm uiForm;
		private static bool biasPointsRunning = false;
		private static bool scalePointsRunning = false;
		private static bool prgPointsRunning = false;
		private static bool readPointsRunning = false;
		private static int currentState = 0;
		private static int sampleCount = 0;
		private static int loopCount = 0;

		// Public
		public static int writeCount;
		public static int readCount;
		private static int locCount;

		// Cal data
		public static double[] dataSample = new double[SAMPLE_COUNT];
		//public static double[] calData = new double[NUM_CAL_POINTS];
		public static double[] dataPoint = new double[movePoints.Length];
		private static double xBiasPos, xBiasNeg;
		public static double xScale, yScale, zScale;

		// Accessors
		public static void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}

		public static void setMagCalRunningState(bool run)
		{
			setBiasRunningSate(true);
		}
		public static bool getMagCalRunningState(bool run)
		{
			return (biasPointsRunning | scalePointsRunning | prgPointsRunning | readPointsRunning);
		}
		public static void setMagCalReset()
		{
			uiForm.btLru0MagXMin.Text = "9999.0";
			uiForm.btLru0MagYMin.Text = "9999.0";
			uiForm.btLru0MagZMin.Text = "9999.0";
			uiForm.btLru0MagXMax.Text = "-9999.0";
			uiForm.btLru0MagYMax.Text = "-9999.0";
			uiForm.btLru0MagZMax.Text = "-9999.0";
		}

		// Start / Stop
		public static void setBiasRunningSate(bool run)
		{
			if (run)
			{
				// Start with bias cal
				biasPointsRunning = true;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;


				uiForm.btLru0MagParmName.Text = "Bias Values";
				uiForm.btLru0MagParmValue.Text = "Set Position";
				uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru0.setParameterReq((int)PARAM.MAGX, RATE.RATE_50HZ);
				uiForm.lru0.setParameterReq((int)PARAM.MAGY, RATE.RATE_50HZ);
				uiForm.lru0.setParameterReq((int)PARAM.MAGZ, RATE.RATE_50HZ);

				// Initial values
				currentState = 0;
				loopCount = 0;

				uiForm.btLru0MagXMin.Text = "9999.0";
				uiForm.btLru0MagYMin.Text = "9999.0";
				uiForm.btLru0MagZMin.Text = "9999.0";
				uiForm.btLru0MagXMax.Text = "-9999.0";
				uiForm.btLru0MagYMax.Text = "-9999.0";
				uiForm.btLru0MagZMax.Text = "-9999.0";


				// Button color
				uiForm.btStartMagCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				uiForm.btStartMagCal.BackColor = System.Drawing.Color.DimGray;

				// Move home
				PosFixture.setPosition("X0 Y0 Z0");

			}
		}

		public static void setScaleRunningSate(bool run)
		{
			if (run)
			{
				// Move to scale cal
				currentState = 0;
				biasPointsRunning = false;
				scalePointsRunning = true;
				readPointsRunning = false;
				prgPointsRunning = false;



				// Button color
				uiForm.btStartMagCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				uiForm.btStartMagCal.BackColor = System.Drawing.Color.DimGray;

				// Move home
				PosFixture.setPosition("X0 Y0 Z0");
			}
		}

		public static void setPrgRunningState(bool run)
		{
			if (run)
			{
				// Turn data off
				uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Start new write cycle
				writeCount = 0;
				locCount = FLASH_LOC_MAG_CAL_START;
				currentState = 0;
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = true;

				// Button color
				uiForm.btStartMagProg.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				uiForm.btStartMagProg.BackColor = System.Drawing.Color.Transparent;
			}
		}

		public static void setReadRunningState(bool run)
		{
			if (run)
			{
				// Turn data off
				uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Start new read all cycle
				readCount = 0;
				locCount = FLASH_LOC_MAG_CAL_START;
				currentState = 0;
				readPointsRunning = true;
				scalePointsRunning = false;
				prgPointsRunning = false;
				biasPointsRunning = false;

				// Clear form table entries
				uiForm.dgMagCalLru0Data.Rows.Clear();
				uiForm.dgMagCalParam.Rows.Clear();

				//// Setup empty entries
				//for (int i = 0; i < BcaCalPoints.bcaCalPointsNum; i++)
				//{
				//	uiForm.dgMagCalLru0Data.Rows.Add(0.ToString("00.00"), "PENDING");
				//}

				// Button color
				uiForm.btStartMagRead.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				uiForm.btStartMagRead.BackColor = System.Drawing.Color.Transparent;
			}
		}




		// Get state
		public static bool getMagCalRunningState()
		{
			return biasPointsRunning || scalePointsRunning;
		}
		public static bool getMagPrgRunningState()
		{
			return prgPointsRunning;
		}

		private static void addTableEntry(string param, double value, string status)
		{

			// Add to cal data table
			uiForm.dgMagCalParam.Rows.Add(param.ToString());
			uiForm.dgMagCalLru0Data.Rows.Add(value.ToString("00.00000"), status);

			//Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
			//(dgv as DataGridView).Rows.Add(avPReading.Average().ToString("0000.00"), avSReading.Average().ToString("0000.00"), "MEASURED");
		}

		// State machine update
		public static void update()
		{
			string msg = "";

			// Handle state
			if (biasPointsRunning)
			{
				// Display Current
				uiForm.btLru0MagXCur.Text = uiForm.lru0.dataParam[(int)PARAM.MAGX].ToString("0000");
				uiForm.btLru0MagYCur.Text = uiForm.lru0.dataParam[(int)PARAM.MAGY].ToString("0000");
				uiForm.btLru0MagZCur.Text = uiForm.lru0.dataParam[(int)PARAM.MAGZ].ToString("0000");

				// Default Colors
				uiForm.btLru0MagXMin.BackColor = Color.Transparent;
				uiForm.btLru0MagYMin.BackColor = Color.Transparent;
				uiForm.btLru0MagZMin.BackColor = Color.Transparent;
				uiForm.btLru0MagXMax.BackColor = Color.Transparent;
				uiForm.btLru0MagYMax.BackColor = Color.Transparent;
				uiForm.btLru0MagZMax.BackColor = Color.Transparent;
				uiForm.btLru0MagXNorm.BackColor = Color.Transparent;
				uiForm.btLru0MagYNorm.BackColor = Color.Transparent;
				uiForm.btLru0MagZNorm.BackColor = Color.Transparent;

				if ((uiForm.lru0.dataParam[(int)PARAM.MAGX] != 0) &&
					(uiForm.lru0.dataParam[(int)PARAM.MAGY] != 0) &&
					(uiForm.lru0.dataParam[(int)PARAM.MAGZ] != 0))
				{
					// Mag Min
					if (uiForm.lru0.dataParam[(int)PARAM.MAGX] < double.Parse(uiForm.btLru0MagXMin.Text))
					{
						uiForm.btLru0MagXMin.Text = uiForm.lru0.dataParam[(int)PARAM.MAGX].ToString("F1");
						uiForm.btLru0MagXMin.BackColor = Color.DarkGreen;
					}
					if (uiForm.lru0.dataParam[(int)PARAM.MAGY] < double.Parse(uiForm.btLru0MagYMin.Text))
					{
						uiForm.btLru0MagYMin.Text = uiForm.lru0.dataParam[(int)PARAM.MAGY].ToString("F1");
						uiForm.btLru0MagYMin.BackColor = Color.DarkGreen;
					}
					if (uiForm.lru0.dataParam[(int)PARAM.MAGZ] < double.Parse(uiForm.btLru0MagZMin.Text))
					{
						uiForm.btLru0MagZMin.Text = uiForm.lru0.dataParam[(int)PARAM.MAGZ].ToString("F1");
						uiForm.btLru0MagZMin.BackColor = Color.DarkGreen;
					}

					// Mag Max
					if (uiForm.lru0.dataParam[(int)PARAM.MAGX] > double.Parse(uiForm.btLru0MagXMax.Text))
					{
						uiForm.btLru0MagXMax.Text = uiForm.lru0.dataParam[(int)PARAM.MAGX].ToString("F1");
						uiForm.btLru0MagXMax.BackColor = Color.DarkGreen;
					}
					if (uiForm.lru0.dataParam[(int)PARAM.MAGY] > double.Parse(uiForm.btLru0MagYMax.Text))
					{
						uiForm.btLru0MagYMax.Text = uiForm.lru0.dataParam[(int)PARAM.MAGY].ToString("F1");
						uiForm.btLru0MagYMax.BackColor = Color.DarkGreen;
					}
					if (uiForm.lru0.dataParam[(int)PARAM.MAGZ] > double.Parse(uiForm.btLru0MagZMax.Text))
					{
						uiForm.btLru0MagZMax.Text = uiForm.lru0.dataParam[(int)PARAM.MAGZ].ToString("F1");
						uiForm.btLru0MagZMax.BackColor = Color.DarkGreen;
					}

					// Delta
					uiForm.btLru0MagXDelta.Text = Math.Abs(double.Parse(uiForm.btLru0MagXMax.Text) - double.Parse(uiForm.btLru0MagXMin.Text)).ToString("F1");
					uiForm.btLru0MagYDelta.Text = Math.Abs(double.Parse(uiForm.btLru0MagYMax.Text) - double.Parse(uiForm.btLru0MagYMin.Text)).ToString("F1");
					uiForm.btLru0MagZDelta.Text = Math.Abs(double.Parse(uiForm.btLru0MagZMax.Text) - double.Parse(uiForm.btLru0MagZMin.Text)).ToString("F1");

					uiForm.btLru0MagXOffset.Text = (-double.Parse(uiForm.btLru0MagXMin.Text) - (double.Parse(uiForm.btLru0MagXDelta.Text) / 2)).ToString("F2");
					uiForm.btLru0MagYOffset.Text = (-double.Parse(uiForm.btLru0MagYMin.Text) - (double.Parse(uiForm.btLru0MagYDelta.Text) / 2)).ToString("F2");
					uiForm.btLru0MagZOffset.Text = (-double.Parse(uiForm.btLru0MagZMin.Text) - (double.Parse(uiForm.btLru0MagZDelta.Text) / 2)).ToString("F2");

					uiForm.btLru0MagXCent.Text = (uiForm.lru0.dataParam[(int)PARAM.MAGX] + double.Parse(uiForm.btLru0MagXOffset.Text)).ToString("F3");
					uiForm.btLru0MagYCent.Text = (uiForm.lru0.dataParam[(int)PARAM.MAGY] + double.Parse(uiForm.btLru0MagYOffset.Text)).ToString("F3");
					uiForm.btLru0MagZCent.Text = (uiForm.lru0.dataParam[(int)PARAM.MAGZ] + double.Parse(uiForm.btLru0MagZOffset.Text)).ToString("F3");

					uiForm.btLru0MagXNorm.Text = (double.Parse(uiForm.btLru0MagXCent.Text) / (double.Parse(uiForm.btLru0MagXDelta.Text) / 2)).ToString("F3");
					uiForm.btLru0MagYNorm.Text = (double.Parse(uiForm.btLru0MagYCent.Text) / (double.Parse(uiForm.btLru0MagYDelta.Text) / 2)).ToString("F3");
					uiForm.btLru0MagZNorm.Text = (double.Parse(uiForm.btLru0MagZCent.Text) / (double.Parse(uiForm.btLru0MagZDelta.Text) / 2)).ToString("F3");

					if (Math.Abs(double.Parse(uiForm.btLru0MagXNorm.Text)) > 0.95)
						uiForm.btLru0MagXNorm.BackColor = Color.DarkGreen;
					if (Math.Abs(double.Parse(uiForm.btLru0MagYNorm.Text)) > 0.95)
						uiForm.btLru0MagYNorm.BackColor = Color.DarkGreen;
					if (Math.Abs(double.Parse(uiForm.btLru0MagZNorm.Text)) > 0.95)
						uiForm.btLru0MagZNorm.BackColor = Color.DarkGreen;


					// Computed Heading
					double heading = Math.Atan2(double.Parse(uiForm.btLru0MagYNorm.Text), double.Parse(uiForm.btLru0MagXNorm.Text));
					if (heading < 0)
					{
						heading += 2 * 3.14;
					}
					heading *= 180 / 3.14;

					//if ((heading > 0) && (heading < 360))
					//{
					//	heading = 360.0 - heading;
					//	currentHeading = accumHeading / 10;
					//	accumHeading += heading - currentHeading;
					//}

					uiForm.btLru0Heading.Text = heading.ToString("F0");


				}

//				msg = biasStateMachine();
			}
			//else if (scalePointsRunning)
			//{
			//	msg = scaleStateMachine();
			//}
			//else if (prgPointsRunning)
			//{
			//	msg = prgPointsStateMachine();
			//}
			//else if (readPointsRunning)
			//{
			//	msg = readPointsStateMachine();
			//}

			// Handle next step
			if (msg == "next")
				currentState++;
			else if (msg == "back")
				currentState--;
			else if (msg == "skip")
				currentState += 2;
			else if (msg == "wait")
			{ }
			else if (msg == "end")
			{
				// Turn off outputs
				uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				biasPointsRunning = false;
				scalePointsRunning = false;
				prgPointsRunning = false;
				readPointsRunning = false;

				// Back to zero
				PosFixture.setPosition("X0 Y0 Z0");

				// Data
				uiForm.btLru0MagParmName.Text = "Complete";
				uiForm.btLru0MagParmValue.Text = "";

				// Button color
				uiForm.btStartMagCal.BackColor = System.Drawing.Color.DimGray;
			}
		}



		private static string biasStateMachine()
		{
			switch (currentState)
			{
				case (int)BIAS_STATE.SET_BIAS:
					{
						if (loopCount < movePoints.Length)
						{
							PosFixture.setPosition(movePoints[loopCount]);
							uiForm.btLru0MagParmName.Text = movePoints[loopCount];

							return ("next");
						}
						else
						{
							//currentState = (int)BIAS_STATE.PROG_BIAS;
							return ("none");
						}
					}

				case (int)BIAS_STATE.WAIT_BIAS:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							sampleCount = 0;
							return ("next");
						}
					}

				case (int)BIAS_STATE.GET_BIAS:
					{
						uiForm.btLru0MagParmName.Text = movePointDesc[loopCount];

						switch (loopCount)
						{
							// X Positive
							case 0:
								xBiasPos = uiForm.lru0.dataParam[(int)PARAM.MAGX];
								break;

							// X Negative
							case 1:
								xBiasNeg = uiForm.lru0.dataParam[(int)PARAM.MAGX];
								break;
						}
						loopCount++;
						currentState = (int)BIAS_STATE.SET_BIAS;
						return ("none");
					}

				case (int)BIAS_STATE.PROG_BIAS:
					{
						return ("end");
						//uiForm.btLru0MagParmName.Text = "Program Bias XYZ";
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 0, xBiasPos - xBiasNeg;
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 1, calData[(int)CAL_POINT.BIASY]);
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 2, calData[(int)CAL_POINT.BIASZ]);

						//// Clear scales
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 3, 1);
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 4, 1);
						//uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 5, 1);

						//uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);

						//// Start Scale
						//setScaleRunningSate(true);
						//return ("none");
					}


				default:
					{
						return ("end");
					}
			}
		}




		//private static string scaleStateMachine()
		//{
		//	switch (currentState)
		//	{

		//		case (int)SCALE_STATE.SET_SCALE:
		//			{
		//				if (loopCount < movePoints.Length)
		//				{
		//					PosFixture.setPosition(movePoints[loopCount]);
		//					uiForm.btLru0MagParmName.Text = movePoints[loopCount];
		//					sampleCount = 0;
		//					return ("next");
		//				}
		//				else
		//				{
		//					currentState = (int)SCALE_STATE.END_SCALE;
		//					return ("none");
		//				}
		//			}

		//		case (int)SCALE_STATE.WAIT_SCALE:
		//			{
		//				uiForm.btLru0MagParmValue.Text = "X:" + uiForm.lru0.dataParam[(int)PARAM.ROLL].ToString("0000") +
		//					" Y:" + uiForm.lru0.dataParam[(int)PARAM.PITCH].ToString("0000") +
		//					" Z:" + uiForm.lru0.dataParam[(int)PARAM.YAW].ToString("0000");
		//				if (PosFixture.getInMotion())
		//				{
		//					return ("wait");
		//				}
		//				else
		//				{
		//					// Wait for full motion to stop and get readings
		//					if (sampleCount++ > 10)
		//					{
		//						return ("next");
		//					}
		//					else
		//					{
		//						return ("wait");
		//					}
		//				}
		//			}

		//		case (int)SCALE_STATE.GET_SCALE:
		//			{

		//				switch (loopCount)
		//				{
		//					// X Effect (Roll)
		//					case 0:
		//						xScale = uiForm.lru0.dataParam[(int)PARAM.MAGX];
		//						xony = uiForm.lru0.dataParam[(int)PARAM.PITCH];
		//						xonz = uiForm.lru0.dataParam[(int)PARAM.YAW];
		//						break;
		//					case 1:
		//						xonx = (1.0 / ((-xonx + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / (ANGLE * 2)));
		//						xony = ((-xony + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / (ANGLE * 2));
		//						xonz = ((-xonz + uiForm.lru0.dataParam[(int)PARAM.YAW]) / (ANGLE * 2));
		//						addTableEntry("X on X", xonx, "MEASURE");
		//						addTableEntry("X on Y", xony, "MEASURE");
		//						addTableEntry("X on Z", xonz, "MEASURE");
		//						PosFixture.setPosition("X0 Y0 Z0");
		//						break;

		//					// Y Effect (Pitch)
		//					case 2:
		//						// Capture roll left
		//						yonx = uiForm.lru0.dataParam[(int)PARAM.ROLL];
		//						yony = uiForm.lru0.dataParam[(int)PARAM.PITCH];
		//						yonz = uiForm.lru0.dataParam[(int)PARAM.YAW];
		//						break;
		//					case 3:
		//						// Capture roll right and get overall scale
		//						yonx = ((-yonx + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / (ANGLE * 2));
		//						yony = (1.0 / ((-yony + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / (ANGLE * 2)));
		//						yonz = ((-yonz + uiForm.lru0.dataParam[(int)PARAM.YAW]) / (ANGLE * 2));
		//						addTableEntry("Y on X", yonx, "MEASURE");
		//						addTableEntry("Y on Y", yony, "MEASURE");
		//						addTableEntry("Y on Z", yonz, "MEASURE");
		//						PosFixture.setPosition("X0 Y0 Z0");
		//						break;

		//					// Z Effect (Yaw)
		//					case 4:
		//						// Capture roll left
		//						zonx = uiForm.lru0.dataParam[(int)PARAM.ROLL];
		//						zony = uiForm.lru0.dataParam[(int)PARAM.PITCH];
		//						zonz = uiForm.lru0.dataParam[(int)PARAM.YAW];
		//						break;
		//					case 5:
		//						// Capture roll right and get overall scale
		//						zonx = ((-zonx + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / (ANGLE * 2));
		//						zony = ((-zony + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / (ANGLE * 2));
		//						zonz = (1.0 / ((-zonz + uiForm.lru0.dataParam[(int)PARAM.YAW]) / (ANGLE * 2)));
		//						addTableEntry("Z on X", zonx, "MEASURE");
		//						addTableEntry("Z on Y", zony, "MEASURE");
		//						addTableEntry("Z on Z", zonz, "MEASURE");
		//						PosFixture.setPosition("X0 Y0 Z0");
		//						break;

		//				}

		//				loopCount++;
		//				currentState = (int)SCALE_STATE.SET_SCALE;
		//				return ("none");
		//			}

		//		case (int)SCALE_STATE.END_SCALE:
		//			{
		//				// Put back into slave mode
		//				uiForm.lru0.setEngWriteF(ENG.FRGM, 0.0);
		//				PosFixture.setPosition("X0 Y0 Z0");

		//				// Check for chain
		//				if (uiForm.cbChainMaglCalToPrg.Checked)
		//				{
		//					// Start Program cycle
		//					setPrgRunningState(true);
		//					return ("wait");
		//				}
		//				return ("end");
		//			}
		//		default:
		//			{
		//				return ("end");
		//			}

		//	}
		//}



		//private static string prgPointsStateMachine()
		//{
		//	switch (currentState)
		//	{
		//		case (int)PRG_STATE.PRG_SCALE:
		//			{
		//				uiForm.btLru0MagParmName.Text = "Program Scales";
		//				// Scales start 3 after bias (already programed)
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 3, xonx);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 4, xony);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 5, xonz);

		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 6, yonx);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 7, yony);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 8, yonz);

		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 9, zonx);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 10, zony);
		//				uiForm.lru0.setCalWriteF(FLASH_LOC_MAG_CAL_START + 11, zonz);

		//				uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);


		//				// End
		//				// Shut this state off
		//				prgPointsRunning = false;
		//				// Button color
		//				uiForm.btStartMagProg.BackColor = System.Drawing.Color.DarkGreen;
		//				// Check for chain
		//				if (uiForm.cbChainMagPrgToRead.Checked)
		//				{
		//					// Start Read cycle
		//					setReadRunningState(true);
		//					return ("wait");
		//				}
		//				else
		//				{
		//					return ("end");
		//				}
		//			}

		//		default:
		//			{
		//				return ("end");
		//			}
		//	}

		//}




		//private static string readPointsStateMachine()
		//{
		//	switch (currentState)
		//	{
		//		case (int)READ_STATE.READ_POINT:
		//			{
		//				// Read each cal point
		//				if (readCount < NUM_CAL_POINTS)
		//				{
		//					// Request data point
		//					uiForm.lru0.setCalReadF(locCount);
		//					return ("next");
		//				}
		//				else
		//				{
		//					// Shut this state off
		//					readPointsRunning = false;
		//					// Button color
		//					uiForm.btStartMagRead.BackColor = System.Drawing.Color.DarkGreen;
		//					//// Check for chain
		//					//if (uiForm.cbChainReadToTest.Checked)
		//					//{
		//					//	// Start Test cycle
		//					//	AtpAdc.setAtpBcaRunningSate(true);
		//					//	return ("wait");
		//					//}
		//					return ("end");
		//				}
		//			}

		//		case (int)READ_STATE.WAIT_POINT:
		//			{
		//				// See if value is back
		//				// TODO address sign
		//				if (!uiForm.lru0.returnReady)
		//				{
		//					return ("wait");
		//				}
		//				else
		//				{

		//					addTableEntry(movePointDesc[readCount], uiForm.lru0.senBoardFbValF, "READ");
		//					readCount++;
		//					locCount++;

		//					// Loop back to next point
		//					currentState = (int)READ_STATE.READ_POINT;
		//					return ("other");
		//				}
		//			}
		//		default:
		//			{
		//				return ("end");
		//			}
		//	}

		//}



	}
}


