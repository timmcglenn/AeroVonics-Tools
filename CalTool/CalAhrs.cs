using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalTool
{
	class CalAhrs
	{
		// Constants
		private const int SAMPLE_COUNT = 200;

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


		// State variables
		static MainForm uiForm;
		public static bool calAccelRunning = false;
		public static bool calGyroRunning = false;
		public static bool prgPointsRunning = false;
		public static bool readPointsRunning = false;
		private static int currentState = 0;
		private static int sampleCount = 0;

		// Cal data
		private static double axz, axp, axn, ayz, ayp, ayn, azz, azp, azn;
		public static double[] dataSample = new double[SAMPLE_COUNT];

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
				calAccelRunning = true;
				calGyroRunning = false;

				// Initial values
				axz = 0;
				axp = 1;
				axn = -1;
				ayz = 0;
				ayp = 1;
				ayn = -1;
				azz = 0;
				azp = 1;
				azn = -1;

				// Button color
				uiForm.btStartAccelCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// Shutdown state
				calAccelRunning = false;
				calGyroRunning = false;

				// Button color
				uiForm.btStartAccelCal.BackColor = System.Drawing.Color.DimGray;

				// Move home
				PosFixture.setPosition("X0 Y0 Z0");

			}
		}

		public static void setPrgRunningState(bool run)
		{

		}

		// Get state
		public static bool getCalRunningState()
		{
			return calGyroRunning | calAccelRunning;
		}


		private static void addTableEntry(string param, double value)
		{
			
			// Add to cal data table
			uiForm.dgAhrsCalParam.Rows.Add(param.ToString());
			uiForm.dgAhrsCalLru0Data.Rows.Add(value.ToString("00.00000"));

			//Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
			//(dgv as DataGridView).Rows.Add(avPReading.Average().ToString("0000.00"), avSReading.Average().ToString("0000.00"), "MEASURED");
		}

		// State machine update
		public static void update()
		{
			string msg = "";


			// Show data based on state
			if ((currentState >= (int)CAL_STATE.SET_ACCELX0) && (currentState <= (int)CAL_STATE.GET_ACCELXN1) )
			{
				uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELXR].ToString("00.00000");
			}
			if ((currentState >= (int)CAL_STATE.SET_ACCELY0) && (currentState <= (int)CAL_STATE.GET_ACCELYN1))
			{
				uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELYR].ToString("00.00000");
			}
			if ((currentState >= (int)CAL_STATE.SET_ACCELZ0) && (currentState <= (int)CAL_STATE.GET_ACCELZN1))
			{
				uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELZR].ToString("00.00000");
			}


			// Handle state
			if (calAccelRunning)
			{
				// General field updates
				uiForm.bADCTestPointNum.Text = (BcaCalPoints.currentCalPoint + 1).ToString() + " OF " + BcaCalPoints.bcaCalPoint.Length.ToString();

				// Accel cal points
				msg = accelStateMachine();
			}

			else
			{
				//// Idle data
				//try
				//{
				//	uiForm.lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_50HZ);
				//	uiForm.lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_50HZ);
				//}
				//catch
				//{
				//}

				//// LRU Roll Pitch values
				//uiForm.btLru0ParmName.Text = uiForm.lru0.dataParam[(int)PARAM.ROLL].ToString("000.00");
				//uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.PITCH].ToString("00.00");

			}




			//if (PosFixture.getInHomeMotion())
			//{
			//	uiForm.btHomeFixture.BackColor = System.Drawing.Color.Red;
			//}
			//else
			//{
			//	uiForm.btHomeFixture.BackColor = System.Drawing.Color.Transparent;

			//}
			// Get current state from running SM
			//if (calGyroRunning)
			//{
			//	// General field updates
			//	//// Gyro raw rates
			//	//uiForm.btGyroXRate.Text = uiForm.lru0.dataParam[(int)PARAM.GYROXR].ToString("0000.00");
			//	//uiForm.btGyroYRate.Text = uiForm.lru0.dataParam[(int)PARAM.GYROYR].ToString("0000.00");
			//	//uiForm.btGyroZRate.Text = uiForm.lru0.dataParam[(int)PARAM.GYROZR].ToString("0000.00");

			//	msg = gyroCalstateMachine();
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
				calAccelRunning = false;
				calGyroRunning = false;
				prgPointsRunning = false;
				readPointsRunning = false;

				// Back to zero
				PosFixture.setPosition("X0 Y0 Z0");

				// Data
				uiForm.btLru0ParmName.Text = "Complete";
				uiForm.btLru0ParmValue.Text = "";

				// Button color
				uiForm.btStartAccelCal.BackColor = System.Drawing.Color.DimGray;
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
						uiForm.lru0.setParameterReq((int)PARAM.ACCELXR, RATE.RATE_50HZ);
						uiForm.btLru0ParmName.Text = "Accel X Zero";
						PosFixture.setPosition("X10 Y0 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELX0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELXR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							axz = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELXP1:
					{
						uiForm.btLru0ParmName.Text = "Accel X Pos";
						PosFixture.setPosition("X0 Y0 Z-90");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELXP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELXR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							axp = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELXN1:
					{
						uiForm.btLru0ParmName.Text = "Accel X Neg";
						PosFixture.setPosition("X0 Y0 Z+90");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELXN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELXR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							axn = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}



				//
				// Accel Y
				//
				case (int)CAL_STATE.SET_ACCELY0:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELYR, RATE.RATE_50HZ);
						uiForm.btLru0ParmName.Text = "Accel Y Zero";

						PosFixture.setPosition("X0 Y0 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELY0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELYR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							ayz = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELYP1:
					{
						uiForm.btLru0ParmName.Text = "Accel Y Pos";
						PosFixture.setPosition("X0 Y90 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELYP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELYR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							ayp = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELYN1:
					{
						uiForm.btLru0ParmName.Text = "Accel Y Neg";
						PosFixture.setPosition("X0 Y-90 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELYN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELYR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							ayn = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}



				//
				// Accel Z
				//
				case (int)CAL_STATE.SET_ACCELZ0:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ACCELZR, RATE.RATE_50HZ);
						uiForm.btLru0ParmName.Text = "Accel Z Zero";

						PosFixture.setPosition("X0 Y90 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELZ0:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELZR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							azz = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELZP1:
					{
						uiForm.btLru0ParmName.Text = "Accel Z Pos";
						PosFixture.setPosition("X0 Y0 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELZP1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELZR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							azp = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}
				case (int)CAL_STATE.SET_ACCELZN1:
					{
						uiForm.btLru0ParmName.Text = "Accel Z Neg";
						PosFixture.setPosition("X0 Y180 Z0");
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
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)CAL_STATE.GET_ACCELZN1:
					{
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.ACCELZR];
							sampleCount++;
							return ("wait");
						}
						else
						{
							azn = dataSample.Average();
							addTableEntry(uiForm.btLru0ParmName.Text, dataSample.Average());
							return ("next");
						}
					}



				default:
					{
						return ("end");
					}

			}

		}



	}
}


