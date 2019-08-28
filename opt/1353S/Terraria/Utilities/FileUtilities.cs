using System;
using System.IO;
using System.Text.RegularExpressions;
using Terraria.Social;

namespace Terraria.Utilities
{
	// Token: 0x02000065 RID: 101
	public static class FileUtilities
	{
		// Token: 0x06000981 RID: 2433 RVA: 0x003B686C File Offset: 0x003B4A6C
		public static bool Exists(string path, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				return SocialAPI.Cloud.HasFile(path);
			}
			return File.Exists(path);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x003B688C File Offset: 0x003B4A8C
		public static void Delete(string path, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				SocialAPI.Cloud.Delete(path);
				return;
			}
			FileOperationAPIWrapper.MoveToRecycleBin(path);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x003B68AC File Offset: 0x003B4AAC
		public static string GetFullPath(string path, bool cloud)
		{
			if (!cloud)
			{
				return Path.GetFullPath(path);
			}
			return path;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x003B68BC File Offset: 0x003B4ABC
		public static void Copy(string source, string destination, bool cloud, bool overwrite = true)
		{
			if (!cloud)
			{
				File.Copy(source, destination, overwrite);
				return;
			}
			if (SocialAPI.Cloud == null || (!overwrite && SocialAPI.Cloud.HasFile(destination)))
			{
				return;
			}
			SocialAPI.Cloud.Write(destination, SocialAPI.Cloud.Read(source));
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x003B68FC File Offset: 0x003B4AFC
		public static void Move(string source, string destination, bool cloud, bool overwrite = true)
		{
			FileUtilities.Copy(source, destination, cloud, overwrite);
			FileUtilities.Delete(source, cloud);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x003B6910 File Offset: 0x003B4B10
		public static int GetFileSize(string path, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				return SocialAPI.Cloud.GetFileSize(path);
			}
			return (int)new FileInfo(path).Length;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x003B6934 File Offset: 0x003B4B34
		public static void Read(string path, byte[] buffer, int length, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				SocialAPI.Cloud.Read(path, buffer, length);
				return;
			}
			using (FileStream fileStream = File.OpenRead(path))
			{
				fileStream.Read(buffer, 0, length);
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x003B6988 File Offset: 0x003B4B88
		public static byte[] ReadAllBytes(string path, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				return SocialAPI.Cloud.Read(path);
			}
			return File.ReadAllBytes(path);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x003B69A8 File Offset: 0x003B4BA8
		public static void WriteAllBytes(string path, byte[] data, bool cloud)
		{
			FileUtilities.Write(path, data, data.Length, cloud);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x003B69B8 File Offset: 0x003B4BB8
		public static void Write(string path, byte[] data, int length, bool cloud)
		{
			if (cloud && SocialAPI.Cloud != null)
			{
				SocialAPI.Cloud.Write(path, data, length);
				return;
			}
			string parentFolderPath = FileUtilities.GetParentFolderPath(path, true);
			if (parentFolderPath != "")
			{
				Directory.CreateDirectory(parentFolderPath);
			}
			using (FileStream fileStream = File.Open(path, FileMode.Create))
			{
				while (fileStream.Position < (long)length)
				{
					fileStream.Write(data, (int)fileStream.Position, Math.Min(length - (int)fileStream.Position, 2048));
				}
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x003B6A4C File Offset: 0x003B4C4C
		public static bool MoveToCloud(string localPath, string cloudPath)
		{
			if (SocialAPI.Cloud == null)
			{
				return false;
			}
			FileUtilities.WriteAllBytes(cloudPath, FileUtilities.ReadAllBytes(localPath, false), true);
			FileUtilities.Delete(localPath, false);
			return true;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x003B6A70 File Offset: 0x003B4C70
		public static bool MoveToLocal(string cloudPath, string localPath)
		{
			if (SocialAPI.Cloud == null)
			{
				return false;
			}
			FileUtilities.WriteAllBytes(localPath, FileUtilities.ReadAllBytes(cloudPath, true), false);
			FileUtilities.Delete(cloudPath, true);
			return true;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x003B6A94 File Offset: 0x003B4C94
		public static string GetFileName(string path, bool includeExtension = true)
		{
			Match match = FileUtilities.FileNameRegex.Match(path);
			if (match == null || match.Groups["fileName"] == null)
			{
				return "";
			}
			includeExtension &= (match.Groups["extension"] != null);
			return match.Groups["fileName"].Value + (includeExtension ? match.Groups["extension"].Value : "");
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x003B6B18 File Offset: 0x003B4D18
		public static string GetParentFolderPath(string path, bool includeExtension = true)
		{
			Match match = FileUtilities.FileNameRegex.Match(path);
			if (match == null || match.Groups["path"] == null)
			{
				return "";
			}
			return match.Groups["path"].Value;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x003B6B64 File Offset: 0x003B4D64
		public static void CopyFolder(string sourcePath, string destinationPath)
		{
			Directory.CreateDirectory(destinationPath);
			string[] array = Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories);
			for (int i = 0; i < array.Length; i++)
			{
				Directory.CreateDirectory(array[i].Replace(sourcePath, destinationPath));
			}
			array = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
			for (int i = 0; i < array.Length; i++)
			{
				string expr_46 = array[i];
				File.Copy(expr_46, expr_46.Replace(sourcePath, destinationPath), true);
			}
		}

		// Token: 0x04000DAE RID: 3502
		private static Regex FileNameRegex = new Regex("^(?<path>.*[\\\\\\/])?(?:$|(?<fileName>.+?)(?:(?<extension>\\.[^.]*$)|$))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
	}
}
