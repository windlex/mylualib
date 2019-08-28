using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace Terraria.GameInput
{
	// Token: 0x02000102 RID: 258
	public class LockOnHelper
	{
		// Token: 0x06000E2C RID: 3628 RVA: 0x003E7CB4 File Offset: 0x003E5EB4
		public static void CycleUseModes()
		{
			switch (LockOnHelper.UseMode)
			{
			case LockOnHelper.LockOnMode.FocusTarget:
				LockOnHelper.UseMode = LockOnHelper.LockOnMode.TargetClosest;
				return;
			case LockOnHelper.LockOnMode.TargetClosest:
				LockOnHelper.UseMode = LockOnHelper.LockOnMode.ThreeDS;
				return;
			case LockOnHelper.LockOnMode.ThreeDS:
				LockOnHelper.UseMode = LockOnHelper.LockOnMode.TargetClosest;
				return;
			default:
				return;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000E2D RID: 3629 RVA: 0x003E7CF0 File Offset: 0x003E5EF0
		public static NPC AimedTarget
		{
			get
			{
				if (LockOnHelper._pickedTarget == -1 || LockOnHelper._targets.Count < 1)
				{
					return null;
				}
				return Main.npc[LockOnHelper._targets[LockOnHelper._pickedTarget]];
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000E2E RID: 3630 RVA: 0x003E7D20 File Offset: 0x003E5F20
		public static Vector2 PredictedPosition
		{
			get
			{
				NPC aimedTarget = LockOnHelper.AimedTarget;
				if (aimedTarget == null)
				{
					return Vector2.Zero;
				}
				Vector2 vector = aimedTarget.Center;
				int num;
				Vector2 vector2;
				if (NPC.GetNPCLocation(LockOnHelper._targets[LockOnHelper._pickedTarget], true, false, out num, out vector2))
				{
					vector = vector2;
					vector += Main.npc[num].Distance(Main.player[Main.myPlayer].Center) / 2000f * Main.npc[num].velocity * 45f;
				}
				Player player = Main.player[Main.myPlayer];
				int num2 = ItemID.Sets.LockOnAimAbove[player.inventory[player.selectedItem].type];
				while (num2 > 0 && vector.Y > 100f)
				{
					Point point = vector.ToTileCoordinates();
					point.Y -= 4;
					if (!WorldGen.InWorld(point.X, point.Y, 10) || WorldGen.SolidTile(point.X, point.Y))
					{
						break;
					}
					vector.Y -= 16f;
					num2--;
				}
				float? num3 = ItemID.Sets.LockOnAimCompensation[player.inventory[player.selectedItem].type];
				if (num3.HasValue)
				{
					vector.Y -= (float)(aimedTarget.height / 2);
					Vector2 v = vector - player.Center;
					Vector2 vector3 = v.SafeNormalize(Vector2.Zero);
					vector3.Y -= 1f;
					float num4 = v.Length();
					num4 = (float)Math.Pow((double)(num4 / 700f), 2.0) * 700f;
					vector.Y += vector3.Y * num4 * num3.Value * 1f;
					vector.X += -vector3.X * num4 * num3.Value * 1f;
				}
				return vector;
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x003E7F18 File Offset: 0x003E6118
		public static void Update()
		{
			LockOnHelper._canLockOn = false;
			if (!PlayerInput.UsingGamepad)
			{
				LockOnHelper.SetActive(false);
				return;
			}
			if (--LockOnHelper._lifeTimeArrowDisplay < 0)
			{
				LockOnHelper._lifeTimeArrowDisplay = 0;
			}
			LockOnHelper.Handle3DSTarget();
			if (PlayerInput.Triggers.JustPressed.LockOn && !PlayerInput.WritingText)
			{
				LockOnHelper._lifeTimeCounter = 40;
				LockOnHelper._lifeTimeArrowDisplay = 30;
				LockOnHelper.HandlePressing();
			}
			if (!LockOnHelper._enabled)
			{
				return;
			}
			if (LockOnHelper.UseMode == LockOnHelper.LockOnMode.FocusTarget && PlayerInput.Triggers.Current.LockOn)
			{
				if (LockOnHelper._lifeTimeCounter <= 0)
				{
					LockOnHelper.SetActive(false);
					return;
				}
				LockOnHelper._lifeTimeCounter--;
			}
			NPC aimedTarget = LockOnHelper.AimedTarget;
			if (!LockOnHelper.ValidTarget(aimedTarget))
			{
				LockOnHelper.SetActive(false);
			}
			if (LockOnHelper.UseMode == LockOnHelper.LockOnMode.TargetClosest)
			{
				LockOnHelper.SetActive(false);
				LockOnHelper.SetActive(LockOnHelper.CanEnable());
			}
			if (!LockOnHelper._enabled)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			Vector2 predictedPosition = LockOnHelper.PredictedPosition;
			bool flag = false;
			if (LockOnHelper.ShouldLockOn(player) && (ItemID.Sets.LockOnIgnoresCollision[player.inventory[player.selectedItem].type] || Collision.CanHit(player.Center, 0, 0, predictedPosition, 0, 0) || Collision.CanHitLine(player.Center, 0, 0, predictedPosition, 0, 0) || Collision.CanHit(player.Center, 0, 0, aimedTarget.Center, 0, 0) || Collision.CanHitLine(player.Center, 0, 0, aimedTarget.Center, 0, 0)))
			{
				flag = true;
			}
			if (flag)
			{
				LockOnHelper._canLockOn = true;
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x003E8084 File Offset: 0x003E6284
		public static void SetUP()
		{
			if (!LockOnHelper._canLockOn)
			{
				return;
			}
			NPC arg_0D_0 = LockOnHelper.AimedTarget;
			LockOnHelper.SetLockPosition(Main.ReverseGravitySupport(LockOnHelper.PredictedPosition - Main.screenPosition, 0f));
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x003E80B4 File Offset: 0x003E62B4
		public static void SetDOWN()
		{
			if (!LockOnHelper._canLockOn)
			{
				return;
			}
			LockOnHelper.ResetLockPosition();
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x003E80C4 File Offset: 0x003E62C4
		private static bool ShouldLockOn(Player p)
		{
			int type = p.inventory[p.selectedItem].type;
			return type != 496;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x003E80F0 File Offset: 0x003E62F0
		public static void Toggle(bool forceOff = false)
		{
			LockOnHelper._lifeTimeCounter = 40;
			LockOnHelper._lifeTimeArrowDisplay = 30;
			LockOnHelper.HandlePressing();
			if (forceOff)
			{
				LockOnHelper._enabled = false;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x003E8110 File Offset: 0x003E6310
		public static bool Enabled
		{
			get
			{
				return LockOnHelper._enabled;
			}
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x003E8118 File Offset: 0x003E6318
		private static void Handle3DSTarget()
		{
			LockOnHelper._threeDSTarget = -1;
			if (LockOnHelper.UseMode != LockOnHelper.LockOnMode.ThreeDS)
			{
				return;
			}
			if (!PlayerInput.UsingGamepad)
			{
				return;
			}
			List<int> list = new List<int>();
			int num = -1;
			Utils.Swap<List<int>>(ref list, ref LockOnHelper._targets);
			Utils.Swap<int>(ref num, ref LockOnHelper._pickedTarget);
			LockOnHelper.RefreshTargets(Main.MouseWorld, 2000f);
			LockOnHelper.GetClosestTarget(Main.MouseWorld);
			Utils.Swap<List<int>>(ref list, ref LockOnHelper._targets);
			Utils.Swap<int>(ref num, ref LockOnHelper._pickedTarget);
			if (num >= 0)
			{
				LockOnHelper._threeDSTarget = list[num];
			}
			list.Clear();
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x003E81A4 File Offset: 0x003E63A4
		private static void HandlePressing()
		{
			if (LockOnHelper.UseMode == LockOnHelper.LockOnMode.TargetClosest)
			{
				LockOnHelper.SetActive(!LockOnHelper._enabled);
				return;
			}
			if (LockOnHelper.UseMode == LockOnHelper.LockOnMode.ThreeDS)
			{
				if (!LockOnHelper._enabled)
				{
					LockOnHelper.SetActive(true);
					return;
				}
				LockOnHelper.CycleTargetThreeDS();
				return;
			}
			else
			{
				if (!LockOnHelper._enabled)
				{
					LockOnHelper.SetActive(true);
					return;
				}
				LockOnHelper.CycleTargetFocus();
				return;
			}
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x003E81F8 File Offset: 0x003E63F8
		private static void CycleTargetFocus()
		{
			int num = LockOnHelper._targets[LockOnHelper._pickedTarget];
			LockOnHelper.RefreshTargets(Main.MouseWorld, 2000f);
			if (LockOnHelper._targets.Count < 1 || (LockOnHelper._targets.Count == 1 && num == LockOnHelper._targets[0]))
			{
				LockOnHelper.SetActive(false);
				return;
			}
			LockOnHelper._pickedTarget = 0;
			for (int i = 0; i < LockOnHelper._targets.Count; i++)
			{
				if (LockOnHelper._targets[i] > num)
				{
					LockOnHelper._pickedTarget = i;
					return;
				}
			}
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x003E8284 File Offset: 0x003E6484
		private static void CycleTargetThreeDS()
		{
			int num = LockOnHelper._targets[LockOnHelper._pickedTarget];
			LockOnHelper.RefreshTargets(Main.MouseWorld, 2000f);
			LockOnHelper.GetClosestTarget(Main.MouseWorld);
			if (LockOnHelper._targets.Count < 1 || (LockOnHelper._targets.Count == 1 && num == LockOnHelper._targets[0]) || num == LockOnHelper._targets[LockOnHelper._pickedTarget])
			{
				LockOnHelper.SetActive(false);
				return;
			}
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x003E82FC File Offset: 0x003E64FC
		private static bool CanEnable()
		{
			return !Main.player[Main.myPlayer].dead;
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x003E8314 File Offset: 0x003E6514
		private static void SetActive(bool on)
		{
			if (on)
			{
				if (!LockOnHelper.CanEnable())
				{
					return;
				}
				LockOnHelper.RefreshTargets(Main.MouseWorld, 2000f);
				LockOnHelper.GetClosestTarget(Main.MouseWorld);
				if (LockOnHelper._pickedTarget >= 0)
				{
					LockOnHelper._enabled = true;
					return;
				}
			}
			else
			{
				LockOnHelper._enabled = false;
				LockOnHelper._targets.Clear();
				LockOnHelper._lifeTimeCounter = 0;
			}
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x003E836C File Offset: 0x003E656C
		private static void RefreshTargets(Vector2 position, float radius)
		{
			LockOnHelper._targets.Clear();
			Rectangle rectangle = Utils.CenteredRectangle(Main.player[Main.myPlayer].Center, new Vector2(1920f, 1200f));
			Vector2 center = Main.player[Main.myPlayer].Center;
			Vector2 value = Main.player[Main.myPlayer].DirectionTo(Main.MouseWorld);
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC nPC = Main.npc[i];
				if (LockOnHelper.ValidTarget(nPC) && nPC.Distance(position) <= radius && rectangle.Intersects(nPC.Hitbox) && Lighting.GetSubLight(nPC.Center).Length() / 3f >= 0.01f && (LockOnHelper.UseMode != LockOnHelper.LockOnMode.ThreeDS || Vector2.Dot(nPC.DirectionFrom(center), value) >= 0.65f))
				{
					LockOnHelper._targets.Add(i);
				}
			}
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x003E845C File Offset: 0x003E665C
		private static void GetClosestTarget(Vector2 position)
		{
			LockOnHelper._pickedTarget = -1;
			float num = -1f;
			if (LockOnHelper.UseMode == LockOnHelper.LockOnMode.ThreeDS)
			{
				Vector2 center = Main.player[Main.myPlayer].Center;
				Vector2 value = Main.player[Main.myPlayer].DirectionTo(Main.MouseWorld);
				for (int i = 0; i < LockOnHelper._targets.Count; i++)
				{
					int num2 = LockOnHelper._targets[i];
					NPC expr_54 = Main.npc[num2];
					float num3 = Vector2.Dot(expr_54.DirectionFrom(center), value);
					if (LockOnHelper.ValidTarget(expr_54) && (LockOnHelper._pickedTarget == -1 || num3 > num))
					{
						LockOnHelper._pickedTarget = i;
						num = num3;
					}
				}
				return;
			}
			for (int j = 0; j < LockOnHelper._targets.Count; j++)
			{
				int num4 = LockOnHelper._targets[j];
				NPC nPC = Main.npc[num4];
				if (LockOnHelper.ValidTarget(nPC) && (LockOnHelper._pickedTarget == -1 || nPC.Distance(position) < num))
				{
					LockOnHelper._pickedTarget = j;
					num = nPC.Distance(position);
				}
			}
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x003E8558 File Offset: 0x003E6758
		private static bool ValidTarget(NPC n)
		{
			return n != null && n.active && !n.dontTakeDamage && !n.friendly && !n.townNPC && n.life >= 1 && !n.immortal && (n.aiStyle != 25 || n.ai[0] != 0f);
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x003E85B8 File Offset: 0x003E67B8
		private static void SetLockPosition(Vector2 position)
		{
			PlayerInput.LockOnCachePosition();
			Main.mouseX = (PlayerInput.MouseX = (int)position.X);
			Main.mouseY = (PlayerInput.MouseY = (int)position.Y);
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x003E85E4 File Offset: 0x003E67E4
		private static void ResetLockPosition()
		{
			PlayerInput.LockOnUnCachePosition();
			Main.mouseX = PlayerInput.MouseX;
			Main.mouseY = PlayerInput.MouseY;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x003E8600 File Offset: 0x003E6800
		public static void Draw(SpriteBatch spriteBatch)
		{
			if (Main.gameMenu)
			{
				return;
			}
			Texture2D lockOnCursorTexture = Main.LockOnCursorTexture;
			Rectangle rectangle = new Rectangle(0, 0, lockOnCursorTexture.Width, 12);
			Rectangle rectangle2 = new Rectangle(0, 16, lockOnCursorTexture.Width, 12);
			Color color = Main.OurFavoriteColor.MultiplyRGBA(new Color(0.75f, 0.75f, 0.75f, 1f));
			color.A = 220;
			Color value = Main.OurFavoriteColor;
			value.A = 220;
			float scale = 0.94f + (float)Math.Sin((double)(Main.GlobalTime * 6.28318548f)) * 0.06f;
			value *= scale;
			color *= scale;
			Utils.Swap<Color>(ref color, ref value);
			Color value2 = color.MultiplyRGBA(new Color(0.8f, 0.8f, 0.8f, 0.8f));
			Color value3 = color.MultiplyRGBA(new Color(0.8f, 0.8f, 0.8f, 0.8f));
			float gravDir = Main.player[Main.myPlayer].gravDir;
			float scaleFactor = 1f;
			float num = 0.1f;
			float scaleFactor2 = 0.8f;
			float num2 = 1f;
			float num3 = 10f;
			float num4 = 10f;
			bool flag = false;
			for (int i = 0; i < LockOnHelper._drawProgress.GetLength(0); i++)
			{
				int num5 = 0;
				if (LockOnHelper._pickedTarget != -1 && LockOnHelper._targets.Count > 0 && i == LockOnHelper._targets[LockOnHelper._pickedTarget])
				{
					num5 = 2;
				}
				else if ((flag && LockOnHelper._targets.Contains(i)) || (LockOnHelper.UseMode == LockOnHelper.LockOnMode.ThreeDS && LockOnHelper._threeDSTarget == i))
				{
					num5 = 1;
				}
				LockOnHelper._drawProgress[i, 0] = MathHelper.Clamp(LockOnHelper._drawProgress[i, 0] + ((num5 == 1) ? num : (-num)), 0f, 1f);
				LockOnHelper._drawProgress[i, 1] = MathHelper.Clamp(LockOnHelper._drawProgress[i, 1] + ((num5 == 2) ? num : (-num)), 0f, 1f);
				float num6 = LockOnHelper._drawProgress[i, 0];
				if (num6 > 0f)
				{
					float num7 = 1f - num6 * num6;
					Vector2 vector = Main.npc[i].Top + new Vector2(0f, -num4 - num7 * num3) - Main.screenPosition;
					vector = Main.ReverseGravitySupport(vector, (float)Main.npc[i].height);
					spriteBatch.Draw(lockOnCursorTexture, vector, new Rectangle?(rectangle), value2 * num6, 0f, rectangle.Size() / 2f, new Vector2(0.58f, 1f) * scaleFactor * scaleFactor2 * (1f + num6) / 2f, SpriteEffects.None, 0f);
					spriteBatch.Draw(lockOnCursorTexture, vector, new Rectangle?(rectangle2), value3 * num6 * num6, 0f, rectangle2.Size() / 2f, new Vector2(0.58f, 1f) * scaleFactor * scaleFactor2 * (1f + num6) / 2f, SpriteEffects.None, 0f);
				}
				float num8 = LockOnHelper._drawProgress[i, 1];
				if (num8 > 0f)
				{
					int num9 = Main.npc[i].width;
					if (Main.npc[i].height > num9)
					{
						num9 = Main.npc[i].height;
					}
					num9 += 20;
					if ((float)num9 < 70f)
					{
						num2 *= (float)num9 / 70f;
					}
					float num10 = 3f;
					Vector2 value4 = Main.npc[i].Center;
					int num11;
					Vector2 vector2;
					if (LockOnHelper._targets.Count >= 0 && LockOnHelper._pickedTarget >= 0 && LockOnHelper._pickedTarget < LockOnHelper._targets.Count && i == LockOnHelper._targets[LockOnHelper._pickedTarget] && NPC.GetNPCLocation(i, true, false, out num11, out vector2))
					{
						value4 = vector2;
					}
					int num12 = 0;
					while ((float)num12 < num10)
					{
						float num13 = 6.28318548f / num10 * (float)num12 + Main.GlobalTime * 6.28318548f * 0.25f;
						Vector2 value5 = new Vector2(0f, (float)(num9 / 2)).RotatedBy((double)num13, default(Vector2));
						Vector2 vector3 = value4 + value5 - Main.screenPosition;
						vector3 = Main.ReverseGravitySupport(vector3, 0f);
						float rotation = num13 * (float)((gravDir == 1f) ? 1 : -1) + 3.14159274f * (float)((gravDir == 1f) ? 1 : 0);
						spriteBatch.Draw(lockOnCursorTexture, vector3, new Rectangle?(rectangle), color * num8, rotation, rectangle.Size() / 2f, new Vector2(0.58f, 1f) * scaleFactor * num2 * (1f + num8) / 2f, SpriteEffects.None, 0f);
						spriteBatch.Draw(lockOnCursorTexture, vector3, new Rectangle?(rectangle2), value * num8 * num8, rotation, rectangle2.Size() / 2f, new Vector2(0.58f, 1f) * scaleFactor * num2 * (1f + num8) / 2f, SpriteEffects.None, 0f);
						num12++;
					}
				}
			}
		}

		// Token: 0x04002F96 RID: 12182
		private const float LOCKON_RANGE = 2000f;

		// Token: 0x04002F97 RID: 12183
		private const int LOCKON_HOLD_LIFETIME = 40;

		// Token: 0x04002F98 RID: 12184
		public static LockOnHelper.LockOnMode UseMode = LockOnHelper.LockOnMode.ThreeDS;

		// Token: 0x04002F99 RID: 12185
		private static bool _enabled;

		// Token: 0x04002F9A RID: 12186
		private static bool _canLockOn = false;

		// Token: 0x04002F9B RID: 12187
		private static List<int> _targets = new List<int>();

		// Token: 0x04002F9C RID: 12188
		private static int _pickedTarget;

		// Token: 0x04002F9D RID: 12189
		private static int _lifeTimeCounter;

		// Token: 0x04002F9E RID: 12190
		private static int _lifeTimeArrowDisplay;

		// Token: 0x04002F9F RID: 12191
		private static int _threeDSTarget = -1;

		// Token: 0x04002FA0 RID: 12192
		private static float[,] _drawProgress = new float[200, 2];

		// Token: 0x02000282 RID: 642
		public enum LockOnMode
		{
			// Token: 0x04003C60 RID: 15456
			FocusTarget,
			// Token: 0x04003C61 RID: 15457
			TargetClosest,
			// Token: 0x04003C62 RID: 15458
			ThreeDS
		}
	}
}
