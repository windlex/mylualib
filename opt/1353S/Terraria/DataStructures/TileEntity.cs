using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Terraria.GameContent.Tile_Entities;

namespace Terraria.DataStructures
{
	// Token: 0x0200018F RID: 399
	public abstract class TileEntity
	{
		// Token: 0x060012C6 RID: 4806 RVA: 0x004193EC File Offset: 0x004175EC
		public static int AssignNewID()
		{
			return TileEntity.TileEntitiesNextID++;
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060012C7 RID: 4807 RVA: 0x004193FC File Offset: 0x004175FC
		// (remove) Token: 0x060012C8 RID: 4808 RVA: 0x00419430 File Offset: 0x00417630
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action _UpdateStart;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060012C9 RID: 4809 RVA: 0x00419464 File Offset: 0x00417664
		// (remove) Token: 0x060012CA RID: 4810 RVA: 0x00419498 File Offset: 0x00417698
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action _UpdateEnd;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060012CB RID: 4811 RVA: 0x004194CC File Offset: 0x004176CC
		// (remove) Token: 0x060012CC RID: 4812 RVA: 0x00419500 File Offset: 0x00417700
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action<int, int, int> _NetPlaceEntity;

		// Token: 0x060012CD RID: 4813 RVA: 0x00419534 File Offset: 0x00417734
		public static void Clear()
		{
			TileEntity.ByID.Clear();
			TileEntity.ByPosition.Clear();
			TileEntity.TileEntitiesNextID = 0;
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x00419550 File Offset: 0x00417750
		public static void UpdateStart()
		{
			if (TileEntity._UpdateStart != null)
			{
				TileEntity._UpdateStart();
			}
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x00419564 File Offset: 0x00417764
		public static void UpdateEnd()
		{
			if (TileEntity._UpdateEnd != null)
			{
				TileEntity._UpdateEnd();
			}
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x00419578 File Offset: 0x00417778
		public static void InitializeAll()
		{
			TETrainingDummy.Initialize();
			TEItemFrame.Initialize();
			TELogicSensor.Initialize();
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x0041958C File Offset: 0x0041778C
		public static void PlaceEntityNet(int x, int y, int type)
		{
			if (!WorldGen.InWorld(x, y, 0))
			{
				return;
			}
			if (TileEntity.ByPosition.ContainsKey(new Point16(x, y)))
			{
				return;
			}
			if (TileEntity._NetPlaceEntity != null)
			{
				TileEntity._NetPlaceEntity(x, y, type);
			}
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x004195C4 File Offset: 0x004177C4
		public virtual void Update()
		{
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x004195C8 File Offset: 0x004177C8
		public static void Write(BinaryWriter writer, TileEntity ent, bool networkSend = false)
		{
			writer.Write(ent.type);
			ent.WriteInner(writer, networkSend);
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x004195E0 File Offset: 0x004177E0
		public static TileEntity Read(BinaryReader reader, bool networkSend = false)
		{
			TileEntity tileEntity = null;
			byte b = reader.ReadByte();
			switch (b)
			{
			case 0:
				tileEntity = new TETrainingDummy();
				break;
			case 1:
				tileEntity = new TEItemFrame();
				break;
			case 2:
				tileEntity = new TELogicSensor();
				break;
			}
			tileEntity.type = b;
			tileEntity.ReadInner(reader, networkSend);
			return tileEntity;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00419630 File Offset: 0x00417830
		private void WriteInner(BinaryWriter writer, bool networkSend)
		{
			if (!networkSend)
			{
				writer.Write(this.ID);
			}
			writer.Write(this.Position.X);
			writer.Write(this.Position.Y);
			this.WriteExtraData(writer, networkSend);
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0041966C File Offset: 0x0041786C
		private void ReadInner(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				this.ID = reader.ReadInt32();
			}
			this.Position = new Point16(reader.ReadInt16(), reader.ReadInt16());
			this.ReadExtraData(reader, networkSend);
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x0041969C File Offset: 0x0041789C
		public virtual void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x004196A0 File Offset: 0x004178A0
		public virtual void ReadExtraData(BinaryReader reader, bool networkSend)
		{
		}

		// Token: 0x04003473 RID: 13427
		public const int MaxEntitiesPerChunk = 1000;

		// Token: 0x04003474 RID: 13428
		public static Dictionary<int, TileEntity> ByID = new Dictionary<int, TileEntity>();

		// Token: 0x04003475 RID: 13429
		public static Dictionary<Point16, TileEntity> ByPosition = new Dictionary<Point16, TileEntity>();

		// Token: 0x04003476 RID: 13430
		public static int TileEntitiesNextID = 0;

		// Token: 0x0400347A RID: 13434
		public int ID;

		// Token: 0x0400347B RID: 13435
		public Point16 Position;

		// Token: 0x0400347C RID: 13436
		public byte type;
	}
}
