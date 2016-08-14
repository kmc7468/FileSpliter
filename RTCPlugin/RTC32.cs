using FileSpliter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPlugin
{
	public sealed class RTC32 : Crypto
	{
		public override void Encrypt(string fromPath, string toPath, string key)
		{
			RTC32org rtc = new RTC32org(key);

			string from = Encoding.UTF8.GetString(File.ReadAllBytes(fromPath));

			string to = rtc.Encrypt(from);

			File.WriteAllText(toPath, to, Encoding.Default);
		}

		public override void Decrypt(string fromPath, string toPath, string key)
		{
			RTC32org rtc = new RTC32org(key);

			string from = File.ReadAllText(fromPath, Encoding.Default);

			string to = rtc.Decrypt(from);

			byte[] save = Encoding.UTF8.GetBytes(to);

			File.WriteAllBytes(toPath, save);
		}
	}
}
