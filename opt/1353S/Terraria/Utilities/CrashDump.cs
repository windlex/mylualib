using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using ReLogic.OS;

namespace Terraria.Utilities
{
	// Token: 0x02000063 RID: 99
	public static class CrashDump
	{
		// Token: 0x06000975 RID: 2421 RVA: 0x003B5FF0 File Offset: 0x003B41F0
		private static string CreateDumpName()
		{
			DateTime dateTime = DateTime.Now.ToLocalTime();
			return string.Format("{0}_{1}_{2}_{3}.dmp", new object[]
			{
				"Terraria",
				Main.versionNumber,
				dateTime.ToString("MM-dd-yy_HH-mm-ss-ffff", CultureInfo.InvariantCulture),
				Thread.CurrentThread.ManagedThreadId
			});
		}

		// Token: 0x0600097A RID: 2426
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern uint GetCurrentThreadId();

		// Token: 0x06000978 RID: 2424
		[DllImport("dbghelp.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		private static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, ref CrashDump.MiniDumpExceptionInformation expParam, IntPtr userStreamParam, IntPtr callbackParam);

		// Token: 0x06000979 RID: 2425
		[DllImport("dbghelp.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		private static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

		// Token: 0x06000974 RID: 2420 RVA: 0x003B5FE3 File Offset: 0x003B41E3
		public static bool Write(CrashDump.Options options, string outputDirectory = ".")
		{
			return CrashDump.Write(options, CrashDump.ExceptionInfo.None, outputDirectory);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x003B6054 File Offset: 0x003B4254
		private static bool Write(CrashDump.Options options, CrashDump.ExceptionInfo exceptionInfo, string outputDirectory)
		{
			if (!Platform.IsWindows)
			{
				return false;
			}
			string arg_23_0 = Path.Combine(outputDirectory, CrashDump.CreateDumpName());
			if (!Directory.Exists(outputDirectory))
			{
				Directory.CreateDirectory(outputDirectory);
			}
			bool result;
			using (FileStream fileStream = File.Create(arg_23_0))
			{
				result = CrashDump.Write(fileStream.SafeFileHandle, options, exceptionInfo);
			}
			return result;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x003B60B8 File Offset: 0x003B42B8
		private static bool Write(SafeHandle fileHandle, CrashDump.Options options, CrashDump.ExceptionInfo exceptionInfo)
		{
			if (!Platform.IsWindows)
			{
				return false;
			}
			Process expr_0E = Process.GetCurrentProcess();
			IntPtr handle = expr_0E.Handle;
			uint id = (uint)expr_0E.Id;
			CrashDump.MiniDumpExceptionInformation miniDumpExceptionInformation;
			miniDumpExceptionInformation.ThreadId = CrashDump.GetCurrentThreadId();
			miniDumpExceptionInformation.ClientPointers = false;
			miniDumpExceptionInformation.ExceptionPointers = IntPtr.Zero;
			if (exceptionInfo == CrashDump.ExceptionInfo.Present)
			{
				miniDumpExceptionInformation.ExceptionPointers = Marshal.GetExceptionPointers();
			}
			bool result;
			if (miniDumpExceptionInformation.ExceptionPointers == IntPtr.Zero)
			{
				result = CrashDump.MiniDumpWriteDump(handle, id, fileHandle, (uint)options, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			}
			else
			{
				result = CrashDump.MiniDumpWriteDump(handle, id, fileHandle, (uint)options, ref miniDumpExceptionInformation, IntPtr.Zero, IntPtr.Zero);
			}
			return result;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x003B5FD9 File Offset: 0x003B41D9
		public static bool WriteException(CrashDump.Options options, string outputDirectory = ".")
		{
			return CrashDump.Write(options, CrashDump.ExceptionInfo.Present, outputDirectory);
		}

		// Token: 0x02000226 RID: 550
		private enum ExceptionInfo
		{
			// Token: 0x040037B1 RID: 14257
			None,
			// Token: 0x040037B2 RID: 14258
			Present
		}

		// Token: 0x02000227 RID: 551
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct MiniDumpExceptionInformation
		{
			// Token: 0x040037B3 RID: 14259
			public uint ThreadId;

			// Token: 0x040037B4 RID: 14260
			public IntPtr ExceptionPointers;

			// Token: 0x040037B5 RID: 14261
			[MarshalAs(UnmanagedType.Bool)]
			public bool ClientPointers;
		}

		// Token: 0x02000225 RID: 549
		[Flags]
		public enum Options : uint
		{
			// Token: 0x0400379C RID: 14236
			Normal = 0u,
			// Token: 0x0400379D RID: 14237
			WithDataSegs = 1u,
			// Token: 0x0400379E RID: 14238
			WithFullMemory = 2u,
			// Token: 0x0400379F RID: 14239
			WithHandleData = 4u,
			// Token: 0x040037A0 RID: 14240
			FilterMemory = 8u,
			// Token: 0x040037A1 RID: 14241
			ScanMemory = 16u,
			// Token: 0x040037A2 RID: 14242
			WithUnloadedModules = 32u,
			// Token: 0x040037A3 RID: 14243
			WithIndirectlyReferencedMemory = 64u,
			// Token: 0x040037A4 RID: 14244
			FilterModulePaths = 128u,
			// Token: 0x040037A5 RID: 14245
			WithProcessThreadData = 256u,
			// Token: 0x040037A6 RID: 14246
			WithPrivateReadWriteMemory = 512u,
			// Token: 0x040037A7 RID: 14247
			WithoutOptionalData = 1024u,
			// Token: 0x040037A8 RID: 14248
			WithFullMemoryInfo = 2048u,
			// Token: 0x040037A9 RID: 14249
			WithThreadInfo = 4096u,
			// Token: 0x040037AA RID: 14250
			WithCodeSegs = 8192u,
			// Token: 0x040037AB RID: 14251
			WithoutAuxiliaryState = 16384u,
			// Token: 0x040037AC RID: 14252
			WithFullAuxiliaryState = 32768u,
			// Token: 0x040037AD RID: 14253
			WithPrivateWriteCopyMemory = 65536u,
			// Token: 0x040037AE RID: 14254
			IgnoreInaccessibleMemory = 131072u,
			// Token: 0x040037AF RID: 14255
			ValidTypeFlags = 262143u
		}
	}
}
