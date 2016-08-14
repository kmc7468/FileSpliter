using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPlugin
{
	internal class RTC96org
	{
		private string Key = string.Empty;

		public RTC96org(string key)
		{
			Key = key;
		}

		public string Encrypt(string from)
		{
			RTC32org r32 = new RTC32org(Key);
			RTC64org r64 = new RTC64org(Key);

			string res = string.Empty;

			res = r32.Encrypt(from);
			res = r64.Encrypt(res, false);
			res = r64.Encrypt(res, true);

			return res;
		}

		public string Decrypt(string from)
		{
			RTC32org r32 = new RTC32org(Key);
			RTC64org r64 = new RTC64org(Key);

			string res = string.Empty;

			res = r64.Decrypt(from, true);
			res = r64.Decrypt(res, false);
			res = r32.Decrypt(res);

			return res;
		}
	}
}
