using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public sealed class RSA256 : Crypto
	{
		public override void Encrypt(string fromPath, string toPath, string key)
		{
			RSACryptoServiceProvider r = new RSACryptoServiceProvider();

			r.FromXmlString(key);

			byte[] b = File.ReadAllBytes(fromPath);

			byte[] res = r.Encrypt(b, false);

			File.WriteAllText(toPath, Convert.ToBase64String(res), Encoding.Default);
        }

		public override void Decrypt(string fromPath, string toPath, string key)
		{
			RSACryptoServiceProvider r = new RSACryptoServiceProvider();

			r.FromXmlString(key);

			byte[] b = Convert.FromBase64String(File.ReadAllText(fromPath, Encoding.Default));

			byte[] res = r.Decrypt(b, false);

			File.WriteAllBytes(toPath, res);
		}

		public static RSA256Key GenKey()
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

			RSAParameters privateKey = RSA.Create().ExportParameters(true);

			RSAParameters publicKey = new RSAParameters();
			publicKey.Modulus = privateKey.Modulus;
			publicKey.Exponent = privateKey.Exponent;

			RSA256Key rsa_r = new RSA256Key();

			{
				// Public

				RSACryptoServiceProvider r = new RSACryptoServiceProvider();
				r.ImportParameters(publicKey);
				rsa_r.PublicKey = rsa.ToXmlString(false);
			}

			{
				// Private

				RSACryptoServiceProvider r = new RSACryptoServiceProvider();
				r.ImportParameters(privateKey);
				rsa_r.PrivateKey = rsa.ToXmlString(true);
			}

			return rsa_r;
		}

		public struct RSA256Key
		{
			public string PublicKey;
			public string PrivateKey;
		}
	}
}
