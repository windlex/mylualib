#pragma once
#include <vector>
#include "..\03.System\SystemBase.h"
#include "..\01.Entity\Entity.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"

namespace ECS
{
	class RoomD : public TSystemBase<4>, public TSingleton<RoomD>
	{
	public:
		RoomD(){}
		~RoomD(){}

		int	FixedUpdate();

		void ProcessJoin();
		int  JoinRoom(int nRoomId, Entity *e);
		void LeaveRoom(int nRoomId, Entity *e);

		void ProcessSync();
		void SendToRoom(Comp_RoomData *room, Entity *me, char *sSync, uint32 size, int bExceptSelf = true);
		void SyncAction(Entity * pEntity, ProtoC2S_Action * pData, uint32 uSize);
	};
}
