using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CalTool
{
	class AtpGyro
	{
		// Constants
		private const int SAMPLE_COUNT = 5;
		private const double TEST_TOL = 1.0;

		// State machine sates
		enum ATP_STATE { AHRS_RES, AHRS_WAIT, AHRS_PREP, SET_POSITION, WAIT_POSITION, GET_POSITION, SET_ZERO, WAIT_ZERO, END_ATP };
		public static string[] atpMovePoints = { "X0 Y+30 Z0", "X0 Y-30 Z0", "X0 Y0 Z+30", "X0 Y0 Z-30", "X+30 Y0 Z0", "X-30 Y0 Z0" };
		public static string[] atpMovePointsDesc = { "+30 ROLL", "-30 ROLL", "+30 PITCH", "-30 PITCH", "+30 YAW", "-30 YAW" };
		public static double[] atpMoveValue = { 30.0, -30, 30, -30, 30, -30 };

		// State variables
		static MainForm uiForm;
		public static bool atpPointsRunning = false;
		private static int currentState = 0;
		private static int sampleCount = 0;
		private static int loopCount = 0;
		private static int stableCount = 0;
		private static double iRoll, iPitch, iYaw;

		// Cal data
		public static double roll, pitch, yaw;
		public static double[] dataSample = new double[SAMPLE_COUNT];
		public static double[] atpDataPoint = new double[atpMovePoints.Length];

		// Accessors
		public static void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}

		// Start / Stop
		public static void setAhrsAtpRunningSate(bool run)
		{
			if (run)
			{
				atpPointsRunning = true;
				uiForm.btStartAhrsAtp.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				atpPointsRunning = false;
				//uiForm.btStartAhrsAtp.BackColor = System.Drawing.Color.DimGray;
				PosFixture.setPosition("X0 Y0 Z0");

			}
		}


		// Table entry
		private static void addTableEntry(string param, string actual, string rollError, string pitchError, string yawError, string passFail)
		{

			// Add to data table
			uiForm.dgAtpParam.Rows.Add(param.ToString());
			uiForm.dgAhrsAtpLru0Data.Rows.Add(actual, rollError, pitchError, yawError, passFail);
		}

		// State machine update
		public static void update()
		{
			string msg = "";

			// Handle state
			if (atpPointsRunning)
			{
				msg = atpStateMachine();
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
				atpPointsRunning = false;

				// Back to zero
				PosFixture.setPosition("X0 Y0 Z0");

				//// Data
				//uiForm.btAhrsAtpParmName.Text = "Complete";
				//uiForm.btLru0AhrsAtpParmValue.Text = "";

				// Button color
				//uiForm.btStartAhrsAtp.BackColor = System.Drawing.Color.DimGray;
			}
		}




		private static string atpStateMachine()
		{
			switch (currentState)
			{
				case (int)ATP_STATE.AHRS_RES:
					{
						PosFixture.setPosition("X0 Y0 Z0");
						//uiForm.btAhrsAtpParmName.Text = "AHRS Reset";
						//uiForm.btLru0AhrsAtpParmValue.Text = "AHRS Reset";
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
				case (int)ATP_STATE.AHRS_WAIT:
					{
						double weight = uiForm.lru0.dataParam[(int)PARAM.RPYWEIGHT];
						//uiForm.btLru0AhrsAtpParmValue.Text = weight.ToString("00");
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
				case (int)ATP_STATE.AHRS_PREP:
					{
						//uiForm.btAhrsAtpParmName.Text = "Scale Test Points";
						//uiForm.btLru0AhrsAtpParmValue.Text = "Set Position";
						uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
						uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
						uiForm.lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_50HZ);
						uiForm.lru0.setParameterReq((int)PARAM.YAW, RATE.RATE_50HZ);
						loopCount = 0;

						// Wait for serial data to start and get parsed
						Thread.Sleep(2000);

						return ("next");
					}

				case (int)ATP_STATE.SET_POSITION:
					{
						if (loopCount < atpMovePoints.Length)
						{
							// Put into free gyro mode
							uiForm.lru0.setEngWriteF(ENG.FRGM, 1.0);

							// Get initial values
							iRoll = uiForm.lru0.dataParam[(int)PARAM.ROLL];
							iPitch = uiForm.lru0.dataParam[(int)PARAM.PITCH];
							iYaw = uiForm.lru0.dataParam[(int)PARAM.YAW];


							PosFixture.setPosition(atpMovePoints[loopCount]);
							//uiForm.btAhrsAtpParmName.Text = atpMovePointsDesc[loopCount];
							sampleCount = 0;
							return ("next");
						}
						else
						{
							currentState = (int)ATP_STATE.END_ATP;
							return ("none");
						}
					}

				case (int)ATP_STATE.WAIT_POSITION:
					{
						//uiForm.btLru0AhrsAtpParmValue.Text = "R:" + uiForm.lru0.dataParam[(int)PARAM.ROLL].ToString("00.00") +
						//	" P:" + uiForm.lru0.dataParam[(int)PARAM.PITCH].ToString("00.00") +
						//	" Y:" + uiForm.lru0.dataParam[(int)PARAM.YAW].ToString("00.00");
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							// Wait for full motion to stop and get readings
							if (sampleCount++ > 50)
							{
								return ("next");
							}
							else
							{
								return ("wait");
							}
						}
					}

				case (int)ATP_STATE.GET_POSITION:
					{

						roll = uiForm.lru0.dataParam[(int)PARAM.ROLL];
						pitch = uiForm.lru0.dataParam[(int)PARAM.PITCH];
						yaw = uiForm.lru0.dataParam[(int)PARAM.YAW];

						double rollError = 10, pitchError = 10, yawError = 10, testValue = 0;
						switch (loopCount)
						{
							// Roll +
							case 0:
								testValue = roll;
								rollError = roll - iRoll - atpMoveValue[loopCount];
								pitchError = pitch - iPitch;
								yawError = yaw - iYaw;
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
							// Roll -
							case 1:
								testValue = roll;
								rollError = roll -iRoll - atpMoveValue[loopCount];
								pitchError = pitch - iPitch;
								yawError = yaw - iYaw;
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
							// Pitch +
							case 2:
								testValue = pitch;
								rollError = roll - iRoll;
								pitchError = pitch - iPitch - atpMoveValue[loopCount];
								yawError = yaw - iYaw;
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
							// Pitch -
							case 3:
								testValue = pitch;
								rollError = roll - iRoll;
								pitchError = pitch - iPitch - atpMoveValue[loopCount];
								yawError = yaw - iYaw;
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
							// Yaw +
							case 4:
								testValue = yaw;
								rollError = roll - iRoll;
								pitchError = pitch - iPitch;
								yawError = yaw - iYaw - atpMoveValue[loopCount];
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
							// Yaw -
							case 5:
								testValue = yaw;
								rollError = roll - iRoll;
								pitchError = pitch - iPitch;
								yawError = yaw - iYaw - atpMoveValue[loopCount];
								if (yawError > 180) yawError -= 360;
								if (yawError < -180) yawError += 360;
								break;
						}

						//switch (loopCount)
						//{
						//	case 0: // + Roll
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.ROLL];
						//		break;
						//	case 1: // - Roll
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.ROLL];
						//		break;
						//	case 2: // + Pitch
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.PITCH];
						//		break;
						//	case 3: // - Pitch
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.PITCH];
						//		break;
						//	case 4: // + Yaw
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.YAW];
						//		break;
						//	case 5: // - Yaw
						//		atpDataPoint[loopCount] = uiForm.lru0.dataParam[(int)PARAM.YAW];
						//		break;
						//}

						string passFail;
						if ((Math.Abs(rollError) > TEST_TOL) || (Math.Abs(pitchError) > TEST_TOL) || (Math.Abs(yawError) > TEST_TOL))
						{
							passFail = "FAIL";
						}
						else
						{
							passFail = "PASS";
						}
						addTableEntry(atpMovePointsDesc[loopCount], testValue.ToString("00.00"), rollError.ToString("0.00"), pitchError.ToString("0.00"), yawError.ToString("0.00"), passFail);

						loopCount++;
						return ("next");
					}

				case (int)ATP_STATE.SET_ZERO:
					{
						// Put into slaving mode mode
						uiForm.lru0.setEngWriteF(ENG.FRGM, 0.0);

						PosFixture.setPosition("X0 Y0 Z0");
						sampleCount = 0;
						return ("next");
					}


				case (int)ATP_STATE.WAIT_ZERO:
					{
						//uiForm.btLru0AhrsAtpParmValue.Text = "R:" + uiForm.lru0.dataParam[(int)PARAM.ROLL].ToString("00.00") +
						//	" P:" + uiForm.lru0.dataParam[(int)PARAM.PITCH].ToString("00.00") +
						//	" Y:" + uiForm.lru0.dataParam[(int)PARAM.YAW].ToString("00.00");
						if (PosFixture.getInMotion())
						{
							return ("wait");
						}
						else
						{
							// Hold position to re-zero - let some align occur
							if (sampleCount++ > 200)
							{
								// Move to next test
								currentState = (int)ATP_STATE.SET_POSITION;
								return ("none");
							}
							else
							{
								return ("wait");
							}
						}
					}



				case (int)ATP_STATE.END_ATP:
					{

						PosFixture.setPosition("X0 Y0 Z0");
						//// Check for chain
						//if (uiForm.cbChainGyrolCalToPrg.Checked)
						//{
						//	// Start Program cycle
						//	setPrgRunningState(true);
						//	return ("wait");
						//}
						return ("end");
					}
				default:
					{
						return ("end");
					}

			}
		}




	}
}


