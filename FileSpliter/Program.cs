using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSpliter
{
	static class Program
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Splitter.Division(@"C:\Users\KMC\Desktop\f.txt", 5, @"C:\Users\KMC\Desktop\f", "txt");
			RSA256.RSA256Key k = RSA256.GenKey();
			Cryptor.EncryptFiles(new RSA256(), k.PublicKey, @"C:\Users\KMC\Desktop\f", @"C:\Users\KMC\Desktop\ff");
			Cryptor.DecryptFiles(new RSA256(), k.PrivateKey, @"C:\Users\KMC\Desktop\ff", @"C:\Users\KMC\Desktop\fff");
			Splitter.Coalescence(@"C:\Users\KMC\Desktop\fff", @"C:\Users\KMC\Desktop\fff.txt");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}
	}
}
