using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Media;
using STBootLib;

namespace STUploader
{
    public partial class fMainForm : Form
    {
        /* current file name */
        string fileName;
        /* com port name */
        string portName;
        /* baudrate */
        uint baudRate = 115200;
        /* address */
        uint address;
        /* page */
        uint page;
		/* write status */
		bool WriteInProcess;

		bool connected = false;
		
		/* application base address */
		//
		// Base address is set for start of flash memory
		// Bootloader resides in the first section, but writing is
		// inhibited on the hardware
		// This allows utilization of the .bin file that is used during
		// development (loading via stlink), which has both the bootloader
		// and application in the same .bin file.
		//
		const uint baseAddress = 0x08000000;

		// Page size
		const uint pageSize = 2000;

		/* constructor */
		public fMainForm()
        {
            /* initialize all components */
            InitializeComponent();

            /* set default baurate selection */
            //cbBauds.SelectedIndex = 6;
            //cbPSize.SelectedIndex = 0;
            /* set defaul address */
            address = baseAddress;
			WriteInProcess = false;
			bOpenFile.Enabled = false;
			bWrite.Enabled = false;

		}

        /* drop down list opened */
        private void cbPorts_DropDown(object sender, EventArgs e)
        {
            /* apply to combo box */
            cbPorts.DataSource = SerialPort.GetPortNames();
        }

        /* port selection was altered */
        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* valid selection made? */
            if (cbPorts.SelectedIndex == -1) {
                /* nope, disable button */
                bWrite.Enabled =  false;
            } else {
                /* store com port name */
                portName = (string)cbPorts.SelectedItem;
                /* enable button */
                bWrite.Enabled =  false;
            }
        }

        /* open file clicked */
        private void bOpenFile_Click(object sender, EventArgs e)
        {
            /* file selected? */
            if (ofdOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                /* set file name */
                tbFileName.Text = ofdOpen.SafeFileName;
                /* set tool tip */
                ttToolTip.SetToolTip(tbFileName, ofdOpen.FileName);
                /* store full path */
                fileName = ofdOpen.FileName;

				bWrite.Enabled = true;
			}
        }

		///* jump button pressed */
		//private async void jump()
		//{
		//	/* disable button */
		//	bWrite.Enabled = false;
		//	/* get port name */
		//	string pName = (string)cbPorts.SelectedItem;
		//	/* get baud rate */
		//	//uint bauds = uint.Parse((string)cbBauds.SelectedItem);
		//	uint bauds = 115200;    // Fixed baud
		//							/* get address */
		//	uint address = baseAddress;

		//	try
		//	{
		//		/* try to upload */
		//		await Jump(address);
		//	}
		//	catch (Exception ex)
		//	{
		//		/* set message */
		//		UpdateStatus(true, ex.Message);
		//	}
		//	finally
		//	{
		//		bWrite.Enabled = true;
		//	}
		//}

		///* jump button pressed */
		//private async void bJump_Click(object sender, EventArgs e)
		//{
		//	/* disable button */
		//	bJump.Enabled = bWrite.Enabled = false;
		//	/* get port name */
		//	string pName = (string)cbPorts.SelectedItem;
		//	/* get baud rate */
		//	//uint bauds = uint.Parse((string)cbBauds.SelectedItem);
		//	uint bauds = 115200;    // Fixed baud
		//							/* get address */
		//	uint address = baseAddress;

		//	try
		//	{
		//		/* try to upload */
		//		await Jump(address);
		//	}
		//	catch (Exception ex)
		//	{
		//		/* set message */
		//		UpdateStatus(true, ex.Message);
		//	}
		//	finally
		//	{
		//		bJump.Enabled = bWrite.Enabled = true;
		//	}
		//}

