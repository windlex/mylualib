#include "ecs_stdafx.h"
#include "..\network\CompSession.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"
#include "..\02.Component\CompDisp.h"
#include "..\02.Component\CompMove.h"
#include "regiond.h"
#include "region_data.h"

namespace ECS
{
	int RegionD::FixedUpdate()
	{
		return TRUE;
	}

	int RegionD::Pos2RegionID(Comp_RoomData *roomdata, int x, int y)
	{
		return y / nRegionSize * roomdata->RegionWidthCount() + x / nRegionSize;
	}

	int RegionD::UpdateRegion(CompPosition *pos)
	{
		Entity *room = RoomD::GetInstance()->GetRoom(pos->m_nRoomId);
		Comp_RoomData *roomdata = room->GetComponent<Comp_RoomData>();
		
		CompRegion *regionData = RoomD::GetInstance()->GetRegion(roomdata, pos->pos.x, pos->pos.z);

		return TRUE;
	}

}