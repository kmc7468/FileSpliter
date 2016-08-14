using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSpliter
{
	internal partial class frmRSAKey : Form
	{
		public frmRSAKey()
		{
			InitializeComponent();

			FontFamily f;

			try
			{
				f = new FontFamily("Noto Sans CJK KR Regular");
			}
			catch (Exception)
			{
				try
				{
					f = new FontFamily("나눔바른고딕");
				}
				catch (Exception)
				{
					try
					{
						f = new FontFamily("나눔고딕");
					}
					catch (Exception)
					{
						f = new FontFamily("맑은 고딕");
					}
				}
			}

			foreach(Control it in Controls)
			{
				it.Font = new Font(f, it.Font.Size);
			}

			var r = RSA256.GenKey();

			txtPublicKey.Text = r.PublicKey;
			txtPrivateKey.Text = r.PrivateKey;
		}

		private void btnPublicCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(txtPublicKey.Text);
		}

		private void btnPrivateCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(txtPrivateKey.Text);
		}
	}
}