		/* write clicked */
		private async void bWrite_Click(object sender, EventArgs e)
        {
            /* disable button */
            bWrite.Enabled = false;
			WriteInProcess = true;
			/* get port name */
			string pName = (string)cbPorts.SelectedItem;

			/* get address */
			//uint address = Convert.ToUInt32(tbAddress.Text, 16);
			uint address = baseAddress;


			try {
                /* read file */
                var bin = await ReadFile(fileName);
                
				// Try Upload and Jump
                await UploadFile(pName, baudRate, bin, address, address);
				lbUnitId.Text = "Jump To Program";

				WriteInProcess = false;
				bWrite.Enabled = false;

				await Jump(address);

			} catch (Exception ex) {
                /* set message */
                UpdateStatus(true, ex.Message);
            } finally {
                bWrite.Enabled = false;
				WriteInProcess = false;
			}
        }



        ///* baud rate changed */
        //private void cbBauds_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    /* convert from string */
        //    baudRate = uint.Parse((string)cbBauds.SelectedItem);
        //}

        /* parse address */
        private void tbAddress_Leave(object sender, EventArgs e)
        {
            /* parsed address */
            uint addr;

            /* try to parse input */
            try {
				/* convert address field */
				addr = baseAddress;
			/* malformed address value */
			} catch (OverflowException) {
                /* set message */
                tsslStatus.Text = "Address too large!";
                /* restore default value */
                addr = baseAddress;
            /* all other errors go here */
            } catch (Exception) {
                /* set message */
                tsslStatus.Text = "Incorrect hex value";
                /* restore default value */
                addr = baseAddress;
            }

            /* store realigned address */
            address = addr & 0xffffff00;
            /* start page - end page */
            page = (address - baseAddress) / 256;

            /* rewrite */
            //tbAddress.Text = string.Format("0x{0:X8}", address);
        }

        /* load firmware file */
        private async Task<byte[]> ReadFile(string fname)
        {
            byte[] bin;

            /* open file */
            using (var s = new FileStream(fname, FileMode.Open,
                    FileAccess.Read)) {
                /* allocate memory */
                bin = new byte[s.Length];
                /* read file contents */
                await s.ReadAsync(bin, 0, bin.Length);
            }

            /* return binary image */
            return bin;
        }

        /* upload a binary image to uC */
        private async Task UploadFile(string portName, uint baudRate,
            byte[] bin, uint address, uint jumpAddress)
        {
            /* get page size */
            //uint psize = uint.Parse(cbPSize.SelectedItem as string);
			uint psize = pageSize;

            /* create new programming interface object */
            using (var uc = new STBoot()) {
                /* open device */
                uc.Open(portName, baudRate);

                ///* initialize communication */
                //await uc.Initialize();
                ///* update the status */
                //UpdateStatus(false, string.Format("Connected: Ver: {0}, PID: 0x{1:X4}",
                //    uc.Version, uc.ProductID));
                ///* give some chance see the message */
                //await Task.Delay(500);

                /* apply new message */
                UpdateStatus(false, "Erasing...");

				await uc.EraseAll();

                /* apply new message */
                UpdateStatus(false, "Programming...");

                /* progress reporter */
                var p = new Progress<STBootProgress>(UpdateProgress);
                
				/* write memory */
                await uc.WriteMemory(address, bin, 0, bin.Length, p,
                    CancellationToken.None, pageSize);

                /* update the status */
                UpdateStatus(false, string.Format("Success: {0} bytes written",
                    bin.Length));

                ///* go! */
                //await uc.Jump(jumpAddress);

                /* end communication */
                uc.Close();
            }
        }

        /* execute code */
        private async Task Jump(uint address)
        {
            /* create new programming interface object */
            using (var uc = new STBoot()) {
                /* open device */
                uc.Open(portName, baudRate);
                ///* initialize communication */
                //await uc.Initialize();
                /* go! */
                await uc.Jump(address);
                /* end communication */
                uc.Close();
				bWrite.Enabled = false;
				WriteInProcess = false;
				timer1.Enabled = false;
				lbUnitId.Text = "Update Complete";
				UpdateStatus(false, "Update Complete");

			}
        }

