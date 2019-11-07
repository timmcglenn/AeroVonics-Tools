using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AhrsMonitor
{

    static class Chart
    {
        public static MainForm uiForm;

        private static int GYRO_X_SIZE = 400;
        private static int GYRO_Y_SIZE = 400;
        private static int CMD_X_SIZE = 1000;
        private static int CMD_Y_SIZE = 100;
		private static int X_INC = 2;

        public static double MAX_RATE = 100;
        public static double MIN_RATE = -100;
        public static int TRG_RATE = 0;
        
        private static double[] xGyroDataPoint = new double[GYRO_X_SIZE + 2];
        private static double[] yGyroDataPoint = new double[GYRO_X_SIZE + 2];
		private static double[] zGyroDataPoint = new double[GYRO_X_SIZE + 2];

		private static int[] cmdDataPoint = new int[CMD_X_SIZE + 1];
        private static int currentGyroPoint = 0;
        private static int currentCmdPoint = 0;
        private static int test = 0;

		public static double rollMarker = 0;
		public static double pitchMarker = 0;
		public static bool freeGyroMode = false;


		// Accessors
		public static void setParentForm(MainForm tform)
        {
            uiForm = tform;
        }

        //private static int CMD_X_SIZE = uiForm.pnCmdChart.Size.Width;
        //private static int CMD_Y_SIZE = uiForm.pnCmdChart.Size.Height;
        //private static int GYRO_X_SIZE = uiForm.pnTempChart.Size.Width;
        //private static int GYRO_Y_SIZE = uiForm.pnTempChart.Size.Height;



        public static void addNewPoint(double newXPoint, double newYPoint, double newZPoint)
        {
            xGyroDataPoint[currentGyroPoint] = newXPoint;
            yGyroDataPoint[currentGyroPoint] = newYPoint;
			zGyroDataPoint[currentGyroPoint] = newZPoint;


			if (currentGyroPoint > GYRO_X_SIZE -1)
            {
                // Move each down one
                for (int i = 0; i < GYRO_X_SIZE; i++)
                {
                    xGyroDataPoint[i] = xGyroDataPoint[i + 1];
                    yGyroDataPoint[i] = yGyroDataPoint[i + 1];
					zGyroDataPoint[i] = zGyroDataPoint[i + 1];
				}

            }
            else
            {
                // Still loading new data
                currentGyroPoint++;
            }
        }

        public static void clearAllPoints()
        {
            currentGyroPoint = 0;
            currentCmdPoint = 0;
        }

        // Draw on temp panel
        public static void drawChartTempPb(object sender, PaintEventArgs e)
        {
            Bitmap buffer = new Bitmap(uiForm.pbTempGraph.Size.Width, uiForm.pbTempGraph.Size.Height);//set the size of the image
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
            myPen.Width = 1;
            System.Drawing.Graphics g = Graphics.FromImage(buffer);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Draw Grids
            drawChartTempGrid(g);
			// Draw Chart

			// X Gyro
			myPen.Color = Color.Red;
			int xBase = 0;
            double yPrev = uiForm.pbTempGraph.Size.Height;
            double yNext = 0;
            for (int i = 0; i < currentGyroPoint - 1; i++)
            {
                //if (xGyroDataPoint[i + 1] != 0)
                //{
                    yNext = rateToYLoc(xGyroDataPoint[i + 1]);
                    g.DrawLine(myPen, xBase + (i * X_INC), (float)yPrev,
                        xBase + ((i+1) * X_INC), (float)yNext);
                    yPrev = yNext;
                //}
            }

			// Y Gyro
            myPen.Color = Color.Green;
            xBase = 0;
            yPrev = uiForm.pbTempGraph.Size.Height;
            yNext = 0;
            for (int i = 0; i < currentGyroPoint - 1; i++)
            {
                //if (yGyroDataPoint[i + 1] != 0)
                //{
                    yNext = rateToYLoc(yGyroDataPoint[i + 1]);
					g.DrawLine(myPen, xBase + (i * X_INC), (float)yPrev,
						xBase + ((i + 1) * X_INC), (float)yNext);
					yPrev = yNext;
                //}
            }

			// Z Gyro
			myPen.Color = Color.Blue;
			xBase = 0;
			yPrev = uiForm.pbTempGraph.Size.Height;
			yNext = 0;
			for (int i = 0; i < currentGyroPoint - 1; i++)
			{
				//if (yGyroDataPoint[i + 1] != 0)
				//{
					yNext = rateToYLoc(zGyroDataPoint[i + 1]);
					g.DrawLine(myPen, xBase + (i * X_INC), (float)yPrev,
						xBase + ((i + 1) * X_INC), (float)yNext);
					yPrev = yNext;
				//}
			}


			uiForm.pbTempGraph.Image = buffer;
            myPen.Dispose();
            g.Dispose();
        }

        private static void drawChartTempGrid(Graphics g)
        {
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Gray);
            for (double i = MIN_RATE; i < MAX_RATE; i = i + (MAX_RATE / 10.0))
            {
                g.DrawLine(myPen, 0, (float)rateToYLoc(i), uiForm.pbTempGraph.Size.Width, (float)rateToYLoc(i));
            }
            // Target
            myPen.Width = 2;
            myPen.Color = Color.Black;
            g.DrawLine(myPen, 0, (float)rateToYLoc(TRG_RATE), uiForm.pbTempGraph.Size.Width, (float)rateToYLoc(TRG_RATE));

			// Free gyro mode markers
			if (freeGyroMode == true)
			{
				// Roll Marker
				myPen.Width = 3;
				myPen.Color = Color.Red;
				g.DrawLine(myPen, uiForm.pbTempGraph.Size.Width - 25, (float)rateToYLoc(rollMarker), uiForm.pbTempGraph.Size.Width, (float)rateToYLoc(rollMarker));

				// Pitch Marker
				myPen.Width = 3;
				myPen.Color = Color.Green;
				g.DrawLine(myPen, uiForm.pbTempGraph.Size.Width - 25, (float)rateToYLoc(pitchMarker), uiForm.pbTempGraph.Size.Width, (float)rateToYLoc(pitchMarker));
			}

			myPen.Dispose();

		}

		public static double rateToYLoc(double rate)
        {
            double y;
            y = (rate - MIN_RATE) / (MAX_RATE - MIN_RATE);
            y *= (uiForm.pbTempGraph.Size.Height);
            y = uiForm.pbTempGraph.Size.Height - y;
            return y;
        }

    }
}
