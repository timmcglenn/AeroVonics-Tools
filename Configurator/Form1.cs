using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CalTool;

namespace Configurator
{
    public partial class Form1 : Form
    {
		public CalTool.LruCom lru;

		public Form1()
        {
            InitializeComponent();
			// Create LRU Instances
			lru = new CalTool.LruCom(0);
			lru.selectedComPort = "COM10";
		}

		private void mainFormTimer_Tick(object sender, EventArgs e)
		{
			lru.update();
		}

		private void btColorBlue_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff000020));	// RGB
		}

		private void btColorBrown_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff101000));  // RGB
		}

		private void btColorGreen_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff001000));  // RGB
		}

		private void btColorCyan_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff001010));  // RGB
		}

		private void btColorBlack_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff000000));  // RGB
		}

		private void btColorGray_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff101010));  // RGB
		}

		private void btColorRed_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff100000));  // RGB
		}

		private void btColorInd_Click(object sender, EventArgs e)
		{
			lru.setPrefWriteI(PREF.PREF_BG_COLOR, unchecked((int)0xff100010));  // RGB
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void btSetGlobalDefaults_Click(object sender, EventArgs e)
		{
			lru.setEngWriteF(ENG.DEF, (float)0x00);    // Set all defaults
		}
	}
}
