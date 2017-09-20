using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileMapUtils
{

	public static bool ImportTexture(Texture2D texture)
	{
#if UNITY_EDITOR
		if (texture != null)
		{
			return ImportTexture(AssetDatabase.GetAssetPath(texture));
		}
#endif
		return false;
	}

	/// <summary>
	/// Import the texture making sure the texture import settings are properly set
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	public static bool ImportTexture(string path)
	{
#if UNITY_EDITOR
		if (path.Length > 0)
		{
			TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
			if (textureImporter)
			{
				textureImporter.alphaIsTransparency = true; // default
				textureImporter.anisoLevel = 1; // default
				textureImporter.borderMipmap = false; // default
				textureImporter.mipmapEnabled = false; // default
				textureImporter.compressionQuality = 100;
				textureImporter.isReadable = true;
				textureImporter.spritePixelsPerUnit = 100f;	// todo:TileMap.PixelToUnits
				textureImporter.spriteImportMode = SpriteImportMode.None;
				textureImporter.wrapMode = TextureWrapMode.Clamp;
				textureImporter.filterMode = FilterMode.Point;
				textureImporter.textureFormat = TextureImporterFormat.ARGB32;	//todo
				textureImporter.textureType = TextureImporterType.Default;
				textureImporter.maxTextureSize = 4096; //todo: Tilesets.k_MaxTextureSize;
				AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
			}
			return true;
		}
#endif
		return false;
	}
	public static Texture2D GenerateAtlas(Tileset tileset) {
		int w = 1 * Tileset.TilesetSlotSize;
        int h = 1 * Tileset.TilesetSlotSize;
		Texture2D atlasTexture = new Texture2D(w, h);
		Color32[] atlasColors = Enumerable.Repeat<Color32>( new Color32(0, 0, 0, 0) , w*h).ToArray();
		atlasTexture.SetPixels32(atlasColors);
		atlasTexture.Apply();

		return atlasTexture;
	}
}