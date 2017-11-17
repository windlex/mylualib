#include "ecs_stdafx.h"
#include "..\network\CompSession.h"
#include "RoomD.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"
#include "..\02.Component\CompDisp.h"
#include "..\02.Component\CompMove.h"
#include "region_data.h"

//todo: 把Sync分离出去

namespace ECS {
	//--NewRoomD------------------------------------------------------
	int RoomD::FixedUpdate()
	{
		return TRUE;
	}

	Entity * RoomD::CreateRoom(int nRoomId)
	{
		auto it = m_RoomMap.find(nRoomId);
		if (it != m_RoomMap.end())
			return it->second;

		Entity *pRoom = Manager::GetInstance()->CreateEntity();	// create or get
		Comp_RoomData *pRoomData = pRoom->AddComponent<Comp_RoomData>();
		pRoomData->m_nRoomId = nRoomId;
		m_RoomMap[nRoomId] = pRoom;

		InitializeRoom(pRoomData);
		return pRoom;
	}

	Entity * RoomD::GetRoom(int nRoomId)
	{
		auto it = m_RoomMap.find(nRoomId);
		if (it == m_RoomMap.end())
			return NULL;
		return it->second;
	}

	void RoomD::CloseRoom(int nRoomId)
	{
		auto it = m_RoomMap.find(nRoomId);
		if (it == m_RoomMap.end())
			return;
		Entity *pRoom = it->second;
		m_RoomMap.erase(it);
		Manager::GetInstance()->DestroyEntity(pRoom->GetUUID());
	}

	int RoomD::JoinRoom(int nRoomId, Entity *e)
	{
		Entity *room = CreateRoom(nRoomId);
		Comp_RoomData *pRoomData = room->GetComponent<Comp_RoomData>();

		ProtoAddPlayer sSync;
		SyncD::GetInstance()->PackEntity(e, &sSync);
		// e -> all
		for (Entity *other : pRoomData->m_entityList)
		{
			CompSession *sc = other->GetComponent<CompSession>();
			if (sc)
			{
				sc->pSession->Send((char*)&sSync, sizeof(sSync));
			}
		}

		// all -> e	
		CompSession *sc = e->GetComponent<CompSession>();
		if (sc)
		{
			for (Entity *other : pRoomData->m_entityList)
			{
				SyncD::GetInstance()->PackEntity(other, &sSync);
				sc->pSession->Send((char*)&sSync, sizeof(sSync));

				CompRoleData *roleData = other->GetComponent<CompRoleData>();
				if (roleData)
				{
					int size = roleData->size + sizeof(ProtoS2C_RoleData) - 1;
					char szBuff[1024] = { 0 };
					ProtoS2C_RoleData &sSync = *new (szBuff)ProtoS2C_RoleData();
					sSync.Size = size;
					memcpy(sSync.Data, roleData->szData, roleData->size);

					sc->pSession->Send((char*)&szBuff, size);
				}
			}
		}

		pRoomData->m_entityList.push_back(e);
		CompPosition *pos = e->GetComponent<CompPosition>();
		pos->m_nRoomId = nRoomId;

		return TRUE;
	}
	void RoomD::LeaveRoom(int nRoomId, Entity *me)
	{
		Entity *room = GetRoom(nRoomId);
		if (!room)
			return;
		Comp_RoomData *pRoomData = room->GetComponent<Comp_RoomData>();

		EntityList::iterator it = pRoomData->m_entityList.begin();
		for (; it != pRoomData->m_entityList.end(); ++it)
		{
			if (*it == me)
			{
				pRoomData->m_entityList.erase(it);
				ProtoRemovePlayer sSync;
				sSync.uuid = me->GetUUID();
				SyncD::GetInstance()->SendToRoom(pRoomData, me, (char*)&sSync, sizeof(sSync));
				return;
			}
		}
	}

	int RoomD::InitializeRoom(Comp_RoomData * pRoomData)
	{
		// todo:windle
		pRoomData->m_nHeight = 100;
		pRoomData->m_nWidth = 100;

		for (int x = 0; x * nRegionSize < pRoomData->m_nWidth; x++)
		{
			for (int y = 0; y * nRegionSize < pRoomData->m_nHeight; y++)
			{
				CompRegion *pRegionData = new CompRegion();
				pRegionData->m_nRoomId = pRoomData->m_nRoomId;
				pRegionData->regionX = x;
				pRegionData->regionY = y;
				pRoomData->m_RegionList.push_back(pRegionData);
			}
		}
		return TRUE;
	}

