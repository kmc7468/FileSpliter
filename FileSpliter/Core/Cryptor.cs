using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public static class Cryptor
	{
		public static void EncryptFile(Crypto cryptor, string key, string fromPath, string toPath)
		{
			cryptor.Encrypt(fromPath, toPath, key);
		}

		public static void DecryptFile(Crypto cryptor, string key, string fromPath, string toPath)
		{
			cryptor.Decrypt(fromPath, toPath, key);
		}

		public static void EncryptFiles(Crypto cryptor, string key, Dictionary<string, string> paths)
		{
			foreach(var it in paths)
			{
				cryptor.Encrypt(it.Key, it.Value, key);
			}
		}

		public static void DecryptFiles(Crypto cryptor, string key, Dictionary<string, string> paths)
		{
			foreach (var it in paths)
			{
				cryptor.Decrypt(it.Key, it.Value, key);
			}
		}

		public static void EncryptFiles(Crypto cryptor, string key, string folderPath, string toFolder)
		{
			foreach(var it in System.IO.Directory.GetFiles(folderPath))
			{
				cryptor.Encrypt(it, $@"{toFolder}\{System.IO.Path.GetFileName(it)}", key);
			}
		}

		public static void DecryptFiles(Crypto cryptor, string key, string folderPath, string toFolder)
		{
			foreach (var it in System.IO.Directory.GetFiles(folderPath))
			{
				cryptor.Decrypt(it, $@"{toFolder}\{System.IO.Path.GetFileName(it)}", key);
			}
		}
    }
}
