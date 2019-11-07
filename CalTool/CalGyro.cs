using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CalTool
{
	class CalGyro
	{
		// Constants
		private const int SAMPLE_COUNT = 100;
		private const int FLASH_LOC_GYRO_CAL_START = 80;    // Start of cal table in sensor board flash memory
		private const int NUM_CAL_POINTS = 12;              // 3 Bias, 9 Scales
															//private const int SCALE_SWEEP_ANGLE = 60;
															//private const int SCALE_SWEEP_ANGLE = 90;
		private const int SCALE_SWEEP_ANGLE = 180;

		// State machine sates
		enum BIAS_STATE { SET_BIAS, WAIT_BIAS, GET_BIASX, GET_BIASY, GET_BIASZ, PROG_BIAS };
		//		enum SCALE_STATE { AHRS_RES, AHRS_WAIT, PREP_SCALE, SET_SCALE, WAIT_SCALE, GET_SCALE, END_SCALE };
		enum SCALE_STATE { SETUP, MOVE_START, WAIT_START, MOVE_END, WAIT_END, GET_SCALE, END_SCALE };
		enum PRG_STATE { PRG_SCALE };
		enum READ_STATE { READ_POINT, WAIT_POINT };
		enum CAL_POINT { BIASX, BIASY, BIASZ, XONX, XONY, XONZ, YONX, YONY, YONZ, ZONX, ZONY, ZONZ };

		//public static string[] gyroMovePoints = { "X0 Y-30 Z0", "X0 Y+30 Z0", "X0 Y0 Z-30", "X0 Y0 Z+30", "X-30 Y0 Z0", "X+30 Y0 Z0" }; // Roll, Pitch, Yaw
		//		public static string[] gyroMovePoints = { "X0 Y-45 Z0", "X0 Y+45 Z0", "X0 Y0 Z-45", "X0 Y0 Z+45", "X-45 Y0 Z0", "X+45 Y0 Z0" }; // Roll, Pitch, Yaw
		public static string[] gyroMovePoints = { "X0 Y-90 Z0", "X0 Y+90 Z0", "X0 Y0 Z-90", "X0 Y0 Z+90", "X-90 Y0 Z0", "X+90 Y0 Z0" }; // Roll, Pitch, Yaw

		//		public static string[] gyroMovePoints = { "Y-90", "Y+90" }; // Roll, Pitch, Yaw

		public static string[] movePointDesc = { "X BIAS", "Y BIAS", "Z BIAS", "X ON X", "X ON Y", "X ON Z", "Y ON X", "Y ON Y", "Y ON Z", "Z ON X", "Z ON Y", "Z ON Z" };

		// State variables
		static MainForm uiForm;
		private static bool biasPointsRunning = false;
		private static bool scalePointsRunning = false;
		private static bool prgPointsRunning = false;
		private static bool readPointsRunning = false;
		private static int currentState = 0;
		private static int sampleCount = 0;
		private static int loopCount = 0;
		private static int stableCount = 0;
		private static int scalePassNumber;

		// Public
		public static int writeCount;
		public static int readCount;
		private static int locCount;

		// Cal data
		public static double[] dataSample0 = new double[SAMPLE_COUNT];
		public static double[] dataSample1 = new double[SAMPLE_COUNT];

		public static double[] calData = new double[NUM_CAL_POINTS];

		public static double[] gyroDataPoint = new double[gyroMovePoints.Length];
		public static double xonx, xony, xonz, yonx, yony, yonz, zonx, zony, zonz;
		public static double deltaX, deltaY, deltaZ;


		// Accessors
		public static void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}

		// Start / Stop
		public static void setBiasRunningSate(bool run)
		{
			if (run)
			{
				// Start with gyro cal

				biasPointsRunning = true;
				scalePointsRunning = false;

				//biasPointsRunning = false;
				//scalePointsRunning = true;

				readPointsRunning = false;
				prgPointsRunning = false;

				// Initial values
				currentState = 0;
				calData[(int)CAL_POINT.BIASX] = 0;
				calData[(int)CAL_POINT.BIASY] = 0;
				calData[(int)CAL_POINT.BIASZ] = 0;
				calData[(int)CAL_POINT.XONX] = 1;
				calData[(int)CAL_POINT.XONY] = 0;
				calData[(int)CAL_POINT.XONZ] = 0;
				calData[(int)CAL_POINT.YONX] = 0;
				calData[(int)CAL_POINT.YONY] = 1;
				calData[(int)CAL_POINT.YONZ] = 0;
				calData[(int)CAL_POINT.ZONX] = 0;
				calData[(int)CAL_POINT.ZONY] = 0;
				calData[(int)CAL_POINT.ZONZ] = 1;

				// Button color
				uiForm.btStartGyroCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;

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
				scalePassNumber = 1;

				// Button color
				uiForm.btStartGyroCal.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;

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
				locCount = FLASH_LOC_GYRO_CAL_START;
				currentState = 0;
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = true;

				// Button color
				uiForm.btStartGyroProg.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartGyroProg.BackColor = System.Drawing.Color.Transparent;
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
				locCount = FLASH_LOC_GYRO_CAL_START;
				currentState = 0;
				readPointsRunning = true;
				scalePointsRunning = false;
				prgPointsRunning = false;
				biasPointsRunning = false;

				// Clear form table entries
				uiForm.dgGyroCalLru0Data.Rows.Clear();
				uiForm.dgGyroCalParam.Rows.Clear();

				//// Setup empty entries
				//for (int i = 0; i < BcaCalPoints.bcaCalPointsNum; i++)
				//{
				//	uiForm.dgGyroCalLru0Data.Rows.Add(0.ToString("00.00"), "PENDING");
				//}

				// Button color
				uiForm.btStartGyroRead.BackColor = System.Drawing.Color.Green;

			}
			else
			{
				// State
				biasPointsRunning = false;
				scalePointsRunning = false;
				readPointsRunning = false;
				prgPointsRunning = false;

				// Button color
				//uiForm.btStartGyroRead.BackColor = System.Drawing.Color.Transparent;
			}
		}




		// Get state
		public static bool getCalRunningState()
		{
			return biasPointsRunning || scalePointsRunning;
		}
		public static bool getPrgRunningState()
		{
			return prgPointsRunning;
		}

		private static void addTableEntry(string param, double value, string status)
		{

			// Add to cal data table
			uiForm.dgGyroCalParam.Rows.Add(param.ToString());
			uiForm.dgGyroCalLru0Data.Rows.Add(value.ToString("00.00000"), status);

			//Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
			//(dgv as DataGridView).Rows.Add(avPReading.Average().ToString("0000.00"), avSReading.Average().ToString("0000.00"), "MEASURED");
		}

		// State machine update
		public static void update()
		{
			string msg = "";


			//// Show data based on state
			//if ((currentState >= (int)CAL_BIAS.SET_ACCELX0) && (currentState <= (int)BIAS_STATE.GET_ACCELXN1) )
			//{
			//	uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELXR].ToString("00.00000");
			//}
			//if ((currentState >= (int)BIAS_STATE.SET_ACCELY0) && (currentState <= (int)BIAS_STATE.GET_ACCELYN1))
			//{
			//	uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELYR].ToString("00.00000");
			//}
			//if ((currentState >= (int)BIAS_STATE.SET_ACCELZ0) && (currentState <= (int)BIAS_STATE.GET_ACCELZN1))
			//{
			//	uiForm.btLru0ParmValue.Text = uiForm.lru0.dataParam[(int)PARAM.ACCELZR].ToString("00.00000");
			//}


			// Handle state
			if (biasPointsRunning)
			{
				msg = biasStateMachine();
			}
			else if (scalePointsRunning)
			{
				msg = scaleStateMachine();
			}
			else if (prgPointsRunning)
			{
				msg = prgPointsStateMachine();
			}
			else if (readPointsRunning)
			{
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
				biasPointsRunning = false;
				scalePointsRunning = false;
				prgPointsRunning = false;
				readPointsRunning = false;

				// Back to zero
				PosFixture.setPosition("X0 Y0 Z0");

				// Data
				uiForm.btLru0GyroParmName.Text = "Complete";
				uiForm.btLru0GyroParmValue.Text = "";

				// Button color
				//uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;
			}
		}



		private static string biasStateMachine()
		{
			int loop = 0;
			const int COM_DELAY = 200;  // Delay for communication

			switch (currentState)
			{

				//
				// Bias XYZ
				//
				case (int)BIAS_STATE.SET_BIAS:
					{
						uiForm.btLru0GyroParmName.Text = "Bias Values";
						uiForm.btLru0GyroParmValue.Text = "Set Position";
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROXR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROYR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROZR0, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROXR1, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROYR1, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROZR1, RATE.RATE_50HZ);
						PosFixture.setPosition("X0 Y0 Z0");

						// Clear bias values in unit to get raw readings without bias applied
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 0, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 1, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 2, 0);

						// Clear cross coupling only if requested
						if (!uiForm.cbSetUnityGain.Checked)
						{
							// Clear cross matrix if full calibration
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 3, 1.0);    // xonx
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 4, 0);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 5, 0);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 6, 0);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 7, 1.0);    // yony
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 8, 0);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 9, 0);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 10, 0);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 11, 1.0);   // zonz

						}
						uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
						return ("next");
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
							System.Threading.Thread.Sleep(1000);
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASX:
					{
						uiForm.btLru0GyroParmName.Text = "X Bias Value";
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROXR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROXR1];
							uiForm.btLru0GyroParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASX] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0GyroParmName.Text, calData[(int)CAL_POINT.BIASX], "MEASURE");
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASY:
					{
						uiForm.btLru0GyroParmName.Text = "Y Bias Value";
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROYR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROYR1];
							uiForm.btLru0GyroParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASY] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0GyroParmName.Text, calData[(int)CAL_POINT.BIASY], "MEASURE");
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASZ:
					{
						uiForm.btLru0GyroParmName.Text = "Z Bias Value";

						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample0[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROZR0];
							dataSample1[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROZR1];
							uiForm.btLru0GyroParmValue.Text = dataSample0[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASZ] = (dataSample0.Average() + dataSample1.Average()) / 2.0;
							addTableEntry(uiForm.btLru0GyroParmName.Text, calData[(int)CAL_POINT.BIASZ], "MEASURE");
							return ("next");
						}
					}
				case (int)BIAS_STATE.PROG_BIAS:
					{
						uiForm.btLru0GyroParmName.Text = "Program Bias XYZ";
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 0, calData[(int)CAL_POINT.BIASX]);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 1, calData[(int)CAL_POINT.BIASY]);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 2, calData[(int)CAL_POINT.BIASZ]);
						uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);

						// Start Scale if not bias only
						if (!uiForm.cbBiasCalOnly.Checked)
						{
							setScaleRunningSate(true);
						}
						biasPointsRunning = false;
						System.Threading.Thread.Sleep(500);
						return ("none");
					}


				default:
					{
						return ("end");
					}
			}
		}





		private static string scaleStateMachine()
		{

			switch (currentState)
			{
				case (int)SCALE_STATE.SETUP:
					{
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROXSUM, RATE.RATE_25HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROYSUM, RATE.RATE_25HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROZSUM, RATE.RATE_25HZ);
						return ("next");
					}
				case (int)SCALE_STATE.MOVE_START:
					{
						if (loopCount < gyroMovePoints.Length)
						{
							PosFixture.setPosition(gyroMovePoints[loopCount]);
							uiForm.btLru0GyroParmName.Text = gyroMovePoints[loopCount];
							System.Threading.Thread.Sleep(1000);
							return ("next");
						}
						else
						{
							// Exit scale calibration
							currentState = (int)SCALE_STATE.END_SCALE;
							return ("none");
						}
					}
				case (int)SCALE_STATE.WAIT_START:
					{
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							// Clear gyro sums
							uiForm.lru0.setEngWriteF(ENG.SCLR, 1.0);
							System.Threading.Thread.Sleep(2000);
							loopCount++;    // Next point
							return ("next");
						}
					}

				case (int)SCALE_STATE.MOVE_END:
					{
						if (loopCount < gyroMovePoints.Length)
						{
							PosFixture.setPosition(gyroMovePoints[loopCount]);
							uiForm.btLru0GyroParmName.Text = gyroMovePoints[loopCount];
							System.Threading.Thread.Sleep(500);
							return ("next");
						}
						else
						{
							// Exit scale calibration
							currentState = (int)SCALE_STATE.END_SCALE;
							return ("none");
						}
					}

				case (int)SCALE_STATE.WAIT_END:
					{
						uiForm.btLru0GyroParmValue.Text = "R:" + uiForm.lru0.dataParam[(int)PARAM.GYROXSUM].ToString("000.00") +
							" P:" + uiForm.lru0.dataParam[(int)PARAM.GYROYSUM].ToString("000.00") +
							" Y:" + uiForm.lru0.dataParam[(int)PARAM.GYROZSUM].ToString("000.00");
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							System.Threading.Thread.Sleep(500);
							return ("next");
						}
					}

				case (int)SCALE_STATE.GET_SCALE:
					{

						switch (loopCount)
						{
							// X Effect (Roll)
							case 1:
								System.Threading.Thread.Sleep(200);
								deltaX = uiForm.lru0.dataParam[(int)PARAM.GYROXSUM];
								deltaY = uiForm.lru0.dataParam[(int)PARAM.GYROYSUM];
								deltaZ = uiForm.lru0.dataParam[(int)PARAM.GYROZSUM];
								xonx = (1.0 / (deltaX / SCALE_SWEEP_ANGLE));
								xony = (deltaY / SCALE_SWEEP_ANGLE);
								xonz = (deltaZ / SCALE_SWEEP_ANGLE);
								break;

							// Y Effect (Pitch)
							case 3:
								System.Threading.Thread.Sleep(200);
								deltaX = uiForm.lru0.dataParam[(int)PARAM.GYROXSUM];
								deltaY = uiForm.lru0.dataParam[(int)PARAM.GYROYSUM];
								deltaZ = uiForm.lru0.dataParam[(int)PARAM.GYROZSUM];
								yonx = (deltaX / SCALE_SWEEP_ANGLE);
								yony = (1.0 / (deltaY / SCALE_SWEEP_ANGLE));
								yonz = (deltaZ / SCALE_SWEEP_ANGLE);
								break;

							// Z Effect (Yaw)
							case 5:
								System.Threading.Thread.Sleep(200);
								deltaX = uiForm.lru0.dataParam[(int)PARAM.GYROXSUM];
								deltaY = uiForm.lru0.dataParam[(int)PARAM.GYROYSUM];
								deltaZ = uiForm.lru0.dataParam[(int)PARAM.GYROZSUM];
								zonx = (deltaX / SCALE_SWEEP_ANGLE);
								zony = (deltaY / SCALE_SWEEP_ANGLE);
								zonz = (1.0 / (deltaZ / SCALE_SWEEP_ANGLE));
								break;
						}

						loopCount++;
						currentState = (int)SCALE_STATE.MOVE_START;
						return ("none");
					}

				case (int)SCALE_STATE.END_SCALE:
					{
						PosFixture.setPosition("X0 Y0 Z0");

						// Start Program cycle
						setPrgRunningState(true);
						return ("wait");

					}
				default:
					{
						return ("end");
					}

			}
		}



		private static string prgPointsStateMachine()
		{
			const int COM_DELAY = 200;  // Delay for communication

			switch (currentState)
			{
				case (int)PRG_STATE.PRG_SCALE:
					{
						uiForm.btLru0GyroParmName.Text = "Program Scales";

						//// TEST FORCE VALUES
						//xony = 0;
						//xonz = 0;
						//yonx = 0;
						//yonz = 0;
						//zonx = 0;
						//zony = 0;


						// Polarity flipped to match gyro outputs
						uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 3, xonx);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 4, xony);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 5, xonz);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 6, -yonx);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 7, yony);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 8, yonz);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 9, -zonx);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 10, zony);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 11, zonz);
						uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
					}

					// End
					prgPointsRunning = false;

					// Button color
					uiForm.btStartGyroProg.BackColor = System.Drawing.Color.DarkGreen;

					// Start Read cycle
					setReadRunningState(true);
					return ("wait");

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
							return ("next");
						}
						else
						{
							// Shut this state off
							//readPointsRunning = false;
							CalGyro.setReadRunningState(false);

							// Button color
							uiForm.btStartGyroRead.BackColor = System.Drawing.Color.DarkGreen;

							// Check for chain
							if (uiForm.cbChainGyroToAtp.Checked)
							{
								// Start Test cycle
								AtpGyro.setAhrsAtpRunningSate(true);
//								return ("wait");
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

							addTableEntry(movePointDesc[readCount], uiForm.lru0.senBoardFbValF, "READ");
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



	}
}


