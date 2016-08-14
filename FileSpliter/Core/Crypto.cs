using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public abstract class Crypto
	{
		public abstract void Encrypt(string fromPath, string toPath, string key);
		public abstract void Decrypt(string fromPath, string toPath, string key);
	}
}
