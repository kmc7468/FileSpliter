﻿using System;
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
	public partial class frmMain : Form
	{
		internal frmMain()
		{
			InitializeComponent();

			PluginManager.MainForm = this;
			PluginManager.Init();

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

			tabControl.Font = new Font(f, tabControl.Font.Size);
			lbCopyright.Font = new Font(f, lbCopyright.Font.Size);

			foreach (var it in tabControl.TabPages)
			{
				foreach (Control c in (it as Control).Controls)
				{
					c.Font = new Font(f, c.Font.Size);

					if (c is Panel)
					{
						foreach (Control p in (c as Panel).Controls)
						{
							p.Font = new Font(f, p.Font.Size);
						}
					}
				}
			}

			btnDivisionBrowse.Size = new Size(btnDivisionBrowse.Width, txtDivisionUrl.Height);

			btnDivisionFolderBrowse.Size = new Size(btnDivisionFolderBrowse.Width, txtDivisionFolder.Height);

			btnCoalescenceFolderBrowse.Size = new Size(btnCoalescenceFolderBrowse.Width, txtCoalescenceFolder.Height);

			btnCoalescenceBrowse.Size = new Size(btnCoalescenceBrowse.Width, txtCoalescenceUrl.Height);

			btnEncryptFile.Size = new Size(btnEncryptFile.Width, txtEncryptFile.Height);

			btnEncryptTo.Size = new Size(btnEncryptTo.Width, txtEncryptTo.Height);

			btnDecryptFile.Size = new Size(btnDecryptFile.Width, txtDecryptFile.Height);

			btnDecryptTo.Size = new Size(btnDecryptTo.Width, txtDecryptTo.Height);
		}

		private void btnDivisionBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "분할할 파일";
			ofd.Filter = "모든 파일|*.*|실행 파일|*.exe;*.jar;*.apk|압축 파일|*.zip;*.egg;*.jar;*.7z;*.npk|이미지 파일|*.png;*.jpg;*.jpge;*.bmp;*.gif;*.icon;*.icns|프로그래밍 파일|*.sln;*.pro;*.csproj;*.vbproj;*.vb;*.cs;*.cpp;*.c;*.h;*.java;*.class;*.js;*.obj;*.lnk";
			ofd.Filter += "|텍스트 파일|*.txt;*.json;*.xml;*.xaml;*.yml;*.yaml|html 파일|*.html;*.htm|라이브러리 파일|*.dll";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtDivisionUrl.Text = ofd.FileName;
			}
		}

		private void btnDivisionFolderBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				txtDivisionFolder.Text = fbd.SelectedPath;
			}
		}

		private void cbDivisionFileEncrypt_CheckedChanged(object sender, EventArgs e)
		{
			if (cbDivisionFileEncrypt.Checked)
			{
				panDivisionEncrypt.Visible = true;
			}
			else
			{
				panDivisionEncrypt.Visible = false;
			}
		}

		private void rbEncryptRSA256_CheckedChanged(object sender, EventArgs e)
		{
			if (rbEncryptRSA256.Checked)
			{
				btnEncryptRsaKeyGen.Visible = true;
			}
			else
			{
				btnEncryptRsaKeyGen.Visible = false;
			}
		}

		private void btnEncryptRsaKeyGen_Click(object sender, EventArgs e)
		{
			frmRSAKey frm = new frmRSAKey();

			frm.ShowDialog();
		}

		private void btnDivision_Click(object sender, EventArgs e)
		{
			if (txtDivisionUrl.Text == "" || !System.IO.File.Exists(txtDivisionUrl.Text))
			{
				MessageBox.Show("분할할 파일이 존재하지 않거나 선택되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (txtDivisionFolder.Text == "")
			{
				MessageBox.Show("저장할 폴더를 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (!System.IO.Directory.Exists(txtDivisionFolder.Text))
				{
					System.IO.Directory.CreateDirectory(txtDivisionFolder.Text);
				}

				if (cbDivisionFileEncrypt.Checked)
				{
					if (rbEncryptRSA256.Checked)
					{
						if (txtEncryptKey.Text.Trim() == "")
						{
							MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						Splitter.Division(txtDivisionUrl.Text, (int)nudDivisionCount.Value, txtDivisionFolder.Text, System.IO.Path.GetExtension(txtDivisionUrl.Text), false);

						Cryptor.EncryptFiles(new RSA256(), txtEncryptKey.Text, txtDivisionFolder.Text, txtDivisionFolder.Text);
					}
					else if (rbEncryptAES256.Checked)
					{
						if (txtEncryptKey.Text.Trim() == "")
						{
							MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						Splitter.Division(txtDivisionUrl.Text, (int)nudDivisionCount.Value, txtDivisionFolder.Text, System.IO.Path.GetExtension(txtDivisionUrl.Text), false);

						Cryptor.EncryptFiles(new AES256(), txtEncryptKey.Text, txtDivisionFolder.Text, txtDivisionFolder.Text);
					}
					else
					{
						foreach (var it in PluginManager.Plugins)
						{
							if (it.EncryptDivision(false))
							{
								Splitter.Division(txtDivisionUrl.Text, (int)nudDivisionCount.Value, txtDivisionFolder.Text, System.IO.Path.GetExtension(txtDivisionUrl.Text), false);
								it.EncryptDivision();

								MessageBox.Show("분할이 완료되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}

						MessageBox.Show("분할한 파일을 암호화 하기로 결정하셨다면 분할한 파일을 암호화 할 기술을 선택해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					Splitter.Division(txtDivisionUrl.Text, (int)nudDivisionCount.Value, txtDivisionFolder.Text, System.IO.Path.GetExtension(txtDivisionUrl.Text));
				}

				MessageBox.Show("분할이 완료되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void cbDecrypt_CheckedChanged(object sender, EventArgs e)
		{
			panDecrypt.Visible = cbDecrypt.Checked;
		}

		private void btnCoalescenceFolderBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				txtCoalescenceFolder.Text = fbd.SelectedPath;
			}
		}

		private void btnCoalescenceBrowse_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.Title = "합쳐진 파일";
			sfd.Filter = "모든 파일|*.*";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				txtCoalescenceUrl.Text = sfd.FileName;
			}
		}

		private void btnCoalescence_Click(object sender, EventArgs e)
		{
			if (txtCoalescenceFolder.Text == "" || !System.IO.Directory.Exists(txtCoalescenceFolder.Text))
			{
				MessageBox.Show("분할된 폴더 위치가 존재하지 않거나 선택되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (txtCoalescenceUrl.Text == "")
			{
				MessageBox.Show("합쳐친 파일 경로를 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (cbDecrypt.Checked)
				{
					if (rbDecryptRSA256.Checked)
					{
						if (txtKey.Text.Trim() == "")
						{
							MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						System.IO.Directory.CreateDirectory(txtCoalescenceFolder.Text + @"\FileSpliterTemp");
						Cryptor.DecryptFiles(new RSA256(), txtKey.Text, txtCoalescenceFolder.Text, txtCoalescenceFolder.Text + @"\FileSpliterTemp");

						Splitter.Coalescence(txtCoalescenceFolder.Text + @"\FileSpliterTemp", txtCoalescenceUrl.Text, false);

						System.IO.Directory.Delete(txtCoalescenceFolder.Text + @"\FileSpliterTemp", true);
					}
					else if (rbDecryptAES256.Checked)
					{
						if (txtKey.Text.Trim() == "")
						{
							MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						System.IO.Directory.CreateDirectory(txtCoalescenceFolder.Text + @"\FileSpliterTemp");
						Cryptor.DecryptFiles(new AES256(), txtKey.Text, txtCoalescenceFolder.Text, txtCoalescenceFolder.Text + @"\FileSpliterTemp");

						Splitter.Coalescence(txtCoalescenceFolder.Text + @"\FileSpliterTemp", txtCoalescenceUrl.Text, false);

						System.IO.Directory.Delete(txtCoalescenceFolder.Text + @"\FileSpliterTemp", true);
					}
					else
					{
						foreach (var it in PluginManager.Plugins)
						{
							if (it.DecryptCoalescence(false))
							{
								System.IO.Directory.CreateDirectory(txtCoalescenceFolder.Text + @"\FileSpliterTemp");
								it.DecryptCoalescence();

								Splitter.Coalescence(txtCoalescenceFolder.Text + @"\FileSpliterTemp", txtCoalescenceUrl.Text, false);

								System.IO.Directory.Delete(txtCoalescenceFolder.Text + @"\FileSpliterTemp", true);
								MessageBox.Show("합체가 완료되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}

						MessageBox.Show("분할된 파일을 복호화 하기로 결정하셨다면 분할된 파일을 복호화 할 기술을 선택해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					Splitter.Coalescence(txtCoalescenceFolder.Text, txtCoalescenceUrl.Text);
				}

				MessageBox.Show("합체가 완료되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnEncryptFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.Title = "암호화 할 파일";
			ofd.Filter = "모든 파일|*.*|실행 파일|*.exe;*.jar;*.apk|압축 파일|*.zip;*.egg;*.jar;*.7z;*.npk|이미지 파일|*.png;*.jpg;*.jpge;*.bmp;*.gif;*.icon;*.icns|프로그래밍 파일|*.sln;*.pro;*.csproj;*.vbproj;*.vb;*.cs;*.cpp;*.c;*.h;*.java;*.class;*.js;*.obj;*.lnk";
			ofd.Filter += "|텍스트 파일|*.txt;*.json;*.xml;*.xaml;*.yml;*.yaml|html 파일|*.html;*.htm|라이브러리 파일|*.dll";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtEncryptFile.Text = ofd.FileName;
			}
		}

		private void btnEncryptTo_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.Title = "암호화 된 파일";
			sfd.Filter = "모든 파일|*.*";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				txtEncryptTo.Text = sfd.FileName;
			}
		}

		private void rbEncryptFileRSA256_CheckedChanged(object sender, EventArgs e)
		{
			btnRSAKeygen02.Visible = rbEncryptFileRSA256.Checked;
		}

		private void btnEncryptFileGo_Click(object sender, EventArgs e)
		{
			if (txtEncryptFile.Text.Trim() == "" || !System.IO.File.Exists(txtEncryptFile.Text))
			{
				MessageBox.Show("암호화 할 파일이 존재하지 않거나 선택되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (txtEncryptTo.Text.Trim() == "")
			{
				MessageBox.Show("암호화 된 파일 경로를 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (rbEncryptFileRSA256.Checked)
				{
					if (txtEncryptFileKey.Text.Trim() == "")
					{
						MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Cryptor.EncryptFile(new RSA256(), txtEncryptFileKey.Text, txtEncryptFile.Text, txtEncryptTo.Text);
				}
				else if (rbEncryptFileAES256.Checked)
				{
					if (txtEncryptFileKey.Text.Trim() == "")
					{
						MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Cryptor.EncryptFile(new AES256(), txtEncryptFileKey.Text, txtEncryptFile.Text, txtEncryptTo.Text);
				}
				else
				{
					foreach (var it in PluginManager.Plugins)
					{
						if (it.EncryptFile())
						{
							MessageBox.Show("암호화 되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}

					MessageBox.Show("암호화 할 기술을 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			MessageBox.Show("암호화 되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDecryptGo_Click(object sender, EventArgs e)
		{
			if (txtDecryptFile.Text.Trim() == "" || !System.IO.File.Exists(txtDecryptFile.Text))
			{
				MessageBox.Show("복호화 할 파일이 존재하지 않거나 선택되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (txtDecryptTo.Text.Trim() == "")
			{
				MessageBox.Show("복호화 된 파일 경로를 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (rbDecryptRSA256.Checked)
				{
					if (txtDecryptTypeKey.Text.Trim() == "")
					{
						MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Cryptor.DecryptFile(new RSA256(), txtDecryptTypeKey.Text, txtDecryptFile.Text, txtDecryptTo.Text);
				}
				else if (rbDecryptFileAES256.Checked)
				{
					if (txtDecryptTypeKey.Text.Trim() == "")
					{
						MessageBox.Show("키를 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					Cryptor.DecryptFile(new AES256(), txtDecryptTypeKey.Text, txtDecryptFile.Text, txtDecryptTo.Text);
				}
				else
				{
					foreach (var it in PluginManager.Plugins)
					{
						if (it.DecryptFile())
						{
							MessageBox.Show("복호화 되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}

					MessageBox.Show("복호화 할 기술을 선택해 주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			MessageBox.Show("복호화 되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDecryptFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.Title = "복호화 할 파일";
			ofd.Filter = "모든 파일|*.*|실행 파일|*.exe;*.jar;*.apk|압축 파일|*.zip;*.egg;*.jar;*.7z;*.npk|이미지 파일|*.png;*.jpg;*.jpge;*.bmp;*.gif;*.icon;*.icns|프로그래밍 파일|*.sln;*.pro;*.csproj;*.vbproj;*.vb;*.cs;*.cpp;*.c;*.h;*.java;*.class;*.js;*.obj;*.lnk";
			ofd.Filter += "|텍스트 파일|*.txt;*.json;*.xml;*.xaml;*.yml;*.yaml|html 파일|*.html;*.htm|라이브러리 파일|*.dll";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtDecryptFile.Text = ofd.FileName;
			}
		}

		private void btnDecryptTo_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.Title = "복호화 된 파일";
			sfd.Filter = "모든 파일|*.*";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				txtDecryptTo.Text = sfd.FileName;
			}
		}
	}
}
