#pragma once
#include "..\01.Entity\Entity.h"
#include "RoomD.h"

namespace ECS {
	static int nRegionSize = 32;

	class CompJoinRoom : public Component
	{
	public:
		int		nRoomId;
	};

	class CompRegion;
	class Comp_RoomData : public Component
	{
	public:
		typedef std::vector<CompRegion *> RegionList;
		int			m_nRoomId;
		EntityList	m_entityList;
		RegionList	m_RegionList;

		int			m_nHeight;
		int			m_nWidth;

		int RegionWidthCount()
		{
			m_nWidth % nRegionSize == 0 ? m_nWidth / nRegionSize;
			 return
		}
		int RegionHeightCount()
		{
			return (m_nHeight + 0.5) / nRegionSize;
		}
		int RegionCount()
		{
			return RegionWidthCount() * RegionHeightCount();
		}
		int Pos2RegionID(int x, int y)
		{
			return y / nRegionSize * RegionWidthCount() + x / nRegionSize;
		}
		int RegionXY2RegionID(int rx, int ry)
		{
			return ry * RegionHeightCount() + rx;
		}
	};

	class SComp_RoomMgr : public TSingleton < SComp_RoomMgr >
	{
	public:
	};
}
