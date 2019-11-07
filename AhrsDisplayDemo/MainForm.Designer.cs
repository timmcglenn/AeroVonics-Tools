namespace AhrsDisplayDemo
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
			this.btRoll = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.gbSerial = new System.Windows.Forms.GroupBox();
			this.cbSerialPort = new System.Windows.Forms.ComboBox();
			this.gbConsole = new System.Windows.Forms.GroupBox();
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btPitch = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.BtVolts = new System.Windows.Forms.Button();
			this.btIas = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btTas = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btOat = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btBca = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.btAoa = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tcFlightDataTab = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btResetMinMax = new System.Windows.Forms.Button();
			this.btHeading = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.btMagZNorm = new System.Windows.Forms.Button();
			this.btMagZ = new System.Windows.Forms.Button();
			this.btMagY = new System.Windows.Forms.Button();
			this.btMagXNorm = new System.Windows.Forms.Button();
			this.btMagX = new System.Windows.Forms.Button();
			this.btMagYNorm = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.btMagZCent = new System.Windows.Forms.Button();
			this.btMagXCent = new System.Windows.Forms.Button();
			this.btMagYCent = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.btMagZOffset = new System.Windows.Forms.Button();
			this.btMagXOffset = new System.Windows.Forms.Button();
			this.btMagYOffset = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.btMagZDelta = new System.Windows.Forms.Button();
			this.btMagXDelta = new System.Windows.Forms.Button();
			this.btMagYDelta = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.btMagZMin = new System.Windows.Forms.Button();
			this.btMagXMin = new System.Windows.Forms.Button();
			this.btMagYMin = new System.Windows.Forms.Button();
			this.btMagZMax = new System.Windows.Forms.Button();
			this.btMagXMax = new System.Windows.Forms.Button();
			this.btMagYMax = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btConnect = new System.Windows.Forms.Button();
			this.pbCompass = new System.Windows.Forms.PictureBox();
			this.gbSerial.SuspendLayout();
			this.gbConsole.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tcFlightDataTab.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCompass)).BeginInit();
			this.SuspendLayout();
			// 
			// btRoll
			// 
			this.btRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btRoll.Location = new System.Drawing.Point(42, 49);
			this.btRoll.Name = "btRoll";
			this.btRoll.Size = new System.Drawing.Size(305, 130);
			this.btRoll.TabIndex = 0;
			this.btRoll.Text = "0.0";
			this.btRoll.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(37, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Roll (Deg)";
			// 
			// gbSerial
			// 
			this.gbSerial.Controls.Add(this.cbSerialPort);
			this.gbSerial.Location = new System.Drawing.Point(27, 12);
			this.gbSerial.Name = "gbSerial";
			this.gbSerial.Size = new System.Drawing.Size(240, 67);
			this.gbSerial.TabIndex = 2;
			this.gbSerial.TabStop = false;
			this.gbSerial.Text = "Serial Connection";
			// 
			// cbSerialPort
			// 
			this.cbSerialPort.FormattingEnabled = true;
			this.cbSerialPort.Location = new System.Drawing.Point(6, 26);
			this.cbSerialPort.Name = "cbSerialPort";
			this.cbSerialPort.Size = new System.Drawing.Size(214, 24);
			this.cbSerialPort.TabIndex = 0;
			this.cbSerialPort.SelectedIndexChanged += new System.EventHandler(this.cbSerialPort_SelectedIndexChanged);
			// 
			// gbConsole
			// 
			this.gbConsole.Controls.Add(this.tbConsole);
			this.gbConsole.ForeColor = System.Drawing.Color.Silver;
			this.gbConsole.Location = new System.Drawing.Point(27, 174);
			this.gbConsole.Name = "gbConsole";
			this.gbConsole.Size = new System.Drawing.Size(240, 477);
			this.gbConsole.TabIndex = 5;
			this.gbConsole.TabStop = false;
			this.gbConsole.Text = "Console";
			// 
			// tbConsole
			// 
			this.tbConsole.Location = new System.Drawing.Point(6, 29);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.Size = new System.Drawing.Size(214, 419);
			this.tbConsole.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btPitch
			// 
			this.btPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btPitch.Location = new System.Drawing.Point(42, 223);
			this.btPitch.Name = "btPitch";
			this.btPitch.Size = new System.Drawing.Size(305, 130);
			this.btPitch.TabIndex = 6;
			this.btPitch.Text = "0.0";
			this.btPitch.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(37, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 25);
			this.label2.TabIndex = 7;
			this.label2.Text = "Pitch (Deg)";
			// 
			// BtVolts
			// 
			this.BtVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtVolts.Location = new System.Drawing.Point(586, 352);
			this.BtVolts.Name = "BtVolts";
			this.BtVolts.Size = new System.Drawing.Size(225, 72);
			this.BtVolts.TabIndex = 8;
			this.BtVolts.Text = "0.0";
			this.BtVolts.UseVisualStyleBackColor = true;
			// 
			// btIas
			// 
			this.btIas.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btIas.Location = new System.Drawing.Point(372, 49);
			this.btIas.Name = "btIas";
			this.btIas.Size = new System.Drawing.Size(185, 101);
			this.btIas.TabIndex = 14;
			this.btIas.Text = "0.0";
			this.btIas.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(367, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 25);
			this.label6.TabIndex = 15;
			this.label6.Text = "IAS (kts)";
			// 
			// btTas
			// 
			this.btTas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btTas.Location = new System.Drawing.Point(372, 223);
			this.btTas.Name = "btTas";
			this.btTas.Size = new System.Drawing.Size(185, 72);
			this.btTas.TabIndex = 16;
			this.btTas.Text = "0.0";
			this.btTas.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(367, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 25);
			this.label7.TabIndex = 17;
			this.label7.Text = "TAS (kts)";
			// 
			// btOat
			// 
			this.btOat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btOat.Location = new System.Drawing.Point(372, 352);
			this.btOat.Name = "btOat";
			this.btOat.Size = new System.Drawing.Size(185, 72);
			this.btOat.TabIndex = 21;
			this.btOat.Text = "0.0";
			this.btOat.UseVisualStyleBackColor = true;
			this.btOat.Click += new System.EventHandler(this.button1_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(367, 324);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 25);
			this.label5.TabIndex = 20;
			this.label5.Text = "OAT (c)";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(591, 324);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(124, 25);
			this.label9.TabIndex = 22;
			this.label9.Text = "Bus Volts (v)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(581, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(106, 25);
			this.label8.TabIndex = 24;
			this.label8.Text = "Altitude (ft)";
			// 
			// btBca
			// 
			this.btBca.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBca.Location = new System.Drawing.Point(586, 46);
			this.btBca.Name = "btBca";
			this.btBca.Size = new System.Drawing.Size(225, 104);
			this.btBca.TabIndex = 23;
			this.btBca.Text = "0.0";
			this.btBca.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(581, 195);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(201, 25);
			this.label11.TabIndex = 28;
			this.label11.Text = "Angle Of Attack (deg)";
			// 
			// btAoa
			// 
			this.btAoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btAoa.Location = new System.Drawing.Point(586, 223);
			this.btAoa.Name = "btAoa";
			this.btAoa.Size = new System.Drawing.Size(225, 72);
			this.btAoa.TabIndex = 27;
			this.btAoa.Text = "0.0";
			this.btAoa.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tcFlightDataTab);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.HotTrack = true;
			this.tabControl1.Location = new System.Drawing.Point(290, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(846, 639);
			this.tabControl1.TabIndex = 29;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexchanged);
			// 
			// tcFlightDataTab
			// 
			this.tcFlightDataTab.Controls.Add(this.btRoll);
			this.tcFlightDataTab.Controls.Add(this.label11);
			this.tcFlightDataTab.Controls.Add(this.label1);
			this.tcFlightDataTab.Controls.Add(this.btAoa);
			this.tcFlightDataTab.Controls.Add(this.label9);
			this.tcFlightDataTab.Controls.Add(this.btPitch);
			this.tcFlightDataTab.Controls.Add(this.btOat);
			this.tcFlightDataTab.Controls.Add(this.label2);
			this.tcFlightDataTab.Controls.Add(this.label5);
			this.tcFlightDataTab.Controls.Add(this.label7);
			this.tcFlightDataTab.Controls.Add(this.label8);
			this.tcFlightDataTab.Controls.Add(this.btIas);
			this.tcFlightDataTab.Controls.Add(this.label6);
			this.tcFlightDataTab.Controls.Add(this.btBca);
			this.tcFlightDataTab.Controls.Add(this.BtVolts);
			this.tcFlightDataTab.Controls.Add(this.btTas);
			this.tcFlightDataTab.Location = new System.Drawing.Point(4, 25);
			this.tcFlightDataTab.Name = "tcFlightDataTab";
			this.tcFlightDataTab.Padding = new System.Windows.Forms.Padding(3);
			this.tcFlightDataTab.Size = new System.Drawing.Size(838, 610);
			this.tcFlightDataTab.TabIndex = 0;
			this.tcFlightDataTab.Text = "Flight Data";
			this.tcFlightDataTab.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.pbCompass);
			this.tabPage2.Controls.Add(this.pictureBox1);
			this.tabPage2.Controls.Add(this.btResetMinMax);
			this.tabPage2.Controls.Add(this.btHeading);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.btMagZNorm);
			this.tabPage2.Controls.Add(this.btMagZ);
			this.tabPage2.Controls.Add(this.btMagY);
			this.tabPage2.Controls.Add(this.btMagXNorm);
			this.tabPage2.Controls.Add(this.btMagX);
			this.tabPage2.Controls.Add(this.btMagYNorm);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.btMagZCent);
			this.tabPage2.Controls.Add(this.btMagXCent);
			this.tabPage2.Controls.Add(this.btMagYCent);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.btMagZOffset);
			this.tabPage2.Controls.Add(this.btMagXOffset);
			this.tabPage2.Controls.Add(this.btMagYOffset);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.btMagZDelta);
			this.tabPage2.Controls.Add(this.btMagXDelta);
			this.tabPage2.Controls.Add(this.btMagYDelta);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.btMagZMin);
			this.tabPage2.Controls.Add(this.btMagXMin);
			this.tabPage2.Controls.Add(this.btMagYMin);
			this.tabPage2.Controls.Add(this.btMagZMax);
			this.tabPage2.Controls.Add(this.btMagXMax);
			this.tabPage2.Controls.Add(this.btMagYMax);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(838, 610);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Magnetics";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 50);
			this.pictureBox1.TabIndex = 75;
			this.pictureBox1.TabStop = false;
			// 
			// btResetMinMax
			// 
			this.btResetMinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btResetMinMax.Location = new System.Drawing.Point(605, 50);
			this.btResetMinMax.Name = "btResetMinMax";
			this.btResetMinMax.Size = new System.Drawing.Size(147, 50);
			this.btResetMinMax.TabIndex = 74;
			this.btResetMinMax.Text = "Reset Cal";
			this.btResetMinMax.UseVisualStyleBackColor = true;
			this.btResetMinMax.Click += new System.EventHandler(this.btResetMinMax_Click_1);
			// 
			// btHeading
			// 
			this.btHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btHeading.Location = new System.Drawing.Point(248, 515);
			this.btHeading.Name = "btHeading";
			this.btHeading.Size = new System.Drawing.Size(147, 72);
			this.btHeading.TabIndex = 73;
			this.btHeading.Text = "0.0";
			this.btHeading.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(25, 433);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(59, 25);
			this.label18.TabIndex = 72;
			this.label18.Text = "Norm";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btMagZNorm
			// 
			this.btMagZNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZNorm.Location = new System.Drawing.Point(398, 425);
			this.btMagZNorm.Name = "btMagZNorm";
			this.btMagZNorm.Size = new System.Drawing.Size(147, 42);
			this.btMagZNorm.TabIndex = 71;
			this.btMagZNorm.Text = "0";
			this.btMagZNorm.UseVisualStyleBackColor = true;
			// 
			// btMagZ
			// 
			this.btMagZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZ.Location = new System.Drawing.Point(399, 50);
			this.btMagZ.Name = "btMagZ";
			this.btMagZ.Size = new System.Drawing.Size(147, 59);
			this.btMagZ.TabIndex = 46;
			this.btMagZ.Text = "0.0";
			this.btMagZ.UseVisualStyleBackColor = true;
			// 
			// btMagY
			// 
			this.btMagY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagY.Location = new System.Drawing.Point(253, 50);
			this.btMagY.Name = "btMagY";
			this.btMagY.Size = new System.Drawing.Size(135, 59);
			this.btMagY.TabIndex = 43;
			this.btMagY.Text = "0.0";
			this.btMagY.UseVisualStyleBackColor = true;
			// 
			// btMagXNorm
			// 
			this.btMagXNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXNorm.Location = new System.Drawing.Point(94, 425);
			this.btMagXNorm.Name = "btMagXNorm";
			this.btMagXNorm.Size = new System.Drawing.Size(147, 42);
			this.btMagXNorm.TabIndex = 70;
			this.btMagXNorm.Text = "0";
			this.btMagXNorm.UseVisualStyleBackColor = true;
			// 
			// btMagX
			// 
			this.btMagX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagX.Location = new System.Drawing.Point(95, 50);
			this.btMagX.Name = "btMagX";
			this.btMagX.Size = new System.Drawing.Size(147, 59);
			this.btMagX.TabIndex = 45;
			this.btMagX.Text = "0.0";
			this.btMagX.UseVisualStyleBackColor = true;
			// 
			// btMagYNorm
			// 
			this.btMagYNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYNorm.Location = new System.Drawing.Point(252, 425);
			this.btMagYNorm.Name = "btMagYNorm";
			this.btMagYNorm.Size = new System.Drawing.Size(135, 42);
			this.btMagYNorm.TabIndex = 69;
			this.btMagYNorm.Text = "0";
			this.btMagYNorm.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(39, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 25);
			this.label12.TabIndex = 54;
			this.label12.Text = "Cur";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(0, 368);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(93, 25);
			this.label17.TabIndex = 68;
			this.label17.Text = "Centered";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btMagZCent
			// 
			this.btMagZCent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZCent.Location = new System.Drawing.Point(398, 359);
			this.btMagZCent.Name = "btMagZCent";
			this.btMagZCent.Size = new System.Drawing.Size(147, 42);
			this.btMagZCent.TabIndex = 67;
			this.btMagZCent.Text = "0";
			this.btMagZCent.UseVisualStyleBackColor = true;
			// 
			// btMagXCent
			// 
			this.btMagXCent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXCent.Location = new System.Drawing.Point(94, 359);
			this.btMagXCent.Name = "btMagXCent";
			this.btMagXCent.Size = new System.Drawing.Size(147, 42);
			this.btMagXCent.TabIndex = 66;
			this.btMagXCent.Text = "0";
			this.btMagXCent.UseVisualStyleBackColor = true;
			// 
			// btMagYCent
			// 
			this.btMagYCent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYCent.Location = new System.Drawing.Point(252, 359);
			this.btMagYCent.Name = "btMagYCent";
			this.btMagYCent.Size = new System.Drawing.Size(135, 42);
			this.btMagYCent.TabIndex = 65;
			this.btMagYCent.Text = "0";
			this.btMagYCent.UseVisualStyleBackColor = true;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(24, 312);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 25);
			this.label16.TabIndex = 64;
			this.label16.Text = "Offset";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btMagZOffset
			// 
			this.btMagZOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZOffset.Location = new System.Drawing.Point(399, 304);
			this.btMagZOffset.Name = "btMagZOffset";
			this.btMagZOffset.Size = new System.Drawing.Size(147, 42);
			this.btMagZOffset.TabIndex = 63;
			this.btMagZOffset.Text = "0";
			this.btMagZOffset.UseVisualStyleBackColor = true;
			// 
			// btMagXOffset
			// 
			this.btMagXOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXOffset.Location = new System.Drawing.Point(95, 304);
			this.btMagXOffset.Name = "btMagXOffset";
			this.btMagXOffset.Size = new System.Drawing.Size(147, 42);
			this.btMagXOffset.TabIndex = 62;
			this.btMagXOffset.Text = "0";
			this.btMagXOffset.UseVisualStyleBackColor = true;
			// 
			// btMagYOffset
			// 
			this.btMagYOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYOffset.Location = new System.Drawing.Point(253, 304);
			this.btMagYOffset.Name = "btMagYOffset";
			this.btMagYOffset.Size = new System.Drawing.Size(135, 42);
			this.btMagYOffset.TabIndex = 61;
			this.btMagYOffset.Text = "0";
			this.btMagYOffset.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(31, 260);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(57, 25);
			this.label15.TabIndex = 60;
			this.label15.Text = "Delta";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btMagZDelta
			// 
			this.btMagZDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZDelta.Location = new System.Drawing.Point(399, 251);
			this.btMagZDelta.Name = "btMagZDelta";
			this.btMagZDelta.Size = new System.Drawing.Size(147, 42);
			this.btMagZDelta.TabIndex = 59;
			this.btMagZDelta.Text = "0";
			this.btMagZDelta.UseVisualStyleBackColor = true;
			// 
			// btMagXDelta
			// 
			this.btMagXDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXDelta.Location = new System.Drawing.Point(95, 251);
			this.btMagXDelta.Name = "btMagXDelta";
			this.btMagXDelta.Size = new System.Drawing.Size(147, 42);
			this.btMagXDelta.TabIndex = 58;
			this.btMagXDelta.Text = "0";
			this.btMagXDelta.UseVisualStyleBackColor = true;
			// 
			// btMagYDelta
			// 
			this.btMagYDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYDelta.Location = new System.Drawing.Point(253, 251);
			this.btMagYDelta.Name = "btMagYDelta";
			this.btMagYDelta.Size = new System.Drawing.Size(135, 42);
			this.btMagYDelta.TabIndex = 57;
			this.btMagYDelta.Text = "0";
			this.btMagYDelta.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(35, 191);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(50, 25);
			this.label14.TabIndex = 56;
			this.label14.Text = "Max";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(37, 133);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 25);
			this.label13.TabIndex = 55;
			this.label13.Text = "Min";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btMagZMin
			// 
			this.btMagZMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZMin.Location = new System.Drawing.Point(399, 126);
			this.btMagZMin.Name = "btMagZMin";
			this.btMagZMin.Size = new System.Drawing.Size(147, 42);
			this.btMagZMin.TabIndex = 53;
			this.btMagZMin.Text = "9999";
			this.btMagZMin.UseVisualStyleBackColor = true;
			// 
			// btMagXMin
			// 
			this.btMagXMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXMin.Location = new System.Drawing.Point(95, 126);
			this.btMagXMin.Name = "btMagXMin";
			this.btMagXMin.Size = new System.Drawing.Size(147, 42);
			this.btMagXMin.TabIndex = 52;
			this.btMagXMin.Text = "9999";
			this.btMagXMin.UseVisualStyleBackColor = true;
			// 
			// btMagYMin
			// 
			this.btMagYMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYMin.Location = new System.Drawing.Point(253, 126);
			this.btMagYMin.Name = "btMagYMin";
			this.btMagYMin.Size = new System.Drawing.Size(135, 42);
			this.btMagYMin.TabIndex = 51;
			this.btMagYMin.Text = "9999";
			this.btMagYMin.UseVisualStyleBackColor = true;
			// 
			// btMagZMax
			// 
			this.btMagZMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagZMax.Location = new System.Drawing.Point(399, 182);
			this.btMagZMax.Name = "btMagZMax";
			this.btMagZMax.Size = new System.Drawing.Size(147, 42);
			this.btMagZMax.TabIndex = 50;
			this.btMagZMax.Text = "-9999";
			this.btMagZMax.UseVisualStyleBackColor = true;
			// 
			// btMagXMax
			// 
			this.btMagXMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagXMax.Location = new System.Drawing.Point(95, 182);
			this.btMagXMax.Name = "btMagXMax";
			this.btMagXMax.Size = new System.Drawing.Size(147, 42);
			this.btMagXMax.TabIndex = 49;
			this.btMagXMax.Text = "-9999";
			this.btMagXMax.UseVisualStyleBackColor = true;
			// 
			// btMagYMax
			// 
			this.btMagYMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btMagYMax.Location = new System.Drawing.Point(253, 182);
			this.btMagYMax.Name = "btMagYMax";
			this.btMagYMax.Size = new System.Drawing.Size(135, 42);
			this.btMagYMax.TabIndex = 48;
			this.btMagYMax.Text = "-9999";
			this.btMagYMax.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(432, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 25);
			this.label10.TabIndex = 47;
			this.label10.Text = "Mag Z";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(275, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 25);
			this.label4.TabIndex = 44;
			this.label4.Text = "Mag Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(129, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 25);
			this.label3.TabIndex = 42;
			this.label3.Text = "Mag X";
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(34, 107);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(212, 39);
			this.btConnect.TabIndex = 30;
			this.btConnect.Text = "Connect";
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// pbCompass
			// 
			this.pbCompass.BackColor = System.Drawing.Color.DarkGray;
			this.pbCompass.Location = new System.Drawing.Point(576, 256);
			this.pbCompass.Name = "pbCompass";
			this.pbCompass.Size = new System.Drawing.Size(213, 210);
			this.pbCompass.TabIndex = 76;
			this.pbCompass.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1162, 697);
			this.Controls.Add(this.btConnect);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.gbSerial);
			this.Controls.Add(this.gbConsole);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			this.gbSerial.ResumeLayout(false);
			this.gbConsole.ResumeLayout(false);
			this.gbConsole.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tcFlightDataTab.ResumeLayout(false);
			this.tcFlightDataTab.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCompass)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.GroupBox gbConsole;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btPitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtVolts;
        private System.Windows.Forms.Button btIas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btTas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btOat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btBca;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btAoa;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tcFlightDataTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button btMagZDelta;
		private System.Windows.Forms.Button btMagXDelta;
		private System.Windows.Forms.Button btMagYDelta;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btMagZMin;
		private System.Windows.Forms.Button btMagXMin;
		private System.Windows.Forms.Button btMagYMin;
		private System.Windows.Forms.Button btMagZMax;
		private System.Windows.Forms.Button btMagXMax;
		private System.Windows.Forms.Button btMagYMax;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btMagZ;
		private System.Windows.Forms.Button btMagX;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btMagY;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btMagZOffset;
		private System.Windows.Forms.Button btMagXOffset;
		private System.Windows.Forms.Button btMagYOffset;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btMagZCent;
		private System.Windows.Forms.Button btMagXCent;
		private System.Windows.Forms.Button btMagYCent;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button btMagZNorm;
		private System.Windows.Forms.Button btMagXNorm;
		private System.Windows.Forms.Button btMagYNorm;
		private System.Windows.Forms.Button btHeading;
		private System.Windows.Forms.Button btResetMinMax;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pbCompass;
	}
}

