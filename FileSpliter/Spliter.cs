using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSpliter
{
	public static class Spliter
	{
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
			else
			{
				if (toExtension[0] == '.')
				{
					toExtension = toExtension.Substring(1);
				}

				byte[] file = System.IO.File.ReadAllBytes(fromPath.Trim());

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
						bytes.AddRange(BitConverter.GetBytes(fromPath.Length));
						bytes.AddRange(Encoding.UTF8.GetBytes(fromPath));
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

					if (j == fileCount)
					{
						break;
					}
				}

				if (mod != 0)
				{
					int start_index = file.Length - mod;

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

				foreach (var it in files)
				{
					byte[] b = Convert.FromBase64String(System.IO.File.ReadAllText(it.Trim(), Encoding.Default));
					byte[] bi = new byte[4] { b[0], b[1], b[2], b[3] };
					byte[] blen = new byte[4] { b[8], b[9], b[10], b[11] };
					int len = 0;
					len = BitConverter.ToInt32(blen, 0);
					byte[] fromPath_Bytes = new byte[len];
					for (int ii = 12; ii < 12 + fromPath_Bytes.Length; ii++)
					{
						fromPath_Bytes[ii - 12] = b[ii];
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
							throw new ArgumentException("한 파일에서 같은 개수로 분할된 파일만 합칠 수 있습니다.");
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
							throw new ArgumentException("한 파일에서 같은 개수로 분할된 파일만 합칠 수 있습니다.");
						}
					}
					int i = BitConverter.ToInt32(bi, 0);

					List<byte> bs = new List<byte>();

					for (int j = 12 + fromPath_Bytes.Length; j < b.Length; j++)
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
