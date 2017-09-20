using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class TilesetEditWindow : EditorWindow
{
	bool m_bShowGround = false;
	bool m_bShowRoad = false;
	public Vector2 scrollPosition;

	public static Tileset tileset;

	//[MenuItem("R/TilesetEditor")]
	public static void ShowDialog(Tileset _tileset)
	{
		TilesetEditWindow wnd = (TilesetEditWindow)EditorWindow.GetWindow(typeof(TilesetEditWindow));
		tileset = _tileset;
	}

	static bool showSubTileset = true;
	static bool[] showSubTilesetByType = new bool[(int)eTileType._SIZE];
	
	void OnGUI()
	{
		UIShowTileset();
	}
	Sprite sp = new Sprite();
	void UIShowTileset() 
	{
		GUILayout.Label("Tileset Configuration", EditorStyles.boldLabel);
		GUILayout.BeginVertical("Box");
		GUI.color = Color.blue;
		showSubTileset = GUILayout.Toggle(showSubTileset, "SubTileset", GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));
		if (!showSubTileset)
		{
			GUILayout.EndVertical();
			return;
		}
		GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(false));
		for (int etype = 0; etype < (int)eTileType._SIZE; ++etype)
		{
			GUI.color = Color.blue;
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
				//SaveTextureAsset(tileset.AtlasTexture);
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
				sp = EditorGUILayout.ObjectField("Sprite", sp, typeof(Sprite), true) as Sprite;
				if (sp != null)
				{
					st.SourceTexture = sp.texture;
				}
				if (st.SourceTexture != null)
				{
					//NOTE: MyTileset.SubTilesets.Count should be 0 when loading old Tileset below version 1.2.0 only
					if (prevTexture != st.SourceTexture)//|| MyTileset.SubTilesets.Count == 0) 
					{
						st.AtlasRec.width = st.SourceTexture.width * 1f;
						st.AtlasRec.height = st.SourceTexture.height;
						tileset.GenerateTilesetData();
						EditorUtility.SetDirty(tileset);
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
}