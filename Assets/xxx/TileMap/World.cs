using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
	public string name;

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
}
