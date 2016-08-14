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
			Splitter.Division(@"C:\Users\KMC\Desktop\f.txt", 1, @"C:\Users\KMC\Desktop\z", ".txt");
			Splitter.Coalescence(@"C:\Users\KMC\Desktop\z", @"C:\Users\KMC\Desktop\ff.txt");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}
	}
}
