using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public static class Splitter
	{
		public const uint VERSION = 2;

		public static void Division(string fromPath, int fileCount, string toFolder, string toExtension)
		{
			if (fromPath.Trim() == "")
			{
				throw new ArgumentException("'fromPath' 매개 변수는 비어 있을 수 없습니다.");
			}
			else if (!System.IO.File.Exists(fromPath.Trim()))
			{
				throw new System.IO.FileNotFoundException($"'{fromPath.Trim()}' 은(는) 존재하지 않는 파일입니다.");
			}
			else if (toFolder.Trim() == "")
			{
				throw new ArgumentException("'toFolder' 매개 변수는 비어 있을 수 없습니다.");
			}
			else if (toExtension.Trim() == "")
			{
				throw new ArgumentException("'toExtension' 매개 변수는 비어 있을 수 없습니다.");
			}
			else if (toExtension[0] == '.' && toExtension.Length == 1)
			{
				throw new ArgumentException("'toExtension' 매개 변수는 맨 앞 .를 제외하고 1글자 이상이여야 합니다.");
			}
			else if (fileCount <= 1)
			{
				throw new ArgumentException("'fileCount' 매개 변수는 2 이상이여야 합니다.");
			}
			else
			{
				if (toExtension[0] == '.')
				{
					toExtension = toExtension.Substring(1);
				}

				byte[] file = System.IO.File.ReadAllBytes(fromPath.Trim());

				if (file.Length == 0)
				{
					throw new ArgumentException("파일 크기가 0바이트인 파일은 분할할 수 없습니다.");
				}
				else if (file.Length == 1)
				{
					List<byte[]> saves = new List<byte[]>();

					for(int iii = 0; iii < fileCount - 1; iii++)
					{
						List<byte> bs = new List<byte>();

						bs.AddRange(BitConverter.GetBytes(iii));
						bs.AddRange(BitConverter.GetBytes(fileCount));
						bs.AddRange(BitConverter.GetBytes(VERSION));
						byte[] b = Encoding.UTF8.GetBytes(fromPath);
						bs.AddRange(BitConverter.GetBytes(b.Length));
						bs.AddRange(b);

						saves.Add(bs.ToArray());
					}

					List<byte> bbs = new List<byte>();

					bbs.AddRange(BitConverter.GetBytes(fileCount - 1));
					bbs.AddRange(BitConverter.GetBytes(fileCount));
					bbs.AddRange(BitConverter.GetBytes(VERSION));
					byte[] bb = Encoding.UTF8.GetBytes(fromPath);
					bbs.AddRange(BitConverter.GetBytes(bb.Length));
					bbs.AddRange(bb);
					bbs.AddRange(file);

					saves.Add(bbs.ToArray());

					int iiii = 0;

					foreach (var it in saves)
					{
						System.IO.File.WriteAllText(toFolder + @"\" + System.IO.Path.GetFileNameWithoutExtension(fromPath) + $"_{iiii.ToString()}" + "." + toExtension, Convert.ToBase64String(it), Encoding.Default);
						iiii++;
					}

					return;
				}

				List<byte[]> splits = new List<byte[]>();

				int mod = file.Length % fileCount;

				int split = 0;

				if (mod == 0)
				{
					split = file.Length / fileCount;
				}
				else
				{
					split = (file.Length - mod) / fileCount;
				}

				List<byte> bytes = new List<byte>();

				int i = 0;
				int j = 0;

				foreach (var it in file)
				{
					if (i == 0)
					{
						bytes.AddRange(BitConverter.GetBytes(j));
						bytes.AddRange(BitConverter.GetBytes(fileCount));
						bytes.AddRange(BitConverter.GetBytes(VERSION));
						byte[] b = Encoding.UTF8.GetBytes(fromPath);
						bytes.AddRange(BitConverter.GetBytes(b.Length));
						bytes.AddRange(b);
					}

					bytes.Add(it);

					i++;

					if (i == split)
					{
						splits.Add(bytes.ToArray());
						bytes.Clear();
						i = 0;
						j++;
					}
				}

				if (mod != 0)
				{
					int start_index = file.Length - mod - 1;

					List<byte> b = new List<byte>();

					for (int iii = start_index; iii < file.Length; iii++)
					{
						b.Add(file[iii]);
					}

					List<byte> last = new List<byte>();
					last.AddRange(splits.Last());
					last.AddRange(b);

					splits[splits.Count - 1] = last.ToArray();
				}

				int ii = 0;

				foreach (var it in splits)
				{
					System.IO.File.WriteAllText(toFolder + @"\" + System.IO.Path.GetFileNameWithoutExtension(fromPath) + $"_{ii.ToString()}" + "." + toExtension, Convert.ToBase64String(it), Encoding.Default);
					ii++;
				}
			}
		}

		public static void Coalescence(string dirPath, string toPath)
		{
			List<string> items = new List<string>();

			foreach (var it in System.IO.Directory.GetFiles(dirPath))
			{
				items.Add(it);
			}

			Coalescence(items, toPath);
		}

		public static void Coalescence(List<string> files, string toPath)
		{
			if (toPath.Trim() == "")
			{
				throw new ArgumentException("'toPath' 매개 변수는 비어 있을 수 없습니다.");
			}
			else if (files.Count == 0)
			{
				throw new ArgumentException("'files' 매개 변수의 아이템 개수는 1 이상이여야 합니다.");
			}
			else
			{
				Dictionary<int, byte[]> items = new Dictionary<int, byte[]>();

				string from = string.Empty;
				int count = 0;
				uint? v = null;

				foreach (var it in files)
				{
					byte[] b = Convert.FromBase64String(System.IO.File.ReadAllText(it.Trim(), Encoding.Default));

					byte[] blen = new byte[4] { b[12], b[13], b[14], b[15] };
					int len = 0;
					len = BitConverter.ToInt32(blen, 0);

					byte[] fromPath_Bytes = new byte[len];
					for (int ii = 16; ii < 16 + fromPath_Bytes.Length; ii++)
					{
						fromPath_Bytes[ii - 16] = b[ii];
					}

					string fromPath = Encoding.UTF8.GetString(fromPath_Bytes);
					if (from == string.Empty)
					{
						from = fromPath;
					}
					else
					{
						if (from != fromPath)
						{
							throw new ArgumentException("한 파일에서 같은 개수 및 같은 버전으로 분할된 파일만 합칠 수 있습니다.");
						}
					}
					byte[] bc = new byte[4] { b[4], b[5], b[6], b[7] };
					int cout = BitConverter.ToInt32(bc, 0);
					if (count == 0)
					{
						count = cout;
					}
					else
					{
						if (count != cout)
						{
							throw new ArgumentException("한 파일에서 같은 개수 및 같은 버전으로 분할된 파일만 합칠 수 있습니다.");
						}
					}
					byte[] bv = new byte[4] { b[8], b[9], b[10], b[11] };
					uint ver = BitConverter.ToUInt32(bv, 0);

					if (ver != VERSION)
					{
						throw new ArgumentException($"합치려는 파일의 버전은 v.{ver.ToString()} 이지만 합칠 수 있는 버전은 v.{VERSION.ToString()} 입니다.");
					}

					if (v == null)
					{
						v = ver;
					}
					else
					{
						if (v != ver)
						{
							throw new ArgumentException("한 파일에서 같은 개수 및 같은 버전으로 분할된 파일만 합칠 수 있습니다.");
						}
					}

					byte[] bi = new byte[4] { b[0], b[1], b[2], b[3] };
					int i = BitConverter.ToInt32(bi, 0);

					List<byte> bs = new List<byte>();

					for (int j = 16 + fromPath_Bytes.Length; j < b.Length; j++)
					{
						bs.Add(b[j]);
					}

					items.Add(i, bs.ToArray());
				}

				List<byte> bytes = new List<byte>();

				for (int i = 0; i < files.Count; i++)
				{
					var kvp = items[i];

					bytes.AddRange(items[i]);
				}

				System.IO.File.WriteAllBytes(toPath.Trim(), bytes.ToArray());
			}
		}
	}
}
