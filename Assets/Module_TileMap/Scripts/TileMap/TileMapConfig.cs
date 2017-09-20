using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileMapConfig : SingletonMono<TileMapConfig>
{
	[System.Serializable]
	public class LayerConfig
	{
		public bool Visible = true;
		public string Name = "layer";
		public float Depth = 0;
	}
	public List<LayerConfig>	layerConfig = new List<LayerConfig>();

	[System.Serializable]
	public class WorldConfig
	{
		public string Name = "world";
		public int sizeX = 200;
		public int sizeY = 200;
	}
	public Dictionary<string, WorldConfig> WorldConfigs = new Dictionary<string, WorldConfig>();
	public List<WorldConfig>	WorldConfigList = new List<WorldConfig>();
	public WorldConfig GetWorldConfig(string worldName)
	{
		for (int i = 0; i < WorldConfigList.Count; i++)
		{
			if (WorldConfigList[i].Name == worldName)
				return WorldConfigList[i];
		}
		return null;
	}

	[System.Serializable]
	public class TileTemplate
	{
		public int Id;
		public eTilePartType[] m_TilePartsType;
		public int[] m_TilePartsIdx;
		public int m_TilePartsLength;
	}
	[System.Serializable]
	public class TileConfig
	{
		public eTileType Type;
		public List<TileTemplate>	tileTemplates = new List<TileTemplate>();
	}
	[SerializeField]
	public Dictionary<eTileType, TileConfig> tileTempConfig = new Dictionary<eTileType, TileConfig>();
	public List<TileConfig> TileTemplateList = new List<TileConfig>();
	public TileTemplate GetTileTemplate(eTileType eType, int Id)
	{
		return tileTempConfig[eType].tileTemplates[0];
	}




}