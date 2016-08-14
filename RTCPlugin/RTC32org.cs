using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCPlugin
{
	internal class RTC32org
	{
		private string Key = string.Empty;

		public RTC32org(string key)
		{
			Key = key;
		}

		private void KeyAlgorithm(ref int key, ref int plus, int i)
		{
			unchecked
			{
				plus ^= 5;
				plus += ~(plus << 30);
				plus ^= (plus >> 24);
				plus += (plus << 14);
				plus ^= (plus >> 23);
				plus += (plus << 15);
				plus ^= (plus >> 18);
				key += plus / 2;

				if (i % 2 == 0)
				{
					key -= plus;
				}
				else
				{
					key += plus;
				}
			}
		}

		public string Encrypt(string from)
		{
			unchecked
			{
				string res = string.Empty;

				int key = 0;
				int key_div = 0;
				int plus = 8;

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

					int temp01 = it;
					key += plus;
					temp01 -= key;
					res += (char)temp01;

					KeyAlgorithm(ref key, ref plus, i);
					KeyAlgorithm(ref key, ref plus, i);
					i++;
				}

				string temp = res;
				res = "";

				foreach (var it in temp)
				{
					res += string.Format("{0:00000}", (int)it);
				}

				return res;
			}
		}

		public string Decrypt(string from)
		{
			unchecked
			{
				string res = string.Empty;
				List<string> temp = new List<string>();
				temp = splitter(from);

				int key = 0;
				int key_div = 0;
				int plus = 8;

				foreach (var it in Key)
				{
					key += it;
				}

				key_div = key / 2;

				int i = 0;
				foreach (var it in temp)
				{
					KeyAlgorithm(ref key, ref plus, i);
					KeyAlgorithm(ref key, ref plus, i);

					int temp01 = int.Parse(it);
					key += plus;
					temp01 += key;
					res += (char)temp01;

					KeyAlgorithm(ref key, ref plus, i);
					KeyAlgorithm(ref key, ref plus, i);
					i++;
				}

				return res;
			}
		}

		private static List<string> splitter(string from)
		{
			var lst = new List<string>(from.Length / 5);

			for (int i = 0; i < from.Length / 5; i++) lst.Add(from.Substring(i * 5, 5));

			return lst;
		}
	}
}
