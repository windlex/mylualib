using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {
	public static TileMap Instance;
	public Tilesets		tilesets;
	public World		curWorld;

	public static int	CellWidth = 32;		// 单位=pixel
	public static int	CellHeight = 32;
	public static int	RegionWidth = 25;		// 单位=cell
	public static int	RegionHeight = 25;
	public static int	RegionPWidth = RegionWidth * CellWidth;		// 单位=pixel
	public static int	RegionPHeight = RegionHeight * CellHeight;

	public Dictionary<string, World>	worlds = new Dictionary<string,World>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(transform.gameObject);
		}
	}

	public void EnterWorld(string worldName, int x, int y)
	{
		if (!curWorld || worldName != curWorld.name) 
		{ 
			World world;
			if (!worlds.TryGetValue(worldName, out world))
			{
				world = World.LoadWorld(worldName);
				if (!world)
				{
					Debug.LogError("No World Named " + worldName);
					return;
				}
				worlds.Add(worldName, world);
			}
			curWorld = world;
		}
		curWorld.EnterPos(x, y);
	}

	public TileConfig tileConfig;
	public static TileConfig.WorldConfig GetWorldConfig(string name)
	{
		return Instance.tileConfig.GetWorldConfig(name);
	}
}
