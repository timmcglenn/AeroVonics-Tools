using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalTool
{
    class BrdTest
    {
        // Constants
        const double NOISE_GAIN = 30;
        const int DATA_HOLD = 5;
        const int FILTER_COUNT = 2;

        const int FILTER_G0_NOISE_AVERAGE = 0;
        const int FILTER_G1_NOISE_AVERAGE = 1;

        // State variables
        static MainForm uiForm;
        static bool connected;
        static CalTool.LruCom thisLru;

        // Gyro 0 Noise
        static double[] gyro0XAverage = new double[50];
        static int gyro0XAverageIndex = 0;
        static int gyro0XPeakNoise = 0;
        static double[] gyro0YAverage = new double[50];
        static int gyro0YAverageIndex = 0;
        static int gyro0YPeakNoise = 0;
        static double[] gyro0ZAverage = new double[50];
        static int gyro0ZAverageIndex = 0;
        static int gyro0ZPeakNoise = 0;

        // Gyro 1 Noise
        static double[] gyro1XAverage = new double[50];
        static int gyro1XAverageIndex = 0;
        static int gyro1XPeakNoise = 0;
        static double[] gyro1YAverage = new double[50];
        static int gyro1YAverageIndex = 0;
        static int gyro1YPeakNoise = 0;
        static double[] gyro1ZAverage = new double[50];
        static int gyro1ZAverageIndex = 0;
        static int gyro1ZPeakNoise = 0;

        static double gyro0NoiseAverage = 0;
        static double gyro1NoiseAverage = 0;



        // Accessors
        public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }

		public static void setBoardDefaults()
		{
			if (uiForm.cbBrdLruSelect.SelectedIndex >= 0)
			{
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU0"))
					uiForm.lru0.setEngWriteF(ENG.DEF, 0);
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU1"))
					uiForm.lru1.setEngWriteF(ENG.DEF, 0);
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU2"))
					uiForm.lru2.setEngWriteF(ENG.DEF, 0);
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU3"))
					uiForm.lru3.setEngWriteF(ENG.DEF, 0);
			}
		}

		public static void connect()
        {
            connected = true;

			setLruNumber();
			
			thisLru.setParameterReq((int) PARAM.NONE, RATE.RATE_0HZ);
            thisLru.setParameterReq((int) PARAM.STATUS, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.VOLTS, RATE.RATE_1HZ);
			thisLru.setParameterReq((int) PARAM.BATVOLTS, RATE.RATE_1HZ);
			thisLru.setParameterReq((int) PARAM.OATC, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.OATRAW, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.AMBLIGHT, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.BTEMP, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.ALLBTN, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.TEMPP, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.TEMPS, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.SENP, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.SENS, RATE.RATE_1HZ);
            thisLru.setParameterReq((int) PARAM.GYROXR0, RATE.RATE_5HZ);
            thisLru.setParameterReq((int) PARAM.GYROYR0, RATE.RATE_5HZ);
            thisLru.setParameterReq((int) PARAM.GYROZR0, RATE.RATE_5HZ);
            thisLru.setParameterReq((int) PARAM.GYROXR1, RATE.RATE_5HZ);
            thisLru.setParameterReq((int) PARAM.GYROYR1, RATE.RATE_5HZ);
            thisLru.setParameterReq((int) PARAM.GYROZR1, RATE.RATE_5HZ);

   			 
			mFilterSetTc(FILTER_G0_NOISE_AVERAGE, 100);
			mFilterSetTc(FILTER_G1_NOISE_AVERAGE, 100);

		}

		public static void disconnect()
		{
			connected = false;
			uiForm.btBrdConnect.BackColor = System.Drawing.Color.Gray;
			thisLru.setParameterReq((int)PARAM.NONE, RATE.RATE_0HZ);
		}


		// Filter variables
		static double[] currentVal = new double[FILTER_COUNT];
		static double[] accumVal = new double[FILTER_COUNT];
		static double[] newVal = new double[FILTER_COUNT];
		static double[] timeConst = new double[FILTER_COUNT];

		static void mFilterUpdate()
		{
			for (int i = 0; i < FILTER_COUNT; i++)
			{
				currentVal[i] = accumVal[i] / timeConst[i];
				accumVal[i] += newVal[i] - currentVal[i];
			}
		}
		static void mFilterSetTc(int filterNumber, double tc)
		{
			timeConst[filterNumber] = tc;
			newVal[filterNumber] = 0.0;
			currentVal[filterNumber] = 0.0;
			accumVal[filterNumber] = 0.0;
		}
		static double mFilterGetValue(int filterNumber, double newValue)
		{
			newVal[filterNumber] = newValue;
			return currentVal[filterNumber];
		}


		static void setLruNumber()
		{
			// Default 
			thisLru = uiForm.lru0;
			if (uiForm.cbBrdLruSelect.SelectedIndex >= 0)
			{
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU0"))
				{
					thisLru = uiForm.lru0;
					if (uiForm.cbLru0Use.Checked)
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Green;
					else
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Gray;
				}
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU1"))
				{
					thisLru = uiForm.lru1;
					if (uiForm.cbLru1Use.Checked)
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Green;
					else
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Gray;
				}
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU2"))
				{
					thisLru = uiForm.lru2;
					if (uiForm.cbLru2Use.Checked)
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Green;
					else
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Gray;
				}
				if (string.Equals(uiForm.cbBrdLruSelect.Items[uiForm.cbBrdLruSelect.SelectedIndex].ToString(), "LRU3"))
				{
					thisLru = uiForm.lru3;
					if (uiForm.cbLru3Use.Checked)
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Green;
					else
						uiForm.btBrdConnect.BackColor = System.Drawing.Color.Gray;

				}
			}




		}

		public static void clearNoise()
		{
			for (int gyro = 1; gyro < gyro0XAverage.Length; gyro++)
			{
				gyro0XAverage[gyro] = gyro0XAverage[gyro - 1];
				gyro0YAverage[gyro] = gyro0YAverage[gyro - 1];
				gyro0ZAverage[gyro] = gyro0ZAverage[gyro - 1];
				gyro1XAverage[gyro] = gyro1XAverage[gyro - 1];
				gyro1YAverage[gyro] = gyro1YAverage[gyro - 1];
				gyro1ZAverage[gyro] = gyro1ZAverage[gyro - 1];

			}

		}
		public static void noiseRefresh()
		{

			gyro0NoiseAverage = 0;
			gyro1NoiseAverage = 0;
		}


		// State machine update
		public static void update()
		{
			if (connected == true)
			{
				double temp;
				int tempi;


				setLruNumber();

				// Volts
				temp = thisLru.dataParam[(int)PARAM.VOLTS];
				uiForm.btBrdVoltsIn.Text = temp.ToString("00.0");
				if ((temp < 10) || (temp > 15))
					uiForm.btBrdVoltsIn.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btBrdVoltsIn.BackColor = System.Drawing.Color.Green;
				
				// Battery Volts
				temp = thisLru.dataParam[(int)PARAM.BATVOLTS];
				uiForm.btBrdBatVolts.Text = temp.ToString("00.0");
				if ((temp < 3) || (temp > 9))
					uiForm.btBrdBatVolts.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btBrdBatVolts.BackColor = System.Drawing.Color.Green;

				// Board temp
				temp = thisLru.dataParam[(int)PARAM.BTEMP];
				uiForm.btBrdBoardTemp.Text = temp.ToString("00.0");
				if ((temp < 10) || (temp > 90))
					uiForm.btBrdBoardTemp.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btBrdBoardTemp.BackColor = System.Drawing.Color.Green;

				// OAT Raw A/D
				temp = thisLru.dataParam[(int)PARAM.OATRAW];
				uiForm.btBrdOat.Text = temp.ToString("0000.0");
				if ((temp < 5) || (temp > 20)) // A/D with no probe connected
					uiForm.btBrdOat.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btBrdOat.BackColor = System.Drawing.Color.Green;

				// Ambient Light
				temp = thisLru.dataParam[(int)PARAM.AMBLIGHT];
				uiForm.btBrdAmbLight.Text = temp.ToString("00.0");
				if ((temp < 500) || (temp > 4095))
					uiForm.btBrdAmbLight.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btBrdAmbLight.BackColor = System.Drawing.Color.Green;

				// Buttons
				tempi = (int)thisLru.dataParam[(int)PARAM.ALLBTN];
				// Func
				if ((tempi & 0x04) > 0)
					uiForm.btBrdButttonFnc.BackColor = System.Drawing.Color.Green;
				else
					uiForm.btBrdButttonFnc.BackColor = System.Drawing.Color.Gray;
				// Left
				if ((tempi & 0x02) > 0)
					uiForm.btBrdButtonLeft.BackColor = System.Drawing.Color.Green;
				else
					uiForm.btBrdButtonLeft.BackColor = System.Drawing.Color.Gray;
				// Right
				if ((tempi & 0x01) > 0)
					uiForm.btBrdButtonRight.BackColor = System.Drawing.Color.Green;
				else
					uiForm.btBrdButtonRight.BackColor = System.Drawing.Color.Gray;

				// P Heater
				temp = thisLru.dataParam[(int)PARAM.TEMPP];
				uiForm.btPHeater.Text = temp.ToString("00.0");
				if ((temp < 60) || (temp > 70))
					uiForm.btPHeater.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btPHeater.BackColor = System.Drawing.Color.Green;

				// S Heater
				temp = thisLru.dataParam[(int)PARAM.TEMPS];
				uiForm.btSHeater.Text = temp.ToString("00.0");
				if ((temp < 60) || (temp > 70))
					uiForm.btSHeater.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btSHeater.BackColor = System.Drawing.Color.Green;


				// P Sensor Pressure
				temp = thisLru.dataParam[(int)PARAM.SENP];
				uiForm.btPSen.Text = temp.ToString("00.0");
				if ((temp < 700) || (temp > 900))
					uiForm.btPSen.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btPSen.BackColor = System.Drawing.Color.Green;

				// S Sensor Pressure
				temp = thisLru.dataParam[(int)PARAM.SENS];
				uiForm.btSSen.Text = temp.ToString("00.0");
				if ((temp < 700) || (temp > 900))
					uiForm.btSSen.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btSSen.BackColor = System.Drawing.Color.Green;


				// Gyro X0
				temp = thisLru.dataParam[(int)PARAM.GYROXR0] * 10.0;
				uiForm.btGyroX0.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroX0.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroX0.BackColor = System.Drawing.Color.Green;
				gyro0XAverage[gyro0XAverageIndex] = temp;
				// Gyro Y0
				temp = thisLru.dataParam[(int)PARAM.GYROYR0] * 10.0;
				uiForm.btGyroY0.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroY0.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroY0.BackColor = System.Drawing.Color.Green;
				gyro0YAverage[gyro0YAverageIndex] = temp;
				// Gyro Z0
				temp = thisLru.dataParam[(int)PARAM.GYROZR0] * 10.0;
				uiForm.btGyroZ0.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroZ0.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroZ0.BackColor = System.Drawing.Color.Green;
				gyro0ZAverage[gyro0ZAverageIndex] = temp;


				// Gyro X1
				temp = thisLru.dataParam[(int)PARAM.GYROXR1] * 10.0;
				uiForm.btGyroX1.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroX1.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroX1.BackColor = System.Drawing.Color.Green;
				gyro1XAverage[gyro1XAverageIndex] = temp;
				// Gyro Y1
				temp = thisLru.dataParam[(int)PARAM.GYROYR1] * 10.0;
				uiForm.btGyroY1.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroY1.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroY1.BackColor = System.Drawing.Color.Green;
				gyro1YAverage[gyro1YAverageIndex] = temp;
				// Gyro Z1
				temp = thisLru.dataParam[(int)PARAM.GYROZR1] * 10.0;
				uiForm.btGyroZ1.Text = temp.ToString("00.00");
				//if (temp == 0)
				//	uiForm.btGyroZ1.BackColor = System.Drawing.Color.Red;
				//else
					uiForm.btGyroZ1.BackColor = System.Drawing.Color.Green;
				gyro1ZAverage[gyro1ZAverageIndex] = temp;


				double average, noise;

				//
				// Gyro 0 Noise
				//
				// X0
				average = gyro0XAverage.Average();
				uiForm.btGyro0XAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro0XAverage[gyro0XAverageIndex]);
				noise *= NOISE_GAIN;
				noise = Math.Min(100, noise);
				gyro0NoiseAverage = gyro0XPeakNoise;
				if (noise > gyro0XPeakNoise)
					gyro0XPeakNoise = (int)noise;
				gyro0XPeakNoise--;
				gyro0XPeakNoise = Math.Min(100, gyro0XPeakNoise);
				gyro0XPeakNoise = Math.Max(0, gyro0XPeakNoise);
				uiForm.pbGyro0X.Value = gyro0XPeakNoise;
				uiForm.btGyro0XAverage.Text = gyro0XPeakNoise.ToString("00.00");
				if (gyro0XPeakNoise > 50)
					uiForm.btGyro0XAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro0XAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro0XAverageIndex >= gyro0XAverage.Length)
					gyro0XAverageIndex = 0;

				// Y0 
				average = gyro0YAverage.Average();
				uiForm.btGyro0YAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro0YAverage[gyro0YAverageIndex]);
				noise *= NOISE_GAIN;
				gyro0NoiseAverage += gyro0YPeakNoise / 2;
				noise = Math.Min(100, noise);
				if (noise > gyro0YPeakNoise)
					gyro0YPeakNoise = (int)noise;
				gyro0YPeakNoise--;
				gyro0YPeakNoise = Math.Min(100, gyro0YPeakNoise);
				gyro0YPeakNoise = Math.Max(0, gyro0YPeakNoise);
				uiForm.pbGyro0Y.Value = gyro0YPeakNoise;
				uiForm.btGyro0YAverage.Text = gyro0YPeakNoise.ToString("00.00");
				if (gyro0YPeakNoise > 50)
					uiForm.btGyro0YAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro0YAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro0YAverageIndex >= gyro0YAverage.Length)
					gyro0YAverageIndex = 0;

				// Z0
				average = gyro0ZAverage.Average();
				uiForm.btGyro0ZAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro0ZAverage[gyro0ZAverageIndex]);
				noise *= NOISE_GAIN;
				gyro0NoiseAverage += gyro0ZPeakNoise / 2;
				noise = Math.Min(100, noise);
				if (noise > gyro0ZPeakNoise)
					gyro0ZPeakNoise = (int)noise;
				gyro0ZPeakNoise--;
				gyro0ZPeakNoise = Math.Min(100, gyro0ZPeakNoise);
				gyro0ZPeakNoise = Math.Max(0, gyro0ZPeakNoise);
				uiForm.pbGyro0Z.Value = gyro0ZPeakNoise;
				uiForm.btGyro0ZAverage.Text = gyro0ZPeakNoise.ToString("00.00");
				if (gyro0ZPeakNoise > 50)
					uiForm.btGyro0ZAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro0ZAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro0ZAverageIndex >= gyro0ZAverage.Length)
					gyro0ZAverageIndex = 0;

				// Total Average
				uiForm.btG0NoiseAverage.Text = mFilterGetValue(FILTER_G0_NOISE_AVERAGE, gyro0NoiseAverage).ToString("0000");
				//					uiForm.btG0NoiseAverage.Text = gyro0NoiseAverage.ToString("0000");

				//
				// Gyro 1 Noise
				//
				// X1
				average = gyro1XAverage.Average();
				uiForm.btGyro1XAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro1XAverage[gyro1XAverageIndex]);
				noise *= NOISE_GAIN;
				gyro1NoiseAverage = gyro1XPeakNoise;
				noise = Math.Min(100, noise);
				if (noise > gyro1XPeakNoise)
					gyro1XPeakNoise = (int)noise;
				gyro1XPeakNoise--;
				gyro1XPeakNoise = Math.Min(100, gyro1XPeakNoise);
				gyro1XPeakNoise = Math.Max(0, gyro1XPeakNoise);
				uiForm.pbGyro1X.Value = gyro1XPeakNoise;
				uiForm.btGyro1XAverage.Text = gyro1XPeakNoise.ToString("00.00");
				if (gyro1XPeakNoise > 50)
					uiForm.btGyro1XAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro1XAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro1XAverageIndex >= gyro1XAverage.Length)
					gyro1XAverageIndex = 0;

				// Y1
				average = gyro1YAverage.Average();
				uiForm.btGyro1YAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro1YAverage[gyro1YAverageIndex]);
				noise *= NOISE_GAIN;
				gyro1NoiseAverage += gyro1YPeakNoise / 2;
				noise = Math.Min(100, noise);
				if (noise > gyro1YPeakNoise)
					gyro1YPeakNoise = (int)noise;
				gyro1YPeakNoise--;
				gyro1YPeakNoise = Math.Min(100, gyro1YPeakNoise);
				gyro1YPeakNoise = Math.Max(0, gyro1YPeakNoise);
				uiForm.pbGyro1Y.Value = gyro1YPeakNoise;
				uiForm.btGyro1YAverage.Text = gyro1YPeakNoise.ToString("00.00");
				if (gyro1YPeakNoise > 50)
					uiForm.btGyro1YAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro1YAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro1YAverageIndex >= gyro1YAverage.Length)
					gyro1YAverageIndex = 0;

				// Z1
				average = gyro1ZAverage.Average();
				uiForm.btGyro1ZAverage.Text = average.ToString("00.00");
				noise = Math.Abs(average - gyro1ZAverage[gyro1ZAverageIndex]);
				noise *= NOISE_GAIN;
				gyro1NoiseAverage += gyro1YPeakNoise / 2;
				noise = Math.Min(100, noise);
				if (noise > gyro1ZPeakNoise)
					gyro1ZPeakNoise = (int)noise;
				gyro1ZPeakNoise--;
				gyro1ZPeakNoise = Math.Min(100, gyro1ZPeakNoise);
				gyro1ZPeakNoise = Math.Max(0, gyro1ZPeakNoise);
				uiForm.pbGyro1Z.Value = gyro1ZPeakNoise;
				uiForm.btGyro1ZAverage.Text = gyro1ZPeakNoise.ToString("00.00");
				if (gyro1ZPeakNoise > 50)
					uiForm.btGyro1ZAverage.BackColor = System.Drawing.Color.Red;
				else
					uiForm.btGyro1ZAverage.BackColor = System.Drawing.Color.Green;
				if (++gyro1ZAverageIndex >= gyro1ZAverage.Length)
					gyro1ZAverageIndex = 0;

				// Total Average
				uiForm.btG1NoiseAverage.Text = mFilterGetValue(FILTER_G1_NOISE_AVERAGE, gyro1NoiseAverage).ToString("0000");
				//uiForm.btG1NoiseAverage.Text = gyro1NoiseAverage.ToString("0000");

			}
			else
			{
				// Volts
				uiForm.btBrdVoltsIn.BackColor = System.Drawing.Color.Gray;
				uiForm.btBrdVoltsIn.Text = "--.-";

				// Board Temp
				uiForm.btBrdBoardTemp.BackColor = System.Drawing.Color.Gray;
				uiForm.btBrdBoardTemp.Text = "--.-";

				// OAT
				uiForm.btBrdOat.BackColor = System.Drawing.Color.Gray;
				uiForm.btBrdOat.Text = "--.-";

				// Ambient light
				uiForm.btBrdAmbLight.BackColor = System.Drawing.Color.Gray;
				uiForm.btBrdAmbLight.Text = "--.-";


			}


			mFilterUpdate();

		}

	}
}
