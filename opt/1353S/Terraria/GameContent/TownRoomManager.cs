using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace Terraria.GameContent
{
	// Token: 0x0200010B RID: 267
	public class TownRoomManager
	{
		// Token: 0x06000F04 RID: 3844 RVA: 0x003F06C0 File Offset: 0x003EE8C0
		public int FindOccupation(int x, int y)
		{
			return this.FindOccupation(new Point(x, y));
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x003F06D0 File Offset: 0x003EE8D0
		public int FindOccupation(Point tilePosition)
		{
			foreach (Tuple<int, Point> current in this._roomLocationPairs)
			{
				if (current.Item2 == tilePosition)
				{
					return current.Item1;
				}
			}
			return -1;
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x003F0738 File Offset: 0x003EE938
		public bool HasRoomQuick(int npcID)
		{
			return this._hasRoom[npcID];
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x003F0744 File Offset: 0x003EE944
		public bool HasRoom(int npcID, out Point roomPosition)
		{
			if (!this._hasRoom[npcID])
			{
				roomPosition = new Point(0, 0);
				return false;
			}
			foreach (Tuple<int, Point> current in this._roomLocationPairs)
			{
				if (current.Item1 == npcID)
				{
					roomPosition = current.Item2;
					return true;
				}
			}
			roomPosition = new Point(0, 0);
			return false;
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x003F07D4 File Offset: 0x003EE9D4
		public void SetRoom(int npcID, int x, int y)
		{
			this._hasRoom[npcID] = true;
			this.SetRoom(npcID, new Point(x, y));
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x003F07F0 File Offset: 0x003EE9F0
		public void SetRoom(int npcID, Point pt)
		{
			this._roomLocationPairs.RemoveAll((Tuple<int, Point> x) => x.Item1 == npcID);
			this._roomLocationPairs.Add(Tuple.Create<int, Point>(npcID, pt));
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x003F083C File Offset: 0x003EEA3C
		public void KickOut(NPC n)
		{
			this.KickOut(n.type);
			this._hasRoom[n.type] = false;
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x003F0858 File Offset: 0x003EEA58
		public void KickOut(int npcType)
		{
			this._roomLocationPairs.RemoveAll((Tuple<int, Point> x) => x.Item1 == npcType);
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x003F088C File Offset: 0x003EEA8C
		public void DisplayRooms()
		{
			foreach (Tuple<int, Point> current in this._roomLocationPairs)
			{
				Dust.QuickDust(current.Item2, Main.hslToRgb((float)current.Item1 * 0.05f % 1f, 1f, 0.5f));
			}
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x003F0908 File Offset: 0x003EEB08
		public void Save(BinaryWriter writer)
		{
			writer.Write(this._roomLocationPairs.Count);
			foreach (Tuple<int, Point> current in this._roomLocationPairs)
			{
				writer.Write(current.Item1);
				writer.Write(current.Item2.X);
				writer.Write(current.Item2.Y);
			}
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x003F0994 File Offset: 0x003EEB94
		public void Load(BinaryReader reader)
		{
			this.Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int num2 = reader.ReadInt32();
				Point item = new Point(reader.ReadInt32(), reader.ReadInt32());
				this._roomLocationPairs.Add(Tuple.Create<int, Point>(num2, item));
				this._hasRoom[num2] = true;
			}
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x003F09F0 File Offset: 0x003EEBF0
		public void Clear()
		{
			this._roomLocationPairs.Clear();
			for (int i = 0; i < this._hasRoom.Length; i++)
			{
				this._hasRoom[i] = false;
			}
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x003F0A24 File Offset: 0x003EEC24
		public byte GetHouseholdStatus(NPC n)
		{
			byte result = 0;
			if (n.homeless)
			{
				result = 1;
			}
			else if (this.HasRoomQuick(n.type))
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x04003026 RID: 12326
		private List<Tuple<int, Point>> _roomLocationPairs = new List<Tuple<int, Point>>();

		// Token: 0x04003027 RID: 12327
		private bool[] _hasRoom = new bool[580];
	}
}
