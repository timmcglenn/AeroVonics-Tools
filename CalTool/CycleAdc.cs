using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalTool
{
    class CyclePoints
    {
		//       public static double[] cyclePoints = {4000 };
		//		public static double[] cyclePoints = { 4000, 6000, 3000, 7000, 2000, 8000, 1000, 15000, -1000, 15000, -1000, 1000, -1000, 4000, 5000 };

		// Pure Vacuum for can
		public static double[] cyclePoints = {
			8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000,
			8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000,
			8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000,
			8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000, 8000, 15000,
			6000
		};
	}

	class CycleAdc
    {
        // State machine sates
        enum CYCLE_STATE { SET_TEST_POINT, WAIT_TEST_POINT };

        // State variables
        public static bool cycleRunning = false;

        static MainForm uiForm;
        static int currentState = 0;
        static int currentTestPoint = 0;

        // Accessors
        public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }

        // Cycle Start / Stop
        public static void setCycleRunningSate(bool run)
        {
            cycleRunning = run;
            if (run)
            {
                // Turn outputs off
                uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);

                // Start at beginning of table
                currentState = 0;
                currentTestPoint = 0;

                // Button color
                uiForm.bStartCycleSens.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                // Button color
                uiForm.bStartCycleSens.BackColor = System.Drawing.Color.Transparent;
            }
        }


        // State machine update
        public static void update()
        {
            string msg = "";

            // Get current state from running SM
            if (cycleRunning)
            {
                // General field updates
                uiForm.bADCTestPointNum.Text = (currentTestPoint + 1).ToString() + " OF " + CyclePoints.cyclePoints.Length.ToString();

                // Bca points
                msg = cycleStateMachine();

            }

            // General field updates


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
                cycleRunning = false;

                // Button color
                uiForm.bStartCycleSens.BackColor = System.Drawing.Color.DarkGreen;

                // Check for chain
                if (uiForm.cbChainCycleToCal.Checked)
                {
                    // Start Cal cycle
                    CalAdc.setCalRunningSate(true);
                }
            }
        }



        private static string cycleStateMachine()
        {
            switch (currentState)
            {
                case (int)CYCLE_STATE.SET_TEST_POINT:
                    {
                        // Check for end
                        if (currentTestPoint >= CyclePoints.cyclePoints.Length)
                        {
                            AdtsCom.setGround();
                            uiForm.bADCTestPointNum.Text = "Complete";
                            return ("end");
                        }
                        else
                        {
                            // Move to next
                            AdtsCom.setBca(CyclePoints.cyclePoints[currentTestPoint]);
                            AdtsCom.setIas(0.0);
                            return ("next");
                        }
                    }

                case (int)CYCLE_STATE.WAIT_TEST_POINT:
                    {
                        // Wait for move to complete
                        if (AdtsCom.getInMotion())
                            return ("wait");
                        else
                        {
                            // Go to next point
                            currentTestPoint++;

                            // Loop back in state machine
                            currentState = (int)CYCLE_STATE.SET_TEST_POINT;
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