        /* set current progress */
        private void UpdateProgress(STBootProgress p)
        {
            /* converts bytes to percentage */
            UpdateProgress(100 * p.bytesProcessed / p.bytesTotal);
			tbBytesWritten.Text = p.bytesProcessed.ToString("#,###,###");

		}

        /* set current progress */
        private void UpdateProgress(int percent)
        {
            /* set progress bar value */
            pbProgress.Value = percent;
            /* set label */
            lProgress.Text = percent.ToString() + "%";
        }

        /* update status bar */
        private void UpdateStatus(bool ding, string text)
        {
            /* text */
            tsslStatus.Text = text;
            /* play a system sound? */
            if (ding) {
                /* ^^ ding! */
                SystemSounds.Exclamation.Play();
            }
        }

        private void cbxErase_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbPSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private async void btConnect_Click(object sender, EventArgs e)
		{
			/* disable button */
			btConnect.Enabled = false;
			bWrite.Enabled = false;
			connected = false;

			/* get port name */
			string pName = (string)cbPorts.SelectedItem;
			
			using (var uc = new STBoot())
			{
				try
				{
					await Connect(pName, baudRate);
				}
				catch (Exception ex)
				{
					UpdateStatus(true, ex.Message);
				}
				finally
				{
					btConnect.Enabled = true;
				}
			}
		}

		/* connect to unit */
		private async Task Connect(string portName, uint baudRate)
		{
			/* get page size */
			// uint psize = uint.Parse(cbPSize.SelectedItem as string);
			uint psize = pageSize;

			/* create new programming interface object */
			using (var uc = new STBoot())
			{
				try
				{
					/* open device */
					uc.Open(portName, baudRate);
					/* initialize communication */
					//await uc.Initialize();
					/* update the status */
					//UpdateStatus(false, string.Format("Connected: Ver: {0}, PID: 0x{1:X4}",
					//	uc.Version, uc.ProductID));
					/* give some chance see the message */
					//await Task.Delay(500);

					/* apply new message */
					UpdateStatus(false, "Connecting...");

					/* progress reporter */
					var p = new Progress<STBootProgress>(UpdateProgress);

					/* connect */
					await uc.Connect();

					/* update the status */
					//UpdateStatus(false, string.Format("Connected"));

					timer1.Enabled = true;
					bWrite.Enabled = false;
					WriteInProcess = false;
					connected = true;
				}
				catch
				{
					timer1.Enabled = false;
					bWrite.Enabled = false;
					bOpenFile.Enabled = false;
					WriteInProcess = false;
					connected = false;
				}
				finally
				{
					/* end communication */
					uc.Close();
				}

			}
		}

		private async void timer1_Tick(object sender, EventArgs e)
		{
			// Dont check if write is in process
			if ((WriteInProcess == false) && connected)
			{
				/* create new programming interface object */
				using (var uc = new STBoot())
				{
					/* get port name */
					string pName = (string)cbPorts.SelectedItem;
					try
					{
						//UpdateStatus(false, "Poll ID...");

						/* open device */
						uc.Open(portName, baudRate);

						/* try to handshake */
						if (await uc.GetID())
						{
							UpdateStatus(false, "Unit Detected");
							connected = true;
							bOpenFile.Enabled = true;

						}
						else
						{
							UpdateStatus(false, "No Unit Detected");
							connected = false;
							bOpenFile.Enabled = false;
							bWrite.Enabled = false;
						}
					}
					catch (Exception ex)
					{
						/* set message */
						// UpdateStatus(true, ex.Message);
						UpdateStatus(false, "Port Error Occured");
						connected = false;

					}
					finally
					{
						uc.Close();

					}

					// On Screen ID
					lbUnitId.Text = uc.ProductID;
				}
			}
			else
			{
				if (WriteInProcess)
				{
					lbUnitId.Text = "Write In Process";
				}

				
			}

		}

		private void pbProgress_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}

}
