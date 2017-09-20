using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class World : MonoBehaviour {
	public string Name;
	public int sizeX;
	public int sizeY;

	public int m_nCenterRegionX;
	public int m_nCenterRegionY;

	static int nSightWidthRegion = 3;
	static int nSightHeightRegion = 3;

	List<Region> m_ToBeUpdateRegion = new List<Region>();

	Dictionary<int, Region>	m_RegionMap = new Dictionary<int,Region>();

	public void Initialize()
	{
	}

	void Update()
	{
		IEnumerator coroutine = UpdateRegions();
		while (coroutine.MoveNext());
	}

	public IEnumerator UpdateRegions()
	{
		while (m_ToBeUpdateRegion.Count > 0)
		{
			m_ToBeUpdateRegion[0].Refresh();
			m_ToBeUpdateRegion.RemoveAt(0);
			yield return null;
		}
	}

	public static World Create(string worldName) 
	{
		TileMapConfig.WorldConfig config = TileMapConfig.Instance.GetWorldConfig(worldName);
		GameObject worldObj = new GameObject();
		worldObj.name = config.Name;
		World world = worldObj.AddComponent<World>();
		world.name = config.Name;
		world.sizeX = config.sizeX;
		world.sizeY = config.sizeY;
		return world;
	}
	public bool Load(string worldName)
	{
		
		Debug.LogError("To Do Load World");
		return true;
	}
	public void SaveMap()
	{

	}

	public static int GetRegionIdx(int rx, int ry)
	{
		int regionIdx = ((rx & 0xFFFF) << 16) | (ry & 0xFFFF);
		return regionIdx;
	}
	public void EnterPos(int cx, int cy)
	{
		int rx = cx / TileMap.RegionPWidth;
		int ry = cy / TileMap.RegionPHeight;
		LoadRegions(rx, ry);
	}
	public void LoadRegions(int rx, int ry)
	{
		int xFrom = rx - (nSightWidthRegion / 2);
		int xTo = xFrom + nSightWidthRegion;
		int yFrom = ry - (nSightHeightRegion / 2);
		int yTo = yFrom + nSightHeightRegion;
		for (int sx = xFrom; sx < xTo; ++sx)
		{
			for (int sy = yFrom; sy < yTo; ++sy)
			{
				LoadARegion(sx, sy);
			}
		}
	}
	public Region LoadARegion(int rx, int ry)
	{
		int regionIdx = GetRegionIdx(rx, ry);
		Region region = null;
		if (m_RegionMap.TryGetValue(regionIdx, out region))
		{
			return region;
		}

		GameObject regionObj = new GameObject();
		regionObj.name = "Region" + "_" + rx + "_" + ry;
		regionObj.transform.SetParent(this.transform, false);
		region = regionObj.AddComponent<Region>();
		m_RegionMap.Add(regionIdx, region);
		region.Initialze(this, rx, ry);
		return region;
	}

	public void ClearMap()
	{

	}
	public Cell GetCell(int cx, int cy, int layer)
	{
		int rx = cx / TileMap.RegionPWidth;
		int ry = cy / TileMap.RegionPHeight;
		Region region = LoadARegion(rx, ry);
		return region.GetCell(layer, cx - region.rx, cy - region.ry);
	}
	public void SetCell(int cx, int cy, eTileType Type, int layerIdx, bool bRefresh = true)
	{
		int rx = cx / TileMap.RegionPWidth;
		int ry = cy / TileMap.RegionPHeight;
		Region region = LoadARegion(rx, ry);
		region.SetCell(layerIdx, cx - region.rx, cy - region.ry, Type);
		if (bRefresh)
		{
			for (int xf = -1; xf < 2; xf++)
			{
				for (int yf = -1; yf < 2; yf++)
				{
					RefreshTile(cx + xf, cy + yf, layerIdx);
				}
			}
		}
	}
	public void RefreshTile(int cx, int cy, int layer)
	{
		int rx = cx / TileMap.RegionPWidth;
		int ry = cy / TileMap.RegionPHeight;
		Region region = LoadARegion(rx, ry);
		region.RefreshTile(layer, cx - region.rx, cy - region.ry);
	}

	public void GenerateWorld() 
	{
		bool isWarning = sizeX * sizeY >= 400 * 400;
		string sWarning = "\n\nMap is too big. This can take up to several minutes.";
		//bool isOk = EditorUtility.DisplayDialog("Generate Map...", "Are you sure?" + (isWarning? sWarning : ""), "Yes", "No");
		//if (!isOk)
		//	return;

		ClearMap();

		// set the right layer index if default layers are changed
		int gndLayer = 0;
		int gndOverlay = 1;                    

		float fDiv = 25f;
		float xf = Random.value * 100;
		float yf = Random.value * 100;
		for (int i = 0; i < sizeX; i++)
		{
			for (int j = 0; j < sizeY; j++)
			{
				float fRand = Random.value;
				float noise = Mathf.PerlinNoise((i + xf) / fDiv, (j + yf) / fDiv);
				//Debug.Log( "noise: "+noise+"; i: "+i+"; j: "+j );
				if (noise < 0.3) //water
				{
					SetCell(i, j, eTileType.ETT_GROUND, gndLayer, false);
				}
				else if (noise < 0.4) // water plants
				{
					SetCell(i, j, eTileType.ETT_WATER, gndLayer, false);
					if (fRand < noise / 3)
						SetCell(i, j, eTileType.ETT_WATER, gndOverlay, false);
				}
				else if (noise < 0.5 && fRand < (1 - noise / 2)) // dark grass
				{
					SetCell(i, j, eTileType.ETT_GROUND, gndLayer, false);
				}
				else if (noise < 0.6 && fRand < (1 - 1.2 * noise)) // flowers
				{
					//MyAutoTileMap.AddAutoTile( i, j, 24, (int)AutoTileMap.eTileLayer.GROUND);
					SetCell(i, j, eTileType.ETT_GROUND, gndLayer, false);
					SetCell(i, j, eTileType.ETT_GROUND + Random.Range(0, 5), gndOverlay, false);
				}
				else if (noise < 0.7) // grass
				{
					SetCell(i, j, eTileType.ETT_GROUND, gndLayer, false);
				}
				else // mountains
				{
					SetCell(i, j, eTileType.ETT_ROAD, gndLayer, false);
				}
			}
		}
		float now, now2;
		now = Time.realtimeSinceStartup;

		//now2 = Time.realtimeSinceStartup;
		//RefreshAllTiles();
		//Debug.Log("RefreshAllTiles execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		now2 = Time.realtimeSinceStartup;
		SaveMap();
		Debug.Log("SaveMap execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		//RefreshMinimapTexture();

		now2 = Time.realtimeSinceStartup;
		Update();
		Debug.Log("UpdateChunks execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		//Debug.Log("Total execution time(ms): " + (Time.realtimeSinceStartup - now) * 1000);
	}
}
