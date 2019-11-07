using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

namespace AhrsDisplayDemo
{

    class AhrsComInit
    {
        public static string[] TG_INIT2 =
        {   "PM=3", // Pitot Control Mode
			"SM=3", // Static Control Mode
			"GG",	// Go to ground
		};
    }

    class AhrsCom
    {

        private static SerialPort serialPort;
        private static Timer handshakeTimer;
        private static bool handshakeRequest = false;
        private static bool handshakeok = false;

        // State variables
        static MainForm uiForm;
        static bool connected = false;
        static bool inMotion = false;
        public static double targetIas;
        public static double targetBca;
        public static double actualIas;
        public static double actualBca;
        public static bool vented;

        private static int dataRequestType;

        // Start
        static AhrsCom()
        {
            handshakeTimer = new Timer(100);
            handshakeTimer.Elapsed += new ElapsedEventHandler(reqHandshake);
            handshakeTimer.AutoReset = true;
            handshakeTimer.Enabled = true;
            dataRequestType = 1;
            vented = true;
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

        public static void setDisconnect()
        {
            try
            {
                serialPort.Close();
            }
            catch { };
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


        }


        // Maintain COM Port Connection State
        private static void checkPortConnection(MainForm form)
        {

            if (!connected)
            {

                // See if there is a selected port
                if (MainForm.AdSelectedPort.IndexOf("COM") >= 0)
                {
                    // Try to connect to selected port
                    serialPort = new SerialPort();
                    serialPort.PortName = MainForm.AdSelectedPort;   // User selected port from main form
                    serialPort.BaudRate = 9600;
                    serialPort.DataBits = 8;
                    serialPort.Parity = 0;
                    serialPort.ReadTimeout = 10;
                    serialPort.WriteTimeout = 10;
                    serialPort.Handshake = Handshake.XOnXOff;
                    serialPort.DtrEnable = true;
                    serialPort.RtsEnable = true;

                    try
                    {
                        serialPort.Open();
                        connected = true;
                        handshakeok = true;
                        uiForm.setConsoleText("AD", "COM PORT OPENED\n");

                        // Initialize controller state
                        foreach (string s in AhrsComInit.TG_INIT2)
                        {
                            sendCommand(s);
                            uiForm.setConsoleText("AD", "INIT STRING:" + s + "\n");
                            System.Threading.Thread.Sleep(200);

                        }


                    }
                    catch
                    {
                        connected = false;
                        uiForm.setConsoleText("AD", "COM PORT FAIL\n");
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


        // Check for handshake required
        private static void checkHandshake()
        {
            // Handshake if no activity
            if ((handshakeRequest == true) && (connected))
            {
                // Toggle data type request
                if (dataRequestType == 1)
                    dataRequestType = 2;
                else
                    dataRequestType = 1;

                // Ias Request
                if (dataRequestType == 1)
                {
                    sendCommand("PA");
                    uiForm.setConsoleText("AD", "IAS STAT REQ\n");
                }
                // Bca Request
                else if (dataRequestType == 2)
                {
                    sendCommand("SA");
                    uiForm.setConsoleText("AD", "BCA STAT REQ\n");
                }

                handshakeRequest = false;

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

                    // Ias response
                    if (dataRequestType == 1)
                        actualIas = Double.Parse(line);
                    // Bca Response
                    else if (dataRequestType == 2)
                        actualBca = Double.Parse(line);

                    // Has motion stopped?
                    if ((actualIas == targetIas) && (actualBca == targetBca))
                    {
                        // Stopped status found
                        inMotion = false;
                        uiForm.setConsoleText("AD", "TARGET REACHED\n");

                    }
                    // Handshake - Invalid command is only handshake possible
                    if (line.Trim() == "19")
                    {
                        uiForm.setConsoleText("AD", "HANDSHAKE RECEIVED\n");
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
                //serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(msg + "\r");
                uiForm.setConsoleText("AD", ">" + msg);
            }
            catch
            {
                uiForm.setConsoleText("AD", "WRITE ERROR\n");
            }
        }

        // Read status line from controller
        private static string readLine()
        {
            try
            {
                string line = serialPort.ReadLine();
                uiForm.setConsoleText("AD", "<" + line);
                return line;
            }
            catch
            {
                return null;
            }
        }

    }

}
