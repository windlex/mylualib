using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
	// Token: 0x02000189 RID: 393
	public struct DrawData
	{
		// Token: 0x060012A6 RID: 4774 RVA: 0x004189EC File Offset: 0x00416BEC
		public DrawData(Texture2D texture, Vector2 position, Color color)
		{
			this.texture = texture;
			this.position = position;
			this.color = color;
			this.destinationRectangle = default(Rectangle);
			this.sourceRect = DrawData.nullRectangle;
			this.rotation = 0f;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.effect = SpriteEffects.None;
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x00418A64 File Offset: 0x00416C64
		public DrawData(Texture2D texture, Vector2 position, Rectangle? sourceRect, Color color)
		{
			this.texture = texture;
			this.position = position;
			this.color = color;
			this.destinationRectangle = default(Rectangle);
			this.sourceRect = sourceRect;
			this.rotation = 0f;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.effect = SpriteEffects.None;
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x00418AD8 File Offset: 0x00416CD8
		public DrawData(Texture2D texture, Vector2 position, Rectangle? sourceRect, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effect, int inactiveLayerDepth)
		{
			this.texture = texture;
			this.position = position;
			this.sourceRect = sourceRect;
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.scale = new Vector2(scale, scale);
			this.effect = effect;
			this.destinationRectangle = default(Rectangle);
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x00418B4C File Offset: 0x00416D4C
		public DrawData(Texture2D texture, Vector2 position, Rectangle? sourceRect, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, int inactiveLayerDepth)
		{
			this.texture = texture;
			this.position = position;
			this.sourceRect = sourceRect;
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.scale = scale;
			this.effect = effect;
			this.destinationRectangle = default(Rectangle);
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x00418BB8 File Offset: 0x00416DB8
		public DrawData(Texture2D texture, Rectangle destinationRectangle, Color color)
		{
			this.texture = texture;
			this.destinationRectangle = destinationRectangle;
			this.color = color;
			this.position = Vector2.Zero;
			this.sourceRect = DrawData.nullRectangle;
			this.rotation = 0f;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.effect = SpriteEffects.None;
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x00418C30 File Offset: 0x00416E30
		public DrawData(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRect, Color color)
		{
			this.texture = texture;
			this.destinationRectangle = destinationRectangle;
			this.color = color;
			this.position = Vector2.Zero;
			this.sourceRect = sourceRect;
			this.rotation = 0f;
			this.origin = Vector2.Zero;
			this.scale = Vector2.One;
			this.effect = SpriteEffects.None;
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x00418CA4 File Offset: 0x00416EA4
		public DrawData(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRect, Color color, float rotation, Vector2 origin, SpriteEffects effect, int inactiveLayerDepth)
		{
			this.texture = texture;
			this.destinationRectangle = destinationRectangle;
			this.sourceRect = sourceRect;
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.effect = effect;
			this.position = Vector2.Zero;
			this.scale = Vector2.One;
			this.shader = 0;
			this.ignorePlayerRotation = false;
			this.useDestinationRectangle = false;
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x00418D14 File Offset: 0x00416F14
		public void Draw(SpriteBatch sb)
		{
			if (this.useDestinationRectangle)
			{
				sb.Draw(this.texture, this.destinationRectangle, this.sourceRect, this.color, this.rotation, this.origin, this.effect, 0f);
				return;
			}
			sb.Draw(this.texture, this.position, this.sourceRect, this.color, this.rotation, this.origin, this.scale, this.effect, 0f);
		}

		// Token: 0x0400344F RID: 13391
		public Texture2D texture;

		// Token: 0x04003450 RID: 13392
		public Vector2 position;

		// Token: 0x04003451 RID: 13393
		public Rectangle destinationRectangle;

		// Token: 0x04003452 RID: 13394
		public Rectangle? sourceRect;

		// Token: 0x04003453 RID: 13395
		public Color color;

		// Token: 0x04003454 RID: 13396
		public float rotation;

		// Token: 0x04003455 RID: 13397
		public Vector2 origin;

		// Token: 0x04003456 RID: 13398
		public Vector2 scale;

		// Token: 0x04003457 RID: 13399
		public SpriteEffects effect;

		// Token: 0x04003458 RID: 13400
		public int shader;

		// Token: 0x04003459 RID: 13401
		public bool ignorePlayerRotation;

		// Token: 0x0400345A RID: 13402
		public readonly bool useDestinationRectangle;

		// Token: 0x0400345B RID: 13403
		public static Rectangle? nullRectangle;
	}
}
