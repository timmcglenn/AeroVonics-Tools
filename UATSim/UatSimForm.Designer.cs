namespace UATSim
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btTx = new System.Windows.Forms.Button();
			this.btStop = new System.Windows.Forms.Button();
			this.btStart = new System.Windows.Forms.Button();
			this.btConnect = new System.Windows.Forms.Button();
			this.cbComPort = new System.Windows.Forms.ComboBox();
			this.gbTarget1 = new System.Windows.Forms.GroupBox();
			this.cbTrg1Enable = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbTrg1Trk = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTrg1Hv = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTrg1Vv = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbTrg1Alt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbTrg1Lon = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbTrg1Lat = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbTrg1Addr = new System.Windows.Forms.TextBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbOwnEnable = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbOwnTrk = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbOwnHv = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbOwnVv = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbOwnAlt = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbOwnLon = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbOwnLat = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbOwnAddr = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbHbEnable = new System.Windows.Forms.CheckBox();
			this.label21 = new System.Windows.Forms.Label();
			this.tbHbStat1 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.gbTarget1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btTx);
			this.groupBox1.Controls.Add(this.btStop);
			this.groupBox1.Controls.Add(this.btStart);
			this.groupBox1.Controls.Add(this.btConnect);
			this.groupBox1.Controls.Add(this.cbComPort);
			this.groupBox1.Location = new System.Drawing.Point(24, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(789, 71);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Serial Port";
			// 
			// btTx
			// 
			this.btTx.Location = new System.Drawing.Point(702, 21);
			this.btTx.Name = "btTx";
			this.btTx.Size = new System.Drawing.Size(65, 44);
			this.btTx.TabIndex = 4;
			this.btTx.Text = "TX";
			this.btTx.UseVisualStyleBackColor = true;
			// 
			// btStop
			// 
			this.btStop.Location = new System.Drawing.Point(527, 21);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(138, 44);
			this.btStop.TabIndex = 3;
			this.btStop.Text = "Stop Broadcast";
			this.btStop.UseVisualStyleBackColor = true;
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// btStart
			// 
			this.btStart.Location = new System.Drawing.Point(368, 21);
			this.btStart.Name = "btStart";
			this.btStart.Size = new System.Drawing.Size(139, 44);
			this.btStart.TabIndex = 2;
			this.btStart.Text = "Start Broadcast";
			this.btStart.UseVisualStyleBackColor = true;
			this.btStart.Click += new System.EventHandler(this.btStart_Click);
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(220, 21);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(129, 44);
			this.btConnect.TabIndex = 1;
			this.btConnect.Text = "Connect";
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// cbComPort
			// 
			this.cbComPort.FormattingEnabled = true;
			this.cbComPort.Location = new System.Drawing.Point(21, 32);
			this.cbComPort.Name = "cbComPort";
			this.cbComPort.Size = new System.Drawing.Size(179, 24);
			this.cbComPort.TabIndex = 0;
			this.cbComPort.Text = "COM20";
			this.cbComPort.SelectedIndexChanged += new System.EventHandler(this.cbComPort_SelectedIndexChanged);
			// 
			// gbTarget1
			// 
			this.gbTarget1.Controls.Add(this.cbTrg1Enable);
			this.gbTarget1.Controls.Add(this.label7);
			this.gbTarget1.Controls.Add(this.tbTrg1Trk);
			this.gbTarget1.Controls.Add(this.label6);
			this.gbTarget1.Controls.Add(this.tbTrg1Hv);
			this.gbTarget1.Controls.Add(this.label5);
			this.gbTarget1.Controls.Add(this.tbTrg1Vv);
			this.gbTarget1.Controls.Add(this.label4);
			this.gbTarget1.Controls.Add(this.tbTrg1Alt);
			this.gbTarget1.Controls.Add(this.label3);
			this.gbTarget1.Controls.Add(this.tbTrg1Lon);
			this.gbTarget1.Controls.Add(this.label2);
			this.gbTarget1.Controls.Add(this.tbTrg1Lat);
			this.gbTarget1.Controls.Add(this.label1);
			this.gbTarget1.Controls.Add(this.tbTrg1Addr);
			this.gbTarget1.Location = new System.Drawing.Point(24, 377);
			this.gbTarget1.Name = "gbTarget1";
			this.gbTarget1.Size = new System.Drawing.Size(784, 110);
			this.gbTarget1.TabIndex = 1;
			this.gbTarget1.TabStop = false;
			this.gbTarget1.Text = "Target #1";
			// 
			// cbTrg1Enable
			// 
			this.cbTrg1Enable.AutoSize = true;
			this.cbTrg1Enable.Location = new System.Drawing.Point(17, 49);
			this.cbTrg1Enable.Name = "cbTrg1Enable";
			this.cbTrg1Enable.Size = new System.Drawing.Size(58, 21);
			this.cbTrg1Enable.TabIndex = 14;
			this.cbTrg1Enable.Text = "ENA";
			this.cbTrg1Enable.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(638, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "TRACK";
			// 
			// tbTrg1Trk
			// 
			this.tbTrg1Trk.Location = new System.Drawing.Point(629, 49);
			this.tbTrg1Trk.Name = "tbTrg1Trk";
			this.tbTrg1Trk.Size = new System.Drawing.Size(77, 22);
			this.tbTrg1Trk.TabIndex = 12;
			this.tbTrg1Trk.Text = "45";
			this.tbTrg1Trk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(556, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 17);
			this.label6.TabIndex = 11;
			this.label6.Text = "HV KTS";
			// 
			// tbTrg1Hv
			// 
			this.tbTrg1Hv.Location = new System.Drawing.Point(546, 49);
			this.tbTrg1Hv.Name = "tbTrg1Hv";
			this.tbTrg1Hv.Size = new System.Drawing.Size(77, 22);
			this.tbTrg1Hv.TabIndex = 10;
			this.tbTrg1Hv.Text = "150";
			this.tbTrg1Hv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(472, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "VV FPM";
			// 
			// tbTrg1Vv
			// 
			this.tbTrg1Vv.Location = new System.Drawing.Point(463, 49);
			this.tbTrg1Vv.Name = "tbTrg1Vv";
			this.tbTrg1Vv.Size = new System.Drawing.Size(77, 22);
			this.tbTrg1Vv.TabIndex = 8;
			this.tbTrg1Vv.Text = "500";
			this.tbTrg1Vv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(399, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "ALT";
			// 
			// tbTrg1Alt
			// 
			this.tbTrg1Alt.Location = new System.Drawing.Point(380, 49);
			this.tbTrg1Alt.Name = "tbTrg1Alt";
			this.tbTrg1Alt.Size = new System.Drawing.Size(77, 22);
			this.tbTrg1Alt.TabIndex = 6;
			this.tbTrg1Alt.Text = "5000";
			this.tbTrg1Alt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(308, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "LON";
			// 
			// tbTrg1Lon
			// 
			this.tbTrg1Lon.Location = new System.Drawing.Point(276, 49);
			this.tbTrg1Lon.Name = "tbTrg1Lon";
			this.tbTrg1Lon.Size = new System.Drawing.Size(98, 22);
			this.tbTrg1Lon.TabIndex = 4;
			this.tbTrg1Lon.Text = "-106.4";
			this.tbTrg1Lon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "LAT";
			// 
			// tbTrg1Lat
			// 
			this.tbTrg1Lat.Location = new System.Drawing.Point(172, 50);
			this.tbTrg1Lat.Name = "tbTrg1Lat";
			this.tbTrg1Lat.Size = new System.Drawing.Size(98, 22);
			this.tbTrg1Lat.TabIndex = 2;
			this.tbTrg1Lat.Text = "35";
			this.tbTrg1Lat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(110, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "ADDR";
			// 
			// tbTrg1Addr
			// 
			this.tbTrg1Addr.Location = new System.Drawing.Point(101, 49);
			this.tbTrg1Addr.Name = "tbTrg1Addr";
			this.tbTrg1Addr.Size = new System.Drawing.Size(65, 22);
			this.tbTrg1Addr.TabIndex = 0;
			this.tbTrg1Addr.Text = "0";
			this.tbTrg1Addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbOwnEnable);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tbOwnTrk);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tbOwnHv);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbOwnVv);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tbOwnAlt);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.tbOwnLon);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.tbOwnLat);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.tbOwnAddr);
			this.groupBox2.Location = new System.Drawing.Point(24, 224);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(784, 110);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ownship";
			// 
			// cbOwnEnable
			// 
			this.cbOwnEnable.AutoSize = true;
			this.cbOwnEnable.Location = new System.Drawing.Point(17, 49);
			this.cbOwnEnable.Name = "cbOwnEnable";
			this.cbOwnEnable.Size = new System.Drawing.Size(58, 21);
			this.cbOwnEnable.TabIndex = 14;
			this.cbOwnEnable.Text = "ENA";
			this.cbOwnEnable.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(638, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 17);
			this.label8.TabIndex = 13;
			this.label8.Text = "TRACK";
			// 
			// tbOwnTrk
			// 
			this.tbOwnTrk.Location = new System.Drawing.Point(629, 49);
			this.tbOwnTrk.Name = "tbOwnTrk";
			this.tbOwnTrk.Size = new System.Drawing.Size(77, 22);
			this.tbOwnTrk.TabIndex = 12;
			this.tbOwnTrk.Text = "45";
			this.tbOwnTrk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(556, 29);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(58, 17);
			this.label9.TabIndex = 11;
			this.label9.Text = "HV KTS";
			// 
			// tbOwnHv
			// 
			this.tbOwnHv.Location = new System.Drawing.Point(546, 49);
			this.tbOwnHv.Name = "tbOwnHv";
			this.tbOwnHv.Size = new System.Drawing.Size(77, 22);
			this.tbOwnHv.TabIndex = 10;
			this.tbOwnHv.Text = "150";
			this.tbOwnHv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(472, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(58, 17);
			this.label10.TabIndex = 9;
			this.label10.Text = "VV FPM";
			// 
			// tbOwnVv
			// 
			this.tbOwnVv.Location = new System.Drawing.Point(463, 49);
			this.tbOwnVv.Name = "tbOwnVv";
			this.tbOwnVv.Size = new System.Drawing.Size(77, 22);
			this.tbOwnVv.TabIndex = 8;
			this.tbOwnVv.Text = "500";
			this.tbOwnVv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(399, 29);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(34, 17);
			this.label11.TabIndex = 7;
			this.label11.Text = "ALT";
			// 
			// tbOwnAlt
			// 
			this.tbOwnAlt.Location = new System.Drawing.Point(380, 49);
			this.tbOwnAlt.Name = "tbOwnAlt";
			this.tbOwnAlt.Size = new System.Drawing.Size(77, 22);
			this.tbOwnAlt.TabIndex = 6;
			this.tbOwnAlt.Text = "5000";
			this.tbOwnAlt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(308, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(37, 17);
			this.label12.TabIndex = 5;
			this.label12.Text = "LON";
			// 
			// tbOwnLon
			// 
			this.tbOwnLon.Location = new System.Drawing.Point(276, 49);
			this.tbOwnLon.Name = "tbOwnLon";
			this.tbOwnLon.Size = new System.Drawing.Size(98, 22);
			this.tbOwnLon.TabIndex = 4;
			this.tbOwnLon.Text = "-106.4";
			this.tbOwnLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(196, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 17);
			this.label13.TabIndex = 3;
			this.label13.Text = "LAT";
			// 
			// tbOwnLat
			// 
			this.tbOwnLat.Location = new System.Drawing.Point(172, 50);
			this.tbOwnLat.Name = "tbOwnLat";
			this.tbOwnLat.Size = new System.Drawing.Size(98, 22);
			this.tbOwnLat.TabIndex = 2;
			this.tbOwnLat.Text = "35";
			this.tbOwnLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(110, 28);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(47, 17);
			this.label14.TabIndex = 1;
			this.label14.Text = "ADDR";
			// 
			// tbOwnAddr
			// 
			this.tbOwnAddr.Location = new System.Drawing.Point(101, 49);
			this.tbOwnAddr.Name = "tbOwnAddr";
			this.tbOwnAddr.Size = new System.Drawing.Size(65, 22);
			this.tbOwnAddr.TabIndex = 0;
			this.tbOwnAddr.Text = "0";
			this.tbOwnAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbHbEnable);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.tbHbStat1);
			this.groupBox3.Location = new System.Drawing.Point(24, 94);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 110);
			this.groupBox3.TabIndex = 16;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Heartbeat";
			// 
			// cbHbEnable
			// 
			this.cbHbEnable.AutoSize = true;
			this.cbHbEnable.Location = new System.Drawing.Point(17, 49);
			this.cbHbEnable.Name = "cbHbEnable";
			this.cbHbEnable.Size = new System.Drawing.Size(58, 21);
			this.cbHbEnable.TabIndex = 14;
			this.cbHbEnable.Text = "ENA";
			this.cbHbEnable.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(110, 28);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(52, 17);
			this.label21.TabIndex = 1;
			this.label21.Text = "STAT1";
			// 
			// tbHbStat1
			// 
			this.tbHbStat1.Location = new System.Drawing.Point(101, 49);
			this.tbHbStat1.Name = "tbHbStat1";
			this.tbHbStat1.Size = new System.Drawing.Size(65, 22);
			this.tbHbStat1.TabIndex = 0;
			this.tbHbStat1.Text = "0";
			this.tbHbStat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 698);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gbTarget1);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Uat Sim";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.gbTarget1.ResumeLayout(false);
			this.gbTarget1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbComPort;
		private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.GroupBox gbTarget1;
		private System.Windows.Forms.CheckBox cbTrg1Enable;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbTrg1Trk;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTrg1Hv;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTrg1Vv;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbTrg1Alt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbTrg1Lon;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbTrg1Lat;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbTrg1Addr;
		private System.Windows.Forms.Button btStop;
		private System.Windows.Forms.Button btStart;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button btTx;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbOwnEnable;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbOwnTrk;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbOwnHv;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbOwnVv;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbOwnAlt;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbOwnLon;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbOwnLat;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbOwnAddr;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox cbHbEnable;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbHbStat1;
	}
}

