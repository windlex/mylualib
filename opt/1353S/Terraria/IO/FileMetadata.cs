using System;
using System.IO;

namespace Terraria.IO
{
	// Token: 0x0200007E RID: 126
	public class FileMetadata
	{
		// Token: 0x06000A6C RID: 2668 RVA: 0x003BFBF0 File Offset: 0x003BDDF0
		private FileMetadata()
		{
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x003BFBF8 File Offset: 0x003BDDF8
		public void Write(BinaryWriter writer)
		{
			writer.Write(27981915666277746uL | (ulong)this.Type << 56);
			writer.Write(this.Revision);
			writer.Write((ulong)((long)((this.IsFavorite.ToInt() & 1) | 0)));
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x003BFC38 File Offset: 0x003BDE38
		public void IncrementAndWrite(BinaryWriter writer)
		{
			this.Revision += 1u;
			this.Write(writer);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x003BFC50 File Offset: 0x003BDE50
		public static FileMetadata FromCurrentSettings(FileType type)
		{
			return new FileMetadata
			{
				Type = type,
				Revision = 0u,
				IsFavorite = false
			};
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x003BFC6C File Offset: 0x003BDE6C
		public static FileMetadata Read(BinaryReader reader, FileType expectedType)
		{
			FileMetadata fileMetadata = new FileMetadata();
			fileMetadata.Read(reader);
			if (fileMetadata.Type != expectedType)
			{
				throw new FileFormatException(string.Concat(new string[]
				{
					"Expected type \"",
					Enum.GetName(typeof(FileType), expectedType),
					"\" but found \"",
					Enum.GetName(typeof(FileType), fileMetadata.Type),
					"\"."
				}));
			}
			return fileMetadata;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x003BFCF0 File Offset: 0x003BDEF0
		private void Read(BinaryReader reader)
		{
			ulong expr_06 = reader.ReadUInt64();
			if ((expr_06 & 72057594037927935uL) != 27981915666277746uL)
			{
				throw new FileFormatException("Expected Re-Logic file format.");
			}
			byte b = (byte)(expr_06 >> 56 & 255uL);
			FileType fileType = FileType.None;
			FileType[] array = (FileType[])Enum.GetValues(typeof(FileType));
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == (FileType)b)
				{
					fileType = array[i];
					break;
				}
			}
			if (fileType == FileType.None)
			{
				throw new FileFormatException("Found invalid file type.");
			}
			this.Type = fileType;
			this.Revision = reader.ReadUInt32();
			ulong num = reader.ReadUInt64();
			this.IsFavorite = ((num & 1uL) == 1uL);
		}

		// Token: 0x04000E25 RID: 3621
		public const ulong MAGIC_NUMBER = 27981915666277746uL;

		// Token: 0x04000E26 RID: 3622
		public const int SIZE = 20;

		// Token: 0x04000E27 RID: 3623
		public FileType Type;

		// Token: 0x04000E28 RID: 3624
		public uint Revision;

		// Token: 0x04000E29 RID: 3625
		public bool IsFavorite;
	}
}
