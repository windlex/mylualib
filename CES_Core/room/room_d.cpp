#include "ecs_stdafx.h"
#include "..\network\SessionComponent.h"
#include "room_d.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"
#include "..\02.Component\CompDisp.h"
#include "..\02.Component\CompMove.h"

namespace ECS
{
	int RoomD::FixedUpdate()
	{
		ProcessJoin();
		ProcessSync();
		return TRUE;
	}

	void RoomD::ProcessJoin()
	{
		std::vector<CompJoinRoom *> group;
		Manager::GetInstance()->ComponentItr<CompJoinRoom>(group);
		for (CompJoinRoom *p : group)
		{
			Entity *e = p->GetOwner();
			int nRet = JoinRoom(p->nRoomId, e);
			if (nRet)
				e->RemoveComponent(p);
		}
	}

	int PackEntity(Entity *e, ProtoAddPlayer *pSync)
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
	int RoomD::JoinRoom(int nRoomId, Entity *e)
	{
		Comp_RoomData *pRoomData = SComp_RoomMap::GetInstance()->CreateRoom(nRoomId);

		ProtoAddPlayer sSync;
		PackEntity(e, &sSync);
		for (Entity *other : pRoomData->m_entityList)
		{
			// e -> all
			SessionCompnent *sc = other->GetComponent<SessionCompnent>();
			if (sc)
			{
				sc->pSession->Send((char*)&sSync, sizeof(sSync));
			}
		}

		// all -> e	
		SessionCompnent *sc = e->GetComponent<SessionCompnent>();
		if (sc)
		{
			for (Entity *other : pRoomData->m_entityList)
			{
				PackEntity(other, &sSync);
				sc->pSession->Send((char*)&sSync, sizeof(sSync));

				CompRoleData *roleData = other->GetComponent<CompRoleData>();
				if (roleData)
				{
					int size = roleData->size + sizeof(ProtoS2C_RoleData) - 1;
					char szBuff[1024] = {0};
					ProtoS2C_RoleData &sSync = *new (szBuff)ProtoS2C_RoleData();
					sSync.Size = size;
					memcpy(sSync.Data, roleData->szData, roleData->size);

					sc->pSession->Send((char*)&szBuff, size);
				}
			}
		}

		pRoomData->m_entityList.push_back(e);
		Comp_RoomId *roomid = e->AddComponent<Comp_RoomId>();
		roomid->m_nRoomId = nRoomId;

		return TRUE;
	}
	void RoomD::LeaveRoom(int nRoomId, Entity *me)
	{
		Comp_RoomData *pRoomData = SComp_RoomMap::GetInstance()->CreateRoom(nRoomId);
		Comp_RoomData::EntityList::iterator it = pRoomData->m_entityList.begin();
		for (; it != pRoomData->m_entityList.end(); ++it)
		{
			if (*it == me)
			{
				pRoomData->m_entityList.erase(it);
				ProtoRemovePlayer sSync;
				sSync.uuid = me->GetUUID();
				SendToRoom(pRoomData, me, (char*)&sSync, sizeof(sSync));
				return;
			}
		}
	}



	void RoomD::ProcessSync()
	{
		for (auto room : SComp_RoomMap::GetInstance()->m_kRoomMap)
		{
			Comp_RoomData *roomData = room.second;
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
					char szBuff[1024] = {0};
					ProtoS2C_RoleData &sSync = *new (szBuff)ProtoS2C_RoleData();
					sSync.Size = size;
					memcpy(sSync.Data, roleData->szData, roleData->size);

					SendToRoom(roomData, e, szBuff, size);
				}

			}
		}
	}

	void RoomD::SendToRoom(Comp_RoomData *room, Entity *me, char *sSync, uint32 size, int bExceptSelf /* = true */)
	{
		for (Entity *e : room->m_entityList)
		{
			SessionCompnent *sc = e->GetComponent<SessionCompnent>();
			if (!sc)
				continue;
			if (bExceptSelf && me == e)
				continue;

			sc->pSession->Send(sSync, size);
		}
	}

	void RoomD::SyncAction(Entity * pEntity, ProtoC2S_Action * pData, uint32 uSize)
	{
		Comp_RoomId *roomid = pEntity->GetComponent<Comp_RoomId>();
		Comp_RoomData *pRoomData = SComp_RoomMap::GetInstance()->CreateRoom(roomid->m_nRoomId);
		pData->cProtocol = PROTO_GS2C_ACTION;
		SendToRoom(pRoomData, pEntity, (char *)pData, uSize);
	}


	Comp_RoomId::~Comp_RoomId()
	{
		if (m_nRoomId)
		{
			RoomD::GetInstance()->LeaveRoom(m_nRoomId, GetOwner());
		}
	}


}