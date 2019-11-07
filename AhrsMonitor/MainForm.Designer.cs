namespace AhrsMonitor
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btParmX = new System.Windows.Forms.Button();
			this.btParmY = new System.Windows.Forms.Button();
			this.lbMaxChartVal = new System.Windows.Forms.Label();
			this.lbMinChartVal = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pbTempGraph = new System.Windows.Forms.PictureBox();
			this.lbP1 = new System.Windows.Forms.Label();
			this.lbP2 = new System.Windows.Forms.Label();
			this.lbTrgTemp = new System.Windows.Forms.Label();
			this.btMaxScale = new System.Windows.Forms.Button();
			this.btMidScale = new System.Windows.Forms.Button();
			this.btMicroScale = new System.Windows.Forms.Button();
			this.lbSource = new System.Windows.Forms.Label();
			this.lbP3 = new System.Windows.Forms.Label();
			this.btParmZ = new System.Windows.Forms.Button();
			this.btShowGyroRaw0 = new System.Windows.Forms.Button();
			this.btShowAccelRaw0 = new System.Windows.Forms.Button();
			this.btShowRpy = new System.Windows.Forms.Button();
			this.btFreeGyroMode = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lbTimeInFreeMode = new System.Windows.Forms.Label();
			this.btShowWeights = new System.Windows.Forms.Button();
			this.btShowGyroCal = new System.Windows.Forms.Button();
			this.btShowAccelCal = new System.Windows.Forms.Button();
			this.btAhrsReset = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btAhrsStable = new System.Windows.Forms.Button();
			this.btStartRandom = new System.Windows.Forms.Button();
			this.btStopRandom = new System.Windows.Forms.Button();
			this.btMilliScale = new System.Windows.Forms.Button();
			this.cbRandomXEnabled = new System.Windows.Forms.CheckBox();
			this.cbRandomYEnabled = new System.Windows.Forms.CheckBox();
			this.cbRandomZEnabled = new System.Windows.Forms.CheckBox();
			this.lbPA = new System.Windows.Forms.Label();
			this.btParmA = new System.Windows.Forms.Button();
			this.btMoveRoll30 = new System.Windows.Forms.Button();
			this.btMoveRoll0 = new System.Windows.Forms.Button();
			this.btShowGyroSum = new System.Windows.Forms.Button();
			this.btClearGyroSum = new System.Windows.Forms.Button();
			this.btShowStats1 = new System.Windows.Forms.Button();
			this.gbScreen = new System.Windows.Forms.GroupBox();
			this.btGoAi = new System.Windows.Forms.Button();
			this.btGoTraf = new System.Windows.Forms.Button();
			this.btGoAoa = new System.Windows.Forms.Button();
			this.btGoCntUp = new System.Windows.Forms.Button();
			this.btGoChrono = new System.Windows.Forms.Button();
			this.btStaticHeatStable = new System.Windows.Forms.Button();
			this.btPitotHeatStable = new System.Windows.Forms.Button();
			this.btShowAirData = new System.Windows.Forms.Button();
			this.btShowHeaters = new System.Windows.Forms.Button();
			this.btShowAirRaw = new System.Windows.Forms.Button();
			this.btShowRates = new System.Windows.Forms.Button();
			this.btUltraScale = new System.Windows.Forms.Button();
			this.btShowGyroRaw1 = new System.Windows.Forms.Button();
			this.btShowAccelRaw1 = new System.Windows.Forms.Button();
			this.tbRandomScaleY = new System.Windows.Forms.TrackBar();
			this.tbRandomScaleR = new System.Windows.Forms.TrackBar();
			this.tbRandomScaleP = new System.Windows.Forms.TrackBar();
			this.btAhrsAlignComplete = new System.Windows.Forms.Button();
			this.btStartDg = new System.Windows.Forms.Button();
			this.btStopDg = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).BeginInit();
			this.gbScreen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleP)).BeginInit();
			this.SuspendLayout();
			// 
			// btParmX
			// 
			this.btParmX.BackColor = System.Drawing.Color.DarkRed;
			this.btParmX.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btParmX.ForeColor = System.Drawing.Color.White;
			this.btParmX.Location = new System.Drawing.Point(29, 144);
			this.btParmX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btParmX.Name = "btParmX";
			this.btParmX.Size = new System.Drawing.Size(191, 68);
			this.btParmX.TabIndex = 11;
			this.btParmX.Text = "X";
			this.btParmX.UseVisualStyleBackColor = false;
			// 
			// btParmY
			// 
			this.btParmY.BackColor = System.Drawing.Color.Green;
			this.btParmY.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btParmY.ForeColor = System.Drawing.Color.White;
			this.btParmY.Location = new System.Drawing.Point(29, 266);
			this.btParmY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btParmY.Name = "btParmY";
			this.btParmY.Size = new System.Drawing.Size(191, 68);
			this.btParmY.TabIndex = 12;
			this.btParmY.Text = "Y";
			this.btParmY.UseVisualStyleBackColor = false;
			// 
			// lbMaxChartVal
			// 
			this.lbMaxChartVal.AutoSize = true;
			this.lbMaxChartVal.Location = new System.Drawing.Point(1973, 53);
			this.lbMaxChartVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbMaxChartVal.Name = "lbMaxChartVal";
			this.lbMaxChartVal.Size = new System.Drawing.Size(49, 25);
			this.lbMaxChartVal.TabIndex = 0;
			this.lbMaxChartVal.Text = "70C";
			// 
			// lbMinChartVal
			// 
			this.lbMinChartVal.AutoSize = true;
			this.lbMinChartVal.Location = new System.Drawing.Point(1973, 1090);
			this.lbMinChartVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbMinChartVal.Name = "lbMinChartVal";
			this.lbMinChartVal.Size = new System.Drawing.Size(49, 25);
			this.lbMinChartVal.TabIndex = 14;
			this.lbMinChartVal.Text = "20C";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pbTempGraph
			// 
			this.pbTempGraph.BackColor = System.Drawing.Color.Silver;
			this.pbTempGraph.Location = new System.Drawing.Point(274, 71);
			this.pbTempGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pbTempGraph.Name = "pbTempGraph";
			this.pbTempGraph.Size = new System.Drawing.Size(1690, 1038);
			this.pbTempGraph.TabIndex = 17;
			this.pbTempGraph.TabStop = false;
			// 
			// lbP1
			// 
			this.lbP1.AutoSize = true;
			this.lbP1.Location = new System.Drawing.Point(34, 116);
			this.lbP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbP1.Name = "lbP1";
			this.lbP1.Size = new System.Drawing.Size(74, 25);
			this.lbP1.TabIndex = 20;
			this.lbP1.Text = "Parm 1";
			// 
			// lbP2
			// 
			this.lbP2.AutoSize = true;
			this.lbP2.Location = new System.Drawing.Point(34, 239);
			this.lbP2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbP2.Name = "lbP2";
			this.lbP2.Size = new System.Drawing.Size(74, 25);
			this.lbP2.TabIndex = 21;
			this.lbP2.Text = "Parm 2";
			// 
			// lbTrgTemp
			// 
			this.lbTrgTemp.AutoSize = true;
			this.lbTrgTemp.Location = new System.Drawing.Point(1973, 578);
			this.lbTrgTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbTrgTemp.Name = "lbTrgTemp";
			this.lbTrgTemp.Size = new System.Drawing.Size(49, 25);
			this.lbTrgTemp.TabIndex = 22;
			this.lbTrgTemp.Text = "20C";
			// 
			// btMaxScale
			// 
			this.btMaxScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMaxScale.Location = new System.Drawing.Point(1712, 1202);
			this.btMaxScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMaxScale.Name = "btMaxScale";
			this.btMaxScale.Size = new System.Drawing.Size(121, 52);
			this.btMaxScale.TabIndex = 23;
			this.btMaxScale.Text = "+/- 100";
			this.btMaxScale.UseVisualStyleBackColor = true;
			this.btMaxScale.Click += new System.EventHandler(this.btMaxScale_Click);
			// 
			// btMidScale
			// 
			this.btMidScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMidScale.Location = new System.Drawing.Point(1712, 1136);
			this.btMidScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMidScale.Name = "btMidScale";
			this.btMidScale.Size = new System.Drawing.Size(121, 52);
			this.btMidScale.TabIndex = 24;
			this.btMidScale.Text = "+/- 10";
			this.btMidScale.UseVisualStyleBackColor = true;
			this.btMidScale.Click += new System.EventHandler(this.btMidScale_Click);
			// 
			// btMicroScale
			// 
			this.btMicroScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMicroScale.Location = new System.Drawing.Point(1560, 1202);
			this.btMicroScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMicroScale.Name = "btMicroScale";
			this.btMicroScale.Size = new System.Drawing.Size(132, 52);
			this.btMicroScale.TabIndex = 25;
			this.btMicroScale.Text = "+/- 1";
			this.btMicroScale.UseVisualStyleBackColor = true;
			this.btMicroScale.Click += new System.EventHandler(this.btMicroScale_Click);
			// 
			// lbSource
			// 
			this.lbSource.AutoSize = true;
			this.lbSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSource.Location = new System.Drawing.Point(35, 24);
			this.lbSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbSource.Name = "lbSource";
			this.lbSource.Size = new System.Drawing.Size(156, 39);
			this.lbSource.TabIndex = 30;
			this.lbSource.Text = "Showing";
			// 
			// lbP3
			// 
			this.lbP3.AutoSize = true;
			this.lbP3.Location = new System.Drawing.Point(34, 359);
			this.lbP3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbP3.Name = "lbP3";
			this.lbP3.Size = new System.Drawing.Size(74, 25);
			this.lbP3.TabIndex = 32;
			this.lbP3.Text = "Parm 3";
			// 
			// btParmZ
			// 
			this.btParmZ.BackColor = System.Drawing.Color.DarkBlue;
			this.btParmZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btParmZ.ForeColor = System.Drawing.Color.White;
			this.btParmZ.Location = new System.Drawing.Point(29, 389);
			this.btParmZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btParmZ.Name = "btParmZ";
			this.btParmZ.Size = new System.Drawing.Size(191, 68);
			this.btParmZ.TabIndex = 31;
			this.btParmZ.Text = "Z";
			this.btParmZ.UseVisualStyleBackColor = false;
			// 
			// btShowGyroRaw0
			// 
			this.btShowGyroRaw0.Location = new System.Drawing.Point(429, 1134);
			this.btShowGyroRaw0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowGyroRaw0.Name = "btShowGyroRaw0";
			this.btShowGyroRaw0.Size = new System.Drawing.Size(137, 58);
			this.btShowGyroRaw0.TabIndex = 33;
			this.btShowGyroRaw0.Text = "Gyro0 Raw";
			this.btShowGyroRaw0.UseVisualStyleBackColor = true;
			this.btShowGyroRaw0.Click += new System.EventHandler(this.btShowGyroRaw0_Click);
			// 
			// btShowAccelRaw0
			// 
			this.btShowAccelRaw0.Location = new System.Drawing.Point(709, 1134);
			this.btShowAccelRaw0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowAccelRaw0.Name = "btShowAccelRaw0";
			this.btShowAccelRaw0.Size = new System.Drawing.Size(144, 58);
			this.btShowAccelRaw0.TabIndex = 34;
			this.btShowAccelRaw0.Text = "Accel0 Raw";
			this.btShowAccelRaw0.UseVisualStyleBackColor = true;
			this.btShowAccelRaw0.Click += new System.EventHandler(this.btShowAccelRaw0_Click);
			// 
			// btShowRpy
			// 
			this.btShowRpy.Location = new System.Drawing.Point(274, 1134);
			this.btShowRpy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowRpy.Name = "btShowRpy";
			this.btShowRpy.Size = new System.Drawing.Size(147, 58);
			this.btShowRpy.TabIndex = 35;
			this.btShowRpy.Text = "RPY";
			this.btShowRpy.UseVisualStyleBackColor = true;
			this.btShowRpy.Click += new System.EventHandler(this.btShowRpy_Click);
			// 
			// btFreeGyroMode
			// 
			this.btFreeGyroMode.Location = new System.Drawing.Point(2110, 325);
			this.btFreeGyroMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btFreeGyroMode.Name = "btFreeGyroMode";
			this.btFreeGyroMode.Size = new System.Drawing.Size(191, 58);
			this.btFreeGyroMode.TabIndex = 36;
			this.btFreeGyroMode.Text = "Free Gyro Undef";
			this.btFreeGyroMode.UseVisualStyleBackColor = true;
			this.btFreeGyroMode.Click += new System.EventHandler(this.btFreeGyroMode_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2114, 430);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(183, 25);
			this.label3.TabIndex = 38;
			this.label3.Text = "Time In Free Mode:";
			// 
			// lbTimeInFreeMode
			// 
			this.lbTimeInFreeMode.AutoSize = true;
			this.lbTimeInFreeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTimeInFreeMode.Location = new System.Drawing.Point(2339, 420);
			this.lbTimeInFreeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbTimeInFreeMode.Name = "lbTimeInFreeMode";
			this.lbTimeInFreeMode.Size = new System.Drawing.Size(36, 39);
			this.lbTimeInFreeMode.TabIndex = 39;
			this.lbTimeInFreeMode.Text = "0";
			// 
			// btShowWeights
			// 
			this.btShowWeights.Location = new System.Drawing.Point(274, 1200);
			this.btShowWeights.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowWeights.Name = "btShowWeights";
			this.btShowWeights.Size = new System.Drawing.Size(147, 58);
			this.btShowWeights.TabIndex = 45;
			this.btShowWeights.Text = "Weights";
			this.btShowWeights.UseVisualStyleBackColor = true;
			this.btShowWeights.Click += new System.EventHandler(this.btShowWeights_Click);
			// 
			// btShowGyroCal
			// 
			this.btShowGyroCal.Location = new System.Drawing.Point(429, 1200);
			this.btShowGyroCal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowGyroCal.Name = "btShowGyroCal";
			this.btShowGyroCal.Size = new System.Drawing.Size(274, 58);
			this.btShowGyroCal.TabIndex = 46;
			this.btShowGyroCal.Text = "Gyro Cal";
			this.btShowGyroCal.UseVisualStyleBackColor = true;
			this.btShowGyroCal.Click += new System.EventHandler(this.btShowGyroCal_Click);
			// 
			// btShowAccelCal
			// 
			this.btShowAccelCal.Location = new System.Drawing.Point(709, 1200);
			this.btShowAccelCal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowAccelCal.Name = "btShowAccelCal";
			this.btShowAccelCal.Size = new System.Drawing.Size(281, 58);
			this.btShowAccelCal.TabIndex = 47;
			this.btShowAccelCal.Text = "Accel Cal";
			this.btShowAccelCal.UseVisualStyleBackColor = true;
			this.btShowAccelCal.Click += new System.EventHandler(this.btShowAccelCal_Click);
			// 
			// btAhrsReset
			// 
			this.btAhrsReset.Location = new System.Drawing.Point(2331, 325);
			this.btAhrsReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btAhrsReset.Name = "btAhrsReset";
			this.btAhrsReset.Size = new System.Drawing.Size(191, 58);
			this.btAhrsReset.TabIndex = 48;
			this.btAhrsReset.Text = "AHRS Reset";
			this.btAhrsReset.UseVisualStyleBackColor = true;
			this.btAhrsReset.Click += new System.EventHandler(this.btAhrsReset_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2069, 68);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 25);
			this.label1.TabIndex = 50;
			this.label1.Text = "Status";
			// 
			// btAhrsStable
			// 
			this.btAhrsStable.BackColor = System.Drawing.Color.DimGray;
			this.btAhrsStable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btAhrsStable.ForeColor = System.Drawing.Color.White;
			this.btAhrsStable.Location = new System.Drawing.Point(2296, 160);
			this.btAhrsStable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btAhrsStable.Name = "btAhrsStable";
			this.btAhrsStable.Size = new System.Drawing.Size(214, 52);
			this.btAhrsStable.TabIndex = 51;
			this.btAhrsStable.Text = "AHRS STABLE";
			this.btAhrsStable.UseVisualStyleBackColor = false;
			// 
			// btStartRandom
			// 
			this.btStartRandom.Location = new System.Drawing.Point(2328, 512);
			this.btStartRandom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btStartRandom.Name = "btStartRandom";
			this.btStartRandom.Size = new System.Drawing.Size(191, 46);
			this.btStartRandom.TabIndex = 52;
			this.btStartRandom.Text = "Start Random";
			this.btStartRandom.UseVisualStyleBackColor = true;
			this.btStartRandom.Click += new System.EventHandler(this.btStartRandom_Click);
			// 
			// btStopRandom
			// 
			this.btStopRandom.Location = new System.Drawing.Point(2328, 568);
			this.btStopRandom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btStopRandom.Name = "btStopRandom";
			this.btStopRandom.Size = new System.Drawing.Size(191, 52);
			this.btStopRandom.TabIndex = 53;
			this.btStopRandom.Text = "Stop Random";
			this.btStopRandom.UseVisualStyleBackColor = true;
			this.btStopRandom.Click += new System.EventHandler(this.btStopRandom_Click);
			// 
			// btMilliScale
			// 
			this.btMilliScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMilliScale.Location = new System.Drawing.Point(1560, 1136);
			this.btMilliScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMilliScale.Name = "btMilliScale";
			this.btMilliScale.Size = new System.Drawing.Size(132, 52);
			this.btMilliScale.TabIndex = 54;
			this.btMilliScale.Text = "+/- .1";
			this.btMilliScale.UseVisualStyleBackColor = true;
			this.btMilliScale.Click += new System.EventHandler(this.btMilliScale_Click);
			// 
			// cbRandomXEnabled
			// 
			this.cbRandomXEnabled.AutoSize = true;
			this.cbRandomXEnabled.Checked = true;
			this.cbRandomXEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRandomXEnabled.Location = new System.Drawing.Point(2341, 637);
			this.cbRandomXEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbRandomXEnabled.Name = "cbRandomXEnabled";
			this.cbRandomXEnabled.Size = new System.Drawing.Size(51, 29);
			this.cbRandomXEnabled.TabIndex = 55;
			this.cbRandomXEnabled.Text = "Y";
			this.cbRandomXEnabled.UseVisualStyleBackColor = true;
			// 
			// cbRandomYEnabled
			// 
			this.cbRandomYEnabled.AutoSize = true;
			this.cbRandomYEnabled.Checked = true;
			this.cbRandomYEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRandomYEnabled.Location = new System.Drawing.Point(2404, 637);
			this.cbRandomYEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbRandomYEnabled.Name = "cbRandomYEnabled";
			this.cbRandomYEnabled.Size = new System.Drawing.Size(51, 29);
			this.cbRandomYEnabled.TabIndex = 56;
			this.cbRandomYEnabled.Text = "R";
			this.cbRandomYEnabled.UseVisualStyleBackColor = true;
			// 
			// cbRandomZEnabled
			// 
			this.cbRandomZEnabled.AutoSize = true;
			this.cbRandomZEnabled.Checked = true;
			this.cbRandomZEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRandomZEnabled.Location = new System.Drawing.Point(2468, 637);
			this.cbRandomZEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbRandomZEnabled.Name = "cbRandomZEnabled";
			this.cbRandomZEnabled.Size = new System.Drawing.Size(51, 29);
			this.cbRandomZEnabled.TabIndex = 57;
			this.cbRandomZEnabled.Text = "P";
			this.cbRandomZEnabled.UseVisualStyleBackColor = true;
			// 
			// lbPA
			// 
			this.lbPA.AutoSize = true;
			this.lbPA.Location = new System.Drawing.Point(33, 551);
			this.lbPA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPA.Name = "lbPA";
			this.lbPA.Size = new System.Drawing.Size(77, 25);
			this.lbPA.TabIndex = 59;
			this.lbPA.Text = "Parm A";
			// 
			// btParmA
			// 
			this.btParmA.BackColor = System.Drawing.Color.DarkBlue;
			this.btParmA.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btParmA.ForeColor = System.Drawing.Color.White;
			this.btParmA.Location = new System.Drawing.Point(29, 578);
			this.btParmA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btParmA.Name = "btParmA";
			this.btParmA.Size = new System.Drawing.Size(191, 68);
			this.btParmA.TabIndex = 58;
			this.btParmA.Text = "A";
			this.btParmA.UseVisualStyleBackColor = false;
			// 
			// btMoveRoll30
			// 
			this.btMoveRoll30.Location = new System.Drawing.Point(2110, 510);
			this.btMoveRoll30.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMoveRoll30.Name = "btMoveRoll30";
			this.btMoveRoll30.Size = new System.Drawing.Size(171, 52);
			this.btMoveRoll30.TabIndex = 60;
			this.btMoveRoll30.Text = "Move Roll 30";
			this.btMoveRoll30.UseVisualStyleBackColor = true;
			this.btMoveRoll30.Click += new System.EventHandler(this.btMoveRoll30_Click);
			// 
			// btMoveRoll0
			// 
			this.btMoveRoll0.Location = new System.Drawing.Point(2110, 575);
			this.btMoveRoll0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btMoveRoll0.Name = "btMoveRoll0";
			this.btMoveRoll0.Size = new System.Drawing.Size(171, 52);
			this.btMoveRoll0.TabIndex = 61;
			this.btMoveRoll0.Text = "Move Roll 0";
			this.btMoveRoll0.UseVisualStyleBackColor = true;
			this.btMoveRoll0.Click += new System.EventHandler(this.btMoveRoll0_Click);
			// 
			// btShowGyroSum
			// 
			this.btShowGyroSum.Location = new System.Drawing.Point(1183, 1134);
			this.btShowGyroSum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowGyroSum.Name = "btShowGyroSum";
			this.btShowGyroSum.Size = new System.Drawing.Size(147, 58);
			this.btShowGyroSum.TabIndex = 62;
			this.btShowGyroSum.Text = "Gyro I Term";
			this.btShowGyroSum.UseVisualStyleBackColor = true;
			this.btShowGyroSum.Click += new System.EventHandler(this.btShowGyroSum_Click);
			// 
			// btClearGyroSum
			// 
			this.btClearGyroSum.Location = new System.Drawing.Point(2110, 678);
			this.btClearGyroSum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btClearGyroSum.Name = "btClearGyroSum";
			this.btClearGyroSum.Size = new System.Drawing.Size(191, 58);
			this.btClearGyroSum.TabIndex = 63;
			this.btClearGyroSum.Text = "Clear Sum";
			this.btClearGyroSum.UseVisualStyleBackColor = true;
			this.btClearGyroSum.Click += new System.EventHandler(this.btClearGyroSum_Click);
			// 
			// btShowStats1
			// 
			this.btShowStats1.Location = new System.Drawing.Point(1183, 1200);
			this.btShowStats1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowStats1.Name = "btShowStats1";
			this.btShowStats1.Size = new System.Drawing.Size(147, 58);
			this.btShowStats1.TabIndex = 64;
			this.btShowStats1.Text = "Stats 1";
			this.btShowStats1.UseVisualStyleBackColor = true;
			this.btShowStats1.Click += new System.EventHandler(this.btShowStats1_Click);
			// 
			// gbScreen
			// 
			this.gbScreen.Controls.Add(this.btGoAi);
			this.gbScreen.Controls.Add(this.btGoTraf);
			this.gbScreen.Controls.Add(this.btGoAoa);
			this.gbScreen.Controls.Add(this.btGoCntUp);
			this.gbScreen.Controls.Add(this.btGoChrono);
			this.gbScreen.Location = new System.Drawing.Point(2079, 863);
			this.gbScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.gbScreen.Name = "gbScreen";
			this.gbScreen.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.gbScreen.Size = new System.Drawing.Size(224, 395);
			this.gbScreen.TabIndex = 65;
			this.gbScreen.TabStop = false;
			this.gbScreen.Text = "Screen";
			// 
			// btGoAi
			// 
			this.btGoAi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGoAi.Location = new System.Drawing.Point(40, 325);
			this.btGoAi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btGoAi.Name = "btGoAi";
			this.btGoAi.Size = new System.Drawing.Size(127, 46);
			this.btGoAi.TabIndex = 71;
			this.btGoAi.Text = "AI";
			this.btGoAi.UseVisualStyleBackColor = true;
			this.btGoAi.Click += new System.EventHandler(this.btGoAi_Click);
			// 
			// btGoTraf
			// 
			this.btGoTraf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGoTraf.Location = new System.Drawing.Point(40, 270);
			this.btGoTraf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btGoTraf.Name = "btGoTraf";
			this.btGoTraf.Size = new System.Drawing.Size(127, 46);
			this.btGoTraf.TabIndex = 70;
			this.btGoTraf.Text = "Traffic";
			this.btGoTraf.UseVisualStyleBackColor = true;
			this.btGoTraf.Click += new System.EventHandler(this.btGoTraf_Click);
			// 
			// btGoAoa
			// 
			this.btGoAoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGoAoa.Location = new System.Drawing.Point(40, 214);
			this.btGoAoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btGoAoa.Name = "btGoAoa";
			this.btGoAoa.Size = new System.Drawing.Size(127, 46);
			this.btGoAoa.TabIndex = 69;
			this.btGoAoa.Text = "AOA";
			this.btGoAoa.UseVisualStyleBackColor = true;
			this.btGoAoa.Click += new System.EventHandler(this.btGoAoa_Click);
			// 
			// btGoCntUp
			// 
			this.btGoCntUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGoCntUp.Location = new System.Drawing.Point(40, 103);
			this.btGoCntUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btGoCntUp.Name = "btGoCntUp";
			this.btGoCntUp.Size = new System.Drawing.Size(127, 46);
			this.btGoCntUp.TabIndex = 67;
			this.btGoCntUp.Text = "Up Count";
			this.btGoCntUp.UseVisualStyleBackColor = true;
			this.btGoCntUp.Click += new System.EventHandler(this.btGoCntUp_Click);
			// 
			// btGoChrono
			// 
			this.btGoChrono.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGoChrono.Location = new System.Drawing.Point(40, 48);
			this.btGoChrono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btGoChrono.Name = "btGoChrono";
			this.btGoChrono.Size = new System.Drawing.Size(127, 46);
			this.btGoChrono.TabIndex = 66;
			this.btGoChrono.Text = "Chrono";
			this.btGoChrono.UseVisualStyleBackColor = true;
			this.btGoChrono.Click += new System.EventHandler(this.btGoChrono_Click);
			// 
			// btStaticHeatStable
			// 
			this.btStaticHeatStable.BackColor = System.Drawing.Color.DimGray;
			this.btStaticHeatStable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btStaticHeatStable.ForeColor = System.Drawing.Color.White;
			this.btStaticHeatStable.Location = new System.Drawing.Point(2072, 158);
			this.btStaticHeatStable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btStaticHeatStable.Name = "btStaticHeatStable";
			this.btStaticHeatStable.Size = new System.Drawing.Size(191, 52);
			this.btStaticHeatStable.TabIndex = 66;
			this.btStaticHeatStable.Text = "S HEAT STABLE";
			this.btStaticHeatStable.UseVisualStyleBackColor = false;
			// 
			// btPitotHeatStable
			// 
			this.btPitotHeatStable.BackColor = System.Drawing.Color.DimGray;
			this.btPitotHeatStable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btPitotHeatStable.ForeColor = System.Drawing.Color.White;
			this.btPitotHeatStable.Location = new System.Drawing.Point(2074, 101);
			this.btPitotHeatStable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btPitotHeatStable.Name = "btPitotHeatStable";
			this.btPitotHeatStable.Size = new System.Drawing.Size(191, 52);
			this.btPitotHeatStable.TabIndex = 67;
			this.btPitotHeatStable.Text = "P HEAT STABLE";
			this.btPitotHeatStable.UseVisualStyleBackColor = false;
			// 
			// btShowAirData
			// 
			this.btShowAirData.Location = new System.Drawing.Point(1027, 1200);
			this.btShowAirData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowAirData.Name = "btShowAirData";
			this.btShowAirData.Size = new System.Drawing.Size(147, 58);
			this.btShowAirData.TabIndex = 68;
			this.btShowAirData.Text = "Air Data";
			this.btShowAirData.UseVisualStyleBackColor = true;
			this.btShowAirData.Click += new System.EventHandler(this.btShowAirData_Click);
			// 
			// btShowHeaters
			// 
			this.btShowHeaters.Location = new System.Drawing.Point(1338, 1134);
			this.btShowHeaters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowHeaters.Name = "btShowHeaters";
			this.btShowHeaters.Size = new System.Drawing.Size(147, 58);
			this.btShowHeaters.TabIndex = 69;
			this.btShowHeaters.Text = "Heater";
			this.btShowHeaters.UseVisualStyleBackColor = true;
			this.btShowHeaters.Click += new System.EventHandler(this.btShowHeaters_Click);
			// 
			// btShowAirRaw
			// 
			this.btShowAirRaw.Location = new System.Drawing.Point(1027, 1134);
			this.btShowAirRaw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowAirRaw.Name = "btShowAirRaw";
			this.btShowAirRaw.Size = new System.Drawing.Size(147, 58);
			this.btShowAirRaw.TabIndex = 70;
			this.btShowAirRaw.Text = "Air Raw";
			this.btShowAirRaw.UseVisualStyleBackColor = true;
			this.btShowAirRaw.Click += new System.EventHandler(this.btShowAirRaw_Click);
			// 
			// btShowRates
			// 
			this.btShowRates.Location = new System.Drawing.Point(1338, 1200);
			this.btShowRates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowRates.Name = "btShowRates";
			this.btShowRates.Size = new System.Drawing.Size(147, 58);
			this.btShowRates.TabIndex = 71;
			this.btShowRates.Text = "Rates";
			this.btShowRates.UseVisualStyleBackColor = true;
			this.btShowRates.Click += new System.EventHandler(this.btShowRates_Click);
			// 
			// btUltraScale
			// 
			this.btUltraScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btUltraScale.Location = new System.Drawing.Point(1843, 1136);
			this.btUltraScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btUltraScale.Name = "btUltraScale";
			this.btUltraScale.Size = new System.Drawing.Size(121, 52);
			this.btUltraScale.TabIndex = 72;
			this.btUltraScale.Text = "+/- 1000";
			this.btUltraScale.UseVisualStyleBackColor = true;
			this.btUltraScale.Click += new System.EventHandler(this.btUltraScale_Click);
			// 
			// btShowGyroRaw1
			// 
			this.btShowGyroRaw1.Location = new System.Drawing.Point(565, 1134);
			this.btShowGyroRaw1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowGyroRaw1.Name = "btShowGyroRaw1";
			this.btShowGyroRaw1.Size = new System.Drawing.Size(137, 58);
			this.btShowGyroRaw1.TabIndex = 73;
			this.btShowGyroRaw1.Text = "Gyro1 Raw";
			this.btShowGyroRaw1.UseVisualStyleBackColor = true;
			this.btShowGyroRaw1.Click += new System.EventHandler(this.btShowGyroRaw1_Click);
			// 
			// btShowAccelRaw1
			// 
			this.btShowAccelRaw1.Location = new System.Drawing.Point(853, 1134);
			this.btShowAccelRaw1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btShowAccelRaw1.Name = "btShowAccelRaw1";
			this.btShowAccelRaw1.Size = new System.Drawing.Size(137, 58);
			this.btShowAccelRaw1.TabIndex = 74;
			this.btShowAccelRaw1.Text = "Accel1 Raw";
			this.btShowAccelRaw1.UseVisualStyleBackColor = true;
			this.btShowAccelRaw1.Click += new System.EventHandler(this.btShowAccelRaw1_Click);
			// 
			// tbRandomScaleY
			// 
			this.tbRandomScaleY.Location = new System.Drawing.Point(2341, 733);
			this.tbRandomScaleY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.tbRandomScaleY.Maximum = 80;
			this.tbRandomScaleY.Name = "tbRandomScaleY";
			this.tbRandomScaleY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRandomScaleY.Size = new System.Drawing.Size(80, 270);
			this.tbRandomScaleY.TabIndex = 75;
			this.tbRandomScaleY.Value = 5;
			// 
			// tbRandomScaleR
			// 
			this.tbRandomScaleR.Location = new System.Drawing.Point(2404, 733);
			this.tbRandomScaleR.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.tbRandomScaleR.Maximum = 80;
			this.tbRandomScaleR.Name = "tbRandomScaleR";
			this.tbRandomScaleR.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRandomScaleR.Size = new System.Drawing.Size(80, 270);
			this.tbRandomScaleR.TabIndex = 76;
			this.tbRandomScaleR.Value = 5;
			// 
			// tbRandomScaleP
			// 
			this.tbRandomScaleP.Location = new System.Drawing.Point(2468, 733);
			this.tbRandomScaleP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.tbRandomScaleP.Maximum = 80;
			this.tbRandomScaleP.Name = "tbRandomScaleP";
			this.tbRandomScaleP.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRandomScaleP.Size = new System.Drawing.Size(80, 270);
			this.tbRandomScaleP.TabIndex = 77;
			this.tbRandomScaleP.Value = 5;
			// 
			// btAhrsAlignComplete
			// 
			this.btAhrsAlignComplete.BackColor = System.Drawing.Color.DimGray;
			this.btAhrsAlignComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btAhrsAlignComplete.ForeColor = System.Drawing.Color.White;
			this.btAhrsAlignComplete.Location = new System.Drawing.Point(2296, 101);
			this.btAhrsAlignComplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btAhrsAlignComplete.Name = "btAhrsAlignComplete";
			this.btAhrsAlignComplete.Size = new System.Drawing.Size(214, 52);
			this.btAhrsAlignComplete.TabIndex = 78;
			this.btAhrsAlignComplete.Text = "ALIGN COMPLETE";
			this.btAhrsAlignComplete.UseVisualStyleBackColor = false;
			// 
			// btStartDg
			// 
			this.btStartDg.Location = new System.Drawing.Point(2328, 1085);
			this.btStartDg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btStartDg.Name = "btStartDg";
			this.btStartDg.Size = new System.Drawing.Size(191, 46);
			this.btStartDg.TabIndex = 79;
			this.btStartDg.Text = "Start DG";
			this.btStartDg.UseVisualStyleBackColor = true;
			this.btStartDg.Click += new System.EventHandler(this.btStartDg_Click);
			// 
			// btStopDg
			// 
			this.btStopDg.Location = new System.Drawing.Point(2328, 1141);
			this.btStopDg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btStopDg.Name = "btStopDg";
			this.btStopDg.Size = new System.Drawing.Size(191, 46);
			this.btStopDg.TabIndex = 80;
			this.btStopDg.Text = "Stop DG";
			this.btStopDg.UseVisualStyleBackColor = true;
			this.btStopDg.Click += new System.EventHandler(this.btStopDg_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(2645, 1582);
			this.Controls.Add(this.btStopDg);
			this.Controls.Add(this.btStartDg);
			this.Controls.Add(this.btAhrsAlignComplete);
			this.Controls.Add(this.tbRandomScaleP);
			this.Controls.Add(this.tbRandomScaleR);
			this.Controls.Add(this.tbRandomScaleY);
			this.Controls.Add(this.btShowAccelRaw1);
			this.Controls.Add(this.btShowGyroRaw1);
			this.Controls.Add(this.btUltraScale);
			this.Controls.Add(this.btShowRates);
			this.Controls.Add(this.btShowAirRaw);
			this.Controls.Add(this.btShowHeaters);
			this.Controls.Add(this.btShowAirData);
			this.Controls.Add(this.btPitotHeatStable);
			this.Controls.Add(this.btStaticHeatStable);
			this.Controls.Add(this.gbScreen);
			this.Controls.Add(this.btShowStats1);
			this.Controls.Add(this.btClearGyroSum);
			this.Controls.Add(this.btShowGyroSum);
			this.Controls.Add(this.btMoveRoll0);
			this.Controls.Add(this.btMoveRoll30);
			this.Controls.Add(this.lbPA);
			this.Controls.Add(this.btParmA);
			this.Controls.Add(this.cbRandomZEnabled);
			this.Controls.Add(this.cbRandomYEnabled);
			this.Controls.Add(this.cbRandomXEnabled);
			this.Controls.Add(this.btMilliScale);
			this.Controls.Add(this.btStopRandom);
			this.Controls.Add(this.btStartRandom);
			this.Controls.Add(this.btAhrsStable);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btAhrsReset);
			this.Controls.Add(this.btShowAccelCal);
			this.Controls.Add(this.btShowGyroCal);
			this.Controls.Add(this.btShowWeights);
			this.Controls.Add(this.lbTimeInFreeMode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btFreeGyroMode);
			this.Controls.Add(this.btShowRpy);
			this.Controls.Add(this.btShowAccelRaw0);
			this.Controls.Add(this.btShowGyroRaw0);
			this.Controls.Add(this.lbP3);
			this.Controls.Add(this.btParmZ);
			this.Controls.Add(this.lbSource);
			this.Controls.Add(this.btMicroScale);
			this.Controls.Add(this.btMidScale);
			this.Controls.Add(this.btMaxScale);
			this.Controls.Add(this.lbTrgTemp);
			this.Controls.Add(this.lbP2);
			this.Controls.Add(this.lbP1);
			this.Controls.Add(this.pbTempGraph);
			this.Controls.Add(this.lbMinChartVal);
			this.Controls.Add(this.lbMaxChartVal);
			this.Controls.Add(this.btParmY);
			this.Controls.Add(this.btParmX);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "MainForm";
			this.Text = "AHRS Monitor";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).EndInit();
			this.gbScreen.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRandomScaleP)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btParmX;
		private System.Windows.Forms.Button btParmY;
		private System.Windows.Forms.Label lbMaxChartVal;
		private System.Windows.Forms.Label lbMinChartVal;
		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.PictureBox pbTempGraph;
		private System.Windows.Forms.Label lbP1;
		private System.Windows.Forms.Label lbP2;
		private System.Windows.Forms.Label lbTrgTemp;
		private System.Windows.Forms.Button btMaxScale;
		private System.Windows.Forms.Button btMidScale;
		private System.Windows.Forms.Button btMicroScale;
		private System.Windows.Forms.Label lbSource;
		private System.Windows.Forms.Label lbP3;
		private System.Windows.Forms.Button btParmZ;
		private System.Windows.Forms.Button btShowGyroRaw0;
		private System.Windows.Forms.Button btShowAccelRaw0;
		private System.Windows.Forms.Button btShowRpy;
		private System.Windows.Forms.Button btFreeGyroMode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbTimeInFreeMode;
		private System.Windows.Forms.Button btShowWeights;
		private System.Windows.Forms.Button btShowGyroCal;
		private System.Windows.Forms.Button btShowAccelCal;
		private System.Windows.Forms.Button btAhrsReset;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btAhrsStable;
		private System.Windows.Forms.Button btStartRandom;
		private System.Windows.Forms.Button btStopRandom;
		private System.Windows.Forms.Button btMilliScale;
		private System.Windows.Forms.CheckBox cbRandomXEnabled;
		private System.Windows.Forms.CheckBox cbRandomYEnabled;
		private System.Windows.Forms.CheckBox cbRandomZEnabled;
		private System.Windows.Forms.Label lbPA;
		private System.Windows.Forms.Button btParmA;
		private System.Windows.Forms.Button btMoveRoll30;
		private System.Windows.Forms.Button btMoveRoll0;
		private System.Windows.Forms.Button btShowGyroSum;
		private System.Windows.Forms.Button btClearGyroSum;
		private System.Windows.Forms.Button btShowStats1;
		private System.Windows.Forms.GroupBox gbScreen;
		private System.Windows.Forms.Button btGoAi;
		private System.Windows.Forms.Button btGoTraf;
		private System.Windows.Forms.Button btGoAoa;
		private System.Windows.Forms.Button btGoCntUp;
		private System.Windows.Forms.Button btGoChrono;
		private System.Windows.Forms.Button btStaticHeatStable;
		private System.Windows.Forms.Button btPitotHeatStable;
        private System.Windows.Forms.Button btShowAirData;
        private System.Windows.Forms.Button btShowHeaters;
		private System.Windows.Forms.Button btShowAirRaw;
		private System.Windows.Forms.Button btShowRates;
		private System.Windows.Forms.Button btUltraScale;
		private System.Windows.Forms.Button btShowGyroRaw1;
		private System.Windows.Forms.Button btShowAccelRaw1;
		private System.Windows.Forms.TrackBar tbRandomScaleY;
		private System.Windows.Forms.TrackBar tbRandomScaleR;
		private System.Windows.Forms.TrackBar tbRandomScaleP;
		private System.Windows.Forms.Button btAhrsAlignComplete;
		private System.Windows.Forms.Button btStartDg;
		private System.Windows.Forms.Button btStopDg;
	}
}

