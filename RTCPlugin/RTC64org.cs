using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPlugin
{
	internal class RTC64org
	{
		private string Key = string.Empty;

		public RTC64org(string key)
		{
			Key = key;
		}

		private void KeyAlgorithm(ref long key, ref long plus, int i)
		{
			unchecked
			{
				plus ^= 5;
				plus += ~(plus << 29);
				plus ^= (plus >> 23);
				plus += (plus << 13);
				plus ^= (plus >> 22);
				plus += (plus << 14);
				plus ^= (plus >> 17);
				key += plus / 2;

				if (i % 2 == 0)
				{
					key *= plus;
				}
				else
				{
					key /= plus;
				}
			}
		}

		public string Encrypt(string from, bool convertBase64)
		{
			unchecked
			{
				string res = string.Empty;

				long key = 0;
				long key_div = 0;
				long plus = 12;

				foreach (var it in Key)
				{
					key += it;
				}

				key_div = key / 2;

				int i = 0;
				foreach (var it in from)
				{
					KeyAlgorithm(ref key, ref plus, i);
					KeyAlgorithm(ref key, ref plus, i);

					long temp01 = it;
					key += plus;
					temp01 -= key;
					res += (char)temp01;

					KeyAlgorithm(ref key, ref plus, i);

					i++;
				}

				if (convertBase64)
				{
					res = Convert.ToBase64String(Encoding.UTF8.GetBytes(res));
				}

				return res;
			}
		}

		public string Decrypt(string from, bool fromBase64)
		{
			unchecked
			{
				if (fromBase64)
				{
					from = Encoding.UTF8.GetString(Convert.FromBase64String(from));
				}

				string res = string.Empty;

				long key = 0;
				long key_div = 0;
				long plus = 12;

				foreach (var it in Key)
				{
					key += it;
				}

				key_div = key / 2;

				int i = 0;
				foreach (var it in from)
				{
					KeyAlgorithm(ref key, ref plus, i);
					KeyAlgorithm(ref key, ref plus, i);

					long temp01 = it;
					key += plus;
					temp01 += key;
					res += (char)temp01;

					KeyAlgorithm(ref key, ref plus, i);

					i++;
				}

				return res;
			}
		}
	}
}
