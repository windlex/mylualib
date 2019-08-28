using System;
using Microsoft.Xna.Framework;

namespace Terraria.Utilities
{
	// Token: 0x0200005F RID: 95
	public static class NPCUtils
	{
		// Token: 0x06000959 RID: 2393 RVA: 0x003B5E44 File Offset: 0x003B4044
		public static NPCUtils.TargetSearchResults SearchForTarget(Vector2 position, NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All, NPCUtils.SearchFilter<Player> playerFilter = null, NPCUtils.SearchFilter<NPC> npcFilter = null)
		{
			return NPCUtils.SearchForTarget(null, position, flags, playerFilter, npcFilter);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x003B5E50 File Offset: 0x003B4050
		public static NPCUtils.TargetSearchResults SearchForTarget(NPC searcher, NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All, NPCUtils.SearchFilter<Player> playerFilter = null, NPCUtils.SearchFilter<NPC> npcFilter = null)
		{
			return NPCUtils.SearchForTarget(searcher, searcher.Center, flags, playerFilter, npcFilter);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x003B5E64 File Offset: 0x003B4064
		public static NPCUtils.TargetSearchResults SearchForTarget(NPC searcher, Vector2 position, NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All, NPCUtils.SearchFilter<Player> playerFilter = null, NPCUtils.SearchFilter<NPC> npcFilter = null)
		{
			float num = 3.40282347E+38f;
			int nearestNPCIndex = -1;
			float num2 = 3.40282347E+38f;
			float nearestTankDistance = 3.40282347E+38f;
			int nearestTankIndex = -1;
			NPCUtils.TargetType tankType = NPCUtils.TargetType.Player;
			if (flags.HasFlag(NPCUtils.TargetSearchFlag.NPCs))
			{
				for (int i = 0; i < 200; i++)
				{
					NPC nPC = Main.npc[i];
					if (nPC.active && (npcFilter == null || npcFilter(nPC)))
					{
						float num3 = Vector2.DistanceSquared(position, nPC.Center);
						if (num3 < num)
						{
							nearestNPCIndex = i;
							num = num3;
						}
					}
				}
			}
			if (flags.HasFlag(NPCUtils.TargetSearchFlag.Players))
			{
				for (int j = 0; j < 255; j++)
				{
					Player player = Main.player[j];
					if (player.active && !player.dead && !player.ghost && (playerFilter == null || playerFilter(player)))
					{
						float num4 = Vector2.Distance(position, player.Center);
						float num5 = num4 - (float)player.aggro;
						bool flag = searcher != null && player.npcTypeNoAggro[searcher.type];
						if ((searcher != null & flag) && searcher.direction == 0)
						{
							num5 += 1000f;
						}
						if (num5 < num2)
						{
							nearestTankIndex = j;
							num2 = num5;
							nearestTankDistance = num4;
							tankType = NPCUtils.TargetType.Player;
						}
						if (player.tankPet >= 0 && !flag)
						{
							Vector2 center = Main.projectile[player.tankPet].Center;
							num4 = Vector2.Distance(position, center);
							num5 = num4 - 200f;
							if (num5 < num2 && num5 < 200f && Collision.CanHit(position, 0, 0, center, 0, 0))
							{
								nearestTankIndex = j;
								num2 = num5;
								nearestTankDistance = num4;
								tankType = NPCUtils.TargetType.TankPet;
							}
						}
					}
				}
			}
			return new NPCUtils.TargetSearchResults(searcher, nearestNPCIndex, (float)Math.Sqrt((double)num), nearestTankIndex, nearestTankDistance, num2, tankType);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x003B6030 File Offset: 0x003B4230
		public static void TargetClosestOldOnesInvasion(NPC searcher, bool faceTarget = true, Vector2? checkPosition = null)
		{
			NPCUtils.TargetSearchResults targetSearchResults = NPCUtils.SearchForTarget(searcher, NPCUtils.TargetSearchFlag.All, NPCUtils.SearchFilters.OnlyPlayersInCertainDistance(searcher.Center, 200f), new NPCUtils.SearchFilter<NPC>(NPCUtils.SearchFilters.OnlyCrystal));
			if (!targetSearchResults.FoundTarget)
			{
				return;
			}
			searcher.target = targetSearchResults.NearestTargetIndex;
			searcher.targetRect = targetSearchResults.NearestTargetHitbox;
			if (searcher.ShouldFaceTarget(ref targetSearchResults, null) & faceTarget)
			{
				searcher.FaceTarget();
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x003B60A0 File Offset: 0x003B42A0
		public static void TargetClosestBetsy(NPC searcher, bool faceTarget = true, Vector2? checkPosition = null)
		{
			NPCUtils.TargetSearchResults targetSearchResults = NPCUtils.SearchForTarget(searcher, NPCUtils.TargetSearchFlag.All, null, new NPCUtils.SearchFilter<NPC>(NPCUtils.SearchFilters.OnlyCrystal));
			if (!targetSearchResults.FoundTarget)
			{
				return;
			}
			NPCUtils.TargetType value = targetSearchResults.NearestTargetType;
			if (targetSearchResults.FoundTank && !targetSearchResults.NearestTankOwner.dead)
			{
				value = NPCUtils.TargetType.Player;
			}
			searcher.target = targetSearchResults.NearestTargetIndex;
			searcher.targetRect = targetSearchResults.NearestTargetHitbox;
			if (searcher.ShouldFaceTarget(ref targetSearchResults, new NPCUtils.TargetType?(value)) & faceTarget)
			{
				searcher.FaceTarget();
			}
		}

		// Token: 0x02000220 RID: 544
		// (Invoke) Token: 0x06001561 RID: 5473
		public delegate bool SearchFilter<T>(T entity) where T : Entity;

		// Token: 0x02000221 RID: 545
		public static class SearchFilters
		{
			// Token: 0x06001564 RID: 5476 RVA: 0x00430360 File Offset: 0x0042E560
			public static bool OnlyCrystal(NPC npc)
			{
				return npc.type == 548 && !npc.dontTakeDamageFromHostiles;
			}

			// Token: 0x06001565 RID: 5477 RVA: 0x0043037C File Offset: 0x0042E57C
			public static NPCUtils.SearchFilter<Player> OnlyPlayersInCertainDistance(Vector2 position, float maxDistance)
			{
				return (Player player) => player.Distance(position) <= maxDistance;
			}
		}

		// Token: 0x02000222 RID: 546
		public enum TargetType
		{
			// Token: 0x0400378B RID: 14219
			None,
			// Token: 0x0400378C RID: 14220
			NPC,
			// Token: 0x0400378D RID: 14221
			Player,
			// Token: 0x0400378E RID: 14222
			TankPet
		}

		// Token: 0x02000223 RID: 547
		public struct TargetSearchResults
		{
			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x06001566 RID: 5478 RVA: 0x0043039C File Offset: 0x0042E59C
			public int NearestTargetIndex
			{
				get
				{
					NPCUtils.TargetType nearestTargetType = this._nearestTargetType;
					if (nearestTargetType == NPCUtils.TargetType.NPC)
					{
						return this.NearestNPC.WhoAmIToTargettingIndex;
					}
					if (nearestTargetType - NPCUtils.TargetType.Player <= 1)
					{
						return this._nearestTankIndex;
					}
					return -1;
				}
			}

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x06001567 RID: 5479 RVA: 0x004303D0 File Offset: 0x0042E5D0
			public Rectangle NearestTargetHitbox
			{
				get
				{
					switch (this._nearestTargetType)
					{
					case NPCUtils.TargetType.NPC:
						return this.NearestNPC.Hitbox;
					case NPCUtils.TargetType.Player:
						return this.NearestTankOwner.Hitbox;
					case NPCUtils.TargetType.TankPet:
						return Main.projectile[this.NearestTankOwner.tankPet].Hitbox;
					default:
						return Rectangle.Empty;
					}
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x06001568 RID: 5480 RVA: 0x00430430 File Offset: 0x0042E630
			public NPCUtils.TargetType NearestTargetType
			{
				get
				{
					return this._nearestTargetType;
				}
			}

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06001569 RID: 5481 RVA: 0x00430438 File Offset: 0x0042E638
			public bool FoundTarget
			{
				get
				{
					return this._nearestTargetType > NPCUtils.TargetType.None;
				}
			}

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x0600156A RID: 5482 RVA: 0x00430444 File Offset: 0x0042E644
			public NPC NearestNPC
			{
				get
				{
					if (this._nearestNPCIndex != -1)
					{
						return Main.npc[this._nearestNPCIndex];
					}
					return null;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x0600156B RID: 5483 RVA: 0x00430460 File Offset: 0x0042E660
			public bool FoundNPC
			{
				get
				{
					return this._nearestNPCIndex != -1;
				}
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x0600156C RID: 5484 RVA: 0x00430470 File Offset: 0x0042E670
			public int NearestNPCIndex
			{
				get
				{
					return this._nearestNPCIndex;
				}
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x0600156D RID: 5485 RVA: 0x00430478 File Offset: 0x0042E678
			public float NearestNPCDistance
			{
				get
				{
					return this._nearestNPCDistance;
				}
			}

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x0600156E RID: 5486 RVA: 0x00430480 File Offset: 0x0042E680
			public Player NearestTankOwner
			{
				get
				{
					if (this._nearestTankIndex != -1)
					{
						return Main.player[this._nearestTankIndex];
					}
					return null;
				}
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x0600156F RID: 5487 RVA: 0x0043049C File Offset: 0x0042E69C
			public bool FoundTank
			{
				get
				{
					return this._nearestTankIndex != -1;
				}
			}

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06001570 RID: 5488 RVA: 0x004304AC File Offset: 0x0042E6AC
			public int NearestTankOwnerIndex
			{
				get
				{
					return this._nearestTankIndex;
				}
			}

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06001571 RID: 5489 RVA: 0x004304B4 File Offset: 0x0042E6B4
			public float NearestTankDistance
			{
				get
				{
					return this._nearestTankDistance;
				}
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06001572 RID: 5490 RVA: 0x004304BC File Offset: 0x0042E6BC
			public float AdjustedTankDistance
			{
				get
				{
					return this._adjustedTankDistance;
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06001573 RID: 5491 RVA: 0x004304C4 File Offset: 0x0042E6C4
			public NPCUtils.TargetType NearestTankType
			{
				get
				{
					return this._nearestTankType;
				}
			}

			// Token: 0x06001574 RID: 5492 RVA: 0x004304CC File Offset: 0x0042E6CC
			public TargetSearchResults(NPC searcher, int nearestNPCIndex, float nearestNPCDistance, int nearestTankIndex, float nearestTankDistance, float adjustedTankDistance, NPCUtils.TargetType tankType)
			{
				this._nearestNPCIndex = nearestNPCIndex;
				this._nearestNPCDistance = nearestNPCDistance;
				this._nearestTankIndex = nearestTankIndex;
				this._adjustedTankDistance = adjustedTankDistance;
				this._nearestTankDistance = nearestTankDistance;
				this._nearestTankType = tankType;
				if (this._nearestNPCIndex != -1 && this._nearestTankIndex != -1)
				{
					if (this._nearestNPCDistance < this._adjustedTankDistance)
					{
						this._nearestTargetType = NPCUtils.TargetType.NPC;
						return;
					}
					this._nearestTargetType = tankType;
					return;
				}
				else
				{
					if (this._nearestNPCIndex != -1)
					{
						this._nearestTargetType = NPCUtils.TargetType.NPC;
						return;
					}
					if (this._nearestTankIndex != -1)
					{
						this._nearestTargetType = tankType;
						return;
					}
					this._nearestTargetType = NPCUtils.TargetType.None;
					return;
				}
			}

			// Token: 0x0400378F RID: 14223
			private NPCUtils.TargetType _nearestTargetType;

			// Token: 0x04003790 RID: 14224
			private int _nearestNPCIndex;

			// Token: 0x04003791 RID: 14225
			private float _nearestNPCDistance;

			// Token: 0x04003792 RID: 14226
			private int _nearestTankIndex;

			// Token: 0x04003793 RID: 14227
			private float _nearestTankDistance;

			// Token: 0x04003794 RID: 14228
			private float _adjustedTankDistance;

			// Token: 0x04003795 RID: 14229
			private NPCUtils.TargetType _nearestTankType;
		}

		// Token: 0x02000224 RID: 548
		[Flags]
		public enum TargetSearchFlag
		{
			// Token: 0x04003797 RID: 14231
			None = 0,
			// Token: 0x04003798 RID: 14232
			NPCs = 1,
			// Token: 0x04003799 RID: 14233
			Players = 2,
			// Token: 0x0400379A RID: 14234
			All = 3
		}
	}
}
