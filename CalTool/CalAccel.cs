using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalTool
{
	class CalAccel
	{
		// Constants
		private const int SAMPLE_COUNT = 200;
		private const int HOLD_COUNT = 100;
		private const int FLASH_LOC_ACCEL_CAL_START = 70;     // Start of cal table in sensor board flash memory
		private const int NUM_CAL_POINTS = 9;
		private const string ANGLE = "45";
		private const double ANGLE_IN_RAD = (45 * (Math.PI / 180.0));

		private const double ROLL_ON_PITCH_POS = +0;       // Pitch effect when rolled positive
		private const double ROLL_ON_PITCH_NEG = +0;       // Pitch effect when rolled negative


		// State machine sates
		enum CAL_STATE
		{
			SET_ACCELX0, WAIT_ACCELX0, GET_ACCELX0,     // Accel X Zero 
			SET_ACCELXP1, WAIT_ACCELXP1, GET_ACCELXP1,  // Accel X Positive 1
			SET_ACCELXN1, WAIT_ACCELXN1, GET_ACCELXN1,  // Accel X Negative 1

			SET_ACCELY0, WAIT_ACCELY0, GET_ACCELY0,     // Accel Y Zero 
			SET_ACCELYP1, WAIT_ACCELYP1, GET_ACCELYP1,  // Accel Y Positive 1
			SET_ACCELYN1, WAIT_ACCELYN1, GET_ACCELYN1,  // Accel Y Negative 1

			SET_ACCELZ0, WAIT_ACCELZ0, GET_ACCELZ0,     // Accel Z Zero 
			SET_ACCELZP1, WAIT_ACCELZP1, GET_ACCELZP1,  // Accel Z Positive 1
			SET_ACCELZN1, WAIT_ACCELZN1, GET_ACCELZN1,  // Accel Z Negative 1

		};
		enum PRG_STATE { PRG_ACCEL };
		enum READ_STATE { READ_POINT, WAIT_POINT };
		enum CAL_POINT { AXZ, AXP, AXN, AYZ, AYP, AYN, AZZ, AZP, AZN };

		// State variables
		static MainForm uiForm;
		public static bool calPointsRunning = false;
		public static bool prgPointsRunning = false;
		public static bool readPointsRunning = false;
		private static int currentState = 0;
		private static int sampleCount = 0;

		// Public
		public static int writeCount;
		public static int readCount;
		private static int locCount;

		// Cal data
		public static double[] dataSample0 = new double[SAMPLE_COUNT];
		public static double[] dataSample1 = new double[SAMPLE_COUNT];

		public static double[] calData = new double[NUM_CAL_POINTS];

		// Accessors
		public static void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}

		// Start / Stop
		public static void setCalRunningSate(bool run)
		{
			if (run)
			{

				// Start with accel cal
				currentState = 0;
				calPointsRunning = true;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Initial values
				calData[(int)CAL_POINT.AXZ] = 0;
				calData[(int)CAL_POINT.AXP] = 1;
				calData[(int)CAL_POINT.AXN] = -1;
				calData[(int)CAL_POINT.AYZ] = 0;
				calData[(int)CAL_POINT.AYP] = 1;
				calData[(int)CAL_POINT.AYN] = -1;
				calData[(int)CAL_POINT.AZZ] = 0;
				calData[(int)CAL_POINT.AZP] = 1;
				calData[(int)CAL_POINT.AZN] = -1;

				// Button color
				uiForm.btStartAccelCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// State
				calPointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartAccelCal.BackColor = System.Drawing.Color.DimGray;

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
				locCount = FLASH_LOC_ACCEL_CAL_START;
				currentState = 0;
				calPointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = true;

				// Button color
				uiForm.btStartAccelProg.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				calPointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartAccelProg.BackColor = System.Drawing.Color.Transparent;
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
				locCount = FLASH_LOC_ACCEL_CAL_START;
				currentState = 0;
				readPointsRunning = true;
				prgPointsRunning = false;
				calPointsRunning = false;

				// Clear form table entries
				uiForm.dgAccelCalLru0Data.Rows.Clear();

				//// Setup empty entries
				//for (int i = 0; i < BcaCalPoints.bcaCalPointsNum; i++)
				//{
				//	uiForm.dgAccelCalLru0Data.Rows.Add(0.ToString("00.00"), "PENDING");
				//}

				// Button color
				uiForm.btStartAccelRead.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				calPointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartAdcRead.BackColor = System.Drawing.Color.Transparent;
			}
		}




		// Get state
		public static bool getCalRunningState()
		{
			return calPointsRunning;
		}
		public static bool getPrgRunningState()
		{
			return prgPointsRunning;
		}

		private static void addTableEntry(string param, double value, string status)
		{

			// Add to cal data table
			uiForm.dgAccelCalParam.Rows.Add(param.ToString());
			uiForm.dgAccelCalLru0Data.Rows.Add(value.ToString("00.00000"), status);

			//Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
			//(dgv as DataGridView).Rows.Add(avPReading.Average().ToString("0000.00"), avSReading.Average().ToString("0000.00"), "MEASURED");
		}

		// State machine update
		public static void update()
		{
			string msg = "";


			// Show data based on state
			if ((currentState >= (int)CAL_STATE.SET_ACCELX0) && (currentState <= (int)CAL_STATE.GET_ACCELXN1))
			{
				//uiForm.btLru0AccelParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELXR].ToString("00.00000");
			}
			if ((currentState >= (int)CAL_STATE.SET_ACCELY0) && (currentState <= (int)CAL_STATE.GET_ACCELYN1))
			{
				uiForm.btLru0AccelParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELYR0].ToString("00.00000");
			}
			if ((currentState >= (int)CAL_STATE.SET_ACCELZ0) && (currentState <= (int)CAL_STATE.GET_ACCELZN1))
			{
				uiForm.btLru0AccelParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELZR0].ToString("00.00000");
			}


			// Handle state
			if (calPointsRunning)
			{

				// Accel cal points
				msg = accelStateMachine();
			}
			else if (prgPointsRunning)
			{
				// Program points
				msg = prgPointsStateMachine();
			}
			else if (readPointsRunning)
			{
				// Read points
				msg = readPointsStateMachine();
			}

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
				calPointsRunning = false;
				prgPointsRunning = false;
				readPointsRunning = false;

				// Back to zero
				PosFixture.setPosition("X0 Y0 Z0");

				// Data
				uiForm.btLru0AccelParmName.Text = "Complete";
				uiForm.btLru0AccelParmValue.Text = "";

				// Button color
				//uiForm.btStartAccelCal.BackColor = System.Drawing.Color.DimGray;
			}
		}



		private static string accelStateMachine()
		{
			int loop = 0;

			switch (currentState)
			{

				//
				// Accel X
				//
				case (int)CAL_STATE.SET_ACCELX0:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELXR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELXR1, RATE.RATE_50HZ);
						uiForm.btLru0AccelParmName.Text = "Accel X Zero";
						///PosFixture.setPosition("X5 Y5 Z5");
						PosFixture.setPosition("X0 Y0 Z0");
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELX0:
					{
						if (PosFixture.getInMotion())
						{

							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELX0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELXR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELXR1];
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");

							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AXZ] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AXZ], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELXP1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel X Pos";
						PosFixture.setPosition("X0 Y0 Z-" + ANGLE);
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELXP1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELXP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELXR0] - calData[(int)CAL_POINT.AXZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELXR1] - calData[(int)CAL_POINT.AXZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AXP] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AXP], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELXN1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel X Neg";
						PosFixture.setPosition("X0 Y0 Z+" + ANGLE);
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELXN1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELXN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELXR0] - calData[(int)CAL_POINT.AXZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELXR1] - calData[(int)CAL_POINT.AXZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AXN] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AXN], "MEASURE");
							return ("next");
						}
					}



				//
				// Accel Y
				//
				case (int)CAL_STATE.SET_ACCELY0:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELYR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELYR1, RATE.RATE_50HZ);
						uiForm.btLru0AccelParmName.Text = "Accel Y Zero";

						PosFixture.setPosition("X0 Y0 Z0");
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELY0:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELY0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELYR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELYR1];
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AYZ] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AYZ], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELYP1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel Y Pos";
						PosFixture.setPosition("X0 Y" + ANGLE + " Z" + ROLL_ON_PITCH_POS);
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELYP1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELYP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELYR0] - calData[(int)CAL_POINT.AYZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELYR1] - calData[(int)CAL_POINT.AYZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AYP] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AYP], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELYN1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel Y Neg";
						PosFixture.setPosition("X0 Y-" + ANGLE + " Z" + ROLL_ON_PITCH_NEG);
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELYN1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELYN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELYR0] - calData[(int)CAL_POINT.AYZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELYR1] - calData[(int)CAL_POINT.AYZ]) * (1.0 / Math.Sin(ANGLE_IN_RAD));
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AYN] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AYN], "MEASURE");
							return ("next");
						}
					}



				//
				// Accel Z
				//
				case (int)CAL_STATE.SET_ACCELZ0:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELZR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELZR1, RATE.RATE_50HZ);
						uiForm.btLru0AccelParmName.Text = "Accel Z Zero";

						PosFixture.setPosition("X0 Y90 Z0");
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELZ0:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELZ0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELZR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELZR1];
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AZZ] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AZZ], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELZP1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel Z Pos";
						PosFixture.setPosition("X0 Y0 Z0");
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELZP1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELZP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELZR0] - calData[(int)CAL_POINT.AZZ]);
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELZR1] - calData[(int)CAL_POINT.AZZ]);
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AZP] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AZP], "MEASURE");
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELZN1:
					{
						uiForm.btLru0AccelParmName.Text = "Accel Z Neg";
						PosFixture.setPosition("X0 Y180 Z0");
						sampleCount = HOLD_COUNT;
						return ("next");
					}
				case (int)CAL_STATE.WAIT_ACCELZN1:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							if (sampleCount-- > 0)
							{
								return ("wait");
							}
							else
							{
								sampleCount = 0;
								return ("next");
							}
						}
					}
				case (int)CAL_STATE.GET_ACCELZN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELZR0] - calData[(int)CAL_POINT.AZZ]);
							dataSample1[sampleCount] = (uiForm.lru0.dataParam[(int)PARAM.ACCELZR1] - calData[(int)CAL_POINT.AZZ]);
							uiForm.btLru0AccelParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.AZN] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0AccelParmName.Text, calData[(int)CAL_POINT.AZN], "MEASURE");

							// Back to zero
							PosFixture.setPosition("X0 Y0 Z0");

							// Start Prog cycle
							setPrgRunningState(true);
							return ("wait");

						}
					}



				default:
					{
						return ("end");
					}

			}

		}


		private static string prgPointsStateMachine()
		{
			switch (currentState)
			{
				case (int)PRG_STATE.PRG_ACCEL:
					{
						if (writeCount < NUM_CAL_POINTS)
						{
							// Write accel  cal values
							uiForm.lru0.setCalWriteF(locCount, calData[writeCount]);
							uiForm.dgAccelCalLru0Data[1, writeCount].Value = "PROG";
							writeCount++;
							locCount++;
							return ("wait");
						}
						else
						{
							// End
							uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);

							// Shut this state off
							prgPointsRunning = false;

							// Button color
							uiForm.btStartAccelProg.BackColor = System.Drawing.Color.DarkGreen;
							
							// Start Read cycle
							setReadRunningState(true);
							return ("wait");

						}
					}

				default:
					{
						return ("end");
					}
			}

		}




		private static string readPointsStateMachine()
		{
			switch (currentState)
			{
				case (int)READ_STATE.READ_POINT:
					{
						// Read each cal point
						if (readCount < NUM_CAL_POINTS)
						{
							// Request data point
							uiForm.lru0.setCalReadF(locCount);
							uiForm.setConsoleText("LRU0", ">" + locCount.ToString("D2"));
							return ("next");
						}
						else
						{
							// Shut this state off
							setReadRunningState(false);
							//readPointsRunning = false;

							// Button color
							uiForm.btStartAccelRead.BackColor = System.Drawing.Color.DarkGreen;

							// Check for chain
							if (uiForm.cbChainAccelToGyro.Checked)
							{
								// Start Test cycle
								System.Threading.Thread.Sleep(3000);
								CalGyro.setBiasRunningSate(true);
								//return ("wait");
							}
							return ("end");
						}
					}

				case (int)READ_STATE.WAIT_POINT:
					{
						// See if value is back
						// TODO address sign
						if (!uiForm.lru0.returnReady)
						{
							return ("wait");
						}
						else
						{
							uiForm.dgAccelCalLru0Data.Rows.Add(uiForm.lru0.senBoardFbValF.ToString("00.00000"), "READ");

							readCount++;
							locCount++;

							// Loop back to next point
							currentState = (int)READ_STATE.READ_POINT;
							return ("other");
						}
					}
				default:
					{
						return ("end");
					}
			}

		}

		public static void clearAccelCalData()
		{

			// Set Accel Data to "unity"
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 0, 0);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 1, 1);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 2, -1);

			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 3, 0);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 4, 1);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 5, -1);

			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 6, 0);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 7, -1);
			uiForm.lru0.setCalWriteF(FLASH_LOC_ACCEL_CAL_START + 8, 1);

			uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
		}

	}
}


