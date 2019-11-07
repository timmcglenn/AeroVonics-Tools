using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalTool
{
	class MopsTestPoints
	{
		// ALT TSO
		public static double[] mopsBcaTestPoint = { -950.0, 0.0, 500, 1000.0, 1500, 2000, 3000, 4000, 6000, 8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000, 24500 };
		public static double[] mopsBcaTolerance = { 20, 20, 20, 20, 25, 30, 30, 35, 40, 60, 80, 90, 100, 110, 120, 130, 140, 155 };

		public static bool[] mopsBcaTestPassFail = new bool[mopsBcaTestPoint.Length];
		public static double[] mopsBcaTestError = new double[mopsBcaTestPoint.Length];

		// IAS TSO (Forward)
		public static double[] mopsIasTestPoint = { 45, 50, 60, 70, 80, 90, 100, 120, 140, 160, 180, 200, 220, 250, 290, 250, 220, 200, 180, 160, 140, 120, 100, 90, 80, 70, 60, 50, 45 };
		public static double[] mopsIasTolerance = { 5, 5, 5, 4, 4, 4, 3, 3, 3, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 };

		//// IAS TSO (Reverse)
		//public static double[] mopsIasTestPoint = { 290, 250, 220, 200, 180, 160, 140, 120, 100, 90, 80, 70, 60, 50, 40 };
		//public static double[] mopsIasTolerance = { 5, 5, 5, 5, 5, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 };

		public static bool[] mopsIasTestPassFail = new bool[mopsIasTestPoint.Length];
		public static double[] mopsIasTestError = new double[mopsIasTestPoint.Length];

	}

	class Mops
	{

		// State machine sates
		enum ATP_STATE { SET_TEST_POINT, WAIT_TEST_POINT, GET_DATA };

		// Constants
		private const int SAMPLE_COUNT = 30;
//		private const int IAS_ALT_POINT = 0;  // Test at sea level
		private const int IAS_ALT_POINT = 5000;

		// State variables
		static MainForm uiForm;
		static bool mopsBcaPointsRunning = false;
		static bool mopsIasPointsRunning = false;
		static int currentState = 0;
		static int currentTestPoint = 0;
		public static int sampleCount;
		static double[] avReading = new double[SAMPLE_COUNT];
		static Control cnt;

		// Accessors
		public static void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}

		// Test Start / Stop
		public static void setMopsAtpBcaRunningSate(bool run)
		{
			mopsBcaPointsRunning = run;

			if (run)
			{

				// Start at beginning of table
				currentState = 0;
				currentTestPoint = 0;

				// Clear data grid view entries
				uiForm.dgMopsAdcTestPoints.Rows.Clear();
				uiForm.dgMopsAdcTestPoints.Refresh();

				// Show BCA Test Points
				for (int i = 0; i < MopsTestPoints.mopsBcaTestPoint.Length; i++)
				{
					uiForm.dgMopsAdcTestPoints.Rows.Add(MopsTestPoints.mopsBcaTestPoint[i].ToString(), MopsTestPoints.mopsBcaTolerance[i].ToString());
				}

				// Button color
				uiForm.btMopsBcaStart.BackColor = System.Drawing.Color.Green;
				uiForm.btMopsIasStart.BackColor = System.Drawing.Color.DimGray;
			}
			else
			{
				// Turn outputs off
				//uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Vent test set
				AdtsCom.setGround();

				// Button color
				uiForm.btMopsIasStart.BackColor = System.Drawing.Color.DimGray;
				uiForm.btMopsBcaStart.BackColor = System.Drawing.Color.DimGray;

				mopsBcaPointsRunning = false;
				mopsIasPointsRunning = false;

			}
		}

		public static void setMopsAtpIasRunningSate(bool run)
		{
			mopsIasPointsRunning = run;

			if (run)
			{

				// Start at beginning of table
				currentState = 0;
				currentTestPoint = 0;

				// Clear data grid view entries
				uiForm.dgMopsAdcTestPoints.Rows.Clear();
				uiForm.dgMopsAdcTestPoints.Refresh();

				// Show IAS Test Points
				for (int i = 0; i < MopsTestPoints.mopsIasTestPoint.Length; i++)
				{
					uiForm.dgMopsAdcTestPoints.Rows.Add(MopsTestPoints.mopsIasTestPoint[i].ToString(), MopsTestPoints.mopsIasTolerance[i].ToString());
				}

				// Button color
				uiForm.btMopsIasStart.BackColor = System.Drawing.Color.Green;
				uiForm.btMopsBcaStart.BackColor = System.Drawing.Color.DimGray;

			}
			else
			{
				// Turn outputs off
				//uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Vent test set
				AdtsCom.setGround();

				// Button color
				uiForm.btMopsIasStart.BackColor = System.Drawing.Color.DimGray;
				uiForm.btMopsBcaStart.BackColor = System.Drawing.Color.DimGray;

				mopsBcaPointsRunning = false;
				mopsIasPointsRunning = false;
			}
		}



		// State machine update
		public static void update()
		{
			string msg = "";
			double temp;
			int tempi;

			//
			// UI Update
			//
			Color lcolor;
			if (uiForm.lru0.getUnitConnected())
				lcolor = Color.Green;
			else
				lcolor = Color.Red;


			// BCA
			temp = uiForm.lru0.dataParam[(int)PARAM.BCA] * 10;	// Scaled
			uiForm.btMopsBca.Text = temp.ToString("000.0");
			uiForm.btMopsBca.ForeColor = lcolor;

			// IAS
			temp = uiForm.lru0.dataParam[(int)PARAM.IAS];
			uiForm.btMopsIas.Text = temp.ToString("000.0");
			uiForm.btMopsIas.ForeColor = lcolor;

			// Roll
			temp = uiForm.lru0.dataParam[(int)PARAM.ROLL];
			uiForm.btMopsRoll.Text = temp.ToString("000.0");
			uiForm.btMopsRoll.ForeColor = lcolor;

			// Pitch
			temp = uiForm.lru0.dataParam[(int)PARAM.PITCH];
			uiForm.btMopsPitch.Text = temp.ToString("000.0");
			uiForm.btMopsPitch.ForeColor = lcolor;

			// Yaw
			temp = uiForm.lru0.dataParam[(int)PARAM.YAW];
			uiForm.btMopsYaw.Text = temp.ToString("000.0");
			uiForm.btMopsYaw.ForeColor = lcolor;

			// AoA
			temp = uiForm.lru0.dataParam[(int)PARAM.AOA];
			uiForm.btMopsAoa.Text = temp.ToString("000.0");
			uiForm.btMopsAoa.ForeColor = lcolor;

			// Bus Volts
			temp = uiForm.lru0.dataParam[(int)PARAM.VOLTS];
			uiForm.btMopsBusV.Text = temp.ToString("00.0");
			uiForm.btMopsBusV.ForeColor = lcolor;

			// Bat Volts
			temp = uiForm.lru0.dataParam[(int)PARAM.BATVOLTS];
			uiForm.btMopsBatV.Text = temp.ToString("00.0");
			uiForm.btMopsBatV.ForeColor = lcolor;
			
			// Temp Pitot
			temp = uiForm.lru0.dataParam[(int)PARAM.TEMPP];
			uiForm.btMopsPTemp.Text = temp.ToString("00.0");
			uiForm.btMopsPTemp.ForeColor = lcolor;

			// Temp Static
			temp = uiForm.lru0.dataParam[(int)PARAM.TEMPS];
			uiForm.btMopsSTemp.Text = temp.ToString("00.0");
			uiForm.btMopsSTemp.ForeColor = lcolor;

			// OAT C
			temp = uiForm.lru0.dataParam[(int)PARAM.OATC];
			uiForm.btMopsOatC.Text = temp.ToString("00.0");
			uiForm.btMopsOatC.ForeColor = lcolor;

			// Amb Light
			temp = uiForm.lru0.dataParam[(int)PARAM.AMBLIGHT];
			uiForm.btMopsLight.Text = temp.ToString("00.0");
			uiForm.btMopsLight.ForeColor = lcolor;

			// Temp Board
			temp = uiForm.lru0.dataParam[(int)PARAM.BTEMP];
			uiForm.btMopsBTmp.Text = temp.ToString("00.0");
			uiForm.btMopsBTmp.ForeColor = lcolor;


			// Roll Pitch Offset Fields
			uiForm.btMopsRollOffset.Text = (uiForm.lru0.dataParam[(int)PARAM.ROLL] - uiForm.rollOffset).ToString("00.0");
			uiForm.btMopsPitchOffset.Text = (uiForm.lru0.dataParam[(int)PARAM.PITCH] - uiForm.pitchOffset).ToString("00.0");

			//
			// State Machines
			//

			// Get current state from running SM
			if (mopsBcaPointsRunning)
			{
				// Bca points state machine
				msg = mopsBcaStateMachine();
			}
			else if (mopsIasPointsRunning)
			{
				// Ias points
				msg = atpIasStateMachine();
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
				//uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				mopsBcaPointsRunning = false;
				mopsIasPointsRunning = false;

			}
		}


		private static string mopsBcaStateMachine()
		{

			switch (currentState)
			{
				case (int)ATP_STATE.SET_TEST_POINT:
					{
						// Check for end
						if (currentTestPoint >= MopsTestPoints.mopsBcaTestPoint.Length)
						{
							// Last point reached
							currentState = 0;
							currentTestPoint = 0;
							setMopsAtpBcaRunningSate(false);
							AdtsCom.setGround();
							return ("end");
						}
						else
						{
							// Move to next
							AdtsCom.setIas(0.0);
							AdtsCom.setBca(MopsTestPoints.mopsBcaTestPoint[currentTestPoint]);
							return ("next");
						}
					}

				case (int)ATP_STATE.WAIT_TEST_POINT:
					{
						// Wait for move to complete
						if (AdtsCom.getInMotion())
							return ("wait");
						else
						{
							return ("next");
						}
					}

				case (int)ATP_STATE.GET_DATA:
					{
						// Multiple samples
						if (sampleCount < SAMPLE_COUNT)
						{
							// LRU 0
							// Get average readings
							avReading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.BCA] * 10; // Scaled
							sampleCount++;
							return ("wait");
						}
						else
						{
							// Add results to test table
							double error = Math.Abs(avReading.Average() - MopsTestPoints.mopsBcaTestPoint[currentTestPoint]);
							if (error < MopsTestPoints.mopsBcaTolerance[currentTestPoint])
								uiForm.dgMopsAdcTestResults.Rows.Add(avReading.Average().ToString("0000.0"), error.ToString("+0.0;-#;0.0"), "PASS");
							else
								uiForm.dgMopsAdcTestResults.Rows.Add(avReading.Average().ToString("0000.0"), error.ToString("+0.0;-#;0.0"), "FAIL");

							// Go to next point
							currentTestPoint++;

							// Loop back in state machine
							currentState = (int)ATP_STATE.SET_TEST_POINT;
							sampleCount = 0;
							return ("wait");
						}
					}

				default:
					{
						return ("end");
					}

			}

		}

		private static string atpIasStateMachine()
		{

			switch (currentState)
			{
				case (int)ATP_STATE.SET_TEST_POINT:
					{
						// Check for end
						if (currentTestPoint >= MopsTestPoints.mopsIasTestPoint.Length)
						{
							currentState = 0;
							currentTestPoint = 0;
							setMopsAtpIasRunningSate(false);
							AdtsCom.setGround();
							return ("end");
						}
						else
						{
							// Move to next
							AdtsCom.setIas(MopsTestPoints.mopsIasTestPoint[currentTestPoint]);
							AdtsCom.setBca(IAS_ALT_POINT);
							return ("next");
						}
					}

				case (int)ATP_STATE.WAIT_TEST_POINT:
					{
						// Wait for move to complete
						if (AdtsCom.getInMotion())
							return ("wait");
						else
						{
							return ("next");
						}
					}

				case (int)ATP_STATE.GET_DATA:
					{
						// Multiple samples
						if (sampleCount < SAMPLE_COUNT)
						{
							// LRU 0
							// Get average readings
							avReading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.IAS];

							sampleCount++;
							return ("wait");
						}
						else
						{
							// Add results to test table
							//uiForm.dgAdcAtpIasLru0Data.Rows.Add(avReading.Average().ToString("000.00"),
							//	(avReading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]).ToString("+0;-#;000.00"),
							//	"PASS");

							double error = Math.Abs(avReading.Average() - MopsTestPoints.mopsIasTestPoint[currentTestPoint]);
							if (error < MopsTestPoints.mopsIasTolerance[currentTestPoint])
								uiForm.dgMopsAdcTestResults.Rows.Add(avReading.Average().ToString("000.0"), error.ToString("+0.0;-#;0.0"), "PASS");
							else
								uiForm.dgMopsAdcTestResults.Rows.Add(avReading.Average().ToString("000.0"), error.ToString("+0.0;-#;0.0"), "FAIL");

							// Go to next point
							currentTestPoint++;

							// Loop back in state machine
							currentState = (int)ATP_STATE.SET_TEST_POINT;
							sampleCount = 0;
							return ("wait");
						}
					}

				default:
					{
						return ("end");
					}

			}

		}

		public static void connect()
		{

			uiForm.btBrdConnect.BackColor = System.Drawing.Color.Green;
			uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
			uiForm.lru0.setParameterReq((int)PARAM.BCA, RATE.RATE_10HZ);
			uiForm.lru0.setParameterReq((int)PARAM.IAS, RATE.RATE_10HZ);
			uiForm.lru0.setParameterReq((int)PARAM.ROLL, RATE.RATE_10HZ);
			uiForm.lru0.setParameterReq((int)PARAM.PITCH, RATE.RATE_10HZ);
			uiForm.lru0.setParameterReq((int)PARAM.YAW, RATE.RATE_10HZ);
			uiForm.lru0.setParameterReq((int)PARAM.BATVOLTS, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.VOLTS, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.TEMPP, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.TEMPS, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.BTEMP, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.OATC, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.AMBLIGHT, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.BTEMP, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.ALLBTN, RATE.RATE_1HZ);
			uiForm.lru0.setParameterReq((int)PARAM.AOA, RATE.RATE_1HZ);

		}


	}
}
