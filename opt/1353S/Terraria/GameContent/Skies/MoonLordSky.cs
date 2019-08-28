using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000163 RID: 355
	public class MoonLordSky : CustomSky
	{
		// Token: 0x060011AD RID: 4525 RVA: 0x0040EB68 File Offset: 0x0040CD68
		public override void OnLoad()
		{
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x0040EB6C File Offset: 0x0040CD6C
		public override void Update(GameTime gameTime)
		{
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0040EB70 File Offset: 0x0040CD70
		private float GetIntensity()
		{
			if (this.UpdateMoonLordIndex())
			{
				float x = 0f;
				if (this._moonLordIndex != -1)
				{
					x = Vector2.Distance(Main.player[Main.myPlayer].Center, Main.npc[this._moonLordIndex].Center);
				}
				return 1f - Utils.SmoothStep(3000f, 6000f, x);
			}
			return 0f;
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0040EBD8 File Offset: 0x0040CDD8
		public override Color OnTileColor(Color inColor)
		{
			float intensity = this.GetIntensity();
			return new Color(Vector4.Lerp(new Vector4(0.5f, 0.8f, 1f, 1f), inColor.ToVector4(), 1f - intensity));
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0040EC20 File Offset: 0x0040CE20
		private bool UpdateMoonLordIndex()
		{
			if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
			{
				return true;
			}
			int num = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 398)
				{
					num = i;
					break;
				}
			}
			this._moonLordIndex = num;
			return num != -1;
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x0040ECAC File Offset: 0x0040CEAC
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0f && minDepth < 0f)
			{
				float intensity = this.GetIntensity();
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * intensity);
			}
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x0040ECF8 File Offset: 0x0040CEF8
		public override float GetCloudAlpha()
		{
			return 0f;
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0040ED00 File Offset: 0x0040CF00
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._isActive = true;
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x0040ED0C File Offset: 0x0040CF0C
		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0040ED18 File Offset: 0x0040CF18
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0040ED24 File Offset: 0x0040CF24
		public override bool IsActive()
		{
			return this._isActive;
		}

		// Token: 0x04003224 RID: 12836
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003225 RID: 12837
		private bool _isActive;

		// Token: 0x04003226 RID: 12838
		private int _moonLordIndex = -1;
	}
}
