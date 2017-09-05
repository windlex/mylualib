using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eTileType
{
	ETT_GROUND,
	ETT_ROAD,
	ETT_BUILDING,
	ETT_WALL,
	ETT_OBJECT,
}

public enum eTilePartType
{
	IN_CORNER,
	EX_CORNER,
	INTER,
	H_SIDE,
	V_SIDE,
}

[System.Serializable]
public class Cell
{
	public eTileType Type;
	public int Id = -1;
	public int[] m_TilePartsIdx;
	public eTilePartType[] m_TilePartsType;
	public int m_TilePartsLength;
}
