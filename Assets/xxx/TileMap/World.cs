using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
	public string name;
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

	void update()
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

	public static World LoadWorld(string worldName) 
	{
		TileConfig.WorldConfig config = TileMap.GetWorldConfig(worldName);
		GameObject worldObj = new GameObject();
		worldObj.name = config.Name;
		World world = worldObj.AddComponent<World>();
		world.name = config.Name;
		world.sizeX = config.sizeX;
		world.sizeY = config.sizeY;

		if (!world.Load(worldName))
			return null;

		return world;
	}
	public bool Load(string worldName)
	{
		
		Debug.LogError("To Do Load World");
		return true;
	}

	public static int GetRegionIdx(int rx, int ry)
	{
		int regionIdx = ((rx & 0xFFFF) << 16) | (ry & 0xFFFF);
		return regionIdx;
	}
	public void EnterPos(int x, int y)
	{
		int rx = x / TileMap.RegionPWidth;
		int ry = y / TileMap.RegionPHeight;
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
	public bool LoadARegion(int rx, int ry)
	{
		int regionIdx = GetRegionIdx(rx, ry);
		if (m_RegionMap.ContainsKey(regionIdx)){
			return true;
		}
		GameObject regionObj = new GameObject();
		regionObj.name = "Region" + "_" + rx + "_" + ry;
		regionObj.transform.SetParent(this.transform, false);
		Region region = regionObj.AddComponent<Region>();
		m_RegionMap.Add(regionIdx, region);
		region.Initialze(this, rx, ry);
		return true;
	}

	public void ClearMap()
	{

	}
	public void SetCell(int cx, int cy, eTileType Type, int layerIdx, bool bRefresh)
	{

	}
	public void GenerateWorld() 
	{
		bool isWarning = MyAutoTileMap.MapTileWidth * MyAutoTileMap.MapTileHeight >= 400 * 400;
		string sWarning = "\n\nMap is too big. This can take up to several minutes.";
		bool isOk = EditorUtility.DisplayDialog("Generate Map...", "Are you sure?" + (isWarning? sWarning : ""), "Yes", "No");
		if (!isOk)
			return;

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
						SetCell(i, j, 5, gndOverlay, false);
				}
				else if (noise < 0.5 && fRand < (1 - noise / 2)) // dark grass
				{
					SetCell(i, j, eTileType.ETT_GRASS, gndLayer, false);
				}
				else if (noise < 0.6 && fRand < (1 - 1.2 * noise)) // flowers
				{
					//MyAutoTileMap.AddAutoTile( i, j, 24, (int)AutoTileMap.eTileLayer.GROUND);
					SetCell(i, j, 144, gndLayer, false);
					SetCell(i, j, 288 + Random.Range(0, 5), gndOverlay, false);
				}
				else if (noise < 0.7) // grass
				{
					SetCell(i, j, eTileType.ETT_GRASS, gndLayer, false);
				}
				else // mountains
				{
					SetCell(i, j, eTileType.ETT_ROAD, gndLayer, false);
				}
			}
		}
		//float now, now2;
		//now = Time.realtimeSinceStartup;

		//now2 = Time.realtimeSinceStartup;
		MyAutoTileMap.RefreshAllTiles();
		//Debug.Log("RefreshAllTiles execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		//now2 = Time.realtimeSinceStartup;
		MyAutoTileMap.SaveMap();
		//Debug.Log("SaveMap execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		MyAutoTileMap.RefreshMinimapTexture();

		//now2 = Time.realtimeSinceStartup;
		MyAutoTileMap.UpdateChunks();
		//Debug.Log("UpdateChunks execution time(ms): " + (Time.realtimeSinceStartup - now2) * 1000);

		//Debug.Log("Total execution time(ms): " + (Time.realtimeSinceStartup - now) * 1000);
	}
}
