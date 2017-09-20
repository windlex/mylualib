using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {

	public World world;
	public int rx = -1;
	public int ry = -1;

	[System.Serializable]
	public class Layer
	{
		public GameObject	layerObject;
		public SubRegion	subRegion;
	}
	[SerializeField]
	public List<Layer> Layers = new List<Layer>();

	public void Initialze(World world, int rx, int ry)
	{
		this.world = world;
		this.rx = rx;
		this.ry = ry;
		Layers.Clear();
		foreach(TileMapConfig.LayerConfig layerConfig in TileMapConfig.Instance.layerConfig)
		{
			GameObject layerObj = new GameObject();
			layerObj.name = layerConfig.Name;
			layerObj.transform.SetParent(transform, false);
			Layer layer = new Layer();
			layer.layerObject = layerObj;
			layer.subRegion = layerObj.AddComponent<SubRegion>();
			Layers.Add(layer);
		}
		Load();
		Refresh();
	}
	public void Load()
	{
	
	}
	public void Save()
	{

	}

	public void Refresh()
	{
		foreach (Layer layer in Layers)
		{
			layer.subRegion.Refresh();
		}
	}
	
	public Cell GetCell(int layer, int cx, int cy)
	{
		return Layers[layer].subRegion.GetCell(cx, cy);
	}
	public void SetCell(int layer, int cx, int cy, eTileType etype)
	{
		Layers[layer].subRegion.SetCell(cx, cy, etype);
	}
	public void RefreshTile(int layer, int cx, int cy)
	{
		Layers[layer].subRegion.RefreshTile(layer, cx, cy);
	}
}

public class SubRegion : MonoBehaviour
{
	public static int CellCount = TileMap.RegionWidth * TileMap.RegionHeight;

	private Vector3[] m_vertices;
	private Vector2[] m_uv;
	private int[] m_triangles;
	private Color32[] m_colors;
	private MeshFilter m_meshFilter = new MeshFilter();
	public Cell[] m_Cells = new Cell[CellCount];

	public static int GetCellIdx(int cx, int cy)
	{
		return cy * TileMap.RegionWidth + cx;
	}
	public Cell GetCell(int cx, int cy)
	{
		int cellIdx = GetCellIdx(cx, cy);
		return m_Cells[cellIdx];
	}
	public void SetCell(int cx, int cy, eTileType etype)
	{
		int cellIdx = GetCellIdx(cx, cy);
		if (m_Cells[cellIdx] == null)
		{
			m_Cells[cellIdx] = new Cell();
		}
		m_Cells[cellIdx].Type = etype;
		m_Cells[cellIdx].Id = 0;	// todo:random template
		//m_Cells[cellIdx].template = TileMapConfig.

	}
	public void RefreshTile(int layer, int cx, int cy)
	{
		int cellIdx = GetCellIdx(cx, cy);
		Cell cell = m_Cells[cellIdx];
		if (cell == null)
			return;
		if (cell.Id == -1)
			return;
		if (cell.Type == eTileType.ETT_OBJECT)
		{
			//RefreshObjectTile();
			cell.template = TileMapConfig.Instance.GetTileTemplate(cell.Type, cell.Id);
		}
		else
		{
			RefreshAutoTile(cell, layer, cx, cy);
		}
	}
	public void RefreshAutoTile(Cell cell, int layer, int cx, int cy)
	{
		for (int j = 0; j < 2; j++)
		{
			for (int i = 0; i < 2; i++)
			{
				//cell.template
			}
		}
	}
	public void Refresh()
	{
		if (m_meshFilter == null)
		{
			m_meshFilter = transform.gameObject.AddComponent<MeshFilter>();
		}
		if (m_meshFilter.sharedMesh == null)
		{
			m_meshFilter.sharedMesh = new Mesh();
			m_meshFilter.sharedMesh.hideFlags = HideFlags.DontSave;
		}
		Mesh mesh = m_meshFilter.sharedMesh;
		mesh.Clear();

		FillData();

		mesh.vertices = m_vertices;
		mesh.colors32 = m_colors;
		mesh.uv = m_uv;
		mesh.triangles = m_triangles;
	}

	void FillData()
	{
		m_vertices = new Vector3[CellCount * 4 * 4];
		m_colors = new Color32[CellCount * 4 * 4];
		m_uv = new Vector2[m_vertices.Length];
		m_triangles = new int[CellCount * 4 * 2 * 3];

		int vertexIdx = 0;
		int triangleIdx = 0;
		for (int cellX = 0; cellX < TileMap.RegionWidth; cellX++)
		{
			for (int cellY = 0; cellY < TileMap.RegionHeight; cellY++)
			{
				FillACell(cellX, cellY);
				vertexIdx += 4;
				triangleIdx += 6;
			}
		}
		// resize arrays
		System.Array.Resize(ref m_vertices, vertexIdx);
		System.Array.Resize(ref m_colors, vertexIdx);
		System.Array.Resize(ref m_uv, vertexIdx);
		System.Array.Resize(ref m_triangles, triangleIdx);
	}
	void FillACell(int cx, int cy)
	{
		int cellIdx = cy * TileMap.RegionHeight + cx;
		Cell cell = m_Cells[cellIdx];
		Tile tile = Tileset.GetTile(cell.Type, cell.Id);
		if (tile == null)
			return;

		int subTileBaseX = cx * 2;
		int subTileBaseY = cy * 2;
		for (int xf = 0; xf < 2; ++xf)
		{
			for (int yf = 0; yf < 2; ++yf)
			{
				int subTileX = subTileBaseX + xf;
				int subTileY = subTileBaseY + yf;

				//float px0 = subTileX * 
			}
		}
	}


}