using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;
using System.Windows.Forms;

namespace CalTool
{
    class PosFixtureInit
    {
        public static string[] TG_INIT2 =
        {
            "$ej=0", // JSON Mode off
            "$ex=2", // Flow Control
			"$tv=1", // Verbose mode
			"$xvm=2000", // xMax rate (mm/min)
			"$yvm=2000", // yMax rate (mm/min)
			"$zvm=2000", // zMax rate (mm/min)
			"$xjm=20",   // xMax jerk (mm/min)
			"$yjm=20",   // yMax jerk (mm/min)
			"$zjm=20",   // zMax jerk (mm/min)
			//"$avm=1000", // aMax rate (deg/min)
			//"$bvm=1000", // bMax rate (deg/min)
			//"$cvm=1000", // cMax rate (deg/min)
            "{sr:f}", // No report data
			"{sr:{stat:t}}", // Just status data
            "$1ma=0",   // Motor 1 to yaw
            "$2ma=1",   // Motor 2 to roll
            "$3ma=2",   // Motor 3 to pitch
            //"$1ma=2",   // Match body axis
            //"$2ma=0",   //
            //"$3ma=1",   //
			//"$1ma=3",   // Motor 1 to A rotary axis
            //"$2ma=4",   // Motor 1 to B rotary axis
            //"$3ma=5",   // Motor 1 to C rotary axis
            "$xsv=500",  // Homing speed
            "$ysv=500",  // Homing speed
            "$zsv=500",  // Homing speed
            "$xlv=20",    // Homing latch backoff speed
            "$ylv=20",    // Homing latch backoff speed
            "$zlv=20",    // Homing latch backoff speed
            //"$1sa=0.9", // Step Angle of motor
            //"$2sa=0.9", // Step Angle of motor
            //"$3sa=0.9", // Step Angle of motor
            //"$4sa=0.9", // Step Angle of motor
            "$1sa=0.9", // Step Angle of motor
            "$2sa=0.9", // Step Angle of motor
            "$3sa=0.9", // Step Angle of motor
            "$1tr=60.0", // Travel ratio (10 to 60 tooth gearing)
            "$2tr=60.0", // Travel ratio (10 to 60 tooth gearing)
            "$3tr=60.0", // Travel ratio (10 to 60 tooth gearing)
            "$1po=1",   // Polarity (can also be done in wiring)
            "$2po=1",   // Polarity
            "$3po=1",   // Polarity
            "$1mi=8",   // Microstep
            "$2mi=8",   // Microstep
            "$3mi=8",   // Microstep
   //         "$aam=1",   // Axis A mode
   //         "$bam=1",   // Axis B mode
   //         "$cam=1",   // Axis C mode
            "$xam=1",   // Axis X mode
            "$yam=1",   // Axis Y mode
            "$zam=1",   // Axis Z mode
   //         "$atn=-180", // Axis A, min angle
   //         "$atm=+180", // Axis A, max angle
   //         "$btn=-180", // Axis B, min angle
   //         "$btm=+180", // Axis B, max angle
   //         "$ctn=-180", // Axis C, min angle
   //         "$ctm=+180", // Axis C, max angle
            "$xtn=-500", // Axis X, min angle (Supports homing)
            "$xtm=+500", // Axis X, max angle
            "$ytn=-500", // Axis Y, min angle
            "$ytm=+500", // Axis Y, max angle
            "$ztn=-500", // Axis Z, min angle
            "$ztm=+500", // Axis Z, max angle
//			"g10 l2 p2 x+183.0 y+91.85 z-109.10", // Cord system 2 (55), offset z: neg = pitch up
			"g10 l2 p2 x+183.0 y+91.75 z-109.70", // Cord system 2 (55), offset z: neg = pitch up
//			"g10 l2 p2 x+183.0 y+91.75 z-105.7", // Cord system 2 (55), offset z: neg = pitch up
            //"$xsn=1",   // X Homing Switch
            //"$xsx=0",   // X Homing Switch
            //"$ysn=1",   // Y Homing Switch
            //"$ysx=0",   // Y Homing Switch
            //"$zsn=1",   // Z Homing Switch
            //"$zsx=0",   // Z Homing Switch
            "$1pm=1",   // Motor 1 
			"$2pm=1",   // Motor 2 
			"$3pm=1",   // Motor 3
			"$4pm=0",   // Motor 4
			"g55"      // Enter G55 coordinate system

        }; // Motor 3 On
    }

    class PosFixture
    {

        // Constants
 //       private const int HANDSHAKECOUNT = 5;
        private const string TG_MOTOR_1_ON = "$1pm=1";          // Always on
        private const string TG_MOTOR_1_OFF = "$1pm=0";         // Always off

        private static SerialPort pFSerialPort;
        private static System.Timers.Timer handshakeTimer;
        private static bool handshakeRequest = false;
        private static bool handshakeok = false;

        // State variables
        static MainForm uiForm;
        static bool connected = false;
        static bool inMotion = false;
        static bool homingActive = false;

        // Start
        static PosFixture()
        {
            handshakeTimer = new System.Timers.Timer(8000);
            handshakeTimer.Elapsed += new ElapsedEventHandler(reqHandshake);
            handshakeTimer.AutoReset = true;
            handshakeTimer.Enabled = true;
        }


