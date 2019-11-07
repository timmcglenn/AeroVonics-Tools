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
//		private const int SCALE_SWEEP_ANGLE = 180;
		private const int SCALE_SWEEP_ANGLE = 90;

		// State machine sates
		enum BIAS_STATE { SET_BIAS, WAIT_BIAS, GET_BIASX, GET_BIASY, GET_BIASZ, PROG_BIAS };
		enum SCALE_STATE { AHRS_RES, AHRS_WAIT, PREP_SCALE, SET_SCALE, WAIT_SCALE, GET_SCALE, END_SCALE };
		enum PRG_STATE { PRG_SCALE };
		enum READ_STATE { READ_POINT, WAIT_POINT };
		enum CAL_POINT { BIASX, BIASY, BIASZ, XONX, XONY, XONZ, YONX, YONY, YONZ, ZONX, ZONY, ZONZ };

//		public static string[] gyroMovePoints = { "X0 Y-90 Z0", "X0 Y+90 Z0", "X0 Y0 Z-90", "X0 Y0 Z+90", "X-90 Y0 Z0", "X+90 Y0 Z0" }; // Roll, Pitch, Yaw
		public static string[] gyroMovePoints = { "X0 Y-45 Z0", "X0 Y+45 Z0", "X0 Y0 Z-45", "X0 Y0 Z+45", "X-45 Y0 Z0", "X+45 Y0 Z0" }; // Roll, Pitch, Yaw

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
		public static double[] dataSample = new double[SAMPLE_COUNT];
		public static double[] calData = new double[NUM_CAL_POINTS];
		public static double[] gyroDataPoint = new double[gyroMovePoints.Length];
		public static double xonx0, xony0, xonz0, yonx0, yony0, yonz0, zonx0, zony0, zonz0;
		public static double xonx1, xony1, xonz1, yonx1, yony1, yonz1, zonx1, zony1, zonz1;
		public static double xonx2, xony2, xonz2, yonx2, yony2, yonz2, zonx2, zony2, zonz2;


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
				uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;

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
				uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;

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
				uiForm.btStartGyroProg.BackColor = System.Drawing.Color.Transparent;
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
				uiForm.btStartGyroRead.BackColor = System.Drawing.Color.Transparent;
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
				uiForm.btStartGyroCal.BackColor = System.Drawing.Color.DimGray;
			}
		}



		private static string biasStateMachine()
		{
			int loop = 0;

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
						uiForm.lru0.setParameterReq((int)PARAM.GYROXR, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROYR, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.GYROZR, RATE.RATE_50HZ);
						PosFixture.setPosition("X0 Y0 Z0");

						// Clear bias values in unit to get raw readings without bias applied
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 0, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 1, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 2, 0);

						// Clear cross matrix
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 3, 1.0);    // xonx
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 4, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 5, 0);

						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 6, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 7, 1.0);    // yony
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 8, 0);

						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 9, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 10, 0);
						uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 11, 1.0);   // zonz

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
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASX:
					{
						uiForm.btLru0GyroParmName.Text = "X Bias Value";
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROXR];
							uiForm.btLru0GyroParmValue.Text = dataSample[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASX] = dataSample.Average();
							addTableEntry(uiForm.btLru0GyroParmName.Text, dataSample.Average(), "MEASURE");
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASY:
					{
						uiForm.btLru0GyroParmName.Text = "Y Bias Value";
						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROYR];
							uiForm.btLru0GyroParmValue.Text = dataSample[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASY] = dataSample.Average();
							addTableEntry(uiForm.btLru0GyroParmName.Text, dataSample.Average(), "MEASURE");
							sampleCount = 0;
							return ("next");
						}
					}
				case (int)BIAS_STATE.GET_BIASZ:
					{
						uiForm.btLru0GyroParmName.Text = "Z Bias Value";

						if (sampleCount < SAMPLE_COUNT)
						{
							dataSample[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.GYROZR];
							uiForm.btLru0GyroParmValue.Text = dataSample[sampleCount].ToString("00.00000");
							sampleCount++;
							return ("wait");
						}
						else
						{
							calData[(int)CAL_POINT.BIASZ] = dataSample.Average();
							addTableEntry(uiForm.btLru0GyroParmName.Text, dataSample.Average(), "MEASURE");
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

						// Start Scale
						setScaleRunningSate(true);
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
				case (int)SCALE_STATE.AHRS_RES:
					{
						PosFixture.setPosition("X0 Y0 Z0");
						uiForm.btLru0GyroParmName.Text = "AHRS Reset";
						uiForm.btLru0GyroParmValue.Text = "AHRS Reset";
						// Put into slaving mode
						uiForm.lru0.setEngWriteF(ENG.FRGM, 0.0);
						// Reset AHRS
						uiForm.lru0.setEngWriteF(ENG.ARES, 1.0);
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
						uiForm.lru0.setParameterReq((int)PARAM.RPYWEIGHT, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.BIASWEIGHT, RATE.RATE_50HZ);
						loopCount = 0;
						stableCount = 0;
						Thread.Sleep(1000);
						return ("next");
					}
				case (int)SCALE_STATE.AHRS_WAIT:
					{
						double weight = uiForm.lru0.dataParam[(int)PARAM.RPYWEIGHT];
						uiForm.btLru0GyroParmValue.Text = weight.ToString("00");
						if (((int)uiForm.lru0.dataParam[(int)PARAM.STATUS] & STATUS.AHRS_STABLE) != 0)
						{
							if (stableCount < 100)
							{
								stableCount++;
								return ("wait");
							}
							else
							{
								return ("next");
							}
						}
						else
						{
							return ("wait");
						}
					}
				case (int)SCALE_STATE.PREP_SCALE:
					{
						uiForm.btLru0GyroParmName.Text = "Scale Test Points";
						uiForm.btLru0GyroParmValue.Text = "Set Position";
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.YAW, RATE.RATE_50HZ);
						loopCount = 0;

						// Put into free gyro mode
						uiForm.lru0.setEngWriteF(ENG.FRGM, 1.0);

						return ("next");
					}

				case (int)SCALE_STATE.SET_SCALE:
					{
						if (loopCount < gyroMovePoints.Length)
						{
							PosFixture.setPosition(gyroMovePoints[loopCount]);
							uiForm.btLru0GyroParmName.Text = gyroMovePoints[loopCount];
							sampleCount = 0;
							return ("next");
						}
						else
						{
							currentState = (int)SCALE_STATE.END_SCALE;
							return ("none");
						}
					}

				case (int)SCALE_STATE.WAIT_SCALE:
					{
						uiForm.btLru0GyroParmValue.Text = "R:" + uiForm.lru0.dataParam[(int)PARAM.ROLL].ToString("00.00") +
							" P:" + uiForm.lru0.dataParam[(int)PARAM.PITCH].ToString("00.00") +
							" Y:" + uiForm.lru0.dataParam[(int)PARAM.YAW].ToString("00.00");
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							// Wait for full motion to stop and get readings
							if (sampleCount++ > 5)
							{
								return ("next");
							}
							else
							{
								return ("wait");
							}
						}
					}

				case (int)SCALE_STATE.GET_SCALE:
					{

						switch (loopCount)
						{
							// X Effect (Roll)
							case 0:
								xonx0 = -uiForm.lru0.dataParam[(int)PARAM.ROLL];
								xony0 = -uiForm.lru0.dataParam[(int)PARAM.PITCH];
								xonz0 = -uiForm.lru0.dataParam[(int)PARAM.YAW];
								break;
							case 1:
								if (scalePassNumber == 1)
								{
									xonx1 = 1.0 / ((xonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									xony1 = ((xony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE);
									xonz1 = ((xonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE);
									addTableEntry("X on X 1", xonx1, "MEASURE");
									addTableEntry("X on Y 1", xony1, "MEASURE");
									addTableEntry("X on Z 1", xonz1, "MEASURE");
								}
								if (scalePassNumber == 2)
								{
									xonx2 = 1.0 / ((xonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									xony2 = ((xony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE);
									xonz2 = ((xonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE);
									addTableEntry("X on X 2", xonx2, "MEASURE");
									addTableEntry("X on Y 2", xony2, "MEASURE");
									addTableEntry("X on Z 2", xonz2, "MEASURE");
								}
								PosFixture.setPosition("X0 Y0 Z0");
								break;

							// Y Effect (Pitch)
							case 2:
								yonx0 = -uiForm.lru0.dataParam[(int)PARAM.ROLL];
								yony0 = -uiForm.lru0.dataParam[(int)PARAM.PITCH];
								yonz0 = -uiForm.lru0.dataParam[(int)PARAM.YAW];
								break;
							case 3:
								if (scalePassNumber == 1)
								{
									yonx1 = ((yonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									yony1 = 1.0 / ((yony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE);
									yonz1 = ((yonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE); //-
									addTableEntry("Y on X 1", yonx1, "MEASURE");
									addTableEntry("Y on Y 1", yony1, "MEASURE");
									addTableEntry("Y on Z 1", yonz1, "MEASURE");
								}
								if (scalePassNumber == 2)
								{
									yonx2 = ((yonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									yony2 = 1.0 / ((yony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE);
									yonz2 = ((yonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE); //-
									addTableEntry("Y on X 2", yonx2, "MEASURE");
									addTableEntry("Y on Y 2", yony2, "MEASURE");
									addTableEntry("Y on Z 2", yonz2, "MEASURE");
								}

								PosFixture.setPosition("X0 Y0 Z0");
								break;

							// Z Effect (Yaw)
							case 4:
								// Capture roll left
								zonx0 = -uiForm.lru0.dataParam[(int)PARAM.ROLL];
								zony0 = -uiForm.lru0.dataParam[(int)PARAM.PITCH];
								zonz0 = -uiForm.lru0.dataParam[(int)PARAM.YAW];
								break;
							case 5:
								if (scalePassNumber == 1)
								{
									zonx1 = ((zonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									zony1 = ((zony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE); //-
									zonz1 = 1.0 / ((zonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE);
									addTableEntry("Z on X 1", zonx1, "MEASURE");
									addTableEntry("Z on Y 1", zony1, "MEASURE");
									addTableEntry("Z on Z 1", zonz1, "MEASURE");
								}
								if (scalePassNumber == 2)
								{
									zonx2 = ((zonx0 + uiForm.lru0.dataParam[(int)PARAM.ROLL]) / SCALE_SWEEP_ANGLE);
									zony2 = ((zony0 + uiForm.lru0.dataParam[(int)PARAM.PITCH]) / SCALE_SWEEP_ANGLE); //-
									zonz2 = 1.0 / ((zonz0 + uiForm.lru0.dataParam[(int)PARAM.YAW]) / SCALE_SWEEP_ANGLE);
									addTableEntry("Z on X 2", zonx2, "MEASURE");
									addTableEntry("Z on Y 2", zony2, "MEASURE");
									addTableEntry("Z on Z 2", zonz2, "MEASURE");
								}
								PosFixture.setPosition("X0 Y0 Z0");
								break;

						}

						loopCount++;
						currentState = (int)SCALE_STATE.SET_SCALE;
						return ("none");
					}

				case (int)SCALE_STATE.END_SCALE:
					{
						// Put back into slave mode
						uiForm.lru0.setEngWriteF(ENG.FRGM, 0.0);
						PosFixture.setPosition("X0 Y0 Z0");

						// Check for chain
						if (uiForm.cbChainGyrolCalToPrg.Checked)
						{
							// Start Program cycle
							setPrgRunningState(true);
							return ("wait");
						}
						return ("end");
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
				case (int)PRG_STATE.PRG_SCALE:
					{
						uiForm.btLru0GyroParmName.Text = "Program Scales";

						if (scalePassNumber == 1)
						{
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 3, xonx1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 4, xony1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 5, xonz1);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 6, yonx1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 7, yony1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 8, yonz1);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 9, zonx1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 10, zony1);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 11, zonz1);

							uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
						}
						if (scalePassNumber == 2)
						{
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 3, (xonx1));
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 4, xony1 + xony2);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 5, xonz1 + xonz2);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 6, yonx1 + yonx2);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 7, (yony1));
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 8, yonz1 + yonz2);

							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 9, zonx1 + zonx2);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 10, zony1 + zony2);
							uiForm.lru0.setCalWriteF(FLASH_LOC_GYRO_CAL_START + 11, (zonz1));

							uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
						}
						
						// End
						prgPointsRunning = false;
						
						// Button color
						uiForm.btStartGyroProg.BackColor = System.Drawing.Color.DarkGreen;

						// Second scale pass - go back to scale, but set counter 
						if (scalePassNumber == 1)
						{
							addTableEntry("SCALE 2", 0, "");
							setScaleRunningSate(true);
							scalePassNumber = 2;
							return ("wait");
						}

						// Check for chain
						if (uiForm.cbChainGyroPrgToRead.Checked)
						{
							// Start Read cycle
							setReadRunningState(true);
							return ("wait");
						}
						else
						{
							return ("end");
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
							return ("next");
						}
						else
						{
							// Shut this state off
							readPointsRunning = false;
							// Button color
							uiForm.btStartGyroRead.BackColor = System.Drawing.Color.DarkGreen;
							//// Check for chain
							//if (uiForm.cbChainReadToTest.Checked)
							//{
							//	// Start Test cycle
							//	AtpAdc.setAtpBcaRunningSate(true);
							//	return ("wait");
							//}
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


