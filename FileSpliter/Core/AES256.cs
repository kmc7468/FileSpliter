using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public sealed class AES256 : Crypto
	{
		// http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt
		// http://blog.naver.com/retn0/220685813500
		private class crypto
		{
			static byte[] keyBytes = null;
			static byte[] saltBytes = null;

			public byte[] KeyBytes { set { keyBytes = SHA256.Create().ComputeHash(value); } }
			public byte[] SaltBytes { set { saltBytes = value; } }
			public string KeyString { set { keyBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)); } }
			public string SaltString { set { saltBytes = Encoding.UTF8.GetBytes(value); } }

			public byte[] EncryptByte(byte[] plainBytes)
			{
				byte[] encryptedBytes = null;

				using (MemoryStream MS = new MemoryStream())
				{
					using (RijndaelManaged AES = new RijndaelManaged())
					{
						AES.KeySize = 256;
						AES.BlockSize = 128;

						var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);
						AES.Key = key.GetBytes(AES.KeySize / 8);
						AES.IV = key.GetBytes(AES.BlockSize / 8);
						AES.Mode = CipherMode.CBC;

						using (var CS = new CryptoStream(MS, AES.CreateEncryptor(), CryptoStreamMode.Write))
						{
							CS.Write(plainBytes, 0, plainBytes.Length);
							CS.Close();
						}

						encryptedBytes = MS.ToArray();
					}
				}

				return encryptedBytes;
			}

			public byte[] DecryptByte(byte[] cipherBytes)
			{
				byte[] decryptedBytes = null;

				using (MemoryStream MS = new MemoryStream())
				{
					using (RijndaelManaged AES = new RijndaelManaged())
					{
						AES.KeySize = 256;
						AES.BlockSize = 128;

						var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);
						AES.Key = key.GetBytes(AES.KeySize / 8);
						AES.IV = key.GetBytes(AES.BlockSize / 8);
						AES.Mode = CipherMode.CBC;

						using (var CS = new CryptoStream(MS, AES.CreateDecryptor(), CryptoStreamMode.Write))
						{
							CS.Write(cipherBytes, 0, cipherBytes.Length);
							CS.Close();
						}

						decryptedBytes = MS.ToArray();
					}
				}

				return decryptedBytes;
			}

			public string EncryptString(string plainString)
			{
				return Convert.ToBase64String(EncryptByte(Encoding.UTF8.GetBytes(plainString)));
			}

			public string DecryptString(string cipherString)
			{
				try { return Encoding.UTF8.GetString(DecryptByte(Convert.FromBase64String(cipherString))); } catch { return null; }
			}
		}

		public override void Encrypt(string fromPath, string toPath, string key)
		{
			crypto aes = new crypto();

			aes.KeyString = key;
			aes.SaltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

			byte[] b = File.ReadAllBytes(fromPath);

			byte[] r = aes.EncryptByte(b);

			File.WriteAllText(toPath, Convert.ToBase64String(r), Encoding.Default);
		}

		public override void Decrypt(string fromPath, string toPath, string key)
		{
			crypto aes = new crypto();

			aes.KeyString = key;
			aes.SaltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

			byte[] b = Convert.FromBase64String(File.ReadAllText(fromPath, Encoding.Default));

			byte[] r = aes.DecryptByte(b);

			File.WriteAllBytes(toPath, r);
		}
	}
}
