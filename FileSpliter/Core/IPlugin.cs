using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public interface IPlugin
	{
		void Startup();
		void Shutdown();

		string Name { get; }
		string Developer { get; }
		Version Version { get; }

		bool EncryptDivision(bool shell = true);
		bool DecryptCoalescence(bool shell = true);
		bool EncryptFile(bool shell = true);
		bool DecryptFile(bool shell = true);
	}
}
