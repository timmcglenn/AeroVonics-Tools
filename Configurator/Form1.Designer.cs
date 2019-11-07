namespace Configurator
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btColorInd = new System.Windows.Forms.Button();
			this.btColorRed = new System.Windows.Forms.Button();
			this.btColorGray = new System.Windows.Forms.Button();
			this.btColorBlack = new System.Windows.Forms.Button();
			this.btColorGreen = new System.Windows.Forms.Button();
			this.btColorBrown = new System.Windows.Forms.Button();
			this.btColorCyan = new System.Windows.Forms.Button();
			this.btColorBlue = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.audio = new System.Windows.Forms.TabPage();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.mainFormTimer = new System.Windows.Forms.Timer(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btSetGlobalDefaults = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.audio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.audio);
			this.tabControl1.Location = new System.Drawing.Point(44, 47);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(606, 555);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btSetGlobalDefaults);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(598, 526);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Connection";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton7);
			this.groupBox5.Controls.Add(this.radioButton8);
			this.groupBox5.Location = new System.Drawing.Point(53, 53);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(296, 80);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Connection Method";
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(25, 48);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(56, 21);
			this.radioButton7.TabIndex = 1;
			this.radioButton7.TabStop = true;
			this.radioButton7.Text = "WIFI";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(25, 21);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(105, 21);
			this.radioButton8.TabIndex = 0;
			this.radioButton8.TabStop = true;
			this.radioButton8.Text = "Serial Cable";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.checkBox5);
			this.tabPage2.Controls.Add(this.checkBox4);
			this.tabPage2.Controls.Add(this.checkBox3);
			this.tabPage2.Controls.Add(this.checkBox2);
			this.tabPage2.Controls.Add(this.checkBox1);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(598, 526);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Functions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(82, 232);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(139, 21);
			this.checkBox5.TabIndex = 5;
			this.checkBox5.Text = "UAT Status Page";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(82, 192);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(173, 21);
			this.checkBox4.TabIndex = 4;
			this.checkBox4.Text = "Attitude Indicator Page";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(82, 154);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(160, 21);
			this.checkBox3.TabIndex = 3;
			this.checkBox3.Text = "AOA / G-Meter Page";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(82, 114);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(107, 21);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "Traffic Page";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(82, 76);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(182, 21);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Time / Volts / OAT Page";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(427, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select the pages that are available via the FUNC button:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.numericUpDown1);
			this.tabPage3.Controls.Add(this.groupBox2);
			this.tabPage3.Controls.Add(this.checkBox6);
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(598, 526);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Time Page Options";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btColorInd);
			this.groupBox3.Controls.Add(this.btColorRed);
			this.groupBox3.Controls.Add(this.btColorGray);
			this.groupBox3.Controls.Add(this.btColorBlack);
			this.groupBox3.Controls.Add(this.btColorGreen);
			this.groupBox3.Controls.Add(this.btColorBrown);
			this.groupBox3.Controls.Add(this.btColorCyan);
			this.groupBox3.Controls.Add(this.btColorBlue);
			this.groupBox3.Location = new System.Drawing.Point(100, 385);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(296, 119);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Background Color";
			// 
			// btColorInd
			// 
			this.btColorInd.BackColor = System.Drawing.Color.Indigo;
			this.btColorInd.Location = new System.Drawing.Point(227, 70);
			this.btColorInd.Name = "btColorInd";
			this.btColorInd.Size = new System.Drawing.Size(36, 35);
			this.btColorInd.TabIndex = 6;
			this.btColorInd.UseVisualStyleBackColor = false;
			this.btColorInd.Click += new System.EventHandler(this.btColorInd_Click);
			// 
			// btColorRed
			// 
			this.btColorRed.BackColor = System.Drawing.Color.Maroon;
			this.btColorRed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btColorRed.Location = new System.Drawing.Point(228, 29);
			this.btColorRed.Name = "btColorRed";
			this.btColorRed.Size = new System.Drawing.Size(35, 35);
			this.btColorRed.TabIndex = 5;
			this.btColorRed.UseVisualStyleBackColor = false;
			this.btColorRed.Click += new System.EventHandler(this.btColorRed_Click);
			// 
			// btColorGray
			// 
			this.btColorGray.BackColor = System.Drawing.Color.DimGray;
			this.btColorGray.Location = new System.Drawing.Point(35, 70);
			this.btColorGray.Name = "btColorGray";
			this.btColorGray.Size = new System.Drawing.Size(36, 35);
			this.btColorGray.TabIndex = 4;
			this.btColorGray.UseVisualStyleBackColor = false;
			this.btColorGray.Click += new System.EventHandler(this.btColorGray_Click);
			// 
			// btColorBlack
			// 
			this.btColorBlack.BackColor = System.Drawing.Color.Black;
			this.btColorBlack.Location = new System.Drawing.Point(35, 29);
			this.btColorBlack.Name = "btColorBlack";
			this.btColorBlack.Size = new System.Drawing.Size(36, 35);
			this.btColorBlack.TabIndex = 2;
			this.btColorBlack.UseVisualStyleBackColor = false;
			this.btColorBlack.Click += new System.EventHandler(this.btColorBlack_Click);
			// 
			// btColorGreen
			// 
			this.btColorGreen.BackColor = System.Drawing.Color.Green;
			this.btColorGreen.Location = new System.Drawing.Point(163, 70);
			this.btColorGreen.Name = "btColorGreen";
			this.btColorGreen.Size = new System.Drawing.Size(36, 35);
			this.btColorGreen.TabIndex = 3;
			this.btColorGreen.UseVisualStyleBackColor = false;
			this.btColorGreen.Click += new System.EventHandler(this.btColorGreen_Click);
			// 
			// btColorBrown
			// 
			this.btColorBrown.BackColor = System.Drawing.Color.Olive;
			this.btColorBrown.Location = new System.Drawing.Point(164, 29);
			this.btColorBrown.Name = "btColorBrown";
			this.btColorBrown.Size = new System.Drawing.Size(35, 35);
			this.btColorBrown.TabIndex = 2;
			this.btColorBrown.UseVisualStyleBackColor = false;
			this.btColorBrown.Click += new System.EventHandler(this.btColorBrown_Click);
			// 
			// btColorCyan
			// 
			this.btColorCyan.BackColor = System.Drawing.Color.Teal;
			this.btColorCyan.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btColorCyan.Location = new System.Drawing.Point(100, 70);
			this.btColorCyan.Name = "btColorCyan";
			this.btColorCyan.Size = new System.Drawing.Size(35, 35);
			this.btColorCyan.TabIndex = 1;
			this.btColorCyan.UseVisualStyleBackColor = false;
			this.btColorCyan.Click += new System.EventHandler(this.btColorCyan_Click);
			// 
			// btColorBlue
			// 
			this.btColorBlue.BackColor = System.Drawing.Color.Blue;
			this.btColorBlue.Location = new System.Drawing.Point(100, 29);
			this.btColorBlue.Name = "btColorBlue";
			this.btColorBlue.Size = new System.Drawing.Size(35, 35);
			this.btColorBlue.TabIndex = 0;
			this.btColorBlue.UseVisualStyleBackColor = false;
			this.btColorBlue.Click += new System.EventHandler(this.btColorBlue_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButton5);
			this.groupBox4.Controls.Add(this.radioButton6);
			this.groupBox4.Location = new System.Drawing.Point(100, 208);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(296, 83);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Temp Format";
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(25, 48);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(137, 21);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "Temp shown in C";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(25, 21);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(138, 21);
			this.radioButton6.TabIndex = 0;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Temp Shown in F";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(168, 298);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(242, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Speed (In Knots) to Start Flight Timer";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.Location = new System.Drawing.Point(74, 297);
			this.numericUpDown1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(78, 22);
			this.numericUpDown1.TabIndex = 5;
			this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Location = new System.Drawing.Point(100, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(296, 81);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Temp Display";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(25, 48);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(127, 21);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Inside Air Temp";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(25, 21);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(221, 21);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Outside Air Temp (Req Probe)";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(74, 341);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(303, 21);
			this.checkBox6.TabIndex = 3;
			this.checkBox6.Text = "Allow Time Sync To UAT/GPS (H:M:S Only)";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(100, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Time Format";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(25, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(128, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "24 Hour Format";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(25, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(128, 21);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "12 Hour Format";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Clock Options:";
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(598, 526);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Colors";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// audio
			// 
			this.audio.Controls.Add(this.trackBar1);
			this.audio.Location = new System.Drawing.Point(4, 25);
			this.audio.Name = "audio";
			this.audio.Padding = new System.Windows.Forms.Padding(3);
			this.audio.Size = new System.Drawing.Size(598, 526);
			this.audio.TabIndex = 4;
			this.audio.Text = "Audio";
			this.audio.UseVisualStyleBackColor = true;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(80, 152);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(251, 56);
			this.trackBar1.TabIndex = 0;
			// 
			// mainFormTimer
			// 
			this.mainFormTimer.Enabled = true;
			this.mainFormTimer.Tick += new System.EventHandler(this.mainFormTimer_Tick);
			// 
			// btSetGlobalDefaults
			// 
			this.btSetGlobalDefaults.Location = new System.Drawing.Point(122, 238);
			this.btSetGlobalDefaults.Name = "btSetGlobalDefaults";
			this.btSetGlobalDefaults.Size = new System.Drawing.Size(192, 83);
			this.btSetGlobalDefaults.TabIndex = 4;
			this.btSetGlobalDefaults.Text = "button1";
			this.btSetGlobalDefaults.UseVisualStyleBackColor = true;
			this.btSetGlobalDefaults.Click += new System.EventHandler(this.btSetGlobalDefaults_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(725, 647);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.audio.ResumeLayout(false);
			this.audio.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.TabPage audio;
        private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Timer mainFormTimer;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btColorInd;
		private System.Windows.Forms.Button btColorRed;
		private System.Windows.Forms.Button btColorGray;
		private System.Windows.Forms.Button btColorBlack;
		private System.Windows.Forms.Button btColorGreen;
		private System.Windows.Forms.Button btColorBrown;
		private System.Windows.Forms.Button btColorCyan;
		private System.Windows.Forms.Button btColorBlue;
		private System.Windows.Forms.Button btSetGlobalDefaults;
	}
}

