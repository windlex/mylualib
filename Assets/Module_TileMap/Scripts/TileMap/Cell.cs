using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell
{
	public eTileType Type;
	public int Id = -1;
	public TileMapConfig.TileTemplate template;
}
