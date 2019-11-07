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

	// Serial parameters

	public enum PARAM {
		// Must match embedded side:
		NONE, STATUS, ROLL, PITCH, YAW, BCA, IAS, OAT, TAS, AOA,
		VOLTS, SENP, SENS, MAGX, MAGY, MAGZ, TEMPP, TEMPS, CMDPH, CMDSH,
		BTEMP, GYROXR, GYROYR, GYROZR, ACCELXR, ACCELYR, ACCELZR, OIT0, OIT1, OIT2,
		RPYWEIGHT, BIASWEIGHT, GYROXC, GYROYC, GYROZC, ACCELXC, ACCELYC, ACCELZC, ALIGNCNT,
		AHRSRPYGATE, AHRSBGATE, UPDATERATE, YAWT, GYROXSUM, GYROYSUM, GYROZSUM,
		OI0, OI1, OI2, FIFOCOUNT, ROLLRATE, PITCHRATE, YAWRATE, AMBLIGHT, ALLBTN,
		FLUSH = 99
	}
	public class ENG
    {
        public const string PHFF = "01";        // Pitot heater feed forward
        public const string PHPG = "02";        // Pitot heater pgain
        public const string PHIG = "03";        // Pitot heater igain
        public const string PHDG = "04";        // Pitot heater dgain
		public const string FRGM = "05";        // Free gyro mode
		public const string ARES = "06";        // AHRS Reset
		public const string SCLR = "07";        // Gyro Sum Clear
		public const string PAGE = "08";        // Goto Page Number


	}
	public class RATE
    {
        public const string RATE_0HZ = "00";
        public const string RATE_50HZ = "01";
		public const string RATE_25HZ = "02";
		public const string RATE_10HZ = "05";
        public const string RATE_5HZ = "10";
        public const string RATE_1HZ = "50";
    }

	public class STATUS
	{
		public const int PITOT_TEMP_STABLE = 1;
		public const int STATIC_TEMP_STABLE = 2;
		public const int AHRS_STABLE = 4;
	}

	public class PREF
	{
		public const string PREF_SN = "00";			// Serial Number
		public const string PREF_BG_COLOR = "01";   // Background Color
	}

	public class LruCom
    {
        // Constants
        private const int HANDSHAKE_TIMEOUT = 30;
		public const int COM_DELAY = 10;           // Delay for communication

		// Public interfaces
		public double[] dataParam = new double[Enum.GetNames(typeof(PARAM)).Length];

		//public double gyroXraw, gyroYraw, gyroZraw;
        public int status;
        public double senBoardFbValF;
        public int senBoardFbValI;
        public bool returnReady;
        public string selectedComPort;
        public bool connected = false;


        // Private variables
        private SerialPort serialPort;
        private int lruIndexNum;
        int timeout = HANDSHAKE_TIMEOUT;

        // Instantiation
        public LruCom(int index)
        {
            lruIndexNum = index;
            connected = false;
        }

        // Accessors
        //public void setParentForm(MainForm tform)
        //{
        //    uiForm = tform;
        //}
        public bool getPortStatus()
        {
            return connected;
        }
        public void setDisconnect()
        {
            try
            {
                serialPort.Close();
            }
            catch { };
        }
        public void setParameterReq(int parameter, string rate)
        {
            // ($out=xx,yy)
            try
            {
				serialPort.WriteLine("\n\r");	// TODO not sure why this is needed - will not switch without second press
				serialPort.WriteLine("$out=" + parameter.ToString("00") + "," + rate + "\n\r");

			}
            catch
            {
                MessageBox.Show("Serial Write Error");
            }
            returnReady = false;
        }


        public void setCalWriteI(int parameter, int value)
        {
			// ($calwi=xx,yyyyyy)
			// TODO look at sign
			serialPort.WriteLine("$calwi=" + parameter.ToString("D2") + "," + value.ToString("00000") + "\n\r");
			returnReady = false;
        }
        public void setCalWriteF(int parameter, double value)
        {
			// ($calwf=xx,yyyy.yy)
			// TODO look at sign
			//serialPort.WriteLine("$calwf=" + parameter.ToString("D2") + "," + value.ToString("0000.00") + "\n\r");
			serialPort.WriteLine("$calwf=" + parameter.ToString("D2") + "," + value.ToString("0000.00000") + "\n\r");
			returnReady = false;
        }
        public void setCalReadI(int parameter)
        {
            // ($calri=xx)
            serialPort.WriteLine("$calri=" + parameter.ToString("D2") + "\n\r");
            returnReady = false;
        }
        public void setCalReadF(int parameter)
        {
            // ($calrf=xx)
            serialPort.WriteLine("$calrf=" + parameter.ToString("D2") + "\n\r");
			returnReady = false;
        }

        public void setEngWriteF(string parameter, double value)
        {
			// ($engwf=xx,yyyy.yy)
			// TODO look at sign
			serialPort.WriteLine("$engwf=" + parameter + "," + value.ToString("0000.00") + "\n\r");
			returnReady = false;
        }

		public void setPrefWriteI(string parameter, int value)
		{
			// ($prefwi=xx,yyyy..)
			serialPort.WriteLine("$prefwi=" + parameter + "," + value.ToString() + "\n\r");
		}

		// Update
		public void update()
        {
            // Check for connection
            checkPortConnection();

            // Check for handshake
 //           checkHandshake();

            // Parse any feedback
            if (connected) checkFeedback();
//            checkFeedback();

        }


        // Maintain COM Port Connection State
        private void checkPortConnection()
        {
            if (!connected)
            {
                // See if there is a selected port
                if (selectedComPort != null)
                {
                    // Try to connect to selected port
                    serialPort = new SerialPort();
                    serialPort.PortName = selectedComPort;
                    serialPort.BaudRate = 115200;
					serialPort.DataBits = 8;
                    serialPort.Parity = 0;
                    serialPort.ReadTimeout = 0;
                    serialPort.WriteTimeout = 10;
                    serialPort.Handshake = Handshake.None;
                    serialPort.DtrEnable = true;
                    serialPort.RtsEnable = true;

                    try
                    {
                        serialPort.Open();
                        connected = true;
 //                       uiForm.setConsoleText("LRU" + lruIndexNum, ">" + "COM PORT OPENED\n");
                    }
                    catch
                    {
                        connected = false;
                    }
                }
            }
            else
            {
                // Check to make sure connection is still valid
                if (!serialPort.IsOpen)
                {
                    // Was connected, port failed for some reason
                    connected = false;
                }
            }
        }


        private void checkHandshake()
        {
            if (connected)
            {
                if (--timeout == 0)
                {
                    // Com link has gone stale
                    connected = false;
                }
                if (timeout < HANDSHAKE_TIMEOUT / 2)
                {
                    // No com activity, force handshake
                    serialPort.WriteLine("\n\r");
                }
            }
        }

        // Check for feedback
        private void checkFeedback()
        {
            string line;
			int numVal;

            do
            {
                line = readLine();
                if ((line != null) && (line.Length > 3))
                {
					// Incoming data format: xx=xx.xxxx
					string temp = line.Substring(0,2);
					try
					{
						numVal = Int32.Parse(temp);
					}
					catch
					{
						numVal = -1;
					}
					if ((numVal > 0) && (numVal < Enum.GetNames(typeof(PARAM)).Length))
					{
						// Parse value as float
						 Double.TryParse(line.Substring(3), out dataParam[numVal]);
					}

					// General feedback float value (f=xxx.xxxx?)
					else if (line.StartsWith("f"))
                    {
                        bool res = Double.TryParse(line.Substring(2), out senBoardFbValF);
                        returnReady = true;
                    }

                    // General feedback uint value (i=xxxx?)
                    else if (line.StartsWith("i"))
                    {
                        bool res = Int32.TryParse(line.Substring(2), out senBoardFbValI);
                        returnReady = true;
                    }

                }

            } while (line != null);
        }

        // Read status line from controller
        private string readLine()
        {
            try
            {
                string line = serialPort.ReadLine();

//                uiForm.setConsoleText("LRU" + lruIndexNum, ">Data Received: " + line);
                return line;
            }
            catch
            {
                return null;
            }
        }
    }
}

