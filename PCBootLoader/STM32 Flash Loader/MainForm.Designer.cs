namespace STUploader
{
    partial class fMainForm
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
            if (disposing && (components != null)) {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btConnect = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbPorts = new System.Windows.Forms.ComboBox();
			this.lbUnitId = new System.Windows.Forms.TextBox();
			this.tbBytesWritten = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lProgress = new System.Windows.Forms.Label();
			this.bWrite = new System.Windows.Forms.Button();
			this.pbProgress = new System.Windows.Forms.ProgressBar();
			this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
			this.ttToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.bOpenFile = new System.Windows.Forms.Button();
			this.tbFileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btConnect);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cbPorts);
			this.groupBox1.Controls.Add(this.lbUnitId);
			this.groupBox1.Location = new System.Drawing.Point(18, 19);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(440, 170);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Serial Port";
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(242, 69);
			this.btConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(181, 35);
			this.btConnect.TabIndex = 4;
			this.btConnect.Text = "Re-Connect";
			this.ttToolTip.SetToolTip(this.btConnect, "Open firmware file");
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(188, 34);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(91, 128);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "Connection Status:";
			// 
			// cbPorts
			// 
			this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPorts.FormattingEnabled = true;
			this.cbPorts.Location = new System.Drawing.Point(242, 29);
			this.cbPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbPorts.Name = "cbPorts";
			this.cbPorts.Size = new System.Drawing.Size(181, 28);
			this.cbPorts.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.cbPorts, "COM Port Name");
			this.cbPorts.DropDown += new System.EventHandler(this.cbPorts_DropDown);
			this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
			this.cbPorts.DropDownClosed += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
			// 
			// lbUnitId
			// 
			this.lbUnitId.Enabled = false;
			this.lbUnitId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbUnitId.ForeColor = System.Drawing.SystemColors.Window;
			this.lbUnitId.Location = new System.Drawing.Point(242, 122);
			this.lbUnitId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.lbUnitId.Name = "lbUnitId";
			this.lbUnitId.Size = new System.Drawing.Size(181, 28);
			this.lbUnitId.TabIndex = 2;
			this.lbUnitId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ttToolTip.SetToolTip(this.lbUnitId, "File Name");
			// 
			// tbBytesWritten
			// 
			this.tbBytesWritten.Enabled = false;
			this.tbBytesWritten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbBytesWritten.ForeColor = System.Drawing.SystemColors.Window;
			this.tbBytesWritten.Location = new System.Drawing.Point(233, 212);
			this.tbBytesWritten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbBytesWritten.Name = "tbBytesWritten";
			this.tbBytesWritten.Size = new System.Drawing.Size(181, 26);
			this.tbBytesWritten.TabIndex = 5;
			this.tbBytesWritten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ttToolTip.SetToolTip(this.tbBytesWritten, "File Name");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(118, 216);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "Bytes Written:";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 605);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
			this.statusStrip1.Size = new System.Drawing.Size(492, 30);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslStatus
			// 
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(27, 25);
			this.tsslStatus.Text = "   ";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.tbBytesWritten);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lProgress);
			this.groupBox3.Controls.Add(this.bWrite);
			this.groupBox3.Controls.Add(this.pbProgress);
			this.groupBox3.Location = new System.Drawing.Point(21, 335);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Size = new System.Drawing.Size(440, 264);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Program Unit";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 35);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(385, 20);
			this.label5.TabIndex = 6;
			this.label5.Text = "Caution: Dot Not Disconnect Unit While Programming";
			// 
			// lProgress
			// 
			this.lProgress.AutoSize = true;
			this.lProgress.Location = new System.Drawing.Point(188, 184);
			this.lProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lProgress.Name = "lProgress";
			this.lProgress.Size = new System.Drawing.Size(32, 20);
			this.lProgress.TabIndex = 2;
			this.lProgress.Text = "0%";
			// 
			// bWrite
			// 
			this.bWrite.Enabled = false;
			this.bWrite.Location = new System.Drawing.Point(52, 74);
			this.bWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.bWrite.Name = "bWrite";
			this.bWrite.Size = new System.Drawing.Size(318, 55);
			this.bWrite.TabIndex = 0;
			this.bWrite.Text = "Write Firmware";
			this.ttToolTip.SetToolTip(this.bWrite, "Uploads the firmware and jumps to it.");
			this.bWrite.UseVisualStyleBackColor = true;
			this.bWrite.Click += new System.EventHandler(this.bWrite_Click);
			// 
			// pbProgress
			// 
			this.pbProgress.Location = new System.Drawing.Point(12, 144);
			this.pbProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(402, 35);
			this.pbProgress.TabIndex = 0;
			this.pbProgress.Click += new System.EventHandler(this.pbProgress_Click);
			// 
			// bOpenFile
			// 
			this.bOpenFile.Location = new System.Drawing.Point(240, 28);
			this.bOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.bOpenFile.Name = "bOpenFile";
			this.bOpenFile.Size = new System.Drawing.Size(181, 35);
			this.bOpenFile.TabIndex = 1;
			this.bOpenFile.Text = "Open File";
			this.ttToolTip.SetToolTip(this.bOpenFile, "Open firmware file");
			this.bOpenFile.UseVisualStyleBackColor = true;
			this.bOpenFile.Click += new System.EventHandler(this.bOpenFile_Click);
			// 
			// tbFileName
			// 
			this.tbFileName.Enabled = false;
			this.tbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbFileName.Location = new System.Drawing.Point(241, 82);
			this.tbFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbFileName.Name = "tbFileName";
			this.tbFileName.Size = new System.Drawing.Size(178, 28);
			this.tbFileName.TabIndex = 0;
			this.tbFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ttToolTip.SetToolTip(this.tbFileName, "File Name");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 89);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Image File:";
			this.ttToolTip.SetToolTip(this.label1, "File Name");
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbFileName);
			this.groupBox2.Controls.Add(this.bOpenFile);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(18, 199);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Size = new System.Drawing.Size(440, 126);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Select Code File (.bin)";
			// 
			// timer1
			// 
			this.timer1.Interval = 3000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// fMainForm
			// 
			this.AcceptButton = this.bWrite;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 635);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "fMainForm";
			this.Text = "AeroVonics Updater V1.1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bWrite;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip ttToolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bOpenFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFileName;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lbUnitId;
		private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.TextBox tbBytesWritten;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}

