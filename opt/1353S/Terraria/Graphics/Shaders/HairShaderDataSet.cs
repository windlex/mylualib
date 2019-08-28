using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000EB RID: 235
	public class HairShaderDataSet
	{
		// Token: 0x06000D90 RID: 3472 RVA: 0x003E4BF1 File Offset: 0x003E2DF1
		public void Apply(short shaderId, Player player, DrawData? drawData = null)
		{
			if (shaderId != 0 && shaderId <= (short)this._shaderDataCount)
			{
				this._shaderData[(int)(shaderId - 1)].Apply(player, drawData);
				return;
			}
			Main.pixelShader.CurrentTechnique.Passes[0].Apply();
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x003E4B9C File Offset: 0x003E2D9C
		public T BindShader<T>(int itemId, T shaderData) where T : HairShaderData
		{
			if (this._shaderDataCount == 255)
			{
				throw new Exception("Too many shaders bound.");
			}
			Dictionary<int, short> arg_31_0 = this._shaderLookupDictionary;
			byte b = (byte)(this._shaderDataCount + 1);
			this._shaderDataCount = b;
			arg_31_0[itemId] = (short)b;
			this._shaderData.Add(shaderData);
			return shaderData;
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x003E4C2F File Offset: 0x003E2E2F
		public Color GetColor(short shaderId, Player player, Color lightColor)
		{
			if (shaderId != 0 && shaderId <= (short)this._shaderDataCount)
			{
				return this._shaderData[(int)(shaderId - 1)].GetColor(player, lightColor);
			}
			return new Color(lightColor.ToVector4() * player.hairColor.ToVector4());
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x003E4C6F File Offset: 0x003E2E6F
		public HairShaderData GetShaderFromItemId(int type)
		{
			if (this._shaderLookupDictionary.ContainsKey(type))
			{
				return this._shaderData[(int)(this._shaderLookupDictionary[type] - 1)];
			}
			return null;
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x003E4C9A File Offset: 0x003E2E9A
		public short GetShaderIdFromItemId(int type)
		{
			if (this._shaderLookupDictionary.ContainsKey(type))
			{
				return this._shaderLookupDictionary[type];
			}
			return -1;
		}

		// Token: 0x04002F3C RID: 12092
		protected List<HairShaderData> _shaderData = new List<HairShaderData>();

		// Token: 0x04002F3E RID: 12094
		protected byte _shaderDataCount;

		// Token: 0x04002F3D RID: 12093
		protected Dictionary<int, short> _shaderLookupDictionary = new Dictionary<int, short>();
	}
}
