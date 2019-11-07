using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalTool
{


    class BcaCalPoints
    {
		// BCA Normal Prodction
		public static double[] bcaCalPoint = { -1000.0, 0.0, 1000.0, 2000.0, 3000.0, 4000.0, 5000.0, 6000.0, 7000.0, 8000.0,
			9000.0, 10000.0, 11000.0, 12000.0, 13000.0, 14000.0, 15000.0, 16000.0, 17000.0, 18000.0,
			19000.0, 20000.0, 21000.0, 22000.0, 23000.0, 24000.0, 25000.0  };  // 27 Entries

		// For fast testing
		// public static double[] bcaCalPoint = { -1000, 0, 1000 };

		// Theoretical values (testing purposes)
		public static double[] bcaTruePoint = {
        1058.34,1013.25, 970.08,   928.74,  889.17, 851.28, // -1000 to 4000
       	815.01, 780.29,  747.04,  715.20,  684.73,    	    // 5000 to 9000
       	655.56, 627.62,  600.88,  575.28,  550.77, 	        // 10,000 to 14,000
       	527.30, 504.83,  483.32,  462.73,  443.01,		    // 15,000 to 19,000
       	424.14, 406.06,  388.76,  372.20,  356.34,		    // 20,000 to 24,000
       	341.15 };				                            // 25,000

        public static int bcaCalPointsNum = bcaCalPoint.Length;
        public static int currentCalPoint = 0;
        public static double currentTargetAlt = 0;

        public static double[] sen0PCalPoint = new double[bcaCalPoint.Length];
        public static double[] sen0SCalPoint = new double[bcaCalPoint.Length];

		public static double[] sen1PCalPoint = new double[bcaCalPoint.Length];
		public static double[] sen1SCalPoint = new double[bcaCalPoint.Length];

		public static double[] sen2PCalPoint = new double[bcaCalPoint.Length];
		public static double[] sen2SCalPoint = new double[bcaCalPoint.Length];

		public static double[] sen3PCalPoint = new double[bcaCalPoint.Length];
		public static double[] sen3SCalPoint = new double[bcaCalPoint.Length];


	}

	class CalAdc
    {
        // Constants
        private const int SAMPLE_COUNT = 30;
        private const int FLASH_LOC_ADC_CAL_START = 10;     // EEPROM Start - Length = 27 Entries * 2 Sensors  = 54 locations (not bytes)

        // State machine sates
        enum CAL_STATE { SET_TEST_POINT, WAIT_TEST_POINT, GET_DATA };
        enum PRG_STATE { PRG_PITOT, PRG_STATIC };
        enum READ_STATE { READ_POINT, WAIT_POINT };
        
		// Public
        public static int sampleCount;
        public static int writeCount;
        public static int readCount;
        private static int locCount;
		
        // State variables
        static MainForm uiForm;
        public static bool calPointsRunning = false;
        public static bool prgPointsRunning = false;
        public static bool readPointsRunning = false;

        static int currentState = 0;
        static Random random = new Random();

        static double[] av0PReading = new double[SAMPLE_COUNT];
        static double[] av0SReading = new double[SAMPLE_COUNT];

		static double[] av1PReading = new double[SAMPLE_COUNT];
		static double[] av1SReading = new double[SAMPLE_COUNT];

		static double[] av2PReading = new double[SAMPLE_COUNT];
		static double[] av2SReading = new double[SAMPLE_COUNT];

		static double[] av3PReading = new double[SAMPLE_COUNT];
		static double[] av3SReading = new double[SAMPLE_COUNT];



		// Accessors
		public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }

		public static void connect()
		{
			// If operation is already in progress, dont send data requests
			if (!calPointsRunning && !prgPointsRunning && !readPointsRunning)
			{
				// Turn outputs on
				if (uiForm.cbLru0Use.Checked)
				{
					uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru0.setParameterReq((int)PARAM.SENP, RATE.RATE_10HZ);
					uiForm.lru0.setParameterReq((int)PARAM.SENS, RATE.RATE_10HZ);
					uiForm.lru0.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru1Use.Checked)
				{
					uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru1.setParameterReq((int)PARAM.SENP, RATE.RATE_10HZ);
					uiForm.lru1.setParameterReq((int)PARAM.SENS, RATE.RATE_10HZ);
					uiForm.lru1.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru2Use.Checked)
				{
					uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru2.setParameterReq((int)PARAM.SENP, RATE.RATE_10HZ);
					uiForm.lru2.setParameterReq((int)PARAM.SENS, RATE.RATE_10HZ);
					uiForm.lru2.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
				if (uiForm.cbLru3Use.Checked)
				{
					uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
					uiForm.lru3.setParameterReq((int)PARAM.SENP, RATE.RATE_10HZ);
					uiForm.lru3.setParameterReq((int)PARAM.SENS, RATE.RATE_10HZ);
					uiForm.lru3.setParameterReq((int)PARAM.STATUS, RATE.RATE_1HZ);
				}
			}
		}

		// Cal Points Start / Stop
		public static void setCalRunningSate(bool run)
        {
            if (run)
            {
				connect();

				// Start at beginning of table
				BcaCalPoints.currentCalPoint = 0;
                currentState = 0;
                uiForm.setConsoleText("AD", "CYCLE START\n");

                // Clear data grid view entries
                Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
                (dgv as DataGridView).Rows.Clear();
                dgv = uiForm.Controls.Find("dgAdcLru1Data", true).FirstOrDefault();
                (dgv as DataGridView).Rows.Clear();
                dgv = uiForm.Controls.Find("dgAdcLru2Data", true).FirstOrDefault();
                (dgv as DataGridView).Rows.Clear();
                dgv = uiForm.Controls.Find("dgAdcLru3Data", true).FirstOrDefault();
                (dgv as DataGridView).Rows.Clear();
                dgv = uiForm.Controls.Find("dgAdcCalPoint", true).FirstOrDefault();
                (dgv as DataGridView).Rows.Clear();

                readPointsRunning = false;
                prgPointsRunning = false;
                calPointsRunning = true;
                
                // Button color
                uiForm.bStartAdcCal.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                // Turn outputs off
                uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

                // Vent test set
                AdtsCom.setGround();

                // Shutdown state
                calPointsRunning = false;

				// Button color
				uiForm.bStartAdcCal.BackColor = System.Drawing.Color.DimGray;
            }
        }

        public static void setPrgRunningState(bool run)
        {
            if (run)
            {
				// Turn data off
				if (uiForm.cbLru0Use.Checked)
					uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru1Use.Checked)
					uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru2Use.Checked)
					uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru3Use.Checked)
					uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				// Start new write cycle
				writeCount = 0;
                locCount = FLASH_LOC_ADC_CAL_START;
                currentState = 0;
                readPointsRunning = false;
                prgPointsRunning = true;
                calPointsRunning = false;

                // Button color
                uiForm.bStartAdcPrg.BackColor = System.Drawing.Color.Green;

            }
            else
            {
                prgPointsRunning = false;
                // Button color
                uiForm.bStartAdcPrg.BackColor = System.Drawing.Color.Transparent;
            }
        }

        public static void setReadRunningState(bool run)
        {
            if (run)
            {
				// Turn data off
				if (uiForm.cbLru0Use.Checked)
					uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru1Use.Checked)
					uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru2Use.Checked)
					uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				if (uiForm.cbLru3Use.Checked)
					uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				//// Wait for data to turn off
				//System.Threading.Thread.Sleep(1000);

				// Reconnect for status to be output
				connect();

				// Start new read all cycle
				readCount = 0;
                locCount = FLASH_LOC_ADC_CAL_START;
                currentState = 0;
                readPointsRunning = true;
                prgPointsRunning = false;
                calPointsRunning = false;

                // Clear form table entries
                uiForm.dgAdcLru0Data.Rows.Clear();
				uiForm.dgAdcLru1Data.Rows.Clear();
				uiForm.dgAdcLru2Data.Rows.Clear();
				uiForm.dgAdcLru3Data.Rows.Clear();
				uiForm.dgAdcCalPoint.Rows.Clear();

                // Setup empty entries
                for (int i = 0; i < BcaCalPoints.bcaCalPointsNum; i++)
                {
                    uiForm.dgAdcCalPoint.Rows.Add(BcaCalPoints.bcaCalPoint[i].ToString());
					if (uiForm.cbLru0Use.Checked)
						uiForm.dgAdcLru0Data.Rows.Add(0.ToString("0000.00"), 0.ToString("0000.00"), "PENDING");
					if (uiForm.cbLru1Use.Checked)
						uiForm.dgAdcLru1Data.Rows.Add(0.ToString("0000.00"), 0.ToString("0000.00"), "PENDING");
					if (uiForm.cbLru2Use.Checked)
						uiForm.dgAdcLru2Data.Rows.Add(0.ToString("0000.00"), 0.ToString("0000.00"), "PENDING");
					if (uiForm.cbLru3Use.Checked)
						uiForm.dgAdcLru3Data.Rows.Add(0.ToString("0000.00"), 0.ToString("0000.00"), "PENDING");
				}

				// Button color
				uiForm.btStartAdcRead.BackColor = System.Drawing.Color.Green;

            }
            else
            {
                readPointsRunning = false;

                // Button color
                uiForm.btStartAdcRead.BackColor = System.Drawing.Color.Transparent;
            }
        }


        public static void setDefaultValues(int lru)
        {
			// Clear tables
			uiForm.dgAdcCalPoint.Rows.Clear();
			uiForm.dgAdcLru0Data.Rows.Clear();
			uiForm.dgAdcLru1Data.Rows.Clear();
			uiForm.dgAdcLru2Data.Rows.Clear();
			uiForm.dgAdcLru3Data.Rows.Clear();

			// Loop through each cal entry
			for (int i = 0; i < BcaCalPoints.bcaCalPointsNum; i++)
            {
                uiForm.dgAdcCalPoint.Rows.Add(BcaCalPoints.bcaCalPoint[i].ToString());
                uiForm.dgAdcLru0Data.Rows.Add(BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), "DEFAULT");

				if (uiForm.cbLru0Use.Checked)
					uiForm.dgAdcLru0Data.Rows.Add(BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), "DEFAULT");

				if (uiForm.cbLru1Use.Checked)
					uiForm.dgAdcLru1Data.Rows.Add(BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), "DEFAULT");

				if (uiForm.cbLru2Use.Checked)
					uiForm.dgAdcLru2Data.Rows.Add(BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), "DEFAULT");

				if (uiForm.cbLru3Use.Checked)
					uiForm.dgAdcLru3Data.Rows.Add(BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), BcaCalPoints.bcaTruePoint[i].ToString("0000.00"), "DEFAULT");


				BcaCalPoints.sen0PCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
                BcaCalPoints.sen0SCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen1PCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen1SCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen2PCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen2SCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen3PCalPoint[i] = BcaCalPoints.bcaTruePoint[i];
				BcaCalPoints.sen3SCalPoint[i] = BcaCalPoints.bcaTruePoint[i];

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
		public static bool getReadRunningState()
		{
			return readPointsRunning;
		}

		public static bool getIdle()
		{
			return (!(calPointsRunning | prgPointsRunning | readPointsRunning));
		}


		// State machine update
		public static void update()
        {
            string msg = "";

            // Get current state from running SM
            if (calPointsRunning)
            {
                // General field updates
                uiForm.bADCTestPointNum.Text = (BcaCalPoints.currentCalPoint + 1).ToString() + " OF " + BcaCalPoints.bcaCalPoint.Length.ToString();

                // Cal points
                msg = calPointsStateMachine();
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
				uiForm.lru1.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru2.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				uiForm.lru3.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

				calPointsRunning = false;
                prgPointsRunning = false;
                readPointsRunning = false;

            }
        }


        private static string calPointsStateMachine()
        {
            int loop = 0;

            switch (currentState)
            {
                case (int)CAL_STATE.SET_TEST_POINT:
                    {
                        // Check for end
                        if (BcaCalPoints.currentCalPoint >= BcaCalPoints.bcaCalPoint.Length)
                        {
                            // Last point reached - end cal cycle
                            uiForm.setConsoleText("AD", "CAL END\n");
                            AdtsCom.setGround();
                            // Shut this state off
                            calPointsRunning = false;
                            // Button color
                            uiForm.bStartAdcCal.BackColor = System.Drawing.Color.DarkGreen;

                            // Check for chain
                            if (true)
                            {
                                // Start Prog cycle
                                setPrgRunningState(true);
                                return ("wait");
                            }

                            return ("end");
                        }
                        else
                        {
                            // Move to next position
                            AdtsCom.setIas(0.0);
                            AdtsCom.setBca(BcaCalPoints.bcaCalPoint[BcaCalPoints.currentCalPoint]);
                            BcaCalPoints.currentTargetAlt = BcaCalPoints.bcaCalPoint[BcaCalPoints.currentCalPoint];
                            uiForm.setConsoleText("AD", "CAL POINT SET\n");
                            return ("next");
                        }
                    }

                case (int)CAL_STATE.WAIT_TEST_POINT:
                    {
                        // Wait for move to complete
                        if (AdtsCom.getInMotion())
                            return ("wait");
                        else
                        {
                            return ("next");
                        }
                    }

                case (int)CAL_STATE.GET_DATA:
                    {
                        // Multiple samples
                        if (sampleCount < SAMPLE_COUNT)
                        {
							// Get average readings
							if (uiForm.cbLru0Use.Checked)
							{
								av0PReading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.SENP];
								av0SReading[sampleCount] = uiForm.lru0.dataParam[(int)PARAM.SENS];
							}
							if (uiForm.cbLru1Use.Checked)
							{
								av1PReading[sampleCount] = uiForm.lru1.dataParam[(int)PARAM.SENP];
								av1SReading[sampleCount] = uiForm.lru1.dataParam[(int)PARAM.SENS];
							}
							if (uiForm.cbLru2Use.Checked)
							{
								av2PReading[sampleCount] = uiForm.lru2.dataParam[(int)PARAM.SENP];
								av2SReading[sampleCount] = uiForm.lru2.dataParam[(int)PARAM.SENS];
							}
							if (uiForm.cbLru3Use.Checked)
							{
								av3PReading[sampleCount] = uiForm.lru3.dataParam[(int)PARAM.SENP];
								av3SReading[sampleCount] = uiForm.lru3.dataParam[(int)PARAM.SENS];
							}


							sampleCount++;
                            return ("wait");
                        }
                        else
                        {
							// Store average readings
							if (uiForm.cbLru0Use.Checked)
							{
								BcaCalPoints.sen0PCalPoint[BcaCalPoints.currentCalPoint] = av0PReading.Average();
								BcaCalPoints.sen0SCalPoint[BcaCalPoints.currentCalPoint] = av0SReading.Average();
							}
							if (uiForm.cbLru1Use.Checked)
							{
								BcaCalPoints.sen1PCalPoint[BcaCalPoints.currentCalPoint] = av1PReading.Average();
								BcaCalPoints.sen1SCalPoint[BcaCalPoints.currentCalPoint] = av1SReading.Average();
							}
							if (uiForm.cbLru2Use.Checked)
							{
								BcaCalPoints.sen2PCalPoint[BcaCalPoints.currentCalPoint] = av2PReading.Average();
								BcaCalPoints.sen2SCalPoint[BcaCalPoints.currentCalPoint] = av2SReading.Average();
							}
							if (uiForm.cbLru3Use.Checked)
							{
								BcaCalPoints.sen3PCalPoint[BcaCalPoints.currentCalPoint] = av3PReading.Average();
								BcaCalPoints.sen3SCalPoint[BcaCalPoints.currentCalPoint] = av3SReading.Average();
							}

							// Add to cal data table
							uiForm.dgAdcCalPoint.Rows.Add(BcaCalPoints.bcaCalPoint[BcaCalPoints.currentCalPoint].ToString());

							Control dgv;
                            dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
                            (dgv as DataGridView).Rows.Add(av0PReading.Average().ToString("0000.00"), av0SReading.Average().ToString("0000.00"), "MEASURED");

							dgv = uiForm.Controls.Find("dgAdcLru1Data", true).FirstOrDefault();
							(dgv as DataGridView).Rows.Add(av1PReading.Average().ToString("0000.00"), av1SReading.Average().ToString("0000.00"), "MEASURED");

							dgv = uiForm.Controls.Find("dgAdcLru2Data", true).FirstOrDefault();
							(dgv as DataGridView).Rows.Add(av2PReading.Average().ToString("0000.00"), av2SReading.Average().ToString("0000.00"), "MEASURED");

							dgv = uiForm.Controls.Find("dgAdcLru3Data", true).FirstOrDefault();
							(dgv as DataGridView).Rows.Add(av3PReading.Average().ToString("0000.00"), av3SReading.Average().ToString("0000.00"), "MEASURED");


							// Go to next point
							BcaCalPoints.currentCalPoint++;

                            // Loop back in state machine
                            currentState = (int)CAL_STATE.SET_TEST_POINT;
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

        private static string prgPointsStateMachine()
        {
            switch (currentState)
            {
                case (int)PRG_STATE.PRG_PITOT:
                    {
                        if (writeCount < BcaCalPoints.bcaCalPointsNum)
                        {
							// Write Pitot port cal values
							if (uiForm.cbLru0Use.Checked)
							{
								uiForm.lru0.setCalWriteF(locCount, BcaCalPoints.sen0PCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "S PROG";
							}
							if (uiForm.cbLru1Use.Checked)
							{
								uiForm.lru1.setCalWriteF(locCount, BcaCalPoints.sen1PCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru1Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "S PROG";
							}
							if (uiForm.cbLru2Use.Checked)
							{
								uiForm.lru2.setCalWriteF(locCount, BcaCalPoints.sen2PCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru2Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "S PROG";
							}
							if (uiForm.cbLru3Use.Checked)
							{
								uiForm.lru3.setCalWriteF(locCount, BcaCalPoints.sen3PCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru3Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "S PROG";
							}

							writeCount++;
                            locCount++;
                            return ("wait");
                        }
                        else
                        {
                            // Start over for static
                            writeCount = 0;
                            return ("next");
                        }
                    }

                case (int)PRG_STATE.PRG_STATIC:
                    {
                        // Write Static port cal values
                        if (writeCount < BcaCalPoints.bcaCalPointsNum)
                        {
							// Write Pitot port cal values
							if (uiForm.cbLru0Use.Checked)
							{
								uiForm.lru0.setCalWriteF(locCount, BcaCalPoints.sen0SCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "P PROG";
							}
							if (uiForm.cbLru1Use.Checked)
							{
								uiForm.lru1.setCalWriteF(locCount, BcaCalPoints.sen1SCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru1Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "P PROG";
							}
							if (uiForm.cbLru2Use.Checked)
							{
								uiForm.lru2.setCalWriteF(locCount, BcaCalPoints.sen2SCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru2Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "P PROG";
							}
							if (uiForm.cbLru3Use.Checked)
							{
								uiForm.lru3.setCalWriteF(locCount, BcaCalPoints.sen3SCalPoint[writeCount]);
								Control dgv = uiForm.Controls.Find("dgAdcLru3Data", true).FirstOrDefault();
								(dgv as DataGridView)[2, writeCount].Value = "P PROG";
							}
							

							writeCount++;
                            locCount++;
                            return ("wait");
                        }
                        else
                        {
							// End
							if (uiForm.cbLru0Use.Checked)
								uiForm.lru0.setCalWriteF((int)PARAM.FLUSH, 0);
							if (uiForm.cbLru1Use.Checked)
								uiForm.lru1.setCalWriteF((int)PARAM.FLUSH, 0);
							if (uiForm.cbLru2Use.Checked)
								uiForm.lru2.setCalWriteF((int)PARAM.FLUSH, 0);
							if (uiForm.cbLru3Use.Checked)
								uiForm.lru3.setCalWriteF((int)PARAM.FLUSH, 0);

							// Shut this state off
							prgPointsRunning = false;

                            // Button color
                            uiForm.bStartAdcPrg.BackColor = System.Drawing.Color.DarkGreen;

                            // Check for chain (always on for now)
                            if (true)
                            {

								// Wait for program flush to complete
								System.Threading.Thread.Sleep(1000);

								// Start Read cycle
								setReadRunningState(true);
                                return ("wait");
                            }

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
                        // Read pitot and static for each cal point
                        if (readCount < (BcaCalPoints.bcaCalPointsNum * 2))
                        {
							// Request data point
							if (uiForm.cbLru0Use.Checked)
								uiForm.lru0.setCalReadF(locCount);
							if (uiForm.cbLru1Use.Checked)
								uiForm.lru1.setCalReadF(locCount);
							if (uiForm.cbLru2Use.Checked)
								uiForm.lru2.setCalReadF(locCount);
							if (uiForm.cbLru3Use.Checked)
								uiForm.lru3.setCalReadF(locCount);

							return ("next");
                        }
                        else
                        {
                            // Shut this state off
                            readPointsRunning = false;
                            // Button color
                            uiForm.btStartAdcRead.BackColor = System.Drawing.Color.DarkGreen;

							// Reconnect to show sensor data
							connect();

							// Check for chain
							if (uiForm.cbChainReadToTest.Checked)
                            {
                                // Start Test cycle
                                AtpAdc.setAtpBcaRunningSate(true);
                                return ("wait");
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
                            //Control dgv = uiForm.Controls.Find("dgAdcLru0Data", true).FirstOrDefault();

                            // Determine which colum to put value
                            if (readCount < BcaCalPoints.bcaCalPointsNum)
                            {
								// Pitot Data
								if (uiForm.cbLru0Use.Checked)
								{
									uiForm.dgAdcLru0Data[0, readCount].Value = uiForm.lru0.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru0Data[2, readCount].Value = "P READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen0PCalPoint[readCount] = uiForm.lru0.senBoardFbValF;
								}
								if (uiForm.cbLru1Use.Checked)
								{
									uiForm.dgAdcLru1Data[0, readCount].Value = uiForm.lru1.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru1Data[2, readCount].Value = "P READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen1PCalPoint[readCount] = uiForm.lru1.senBoardFbValF;
								}
								if (uiForm.cbLru2Use.Checked)
								{
									uiForm.dgAdcLru2Data[0, readCount].Value = uiForm.lru2.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru2Data[2, readCount].Value = "P READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen2PCalPoint[readCount] = uiForm.lru2.senBoardFbValF;
								}
								if (uiForm.cbLru3Use.Checked)
								{
									uiForm.dgAdcLru3Data[0, readCount].Value = uiForm.lru3.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru3Data[2, readCount].Value = "P READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen3PCalPoint[readCount] = uiForm.lru3.senBoardFbValF;
								}
							}
							else
                            {
								// Static Data
								if (uiForm.cbLru0Use.Checked)
								{
									uiForm.dgAdcLru0Data[1, readCount - BcaCalPoints.bcaCalPointsNum].Value = uiForm.lru0.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru0Data[2, readCount - BcaCalPoints.bcaCalPointsNum].Value = "S READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen0SCalPoint[readCount - BcaCalPoints.bcaCalPointsNum] = uiForm.lru0.senBoardFbValF;
								}
								if (uiForm.cbLru1Use.Checked)
								{
									uiForm.dgAdcLru1Data[1, readCount - BcaCalPoints.bcaCalPointsNum].Value = uiForm.lru1.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru1Data[2, readCount - BcaCalPoints.bcaCalPointsNum].Value = "S READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen1SCalPoint[readCount - BcaCalPoints.bcaCalPointsNum] = uiForm.lru1.senBoardFbValF;
								}
								if (uiForm.cbLru2Use.Checked)
								{
									uiForm.dgAdcLru2Data[1, readCount - BcaCalPoints.bcaCalPointsNum].Value = uiForm.lru2.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru2Data[2, readCount - BcaCalPoints.bcaCalPointsNum].Value = "S READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen2SCalPoint[readCount - BcaCalPoints.bcaCalPointsNum] = uiForm.lru2.senBoardFbValF;
								}
								if (uiForm.cbLru3Use.Checked)
								{
									uiForm.dgAdcLru3Data[1, readCount - BcaCalPoints.bcaCalPointsNum].Value = uiForm.lru3.senBoardFbValF.ToString("0000.00");
									uiForm.dgAdcLru3Data[2, readCount - BcaCalPoints.bcaCalPointsNum].Value = "S READ";
									// Optional store back into cal data block - not sure this should be done however
									BcaCalPoints.sen3SCalPoint[readCount - BcaCalPoints.bcaCalPointsNum] = uiForm.lru3.senBoardFbValF;
								}

							}

							//// Wrap for static sensor values in table
							//if (++readCount >= BcaCalPoints.bcaCalPointsNum)
							//{
							//    readCount = 0;
							//}

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
