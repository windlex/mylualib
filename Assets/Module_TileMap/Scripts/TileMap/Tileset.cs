using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum eTileType
{
	ETT_WATER,
	ETT_GROUND,
	ETT_WALL,
	ETT_BUILDING,
	ETT_ROAD,
	ETT_OBJECT,
	_SIZE,
}

public enum eTilePartType
{
	IN_CORNER,
	EX_CORNER,
	INTER,
	H_SIDE,
	V_SIDE,
	_SIZE,
}

public enum eTileCollisionType
{
	EMPTY = -1,
	PASSABLE,
	BLOCK,
	WALL,
	FENCE,
	OVERLAY,
	_SIZE,
}
[System.Serializable]
public class Tile {
	public string Name;
	public int SubTilesetIdx;
	public int TileIdx;
	public eTileType TileType;
	public Rect ThumbRect;
	public Rect[,] PartRect;
	public eTileCollisionType CollType;

	public virtual Rect GetThumbRect(int part, eTilePartType partType) 
	{
		return ThumbRect; 
	}
	public virtual Rect GetPartRect(int part, eTilePartType partType) 
	{ 
		return ThumbRect; 
	}
	public virtual void InitTile(int subTilesetIdx, int tileIdx, eTileType tileType, Rect TileRect) 
	{
		SubTilesetIdx = subTilesetIdx;
		TileIdx = tileIdx;
		TileType = tileType;
		//todo CollType = ?;
		ThumbRect = TileRect;

	}
}
public class GroundTile : Tile {
	public static List<int[,]> AutoTilePartOff = new List<int[,]>()
	{
		new int[,] {	// A
			{2, 0},			//IN_CORNER,
			{0, 2},			//EX_CORNER,
			{2, 4},			//INTER,
			{2, 2},			//H_SIDE,
			{0, 4},			//V_SIDE,
		},
		new int[,]{		// B
			{3, 0},			//IN_CORNER,
			{3, 2},			//EX_CORNER,
			{1, 4},			//INTER,
			{1, 2},			//H_SIDE,
			{3, 4},			//V_SIDE,
		},
		new int[,] {	// C
			{2, 1},			//IN_CORNER,
			{0, 5},			//EX_CORNER,
			{2, 3},			//INTER,
			{2, 5},			//H_SIDE,
			{0, 3},			//V_SIDE,
		},
		new int[,]{		// D
			{3, 1},			//IN_CORNER,
			{3, 5},			//EX_CORNER,
			{1, 3},			//INTER,
			{1, 5},			//H_SIDE,
			{3, 3},			//V_SIDE,
		},
	};	
	public override Rect GetPartRect(int part, eTilePartType partType)
	{
		return PartRect[part,(int)partType];
	}
	public override void InitTile(int subTilesetIdx, int tileIdx, eTileType tileType, Rect TileRect)
	{
		base.InitTile(subTilesetIdx, tileIdx, tileType, TileRect);
		ThumbRect = new Rect(TileRect.x, TileRect.y, TileMap.CellWidth, TileMap.CellHeight);
		PartRect = new Rect[TileMap.TilePartSize, TileMap.TilePartTypeSize];
		for (int i = 0; i < TileMap.TilePartSize; i++)
		{
			for (int j = 0; j < TileMap.TilePartTypeSize; j++)
			{
				Rect partRect = new Rect(TileRect.x, TileRect.y, TileMap.CellWidth/2, TileMap.CellHeight/2);
				int offX = AutoTilePartOff[i][j, 0];
				int offY = AutoTilePartOff[i][j, 1];
				partRect.x += offX * TileMap.CellWidth/2;
				partRect.y += offY * TileMap.CellHeight/2;
				PartRect[i,j] = partRect;
			}
		}
	}
}

public class Tileset : ScriptableObject
{
	public Tileset()
	{
	}

#region SubTileset
	[System.Serializable]
	public class SubTileset
	{
		public int Idx;
		public string Name;
		public Texture2D SourceTexture;
		public eTileType TileType;
		public Rect AtlasRec;
		public List<int> TilePartOffset;
	}
	public List<List<SubTileset>> SubTilesetList = new List<List<SubTileset>>();

