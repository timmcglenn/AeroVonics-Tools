using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

namespace CalTool
{
	public class Lru
	{

		// Private state variables
		private int lruIndexNum;
		private SerialPort serialPort;
		private Timer handshakeTimer;
		private MainForm uiForm;
		private bool connected;
		private bool handshakeok;
		private bool handshakeRequest;
		private char[] outMess;
		private char[] recBuffer;
		private float returnVal;


		public string selectedComPort;
		public bool returnReady;


		public Lru(int index)
		{
			lruIndexNum = index;
			connected = false;
			handshakeok = false;
			handshakeRequest = false;

			handshakeTimer = new Timer(5000);
			handshakeTimer.Elapsed += new ElapsedEventHandler(reqHandshake);
			handshakeTimer.AutoReset = true;
			handshakeTimer.Enabled = true;

			outMess = new char[10];
			recBuffer = new char[500];
			returnReady = false;

		}

		// Accessors
		public void setParentForm(MainForm tform)
		{
			uiForm = tform;
		}
		public bool getPortStatus()
		{
			return connected && handshakeok;
		}
		public void setParameterReq(int _parameter)
		{
			outMess[0] = (char)_parameter;
			sendCommand(outMess);
		}
		public float getParameterVal()
		{
			returnReady = false;
			return returnVal;
		}

		// Update
		public void update()
		{

			// Check for connection
			checkPortConnection(uiForm);

			// Additional Processing
			checkHandshake();

			// Parse any feedback
			checkFeedback();


		}


		// Maintain COM Port Connection State
		private void checkPortConnection(MainForm form)
		{
			if (!connected)
			{
				try
				{
					// Try to connect to selected port
					serialPort = new SerialPort();
					serialPort.PortName = selectedComPort;
					serialPort.BaudRate = 57600;
					serialPort.DataBits = 8;
					serialPort.Parity = 0;
					serialPort.ReadTimeout = 10;
					serialPort.WriteTimeout = 10;
					serialPort.Handshake = Handshake.None;
					serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

					serialPort.Open();
					connected = true;
					handshakeok = true;
					uiForm.setConsoleText("LRU" + lruIndexNum, "COM PORT OPENED\n");
				}
				catch
				{
					connected = false;
					uiForm.setConsoleText("LRU" + lruIndexNum, "COM PORT FAIL\n");
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
		private void checkHandshake()
		{
			// Handshake if no activity
			if ((handshakeRequest == true) && (connected))
			{
				// Send blank line - causes ok response
				outMess[0] = (char)10;
				sendCommand(outMess);
				handshakeRequest = false;
				uiForm.setConsoleText("LRU" + lruIndexNum, "HANDSHAKE REQUESTED\n");
			}
		}
		private void reqHandshake(object sender, ElapsedEventArgs e)
		{
			handshakeRequest = true;
		}




		// Check for status feedback from controller
		private void checkFeedback()
		{

			//response = readResponse();
			//DataReceivedHandler(this, null);
			if (returnReady)
			{
				float val = getParameterVal();
				if (val == 12.34f)
				{
					handshakeok = true;
					handshakeTimer.Stop();
					handshakeTimer.Start();
					handshakeRequest = false;
					uiForm.setConsoleText("LRU" + lruIndexNum, "HANDSHAKE RECEIVED");

				}
			}



		}
		
		// Send command to lru
		private void sendCommand(char[] msg)
		{
			try
			{
				//serialPort.DiscardInBuffer();
				serialPort.DiscardOutBuffer();
				serialPort.Write(msg, 0, 1);
				returnReady = false;
				uiForm.setConsoleText("LRU" + lruIndexNum, ">" + msg);
			}
			catch { }
		}

		// Read status line from lru
		private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			int count;
			if (serialPort.BytesToRead > 4)
			{
				byte[] buffer = new byte[4];
				count = serialPort.Read(buffer, 0, 4);
				returnVal = BitConverter.ToSingle(buffer, 0);
				returnReady = true;

			}
		}



	}
}
