using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Tile_Entities;
using Terraria.Modules;

namespace Terraria.ObjectData
{
	// Token: 0x0200003B RID: 59
	public class TileObjectData
	{
		// Token: 0x06000883 RID: 2179 RVA: 0x003AD698 File Offset: 0x003AB898
		public TileObjectData(TileObjectData copyFrom = null)
		{
			this._parent = null;
			this._linkedAlternates = false;
			if (copyFrom == null)
			{
				this._usesCustomCanPlace = false;
				this._alternates = null;
				this._anchor = null;
				this._anchorTiles = null;
				this._tileObjectBase = null;
				this._liquidDeath = null;
				this._liquidPlacement = null;
				this._placementHooks = null;
				this._tileObjectDraw = null;
				this._tileObjectStyle = null;
				this._tileObjectCoords = null;
				return;
			}
			this.CopyFrom(copyFrom);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x003AD714 File Offset: 0x003AB914
		public void CopyFrom(TileObjectData copy)
		{
			if (copy == null)
			{
				return;
			}
			this._usesCustomCanPlace = copy._usesCustomCanPlace;
			this._alternates = copy._alternates;
			this._anchor = copy._anchor;
			this._anchorTiles = copy._anchorTiles;
			this._tileObjectBase = copy._tileObjectBase;
			this._liquidDeath = copy._liquidDeath;
			this._liquidPlacement = copy._liquidPlacement;
			this._placementHooks = copy._placementHooks;
			this._tileObjectDraw = copy._tileObjectDraw;
			this._tileObjectStyle = copy._tileObjectStyle;
			this._tileObjectCoords = copy._tileObjectCoords;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x003AD7AC File Offset: 0x003AB9AC
		public void FullCopyFrom(ushort tileType)
		{
			this.FullCopyFrom(TileObjectData.GetTileData((int)tileType, 0, 0));
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x003AD7BC File Offset: 0x003AB9BC
		public void FullCopyFrom(TileObjectData copy)
		{
			if (copy == null)
			{
				return;
			}
			this._usesCustomCanPlace = copy._usesCustomCanPlace;
			this._alternates = copy._alternates;
			this._anchor = copy._anchor;
			this._anchorTiles = copy._anchorTiles;
			this._tileObjectBase = copy._tileObjectBase;
			this._liquidDeath = copy._liquidDeath;
			this._liquidPlacement = copy._liquidPlacement;
			this._placementHooks = copy._placementHooks;
			this._tileObjectDraw = copy._tileObjectDraw;
			this._tileObjectStyle = copy._tileObjectStyle;
			this._tileObjectCoords = copy._tileObjectCoords;
			this._subTiles = new TileObjectSubTilesModule(copy._subTiles, null);
			this._hasOwnSubTiles = true;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x003AD86C File Offset: 0x003ABA6C
		private void SetupBaseObject()
		{
			this._alternates = new TileObjectAlternatesModule(null);
			this._hasOwnAlternates = true;
			this.Alternates = new List<TileObjectData>();
			this._anchor = new AnchorDataModule(null);
			this._hasOwnAnchor = true;
			this.AnchorTop = default(AnchorData);
			this.AnchorBottom = default(AnchorData);
			this.AnchorLeft = default(AnchorData);
			this.AnchorRight = default(AnchorData);
			this.AnchorWall = false;
			this._anchorTiles = new AnchorTypesModule(null);
			this._hasOwnAnchorTiles = true;
			this.AnchorValidTiles = null;
			this.AnchorInvalidTiles = null;
			this.AnchorAlternateTiles = null;
			this.AnchorValidWalls = null;
			this._liquidDeath = new LiquidDeathModule(null);
			this._hasOwnLiquidDeath = true;
			this.WaterDeath = false;
			this.LavaDeath = false;
			this._liquidPlacement = new LiquidPlacementModule(null);
			this._hasOwnLiquidPlacement = true;
			this.WaterPlacement = LiquidPlacement.Allowed;
			this.LavaPlacement = LiquidPlacement.NotAllowed;
			this._placementHooks = new TilePlacementHooksModule(null);
			this._hasOwnPlacementHooks = true;
			this.HookCheck = default(PlacementHook);
			this.HookPostPlaceEveryone = default(PlacementHook);
			this.HookPostPlaceMyPlayer = default(PlacementHook);
			this.HookPlaceOverride = default(PlacementHook);
			this.SubTiles = new List<TileObjectData>(470);
			this._tileObjectBase = new TileObjectBaseModule(null);
			this._hasOwnTileObjectBase = true;
			this.Width = 1;
			this.Height = 1;
			this.Origin = Point16.Zero;
			this.Direction = TileObjectDirection.None;
			this.RandomStyleRange = 0;
			this.FlattenAnchors = false;
			this._tileObjectCoords = new TileObjectCoordinatesModule(null, null);
			this._hasOwnTileObjectCoords = true;
			this.CoordinateHeights = new int[]
			{
				16
			};
			this.CoordinateWidth = 0;
			this.CoordinatePadding = 0;
			this.CoordinatePaddingFix = Point16.Zero;
			this._tileObjectDraw = new TileObjectDrawModule(null);
			this._hasOwnTileObjectDraw = true;
			this.DrawYOffset = 0;
			this.DrawFlipHorizontal = false;
			this.DrawFlipVertical = false;
			this.DrawStepDown = 0;
			this._tileObjectStyle = new TileObjectStyleModule(null);
			this._hasOwnTileObjectStyle = true;
			this.Style = 0;
			this.StyleHorizontal = false;
			this.StyleWrapLimit = 0;
			this.StyleMultiplier = 1;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x003ADA9C File Offset: 0x003ABC9C
		private void Calculate()
		{
			if (this._tileObjectCoords.calculated)
			{
				return;
			}
			this._tileObjectCoords.calculated = true;
			this._tileObjectCoords.styleWidth = (this._tileObjectCoords.width + this._tileObjectCoords.padding) * this.Width + (int)this._tileObjectCoords.paddingFix.X;
			int num = 0;
			this._tileObjectCoords.styleHeight = 0;
			for (int i = 0; i < this._tileObjectCoords.heights.Length; i++)
			{
				num += this._tileObjectCoords.heights[i] + this._tileObjectCoords.padding;
			}
			num += (int)this._tileObjectCoords.paddingFix.Y;
			this._tileObjectCoords.styleHeight = num;
			if (this._hasOwnLiquidDeath)
			{
				if (this._liquidDeath.lava)
				{
					this.LavaPlacement = LiquidPlacement.NotAllowed;
				}
				if (this._liquidDeath.water)
				{
					this.WaterPlacement = LiquidPlacement.NotAllowed;
				}
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x003ADB90 File Offset: 0x003ABD90
		private void WriteCheck()
		{
			if (TileObjectData.readOnlyData)
			{
				throw new FieldAccessException("Tile data is locked and only accessible during startup.");
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x003ADBA4 File Offset: 0x003ABDA4
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x003ADBAC File Offset: 0x003ABDAC
		private bool LinkedAlternates
		{
			get
			{
				return this._linkedAlternates;
			}
			set
			{
				this.WriteCheck();
				if (value && !this._hasOwnAlternates)
				{
					this._hasOwnAlternates = true;
					this._alternates = new TileObjectAlternatesModule(this._alternates);
				}
				this._linkedAlternates = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x003ADBE0 File Offset: 0x003ABDE0
		// (set) Token: 0x0600088D RID: 2189 RVA: 0x003ADBE8 File Offset: 0x003ABDE8
		public bool UsesCustomCanPlace
		{
			get
			{
				return this._usesCustomCanPlace;
			}
			set
			{
				this.WriteCheck();
				this._usesCustomCanPlace = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x003ADBF8 File Offset: 0x003ABDF8
		// (set) Token: 0x0600088F RID: 2191 RVA: 0x003ADC18 File Offset: 0x003ABE18
		private List<TileObjectData> Alternates
		{
			get
			{
				if (this._alternates == null)
				{
					return TileObjectData._baseObject.Alternates;
				}
				return this._alternates.data;
			}
			set
			{
				if (!this._hasOwnAlternates)
				{
					this._hasOwnAlternates = true;
					this._alternates = new TileObjectAlternatesModule(this._alternates);
				}
				this._alternates.data = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x003ADC48 File Offset: 0x003ABE48
		// (set) Token: 0x06000891 RID: 2193 RVA: 0x003ADC68 File Offset: 0x003ABE68
		public AnchorData AnchorTop
		{
			get
			{
				if (this._anchor == null)
				{
					return TileObjectData._baseObject.AnchorTop;
				}
				return this._anchor.top;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchor)
				{
					if (this._anchor.top == value)
					{
						return;
					}
					this._hasOwnAnchor = true;
					this._anchor = new AnchorDataModule(this._anchor);
				}
				this._anchor.top = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].AnchorTop = value;
					}
				}
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x003ADCF8 File Offset: 0x003ABEF8
		// (set) Token: 0x06000893 RID: 2195 RVA: 0x003ADD18 File Offset: 0x003ABF18
		public AnchorData AnchorBottom
		{
			get
			{
				if (this._anchor == null)
				{
					return TileObjectData._baseObject.AnchorBottom;
				}
				return this._anchor.bottom;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchor)
				{
					if (this._anchor.bottom == value)
					{
						return;
					}
					this._hasOwnAnchor = true;
					this._anchor = new AnchorDataModule(this._anchor);
				}
				this._anchor.bottom = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].AnchorBottom = value;
					}
				}
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x003ADDA8 File Offset: 0x003ABFA8
		// (set) Token: 0x06000895 RID: 2197 RVA: 0x003ADDC8 File Offset: 0x003ABFC8
		public AnchorData AnchorLeft
		{
			get
			{
				if (this._anchor == null)
				{
					return TileObjectData._baseObject.AnchorLeft;
				}
				return this._anchor.left;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchor)
				{
					if (this._anchor.left == value)
					{
						return;
					}
					this._hasOwnAnchor = true;
					this._anchor = new AnchorDataModule(this._anchor);
				}
				this._anchor.left = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].AnchorLeft = value;
					}
				}
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x003ADE58 File Offset: 0x003AC058
		// (set) Token: 0x06000897 RID: 2199 RVA: 0x003ADE78 File Offset: 0x003AC078
		public AnchorData AnchorRight
		{
			get
			{
				if (this._anchor == null)
				{
					return TileObjectData._baseObject.AnchorRight;
				}
				return this._anchor.right;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchor)
				{
					if (this._anchor.right == value)
					{
						return;
					}
					this._hasOwnAnchor = true;
					this._anchor = new AnchorDataModule(this._anchor);
				}
				this._anchor.right = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].AnchorRight = value;
					}
				}
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x003ADF08 File Offset: 0x003AC108
		// (set) Token: 0x06000899 RID: 2201 RVA: 0x003ADF28 File Offset: 0x003AC128
		public bool AnchorWall
		{
			get
			{
				if (this._anchor == null)
				{
					return TileObjectData._baseObject.AnchorWall;
				}
				return this._anchor.wall;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchor)
				{
					if (this._anchor.wall == value)
					{
						return;
					}
					this._hasOwnAnchor = true;
					this._anchor = new AnchorDataModule(this._anchor);
				}
				this._anchor.wall = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].AnchorWall = value;
					}
				}
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x003ADFB0 File Offset: 0x003AC1B0
		// (set) Token: 0x0600089B RID: 2203 RVA: 0x003ADFD0 File Offset: 0x003AC1D0
		public int[] AnchorValidTiles
		{
			get
			{
				if (this._anchorTiles == null)
				{
					return TileObjectData._baseObject.AnchorValidTiles;
				}
				return this._anchorTiles.tileValid;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchorTiles)
				{
					if (value.deepCompare(this._anchorTiles.tileValid))
					{
						return;
					}
					this._hasOwnAnchorTiles = true;
					this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
				}
				this._anchorTiles.tileValid = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						int[] anchorValidTiles = value;
						if (value != null)
						{
							anchorValidTiles = (int[])value.Clone();
						}
						this._alternates.data[i].AnchorValidTiles = anchorValidTiles;
					}
				}
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x003AE070 File Offset: 0x003AC270
		// (set) Token: 0x0600089D RID: 2205 RVA: 0x003AE090 File Offset: 0x003AC290
		public int[] AnchorInvalidTiles
		{
			get
			{
				if (this._anchorTiles == null)
				{
					return TileObjectData._baseObject.AnchorInvalidTiles;
				}
				return this._anchorTiles.tileInvalid;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchorTiles)
				{
					if (value.deepCompare(this._anchorTiles.tileInvalid))
					{
						return;
					}
					this._hasOwnAnchorTiles = true;
					this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
				}
				this._anchorTiles.tileInvalid = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						int[] anchorInvalidTiles = value;
						if (value != null)
						{
							anchorInvalidTiles = (int[])value.Clone();
						}
						this._alternates.data[i].AnchorInvalidTiles = anchorInvalidTiles;
					}
				}
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x003AE130 File Offset: 0x003AC330
		// (set) Token: 0x0600089F RID: 2207 RVA: 0x003AE150 File Offset: 0x003AC350
		public int[] AnchorAlternateTiles
		{
			get
			{
				if (this._anchorTiles == null)
				{
					return TileObjectData._baseObject.AnchorAlternateTiles;
				}
				return this._anchorTiles.tileAlternates;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchorTiles)
				{
					if (value.deepCompare(this._anchorTiles.tileInvalid))
					{
						return;
					}
					this._hasOwnAnchorTiles = true;
					this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
				}
				this._anchorTiles.tileAlternates = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						int[] anchorAlternateTiles = value;
						if (value != null)
						{
							anchorAlternateTiles = (int[])value.Clone();
						}
						this._alternates.data[i].AnchorAlternateTiles = anchorAlternateTiles;
					}
				}
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x003AE1F0 File Offset: 0x003AC3F0
		// (set) Token: 0x060008A1 RID: 2209 RVA: 0x003AE210 File Offset: 0x003AC410
		public int[] AnchorValidWalls
		{
			get
			{
				if (this._anchorTiles == null)
				{
					return TileObjectData._baseObject.AnchorValidWalls;
				}
				return this._anchorTiles.wallValid;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnAnchorTiles)
				{
					this._hasOwnAnchorTiles = true;
					this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
				}
				this._anchorTiles.wallValid = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						int[] anchorValidWalls = value;
						if (value != null)
						{
							anchorValidWalls = (int[])value.Clone();
						}
						this._alternates.data[i].AnchorValidWalls = anchorValidWalls;
					}
				}
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x003AE29C File Offset: 0x003AC49C
		// (set) Token: 0x060008A3 RID: 2211 RVA: 0x003AE2BC File Offset: 0x003AC4BC
		public bool WaterDeath
		{
			get
			{
				if (this._liquidDeath == null)
				{
					return TileObjectData._baseObject.WaterDeath;
				}
				return this._liquidDeath.water;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnLiquidDeath)
				{
					if (this._liquidDeath.water == value)
					{
						return;
					}
					this._hasOwnLiquidDeath = true;
					this._liquidDeath = new LiquidDeathModule(this._liquidDeath);
				}
				this._liquidDeath.water = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].WaterDeath = value;
					}
				}
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x003AE344 File Offset: 0x003AC544
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x003AE364 File Offset: 0x003AC564
		public bool LavaDeath
		{
			get
			{
				if (this._liquidDeath == null)
				{
					return TileObjectData._baseObject.LavaDeath;
				}
				return this._liquidDeath.lava;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnLiquidDeath)
				{
					if (this._liquidDeath.lava == value)
					{
						return;
					}
					this._hasOwnLiquidDeath = true;
					this._liquidDeath = new LiquidDeathModule(this._liquidDeath);
				}
				this._liquidDeath.lava = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].LavaDeath = value;
					}
				}
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x003AE3EC File Offset: 0x003AC5EC
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x003AE40C File Offset: 0x003AC60C
		public LiquidPlacement WaterPlacement
		{
			get
			{
				if (this._liquidPlacement == null)
				{
					return TileObjectData._baseObject.WaterPlacement;
				}
				return this._liquidPlacement.water;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnLiquidPlacement)
				{
					if (this._liquidPlacement.water == value)
					{
						return;
					}
					this._hasOwnLiquidPlacement = true;
					this._liquidPlacement = new LiquidPlacementModule(this._liquidPlacement);
				}
				this._liquidPlacement.water = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].WaterPlacement = value;
					}
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x003AE494 File Offset: 0x003AC694
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x003AE4B4 File Offset: 0x003AC6B4
		public LiquidPlacement LavaPlacement
		{
			get
			{
				if (this._liquidPlacement == null)
				{
					return TileObjectData._baseObject.LavaPlacement;
				}
				return this._liquidPlacement.lava;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnLiquidPlacement)
				{
					if (this._liquidPlacement.lava == value)
					{
						return;
					}
					this._hasOwnLiquidPlacement = true;
					this._liquidPlacement = new LiquidPlacementModule(this._liquidPlacement);
				}
				this._liquidPlacement.lava = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].LavaPlacement = value;
					}
				}
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x003AE53C File Offset: 0x003AC73C
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x003AE55C File Offset: 0x003AC75C
		public PlacementHook HookCheck
		{
			get
			{
				if (this._placementHooks == null)
				{
					return TileObjectData._baseObject.HookCheck;
				}
				return this._placementHooks.check;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnPlacementHooks)
				{
					this._hasOwnPlacementHooks = true;
					this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
				}
				this._placementHooks.check = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x003AE590 File Offset: 0x003AC790
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x003AE5B0 File Offset: 0x003AC7B0
		public PlacementHook HookPostPlaceEveryone
		{
			get
			{
				if (this._placementHooks == null)
				{
					return TileObjectData._baseObject.HookPostPlaceEveryone;
				}
				return this._placementHooks.postPlaceEveryone;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnPlacementHooks)
				{
					this._hasOwnPlacementHooks = true;
					this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
				}
				this._placementHooks.postPlaceEveryone = value;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x003AE5E4 File Offset: 0x003AC7E4
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x003AE604 File Offset: 0x003AC804
		public PlacementHook HookPostPlaceMyPlayer
		{
			get
			{
				if (this._placementHooks == null)
				{
					return TileObjectData._baseObject.HookPostPlaceMyPlayer;
				}
				return this._placementHooks.postPlaceMyPlayer;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnPlacementHooks)
				{
					this._hasOwnPlacementHooks = true;
					this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
				}
				this._placementHooks.postPlaceMyPlayer = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x003AE638 File Offset: 0x003AC838
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x003AE658 File Offset: 0x003AC858
		public PlacementHook HookPlaceOverride
		{
			get
			{
				if (this._placementHooks == null)
				{
					return TileObjectData._baseObject.HookPlaceOverride;
				}
				return this._placementHooks.placeOverride;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnPlacementHooks)
				{
					this._hasOwnPlacementHooks = true;
					this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
				}
				this._placementHooks.placeOverride = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x003AE68C File Offset: 0x003AC88C
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x003AE6AC File Offset: 0x003AC8AC
		private List<TileObjectData> SubTiles
		{
			get
			{
				if (this._subTiles == null)
				{
					return TileObjectData._baseObject.SubTiles;
				}
				return this._subTiles.data;
			}
			set
			{
				if (!this._hasOwnSubTiles)
				{
					this._hasOwnSubTiles = true;
					this._subTiles = new TileObjectSubTilesModule(null, null);
				}
				if (value == null)
				{
					this._subTiles.data = null;
					return;
				}
				this._subTiles.data = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x003AE6E8 File Offset: 0x003AC8E8
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x003AE704 File Offset: 0x003AC904
		public int DrawYOffset
		{
			get
			{
				if (this._tileObjectDraw == null)
				{
					return this.DrawYOffset;
				}
				return this._tileObjectDraw.yOffset;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectDraw)
				{
					if (this._tileObjectDraw.yOffset == value)
					{
						return;
					}
					this._hasOwnTileObjectDraw = true;
					this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
				}
				this._tileObjectDraw.yOffset = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].DrawYOffset = value;
					}
				}
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x003AE78C File Offset: 0x003AC98C
		// (set) Token: 0x060008B7 RID: 2231 RVA: 0x003AE7A8 File Offset: 0x003AC9A8
		public bool DrawFlipHorizontal
		{
			get
			{
				if (this._tileObjectDraw == null)
				{
					return this.DrawFlipHorizontal;
				}
				return this._tileObjectDraw.flipHorizontal;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectDraw)
				{
					if (this._tileObjectDraw.flipHorizontal == value)
					{
						return;
					}
					this._hasOwnTileObjectDraw = true;
					this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
				}
				this._tileObjectDraw.flipHorizontal = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].DrawFlipHorizontal = value;
					}
				}
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x003AE830 File Offset: 0x003ACA30
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x003AE84C File Offset: 0x003ACA4C
		public bool DrawFlipVertical
		{
			get
			{
				if (this._tileObjectDraw == null)
				{
					return this.DrawFlipVertical;
				}
				return this._tileObjectDraw.flipVertical;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectDraw)
				{
					if (this._tileObjectDraw.flipVertical == value)
					{
						return;
					}
					this._hasOwnTileObjectDraw = true;
					this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
				}
				this._tileObjectDraw.flipVertical = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].DrawFlipVertical = value;
					}
				}
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x003AE8D4 File Offset: 0x003ACAD4
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x003AE8F0 File Offset: 0x003ACAF0
		public int DrawStepDown
		{
			get
			{
				if (this._tileObjectDraw == null)
				{
					return this.DrawStepDown;
				}
				return this._tileObjectDraw.stepDown;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectDraw)
				{
					if (this._tileObjectDraw.stepDown == value)
					{
						return;
					}
					this._hasOwnTileObjectDraw = true;
					this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
				}
				this._tileObjectDraw.stepDown = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].DrawStepDown = value;
					}
				}
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x003AE978 File Offset: 0x003ACB78
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x003AE994 File Offset: 0x003ACB94
		public bool StyleHorizontal
		{
			get
			{
				if (this._tileObjectStyle == null)
				{
					return this.StyleHorizontal;
				}
				return this._tileObjectStyle.horizontal;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectStyle)
				{
					if (this._tileObjectStyle.horizontal == value)
					{
						return;
					}
					this._hasOwnTileObjectStyle = true;
					this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
				}
				this._tileObjectStyle.horizontal = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].StyleHorizontal = value;
					}
				}
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x003AEA1C File Offset: 0x003ACC1C
		// (set) Token: 0x060008BF RID: 2239 RVA: 0x003AEA3C File Offset: 0x003ACC3C
		public int Style
		{
			get
			{
				if (this._tileObjectStyle == null)
				{
					return TileObjectData._baseObject.Style;
				}
				return this._tileObjectStyle.style;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectStyle)
				{
					if (this._tileObjectStyle.style == value)
					{
						return;
					}
					this._hasOwnTileObjectStyle = true;
					this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
				}
				this._tileObjectStyle.style = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].Style = value;
					}
				}
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x003AEAC4 File Offset: 0x003ACCC4
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x003AEAE4 File Offset: 0x003ACCE4
		public int StyleWrapLimit
		{
			get
			{
				if (this._tileObjectStyle == null)
				{
					return TileObjectData._baseObject.StyleWrapLimit;
				}
				return this._tileObjectStyle.styleWrapLimit;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectStyle)
				{
					if (this._tileObjectStyle.styleWrapLimit == value)
					{
						return;
					}
					this._hasOwnTileObjectStyle = true;
					this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
				}
				this._tileObjectStyle.styleWrapLimit = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].StyleWrapLimit = value;
					}
				}
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x003AEB6C File Offset: 0x003ACD6C
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x003AEB8C File Offset: 0x003ACD8C
		public int StyleLineSkip
		{
			get
			{
				if (this._tileObjectStyle == null)
				{
					return TileObjectData._baseObject.StyleLineSkip;
				}
				return this._tileObjectStyle.styleLineSkip;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectStyle)
				{
					if (this._tileObjectStyle.styleLineSkip == value)
					{
						return;
					}
					this._hasOwnTileObjectStyle = true;
					this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
				}
				this._tileObjectStyle.styleLineSkip = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].StyleLineSkip = value;
					}
				}
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x003AEC14 File Offset: 0x003ACE14
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x003AEC34 File Offset: 0x003ACE34
		public int StyleMultiplier
		{
			get
			{
				if (this._tileObjectStyle == null)
				{
					return TileObjectData._baseObject.StyleMultiplier;
				}
				return this._tileObjectStyle.styleMultiplier;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectStyle)
				{
					if (this._tileObjectStyle.styleMultiplier == value)
					{
						return;
					}
					this._hasOwnTileObjectStyle = true;
					this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
				}
				this._tileObjectStyle.styleMultiplier = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].StyleMultiplier = value;
					}
				}
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x003AECBC File Offset: 0x003ACEBC
		// (set) Token: 0x060008C7 RID: 2247 RVA: 0x003AECDC File Offset: 0x003ACEDC
		public int Width
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.Width;
				}
				return this._tileObjectBase.width;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.width == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
					if (!this._hasOwnTileObjectCoords)
					{
						this._hasOwnTileObjectCoords = true;
						this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, null);
						this._tileObjectCoords.calculated = false;
					}
				}
				this._tileObjectBase.width = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].Width = value;
					}
				}
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x003AED94 File Offset: 0x003ACF94
		// (set) Token: 0x060008C9 RID: 2249 RVA: 0x003AEDB4 File Offset: 0x003ACFB4
		public int Height
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.Height;
				}
				return this._tileObjectBase.height;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.height == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
					if (!this._hasOwnTileObjectCoords)
					{
						this._hasOwnTileObjectCoords = true;
						this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, null);
						this._tileObjectCoords.calculated = false;
					}
				}
				this._tileObjectBase.height = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].Height = value;
					}
				}
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x003AEE6C File Offset: 0x003AD06C
		// (set) Token: 0x060008CB RID: 2251 RVA: 0x003AEE8C File Offset: 0x003AD08C
		public Point16 Origin
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.Origin;
				}
				return this._tileObjectBase.origin;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.origin == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
				}
				this._tileObjectBase.origin = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].Origin = value;
					}
				}
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x003AEF1C File Offset: 0x003AD11C
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x003AEF3C File Offset: 0x003AD13C
		public TileObjectDirection Direction
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.Direction;
				}
				return this._tileObjectBase.direction;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.direction == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
				}
				this._tileObjectBase.direction = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].Direction = value;
					}
				}
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x003AEFC4 File Offset: 0x003AD1C4
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x003AEFE4 File Offset: 0x003AD1E4
		public int RandomStyleRange
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.RandomStyleRange;
				}
				return this._tileObjectBase.randomRange;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.randomRange == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
				}
				this._tileObjectBase.randomRange = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].RandomStyleRange = value;
					}
				}
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x003AF06C File Offset: 0x003AD26C
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x003AF08C File Offset: 0x003AD28C
		public bool FlattenAnchors
		{
			get
			{
				if (this._tileObjectBase == null)
				{
					return TileObjectData._baseObject.FlattenAnchors;
				}
				return this._tileObjectBase.flattenAnchors;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectBase)
				{
					if (this._tileObjectBase.flattenAnchors == value)
					{
						return;
					}
					this._hasOwnTileObjectBase = true;
					this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
				}
				this._tileObjectBase.flattenAnchors = value;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].FlattenAnchors = value;
					}
				}
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x003AF114 File Offset: 0x003AD314
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x003AF134 File Offset: 0x003AD334
		public int[] CoordinateHeights
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinateHeights;
				}
				return this._tileObjectCoords.heights;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectCoords)
				{
					if (value.deepCompare(this._tileObjectCoords.heights))
					{
						return;
					}
					this._hasOwnTileObjectCoords = true;
					this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, value);
				}
				else
				{
					this._tileObjectCoords.heights = value;
				}
				this._tileObjectCoords.calculated = false;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						int[] coordinateHeights = value;
						if (value != null)
						{
							coordinateHeights = (int[])value.Clone();
						}
						this._alternates.data[i].CoordinateHeights = coordinateHeights;
					}
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x003AF1E4 File Offset: 0x003AD3E4
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x003AF204 File Offset: 0x003AD404
		public int CoordinateWidth
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinateWidth;
				}
				return this._tileObjectCoords.width;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectCoords)
				{
					if (this._tileObjectCoords.width == value)
					{
						return;
					}
					this._hasOwnTileObjectCoords = true;
					this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, null);
				}
				this._tileObjectCoords.width = value;
				this._tileObjectCoords.calculated = false;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].CoordinateWidth = value;
					}
				}
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x003AF29C File Offset: 0x003AD49C
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x003AF2BC File Offset: 0x003AD4BC
		public int CoordinatePadding
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinatePadding;
				}
				return this._tileObjectCoords.padding;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectCoords)
				{
					if (this._tileObjectCoords.padding == value)
					{
						return;
					}
					this._hasOwnTileObjectCoords = true;
					this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, null);
				}
				this._tileObjectCoords.padding = value;
				this._tileObjectCoords.calculated = false;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].CoordinatePadding = value;
					}
				}
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x003AF354 File Offset: 0x003AD554
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x003AF374 File Offset: 0x003AD574
		public Point16 CoordinatePaddingFix
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinatePaddingFix;
				}
				return this._tileObjectCoords.paddingFix;
			}
			set
			{
				this.WriteCheck();
				if (!this._hasOwnTileObjectCoords)
				{
					if (this._tileObjectCoords.paddingFix == value)
					{
						return;
					}
					this._hasOwnTileObjectCoords = true;
					this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, null);
				}
				this._tileObjectCoords.paddingFix = value;
				this._tileObjectCoords.calculated = false;
				if (this._linkedAlternates)
				{
					for (int i = 0; i < this._alternates.data.Count; i++)
					{
						this._alternates.data[i].CoordinatePaddingFix = value;
					}
				}
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x003AF410 File Offset: 0x003AD610
		public int CoordinateFullWidth
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinateFullWidth;
				}
				if (!this._tileObjectCoords.calculated)
				{
					this.Calculate();
				}
				return this._tileObjectCoords.styleWidth;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x003AF444 File Offset: 0x003AD644
		public int CoordinateFullHeight
		{
			get
			{
				if (this._tileObjectCoords == null)
				{
					return TileObjectData._baseObject.CoordinateFullHeight;
				}
				if (!this._tileObjectCoords.calculated)
				{
					this.Calculate();
				}
				return this._tileObjectCoords.styleHeight;
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x003AF478 File Offset: 0x003AD678
		public bool LiquidPlace(Tile checkTile)
		{
			if (checkTile == null)
			{
				return false;
			}
			if (checkTile.liquid > 0)
			{
				switch (checkTile.liquidType())
				{
				case 0:
				case 2:
					if (this.WaterPlacement == LiquidPlacement.NotAllowed)
					{
						return false;
					}
					if (this.WaterPlacement == LiquidPlacement.OnlyInFullLiquid && checkTile.liquid != 255)
					{
						return false;
					}
					break;
				case 1:
					if (this.LavaPlacement == LiquidPlacement.NotAllowed)
					{
						return false;
					}
					if (this.LavaPlacement == LiquidPlacement.OnlyInFullLiquid && checkTile.liquid != 255)
					{
						return false;
					}
					break;
				}
			}
			else
			{
				switch (checkTile.liquidType())
				{
				case 0:
				case 2:
					if (this.WaterPlacement == LiquidPlacement.OnlyInFullLiquid || this.WaterPlacement == LiquidPlacement.OnlyInLiquid)
					{
						return false;
					}
					break;
				case 1:
					if (this.LavaPlacement == LiquidPlacement.OnlyInFullLiquid || this.LavaPlacement == LiquidPlacement.OnlyInLiquid)
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x003AF53C File Offset: 0x003AD73C
		public int AlternatesCount
		{
			get
			{
				return this.Alternates.Count;
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x003AF54C File Offset: 0x003AD74C
		public bool isValidTileAnchor(int type)
		{
			int[] array;
			int[] array2;
			if (this._anchorTiles == null)
			{
				array = null;
				array2 = null;
			}
			else
			{
				array = this._anchorTiles.tileValid;
				array2 = this._anchorTiles.tileInvalid;
			}
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					if (type == array2[i])
					{
						return false;
					}
				}
			}
			if (array == null)
			{
				return true;
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (type == array[j])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x003AF5B4 File Offset: 0x003AD7B4
		public bool isValidWallAnchor(int type)
		{
			int[] array;
			if (this._anchorTiles == null)
			{
				array = null;
			}
			else
			{
				array = this._anchorTiles.wallValid;
			}
			if (array == null)
			{
				return type != 0;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (type == array[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x003AF5FC File Offset: 0x003AD7FC
		public bool isValidAlternateAnchor(int type)
		{
			if (this._anchorTiles == null)
			{
				return false;
			}
			int[] tileAlternates = this._anchorTiles.tileAlternates;
			if (tileAlternates == null)
			{
				return false;
			}
			for (int i = 0; i < tileAlternates.Length; i++)
			{
				if (type == tileAlternates[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x003AF63C File Offset: 0x003AD83C
		public int CalculatePlacementStyle(int style, int alternate, int random)
		{
			int num = style * this.StyleMultiplier;
			num += this.Style;
			if (random >= 0)
			{
				num += random;
			}
			return num;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x003AF664 File Offset: 0x003AD864
		private static void addBaseTile(out TileObjectData baseTile)
		{
			TileObjectData.newTile.Calculate();
			baseTile = TileObjectData.newTile;
			baseTile._parent = TileObjectData._baseObject;
			TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x003AF694 File Offset: 0x003AD894
		private static void addTile(int tileType)
		{
			TileObjectData.newTile.Calculate();
			TileObjectData._data[tileType] = TileObjectData.newTile;
			TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x003AF6C0 File Offset: 0x003AD8C0
		private static void addSubTile(int style)
		{
			TileObjectData.newSubTile.Calculate();
			List<TileObjectData> list;
			if (!TileObjectData.newTile._hasOwnSubTiles)
			{
				list = new List<TileObjectData>(style + 1);
				TileObjectData.newTile.SubTiles = list;
			}
			else
			{
				list = TileObjectData.newTile.SubTiles;
			}
			if (list.Count <= style)
			{
				for (int i = list.Count; i <= style; i++)
				{
					list.Add(null);
				}
			}
			TileObjectData.newSubTile._parent = TileObjectData.newTile;
			list[style] = TileObjectData.newSubTile;
			TileObjectData.newSubTile = new TileObjectData(TileObjectData._baseObject);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x003AF750 File Offset: 0x003AD950
		private static void addAlternate(int baseStyle)
		{
			TileObjectData.newAlternate.Calculate();
			if (!TileObjectData.newTile._hasOwnAlternates)
			{
				TileObjectData.newTile.Alternates = new List<TileObjectData>();
			}
			TileObjectData.newAlternate.Style = baseStyle;
			TileObjectData.newAlternate._parent = TileObjectData.newTile;
			TileObjectData.newTile.Alternates.Add(TileObjectData.newAlternate);
			TileObjectData.newAlternate = new TileObjectData(TileObjectData._baseObject);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x003AF7C0 File Offset: 0x003AD9C0
		public static void Initialize()
		{
			TileObjectData._baseObject = new TileObjectData(null);
			TileObjectData._baseObject.SetupBaseObject();
			TileObjectData._data = new List<TileObjectData>(470);
			for (int i = 0; i < 470; i++)
			{
				TileObjectData._data.Add(null);
			}
			TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
			TileObjectData.newSubTile = new TileObjectData(TileObjectData._baseObject);
			TileObjectData.newAlternate = new TileObjectData(TileObjectData._baseObject);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 27;
			TileObjectData.newTile.StyleWrapLimit = 27;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(13);
			TileObjectData.addTile(19);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 27;
			TileObjectData.newTile.StyleWrapLimit = 27;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(427);
			for (int j = 435; j <= 439; j++)
			{
				TileObjectData.newTile.CoordinateHeights = new int[]
				{
					16
				};
				TileObjectData.newTile.CoordinateWidth = 16;
				TileObjectData.newTile.CoordinatePadding = 2;
				TileObjectData.newTile.StyleHorizontal = true;
				TileObjectData.newTile.StyleMultiplier = 27;
				TileObjectData.newTile.StyleWrapLimit = 27;
				TileObjectData.newTile.UsesCustomCanPlace = false;
				TileObjectData.newTile.LavaDeath = true;
				TileObjectData.addTile(j);
			}
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 8;
			TileObjectData.newTile.Origin = new Point16(1, 7);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.HookPlaceOverride = new PlacementHook(new Func<int, int, int, int, int, int>(WorldGen.PlaceXmasTree_Direct), -1, 0, true);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 0;
			TileObjectData.addTile(171);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				38
			};
			TileObjectData.newTile.CoordinateWidth = 32;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.DrawYOffset = -20;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.addBaseTile(out TileObjectData.StyleDye);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.AnchorValidWalls = new int[1];
			TileObjectData.addSubTile(3);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.AnchorValidWalls = new int[1];
			TileObjectData.addSubTile(4);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.OnlyInFullLiquid;
			TileObjectData.addSubTile(5);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				80
			};
			TileObjectData.newSubTile.AnchorLeft = new AnchorData(AnchorType.EmptyTile, 1, 1);
			TileObjectData.newSubTile.AnchorRight = new AnchorData(AnchorType.EmptyTile, 1, 1);
			TileObjectData.addSubTile(6);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
			TileObjectData.newSubTile.DrawYOffset = -6;
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newSubTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newSubTile.Width, 0);
			TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.EmptyTile, TileObjectData.newSubTile.Width, 0);
			TileObjectData.addSubTile(7);
			TileObjectData.addTile(227);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = false;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.newTile.StyleLineSkip = 3;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 1);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 2);
			TileObjectData.addAlternate(0);
			TileObjectData.addTile(10);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 1);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 2);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 0);
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 1);
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 2);
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.addAlternate(1);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(19);
			TileObjectData.addTile(11);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.DrawYOffset = -2;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				18,
				16,
				16,
				16,
				18
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			for (int k = 1; k < 5; k++)
			{
				TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
				TileObjectData.newAlternate.Origin = new Point16(0, k);
				TileObjectData.addAlternate(0);
			}
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			for (int l = 1; l < 5; l++)
			{
				TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
				TileObjectData.newAlternate.Origin = new Point16(0, l);
				TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
				TileObjectData.addAlternate(1);
			}
			TileObjectData.addTile(388);
			TileObjectData.newTile.FullCopyFrom(388);
			TileObjectData.addTile(389);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addBaseTile(out TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(13);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -4;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(25);
			TileObjectData.addTile(33);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -4;
			TileObjectData.addTile(49);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -4;
			TileObjectData.addTile(372);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 5;
			TileObjectData.addTile(50);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(78);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -4;
			TileObjectData.addTile(174);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addBaseTile(out TileObjectData.Style1xX);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(23);
			TileObjectData.addTile(93);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.newTile.Height = 6;
			TileObjectData.newTile.Origin = new Point16(0, 5);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16,
				16
			};
			TileObjectData.addTile(92);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(453);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style1x2Top);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.addTile(270);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.addTile(271);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(32);
			TileObjectData.addTile(42);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(91);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addBaseTile(out TileObjectData.Style4x2);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(25);
			TileObjectData.addTile(90);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(8);
			TileObjectData.addTile(79);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 2, 1);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(209);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addBaseTile(out TileObjectData.StyleSmallCage);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(285);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(286);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(298);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(299);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(310);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(339);
			TileObjectData.newTile.Width = 6;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(3, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style6x3);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(275);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(276);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(413);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(414);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(277);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(278);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(279);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(280);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(281);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(296);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(297);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(309);
			TileObjectData.newTile.Width = 5;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(2, 3);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style5x4);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.addTile(464);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.addTile(466);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style2x1);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(29);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(103);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(462);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				18
			};
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(14);
			TileObjectData.addTile(18);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				18
			};
			TileObjectData.addTile(16);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(134);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newTile.AnchorRight = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Height, 0);
			TileObjectData.addTile(387);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.addAlternate(3);
			TileObjectData.addTile(443);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addBaseTile(out TileObjectData.Style2xX);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(1, 3);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(207);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				18
			};
			TileObjectData.addTile(410);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(349);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(337);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorBottom = default(AnchorData);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(465);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(320);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(456);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(TETrainingDummy.Hook_AfterPlacement), -1, 0, false);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(378);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.StyleWrapLimit = 55;
			TileObjectData.addTile(105);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.Origin = new Point16(0, 4);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(17);
			TileObjectData.addTile(104);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Origin = new Point16(0, 2);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(128);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Origin = new Point16(0, 2);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(269);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addBaseTile(out TileObjectData.Style3x3);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.StyleWrapLimit = 37;
			TileObjectData.newTile.StyleHorizontal = false;
			TileObjectData.newTile.StyleLineSkip = 2;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(32);
			TileObjectData.addTile(34);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Origin = new Point16(2, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(454);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style3x2);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newSubTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(13);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newSubTile.Height = 1;
			TileObjectData.newSubTile.Origin = new Point16(1, 0);
			TileObjectData.newSubTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.addSubTile(25);
			TileObjectData.addTile(14);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.addTile(469);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(9);
			TileObjectData.addTile(88);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addTile(237);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(244);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.addTile(26);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(86);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(377);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(15);
			TileObjectData.addTile(87);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(10);
			TileObjectData.addTile(89);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(114);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(186);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(187);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.WaterDeath = false;
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(1);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.WaterDeath = false;
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(4);
			TileObjectData.addTile(215);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(217);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(218);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.addTile(17);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(77);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(133);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(405);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(235);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(1, 3);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style3x4);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(4);
			TileObjectData.addTile(101);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.addTile(102);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(463);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style2x2);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(21);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(467);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(441);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(468);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 6;
			TileObjectData.newTile.StyleMultiplier = 6;
			TileObjectData.newTile.RandomStyleRange = 6;
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				2,
				109
			};
			TileObjectData.addTile(254);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(96);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.RandomStyleRange = 5;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(457);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(139);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.RandomStyleRange = 9;
			TileObjectData.addTile(35);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.addTile(95);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.addTile(126);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.addTile(444);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.addTile(98);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(13);
			TileObjectData.addTile(172);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(94);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(411);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(97);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(99);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(25);
			TileObjectData.addTile(100);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(125);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(173);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(287);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(319);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(287);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(376);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(138);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(142);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(143);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(282);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(288);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(289);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(290);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(291);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(292);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(293);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(294);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(295);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(316);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(317);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(318);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(360);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(358);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.addTile(359);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(361);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(362);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(363);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(364);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(391);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(392);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(393);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(394);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(287);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(335);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(354);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(355);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(356);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newTile.AnchorRight = new AnchorData(AnchorType.SolidTile, 1, 1);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.addTile(386);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.addAlternate(2);
			TileObjectData.addTile(132);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 0);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(3);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(4);
			TileObjectData.addTile(55);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 0);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(3);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(4);
			TileObjectData.addTile(425);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(85);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(TEItemFrame.Hook_AfterPlacement), -1, 0, true);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 0);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(3);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = Point16.Zero;
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(4);
			TileObjectData.addTile(395);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style3x3);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.addTile(106);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(212);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(219);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(220);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(228);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(231);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(243);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(247);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(283);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(300);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(301);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(302);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(303);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(304);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(305);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(306);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(307);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(308);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.addTile(406);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.addTile(452);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(412);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(455);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style1x2);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(16);
			TileObjectData.addTile(15);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				20
			};
			TileObjectData.addTile(216);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.addTile(390);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.addTile(338);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style1x1);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(420);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorAlternateTiles = new int[]
			{
				420,
				419
			};
			TileObjectData.newAlternate.UsesCustomCanPlace = true;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 1);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				419
			};
			TileObjectData.addTile(419);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(TELogicSensor.Hook_AfterPlacement), -1, 0, true);
			TileObjectData.addTile(423);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(424);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(445);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(429);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				26
			};
			TileObjectData.newTile.CoordinateWidth = 24;
			TileObjectData.newTile.DrawYOffset = -8;
			TileObjectData.newTile.RandomStyleRange = 6;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(81);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				18
			};
			TileObjectData.newTile.CoordinatePadding = 0;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(135);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				18
			};
			TileObjectData.newTile.CoordinatePadding = 0;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(428);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.RandomStyleRange = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(141);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(144);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(210);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(239);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 7;
			TileObjectData.addTile(36);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newTile.StyleMultiplier = 3;
			TileObjectData.newTile.StyleWrapLimit = 3;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.CoordinateWidth = 20;
			TileObjectData.newTile.DrawYOffset = -2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(324);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.FlattenAnchors = true;
			TileObjectData.addBaseTile(out TileObjectData.StyleSwitch);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.addAlternate(3);
			TileObjectData.addTile(136);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.FlattenAnchors = true;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawStepDown = 2;
			TileObjectData.newTile.CoordinateWidth = 20;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleMultiplier = 6;
			TileObjectData.newTile.StyleWrapLimit = 6;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.StyleTorch);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.addAlternate(0);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.WaterDeath = false;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(8);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.WaterDeath = false;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(11);
			TileObjectData.addTile(4);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.FlattenAnchors = true;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.DrawStepDown = 2;
			TileObjectData.newTile.CoordinateWidth = 20;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.WaterDeath = false;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.StyleWrapLimit = 4;
			TileObjectData.newTile.StyleMultiplier = 4;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.DrawStepDown = -4;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[]
			{
				124
			};
			TileObjectData.addAlternate(3);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(442);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.Origin = Point16.Zero;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.DrawYOffset = -1;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.addBaseTile(out TileObjectData.StyleAlch);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				2,
				109
			};
			TileObjectData.newTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				60
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.addSubTile(1);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				0,
				59
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.addSubTile(2);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				199,
				203,
				25,
				23
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.addSubTile(3);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				53,
				116
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(4);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				57
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.addSubTile(5);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newSubTile.AnchorValidTiles = new int[]
			{
				147,
				161,
				163,
				164,
				200
			};
			TileObjectData.newSubTile.AnchorAlternateTiles = new int[]
			{
				78
			};
			TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.addSubTile(6);
			TileObjectData.addTile(82);
			TileObjectData.newTile.FullCopyFrom(82);
			TileObjectData.addTile(83);
			TileObjectData.newTile.FullCopyFrom(83);
			TileObjectData.addTile(84);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addBaseTile(out TileObjectData.Style3x3Wall);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(240);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(440);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile(334);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(245);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.addTile(246);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.RandomStyleRange = 9;
			TileObjectData.addTile(241);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 6;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(2, 2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16
			};
			TileObjectData.newTile.StyleWrapLimit = 27;
			TileObjectData.addTile(242);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(0, 3);
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				18
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidWalls = new int[1];
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				2,
				109
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile(27);
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				2
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				147
			};
			TileObjectData.addAlternate(3);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				60
			};
			TileObjectData.addAlternate(6);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				23
			};
			TileObjectData.addAlternate(9);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				199
			};
			TileObjectData.addAlternate(12);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				109
			};
			TileObjectData.addAlternate(15);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				53
			};
			TileObjectData.addAlternate(18);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				116
			};
			TileObjectData.addAlternate(21);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				234
			};
			TileObjectData.addAlternate(24);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorValidTiles = new int[]
			{
				112
			};
			TileObjectData.addAlternate(27);
			TileObjectData.addTile(20);
			TileObjectData.readOnlyData = true;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x003B4534 File Offset: 0x003B2734
		public static bool CustomPlace(int type, int style)
		{
			if (type < 0 || type >= TileObjectData._data.Count || style < 0)
			{
				return false;
			}
			TileObjectData tileObjectData = TileObjectData._data[type];
			if (tileObjectData == null)
			{
				return false;
			}
			List<TileObjectData> subTiles = tileObjectData.SubTiles;
			if (subTiles != null && style < subTiles.Count)
			{
				TileObjectData tileObjectData2 = subTiles[style];
				if (tileObjectData2 != null)
				{
					return tileObjectData2._usesCustomCanPlace;
				}
			}
			return tileObjectData._usesCustomCanPlace;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x003B4594 File Offset: 0x003B2794
		public static bool CheckLiquidPlacement(int type, int style, Tile checkTile)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			if (tileData != null)
			{
				return tileData.LiquidPlace(checkTile);
			}
			return TileObjectData.LiquidPlace(type, checkTile);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x003B45BC File Offset: 0x003B27BC
		public static bool LiquidPlace(int type, Tile checkTile)
		{
			if (checkTile == null)
			{
				return false;
			}
			if (checkTile.liquid > 0)
			{
				switch (checkTile.liquidType())
				{
				case 0:
				case 2:
					if (Main.tileWaterDeath[type])
					{
						return false;
					}
					break;
				case 1:
					if (Main.tileLavaDeath[type])
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x003B460C File Offset: 0x003B280C
		public static bool CheckWaterDeath(int type, int style)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			if (tileData == null)
			{
				return Main.tileWaterDeath[type];
			}
			return tileData.WaterDeath;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x003B4634 File Offset: 0x003B2834
		public static bool CheckWaterDeath(Tile checkTile)
		{
			if (!checkTile.active())
			{
				return false;
			}
			TileObjectData tileData = TileObjectData.GetTileData(checkTile);
			if (tileData == null)
			{
				return Main.tileWaterDeath[(int)checkTile.type];
			}
			return tileData.WaterDeath;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x003B4668 File Offset: 0x003B2868
		public static bool CheckLavaDeath(int type, int style)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			if (tileData == null)
			{
				return Main.tileLavaDeath[type];
			}
			return tileData.LavaDeath;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x003B4690 File Offset: 0x003B2890
		public static bool CheckLavaDeath(Tile checkTile)
		{
			if (!checkTile.active())
			{
				return false;
			}
			TileObjectData tileData = TileObjectData.GetTileData(checkTile);
			if (tileData == null)
			{
				return Main.tileLavaDeath[(int)checkTile.type];
			}
			return tileData.LavaDeath;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x003B46C4 File Offset: 0x003B28C4
		public static int PlatformFrameWidth()
		{
			return TileObjectData._data[19].CoordinateFullWidth;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x003B46D8 File Offset: 0x003B28D8
		public static TileObjectData GetTileData(int type, int style, int alternate = 0)
		{
			if (type < 0 || type >= TileObjectData._data.Count)
			{
				throw new ArgumentOutOfRangeException("Function called with a bad type argument");
			}
			if (style < 0)
			{
				throw new ArgumentOutOfRangeException("Function called with a bad style argument");
			}
			TileObjectData tileObjectData = TileObjectData._data[type];
			if (tileObjectData == null)
			{
				return null;
			}
			List<TileObjectData> subTiles = tileObjectData.SubTiles;
			if (subTiles != null && style < subTiles.Count)
			{
				TileObjectData tileObjectData2 = subTiles[style];
				if (tileObjectData2 != null)
				{
					tileObjectData = tileObjectData2;
				}
			}
			alternate--;
			List<TileObjectData> alternates = tileObjectData.Alternates;
			if (alternates != null && alternate >= 0 && alternate < alternates.Count)
			{
				TileObjectData tileObjectData3 = alternates[alternate];
				if (tileObjectData3 != null)
				{
					tileObjectData = tileObjectData3;
				}
			}
			return tileObjectData;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x003B4770 File Offset: 0x003B2970
		public static TileObjectData GetTileData(Tile getTile)
		{
			if (getTile == null || !getTile.active())
			{
				return null;
			}
			int type = (int)getTile.type;
			if (type < 0 || type >= TileObjectData._data.Count)
			{
				throw new ArgumentOutOfRangeException("Function called with a bad tile type");
			}
			TileObjectData tileObjectData = TileObjectData._data[type];
			if (tileObjectData == null)
			{
				return null;
			}
			int num = (int)getTile.frameX / tileObjectData.CoordinateFullWidth;
			int num2 = (int)getTile.frameY / tileObjectData.CoordinateFullHeight;
			int num3 = tileObjectData.StyleWrapLimit;
			if (num3 == 0)
			{
				num3 = 1;
			}
			int num4;
			if (tileObjectData.StyleHorizontal)
			{
				num4 = num2 * num3 + num;
			}
			else
			{
				num4 = num * num3 + num2;
			}
			int num5 = num4 / tileObjectData.StyleMultiplier;
			int num6 = num4 % tileObjectData.StyleMultiplier;
			if (tileObjectData.SubTiles != null && num5 >= 0 && num5 < tileObjectData.SubTiles.Count)
			{
				TileObjectData tileObjectData2 = tileObjectData.SubTiles[num5];
				if (tileObjectData2 != null)
				{
					tileObjectData = tileObjectData2;
				}
			}
			if (tileObjectData._alternates != null)
			{
				for (int i = 0; i < tileObjectData.Alternates.Count; i++)
				{
					TileObjectData tileObjectData3 = tileObjectData.Alternates[i];
					if (tileObjectData3 != null && num6 >= tileObjectData3.Style && num6 <= tileObjectData3.Style + tileObjectData3.RandomStyleRange)
					{
						return tileObjectData3;
					}
				}
			}
			return tileObjectData;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x003B48A4 File Offset: 0x003B2AA4
		public static void SyncObjectPlacement(int tileX, int tileY, int type, int style, int dir)
		{
			NetMessage.SendData(17, -1, -1, null, 1, (float)tileX, (float)tileY, (float)type, style, 0, 0);
			TileObjectData.GetTileData(type, style, 0);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x003B48D0 File Offset: 0x003B2AD0
		public static bool CallPostPlacementPlayerHook(int tileX, int tileY, int type, int style, int dir, TileObject data)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, data.alternate);
			if (tileData == null || tileData._placementHooks == null || tileData._placementHooks.postPlaceMyPlayer.hook == null)
			{
				return false;
			}
			PlacementHook postPlaceMyPlayer = tileData._placementHooks.postPlaceMyPlayer;
			if (postPlaceMyPlayer.processedCoordinates)
			{
				tileX -= (int)tileData.Origin.X;
				tileY -= (int)tileData.Origin.Y;
			}
			return postPlaceMyPlayer.hook(tileX, tileY, type, style, dir) == postPlaceMyPlayer.badReturn;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x003B4958 File Offset: 0x003B2B58
		public static void OriginToTopLeft(int type, int style, ref Point16 baseCoords)
		{
			TileObjectData tileData = TileObjectData.GetTileData(type, style, 0);
			if (tileData == null)
			{
				return;
			}
			baseCoords = new Point16((int)(baseCoords.X - tileData.Origin.X), (int)(baseCoords.Y - tileData.Origin.Y));
		}

		// Token: 0x04000D22 RID: 3362
		private TileObjectData _parent;

		// Token: 0x04000D23 RID: 3363
		private bool _linkedAlternates;

		// Token: 0x04000D24 RID: 3364
		private bool _usesCustomCanPlace;

		// Token: 0x04000D25 RID: 3365
		private TileObjectAlternatesModule _alternates;

		// Token: 0x04000D26 RID: 3366
		private AnchorDataModule _anchor;

		// Token: 0x04000D27 RID: 3367
		private AnchorTypesModule _anchorTiles;

		// Token: 0x04000D28 RID: 3368
		private LiquidDeathModule _liquidDeath;

		// Token: 0x04000D29 RID: 3369
		private LiquidPlacementModule _liquidPlacement;

		// Token: 0x04000D2A RID: 3370
		private TilePlacementHooksModule _placementHooks;

		// Token: 0x04000D2B RID: 3371
		private TileObjectSubTilesModule _subTiles;

		// Token: 0x04000D2C RID: 3372
		private TileObjectDrawModule _tileObjectDraw;

		// Token: 0x04000D2D RID: 3373
		private TileObjectStyleModule _tileObjectStyle;

		// Token: 0x04000D2E RID: 3374
		private TileObjectBaseModule _tileObjectBase;

		// Token: 0x04000D2F RID: 3375
		private TileObjectCoordinatesModule _tileObjectCoords;

		// Token: 0x04000D30 RID: 3376
		private bool _hasOwnAlternates;

		// Token: 0x04000D31 RID: 3377
		private bool _hasOwnAnchor;

		// Token: 0x04000D32 RID: 3378
		private bool _hasOwnAnchorTiles;

		// Token: 0x04000D33 RID: 3379
		private bool _hasOwnLiquidDeath;

		// Token: 0x04000D34 RID: 3380
		private bool _hasOwnLiquidPlacement;

		// Token: 0x04000D35 RID: 3381
		private bool _hasOwnPlacementHooks;

		// Token: 0x04000D36 RID: 3382
		private bool _hasOwnSubTiles;

		// Token: 0x04000D37 RID: 3383
		private bool _hasOwnTileObjectBase;

		// Token: 0x04000D38 RID: 3384
		private bool _hasOwnTileObjectDraw;

		// Token: 0x04000D39 RID: 3385
		private bool _hasOwnTileObjectStyle;

		// Token: 0x04000D3A RID: 3386
		private bool _hasOwnTileObjectCoords;

		// Token: 0x04000D3B RID: 3387
		private static List<TileObjectData> _data;

		// Token: 0x04000D3C RID: 3388
		private static TileObjectData _baseObject;

		// Token: 0x04000D3D RID: 3389
		private static bool readOnlyData;

		// Token: 0x04000D3E RID: 3390
		private static TileObjectData newTile;

		// Token: 0x04000D3F RID: 3391
		private static TileObjectData newSubTile;

		// Token: 0x04000D40 RID: 3392
		private static TileObjectData newAlternate;

		// Token: 0x04000D41 RID: 3393
		private static TileObjectData StyleSwitch;

		// Token: 0x04000D42 RID: 3394
		private static TileObjectData StyleTorch;

		// Token: 0x04000D43 RID: 3395
		private static TileObjectData Style4x2;

		// Token: 0x04000D44 RID: 3396
		private static TileObjectData Style2x2;

		// Token: 0x04000D45 RID: 3397
		private static TileObjectData Style1x2;

		// Token: 0x04000D46 RID: 3398
		private static TileObjectData Style1x1;

		// Token: 0x04000D47 RID: 3399
		private static TileObjectData StyleAlch;

		// Token: 0x04000D48 RID: 3400
		private static TileObjectData StyleDye;

		// Token: 0x04000D49 RID: 3401
		private static TileObjectData Style2x1;

		// Token: 0x04000D4A RID: 3402
		private static TileObjectData Style6x3;

		// Token: 0x04000D4B RID: 3403
		private static TileObjectData StyleSmallCage;

		// Token: 0x04000D4C RID: 3404
		private static TileObjectData StyleOnTable1x1;

		// Token: 0x04000D4D RID: 3405
		private static TileObjectData Style1x2Top;

		// Token: 0x04000D4E RID: 3406
		private static TileObjectData Style1xX;

		// Token: 0x04000D4F RID: 3407
		private static TileObjectData Style2xX;

		// Token: 0x04000D50 RID: 3408
		private static TileObjectData Style3x2;

		// Token: 0x04000D51 RID: 3409
		private static TileObjectData Style3x3;

		// Token: 0x04000D52 RID: 3410
		private static TileObjectData Style3x4;

		// Token: 0x04000D53 RID: 3411
		private static TileObjectData Style5x4;

		// Token: 0x04000D54 RID: 3412
		private static TileObjectData Style3x3Wall;
	}
}
