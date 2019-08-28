using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000EA RID: 234
	public class ArmorShaderDataSet
	{
		// Token: 0x06000D88 RID: 3464 RVA: 0x003E5508 File Offset: 0x003E3708
		public T BindShader<T>(int itemId, T shaderData) where T : ArmorShaderData
		{
			Dictionary<int, int> arg_18_0 = this._shaderLookupDictionary;
			int num = this._shaderDataCount + 1;
			this._shaderDataCount = num;
			arg_18_0[itemId] = num;
			this._shaderData.Add(shaderData);
			return shaderData;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x003E5544 File Offset: 0x003E3744
		public void Apply(int shaderId, Entity entity, DrawData? drawData = null)
		{
			if (shaderId != 0 && shaderId <= this._shaderDataCount)
			{
				this._shaderData[shaderId - 1].Apply(entity, drawData);
				return;
			}
			Main.pixelShader.CurrentTechnique.Passes[0].Apply();
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x003E5584 File Offset: 0x003E3784
		public void ApplySecondary(int shaderId, Entity entity, DrawData? drawData = null)
		{
			if (shaderId != 0 && shaderId <= this._shaderDataCount)
			{
				this._shaderData[shaderId - 1].GetSecondaryShader(entity).Apply(entity, drawData);
				return;
			}
			Main.pixelShader.CurrentTechnique.Passes[0].Apply();
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x003E55D4 File Offset: 0x003E37D4
		public ArmorShaderData GetShaderFromItemId(int type)
		{
			if (this._shaderLookupDictionary.ContainsKey(type))
			{
				return this._shaderData[this._shaderLookupDictionary[type] - 1];
			}
			return null;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x003E5600 File Offset: 0x003E3800
		public int GetShaderIdFromItemId(int type)
		{
			if (this._shaderLookupDictionary.ContainsKey(type))
			{
				return this._shaderLookupDictionary[type];
			}
			return 0;
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x003E5620 File Offset: 0x003E3820
		public ArmorShaderData GetSecondaryShader(int id, Player player)
		{
			if (id != 0 && id <= this._shaderDataCount && this._shaderData[id - 1] != null)
			{
				return this._shaderData[id - 1].GetSecondaryShader(player);
			}
			return null;
		}

		// Token: 0x04002F39 RID: 12089
		protected List<ArmorShaderData> _shaderData = new List<ArmorShaderData>();

		// Token: 0x04002F3A RID: 12090
		protected Dictionary<int, int> _shaderLookupDictionary = new Dictionary<int, int>();

		// Token: 0x04002F3B RID: 12091
		protected int _shaderDataCount;
	}
}
