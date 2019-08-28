using System;
using System.Collections.Generic;
using System.IO;

namespace Terraria
{
	// Token: 0x02000021 RID: 33
	public struct BitsByte
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0002DC9C File Offset: 0x0002BE9C
		public BitsByte(bool b1 = false, bool b2 = false, bool b3 = false, bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false, bool b8 = false)
		{
			this.value = 0;
			this[0] = b1;
			this[1] = b2;
			this[2] = b3;
			this[3] = b4;
			this[4] = b5;
			this[5] = b6;
			this[6] = b7;
			this[7] = b8;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0002DCF8 File Offset: 0x0002BEF8
		public void ClearAll()
		{
			this.value = 0;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0002DD04 File Offset: 0x0002BF04
		public void SetAll()
		{
			this.value = 255;
		}

		// Token: 0x17000048 RID: 72
		public bool this[int key]
		{
			get
			{
				return ((int)this.value & 1 << key) != 0;
			}
			set
			{
				if (value)
				{
					this.value |= (byte)(1 << key);
					return;
				}
				this.value &= (byte)(~(byte)(1 << key));
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0002DD5C File Offset: 0x0002BF5C
		public void Retrieve(ref bool b0)
		{
			this.Retrieve(ref b0, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0002DD94 File Offset: 0x0002BF94
		public void Retrieve(ref bool b0, ref bool b1)
		{
			this.Retrieve(ref b0, ref b1, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0002DDC8 File Offset: 0x0002BFC8
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0002DDF8 File Offset: 0x0002BFF8
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0002DE24 File Offset: 0x0002C024
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref BitsByte.Null, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0002DE50 File Offset: 0x0002C050
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref b5, ref BitsByte.Null, ref BitsByte.Null);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0002DE78 File Offset: 0x0002C078
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6)
		{
			this.Retrieve(ref b0, ref b1, ref b2, ref b3, ref b4, ref b5, ref b6, ref BitsByte.Null);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0002DE9C File Offset: 0x0002C09C
		public void Retrieve(ref bool b0, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6, ref bool b7)
		{
			b0 = this[0];
			b1 = this[1];
			b2 = this[2];
			b3 = this[3];
			b4 = this[4];
			b5 = this[5];
			b6 = this[6];
			b7 = this[7];
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0002DEF8 File Offset: 0x0002C0F8
		public static implicit operator byte(BitsByte bb)
		{
			return bb.value;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0002DF00 File Offset: 0x0002C100
		public static implicit operator BitsByte(byte b)
		{
			return new BitsByte
			{
				value = b
			};
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0002DF20 File Offset: 0x0002C120
		public static BitsByte[] ComposeBitsBytesChain(bool optimizeLength, params bool[] flags)
		{
			int i = flags.Length;
			int num = 0;
			while (i > 0)
			{
				num++;
				i -= 7;
			}
			BitsByte[] array = new BitsByte[num];
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < flags.Length; j++)
			{
				array[num3][num2] = flags[j];
				num2++;
				if (num2 == 7 && num3 < num - 1)
				{
					array[num3][num2] = true;
					num2 = 0;
					num3++;
				}
			}
			if (optimizeLength)
			{
				int num4 = array.Length - 1;
				while (array[num4] == 0 && num4 > 0)
				{
					array[num4 - 1][7] = false;
					num4--;
				}
				Array.Resize<BitsByte>(ref array, num4 + 1);
			}
			return array;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0002DFDC File Offset: 0x0002C1DC
		public static BitsByte[] DecomposeBitsBytesChain(BinaryReader reader)
		{
			List<BitsByte> list = new List<BitsByte>();
			BitsByte item;
			do
			{
				item = reader.ReadByte();
				list.Add(item);
			}
			while (item[7]);
			return list.ToArray();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0002E014 File Offset: 0x0002C214
		public static void SortOfAUnitTest()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			BinaryReader reader = new BinaryReader(memoryStream);
			bool arg_25_0 = false;
			bool[] expr_1C = new bool[28];
			expr_1C[3] = true;
			expr_1C[14] = true;
			BitsByte[] array = BitsByte.ComposeBitsBytesChain(arg_25_0, expr_1C);
			BitsByte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				binaryWriter.Write(b);
			}
			memoryStream.Position = 0L;
			BitsByte[] array3 = BitsByte.DecomposeBitsBytesChain(reader);
			string arg = "";
			string arg2 = "";
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				BitsByte bb = array2[i];
				arg = arg + bb + ", ";
			}
			array2 = array3;
			for (int i = 0; i < array2.Length; i++)
			{
				BitsByte bb2 = array2[i];
				arg2 = arg2 + bb2 + ", ";
			}
			Main.NewText("done", 255, 255, 255, false);
		}

		// Token: 0x040001A0 RID: 416
		private static bool Null;

		// Token: 0x040001A1 RID: 417
		private byte value;
	}
}
