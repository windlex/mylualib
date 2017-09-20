using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;
using System.Collections.Generic;

[CustomEditor(typeof(Tileset))]
public class TilesetEditor : Editor
{
	Color guiRed = new Color(255f / 255f, 100f / 255f, 100f / 255f);
	Color guiBlue = new Color(0f / 255f, 180f / 255f, 255f / 255f);
	Color guiBluelight = new Color(180f / 255f, 240f / 255f, 255f / 255f);

	public Tileset tileset;
	Tileset MyTileset { get { return (Tileset)target; } }
	private void OnEnable()
	{

		//get script Reference
		tileset = (Tileset)target;

		//SceneView.onSceneGUIDelegate = GridUpdate;

		//LoadResources();

		//get all available masks
		//TileWorldMaskLookup.GetMasks(out tileset.iMasks, out _maskNames);

		//currentScene = EditorApplication.currentScene;
		//EditorApplication.hierarchyWindowChanged += HierarchyWindowChanged;
	}

	static bool showGeneralWorldSettings = false;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		UIEditTileset();

		UIShowAtlas();

		UIShowSubTileset();

		UIShowTiles();

		GUILayout.BeginVertical("box");
		{
			//SHOW SETTINGS
			//-------------
			showGeneralWorldSettings = GUILayout.Toggle(showGeneralWorldSettings, ("Settings"),
				GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));


		}
		GUILayout.EndVertical();


		if (showGeneralWorldSettings)
		{
			ShowSettings();
		}
	}

	void UIEditTileset()
	{
		if (GUILayout.Button("Edit Tileset..."))
		{
			TilesetEditWindow.ShowDialog(tileset);
		}
	}

	public void UIShowAtlas()
	{
		//GenerateAtlas
		//-------------
		EditorGUILayout.HelpBox("Select a texture atlas directly or Generate a new atlas using separated textures", MessageType.Info);
		Texture2D prevTexture = MyTileset.AtlasTexture;
		MyTileset.AtlasTexture = EditorGUILayout.ObjectField("Tileset Atlas", MyTileset.AtlasTexture, typeof(Texture2D), false) as Texture2D;
		if (MyTileset.AtlasTexture != null)
		{
			//NOTE: MyTileset.SubTilesets.Count should be 0 when loading old Tileset below version 1.2.0 only
			if (prevTexture != MyTileset.AtlasTexture)//|| MyTileset.SubTilesets.Count == 0) 
			{
				MyTileset.GenerateTilesetData();
				EditorUtility.SetDirty(MyTileset);
			}

			EditorGUILayout.HelpBox("Add tilesets to any free slot", MessageType.Info);
			if (GUILayout.Button("Edit Tileset..."))
			{
				//AutoTilesetEditorWindow.ShowDialog(MyTileset, AutoTilesetEditorWindow.eEditMode.TilesetAtlas);
			}
		}
		else
		{
			if (GUILayout.Button("Generate Atlas of " + "?" + "x" + "?"))
			{
				Texture2D atlasTexture = TileMapUtils.GenerateAtlas(MyTileset);
				if (atlasTexture)
				{
					string path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(MyTileset));
					string filePath = EditorUtility.SaveFilePanel("Save Atlas", path, MyTileset.name + ".png", "png");
					if (filePath.Length > 0)
					{
						byte[] bytes = atlasTexture.EncodeToPNG();
						File.WriteAllBytes(filePath, bytes);

						// make path relative to project
						filePath = "Assets" + filePath.Remove(0, Application.dataPath.Length);

						// Make sure LoadAssetAtPath and ImportTexture is going to work
						AssetDatabase.Refresh();

						TileMapUtils.ImportTexture(filePath);

						// Link Atlas with asset to be able to save it in the prefab
						MyTileset.AtlasTexture = (Texture2D)AssetDatabase.LoadAssetAtPath(filePath, typeof(Texture2D));
						TileMapUtils.ImportTexture(MyTileset.AtlasTexture);
					}
					else
					{
						MyTileset.AtlasTexture = null;
					}
				}
				MyTileset.GenerateTilesetData();
				EditorUtility.SetDirty(MyTileset);
			}
		}
	}

	static bool showSubTileset = true;
	static bool[] showSubTilesetByType = new bool[(int)eTileType._SIZE];
	public void UIShowSubTileset()
	{
		if (tileset.SubTilesetList.Count == 0)
		{ 
			Debug.LogError("==================== InitSubTileset");
			tileset.InitSubTileset();
		}

		GUILayout.BeginVertical("Box");
		GUI.color = guiBlue;
		showSubTileset = GUILayout.Toggle(showSubTileset, "SubTileset", GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));
		if (!showSubTileset)
		{
			GUILayout.EndVertical();
			return;
		}
		GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(false));
		for (int etype = 0; etype < (int)eTileType._SIZE; ++etype)
		{
			GUI.color = guiBlue;
			GUILayout.BeginHorizontal("Box");
			showSubTilesetByType[etype] = GUILayout.Toggle(showSubTilesetByType[etype],
						((eTileType)etype).ToString(),
						GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));
			if (GUILayout.Button("+", GUILayout.Height(18), GUILayout.Width(25)))
			{
				tileset.AddSubTileset(etype);
			}
			GUILayout.EndHorizontal();
			if (!showSubTilesetByType[etype])
			{
				continue;
			}
			GUI.color = Color.white;
			if (GUILayout.Button("Accept", GUILayout.Height(25)))
			{
				//todo:TileMapUtils.CopySubTilesetInAtlas(tileset);
				tileset.AtlasTexture.Apply();
				SaveTextureAsset(tileset.AtlasTexture);
				tileset.GenerateTilesetData();
				EditorUtility.SetDirty(tileset);
			} 
			
			foreach (Tileset.SubTileset st in tileset.SubTilesetList[etype])
			{
				GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(false));
				st.Idx = EditorGUILayout.IntField("Id:", st.Idx);
				st.Name = EditorGUILayout.TextField("Name:", st.Name);
				Texture2D prevTexture = st.SourceTexture;
				st.SourceTexture = EditorGUILayout.ObjectField("Tileset Atlas", st.SourceTexture, typeof(Texture2D), true) as Texture2D;
				if (st.SourceTexture != null)
				{
					//NOTE: MyTileset.SubTilesets.Count should be 0 when loading old Tileset below version 1.2.0 only
					if (prevTexture != st.SourceTexture)//|| MyTileset.SubTilesets.Count == 0) 
					{
						st.AtlasRec.width = st.SourceTexture.width * 1f;
						st.AtlasRec.height = st.SourceTexture.height;
						MyTileset.GenerateTilesetData();
						EditorUtility.SetDirty(MyTileset);
					}
				}
				//public eTileType TileType;
				st.AtlasRec = EditorGUILayout.RectField("Atlas:", st.AtlasRec);
				//public List<int> TilePartOffset;
				GUILayout.EndVertical();
			}
		}
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		GUI.color = Color.white;
	}

	public bool SaveTextureAsset(Texture2D texture)
	{
		if (texture == null)
			return false;
		string filePath = AssetDatabase.GetAssetPath(texture);
		if (filePath.Length <= 0)
			return false;

		byte[] bytes = texture.EncodeToPNG();
		File.WriteAllBytes(filePath, bytes);
		AssetDatabase.Refresh();
		return TileMapUtils.ImportTexture(filePath);
	}

	static bool showTiles = true;
	Vector2 m_scrollPos;
	const int k_visualTileWidth = 32; 
	const int k_visualTileHeight = 32;
	Texture2D m_tilesetTexture;
	public void UIShowTiles()
	{
		GUILayout.BeginVertical("Box");
		GUI.color = guiBlue;
		showTiles = GUILayout.Toggle(showTiles, "Tiles " + tileset.TileList.Count, GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));
		if (!showTiles)
		{
			GUILayout.EndVertical();
			return;
		}
		int n = 0;
		foreach (Tile tile in tileset.TileList)
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(false));
			tile.Name = EditorGUILayout.TextField("Name:", tile.Name);
			tile.SubTilesetIdx= EditorGUILayout.IntField("SubTileIdx:", tile.SubTilesetIdx);
			tile.TileIdx = EditorGUILayout.IntField("TileIdx:", tile.TileIdx);
			tile.TileType = (eTileType)EditorGUILayout.EnumPopup("TileType:", tile.TileType);
			tile.ThumbRect = EditorGUILayout.RectField("ThumbRect:", tile.ThumbRect);
			//public Rect[,] tile.PartRect = EditorGUILayout.TextField("Name:", tile.Name);
			tile.CollType = (eTileCollisionType)EditorGUILayout.EnumPopup("CollType:", tile.CollType);

			GUILayout.EndVertical();
			if (++n > 50)
				break;
		}
		if (GUI.changed || m_tilesetTexture == null)
		{
			//m_tilesetTexture = UtilsAutoTileMap.GenerateTilesetTexture(m_autoTileMap.Tileset, m_autoTileMap.Tileset.SubTilesets[m_subTilesetIdx]);
		}
		if (!m_tilesetTexture)
		{
			GUILayout.EndVertical();
			return;
		}

		m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.MinHeight(16f * k_visualTileHeight));
		//if (false)
		{
			Rect rTileset = new Rect();
			Rect rTile = new Rect(0, 0, k_visualTileWidth, k_visualTileHeight);

			GUIStyle tilesetStyle = new GUIStyle(GUI.skin.button);
			tilesetStyle.normal.background = m_tilesetTexture;
			tilesetStyle.border = tilesetStyle.margin = tilesetStyle.padding = new RectOffset(0, 0, 0, 0);
			float fWidth = 8 * k_visualTileWidth;
			float fHeight = m_tilesetTexture.height * fWidth / m_tilesetTexture.width;
			GUILayout.Box("", tilesetStyle, GUILayout.Width(fWidth), GUILayout.Height(fHeight));
			rTileset = GUILayoutUtility.GetLastRect();

			/*if (IsEditCollision)
			{
				for (int autoTileLocalIdx = 0; autoTileLocalIdx < 256; ++autoTileLocalIdx) //autoTileLocalIdx: index of current tileset group
				{
					rTile.x = rTileset.x + (autoTileLocalIdx % m_autoTileMap.Tileset.AutoTilesPerRow) * k_visualTileWidth;
					rTile.y = rTileset.y + (autoTileLocalIdx / m_autoTileMap.Tileset.AutoTilesPerRow) * k_visualTileHeight;

					int autoTileIdx = autoTileLocalIdx + (int)m_subTilesetIdx * 256; // global autotile idx
					if (Event.current.type == EventType.MouseUp)
					{
						if (rTile.Contains(Event.current.mousePosition))
						{
							int collType = (int)m_autoTileMap.Tileset.AutotileCollType[autoTileIdx];
							if (Event.current.button == 0)
							{
								collType += 1; // go next
							}
							else if (Event.current.button == 1)
							{
								collType += (int)eTileCollisionType._SIZE - 1; // go back
							}
							collType %= (int)eTileCollisionType._SIZE;
							m_autoTileMap.Tileset.AutotileCollType[autoTileIdx] = (eTileCollisionType)(collType);
						}
						EditorUtility.SetDirty(m_autoTileMap.Tileset);
					}


					string sCollision = "";
					switch (m_autoTileMap.Tileset.AutotileCollType[autoTileIdx])
					{
						//NOTE: if you don't see the special characters properly, be sure this file is saved in UTF-8
						case eTileCollisionType.BLOCK: sCollision = "¡ö"; break;
						case eTileCollisionType.FENCE: sCollision = "#"; break;
						case eTileCollisionType.WALL: sCollision = "¡õ"; break;
						case eTileCollisionType.OVERLAY: sCollision = "¡ï"; break;
					}

					if (sCollision.Length > 0)
					{
						GUI.color = new Color(1f, 1f, 1f, 1f);
						GUIStyle style = new GUIStyle();
						style.fontSize = 30;
						style.fontStyle = FontStyle.Bold;
						style.alignment = TextAnchor.MiddleCenter;
						style.normal.textColor = Color.white;
						GUI.Box(rTile, sCollision, style);
						GUI.color = Color.white;
					}

					//debug Alpha tiles
					if( m_autoTileMap.Tileset.IsAutoTileHasAlpha[autoTileIdx] )
					{
						GUIStyle style = new GUIStyle();
						style.fontSize = 30;
						style.fontStyle = FontStyle.Bold;
						style.alignment = TextAnchor.MiddleCenter;
						style.normal.textColor = Color.blue;
						GUI.Box( rTile, "A", style );
					}
				}
			}
			else*/
			/*{
				UpdateTilesetOnInspector(rTileset);

				Rect rSelected = new Rect(0, 0, k_visualTileWidth, k_visualTileHeight);
				int tileWithSelectMark = m_selectedTileId;
				tileWithSelectMark -= (int)m_subTilesetIdx * 256;
				rSelected.position = rTileset.position + new Vector2((tileWithSelectMark % m_autoTileMap.Tileset.AutoTilesPerRow) * k_visualTileWidth, (tileWithSelectMark / m_autoTileMap.Tileset.AutoTilesPerRow) * k_visualTileHeight);
				UtilsGuiDrawing.DrawRectWithOutline(rSelected, new Color(0f, 0f, 0f, 0.1f), new Color(1f, 1f, 1f, 1f));
			}*/
		}
		EditorGUILayout.EndScrollView();

		GUILayout.EndVertical();
		GUI.color = Color.white;
	}
	public static Texture2D GenerateTilesetTexture(Tileset autoTileset)
	{
		int TileHeight = 32;
		int TileWidth = 32;
		//+++ old values for 32x32 tiles, now depend on tile size
		int _1024 = 32 * TileWidth;
		int _256 = 8 * TileWidth;
		//---
		List<Rect> sprList = new List<Rect>();
		//FillWithTilesetThumbnailSprites(sprList, autoTileset, tilesetConf);
		Texture2D tilesetTexture = new Texture2D(_256, _1024, TextureFormat.ARGB32, false);
		tilesetTexture.filterMode = FilterMode.Point;

		int sprIdx = 0;
		Rect dstRect = new Rect(0, tilesetTexture.height - TileHeight, TileWidth, TileHeight);
		for (; dstRect.y >= 0; dstRect.y -= TileHeight)
		{
			for (dstRect.x = 0; dstRect.x < tilesetTexture.width && sprIdx < sprList.Count; dstRect.x += TileWidth, ++sprIdx)
			{
				Rect srcRect = sprList[sprIdx];
				Color[] autotileColors = autoTileset.AtlasTexture.GetPixels(Mathf.RoundToInt(srcRect.x), Mathf.RoundToInt(srcRect.y), TileWidth, TileHeight);
				tilesetTexture.SetPixels(Mathf.RoundToInt(dstRect.x), Mathf.RoundToInt(dstRect.y), TileWidth, TileHeight, autotileColors);
			}
		}
		tilesetTexture.Apply();

		return tilesetTexture;
	}
	
	public void ShowSettings()
    {
		//SETTINGS
		//--------
		GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true));
		GUILayout.EndVertical();
	}
}