	//--JoinRoomD------------------------------------------------------
	int JoinRoomD::FixedUpdate()
	{
		std::vector<CompJoinRoom *> group;
		Manager::GetInstance()->ComponentItr<CompJoinRoom>(group);
		for (CompJoinRoom *p : group)
		{
			Entity *e = p->GetOwner();
			int nRet = RoomD::GetInstance()->JoinRoom(p->nRoomId, e);
			if (nRet)
				e->RemoveComponent(p);
		}
		return TRUE;
	}

	//--SyncD------------------------------------------------------
	int SyncD::FixedUpdate()
	{
		for (auto room : RoomD::GetInstance()->m_RoomMap)
		{
			Entity *proom = room.second;
			Comp_RoomData *roomData = proom->GetComponent<Comp_RoomData>();
			for (Entity *e : roomData->m_entityList)
			{
				CompPosition *pos = e->GetComponent<CompPosition>();
				CompMove *move = e->GetComponent<CompMove>();
				if (pos->bUpdate)
				{
					pos->bUpdate = FALSE;
					ProtoS2CPos sSync;
					sSync.uuid = e->GetUUID();
					sSync.x = pos->pos.x;
					sSync.y = pos->pos.y;
					sSync.z = pos->pos.z;
					sSync.dir = pos->ndir;
					if (move)
					{
						sSync.moveX = move->moveX;
						sSync.moveZ = move->moveZ;
					}
					else
					{
						sSync.moveX = 0;
						sSync.moveZ = 0;
					}
					SendToRoom(roomData, e, (char*)&sSync, sizeof(sSync), true);
				}
				CompRoleData *roleData = e->GetComponent<CompRoleData>();
				if (roleData && roleData->bUpdate)
				{
					roleData->bUpdate = FALSE;
					int size = roleData->size + sizeof(ProtoS2C_RoleData) - 1;
					char szBuff[1024] = { 0 };
					ProtoS2C_RoleData &sSync = *new (szBuff)ProtoS2C_RoleData();
					sSync.Size = size;
					memcpy(sSync.Data, roleData->szData, roleData->size);

					SendToRoom(roomData, e, szBuff, size);
				}

			}
		}
		return TRUE;
	}

	int SyncD::PackEntity(Entity *e, ProtoAddPlayer *pSync)
	{
		pSync->uuid = e->GetUUID();
		CompDisp *disp = e->GetComponent<CompDisp>();
		g_StrCpyLen(pSync->szName, disp->szName, sizeof(pSync->szName));
		CompPosition *pos = e->GetComponent<CompPosition>();
		pSync->x = pos->pos.x;
		pSync->y = pos->pos.y;
		pSync->z = pos->pos.z;
		return TRUE;
	}

	void SyncD::SendToRoom(Comp_RoomData *room, Entity *me, char *sSync, uint32 size, int bExceptSelf /* = true */)
	{
		for (Entity *e : room->m_entityList)
		{
			CompSession *sc = e->GetComponent<CompSession>();
			if (!sc)
				continue;
			if (bExceptSelf && me == e)
				continue;

			sc->pSession->Send(sSync, size);
		}
	}

	void SyncD::SyncAction(Entity * pEntity, ProtoC2S_Action * pData, uint32 uSize)
	{
		CompPosition *pos = pEntity->GetComponent<CompPosition>();
		Entity *room = RoomD::GetInstance()->GetRoom(pos->m_nRoomId);
		if (!room)
			return;
		Comp_RoomData *pRoomData = room->GetComponent<Comp_RoomData>();

		pData->cProtocol = PROTO_GS2C_ACTION;
		SendToRoom(pRoomData, pEntity, (char *)pData, uSize);
	}

	//--------------------------------------------------------
	CompPosition::~CompPosition()
	{
		if (m_nRoomId)
		{
			RoomD::GetInstance()->LeaveRoom(m_nRoomId, GetOwner());
		}
	}
}