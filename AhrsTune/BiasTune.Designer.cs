namespace BiasTune
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
			this.btVolts = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btBoardTemp = new System.Windows.Forms.Button();
			this.lbSource = new System.Windows.Forms.Label();
			this.btToggleSource = new System.Windows.Forms.Button();
			this.btSStable = new System.Windows.Forms.Button();
			this.btPStable = new System.Windows.Forms.Button();
			this.btMicroScale = new System.Windows.Forms.Button();
			this.btMidScale = new System.Windows.Forms.Button();
			this.btMaxScale = new System.Windows.Forms.Button();
			this.lbTrgTemp = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pbCmdGraph = new System.Windows.Forms.PictureBox();
			this.pbTempGraph = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbMinChartVal = new System.Windows.Forms.Label();
			this.lbMaxChartVal = new System.Windows.Forms.Label();
			this.btCmd = new System.Windows.Forms.Button();
			this.btTemp = new System.Windows.Forms.Button();
			this.tbDGain = new System.Windows.Forms.TextBox();
			this.btDGain = new System.Windows.Forms.Button();
			this.tbIGain = new System.Windows.Forms.TextBox();
			this.btIGain = new System.Windows.Forms.Button();
			this.tbPGain = new System.Windows.Forms.TextBox();
			this.btPGain = new System.Windows.Forms.Button();
			this.tbFeedForward = new System.Windows.Forms.TextBox();
			this.btFeedForward = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbCmdGraph)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).BeginInit();
			this.SuspendLayout();
			// 
			// btVolts
			// 
			this.btVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btVolts.Location = new System.Drawing.Point(1127, 668);
			this.btVolts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btVolts.Name = "btVolts";
			this.btVolts.Size = new System.Drawing.Size(139, 46);
			this.btVolts.TabIndex = 62;
			this.btVolts.Text = "Volts";
			this.btVolts.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 17);
			this.label1.TabIndex = 61;
			this.label1.Text = "Board Temp (c)";
			// 
			// btBoardTemp
			// 
			this.btBoardTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBoardTemp.Location = new System.Drawing.Point(12, 243);
			this.btBoardTemp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btBoardTemp.Name = "btBoardTemp";
			this.btBoardTemp.Size = new System.Drawing.Size(139, 46);
			this.btBoardTemp.TabIndex = 60;
			this.btBoardTemp.Text = "CMD";
			this.btBoardTemp.UseVisualStyleBackColor = true;
			// 
			// lbSource
			// 
			this.lbSource.AutoSize = true;
			this.lbSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSource.Location = new System.Drawing.Point(11, 11);
			this.lbSource.Name = "lbSource";
			this.lbSource.Size = new System.Drawing.Size(100, 39);
			this.lbSource.TabIndex = 59;
			this.lbSource.Text = "BIAS";
			this.lbSource.Click += new System.EventHandler(this.lbSource_Click);
			// 
			// btToggleSource
			// 
			this.btToggleSource.Location = new System.Drawing.Point(180, 670);
			this.btToggleSource.Name = "btToggleSource";
			this.btToggleSource.Size = new System.Drawing.Size(120, 42);
			this.btToggleSource.TabIndex = 58;
			this.btToggleSource.Text = "Toggle Source";
			this.btToggleSource.UseVisualStyleBackColor = true;
			// 
			// btSStable
			// 
			this.btSStable.Location = new System.Drawing.Point(450, 680);
			this.btSStable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btSStable.Name = "btSStable";
			this.btSStable.Size = new System.Drawing.Size(110, 34);
			this.btSStable.TabIndex = 57;
			this.btSStable.Text = "S Stable";
			this.btSStable.UseVisualStyleBackColor = true;
			// 
			// btPStable
			// 
			this.btPStable.Location = new System.Drawing.Point(339, 679);
			this.btPStable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btPStable.Name = "btPStable";
			this.btPStable.Size = new System.Drawing.Size(105, 34);
			this.btPStable.TabIndex = 56;
			this.btPStable.Text = "P Stable";
			this.btPStable.UseVisualStyleBackColor = true;
			// 
			// btMicroScale
			// 
			this.btMicroScale.Location = new System.Drawing.Point(974, 679);
			this.btMicroScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMicroScale.Name = "btMicroScale";
			this.btMicroScale.Size = new System.Drawing.Size(139, 34);
			this.btMicroScale.TabIndex = 55;
			this.btMicroScale.Text = "Micro Scale";
			this.btMicroScale.UseVisualStyleBackColor = true;
			// 
			// btMidScale
			// 
			this.btMidScale.Location = new System.Drawing.Point(815, 679);
			this.btMidScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMidScale.Name = "btMidScale";
			this.btMidScale.Size = new System.Drawing.Size(139, 34);
			this.btMidScale.TabIndex = 54;
			this.btMidScale.Text = "Mid Scale";
			this.btMidScale.UseVisualStyleBackColor = true;
			// 
			// btMaxScale
			// 
			this.btMaxScale.Location = new System.Drawing.Point(654, 679);
			this.btMaxScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btMaxScale.Name = "btMaxScale";
			this.btMaxScale.Size = new System.Drawing.Size(139, 34);
			this.btMaxScale.TabIndex = 53;
			this.btMaxScale.Text = "Max Scale";
			this.btMaxScale.UseVisualStyleBackColor = true;
			// 
			// lbTrgTemp
			// 
			this.lbTrgTemp.AutoSize = true;
			this.lbTrgTemp.Location = new System.Drawing.Point(1277, 204);
			this.lbTrgTemp.Name = "lbTrgTemp";
			this.lbTrgTemp.Size = new System.Drawing.Size(33, 17);
			this.lbTrgTemp.TabIndex = 52;
			this.lbTrgTemp.Text = "20C";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 143);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 17);
			this.label6.TabIndex = 51;
			this.label6.Text = "Current Cmd (%)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 17);
			this.label5.TabIndex = 50;
			this.label5.Text = "Current Temp(c)";
			// 
			// pbCmdGraph
			// 
			this.pbCmdGraph.BackColor = System.Drawing.Color.Silver;
			this.pbCmdGraph.Location = new System.Drawing.Point(179, 526);
			this.pbCmdGraph.Name = "pbCmdGraph";
			this.pbCmdGraph.Size = new System.Drawing.Size(1087, 116);
			this.pbCmdGraph.TabIndex = 49;
			this.pbCmdGraph.TabStop = false;
			// 
			// pbTempGraph
			// 
			this.pbTempGraph.BackColor = System.Drawing.Color.Silver;
			this.pbTempGraph.Location = new System.Drawing.Point(179, 31);
			this.pbTempGraph.Name = "pbTempGraph";
			this.pbTempGraph.Size = new System.Drawing.Size(1087, 484);
			this.pbTempGraph.TabIndex = 48;
			this.pbTempGraph.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1286, 649);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 17);
			this.label4.TabIndex = 47;
			this.label4.Text = "0%";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1282, 526);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 46;
			this.label3.Text = "100%";
			// 
			// lbMinChartVal
			// 
			this.lbMinChartVal.AutoSize = true;
			this.lbMinChartVal.Location = new System.Drawing.Point(1282, 506);
			this.lbMinChartVal.Name = "lbMinChartVal";
			this.lbMinChartVal.Size = new System.Drawing.Size(33, 17);
			this.lbMinChartVal.TabIndex = 45;
			this.lbMinChartVal.Text = "20C";
			// 
			// lbMaxChartVal
			// 
			this.lbMaxChartVal.AutoSize = true;
			this.lbMaxChartVal.Location = new System.Drawing.Point(1277, 24);
			this.lbMaxChartVal.Name = "lbMaxChartVal";
			this.lbMaxChartVal.Size = new System.Drawing.Size(33, 17);
			this.lbMaxChartVal.TabIndex = 35;
			this.lbMaxChartVal.Text = "70C";
			// 
			// btCmd
			// 
			this.btCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCmd.Location = new System.Drawing.Point(12, 162);
			this.btCmd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btCmd.Name = "btCmd";
			this.btCmd.Size = new System.Drawing.Size(139, 46);
			this.btCmd.TabIndex = 44;
			this.btCmd.Text = "CMD";
			this.btCmd.UseVisualStyleBackColor = true;
			// 
			// btTemp
			// 
			this.btTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btTemp.Location = new System.Drawing.Point(12, 81);
			this.btTemp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btTemp.Name = "btTemp";
			this.btTemp.Size = new System.Drawing.Size(139, 46);
			this.btTemp.TabIndex = 43;
			this.btTemp.Text = "TMP";
			this.btTemp.UseVisualStyleBackColor = true;
			// 
			// tbDGain
			// 
			this.tbDGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDGain.Location = new System.Drawing.Point(12, 630);
			this.tbDGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbDGain.Name = "tbDGain";
			this.tbDGain.Size = new System.Drawing.Size(139, 30);
			this.tbDGain.TabIndex = 42;
			this.tbDGain.Text = "20";
			this.tbDGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btDGain
			// 
			this.btDGain.Location = new System.Drawing.Point(12, 663);
			this.btDGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btDGain.Name = "btDGain";
			this.btDGain.Size = new System.Drawing.Size(139, 46);
			this.btDGain.TabIndex = 41;
			this.btDGain.Text = "D Gain";
			this.btDGain.UseVisualStyleBackColor = true;
			// 
			// tbIGain
			// 
			this.tbIGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbIGain.Location = new System.Drawing.Point(12, 525);
			this.tbIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbIGain.Name = "tbIGain";
			this.tbIGain.Size = new System.Drawing.Size(139, 30);
			this.tbIGain.TabIndex = 40;
			this.tbIGain.Text = "175";
			this.tbIGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btIGain
			// 
			this.btIGain.Location = new System.Drawing.Point(12, 557);
			this.btIGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btIGain.Name = "btIGain";
			this.btIGain.Size = new System.Drawing.Size(139, 46);
			this.btIGain.TabIndex = 39;
			this.btIGain.Text = "I Gain";
			this.btIGain.UseVisualStyleBackColor = true;
			// 
			// tbPGain
			// 
			this.tbPGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPGain.Location = new System.Drawing.Point(12, 423);
			this.tbPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbPGain.Name = "tbPGain";
			this.tbPGain.Size = new System.Drawing.Size(139, 30);
			this.tbPGain.TabIndex = 38;
			this.tbPGain.Text = "150";
			this.tbPGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btPGain
			// 
			this.btPGain.Location = new System.Drawing.Point(12, 456);
			this.btPGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btPGain.Name = "btPGain";
			this.btPGain.Size = new System.Drawing.Size(139, 46);
			this.btPGain.TabIndex = 37;
			this.btPGain.Text = "P Gain";
			this.btPGain.UseVisualStyleBackColor = true;
			// 
			// tbFeedForward
			// 
			this.tbFeedForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFeedForward.Location = new System.Drawing.Point(12, 311);
			this.tbFeedForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbFeedForward.Name = "tbFeedForward";
			this.tbFeedForward.Size = new System.Drawing.Size(139, 30);
			this.tbFeedForward.TabIndex = 36;
			this.tbFeedForward.Text = "1";
			this.tbFeedForward.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btFeedForward
			// 
			this.btFeedForward.Location = new System.Drawing.Point(12, 344);
			this.btFeedForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btFeedForward.Name = "btFeedForward";
			this.btFeedForward.Size = new System.Drawing.Size(139, 46);
			this.btFeedForward.TabIndex = 34;
			this.btFeedForward.Text = "Feed Forward";
			this.btFeedForward.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1352, 755);
			this.Controls.Add(this.btVolts);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btBoardTemp);
			this.Controls.Add(this.lbSource);
			this.Controls.Add(this.btToggleSource);
			this.Controls.Add(this.btSStable);
			this.Controls.Add(this.btPStable);
			this.Controls.Add(this.btMicroScale);
			this.Controls.Add(this.btMidScale);
			this.Controls.Add(this.btMaxScale);
			this.Controls.Add(this.lbTrgTemp);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.pbCmdGraph);
			this.Controls.Add(this.pbTempGraph);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbMinChartVal);
			this.Controls.Add(this.lbMaxChartVal);
			this.Controls.Add(this.btCmd);
			this.Controls.Add(this.btTemp);
			this.Controls.Add(this.tbDGain);
			this.Controls.Add(this.btDGain);
			this.Controls.Add(this.tbIGain);
			this.Controls.Add(this.btIGain);
			this.Controls.Add(this.tbPGain);
			this.Controls.Add(this.btPGain);
			this.Controls.Add(this.tbFeedForward);
			this.Controls.Add(this.btFeedForward);
			this.Name = "Form1";
			this.Text = "BiasTune";
			((System.ComponentModel.ISupportInitialize)(this.pbCmdGraph)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbTempGraph)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btVolts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btBoardTemp;
		private System.Windows.Forms.Label lbSource;
		private System.Windows.Forms.Button btToggleSource;
		private System.Windows.Forms.Button btSStable;
		private System.Windows.Forms.Button btPStable;
		private System.Windows.Forms.Button btMicroScale;
		private System.Windows.Forms.Button btMidScale;
		private System.Windows.Forms.Button btMaxScale;
		private System.Windows.Forms.Label lbTrgTemp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.PictureBox pbCmdGraph;
		public System.Windows.Forms.PictureBox pbTempGraph;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbMinChartVal;
		private System.Windows.Forms.Label lbMaxChartVal;
		private System.Windows.Forms.Button btCmd;
		private System.Windows.Forms.Button btTemp;
		private System.Windows.Forms.TextBox tbDGain;
		private System.Windows.Forms.Button btDGain;
		private System.Windows.Forms.TextBox tbIGain;
		private System.Windows.Forms.Button btIGain;
		private System.Windows.Forms.TextBox tbPGain;
		private System.Windows.Forms.Button btPGain;
		private System.Windows.Forms.TextBox tbFeedForward;
		private System.Windows.Forms.Button btFeedForward;
	}
}

