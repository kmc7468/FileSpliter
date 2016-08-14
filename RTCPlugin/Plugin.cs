using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSpliter;
using System.Windows.Forms;
using System.Drawing;

namespace RTCPlugin
{
	public class Plugin : IPlugin
	{
		public string Name
		{
			get
			{
				return "RTCPlugin";
			}
		}

		public string Developer
		{
			get
			{
				return "kmc7468@naver.com";
			}
		}

		public Version Version
		{
			get
			{
				return new Version("1.0.0.0");
			}
		}

		private frmMain MainForm;

		private RadioButton Division_RTC32;
		private RadioButton Coalescence_RTC32;
		private RadioButton FileEn_RTC32;
		private RadioButton FileDe_RTC32;

		public void Startup()
		{
			MainForm = PluginManager.MainForm;

			Division_RTC32 = new RadioButton() { Text = "RTC32", Location = new Point(MainForm.rbEncryptRSA256.Location.X + 90, MainForm.rbEncryptRSA256.Location.Y) };
			Coalescence_RTC32 = new RadioButton() { Text = "RTC32", Location = new Point(MainForm.rbDecryptRSA256.Location.X + 90, MainForm.rbDecryptRSA256.Location.Y) };
			FileEn_RTC32 = new RadioButton() { Text = "RTC32", Location = new Point(MainForm.rbEncryptFileRSA256.Location.X + 90, MainForm.rbEncryptFileRSA256.Location.Y) };
			FileDe_RTC32 = new RadioButton() { Text = "RTC32", Location = new Point(MainForm.rbDecryptFileRSA256.Location.X + 90, MainForm.rbDecryptFileRSA256.Location.Y) };

			MainForm.panDivisionEncrypt.Controls.Add(Division_RTC32);
			MainForm.panDecrypt.Controls.Add(Coalescence_RTC32);
			MainForm.panEncryptFileEncrypt.Controls.Add(FileEn_RTC32);
			MainForm.panDecryptType.Controls.Add(FileDe_RTC32);
		}

		public void Shutdown()
		{

		}

		public bool EncryptDivision(bool shell = true)
		{
			bool res = false;

			if (Division_RTC32.Checked)
			{
				if (!shell)
				{
					return true;
				}

				try
				{
					Cryptor.EncryptFiles(new RTC32(), MainForm.txtEncryptKey.Text, MainForm.txtDivisionFolder.Text, MainForm.txtDivisionFolder.Text);

					res = true;
				}
				catch (Exception)
				{
					res = false;
				}
			}

			return res;
		}

		public bool DecryptCoalescence(bool shell = true)
		{
			bool res = false;

			if (Coalescence_RTC32.Checked)
			{
				if (!shell)
				{
					return true;
				}

				try
				{
					Cryptor.DecryptFiles(new RTC32(), MainForm.txtKey.Text, MainForm.txtCoalescenceFolder.Text, MainForm.txtCoalescenceFolder.Text + @"\FileSpliterTemp");

					res = true;
				}
				catch (Exception)
				{
					res = false;
				}
			}

			return res;
		}

		public bool EncryptFile(bool shell = true)
		{
			bool res = false;

			if (FileEn_RTC32.Checked)
			{
				if (!shell)
				{
					return true;
				}

				try
				{
					Cryptor.EncryptFile(new RTC32(), MainForm.txtEncryptFileKey.Text, MainForm.txtEncryptFile.Text, MainForm.txtEncryptTo.Text);

					res = true;
				}
				catch (Exception)
				{
					res = false;
				}
			}

			return res;
		}

		public bool DecryptFile(bool shell = true)
		{
			bool res = false;

			if (FileDe_RTC32.Checked)
			{
				if (!shell)
				{
					return true;
				}

				try
				{
					Cryptor.DecryptFile(new RTC32(), MainForm.txtDecryptTypeKey.Text, MainForm.txtDecryptFile.Text, MainForm.txtDecryptTo.Text);

					res = true;
				}
				catch (Exception)
				{
					res = false;
				}
			}

			return res;
		}
	}
}
