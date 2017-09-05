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
		foreach(TileConfig.LayerConfig layerConfig in TileMap.Instance.tileConfig.layerConfig)
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
}

public class SubRegion : MonoBehaviour
{
	public static int CellCount = TileMap.RegionWidth * TileMap.RegionHeight;

	private Vector3[] m_vertices;
	private Vector2[] m_uv;
	private int[] m_triangles;
	private Color32[] m_colors;
	private MeshFilter m_meshFilter = new MeshFilter();
	public Cell[] m_Cells;

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