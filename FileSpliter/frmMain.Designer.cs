namespace FileSpliter
{
	partial class frmMain
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnDivisionFolderBrowse = new System.Windows.Forms.Button();
			this.txtDivisionFolder = new System.Windows.Forms.TextBox();
			this.lbDivisionFolder = new System.Windows.Forms.Label();
			this.btnDivision = new System.Windows.Forms.Button();
			this.panDivisionEncrypt = new System.Windows.Forms.Panel();
			this.btnEncryptRsaKeyGen = new System.Windows.Forms.Button();
			this.txtEncryptKey = new System.Windows.Forms.TextBox();
			this.lbEncryptKey = new System.Windows.Forms.Label();
			this.rbEncryptAES256 = new System.Windows.Forms.RadioButton();
			this.rbEncryptRSA256 = new System.Windows.Forms.RadioButton();
			this.cbDivisionFileEncrypt = new System.Windows.Forms.CheckBox();
			this.nudDivisionCount = new System.Windows.Forms.NumericUpDown();
			this.lbDivisionSplitCount = new System.Windows.Forms.Label();
			this.btnDivisionBrowse = new System.Windows.Forms.Button();
			this.txtDivisionUrl = new System.Windows.Forms.TextBox();
			this.lbDivisionUrl = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnCoalescenceBrowse = new System.Windows.Forms.Button();
			this.txtCoalescenceUrl = new System.Windows.Forms.TextBox();
			this.lbCoalescenceUrl = new System.Windows.Forms.Label();
			this.btnCoalescence = new System.Windows.Forms.Button();
			this.panDecrypt = new System.Windows.Forms.Panel();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.lbKey = new System.Windows.Forms.Label();
			this.rbDecryptAES256 = new System.Windows.Forms.RadioButton();
			this.rbDecryptRSA256 = new System.Windows.Forms.RadioButton();
			this.cbDecrypt = new System.Windows.Forms.CheckBox();
			this.btnCoalescenceFolderBrowse = new System.Windows.Forms.Button();
			this.txtCoalescenceFolder = new System.Windows.Forms.TextBox();
			this.lbCoalescenceFolder = new System.Windows.Forms.Label();
			this.lbCopyright = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panDivisionEncrypt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDivisionCount)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panDecrypt.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl.Font = new System.Drawing.Font("굴림", 11F);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(640, 456);
			this.tabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnDivisionFolderBrowse);
			this.tabPage1.Controls.Add(this.txtDivisionFolder);
			this.tabPage1.Controls.Add(this.lbDivisionFolder);
			this.tabPage1.Controls.Add(this.btnDivision);
			this.tabPage1.Controls.Add(this.panDivisionEncrypt);
			this.tabPage1.Controls.Add(this.cbDivisionFileEncrypt);
			this.tabPage1.Controls.Add(this.nudDivisionCount);
			this.tabPage1.Controls.Add(this.lbDivisionSplitCount);
			this.tabPage1.Controls.Add(this.btnDivisionBrowse);
			this.tabPage1.Controls.Add(this.txtDivisionUrl);
			this.tabPage1.Controls.Add(this.lbDivisionUrl);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(632, 427);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "분할";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnDivisionFolderBrowse
			// 
			this.btnDivisionFolderBrowse.Location = new System.Drawing.Point(595, 152);
			this.btnDivisionFolderBrowse.Name = "btnDivisionFolderBrowse";
			this.btnDivisionFolderBrowse.Size = new System.Drawing.Size(31, 24);
			this.btnDivisionFolderBrowse.TabIndex = 10;
			this.btnDivisionFolderBrowse.Text = "...";
			this.btnDivisionFolderBrowse.UseVisualStyleBackColor = true;
			this.btnDivisionFolderBrowse.Click += new System.EventHandler(this.btnDivisionFolderBrowse_Click);
			// 
			// txtDivisionFolder
			// 
			this.txtDivisionFolder.BackColor = System.Drawing.Color.White;
			this.txtDivisionFolder.Location = new System.Drawing.Point(11, 152);
			this.txtDivisionFolder.Name = "txtDivisionFolder";
			this.txtDivisionFolder.ReadOnly = true;
			this.txtDivisionFolder.Size = new System.Drawing.Size(578, 24);
			this.txtDivisionFolder.TabIndex = 9;
			// 
			// lbDivisionFolder
			// 
			this.lbDivisionFolder.AutoSize = true;
			this.lbDivisionFolder.Location = new System.Drawing.Point(8, 129);
			this.lbDivisionFolder.Name = "lbDivisionFolder";
			this.lbDivisionFolder.Size = new System.Drawing.Size(87, 15);
			this.lbDivisionFolder.TabIndex = 8;
			this.lbDivisionFolder.Text = "저장할 폴더";
			// 
			// btnDivision
			// 
			this.btnDivision.Location = new System.Drawing.Point(476, 378);
			this.btnDivision.Name = "btnDivision";
			this.btnDivision.Size = new System.Drawing.Size(148, 43);
			this.btnDivision.TabIndex = 7;
			this.btnDivision.Text = "작업 시작";
			this.btnDivision.UseVisualStyleBackColor = true;
			this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
			// 
			// panDivisionEncrypt
			// 
			this.panDivisionEncrypt.BackColor = System.Drawing.Color.LightGray;
			this.panDivisionEncrypt.Controls.Add(this.btnEncryptRsaKeyGen);
			this.panDivisionEncrypt.Controls.Add(this.txtEncryptKey);
			this.panDivisionEncrypt.Controls.Add(this.lbEncryptKey);
			this.panDivisionEncrypt.Controls.Add(this.rbEncryptAES256);
			this.panDivisionEncrypt.Controls.Add(this.rbEncryptRSA256);
			this.panDivisionEncrypt.Location = new System.Drawing.Point(11, 221);
			this.panDivisionEncrypt.Name = "panDivisionEncrypt";
			this.panDivisionEncrypt.Size = new System.Drawing.Size(613, 142);
			this.panDivisionEncrypt.TabIndex = 6;
			this.panDivisionEncrypt.Visible = false;
			// 
			// btnEncryptRsaKeyGen
			// 
			this.btnEncryptRsaKeyGen.Font = new System.Drawing.Font("굴림", 9F);
			this.btnEncryptRsaKeyGen.Location = new System.Drawing.Point(509, 8);
			this.btnEncryptRsaKeyGen.Name = "btnEncryptRsaKeyGen";
			this.btnEncryptRsaKeyGen.Size = new System.Drawing.Size(96, 23);
			this.btnEncryptRsaKeyGen.TabIndex = 4;
			this.btnEncryptRsaKeyGen.Text = "키 생성";
			this.btnEncryptRsaKeyGen.UseVisualStyleBackColor = true;
			this.btnEncryptRsaKeyGen.Visible = false;
			this.btnEncryptRsaKeyGen.Click += new System.EventHandler(this.btnEncryptRsaKeyGen_Click);
			// 
			// txtEncryptKey
			// 
			this.txtEncryptKey.Location = new System.Drawing.Point(14, 86);
			this.txtEncryptKey.Name = "txtEncryptKey";
			this.txtEncryptKey.Size = new System.Drawing.Size(585, 24);
			this.txtEncryptKey.TabIndex = 3;
			// 
			// lbEncryptKey
			// 
			this.lbEncryptKey.AutoSize = true;
			this.lbEncryptKey.Location = new System.Drawing.Point(11, 64);
			this.lbEncryptKey.Name = "lbEncryptKey";
			this.lbEncryptKey.Size = new System.Drawing.Size(22, 15);
			this.lbEncryptKey.TabIndex = 2;
			this.lbEncryptKey.Text = "키";
			// 
			// rbEncryptAES256
			// 
			this.rbEncryptAES256.AutoSize = true;
			this.rbEncryptAES256.Location = new System.Drawing.Point(14, 37);
			this.rbEncryptAES256.Name = "rbEncryptAES256";
			this.rbEncryptAES256.Size = new System.Drawing.Size(77, 19);
			this.rbEncryptAES256.TabIndex = 1;
			this.rbEncryptAES256.TabStop = true;
			this.rbEncryptAES256.Text = "AES256";
			this.rbEncryptAES256.UseVisualStyleBackColor = true;
			// 
			// rbEncryptRSA256
			// 
			this.rbEncryptRSA256.AutoSize = true;
			this.rbEncryptRSA256.Location = new System.Drawing.Point(14, 12);
			this.rbEncryptRSA256.Name = "rbEncryptRSA256";
			this.rbEncryptRSA256.Size = new System.Drawing.Size(78, 19);
			this.rbEncryptRSA256.TabIndex = 0;
			this.rbEncryptRSA256.TabStop = true;
			this.rbEncryptRSA256.Text = "RSA256";
			this.rbEncryptRSA256.UseVisualStyleBackColor = true;
			this.rbEncryptRSA256.CheckedChanged += new System.EventHandler(this.rbEncryptRSA256_CheckedChanged);
			// 
			// cbDivisionFileEncrypt
			// 
			this.cbDivisionFileEncrypt.AutoSize = true;
			this.cbDivisionFileEncrypt.Location = new System.Drawing.Point(11, 196);
			this.cbDivisionFileEncrypt.Name = "cbDivisionFileEncrypt";
			this.cbDivisionFileEncrypt.Size = new System.Drawing.Size(156, 19);
			this.cbDivisionFileEncrypt.TabIndex = 5;
			this.cbDivisionFileEncrypt.Text = "분할한 파일 암호화";
			this.cbDivisionFileEncrypt.UseVisualStyleBackColor = true;
			this.cbDivisionFileEncrypt.CheckedChanged += new System.EventHandler(this.cbDivisionFileEncrypt_CheckedChanged);
			// 
			// nudDivisionCount
			// 
			this.nudDivisionCount.BackColor = System.Drawing.Color.White;
			this.nudDivisionCount.Location = new System.Drawing.Point(11, 93);
			this.nudDivisionCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nudDivisionCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudDivisionCount.Name = "nudDivisionCount";
			this.nudDivisionCount.Size = new System.Drawing.Size(613, 24);
			this.nudDivisionCount.TabIndex = 4;
			this.nudDivisionCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lbDivisionSplitCount
			// 
			this.lbDivisionSplitCount.AutoSize = true;
			this.lbDivisionSplitCount.Location = new System.Drawing.Point(8, 71);
			this.lbDivisionSplitCount.Name = "lbDivisionSplitCount";
			this.lbDivisionSplitCount.Size = new System.Drawing.Size(107, 15);
			this.lbDivisionSplitCount.TabIndex = 3;
			this.lbDivisionSplitCount.Text = "분할 파일 개수";
			// 
			// btnDivisionBrowse
			// 
			this.btnDivisionBrowse.Location = new System.Drawing.Point(595, 35);
			this.btnDivisionBrowse.Name = "btnDivisionBrowse";
			this.btnDivisionBrowse.Size = new System.Drawing.Size(31, 24);
			this.btnDivisionBrowse.TabIndex = 2;
			this.btnDivisionBrowse.Text = "...";
			this.btnDivisionBrowse.UseVisualStyleBackColor = true;
			this.btnDivisionBrowse.Click += new System.EventHandler(this.btnDivisionBrowse_Click);
			// 
			// txtDivisionUrl
			// 
			this.txtDivisionUrl.BackColor = System.Drawing.Color.White;
			this.txtDivisionUrl.Location = new System.Drawing.Point(11, 35);
			this.txtDivisionUrl.Name = "txtDivisionUrl";
			this.txtDivisionUrl.ReadOnly = true;
			this.txtDivisionUrl.Size = new System.Drawing.Size(578, 24);
			this.txtDivisionUrl.TabIndex = 1;
			// 
			// lbDivisionUrl
			// 
			this.lbDivisionUrl.AutoSize = true;
			this.lbDivisionUrl.Location = new System.Drawing.Point(8, 12);
			this.lbDivisionUrl.Name = "lbDivisionUrl";
			this.lbDivisionUrl.Size = new System.Drawing.Size(87, 15);
			this.lbDivisionUrl.TabIndex = 0;
			this.lbDivisionUrl.Text = "분할할 파일";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnCoalescenceBrowse);
			this.tabPage2.Controls.Add(this.txtCoalescenceUrl);
			this.tabPage2.Controls.Add(this.lbCoalescenceUrl);
			this.tabPage2.Controls.Add(this.btnCoalescence);
			this.tabPage2.Controls.Add(this.panDecrypt);
			this.tabPage2.Controls.Add(this.cbDecrypt);
			this.tabPage2.Controls.Add(this.btnCoalescenceFolderBrowse);
			this.tabPage2.Controls.Add(this.txtCoalescenceFolder);
			this.tabPage2.Controls.Add(this.lbCoalescenceFolder);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(632, 427);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "합체";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnCoalescenceBrowse
			// 
			this.btnCoalescenceBrowse.Location = new System.Drawing.Point(595, 96);
			this.btnCoalescenceBrowse.Name = "btnCoalescenceBrowse";
			this.btnCoalescenceBrowse.Size = new System.Drawing.Size(31, 24);
			this.btnCoalescenceBrowse.TabIndex = 21;
			this.btnCoalescenceBrowse.Text = "...";
			this.btnCoalescenceBrowse.UseVisualStyleBackColor = true;
			this.btnCoalescenceBrowse.Click += new System.EventHandler(this.btnCoalescenceBrowse_Click);
			// 
			// txtCoalescenceUrl
			// 
			this.txtCoalescenceUrl.BackColor = System.Drawing.Color.White;
			this.txtCoalescenceUrl.Location = new System.Drawing.Point(11, 96);
			this.txtCoalescenceUrl.Name = "txtCoalescenceUrl";
			this.txtCoalescenceUrl.ReadOnly = true;
			this.txtCoalescenceUrl.Size = new System.Drawing.Size(578, 24);
			this.txtCoalescenceUrl.TabIndex = 20;
			// 
			// lbCoalescenceUrl
			// 
			this.lbCoalescenceUrl.AutoSize = true;
			this.lbCoalescenceUrl.Location = new System.Drawing.Point(8, 73);
			this.lbCoalescenceUrl.Name = "lbCoalescenceUrl";
			this.lbCoalescenceUrl.Size = new System.Drawing.Size(87, 15);
			this.lbCoalescenceUrl.TabIndex = 19;
			this.lbCoalescenceUrl.Text = "합쳐진 파일";
			// 
			// btnCoalescence
			// 
			this.btnCoalescence.Location = new System.Drawing.Point(476, 378);
			this.btnCoalescence.Name = "btnCoalescence";
			this.btnCoalescence.Size = new System.Drawing.Size(148, 43);
			this.btnCoalescence.TabIndex = 18;
			this.btnCoalescence.Text = "작업 시작";
			this.btnCoalescence.UseVisualStyleBackColor = true;
			this.btnCoalescence.Click += new System.EventHandler(this.btnCoalescence_Click);
			// 
			// panDecrypt
			// 
			this.panDecrypt.BackColor = System.Drawing.Color.LightGray;
			this.panDecrypt.Controls.Add(this.txtKey);
			this.panDecrypt.Controls.Add(this.lbKey);
			this.panDecrypt.Controls.Add(this.rbDecryptAES256);
			this.panDecrypt.Controls.Add(this.rbDecryptRSA256);
			this.panDecrypt.Location = new System.Drawing.Point(11, 165);
			this.panDecrypt.Name = "panDecrypt";
			this.panDecrypt.Size = new System.Drawing.Size(613, 142);
			this.panDecrypt.TabIndex = 17;
			this.panDecrypt.Visible = false;
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(14, 86);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(585, 24);
			this.txtKey.TabIndex = 3;
			// 
			// lbKey
			// 
			this.lbKey.AutoSize = true;
			this.lbKey.Location = new System.Drawing.Point(11, 64);
			this.lbKey.Name = "lbKey";
			this.lbKey.Size = new System.Drawing.Size(22, 15);
			this.lbKey.TabIndex = 2;
			this.lbKey.Text = "키";
			// 
			// rbDecryptAES256
			// 
			this.rbDecryptAES256.AutoSize = true;
			this.rbDecryptAES256.Location = new System.Drawing.Point(14, 37);
			this.rbDecryptAES256.Name = "rbDecryptAES256";
			this.rbDecryptAES256.Size = new System.Drawing.Size(77, 19);
			this.rbDecryptAES256.TabIndex = 1;
			this.rbDecryptAES256.TabStop = true;
			this.rbDecryptAES256.Text = "AES256";
			this.rbDecryptAES256.UseVisualStyleBackColor = true;
			// 
			// rbDecryptRSA256
			// 
			this.rbDecryptRSA256.AutoSize = true;
			this.rbDecryptRSA256.Location = new System.Drawing.Point(14, 12);
			this.rbDecryptRSA256.Name = "rbDecryptRSA256";
			this.rbDecryptRSA256.Size = new System.Drawing.Size(78, 19);
			this.rbDecryptRSA256.TabIndex = 0;
			this.rbDecryptRSA256.TabStop = true;
			this.rbDecryptRSA256.Text = "RSA256";
			this.rbDecryptRSA256.UseVisualStyleBackColor = true;
			// 
			// cbDecrypt
			// 
			this.cbDecrypt.AutoSize = true;
			this.cbDecrypt.Location = new System.Drawing.Point(11, 140);
			this.cbDecrypt.Name = "cbDecrypt";
			this.cbDecrypt.Size = new System.Drawing.Size(156, 19);
			this.cbDecrypt.TabIndex = 16;
			this.cbDecrypt.Text = "분할된 파일 복호화";
			this.cbDecrypt.UseVisualStyleBackColor = true;
			this.cbDecrypt.CheckedChanged += new System.EventHandler(this.cbDecrypt_CheckedChanged);
			// 
			// btnCoalescenceFolderBrowse
			// 
			this.btnCoalescenceFolderBrowse.Location = new System.Drawing.Point(595, 35);
			this.btnCoalescenceFolderBrowse.Name = "btnCoalescenceFolderBrowse";
			this.btnCoalescenceFolderBrowse.Size = new System.Drawing.Size(31, 24);
			this.btnCoalescenceFolderBrowse.TabIndex = 13;
			this.btnCoalescenceFolderBrowse.Text = "...";
			this.btnCoalescenceFolderBrowse.UseVisualStyleBackColor = true;
			this.btnCoalescenceFolderBrowse.Click += new System.EventHandler(this.btnCoalescenceFolderBrowse_Click);
			// 
			// txtCoalescenceFolder
			// 
			this.txtCoalescenceFolder.BackColor = System.Drawing.Color.White;
			this.txtCoalescenceFolder.Location = new System.Drawing.Point(11, 35);
			this.txtCoalescenceFolder.Name = "txtCoalescenceFolder";
			this.txtCoalescenceFolder.ReadOnly = true;
			this.txtCoalescenceFolder.Size = new System.Drawing.Size(578, 24);
			this.txtCoalescenceFolder.TabIndex = 12;
			// 
			// lbCoalescenceFolder
			// 
			this.lbCoalescenceFolder.AutoSize = true;
			this.lbCoalescenceFolder.Location = new System.Drawing.Point(8, 12);
			this.lbCoalescenceFolder.Name = "lbCoalescenceFolder";
			this.lbCoalescenceFolder.Size = new System.Drawing.Size(122, 15);
			this.lbCoalescenceFolder.TabIndex = 11;
			this.lbCoalescenceFolder.Text = "분할된 파일 폴더";
			// 
			// lbCopyright
			// 
			this.lbCopyright.AutoSize = true;
			this.lbCopyright.Font = new System.Drawing.Font("굴림", 10F);
			this.lbCopyright.Location = new System.Drawing.Point(1, 458);
			this.lbCopyright.Name = "lbCopyright";
			this.lbCopyright.Size = new System.Drawing.Size(252, 14);
			this.lbCopyright.TabIndex = 1;
			this.lbCopyright.Text = "ⓒ 2016. kmc7468 All rights reserved.";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.lbCopyright);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FileSpliter 1.0.0.0";
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.panDivisionEncrypt.ResumeLayout(false);
			this.panDivisionEncrypt.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDivisionCount)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panDecrypt.ResumeLayout(false);
			this.panDecrypt.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label lbDivisionUrl;
		private System.Windows.Forms.Button btnDivisionBrowse;
		private System.Windows.Forms.TextBox txtDivisionUrl;
		private System.Windows.Forms.NumericUpDown nudDivisionCount;
		private System.Windows.Forms.Label lbDivisionSplitCount;
		private System.Windows.Forms.Label lbCopyright;
		private System.Windows.Forms.Button btnDivisionFolderBrowse;
		private System.Windows.Forms.TextBox txtDivisionFolder;
		private System.Windows.Forms.Label lbDivisionFolder;
		private System.Windows.Forms.Button btnDivision;
		private System.Windows.Forms.Panel panDivisionEncrypt;
		private System.Windows.Forms.CheckBox cbDivisionFileEncrypt;
		private System.Windows.Forms.RadioButton rbEncryptAES256;
		private System.Windows.Forms.RadioButton rbEncryptRSA256;
		private System.Windows.Forms.Button btnEncryptRsaKeyGen;
		private System.Windows.Forms.TextBox txtEncryptKey;
		private System.Windows.Forms.Label lbEncryptKey;
		private System.Windows.Forms.Button btnCoalescenceBrowse;
		private System.Windows.Forms.TextBox txtCoalescenceUrl;
		private System.Windows.Forms.Label lbCoalescenceUrl;
		private System.Windows.Forms.Button btnCoalescence;
		private System.Windows.Forms.Panel panDecrypt;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label lbKey;
		private System.Windows.Forms.RadioButton rbDecryptAES256;
		private System.Windows.Forms.RadioButton rbDecryptRSA256;
		private System.Windows.Forms.CheckBox cbDecrypt;
		private System.Windows.Forms.Button btnCoalescenceFolderBrowse;
		private System.Windows.Forms.TextBox txtCoalescenceFolder;
		private System.Windows.Forms.Label lbCoalescenceFolder;
	}
}

