using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConfig : MonoBehaviour
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
}