namespace FileSpliter
{
	partial class frmRSAKey
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
			this.lbPublicKey = new System.Windows.Forms.Label();
			this.txtPublicKey = new System.Windows.Forms.TextBox();
			this.txtPrivateKey = new System.Windows.Forms.TextBox();
			this.lbPrivateKey = new System.Windows.Forms.Label();
			this.btnPublicCopy = new System.Windows.Forms.Button();
			this.btnPrivateCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbPublicKey
			// 
			this.lbPublicKey.AutoSize = true;
			this.lbPublicKey.Font = new System.Drawing.Font("굴림", 11F);
			this.lbPublicKey.Location = new System.Drawing.Point(12, 9);
			this.lbPublicKey.Name = "lbPublicKey";
			this.lbPublicKey.Size = new System.Drawing.Size(119, 15);
			this.lbPublicKey.TabIndex = 0;
			this.lbPublicKey.Text = "공개 키 (암호화)";
			// 
			// txtPublicKey
			// 
			this.txtPublicKey.BackColor = System.Drawing.SystemColors.Control;
			this.txtPublicKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPublicKey.Font = new System.Drawing.Font("굴림", 11F);
			this.txtPublicKey.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPublicKey.Location = new System.Drawing.Point(15, 34);
			this.txtPublicKey.Name = "txtPublicKey";
			this.txtPublicKey.ReadOnly = true;
			this.txtPublicKey.Size = new System.Drawing.Size(408, 17);
			this.txtPublicKey.TabIndex = 1;
			// 
			// txtPrivateKey
			// 
			this.txtPrivateKey.BackColor = System.Drawing.SystemColors.Control;
			this.txtPrivateKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPrivateKey.Font = new System.Drawing.Font("굴림", 11F);
			this.txtPrivateKey.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrivateKey.Location = new System.Drawing.Point(15, 85);
			this.txtPrivateKey.Name = "txtPrivateKey";
			this.txtPrivateKey.ReadOnly = true;
			this.txtPrivateKey.Size = new System.Drawing.Size(408, 17);
			this.txtPrivateKey.TabIndex = 3;
			// 
			// lbPrivateKey
			// 
			this.lbPrivateKey.AutoSize = true;
			this.lbPrivateKey.Font = new System.Drawing.Font("굴림", 11F);
			this.lbPrivateKey.Location = new System.Drawing.Point(12, 60);
			this.lbPrivateKey.Name = "lbPrivateKey";
			this.lbPrivateKey.Size = new System.Drawing.Size(119, 15);
			this.lbPrivateKey.TabIndex = 2;
			this.lbPrivateKey.Text = "보안 키 (복호화)";
			// 
			// btnPublicCopy
			// 
			this.btnPublicCopy.Font = new System.Drawing.Font("굴림", 6F);
			this.btnPublicCopy.Location = new System.Drawing.Point(429, 34);
			this.btnPublicCopy.Name = "btnPublicCopy";
			this.btnPublicCopy.Size = new System.Drawing.Size(59, 17);
			this.btnPublicCopy.TabIndex = 4;
			this.btnPublicCopy.Text = "복사";
			this.btnPublicCopy.UseVisualStyleBackColor = true;
			this.btnPublicCopy.Click += new System.EventHandler(this.btnPublicCopy_Click);
			// 
			// btnPrivateCopy
			// 
			this.btnPrivateCopy.Font = new System.Drawing.Font("굴림", 6F);
			this.btnPrivateCopy.Location = new System.Drawing.Point(429, 85);
			this.btnPrivateCopy.Name = "btnPrivateCopy";
			this.btnPrivateCopy.Size = new System.Drawing.Size(59, 17);
			this.btnPrivateCopy.TabIndex = 5;
			this.btnPrivateCopy.Text = "복사";
			this.btnPrivateCopy.UseVisualStyleBackColor = true;
			this.btnPrivateCopy.Click += new System.EventHandler(this.btnPrivateCopy_Click);
			// 
			// frmRSAKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(500, 115);
			this.Controls.Add(this.btnPrivateCopy);
			this.Controls.Add(this.btnPublicCopy);
			this.Controls.Add(this.txtPrivateKey);
			this.Controls.Add(this.lbPrivateKey);
			this.Controls.Add(this.txtPublicKey);
			this.Controls.Add(this.lbPublicKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmRSAKey";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RSA 키 생성";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbPublicKey;
		private System.Windows.Forms.TextBox txtPublicKey;
		private System.Windows.Forms.TextBox txtPrivateKey;
		private System.Windows.Forms.Label lbPrivateKey;
		private System.Windows.Forms.Button btnPublicCopy;
		private System.Windows.Forms.Button btnPrivateCopy;
	}
}