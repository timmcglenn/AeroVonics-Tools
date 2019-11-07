using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalTool
{
    class AtpTestPoints
    {
		//// ALT TSO
		//public static double[] bcaTestPoint = { -950.0, 0.0, 500, 1000.0, 1500, 2000, 3000, 4000, 6000, 8000, 10000, 12000, 14000, 16000, 18000, 20000, 22000, 24500 };
		//public static double[] bcaTolerance = { 20, 20, 20, 20, 25, 30, 30, 35, 40, 60, 80, 90, 100, 110, 120, 130, 140, 155 };

		// ALT Normal Production
		public static double[] bcaTestPoint = { -900.0, 0.0, 1000.0, 5000.0, 10000.0, 15000.0, 20000.0, 24000.0 };
		public static double[] bcaTolerance = { 20, 20, 20, 40, 80, 100, 130, 155 };

		// ALT Fast
		//public static double[] bcaTestPoint = { 5000, 5500, 6000 };
		//public static double[] bcaTolerance = { 50, 50, 50 };

		public static bool[] bcaTestPassFail = new bool[bcaTestPoint.Length];
        public static double[] bcaTestError = new double[bcaTestPoint.Length];

		//// IAS TSO (Forward)
		//      public static double[] iasTestPoint = { 40, 50, 60, 70, 80, 90, 100, 120, 140, 160, 180, 200, 220, 250, 290 };
		//      public static double[] iasTolerance = { 5,5,5,4,4,4,3,3,3,3,5,5,5,5,5 };

		//// IAS TSO (Reverse)
		//public static double[] iasTestPoint = { 290, 250, 220, 200, 180, 160, 140, 120, 100, 90, 80, 70, 60, 50, 40 };
		//public static double[] iasTolerance = { 5, 5, 5, 5, 5, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5 };
	
		// IAS Normal Production
		public static double[] iasTestPoint = { 0.0, 40.0, 70.0, 100.0, 200.0, 280 };
		public static double[] iasTolerance = { 1.0, 5.0, 5.0, 3.0, 5.0, 5.0 };

		// IAS Fast
		//public static double[] iasTestPoint = { 40.0, 80.0 };
		//public static double[] iasTolerance = { 5.0, 5.0 };

		public static bool[] iasTestPassFail = new bool[iasTestPoint.Length];
        public static double[] iasTestError = new double[iasTestPoint.Length];

    }
    
    class AtpAdc
    {

        // State machine sates
        enum ATP_STATE { SET_TEST_POINT, WAIT_TEST_POINT, GET_DATA };
        
        // Constants
        private const int SAMPLE_COUNT = 30;
        private const int IAS_ALT_POINT = 5000;

        // State variables
        static MainForm uiForm;
        static bool bcaPointsRunning = false;
        static bool iasPointsRunning = false;
        static int currentState = 0;
        static int currentTestPoint = 0;
        public static int sampleCount;

		static double[] av0Reading = new double[SAMPLE_COUNT];
		static double[] av1Reading = new double[SAMPLE_COUNT];
		static double[] av2Reading = new double[SAMPLE_COUNT];
		static double[] av3Reading = new double[SAMPLE_COUNT];

		static Control cnt;

        // Accessors
        public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }


        // Test Start / Stop
        public static void setAtpBcaRunningSate(bool run)
        {
            bcaPointsRunning = run;

			if (run)
            {
				// Turn outputs on
				if (uiForm.cbLru0Use.Checked)
				{
					uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru0.setParameterReq((int)PARAM.BCA, RATE.RATE_10HZ);
					uiForm.lru0.setParameterReq((int)PARAM.IAS, RATE.RATE_10HZ);
					uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru1Use.Checked)
				{
					uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru1.setParameterReq((int)PARAM.BCA, RATE.RATE_10HZ);
					uiForm.lru1.setParameterReq((int)PARAM.IAS, RATE.RATE_10HZ);
					uiForm.lru1.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru2Use.Checked)
				{
					uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru2.setParameterReq((int)PARAM.BCA, RATE.RATE_10HZ);
					uiForm.lru2.setParameterReq((int)PARAM.IAS, RATE.RATE_10HZ);
					uiForm.lru2.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru3Use.Checked)
				{
					uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru3.setParameterReq((int)PARAM.BCA, RATE.RATE_10HZ);
					uiForm.lru3.setParameterReq((int)PARAM.IAS, RATE.RATE_10HZ);
					uiForm.lru3.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}

				// Start at beginning of table
				currentState = 0;
                currentTestPoint = 0;

                // Clear data grid view entries
                uiForm.dgAdcAtpBcaLru0Data.ClearSelection();
                uiForm.dgAdcAtpBcaLru1Data.ClearSelection();
                uiForm.dgAdcAtpBcaLru2Data.ClearSelection();
                uiForm.dgAdcAtpBcaLru3Data.ClearSelection();

				uiForm.dgAdcAtpBcaTestPoints.ClearSelection();
                uiForm.dgAdcAtpIasTestPoints.ClearSelection();


                // Show BCA Test Points
                for (int i = 0; i < AtpTestPoints.bcaTestPoint.Length; i++)
                {
                    uiForm.dgAdcAtpBcaTestPoints.Rows.Add(AtpTestPoints.bcaTestPoint[i].ToString() + " [" + AtpTestPoints.bcaTolerance[i].ToString() + "]");
				}
                // Show IAS Test Points
                for (int i = 0; i < AtpTestPoints.iasTestPoint.Length; i++)
                {
                    uiForm.dgAdcAtpIasTestPoints.Rows.Add(AtpTestPoints.iasTestPoint[i].ToString() + " [" + AtpTestPoints.iasTolerance[i].ToString() + "]");
                }

				// Button color
				uiForm.bStartAdcAtp.BackColor = System.Drawing.Color.Green;

			}
            else
            {
                // Turn outputs off
                uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Button color
				uiForm.bStartAdcAtp.BackColor = System.Drawing.Color.Transparent;

				// Vent test set
				AdtsCom.setGround();
            }
        }


        // State machine update
        public static void update()
        {
            string msg = "";

			// Get current state from running SM

            if (bcaPointsRunning)
            {
				// BCA field updates
				if (uiForm.cbLru0Use.Checked)
				{
					AtpAdc.uiForm.btLru0Bca.Text = (uiForm.lru0.dataParam[(int)PARAM.BCA] * 10).ToString("0000"); // Scaled
					AtpAdc.uiForm.btLru0Ias.Text = uiForm.lru0.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru1Use.Checked)
				{
					AtpAdc.uiForm.btLru1Bca.Text = (uiForm.lru1.dataParam[(int)PARAM.BCA] * 10).ToString("0000"); // Scaled
					AtpAdc.uiForm.btLru1Ias.Text = uiForm.lru1.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru2Use.Checked)
				{
					AtpAdc.uiForm.btLru2Bca.Text = (uiForm.lru2.dataParam[(int)PARAM.BCA] * 10).ToString("0000"); // Scaled
					AtpAdc.uiForm.btLru2Ias.Text = uiForm.lru2.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru3Use.Checked)
				{
					AtpAdc.uiForm.btLru3Bca.Text = (uiForm.lru3.dataParam[(int)PARAM.BCA] * 10).ToString("0000"); // Scaled
					AtpAdc.uiForm.btLru3Ias.Text = uiForm.lru3.dataParam[(int)PARAM.IAS].ToString("000.0");
				}


				// Bca point number
				uiForm.bADCTestPointNum.Text = currentTestPoint.ToString() + " OF " + AtpTestPoints.bcaTestPoint.Length.ToString();

				msg = atpBcaStateMachine();
            }
            else if (iasPointsRunning)
            {
				// IAS field updates
				if (uiForm.cbLru0Use.Checked)
				{
					AtpAdc.uiForm.btLru0Bca.Text = (uiForm.lru0.dataParam[(int)PARAM.BCA] * 10).ToString("0000");
					AtpAdc.uiForm.btLru0Ias.Text = uiForm.lru0.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru1Use.Checked)
				{
					AtpAdc.uiForm.btLru1Bca.Text = (uiForm.lru1.dataParam[(int)PARAM.BCA] * 10).ToString("0000");
					AtpAdc.uiForm.btLru1Ias.Text = uiForm.lru1.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru2Use.Checked)
				{
					AtpAdc.uiForm.btLru2Bca.Text = (uiForm.lru2.dataParam[(int)PARAM.BCA] * 10).ToString("0000");
					AtpAdc.uiForm.btLru2Ias.Text = uiForm.lru2.dataParam[(int)PARAM.IAS].ToString("000.0");
				}
				if (uiForm.cbLru3Use.Checked)
				{
					AtpAdc.uiForm.btLru3Bca.Text = (uiForm.lru3.dataParam[(int)PARAM.BCA] * 10).ToString("0000");
					AtpAdc.uiForm.btLru3Ias.Text = uiForm.lru3.dataParam[(int)PARAM.IAS].ToString("000.0");
				}

				uiForm.bADCTestPointNum.Text = currentTestPoint.ToString() + " OF " + AtpTestPoints.iasTestPoint.Length.ToString();

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
                uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				bcaPointsRunning = false;
                iasPointsRunning = false;

				// Button color
				uiForm.bStartAdcAtp.BackColor = System.Drawing.Color.DarkGreen;

				// Check for chain
				if (uiForm.cbChainAdcToAhrs.Checked)
				{
					// Start Accel Cal cycle
					CalAccel.setCalRunningSate(true);
				}
			}
        }


        private static string atpBcaStateMachine()
        {
            int loop = 0;

            switch (currentState)
            {
                case (int)ATP_STATE.SET_TEST_POINT:
                    {
                        // Check for end
                        if (currentTestPoint >= AtpTestPoints.bcaTestPoint.Length)
                        {
                            // Last point reached - go to IAS ATP
                            bcaPointsRunning = false;
                            iasPointsRunning = true;
                            currentState = 0;
                            currentTestPoint = 0;
                            return ("wait");
                        }
                        else
                        {
                            // Move to next
                            AdtsCom.setIas(0.0);
                            AdtsCom.setBca(AtpTestPoints.bcaTestPoint[currentTestPoint]);
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
							if (uiForm.cbLru0Use.Checked)
								av0Reading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.BCA] * 10; // Scaled
							if (uiForm.cbLru1Use.Checked)
								av1Reading[sampleCount] = uiForm.lru1.dataParam[(int)PARAM.BCA] * 10; // Scaled
							if (uiForm.cbLru2Use.Checked)
								av2Reading[sampleCount] = uiForm.lru2.dataParam[(int)PARAM.BCA] * 10; // Scaled
							if (uiForm.cbLru3Use.Checked)
								av3Reading[sampleCount] = uiForm.lru3.dataParam[(int)PARAM.BCA] * 10; // Scaled


							sampleCount++;
                            return ("wait");
                        }
                        else
                        {
							// Add results to test table
							if (uiForm.cbLru0Use.Checked)
							{
								double error = Math.Abs(av0Reading.Average() - AtpTestPoints.bcaTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.bcaTolerance[currentTestPoint])
									uiForm.dgAdcAtpBcaLru0Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpBcaLru0Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru1Use.Checked)
							{
								double error = Math.Abs(av1Reading.Average() - AtpTestPoints.bcaTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.bcaTolerance[currentTestPoint])
									uiForm.dgAdcAtpBcaLru1Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpBcaLru1Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru2Use.Checked)
							{
								double error = Math.Abs(av2Reading.Average() - AtpTestPoints.bcaTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.bcaTolerance[currentTestPoint])
									uiForm.dgAdcAtpBcaLru2Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpBcaLru2Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru3Use.Checked)
							{
								double error = Math.Abs(av3Reading.Average() - AtpTestPoints.bcaTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.bcaTolerance[currentTestPoint])
									uiForm.dgAdcAtpBcaLru3Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpBcaLru3Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}

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
            int loop = 0;

            switch (currentState)
            {
                case (int)ATP_STATE.SET_TEST_POINT:
                    {
                        // Check for end
                        if (currentTestPoint >= AtpTestPoints.iasTestPoint.Length)
                        {
                            AdtsCom.setGround();
                            return ("end");
                        }
                        else
                        {
                            // Move to next
                            AdtsCom.setIas(AtpTestPoints.iasTestPoint[currentTestPoint]);
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
							if (uiForm.cbLru0Use.Checked)
								av0Reading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.IAS];
							if (uiForm.cbLru1Use.Checked)
								av1Reading[sampleCount] = uiForm.lru1.dataParam[(int)PARAM.IAS];
							if (uiForm.cbLru2Use.Checked)
								av2Reading[sampleCount] = uiForm.lru2.dataParam[(int)PARAM.IAS];
							if (uiForm.cbLru3Use.Checked)
								av3Reading[sampleCount] = uiForm.lru3.dataParam[(int)PARAM.IAS];

							sampleCount++;
                            return ("wait");
                        }
                        else
                        {
                            // Add results to test table
                            //uiForm.dgAdcAtpIasLru0Data.Rows.Add(av0Reading.Average().ToString("000.00"),
                            //    (av0Reading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]).ToString("+0;-#;000.00"),
                            //    "PASS");

							if (uiForm.cbLru0Use.Checked)
							{
								double error = Math.Abs(av0Reading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.iasTolerance[currentTestPoint])
									uiForm.dgAdcAtpIasLru0Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpIasLru0Data.Rows.Add(av0Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru1Use.Checked)
							{
								double error = Math.Abs(av1Reading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.iasTolerance[currentTestPoint])
									uiForm.dgAdcAtpIasLru1Data.Rows.Add(av1Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpIasLru1Data.Rows.Add(av1Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru2Use.Checked)
							{
								double error = Math.Abs(av2Reading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.iasTolerance[currentTestPoint])
									uiForm.dgAdcAtpIasLru2Data.Rows.Add(av2Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpIasLru2Data.Rows.Add(av2Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}
							if (uiForm.cbLru3Use.Checked)
							{
								double error = Math.Abs(av3Reading.Average() - AtpTestPoints.iasTestPoint[currentTestPoint]);
								if (error < AtpTestPoints.iasTolerance[currentTestPoint])
									uiForm.dgAdcAtpIasLru3Data.Rows.Add(av3Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "PASS");
								else
									uiForm.dgAdcAtpIasLru3Data.Rows.Add(av3Reading.Average().ToString("0000.00"), error.ToString("+0;-#;000.00"), "** FAIL **");
							}


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


    }
}
