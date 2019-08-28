using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
	// Token: 0x02000023 RID: 35
	public struct TileObject
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0002E828 File Offset: 0x0002CA28
		public static bool Place(TileObject toBePlaced)
		{
			TileObjectData tileData = TileObjectData.GetTileData(toBePlaced.type, toBePlaced.style, toBePlaced.alternate);
			if (tileData == null)
			{
				return false;
			}
			if (tileData.HookPlaceOverride.hook != null)
			{
				int arg;
				int arg2;
				if (tileData.HookPlaceOverride.processedCoordinates)
				{
					arg = toBePlaced.xCoord;
					arg2 = toBePlaced.yCoord;
				}
				else
				{
					arg = toBePlaced.xCoord + (int)tileData.Origin.X;
					arg2 = toBePlaced.yCoord + (int)tileData.Origin.Y;
				}
				if (tileData.HookPlaceOverride.hook(arg, arg2, toBePlaced.type, toBePlaced.style, 1) == tileData.HookPlaceOverride.badReturn)
				{
					return false;
				}
			}
			else
			{
				ushort num = (ushort)toBePlaced.type;
				int num2 = tileData.CalculatePlacementStyle(toBePlaced.style, toBePlaced.alternate, toBePlaced.random);
				int num3 = 0;
				if (tileData.StyleWrapLimit > 0)
				{
					num3 = num2 / tileData.StyleWrapLimit * tileData.StyleLineSkip;
					num2 %= tileData.StyleWrapLimit;
				}
				int num4;
				int num5;
				if (tileData.StyleHorizontal)
				{
					num4 = tileData.CoordinateFullWidth * num2;
					num5 = tileData.CoordinateFullHeight * num3;
				}
				else
				{
					num4 = tileData.CoordinateFullWidth * num3;
					num5 = tileData.CoordinateFullHeight * num2;
				}
				int num6 = toBePlaced.xCoord;
				int num7 = toBePlaced.yCoord;
				for (int i = 0; i < tileData.Width; i++)
				{
					for (int j = 0; j < tileData.Height; j++)
					{
						Tile tileSafely = Framing.GetTileSafely(num6 + i, num7 + j);
						if (tileSafely.active() && Main.tileCut[(int)tileSafely.type])
						{
							WorldGen.KillTile(num6 + i, num7 + j, false, false, false);
						}
					}
				}
				for (int k = 0; k < tileData.Width; k++)
				{
					int num8 = num4 + k * (tileData.CoordinateWidth + tileData.CoordinatePadding);
					int num9 = num5;
					for (int l = 0; l < tileData.Height; l++)
					{
						Tile tileSafely2 = Framing.GetTileSafely(num6 + k, num7 + l);
						if (!tileSafely2.active())
						{
							tileSafely2.active(true);
							tileSafely2.frameX = (short)num8;
							tileSafely2.frameY = (short)num9;
							tileSafely2.type = num;
						}
						num9 += tileData.CoordinateHeights[l] + tileData.CoordinatePadding;
					}
				}
			}
			if (tileData.FlattenAnchors)
			{
				AnchorData anchorData = tileData.AnchorBottom;
				if (anchorData.tileCount != 0 && (anchorData.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num10 = toBePlaced.xCoord + anchorData.checkStart;
					int j2 = toBePlaced.yCoord + tileData.Height;
					for (int m = 0; m < anchorData.tileCount; m++)
					{
						Tile tileSafely3 = Framing.GetTileSafely(num10 + m, j2);
						if (Main.tileSolid[(int)tileSafely3.type] && !Main.tileSolidTop[(int)tileSafely3.type] && tileSafely3.blockType() != 0)
						{
							WorldGen.SlopeTile(num10 + m, j2, 0);
						}
					}
				}
				anchorData = tileData.AnchorTop;
				if (anchorData.tileCount != 0 && (anchorData.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int num11 = toBePlaced.xCoord + anchorData.checkStart;
					int j3 = toBePlaced.yCoord - 1;
					for (int n = 0; n < anchorData.tileCount; n++)
					{
						Tile tileSafely4 = Framing.GetTileSafely(num11 + n, j3);
						if (Main.tileSolid[(int)tileSafely4.type] && !Main.tileSolidTop[(int)tileSafely4.type] && tileSafely4.blockType() != 0)
						{
							WorldGen.SlopeTile(num11 + n, j3, 0);
						}
					}
				}
				anchorData = tileData.AnchorRight;
				if (anchorData.tileCount != 0 && (anchorData.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int i2 = toBePlaced.xCoord + tileData.Width;
					int num12 = toBePlaced.yCoord + anchorData.checkStart;
					for (int num13 = 0; num13 < anchorData.tileCount; num13++)
					{
						Tile tileSafely5 = Framing.GetTileSafely(i2, num12 + num13);
						if (Main.tileSolid[(int)tileSafely5.type] && !Main.tileSolidTop[(int)tileSafely5.type] && tileSafely5.blockType() != 0)
						{
							WorldGen.SlopeTile(i2, num12 + num13, 0);
						}
					}
				}
				anchorData = tileData.AnchorLeft;
				if (anchorData.tileCount != 0 && (anchorData.type & AnchorType.SolidTile) == AnchorType.SolidTile)
				{
					int i3 = toBePlaced.xCoord - 1;
					int num14 = toBePlaced.yCoord + anchorData.checkStart;
					for (int num15 = 0; num15 < anchorData.tileCount; num15++)
					{
						Tile tileSafely6 = Framing.GetTileSafely(i3, num14 + num15);
						if (Main.tileSolid[(int)tileSafely6.type] && !Main.tileSolidTop[(int)tileSafely6.type] && tileSafely6.blockType() != 0)
						{
							WorldGen.SlopeTile(i3, num14 + num15, 0);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0002ECC8 File Offset: 0x0002CEC8
		public static bool CanPlace(int x, int y, int type, int style, int dir, out TileObject objectData, bool onlyCheck = false)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			objectData = TileObject.Empty;
			if (tileData == null)
			{
				return false;
			}
			int num = x - (int)tileData.Origin.X;
			int num2 = y - (int)tileData.Origin.Y;
			if (num < 0 || num + tileData.Width >= Main.maxTilesX || num2 < 0 || num2 + tileData.Height >= Main.maxTilesY)
			{
				return false;
			}
			bool flag = tileData.RandomStyleRange > 0;
			if (TileObjectPreviewData.placementCache == null)
			{
				TileObjectPreviewData.placementCache = new TileObjectPreviewData();
			}
			TileObjectPreviewData.placementCache.Reset();
			int arg_AF_0 = 0;
			int num3 = 0;
			if (tileData.AlternatesCount != 0)
			{
				num3 = tileData.AlternatesCount;
			}
			float num4 = -1f;
			float num5 = -1f;
			int num6 = 0;
			TileObjectData tileObjectData = null;
			int i = arg_AF_0 - 1;
			while (i < num3)
			{
				i++;
				TileObjectData tileData2 = TileObjectData.GetTileData(type, style, i);
				if (tileData2.Direction == TileObjectDirection.None || ((tileData2.Direction != TileObjectDirection.PlaceLeft || dir != 1) && (tileData2.Direction != TileObjectDirection.PlaceRight || dir != -1)))
				{
					int num7 = x - (int)tileData2.Origin.X;
					int num8 = y - (int)tileData2.Origin.Y;
					if (num7 < 5 || num7 + tileData2.Width > Main.maxTilesX - 5 || num8 < 5 || num8 + tileData2.Height > Main.maxTilesY - 5)
					{
						return false;
					}
					Rectangle rectangle = new Rectangle(0, 0, tileData2.Width, tileData2.Height);
					int num9 = 0;
					int num10 = 0;
					if (tileData2.AnchorTop.tileCount != 0)
					{
						if (rectangle.Y == 0)
						{
							rectangle.Y = -1;
							rectangle.Height++;
							num10++;
						}
						int checkStart = tileData2.AnchorTop.checkStart;
						if (checkStart < rectangle.X)
						{
							rectangle.Width += rectangle.X - checkStart;
							num9 += rectangle.X - checkStart;
							rectangle.X = checkStart;
						}
						int num11 = checkStart + tileData2.AnchorTop.tileCount - 1;
						int num12 = rectangle.X + rectangle.Width - 1;
						if (num11 > num12)
						{
							rectangle.Width += num11 - num12;
						}
					}
					if (tileData2.AnchorBottom.tileCount != 0)
					{
						if (rectangle.Y + rectangle.Height == tileData2.Height)
						{
							rectangle.Height++;
						}
						int checkStart2 = tileData2.AnchorBottom.checkStart;
						if (checkStart2 < rectangle.X)
						{
							rectangle.Width += rectangle.X - checkStart2;
							num9 += rectangle.X - checkStart2;
							rectangle.X = checkStart2;
						}
						int num13 = checkStart2 + tileData2.AnchorBottom.tileCount - 1;
						int num14 = rectangle.X + rectangle.Width - 1;
						if (num13 > num14)
						{
							rectangle.Width += num13 - num14;
						}
					}
					if (tileData2.AnchorLeft.tileCount != 0)
					{
						if (rectangle.X == 0)
						{
							rectangle.X = -1;
							rectangle.Width++;
							num9++;
						}
						int num15 = tileData2.AnchorLeft.checkStart;
						if ((tileData2.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
						{
							num15--;
						}
						if (num15 < rectangle.Y)
						{
							rectangle.Width += rectangle.Y - num15;
							num10 += rectangle.Y - num15;
							rectangle.Y = num15;
						}
						int num16 = num15 + tileData2.AnchorLeft.tileCount - 1;
						if ((tileData2.AnchorLeft.type & AnchorType.Tree) == AnchorType.Tree)
						{
							num16 += 2;
						}
						int num17 = rectangle.Y + rectangle.Height - 1;
						if (num16 > num17)
						{
							rectangle.Height += num16 - num17;
						}
					}
					if (tileData2.AnchorRight.tileCount != 0)
					{
						if (rectangle.X + rectangle.Width == tileData2.Width)
						{
							rectangle.Width++;
						}
						int num18 = tileData2.AnchorLeft.checkStart;
						if ((tileData2.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
						{
							num18--;
						}
						if (num18 < rectangle.Y)
						{
							rectangle.Width += rectangle.Y - num18;
							num10 += rectangle.Y - num18;
							rectangle.Y = num18;
						}
						int num19 = num18 + tileData2.AnchorRight.tileCount - 1;
						if ((tileData2.AnchorRight.type & AnchorType.Tree) == AnchorType.Tree)
						{
							num19 += 2;
						}
						int num20 = rectangle.Y + rectangle.Height - 1;
						if (num19 > num20)
						{
							rectangle.Height += num19 - num20;
						}
					}
					if (onlyCheck)
					{
						TileObject.objectPreview.Reset();
						TileObject.objectPreview.Active = true;
						TileObject.objectPreview.Type = (ushort)type;
						TileObject.objectPreview.Style = (short)style;
						TileObject.objectPreview.Alternate = i;
						TileObject.objectPreview.Size = new Point16(rectangle.Width, rectangle.Height);
						TileObject.objectPreview.ObjectStart = new Point16(num9, num10);
						TileObject.objectPreview.Coordinates = new Point16(num7 - num9, num8 - num10);
					}
					float num21 = 0f;
					float num22 = (float)(tileData2.Width * tileData2.Height);
					float num23 = 0f;
					float num24 = 0f;
					for (int j = 0; j < tileData2.Width; j++)
					{
						for (int k = 0; k < tileData2.Height; k++)
						{
							Tile tileSafely = Framing.GetTileSafely(num7 + j, num8 + k);
							bool flag2 = !tileData2.LiquidPlace(tileSafely);
							bool flag3 = false;
							if (tileData2.AnchorWall)
							{
								num24 += 1f;
								if (!tileData2.isValidWallAnchor((int)tileSafely.wall))
								{
									flag3 = true;
								}
								else
								{
									num23 += 1f;
								}
							}
							bool flag4 = false;
							if (tileSafely.active() && !Main.tileCut[(int)tileSafely.type])
							{
								flag4 = true;
							}
							if (flag4 | flag2 | flag3)
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[j + num9, k + num10] = 2;
								}
							}
							else
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[j + num9, k + num10] = 1;
								}
								num21 += 1f;
							}
						}
					}
					AnchorData anchorData = tileData2.AnchorBottom;
					if (anchorData.tileCount != 0)
					{
						num24 += (float)anchorData.tileCount;
						int height = tileData2.Height;
						for (int l = 0; l < anchorData.tileCount; l++)
						{
							int num25 = anchorData.checkStart + l;
							Tile tileSafely = Framing.GetTileSafely(num7 + num25, num8 + height);
							bool flag5 = false;
							if (tileSafely.nactive())
							{
								if ((anchorData.type & AnchorType.SolidTile) == AnchorType.SolidTile && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type] && !Main.tileNoAttach[(int)tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
								{
									flag5 = tileData2.isValidTileAnchor((int)tileSafely.type);
								}
								if (!flag5 && ((anchorData.type & AnchorType.SolidWithTop) == AnchorType.SolidWithTop || (anchorData.type & AnchorType.Table) == AnchorType.Table))
								{
									if (TileID.Sets.Platforms[(int)tileSafely.type])
									{
										int num26 = (int)tileSafely.frameX / TileObjectData.PlatformFrameWidth();
										if ((!tileSafely.halfBrick() && num26 >= 0 && num26 <= 7) || (num26 >= 12 && num26 <= 16) || (num26 >= 25 && num26 <= 26))
										{
											flag5 = true;
										}
									}
									else if (Main.tileSolid[(int)tileSafely.type] && Main.tileSolidTop[(int)tileSafely.type])
									{
										flag5 = true;
									}
								}
								if (!flag5 && (anchorData.type & AnchorType.Table) == AnchorType.Table && !TileID.Sets.Platforms[(int)tileSafely.type] && Main.tileTable[(int)tileSafely.type] && tileSafely.blockType() == 0)
								{
									flag5 = true;
								}
								if (!flag5 && (anchorData.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type])
								{
									int num27 = tileSafely.blockType();
									if (num27 - 4 <= 1)
									{
										flag5 = tileData2.isValidTileAnchor((int)tileSafely.type);
									}
								}
								if (!flag5 && (anchorData.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int)tileSafely.type))
								{
									flag5 = true;
								}
							}
							else if (!flag5 && (anchorData.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
							{
								flag5 = true;
							}
							if (!flag5)
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num25 + num9, height + num10] = 2;
								}
							}
							else
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num25 + num9, height + num10] = 1;
								}
								num23 += 1f;
							}
						}
					}
					anchorData = tileData2.AnchorTop;
					if (anchorData.tileCount != 0)
					{
						num24 += (float)anchorData.tileCount;
						int num28 = -1;
						for (int m = 0; m < anchorData.tileCount; m++)
						{
							int num29 = anchorData.checkStart + m;
							Tile tileSafely = Framing.GetTileSafely(num7 + num29, num8 + num28);
							bool flag6 = false;
							if (tileSafely.nactive())
							{
								if (Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type] && !Main.tileNoAttach[(int)tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
								{
									flag6 = tileData2.isValidTileAnchor((int)tileSafely.type);
								}
								if (!flag6 && (anchorData.type & AnchorType.SolidBottom) == AnchorType.SolidBottom && ((Main.tileSolid[(int)tileSafely.type] && (!Main.tileSolidTop[(int)tileSafely.type] || (TileID.Sets.Platforms[(int)tileSafely.type] && (tileSafely.halfBrick() || tileSafely.topSlope())))) || tileSafely.halfBrick() || tileSafely.topSlope()) && !TileID.Sets.NotReallySolid[(int)tileSafely.type] && !tileSafely.bottomSlope())
								{
									flag6 = tileData2.isValidTileAnchor((int)tileSafely.type);
								}
								if (!flag6 && (anchorData.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type])
								{
									int num27 = tileSafely.blockType();
									if (num27 - 2 <= 1)
									{
										flag6 = tileData2.isValidTileAnchor((int)tileSafely.type);
									}
								}
								if (!flag6 && (anchorData.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int)tileSafely.type))
								{
									flag6 = true;
								}
							}
							else if (!flag6 && (anchorData.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
							{
								flag6 = true;
							}
							if (!flag6)
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num29 + num9, num28 + num10] = 2;
								}
							}
							else
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num29 + num9, num28 + num10] = 1;
								}
								num23 += 1f;
							}
						}
					}
					anchorData = tileData2.AnchorRight;
					if (anchorData.tileCount != 0)
					{
						num24 += (float)anchorData.tileCount;
						int width = tileData2.Width;
						for (int n = 0; n < anchorData.tileCount; n++)
						{
							int num30 = anchorData.checkStart + n;
							Tile tileSafely = Framing.GetTileSafely(num7 + width, num8 + num30);
							bool flag7 = false;
							if (tileSafely.nactive())
							{
								if (Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type] && !Main.tileNoAttach[(int)tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
								{
									flag7 = tileData2.isValidTileAnchor((int)tileSafely.type);
								}
								if (!flag7 && (anchorData.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type])
								{
									int num27 = tileSafely.blockType();
									if (num27 == 2 || num27 == 4)
									{
										flag7 = tileData2.isValidTileAnchor((int)tileSafely.type);
									}
								}
								if (!flag7 && (anchorData.type & AnchorType.Tree) == AnchorType.Tree && tileSafely.type == 5)
								{
									flag7 = true;
									if (n == 0)
									{
										num24 += 1f;
										Tile tileSafely2 = Framing.GetTileSafely(num7 + width, num8 + num30 - 1);
										if (tileSafely2.nactive() && tileSafely2.type == 5)
										{
											num23 += 1f;
											if (onlyCheck)
											{
												TileObject.objectPreview[width + num9, num30 + num10 - 1] = 1;
											}
										}
										else if (onlyCheck)
										{
											TileObject.objectPreview[width + num9, num30 + num10 - 1] = 2;
										}
									}
									if (n == anchorData.tileCount - 1)
									{
										num24 += 1f;
										Tile tileSafely3 = Framing.GetTileSafely(num7 + width, num8 + num30 + 1);
										if (tileSafely3.nactive() && tileSafely3.type == 5)
										{
											num23 += 1f;
											if (onlyCheck)
											{
												TileObject.objectPreview[width + num9, num30 + num10 + 1] = 1;
											}
										}
										else if (onlyCheck)
										{
											TileObject.objectPreview[width + num9, num30 + num10 + 1] = 2;
										}
									}
								}
								if (!flag7 && (anchorData.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int)tileSafely.type))
								{
									flag7 = true;
								}
							}
							else if (!flag7 && (anchorData.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
							{
								flag7 = true;
							}
							if (!flag7)
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[width + num9, num30 + num10] = 2;
								}
							}
							else
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[width + num9, num30 + num10] = 1;
								}
								num23 += 1f;
							}
						}
					}
					anchorData = tileData2.AnchorLeft;
					if (anchorData.tileCount != 0)
					{
						num24 += (float)anchorData.tileCount;
						int num31 = -1;
						for (int num32 = 0; num32 < anchorData.tileCount; num32++)
						{
							int num33 = anchorData.checkStart + num32;
							Tile tileSafely = Framing.GetTileSafely(num7 + num31, num8 + num33);
							bool flag8 = false;
							if (tileSafely.nactive())
							{
								if (Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type] && !Main.tileNoAttach[(int)tileSafely.type] && (tileData2.FlattenAnchors || tileSafely.blockType() == 0))
								{
									flag8 = tileData2.isValidTileAnchor((int)tileSafely.type);
								}
								if (!flag8 && (anchorData.type & AnchorType.SolidSide) == AnchorType.SolidSide && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type])
								{
									int num27 = tileSafely.blockType();
									if (num27 == 3 || num27 == 5)
									{
										flag8 = tileData2.isValidTileAnchor((int)tileSafely.type);
									}
								}
								if (!flag8 && (anchorData.type & AnchorType.Tree) == AnchorType.Tree && tileSafely.type == 5)
								{
									flag8 = true;
									if (num32 == 0)
									{
										num24 += 1f;
										Tile tileSafely4 = Framing.GetTileSafely(num7 + num31, num8 + num33 - 1);
										if (tileSafely4.nactive() && tileSafely4.type == 5)
										{
											num23 += 1f;
											if (onlyCheck)
											{
												TileObject.objectPreview[num31 + num9, num33 + num10 - 1] = 1;
											}
										}
										else if (onlyCheck)
										{
											TileObject.objectPreview[num31 + num9, num33 + num10 - 1] = 2;
										}
									}
									if (num32 == anchorData.tileCount - 1)
									{
										num24 += 1f;
										Tile tileSafely5 = Framing.GetTileSafely(num7 + num31, num8 + num33 + 1);
										if (tileSafely5.nactive() && tileSafely5.type == 5)
										{
											num23 += 1f;
											if (onlyCheck)
											{
												TileObject.objectPreview[num31 + num9, num33 + num10 + 1] = 1;
											}
										}
										else if (onlyCheck)
										{
											TileObject.objectPreview[num31 + num9, num33 + num10 + 1] = 2;
										}
									}
								}
								if (!flag8 && (anchorData.type & AnchorType.AlternateTile) == AnchorType.AlternateTile && tileData2.isValidAlternateAnchor((int)tileSafely.type))
								{
									flag8 = true;
								}
							}
							else if (!flag8 && (anchorData.type & AnchorType.EmptyTile) == AnchorType.EmptyTile)
							{
								flag8 = true;
							}
							if (!flag8)
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num31 + num9, num33 + num10] = 2;
								}
							}
							else
							{
								if (onlyCheck)
								{
									TileObject.objectPreview[num31 + num9, num33 + num10] = 1;
								}
								num23 += 1f;
							}
						}
					}
					if (tileData2.HookCheck.hook != null)
					{
						if (tileData2.HookCheck.processedCoordinates)
						{
							Point16 arg_103B_0 = tileData2.Origin;
							Point16 arg_1043_0 = tileData2.Origin;
						}
						if (tileData2.HookCheck.hook(x, y, type, style, dir) == tileData2.HookCheck.badReturn && tileData2.HookCheck.badResponse == 0)
						{
							num23 = 0f;
							num21 = 0f;
							TileObject.objectPreview.AllInvalid();
						}
					}
					float num34 = num23 / num24;
					float num35 = num21 / num22;
					if (num35 == 1f && num24 == 0f)
					{
						num34 = 1f;
						num35 = 1f;
					}
					if (num34 == 1f && num35 == 1f)
					{
						num4 = 1f;
						num5 = 1f;
						num6 = i;
						tileObjectData = tileData2;
						break;
					}
					if (num34 > num4 || (num34 == num4 && num35 > num5))
					{
						TileObjectPreviewData.placementCache.CopyFrom(TileObject.objectPreview);
						num4 = num34;
						num5 = num35;
						tileObjectData = tileData2;
						num6 = i;
					}
				}
			}
			int num36 = -1;
			if (flag)
			{
				if (TileObjectPreviewData.randomCache == null)
				{
					TileObjectPreviewData.randomCache = new TileObjectPreviewData();
				}
				bool flag9 = false;
				if ((int)TileObjectPreviewData.randomCache.Type == type)
				{
					Point16 arg_116E_0 = TileObjectPreviewData.randomCache.Coordinates;
					Point16 objectStart = TileObjectPreviewData.randomCache.ObjectStart;
					int num37 = (int)(arg_116E_0.X + objectStart.X);
					int num38 = (int)(arg_116E_0.Y + objectStart.Y);
					int num39 = x - (int)tileData.Origin.X;
					int num40 = y - (int)tileData.Origin.Y;
					if (num37 != num39 || num38 != num40)
					{
						flag9 = true;
					}
				}
				else
				{
					flag9 = true;
				}
				if (flag9)
				{
					num36 = Main.rand.Next(tileData.RandomStyleRange);
				}
				else
				{
					num36 = TileObjectPreviewData.randomCache.Random;
				}
			}
			if (onlyCheck)
			{
				if (num4 != 1f || num5 != 1f)
				{
					TileObject.objectPreview.CopyFrom(TileObjectPreviewData.placementCache);
					i = num6;
				}
				TileObject.objectPreview.Random = num36;
				if (tileData.RandomStyleRange > 0)
				{
					TileObjectPreviewData.randomCache.CopyFrom(TileObject.objectPreview);
				}
			}
			if (!onlyCheck)
			{
				objectData.xCoord = x - (int)tileObjectData.Origin.X;
				objectData.yCoord = y - (int)tileObjectData.Origin.Y;
				objectData.type = type;
				objectData.style = style;
				objectData.alternate = i;
				objectData.random = num36;
			}
			return num4 == 1f && num5 == 1f;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0002FF68 File Offset: 0x0002E168
		public static void DrawPreview(SpriteBatch sb, TileObjectPreviewData op, Vector2 position)
		{
			Point16 coordinates = op.Coordinates;
			Texture2D texture = Main.tileTexture[(int)op.Type];
			TileObjectData tileData = TileObjectData.GetTileData((int)op.Type, (int)op.Style, op.Alternate);
			int num = tileData.CalculatePlacementStyle((int)op.Style, op.Alternate, op.Random);
			int num2 = 0;
			int num3 = tileData.DrawYOffset;
			if (tileData.StyleWrapLimit > 0)
			{
				num2 = num / tileData.StyleWrapLimit * tileData.StyleLineSkip;
				num %= tileData.StyleWrapLimit;
			}
			int num4;
			int num5;
			if (tileData.StyleHorizontal)
			{
				num4 = tileData.CoordinateFullWidth * num;
				num5 = tileData.CoordinateFullHeight * num2;
			}
			else
			{
				num4 = tileData.CoordinateFullWidth * num2;
				num5 = tileData.CoordinateFullHeight * num;
			}
			for (int i = 0; i < (int)op.Size.X; i++)
			{
				int x = num4 + (i - (int)op.ObjectStart.X) * (tileData.CoordinateWidth + tileData.CoordinatePadding);
				int num6 = num5;
				int j = 0;
				while (j < (int)op.Size.Y)
				{
					int num7 = (int)coordinates.X + i;
					int num8 = (int)coordinates.Y + j;
					if (j == 0 && tileData.DrawStepDown != 0 && WorldGen.SolidTile(Framing.GetTileSafely(num7, num8 - 1)))
					{
						num3 += tileData.DrawStepDown;
					}
					int num9 = op[i, j];
					Color color;
					if (num9 == 1)
					{
						color = Color.White;
						goto IL_156;
					}
					if (num9 == 2)
					{
						color = Color.Red * 0.7f;
						goto IL_156;
					}
					IL_289:
					j++;
					continue;
					IL_156:
					color *= 0.5f;
					if (i >= (int)op.ObjectStart.X && i < (int)op.ObjectStart.X + tileData.Width && j >= (int)op.ObjectStart.Y && j < (int)op.ObjectStart.Y + tileData.Height)
					{
						SpriteEffects spriteEffects = SpriteEffects.None;
						if (tileData.DrawFlipHorizontal && i % 2 == 1)
						{
							spriteEffects |= SpriteEffects.FlipHorizontally;
						}
						if (tileData.DrawFlipVertical && j % 2 == 1)
						{
							spriteEffects |= SpriteEffects.FlipVertically;
						}
						Rectangle value = new Rectangle(x, num6, tileData.CoordinateWidth, tileData.CoordinateHeights[j - (int)op.ObjectStart.Y]);
						sb.Draw(texture, new Vector2((float)(num7 * 16 - (int)(position.X + (float)(tileData.CoordinateWidth - 16) / 2f)), (float)(num8 * 16 - (int)position.Y + num3)), new Rectangle?(value), color, 0f, Vector2.Zero, 1f, spriteEffects, 0f);
						num6 += tileData.CoordinateHeights[j - (int)op.ObjectStart.Y] + tileData.CoordinatePadding;
						goto IL_289;
					}
					goto IL_289;
				}
			}
		}

		// Token: 0x040001A7 RID: 423
		public int xCoord;

		// Token: 0x040001A8 RID: 424
		public int yCoord;

		// Token: 0x040001A9 RID: 425
		public int type;

		// Token: 0x040001AA RID: 426
		public int style;

		// Token: 0x040001AB RID: 427
		public int alternate;

		// Token: 0x040001AC RID: 428
		public int random;

		// Token: 0x040001AD RID: 429
		public static TileObject Empty = default(TileObject);

		// Token: 0x040001AE RID: 430
		public static TileObjectPreviewData objectPreview = new TileObjectPreviewData();
	}
}
