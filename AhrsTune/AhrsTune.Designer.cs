namespace AhrsTune
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
			this.btMicroScale = new System.Windows.Forms.Button();
			this.btMidScale = new System.Windows.Forms.Button();
			this.btMaxScale = new System.Windows.Forms.Button();
			this.pbTempGraph = new System.Windows.Forms.PictureBox();
			this.tbRpyPGain = new System.Windows.Forms.TextBox();
			this.btSetRpyPGain = new System.Windows.Forms.Button();
			this.btBiasZ = new System.Windows.Forms.Button();
			this.btBiasY = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btBiasX = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btRpyWeight = new System.Windows.Forms.Button();
			this.btBiasWeight = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btBiasGate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btRpyGate = new System.Windows.Forms.Button();
			this.btBiasTrendZ = new System.Windows.Forms.Button();
			this.btBiasTrendX = new System.Windows.Forms.Button();
			this.btBiasTrendY = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.btYaw = new System.Windows.Forms.Button();
			this.btRoll = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btPitch = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btSetYawIGain = new System.Windows.Forms.Button();
			this.tbYawIGain = new System.Windows.Forms.TextBox();
			this.btSetYawPGain = new System.Windows.Forms.Button();
			this.tbYawPGain = new System.Windows.Forms.TextBox();
			this.btSetBiasIGain = new System.Windows.Forms.Button();
			this.tbBiasIGain = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btFreeGyro = new System.Windows.Forms.Button();
			this.btResetAhrs = new System.Windows.Forms.Button();
			this.btShowBias = new System.Windows.Forms.Button();
			this.btShowBiasTrend = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.btRefreshCom = new System.Windows.Forms.Button();
			this.btStable = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btMicroScale
			// 
			this.btMicroScale.Location = new System.Drawing.Point(1127, 679);
			this.btMicroScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMicroScale.Name = "btMicroScale";
			this.btMicroScale.Size = new System.Drawing.Size(139, 34);
			this.btMicroScale.TabIndex = 55;
			this.btMicroScale.Text = "Micro Scale";
			this.btMicroScale.UseVisualStyleBackColor = true;
			// 
			// btMidScale
			// 
			this.btMidScale.Location = new System.Drawing.Point(982, 679);
			this.btMidScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMidScale.Name = "btMidScale";
			this.btMidScale.Size = new System.Drawing.Size(139, 34);
			this.btMidScale.TabIndex = 54;
			this.btMidScale.Text = "Mid Scale";
			this.btMidScale.UseVisualStyleBackColor = true;
			// 
			// btMaxScale
			// 
			this.btMaxScale.Location = new System.Drawing.Point(837, 679);
			this.btMaxScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMaxScale.Name = "btMaxScale";
			this.btMaxScale.Size = new System.Drawing.Size(139, 34);
			this.btMaxScale.TabIndex = 53;
			this.btMaxScale.Text = "Max Scale";
			this.btMaxScale.UseVisualStyleBackColor = true;
			// 
			// pbTempGraph
			// 
			this.pbTempGraph.BackColor = System.Drawing.Color.Silver;
			this.pbTempGraph.Location = new System.Drawing.Point(342, 98);
			this.pbTempGraph.Name = "pbTempGraph";
			this.pbTempGraph.Size = new System.Drawing.Size(1000, 500);
			this.pbTempGraph.TabIndex = 48;
			this.pbTempGraph.TabStop = false;
			// 
			// tbRpyPGain
			// 
			this.tbRpyPGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbRpyPGain.Location = new System.Drawing.Point(200, 30);
			this.tbRpyPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbRpyPGain.Name = "tbRpyPGain";
			this.tbRpyPGain.Size = new System.Drawing.Size(105, 30);
			this.tbRpyPGain.TabIndex = 36;
			this.tbRpyPGain.Text = "10";
			this.tbRpyPGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btSetRpyPGain
			// 
			this.btSetRpyPGain.Location = new System.Drawing.Point(6, 30);
			this.btSetRpyPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btSetRpyPGain.Name = "btSetRpyPGain";
			this.btSetRpyPGain.Size = new System.Drawing.Size(188, 30);
			this.btSetRpyPGain.TabIndex = 34;
			this.btSetRpyPGain.Text = "Set Error P Gain";
			this.btSetRpyPGain.UseVisualStyleBackColor = true;
			this.btSetRpyPGain.Click += new System.EventHandler(this.btSetRpyPGain_Click);
			// 
			// btBiasZ
			// 
			this.btBiasZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasZ.Location = new System.Drawing.Point(20, 256);
			this.btBiasZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasZ.Name = "btBiasZ";
			this.btBiasZ.Size = new System.Drawing.Size(139, 32);
			this.btBiasZ.TabIndex = 69;
			this.btBiasZ.Text = "Bias Z";
			this.btBiasZ.UseVisualStyleBackColor = true;
			// 
			// btBiasY
			// 
			this.btBiasY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasY.Location = new System.Drawing.Point(20, 220);
			this.btBiasY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasY.Name = "btBiasY";
			this.btBiasY.Size = new System.Drawing.Size(139, 32);
			this.btBiasY.TabIndex = 68;
			this.btBiasY.Text = "Bias Y";
			this.btBiasY.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 165);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 17);
			this.label1.TabIndex = 67;
			this.label1.Text = "Bias Values (e-5)";
			// 
			// btBiasX
			// 
			this.btBiasX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasX.Location = new System.Drawing.Point(20, 184);
			this.btBiasX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasX.Name = "btBiasX";
			this.btBiasX.Size = new System.Drawing.Size(139, 32);
			this.btBiasX.TabIndex = 66;
			this.btBiasX.Text = "Bias X";
			this.btBiasX.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(166, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 17);
			this.label6.TabIndex = 71;
			this.label6.Text = "Weights";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// btRpyWeight
			// 
			this.btRpyWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btRpyWeight.Location = new System.Drawing.Point(166, 42);
			this.btRpyWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btRpyWeight.Name = "btRpyWeight";
			this.btRpyWeight.Size = new System.Drawing.Size(139, 32);
			this.btRpyWeight.TabIndex = 70;
			this.btRpyWeight.Text = "RPY Weight";
			this.btRpyWeight.UseVisualStyleBackColor = true;
			// 
			// btBiasWeight
			// 
			this.btBiasWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasWeight.Location = new System.Drawing.Point(166, 78);
			this.btBiasWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasWeight.Name = "btBiasWeight";
			this.btBiasWeight.Size = new System.Drawing.Size(139, 32);
			this.btBiasWeight.TabIndex = 72;
			this.btBiasWeight.Text = "Bias Weight";
			this.btBiasWeight.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btStable);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btBiasGate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btRpyGate);
			this.groupBox1.Controls.Add(this.btBiasTrendZ);
			this.groupBox1.Controls.Add(this.btBiasTrendX);
			this.groupBox1.Controls.Add(this.btBiasTrendY);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.btYaw);
			this.groupBox1.Controls.Add(this.btRoll);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.btPitch);
			this.groupBox1.Controls.Add(this.btBiasWeight);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btBiasZ);
			this.groupBox1.Controls.Add(this.btBiasX);
			this.groupBox1.Controls.Add(this.btBiasY);
			this.groupBox1.Controls.Add(this.btRpyWeight);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(318, 430);
			this.groupBox1.TabIndex = 73;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Monitor";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(169, 301);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 17);
			this.label3.TabIndex = 84;
			this.label3.Text = "Bias Gate";
			// 
			// btBiasGate
			// 
			this.btBiasGate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasGate.Location = new System.Drawing.Point(169, 320);
			this.btBiasGate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasGate.Name = "btBiasGate";
			this.btBiasGate.Size = new System.Drawing.Size(139, 32);
			this.btBiasGate.TabIndex = 83;
			this.btBiasGate.Text = "Bias Weight";
			this.btBiasGate.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 301);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 17);
			this.label2.TabIndex = 82;
			this.label2.Text = "RPY Gate";
			// 
			// btRpyGate
			// 
			this.btRpyGate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btRpyGate.Location = new System.Drawing.Point(20, 320);
			this.btRpyGate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btRpyGate.Name = "btRpyGate";
			this.btRpyGate.Size = new System.Drawing.Size(139, 32);
			this.btRpyGate.TabIndex = 81;
			this.btRpyGate.Text = "RPY Gate";
			this.btRpyGate.UseVisualStyleBackColor = true;
			// 
			// btBiasTrendZ
			// 
			this.btBiasTrendZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasTrendZ.Location = new System.Drawing.Point(169, 256);
			this.btBiasTrendZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasTrendZ.Name = "btBiasTrendZ";
			this.btBiasTrendZ.Size = new System.Drawing.Size(139, 32);
			this.btBiasTrendZ.TabIndex = 80;
			this.btBiasTrendZ.Text = "Bias Trend Z";
			this.btBiasTrendZ.UseVisualStyleBackColor = true;
			// 
			// btBiasTrendX
			// 
			this.btBiasTrendX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasTrendX.Location = new System.Drawing.Point(169, 184);
			this.btBiasTrendX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasTrendX.Name = "btBiasTrendX";
			this.btBiasTrendX.Size = new System.Drawing.Size(139, 32);
			this.btBiasTrendX.TabIndex = 77;
			this.btBiasTrendX.Text = "Bias Trend X";
			this.btBiasTrendX.UseVisualStyleBackColor = true;
			// 
			// btBiasTrendY
			// 
			this.btBiasTrendY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBiasTrendY.Location = new System.Drawing.Point(169, 220);
			this.btBiasTrendY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBiasTrendY.Name = "btBiasTrendY";
			this.btBiasTrendY.Size = new System.Drawing.Size(139, 32);
			this.btBiasTrendY.TabIndex = 79;
			this.btBiasTrendY.Text = "Bias Trend Y";
			this.btBiasTrendY.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(169, 165);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 17);
			this.label8.TabIndex = 78;
			this.label8.Text = "Bias Trend";
			// 
			// btYaw
			// 
			this.btYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btYaw.Location = new System.Drawing.Point(17, 114);
			this.btYaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btYaw.Name = "btYaw";
			this.btYaw.Size = new System.Drawing.Size(139, 32);
			this.btYaw.TabIndex = 76;
			this.btYaw.Text = "Yaw";
			this.btYaw.UseVisualStyleBackColor = true;
			// 
			// btRoll
			// 
			this.btRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btRoll.Location = new System.Drawing.Point(17, 42);
			this.btRoll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btRoll.Name = "btRoll";
			this.btRoll.Size = new System.Drawing.Size(139, 32);
			this.btRoll.TabIndex = 73;
			this.btRoll.Text = "Roll";
			this.btRoll.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 17);
			this.label7.TabIndex = 74;
			this.label7.Text = "Roll Pitch Yaw";
			// 
			// btPitch
			// 
			this.btPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btPitch.Location = new System.Drawing.Point(17, 78);
			this.btPitch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btPitch.Name = "btPitch";
			this.btPitch.Size = new System.Drawing.Size(139, 32);
			this.btPitch.TabIndex = 75;
			this.btPitch.Text = "Pitch";
			this.btPitch.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btSetYawIGain);
			this.groupBox2.Controls.Add(this.tbYawIGain);
			this.groupBox2.Controls.Add(this.btSetYawPGain);
			this.groupBox2.Controls.Add(this.tbYawPGain);
			this.groupBox2.Controls.Add(this.btSetBiasIGain);
			this.groupBox2.Controls.Add(this.tbBiasIGain);
			this.groupBox2.Controls.Add(this.btSetRpyPGain);
			this.groupBox2.Controls.Add(this.tbRpyPGain);
			this.groupBox2.Location = new System.Drawing.Point(12, 504);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(318, 209);
			this.groupBox2.TabIndex = 74;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Control (1000X)";
			// 
			// btSetYawIGain
			// 
			this.btSetYawIGain.Location = new System.Drawing.Point(6, 145);
			this.btSetYawIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btSetYawIGain.Name = "btSetYawIGain";
			this.btSetYawIGain.Size = new System.Drawing.Size(188, 30);
			this.btSetYawIGain.TabIndex = 41;
			this.btSetYawIGain.Text = "Set Yaw I Gain";
			this.btSetYawIGain.UseVisualStyleBackColor = true;
			this.btSetYawIGain.Click += new System.EventHandler(this.btSetYawIGain_Click);
			// 
			// tbYawIGain
			// 
			this.tbYawIGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbYawIGain.Location = new System.Drawing.Point(200, 145);
			this.tbYawIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbYawIGain.Name = "tbYawIGain";
			this.tbYawIGain.Size = new System.Drawing.Size(105, 30);
			this.tbYawIGain.TabIndex = 42;
			this.tbYawIGain.Text = ".02";
			this.tbYawIGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btSetYawPGain
			// 
			this.btSetYawPGain.Location = new System.Drawing.Point(6, 111);
			this.btSetYawPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btSetYawPGain.Name = "btSetYawPGain";
			this.btSetYawPGain.Size = new System.Drawing.Size(188, 30);
			this.btSetYawPGain.TabIndex = 39;
			this.btSetYawPGain.Text = "Set Yaw Error P Gain";
			this.btSetYawPGain.UseVisualStyleBackColor = true;
			this.btSetYawPGain.Click += new System.EventHandler(this.btSetYawPGain_Click);
			// 
			// tbYawPGain
			// 
			this.tbYawPGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbYawPGain.Location = new System.Drawing.Point(200, 111);
			this.tbYawPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbYawPGain.Name = "tbYawPGain";
			this.tbYawPGain.Size = new System.Drawing.Size(105, 30);
			this.tbYawPGain.TabIndex = 40;
			this.tbYawPGain.Text = "10";
			this.tbYawPGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btSetBiasIGain
			// 
			this.btSetBiasIGain.Location = new System.Drawing.Point(6, 64);
			this.btSetBiasIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btSetBiasIGain.Name = "btSetBiasIGain";
			this.btSetBiasIGain.Size = new System.Drawing.Size(188, 30);
			this.btSetBiasIGain.TabIndex = 37;
			this.btSetBiasIGain.Text = "Set Bias I Gain";
			this.btSetBiasIGain.UseVisualStyleBackColor = true;
			this.btSetBiasIGain.Click += new System.EventHandler(this.btSetBiasIGain_Click);
			// 
			// tbBiasIGain
			// 
			this.tbBiasIGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbBiasIGain.Location = new System.Drawing.Point(200, 64);
			this.tbBiasIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbBiasIGain.Name = "tbBiasIGain";
			this.tbBiasIGain.Size = new System.Drawing.Size(105, 30);
			this.tbBiasIGain.TabIndex = 38;
			this.tbBiasIGain.Text = ".02";
			this.tbBiasIGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btFreeGyro
			// 
			this.btFreeGyro.Location = new System.Drawing.Point(453, 670);
			this.btFreeGyro.Name = "btFreeGyro";
			this.btFreeGyro.Size = new System.Drawing.Size(163, 42);
			this.btFreeGyro.TabIndex = 75;
			this.btFreeGyro.Text = "Toggle Free Gyro";
			this.btFreeGyro.UseVisualStyleBackColor = true;
			this.btFreeGyro.Click += new System.EventHandler(this.btFreeGyro_Click);
			// 
			// btResetAhrs
			// 
			this.btResetAhrs.Location = new System.Drawing.Point(622, 670);
			this.btResetAhrs.Name = "btResetAhrs";
			this.btResetAhrs.Size = new System.Drawing.Size(163, 42);
			this.btResetAhrs.TabIndex = 76;
			this.btResetAhrs.Text = "Reset AHRS";
			this.btResetAhrs.UseVisualStyleBackColor = true;
			this.btResetAhrs.Click += new System.EventHandler(this.btResetAhrs_Click);
			// 
			// btShowBias
			// 
			this.btShowBias.Location = new System.Drawing.Point(453, 52);
			this.btShowBias.Name = "btShowBias";
			this.btShowBias.Size = new System.Drawing.Size(98, 30);
			this.btShowBias.TabIndex = 77;
			this.btShowBias.Text = "Bias";
			this.btShowBias.UseVisualStyleBackColor = true;
			this.btShowBias.Click += new System.EventHandler(this.btShowBias_Click);
			// 
			// btShowBiasTrend
			// 
			this.btShowBiasTrend.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btShowBiasTrend.Location = new System.Drawing.Point(557, 52);
			this.btShowBiasTrend.Name = "btShowBiasTrend";
			this.btShowBiasTrend.Size = new System.Drawing.Size(98, 30);
			this.btShowBiasTrend.TabIndex = 78;
			this.btShowBiasTrend.Text = "Bias Trend";
			this.btShowBiasTrend.UseVisualStyleBackColor = true;
			this.btShowBiasTrend.Click += new System.EventHandler(this.btShowBiasTrend_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(350, 53);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 29);
			this.label9.TabIndex = 79;
			this.label9.Text = "Show:";
			// 
			// btRefreshCom
			// 
			this.btRefreshCom.Location = new System.Drawing.Point(29, 12);
			this.btRefreshCom.Name = "btRefreshCom";
			this.btRefreshCom.Size = new System.Drawing.Size(182, 34);
			this.btRefreshCom.TabIndex = 80;
			this.btRefreshCom.Text = "Refresh Com Link";
			this.btRefreshCom.UseVisualStyleBackColor = true;
			this.btRefreshCom.Click += new System.EventHandler(this.btRefreshCom_Click);
			// 
			// btStable
			// 
			this.btStable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btStable.Location = new System.Drawing.Point(166, 114);
			this.btStable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btStable.Name = "btStable";
			this.btStable.Size = new System.Drawing.Size(139, 32);
			this.btStable.TabIndex = 85;
			this.btStable.Text = "ALIGN";
			this.btStable.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(1398, 755);
			this.Controls.Add(this.btRefreshCom);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btShowBiasTrend);
			this.Controls.Add(this.btShowBias);
			this.Controls.Add(this.btResetAhrs);
			this.Controls.Add(this.btFreeGyro);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btMicroScale);
			this.Controls.Add(this.btMidScale);
			this.Controls.Add(this.btMaxScale);
			this.Controls.Add(this.pbTempGraph);
			this.Name = "MainForm";
			this.Text = "AhrsTune";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btMicroScale;
		private System.Windows.Forms.Button btMidScale;
		private System.Windows.Forms.Button btMaxScale;
		public System.Windows.Forms.PictureBox pbTempGraph;
		private System.Windows.Forms.TextBox tbRpyPGain;
		private System.Windows.Forms.Button btSetRpyPGain;
		private System.Windows.Forms.Button btBiasZ;
		private System.Windows.Forms.Button btBiasY;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btBiasX;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btRpyWeight;
		private System.Windows.Forms.Button btBiasWeight;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btSetYawIGain;
		private System.Windows.Forms.TextBox tbYawIGain;
		private System.Windows.Forms.Button btSetYawPGain;
		private System.Windows.Forms.TextBox tbYawPGain;
		private System.Windows.Forms.Button btSetBiasIGain;
		private System.Windows.Forms.TextBox tbBiasIGain;
		private System.Windows.Forms.Button btYaw;
		private System.Windows.Forms.Button btRoll;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btPitch;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btFreeGyro;
		private System.Windows.Forms.Button btResetAhrs;
		private System.Windows.Forms.Button btBiasTrendZ;
		private System.Windows.Forms.Button btBiasTrendX;
		private System.Windows.Forms.Button btBiasTrendY;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btShowBias;
		private System.Windows.Forms.Button btShowBiasTrend;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btRefreshCom;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btBiasGate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btRpyGate;
		private System.Windows.Forms.Button btStable;
	}
}

