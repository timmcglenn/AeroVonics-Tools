using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CalTool
{
    class SerialNum
    {
        // Constants
        private const int FLASH_LOC_SN = 1;     // Serial number location

        // State machine sates
        enum SN_STATE { WRITE_SN, REQUEST_SN, WAIT_SN, READ_SN, VIEW_SN };

        // Variables
        static MainForm uiForm;
        static bool[] writeRequest = new bool[4];
        static int[] lruSnToWrite = new int[4];
        static bool newRequest = false;
        static bool stateMachineRunning = false;
        static int currentState = 0;

        // Accessors
        public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }


        public static void setSerialNum(int lru, int serialNum)
        {
            lruSnToWrite[lru] = serialNum;
            writeRequest[lru] = true;
            newRequest = true;
        }

        public static void setSerialNumRead(int lru)
        {
            stateMachineRunning = true;
            currentState = (int)SN_STATE.REQUEST_SN;
			newRequest = true;

		}

        public static void update()
        {
            string msg = "";

            // Look for new requests to set sn
            if (newRequest)
            {
                // Turn off outputs
                uiForm.lru0.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
				Thread.Sleep(1000);

				// Start state machine to process serial number write / confirmation
				stateMachineRunning = true;
                currentState = 0;
                newRequest = false;
            }

            // Update state machine
            if (stateMachineRunning)
            {
                msg = snStateMachine();
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
                stateMachineRunning = false;
            }
        }


        private static string snStateMachine()
        {
            switch (currentState)
            {
                case (int)SN_STATE.WRITE_SN:
                    {
                        uiForm.lru0.setCalWriteI(FLASH_LOC_SN, lruSnToWrite[0]);
						Thread.Sleep(100);
						return ("next");
                    }
                case (int)SN_STATE.REQUEST_SN:
                    {
                        uiForm.lru0.setCalReadI(FLASH_LOC_SN);
						Thread.Sleep(100);
						return ("next");
                    }
                case (int)SN_STATE.WAIT_SN:
                    {
                        // See if value is back
                        // TODO address sign
                        if (!uiForm.lru0.returnReady)
                        {
							Thread.Sleep(100);
							return ("wait");
                        }
                        else
                        {
							Thread.Sleep(100);
							// uiForm.lbLru0Sn.Text = uiForm.lru0.senBoardFbValI.ToString("00000");
							uiForm.tbLru0SetSn.Text = uiForm.lru0.senBoardFbValI.ToString("00000");
							// For ATP page
							uiForm.tbAtpSnLru0.Text = uiForm.tbLru0SetSn.Text;

							return ("end");
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



