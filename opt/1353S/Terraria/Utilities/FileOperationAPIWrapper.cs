using System;
using System.Runtime.InteropServices;

namespace Terraria.Utilities
{
	// Token: 0x02000064 RID: 100
	public static class FileOperationAPIWrapper
	{
		// Token: 0x0600097B RID: 2427
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern int SHFileOperation(ref FileOperationAPIWrapper.SHFILEOPSTRUCT FileOp);

		// Token: 0x0600097C RID: 2428 RVA: 0x003B6780 File Offset: 0x003B4980
		private static bool Send(string path, FileOperationAPIWrapper.FileOperationFlags flags)
		{
			bool result;
			try
			{
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT = new FileOperationAPIWrapper.SHFILEOPSTRUCT
				{
					wFunc = FileOperationAPIWrapper.FileOperationType.FO_DELETE,
					pFrom = path + "\0\0",
					fFlags = (FileOperationAPIWrapper.FileOperationFlags.FOF_ALLOWUNDO | flags)
				};
				FileOperationAPIWrapper.SHFileOperation(ref sHFILEOPSTRUCT);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x003B67E0 File Offset: 0x003B49E0
		private static bool Send(string path)
		{
			return FileOperationAPIWrapper.Send(path, FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_WANTNUKEWARNING);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x003B67F0 File Offset: 0x003B49F0
		public static bool MoveToRecycleBin(string path)
		{
			return FileOperationAPIWrapper.Send(path, FileOperationAPIWrapper.FileOperationFlags.FOF_SILENT | FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_NOERRORUI);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x003B6800 File Offset: 0x003B4A00
		private static bool DeleteFile(string path, FileOperationAPIWrapper.FileOperationFlags flags)
		{
			bool result;
			try
			{
				FileOperationAPIWrapper.SHFILEOPSTRUCT sHFILEOPSTRUCT = new FileOperationAPIWrapper.SHFILEOPSTRUCT
				{
					wFunc = FileOperationAPIWrapper.FileOperationType.FO_DELETE,
					pFrom = path + "\0\0",
					fFlags = flags
				};
				FileOperationAPIWrapper.SHFileOperation(ref sHFILEOPSTRUCT);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x003B685C File Offset: 0x003B4A5C
		private static bool DeleteCompletelySilent(string path)
		{
			return FileOperationAPIWrapper.DeleteFile(path, FileOperationAPIWrapper.FileOperationFlags.FOF_SILENT | FileOperationAPIWrapper.FileOperationFlags.FOF_NOCONFIRMATION | FileOperationAPIWrapper.FileOperationFlags.FOF_NOERRORUI);
		}

		// Token: 0x02000228 RID: 552
		[Flags]
		private enum FileOperationFlags : ushort
		{
			// Token: 0x040037B7 RID: 14263
			FOF_SILENT = 4,
			// Token: 0x040037B8 RID: 14264
			FOF_NOCONFIRMATION = 16,
			// Token: 0x040037B9 RID: 14265
			FOF_ALLOWUNDO = 64,
			// Token: 0x040037BA RID: 14266
			FOF_SIMPLEPROGRESS = 256,
			// Token: 0x040037BB RID: 14267
			FOF_NOERRORUI = 1024,
			// Token: 0x040037BC RID: 14268
			FOF_WANTNUKEWARNING = 16384
		}

		// Token: 0x02000229 RID: 553
		private enum FileOperationType : uint
		{
			// Token: 0x040037BE RID: 14270
			FO_MOVE = 1u,
			// Token: 0x040037BF RID: 14271
			FO_COPY,
			// Token: 0x040037C0 RID: 14272
			FO_DELETE,
			// Token: 0x040037C1 RID: 14273
			FO_RENAME
		}

		// Token: 0x0200022A RID: 554
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
		private struct SHFILEOPSTRUCT
		{
			// Token: 0x040037C2 RID: 14274
			public IntPtr hwnd;

			// Token: 0x040037C3 RID: 14275
			[MarshalAs(UnmanagedType.U4)]
			public FileOperationAPIWrapper.FileOperationType wFunc;

			// Token: 0x040037C4 RID: 14276
			public string pFrom;

			// Token: 0x040037C5 RID: 14277
			public string pTo;

			// Token: 0x040037C6 RID: 14278
			public FileOperationAPIWrapper.FileOperationFlags fFlags;

			// Token: 0x040037C7 RID: 14279
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAnyOperationsAborted;

			// Token: 0x040037C8 RID: 14280
			public IntPtr hNameMappings;

			// Token: 0x040037C9 RID: 14281
			public string lpszProgressTitle;
		}
	}
}