        // Accessors
        public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }
        public static bool getPortStatus()
        {
            return connected && handshakeok;
        }
        public static bool getInMotion()
        {
            return inMotion;
        }
        public static bool getInHomeMotion()
        {
            return homingActive;
        }
        public static void setDisconnect()
        {
            try
            {
                // Shutdown controller and serial port
                sendCommand(TG_MOTOR_1_OFF);
                //System.Threading.Thread.Sleep(1000);
                pFSerialPort.Close();
            }
            catch { };
        }

        public static void setPosition(string position)
        {
            sendCommand("G0 " + position);
            inMotion = true;
        }
		public static void setStop()
        {
            sendCommand("!");
        }

        public static void setHomeStart()
        {
            sendCommand("G28.2 X0 Y0 Z0");

			System.Threading.Thread.Sleep(500);
            homingActive = true;
        }

		public static void setControllerInit()
		{
			// Initialize controller state
			sendCommand("$defa=1");   // Reset
			sendCommand("\u0018");
			System.Threading.Thread.Sleep(6000);
			foreach (string s in PosFixtureInit.TG_INIT2)
			{
				sendCommand(s);
				System.Threading.Thread.Sleep(200);
			}
		}


		// Update
		public static void update()
        {

            // Check for connection
            checkPortConnection(uiForm);

            // Additional Processing
            checkHandshake();

            // Parse any feedback
            checkFeedback();

            if (homingActive && !inMotion)
            {
                //setHomeEnd();
            }
        }


        // Maintain COM Port Connection State
        private static void checkPortConnection(MainForm form)
        {
            //string[] TG_INIT = new string[]
            //{	"$defa", // Defaults
            //	"$ej=0", // JSON Mode off
            //	"$tv=1", // Verbose mode
            //	"$xvm=10000", // xMax rate
            //	"{sr:f}", // No report data
            //	"{sr:{stat:t}}", // Just status data
            //	"$1pm=1" };	// Motor 1 On

            if (!connected)
            {
                // Try to connect to selected port
                pFSerialPort = new SerialPort();
                pFSerialPort.PortName = form.getPfPort();   // User selected port from main form
                pFSerialPort.BaudRate = 115200;
                pFSerialPort.DataBits = 8;
                pFSerialPort.Parity = 0;
                pFSerialPort.ReadTimeout = 10;
                pFSerialPort.WriteTimeout = 10;
//                pFSerialPort.Handshake = Handshake.XOnXOff;
                pFSerialPort.Handshake = Handshake.RequestToSend;
                try
                {
                    pFSerialPort.Open();
                    connected = true;
                    handshakeok = true;
                    uiForm.setConsoleText("PF", "COM PORT OPENED\n");

                }
                catch
                {
                    connected = false;
                    uiForm.setConsoleText("PF", "COM PORT FAIL\n");
                }

            }
            else
            {
                // Check to make sure connection is still valid
                if (!pFSerialPort.IsOpen)
                {
                    // Was connected, port failed for some reason
                    connected = false;
                }
            }

        }

        // Check for handshake required
        private static void checkHandshake()
        {
            // Handshake if no activity
            if ((handshakeRequest == true) && (connected))
            {
                // Send blank line - causes ok response
                sendCommand(" \n");
                handshakeRequest = false;
                uiForm.setConsoleText("PF", "HANDSHAKE REQUESTED\n");

                // Assume that if a timeout has occured, motion has stopped
                // (The motion stop response was missed from the serial status stream)
                inMotion = false;
            }
        }
        private static void reqHandshake(object sender, ElapsedEventArgs e)
        {
            handshakeRequest = true;
        }


        // Check for status feedback from controller
        private static void checkFeedback()
        {
            string line;
            do
            {
                line = readLine();
                if (line != null)
                {
                    // Has motion stopped
                    if (line.IndexOf("stat:3") != -1)
                    {
                        // Stopped status found
                        inMotion = false;
                        uiForm.setConsoleText("PF", "STOPPED DETECTED\n");

						// If this was homing sequence, move to 0,0,0 in G55 cord system
						if (homingActive)
						{
							sendCommand("G55");
							setPosition("X0 Y0 Z0");
							homingActive = false;
						}

                    }
                    else if (line.Trim().EndsWith("ok>"))
                    {
                        uiForm.setConsoleText("PF", "HANDSHAKE RECEIVED\n");
                        handshakeok = true;
                    }

                    // Receiving data - Reset handshake time
                    handshakeTimer.Stop();
                    handshakeTimer.Start();
                    handshakeRequest = false;
                }

            } while (line != null);


        }

        // Send command to controller
        private static void sendCommand(string msg)
        {
            try
            {
                //pFSerialPort.DiscardInBuffer();
                pFSerialPort.DiscardOutBuffer();
                pFSerialPort.Write(msg + "\n");
                uiForm.setConsoleText("PF", ">" + msg);
            }
            catch { }
        }

        // Read status line from controller
        private static string readLine()
        {
            try
            {
                string line = pFSerialPort.ReadLine();
                uiForm.setConsoleText("PF", "<" + line);
                return line;
            }
            catch
            {
                return null;
            }
        }

    }
}
