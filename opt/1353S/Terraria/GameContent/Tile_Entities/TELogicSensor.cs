using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Tile_Entities
{
	// Token: 0x0200011E RID: 286
	public class TELogicSensor : TileEntity
	{
		// Token: 0x06000F7D RID: 3965 RVA: 0x003F49E7 File Offset: 0x003F2BE7
		public TELogicSensor()
		{
			this.logicCheck = TELogicSensor.LogicCheckType.None;
			this.On = false;
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x003F48C8 File Offset: 0x003F2AC8
		public void ChangeState(bool onState, bool TripWire)
		{
			if (onState != this.On && !TELogicSensor.SanityCheck((int)this.Position.X, (int)this.Position.Y))
			{
				return;
			}
			Main.tile[(int)this.Position.X, (int)this.Position.Y].frameX = ((short)(onState ? 18 : 0));
			this.On = onState;
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(-1, (int)this.Position.X, (int)this.Position.Y, 1, TileChangeType.None);
			}
			if (TripWire && Main.netMode != 1)
			{
				TELogicSensor.tripPoints.Add(Tuple.Create<Point16, bool>(this.Position, this.logicCheck == TELogicSensor.LogicCheckType.PlayerAbove));
			}
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x003F4BE8 File Offset: 0x003F2DE8
		public void FigureCheckState()
		{
			this.logicCheck = TELogicSensor.FigureCheckType((int)this.Position.X, (int)this.Position.Y, out this.On);
			TELogicSensor.GetFrame((int)this.Position.X, (int)this.Position.Y, this.logicCheck, this.On);
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x003F4A00 File Offset: 0x003F2C00
		public static TELogicSensor.LogicCheckType FigureCheckType(int x, int y, out bool on)
		{
			on = false;
			if (!WorldGen.InWorld(x, y, 0))
			{
				return TELogicSensor.LogicCheckType.None;
			}
			Tile tile = Main.tile[x, y];
			if (tile == null)
			{
				return TELogicSensor.LogicCheckType.None;
			}
			TELogicSensor.LogicCheckType logicCheckType = TELogicSensor.LogicCheckType.None;
			switch (tile.frameY / 18)
			{
				case 0:
					logicCheckType = TELogicSensor.LogicCheckType.Day;
					break;
				case 1:
					logicCheckType = TELogicSensor.LogicCheckType.Night;
					break;
				case 2:
					logicCheckType = TELogicSensor.LogicCheckType.PlayerAbove;
					break;
				case 3:
					logicCheckType = TELogicSensor.LogicCheckType.Water;
					break;
				case 4:
					logicCheckType = TELogicSensor.LogicCheckType.Lava;
					break;
				case 5:
					logicCheckType = TELogicSensor.LogicCheckType.Honey;
					break;
				case 6:
					logicCheckType = TELogicSensor.LogicCheckType.Liquid;
					break;
			}
			on = TELogicSensor.GetState(x, y, logicCheckType, null);
			return logicCheckType;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x003F46F4 File Offset: 0x003F28F4
		private static void FillPlayerHitboxes()
		{
			if (!TELogicSensor.playerBoxFilled)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						TELogicSensor.playerBox[i] = Main.player[i].getRect();
					}
				}
				TELogicSensor.playerBoxFilled = true;
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x003F4FC8 File Offset: 0x003F31C8
		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				return tileEntity.ID;
			}
			return -1;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x003F4C44 File Offset: 0x003F2E44
		public static void GetFrame(int x, int y, TELogicSensor.LogicCheckType type, bool on)
		{
			Main.tile[x, y].frameX = ((short)(on ? 18 : 0));
			switch (type)
			{
				case TELogicSensor.LogicCheckType.Day:
					Main.tile[x, y].frameY = 0;
					return;
				case TELogicSensor.LogicCheckType.Night:
					Main.tile[x, y].frameY = 18;
					return;
				case TELogicSensor.LogicCheckType.PlayerAbove:
					Main.tile[x, y].frameY = 36;
					return;
				case TELogicSensor.LogicCheckType.Water:
					Main.tile[x, y].frameY = 54;
					return;
				case TELogicSensor.LogicCheckType.Lava:
					Main.tile[x, y].frameY = 72;
					return;
				case TELogicSensor.LogicCheckType.Honey:
					Main.tile[x, y].frameY = 90;
					return;
				case TELogicSensor.LogicCheckType.Liquid:
					Main.tile[x, y].frameY = 108;
					return;
				default:
					Main.tile[x, y].frameY = 0;
					return;
			}
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x003F4A84 File Offset: 0x003F2C84
		public static bool GetState(int x, int y, TELogicSensor.LogicCheckType type, TELogicSensor instance = null)
		{
			switch (type)
			{
				case TELogicSensor.LogicCheckType.Day:
					return Main.dayTime;
				case TELogicSensor.LogicCheckType.Night:
					return !Main.dayTime;
				case TELogicSensor.LogicCheckType.PlayerAbove:
					{
						bool result = false;
						Rectangle value = new Rectangle(x * 16 - 32 - 1, y * 16 - 160 - 1, 82, 162);
						foreach (KeyValuePair<int, Rectangle> current in TELogicSensor.playerBox)
						{
							if (current.Value.Intersects(value))
							{
								result = true;
								break;
							}
						}
						return result;
					}
				case TELogicSensor.LogicCheckType.Water:
				case TELogicSensor.LogicCheckType.Lava:
				case TELogicSensor.LogicCheckType.Honey:
				case TELogicSensor.LogicCheckType.Liquid:
					{
						if (instance == null)
						{
							return false;
						}
						Tile tile = Main.tile[x, y];
						bool flag = true;
						if (tile == null || tile.liquid == 0)
						{
							flag = false;
						}
						if (!tile.lava() && type == TELogicSensor.LogicCheckType.Lava)
						{
							flag = false;
						}
						if (!tile.honey() && type == TELogicSensor.LogicCheckType.Honey)
						{
							flag = false;
						}
						if ((tile.honey() || tile.lava()) && type == TELogicSensor.LogicCheckType.Water)
						{
							flag = false;
						}
						if (!flag && instance.On)
						{
							if (instance.CountedData == 0)
							{
								instance.CountedData = 15;
							}
							else if (instance.CountedData > 0)
							{
								instance.CountedData--;
							}
							flag = (instance.CountedData > 0);
						}
						return flag;
					}
				default:
					return false;
			}
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x003F4DC4 File Offset: 0x003F2FC4
		public static int Hook_AfterPlacement(int x, int y, int type = 423, int style = 0, int direction = 1)
		{
			bool on;
			TELogicSensor.LogicCheckType type2 = TELogicSensor.FigureCheckType(x, y, out on);
			TELogicSensor.GetFrame(x, y, type2, on);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x, y, 1, TileChangeType.None);
				NetMessage.SendData(87, -1, -1, null, x, (float)y, 2f, 0f, 0, 0, 0);
				return -1;
			}
			int num = TELogicSensor.Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			return num;
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x003F4644 File Offset: 0x003F2844
		public static void Initialize()
		{
			TileEntity._UpdateStart += new Action(TELogicSensor.UpdateStartInternal);
			TileEntity._UpdateEnd += new Action(TELogicSensor.UpdateEndInternal);
			TileEntity._NetPlaceEntity += new Action<int, int, int>(TELogicSensor.NetPlaceEntity);
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x003F4E34 File Offset: 0x003F3034
		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 2)
			{
				Wiring.blockPlayerTeleportationForOneIteration = (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.PlayerAbove);
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.PlayerAbove && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Water && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Lava && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Honey && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				if (((TELogicSensor)tileEntity).logicCheck == TELogicSensor.LogicCheckType.Liquid && ((TELogicSensor)tileEntity).On)
				{
					Wiring.HitSwitch((int)tileEntity.Position.X, (int)tileEntity.Position.Y);
				}
				Wiring.blockPlayerTeleportationForOneIteration = false;
				if (TELogicSensor.inUpdateLoop)
				{
					TELogicSensor.markedIDsForRemoval.Add(tileEntity.ID);
					return;
				}
				TileEntity.ByPosition.Remove(new Point16(x, y));
				TileEntity.ByID.Remove(tileEntity.ID);
			}
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x003F467C File Offset: 0x003F287C
		public static void NetPlaceEntity(int x, int y, int type)
		{
			if (type != 2)
			{
				return;
			}
			if (!TELogicSensor.ValidTile(x, y))
			{
				return;
			}
			int num = TELogicSensor.Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			NetMessage.SendData(86, -1, -1, null, num, (float)x, (float)y, 0f, 0, 0, 0);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x003F4D68 File Offset: 0x003F2F68
		public static int Place(int x, int y)
		{
			TELogicSensor tELogicSensor = new TELogicSensor();
			tELogicSensor.Position = new Point16(x, y);
			tELogicSensor.ID = TileEntity.AssignNewID();
			tELogicSensor.type = 2;
			TileEntity.ByID[tELogicSensor.ID] = tELogicSensor;
			TileEntity.ByPosition[tELogicSensor.Position] = tELogicSensor;
			return tELogicSensor.ID;
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x003F5019 File Offset: 0x003F3219
		public override void ReadExtraData(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				this.logicCheck = (TELogicSensor.LogicCheckType)reader.ReadByte();
				this.On = reader.ReadBoolean();
			}
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x003F4D31 File Offset: 0x003F2F31
		public static bool SanityCheck(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 423)
			{
				TELogicSensor.Kill(x, y);
				return false;
			}
			return true;
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x003F5038 File Offset: 0x003F3238
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.Position.X,
				"x  ",
				this.Position.Y,
				"y ",
				this.logicCheck
			});
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x003F4848 File Offset: 0x003F2A48
		public override void Update()
		{
			bool state = TELogicSensor.GetState((int)this.Position.X, (int)this.Position.Y, this.logicCheck, this);
			TELogicSensor.LogicCheckType logicCheckType = this.logicCheck;
			if (logicCheckType - TELogicSensor.LogicCheckType.Day > 1)
			{
				if (logicCheckType - TELogicSensor.LogicCheckType.PlayerAbove > 4)
				{
					return;
				}
				if (this.On != state)
				{
					this.ChangeState(state, true);
				}
			}
			else
			{
				if (!this.On & state)
				{
					this.ChangeState(true, true);
				}
				if (this.On && !state)
				{
					this.ChangeState(false, false);
					return;
				}
			}
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x003F4744 File Offset: 0x003F2944
		private static void UpdateEndInternal()
		{
			TELogicSensor.inUpdateLoop = false;
			foreach (Tuple<Point16, bool> current in TELogicSensor.tripPoints)
			{
				Wiring.blockPlayerTeleportationForOneIteration = current.Item2;
				Wiring.HitSwitch((int)current.Item1.X, (int)current.Item1.Y);
			}
			Wiring.blockPlayerTeleportationForOneIteration = false;
			TELogicSensor.tripPoints.Clear();
			foreach (int current2 in TELogicSensor.markedIDsForRemoval)
			{
				TileEntity tileEntity;
				if (TileEntity.ByID.TryGetValue(current2, out tileEntity) && tileEntity.type == 2)
				{
					TileEntity.ByID.Remove(current2);
				}
				TileEntity.ByPosition.Remove(tileEntity.Position);
			}
			TELogicSensor.markedIDsForRemoval.Clear();
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x003F46CC File Offset: 0x003F28CC
		private static void UpdateStartInternal()
		{
			TELogicSensor.inUpdateLoop = true;
			TELogicSensor.markedIDsForRemoval.Clear();
			TELogicSensor.playerBox.Clear();
			TELogicSensor.playerBoxFilled = false;
			TELogicSensor.FillPlayerHitboxes();
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x003F4980 File Offset: 0x003F2B80
		public static bool ValidTile(int x, int y)
		{
			return Main.tile[x, y].active() && Main.tile[x, y].type == 423 && Main.tile[x, y].frameY % 18 == 0 && Main.tile[x, y].frameX % 18 == 0;
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x003F4FFB File Offset: 0x003F31FB
		public override void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
			if (!networkSend)
			{
				writer.Write((byte)this.logicCheck);
				writer.Write(this.On);
			}
		}

		// Token: 0x0400306C RID: 12396
		public int CountedData;

		// Token: 0x04003068 RID: 12392
		private static bool inUpdateLoop = false;

		// Token: 0x0400306A RID: 12394
		public TELogicSensor.LogicCheckType logicCheck;

		// Token: 0x04003067 RID: 12391
		private static List<int> markedIDsForRemoval = new List<int>();

		// Token: 0x0400306B RID: 12395
		public bool On;

		// Token: 0x04003065 RID: 12389
		private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();

		// Token: 0x04003069 RID: 12393
		private static bool playerBoxFilled = false;

		// Token: 0x04003066 RID: 12390
		private static List<Tuple<Point16, bool>> tripPoints = new List<Tuple<Point16, bool>>();

		// Token: 0x0200028C RID: 652
		public enum LogicCheckType
		{
			// Token: 0x04003C8E RID: 15502
			None,
			// Token: 0x04003C8F RID: 15503
			Day,
			// Token: 0x04003C90 RID: 15504
			Night,
			// Token: 0x04003C91 RID: 15505
			PlayerAbove,
			// Token: 0x04003C92 RID: 15506
			Water,
			// Token: 0x04003C93 RID: 15507
			Lava,
			// Token: 0x04003C94 RID: 15508
			Honey,
			// Token: 0x04003C95 RID: 15509
			Liquid
		}
	}
}
