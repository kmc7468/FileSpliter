using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSpliter
{
	public static class PluginManager
	{
		private static List<IPlugin> plugs = new List<IPlugin>();

		public static List<IPlugin> Plugins
		{
			get
			{
				return plugs;
			}
		}

		public static frmMain MainForm
		{
			get;
			internal set;
		}

		internal static void Init()
		{
			plugs.Clear();

			foreach (var it in System.IO.Directory.GetFiles(Application.StartupPath))
			{
				if (System.IO.Path.GetExtension(it).ToLower() == ".plug")
				{
					IPlugin p = CreateObject<IPlugin>(it, Assembly.LoadFile(it).GetName().Name + ".Plugin");

					p.Startup();

					plugs.Add(p);
				}
			}
		}

		// from RouteTycoon C# By sizeof
		internal static T CreateObject<T>(string path, string type) where T : class
		{
			return (T)Assembly.LoadFile(path).GetType(type, true, true).GetConstructor(new Type[0]).Invoke(new object[0]);
		}
	}
}
