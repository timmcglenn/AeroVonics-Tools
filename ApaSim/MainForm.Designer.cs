namespace ApaSim
{
    partial class Form1
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
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPacket1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPacket2 = new System.Windows.Forms.TextBox();
            this.tbRoll = new System.Windows.Forms.TextBox();
            this.tbPacket3 = new System.Windows.Forms.TextBox();
            this.tbPitch = new System.Windows.Forms.TextBox();
            this.tbPacket4 = new System.Windows.Forms.TextBox();
            this.tbYaw = new System.Windows.Forms.TextBox();
            this.tbPacket5 = new System.Windows.Forms.TextBox();
            this.tbHdgDatum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPacket6 = new System.Windows.Forms.TextBox();
            this.tbCrsDatum = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btTx = new System.Windows.Forms.Button();
            this.sliderRoll = new System.Windows.Forms.TrackBar();
            this.sliderPitch = new System.Windows.Forms.TrackBar();
            this.cbAhrsValid = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbSendStatus = new System.Windows.Forms.CheckBox();
            this.cbSendRoll = new System.Windows.Forms.CheckBox();
            this.cbSendPitch = new System.Windows.Forms.CheckBox();
            this.cbSendYaw = new System.Windows.Forms.CheckBox();
            this.cbSendHdgDatum = new System.Windows.Forms.CheckBox();
            this.cbSendCrsDatum = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.sliderYaw = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.sliderHdgDatum = new System.Windows.Forms.TrackBar();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.sliderCrsDatum = new System.Windows.Forms.TrackBar();
            this.tbOutputString = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbAutoSlew = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHdgDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderCrsDatum)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(289, 91);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(135, 20);
            this.tbStatus.TabIndex = 0;
            this.tbStatus.Text = "1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apa Status";
            // 
            // tbPacket1
            // 
            this.tbPacket1.Location = new System.Drawing.Point(211, 91);
            this.tbPacket1.Name = "tbPacket1";
            this.tbPacket1.Size = new System.Drawing.Size(54, 20);
            this.tbPacket1.TabIndex = 2;
            this.tbPacket1.Text = "10";
            this.tbPacket1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Packet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data";
            // 
            // tbPacket2
            // 
            this.tbPacket2.Location = new System.Drawing.Point(211, 146);
            this.tbPacket2.Name = "tbPacket2";
            this.tbPacket2.Size = new System.Drawing.Size(54, 20);
            this.tbPacket2.TabIndex = 6;
            this.tbPacket2.Text = "11";
            this.tbPacket2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRoll
            // 
            this.tbRoll.Location = new System.Drawing.Point(289, 146);
            this.tbRoll.Name = "tbRoll";
            this.tbRoll.Size = new System.Drawing.Size(135, 20);
            this.tbRoll.TabIndex = 5;
            this.tbRoll.Text = "0000";
            // 
            // tbPacket3
            // 
            this.tbPacket3.Location = new System.Drawing.Point(211, 201);
            this.tbPacket3.Name = "tbPacket3";
            this.tbPacket3.Size = new System.Drawing.Size(54, 20);
            this.tbPacket3.TabIndex = 8;
            this.tbPacket3.Text = "12";
            this.tbPacket3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPitch
            // 
            this.tbPitch.Location = new System.Drawing.Point(289, 201);
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.Size = new System.Drawing.Size(135, 20);
            this.tbPitch.TabIndex = 7;
            this.tbPitch.Text = "0000";
            // 
            // tbPacket4
            // 
            this.tbPacket4.Location = new System.Drawing.Point(211, 256);
            this.tbPacket4.Name = "tbPacket4";
            this.tbPacket4.Size = new System.Drawing.Size(54, 20);
            this.tbPacket4.TabIndex = 10;
            this.tbPacket4.Text = "13";
            this.tbPacket4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbYaw
            // 
            this.tbYaw.Location = new System.Drawing.Point(289, 256);
            this.tbYaw.Name = "tbYaw";
            this.tbYaw.Size = new System.Drawing.Size(135, 20);
            this.tbYaw.TabIndex = 9;
            this.tbYaw.Text = "0000";
            // 
            // tbPacket5
            // 
            this.tbPacket5.Location = new System.Drawing.Point(211, 311);
            this.tbPacket5.Name = "tbPacket5";
            this.tbPacket5.Size = new System.Drawing.Size(54, 20);
            this.tbPacket5.TabIndex = 12;
            this.tbPacket5.Text = "14";
            this.tbPacket5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbHdgDatum
            // 
            this.tbHdgDatum.Location = new System.Drawing.Point(289, 311);
            this.tbHdgDatum.Name = "tbHdgDatum";
            this.tbHdgDatum.Size = new System.Drawing.Size(135, 20);
            this.tbHdgDatum.TabIndex = 11;
            this.tbHdgDatum.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Apa Roll";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Apa Pitch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Apa Yaw";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Apa Hdg Datum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Apa Crs Datum";
            // 
            // tbPacket6
            // 
            this.tbPacket6.Location = new System.Drawing.Point(210, 366);
            this.tbPacket6.Name = "tbPacket6";
            this.tbPacket6.Size = new System.Drawing.Size(54, 20);
            this.tbPacket6.TabIndex = 19;
            this.tbPacket6.Text = "15";
            this.tbPacket6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCrsDatum
            // 
            this.tbCrsDatum.Location = new System.Drawing.Point(288, 366);
            this.tbCrsDatum.Name = "tbCrsDatum";
            this.tbCrsDatum.Size = new System.Drawing.Size(135, 20);
            this.tbCrsDatum.TabIndex = 18;
            this.tbCrsDatum.Text = "0000";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(50, 126);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(103, 37);
            this.btStart.TabIndex = 37;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(50, 186);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(103, 37);
            this.btStop.TabIndex = 38;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(59, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(473, 31);
            this.label14.TabIndex = 39;
            this.label14.Text = "Autopilot Interface Sim - AV-30 to ApA";
            // 
            // cbComPort
            // 
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(50, 90);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(104, 21);
            this.cbComPort.TabIndex = 40;
            this.cbComPort.SelectedIndexChanged += new System.EventHandler(this.cbComPort_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(84, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Com Port";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btTx
            // 
            this.btTx.Location = new System.Drawing.Point(54, 324);
            this.btTx.Margin = new System.Windows.Forms.Padding(2);
            this.btTx.Name = "btTx";
            this.btTx.Size = new System.Drawing.Size(99, 25);
            this.btTx.TabIndex = 45;
            this.btTx.Text = "Transmitting";
            this.btTx.UseVisualStyleBackColor = true;
            // 
            // sliderRoll
            // 
            this.sliderRoll.Location = new System.Drawing.Point(517, 147);
            this.sliderRoll.Margin = new System.Windows.Forms.Padding(1);
            this.sliderRoll.Maximum = 4095;
            this.sliderRoll.Name = "sliderRoll";
            this.sliderRoll.Size = new System.Drawing.Size(244, 45);
            this.sliderRoll.TabIndex = 46;
            this.sliderRoll.ValueChanged += new System.EventHandler(this.SliderRoll_ValueChanged);
            // 
            // sliderPitch
            // 
            this.sliderPitch.Location = new System.Drawing.Point(517, 200);
            this.sliderPitch.Margin = new System.Windows.Forms.Padding(1);
            this.sliderPitch.Maximum = 4095;
            this.sliderPitch.Name = "sliderPitch";
            this.sliderPitch.Size = new System.Drawing.Size(244, 45);
            this.sliderPitch.TabIndex = 47;
            this.sliderPitch.ValueChanged += new System.EventHandler(this.SliderPitch_ValueChanged);
            // 
            // cbAhrsValid
            // 
            this.cbAhrsValid.AutoSize = true;
            this.cbAhrsValid.Checked = true;
            this.cbAhrsValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAhrsValid.Location = new System.Drawing.Point(526, 92);
            this.cbAhrsValid.Margin = new System.Windows.Forms.Padding(1);
            this.cbAhrsValid.Name = "cbAhrsValid";
            this.cbAhrsValid.Size = new System.Drawing.Size(82, 17);
            this.cbAhrsValid.TabIndex = 48;
            this.cbAhrsValid.Text = "AHRS Valid";
            this.cbAhrsValid.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(522, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 50;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(720, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 51;
            this.label11.Text = "4095";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(720, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 17);
            this.label12.TabIndex = 53;
            this.label12.Text = "4095";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(522, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 52;
            this.label13.Text = "0";
            // 
            // cbSendStatus
            // 
            this.cbSendStatus.AutoSize = true;
            this.cbSendStatus.Checked = true;
            this.cbSendStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendStatus.Location = new System.Drawing.Point(183, 94);
            this.cbSendStatus.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendStatus.Name = "cbSendStatus";
            this.cbSendStatus.Size = new System.Drawing.Size(15, 14);
            this.cbSendStatus.TabIndex = 54;
            this.cbSendStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendStatus.UseVisualStyleBackColor = true;
            // 
            // cbSendRoll
            // 
            this.cbSendRoll.AutoSize = true;
            this.cbSendRoll.Checked = true;
            this.cbSendRoll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendRoll.Location = new System.Drawing.Point(183, 149);
            this.cbSendRoll.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendRoll.Name = "cbSendRoll";
            this.cbSendRoll.Size = new System.Drawing.Size(15, 14);
            this.cbSendRoll.TabIndex = 55;
            this.cbSendRoll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendRoll.UseVisualStyleBackColor = true;
            // 
            // cbSendPitch
            // 
            this.cbSendPitch.AutoSize = true;
            this.cbSendPitch.Checked = true;
            this.cbSendPitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendPitch.Location = new System.Drawing.Point(183, 204);
            this.cbSendPitch.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendPitch.Name = "cbSendPitch";
            this.cbSendPitch.Size = new System.Drawing.Size(15, 14);
            this.cbSendPitch.TabIndex = 56;
            this.cbSendPitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendPitch.UseVisualStyleBackColor = true;
            // 
            // cbSendYaw
            // 
            this.cbSendYaw.AutoSize = true;
            this.cbSendYaw.Checked = true;
            this.cbSendYaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendYaw.Location = new System.Drawing.Point(183, 259);
            this.cbSendYaw.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendYaw.Name = "cbSendYaw";
            this.cbSendYaw.Size = new System.Drawing.Size(15, 14);
            this.cbSendYaw.TabIndex = 57;
            this.cbSendYaw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendYaw.UseVisualStyleBackColor = true;
            // 
            // cbSendHdgDatum
            // 
            this.cbSendHdgDatum.AutoSize = true;
            this.cbSendHdgDatum.Checked = true;
            this.cbSendHdgDatum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendHdgDatum.Location = new System.Drawing.Point(183, 314);
            this.cbSendHdgDatum.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendHdgDatum.Name = "cbSendHdgDatum";
            this.cbSendHdgDatum.Size = new System.Drawing.Size(15, 14);
            this.cbSendHdgDatum.TabIndex = 58;
            this.cbSendHdgDatum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendHdgDatum.UseVisualStyleBackColor = true;
            // 
            // cbSendCrsDatum
            // 
            this.cbSendCrsDatum.AutoSize = true;
            this.cbSendCrsDatum.Checked = true;
            this.cbSendCrsDatum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendCrsDatum.Location = new System.Drawing.Point(183, 369);
            this.cbSendCrsDatum.Margin = new System.Windows.Forms.Padding(1);
            this.cbSendCrsDatum.Name = "cbSendCrsDatum";
            this.cbSendCrsDatum.Size = new System.Drawing.Size(15, 14);
            this.cbSendCrsDatum.TabIndex = 59;
            this.cbSendCrsDatum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSendCrsDatum.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(720, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 17);
            this.label16.TabIndex = 62;
            this.label16.Text = "4095";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(522, 231);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 17);
            this.label17.TabIndex = 61;
            this.label17.Text = "0";
            // 
            // sliderYaw
            // 
            this.sliderYaw.Location = new System.Drawing.Point(517, 253);
            this.sliderYaw.Margin = new System.Windows.Forms.Padding(1);
            this.sliderYaw.Maximum = 4095;
            this.sliderYaw.Name = "sliderYaw";
            this.sliderYaw.Size = new System.Drawing.Size(244, 45);
            this.sliderYaw.TabIndex = 60;
            this.sliderYaw.ValueChanged += new System.EventHandler(this.SliderYaw_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(720, 290);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 17);
            this.label18.TabIndex = 65;
            this.label18.Text = "4095";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(522, 290);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 17);
            this.label19.TabIndex = 64;
            this.label19.Text = "0";
            // 
            // sliderHdgDatum
            // 
            this.sliderHdgDatum.Location = new System.Drawing.Point(517, 306);
            this.sliderHdgDatum.Margin = new System.Windows.Forms.Padding(1);
            this.sliderHdgDatum.Maximum = 4095;
            this.sliderHdgDatum.Name = "sliderHdgDatum";
            this.sliderHdgDatum.Size = new System.Drawing.Size(244, 45);
            this.sliderHdgDatum.TabIndex = 63;
            this.sliderHdgDatum.ValueChanged += new System.EventHandler(this.SliderHdgDatum_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(720, 346);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 17);
            this.label20.TabIndex = 68;
            this.label20.Text = "4095";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(522, 346);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 17);
            this.label21.TabIndex = 67;
            this.label21.Text = "0";
            // 
            // sliderCrsDatum
            // 
            this.sliderCrsDatum.Location = new System.Drawing.Point(517, 363);
            this.sliderCrsDatum.Margin = new System.Windows.Forms.Padding(1);
            this.sliderCrsDatum.Maximum = 4095;
            this.sliderCrsDatum.Name = "sliderCrsDatum";
            this.sliderCrsDatum.Size = new System.Drawing.Size(244, 45);
            this.sliderCrsDatum.TabIndex = 66;
            this.sliderCrsDatum.ValueChanged += new System.EventHandler(this.SliderCrsDatum_ValueChanged);
            // 
            // tbOutputString
            // 
            this.tbOutputString.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutputString.Location = new System.Drawing.Point(54, 418);
            this.tbOutputString.Name = "tbOutputString";
            this.tbOutputString.Size = new System.Drawing.Size(706, 26);
            this.tbOutputString.TabIndex = 69;
            this.tbOutputString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(54, 401);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 70;
            this.label22.Text = "Output String";
            // 
            // cbAutoSlew
            // 
            this.cbAutoSlew.AutoSize = true;
            this.cbAutoSlew.Checked = true;
            this.cbAutoSlew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoSlew.Location = new System.Drawing.Point(52, 239);
            this.cbAutoSlew.Margin = new System.Windows.Forms.Padding(1);
            this.cbAutoSlew.Name = "cbAutoSlew";
            this.cbAutoSlew.Size = new System.Drawing.Size(109, 17);
            this.cbAutoSlew.TabIndex = 71;
            this.cbAutoSlew.Text = "Auto Slew Values";
            this.cbAutoSlew.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(824, 469);
            this.Controls.Add(this.cbAutoSlew);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbOutputString);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.sliderCrsDatum);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.sliderHdgDatum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.sliderYaw);
            this.Controls.Add(this.cbSendCrsDatum);
            this.Controls.Add(this.cbSendHdgDatum);
            this.Controls.Add(this.cbSendYaw);
            this.Controls.Add(this.cbSendPitch);
            this.Controls.Add(this.cbSendRoll);
            this.Controls.Add(this.cbSendStatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbAhrsValid);
            this.Controls.Add(this.sliderPitch);
            this.Controls.Add(this.sliderRoll);
            this.Controls.Add(this.btTx);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbComPort);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbPacket6);
            this.Controls.Add(this.tbCrsDatum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPacket5);
            this.Controls.Add(this.tbHdgDatum);
            this.Controls.Add(this.tbPacket4);
            this.Controls.Add(this.tbYaw);
            this.Controls.Add(this.tbPacket3);
            this.Controls.Add(this.tbPitch);
            this.Controls.Add(this.tbPacket2);
            this.Controls.Add(this.tbRoll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPacket1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderHdgDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderCrsDatum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPacket1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPacket2;
        private System.Windows.Forms.TextBox tbRoll;
        private System.Windows.Forms.TextBox tbPacket3;
        private System.Windows.Forms.TextBox tbPitch;
        private System.Windows.Forms.TextBox tbPacket4;
        private System.Windows.Forms.TextBox tbYaw;
        private System.Windows.Forms.TextBox tbPacket5;
        private System.Windows.Forms.TextBox tbHdgDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPacket6;
        private System.Windows.Forms.TextBox tbCrsDatum;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btTx;
        private System.Windows.Forms.TrackBar sliderRoll;
        private System.Windows.Forms.TrackBar sliderPitch;
        private System.Windows.Forms.CheckBox cbAhrsValid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbSendStatus;
        private System.Windows.Forms.CheckBox cbSendRoll;
        private System.Windows.Forms.CheckBox cbSendPitch;
        private System.Windows.Forms.CheckBox cbSendYaw;
        private System.Windows.Forms.CheckBox cbSendHdgDatum;
        private System.Windows.Forms.CheckBox cbSendCrsDatum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar sliderYaw;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TrackBar sliderHdgDatum;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar sliderCrsDatum;
        private System.Windows.Forms.TextBox tbOutputString;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbAutoSlew;
    }
}