	public void InitSubTileset()
	{
		for (int etype = 0; etype < (int)eTileType._SIZE; ++etype)
		{
			if (SubTilesetList.Count <= etype)
				SubTilesetList.Add(new List<SubTileset>());
		}
	}
	public void AddSubTileset(int etype)
	{
		SubTileset st = new SubTileset();
		st.TileType = (eTileType)etype;
		SubTilesetList[etype].Add(st);
	}
	public void RemoveSubTileset(eTileType etype, int n)
	{
		SubTilesetList[(int)etype].RemoveAt(n);
	}
#endregion
	public List<Tile> TileList = new List<Tile>(); 

	public static int TilesetSlotSize = 32 * TileMap.CellWidth;

	#region Material
	[SerializeField]
	public Material AtlasMaterial { get; private set; }
	[SerializeField]
	private Texture2D m_atlasTexture;
	public Texture2D AtlasTexture
	{
		get { return m_atlasTexture; }
		set
		{
			if (value == null || value == m_atlasTexture)
			{
				m_atlasTexture = value;
				return;
			}
			if (value.width % TileMap.CellWidth != 0 || value.height % TileMap.CellHeight != 0)
			{
				m_atlasTexture = null;
				Debug.LogError(" TilesetsAtlasTexture.set: atlas texture has a wrong size " + value.width + "x" + value.height);
				return;
			}
			m_atlasTexture = value;
			TileMapUtils.ImportTexture(m_atlasTexture);
			GenerateTilesetData();

		}
	}
	public void CreateAtlasMaterial()
	{
		string matPath = "";
#if UNITY_EDITOR
		matPath = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(m_atlasTexture));
		if (!string.IsNullOrEmpty(matPath))
		{
			matPath += "/" + AtlasTexture.name + "AtlasMat.mat";
			Material matAtlas = (Material)AssetDatabase.LoadAssetAtPath(matPath, typeof(Material));
			if (matAtlas == null)
			{
				matAtlas = new Material(Shader.Find("Sprites/Default"));//NOTE: if this material changes, remember to change also the one inside #else #endif below
				AssetDatabase.CreateAsset(matAtlas, matPath);
			}
			AtlasMaterial = matAtlas;
			EditorUtility.SetDirty(AtlasMaterial);
			AssetDatabase.SaveAssets();
		}
#else
		AtlasMaterial = new Material(Shard.Find("Sprites/Default"));
#endif
		if (AtlasMaterial != null)
			AtlasMaterial.mainTexture = AtlasTexture;
		else
		{
			m_atlasTexture = null;
			Debug.LogError(" TilesetsAtlasTexture.set: there was an error creating the material asset at " + matPath);
		}
	}
	#endregion

	public void GenerateTilesetData()
	{
		if (AtlasMaterial == null)
			CreateAtlasMaterial();

		for (int etype = 0; etype < (int)eTileType._SIZE; ++etype)
		{ 
			foreach(SubTileset subTileset in SubTilesetList[etype])
				BuildTileList(subTileset);
		}
		
	}
	int[] TileWidthByType = new int[] {3,2,2,2,2,1};
	int[] TileHeightByType = new int[]{3,3,2,5,1,1};
	public void BuildTileList(SubTileset subTileset)
	{
		int x = 0;
		int y = 0;
		int w = TileWidthByType[(int)subTileset.TileType];
		int h = TileHeightByType[(int)subTileset.TileType];

		TileList.Clear();

		Rect rect = new Rect( 0, 0, TileMap.CellWidth * w, TileMap.CellHeight * h);
		for (int tileIdx = 0; ; ++tileIdx)
		{
			Tile tile = null;
			switch(subTileset.TileType){
			case eTileType.ETT_GROUND: tile = new GroundTile();break;
			}
			if (tile == null)
			{
				Debug.LogError("xxxxx");
				return;
			}
			rect.x = subTileset.AtlasRec.x + x;
			rect.y = subTileset.AtlasRec.y + y;
			tile.InitTile(subTileset.Idx, tileIdx, subTileset.TileType, rect);
			TileList.Add(tile);
		
			x += w * TileMap.CellWidth;
			if (x >= subTileset.AtlasRec.width)
			{ 
				x = 0;
				y += h * TileMap.CellHeight;
			}
			if (y >= subTileset.AtlasRec.height)
				break;
		}
	}
	public static Tile GetTile(eTileType Type, int Id)	// todo
	{
		return null;
	}

}

