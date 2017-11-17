#pragma once
#include <vector>
#include "..\03.System\SystemBase.h"
#include "..\01.Entity\Entity.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"

namespace ECS
{
	class Comp_RoomData;

	//--------------------------------------------------------
	class JoinRoomD : public TSystemBase<SYS_JOINROOM>, public TSingleton < JoinRoomD >
	{
		int	FixedUpdate();

	};

	//--------------------------------------------------------
	class RoomD : public TSystemBase<SYS_ROOM>, public TSingleton < RoomD >
	{
		friend class SyncD;
	public:
		int	FixedUpdate();


	public:
		typedef std::map<int, Entity *>		EntityMap;
		Entity *CreateRoom(int nRoomId);
		Entity *GetRoom(int nRoomId);
		void	CloseRoom(int nRoomId);

		int  JoinRoom(int nRoomId, Entity *e);
		void LeaveRoom(int nRoomId, Entity *e);
		int InitializeRoom(Comp_RoomData * pRoomData);
	protected:
		EntityMap		m_RoomMap;

	};

	//--------------------------------------------------------
	class SyncD : public TSystemBase<SYS_SYNCROOM>, public TSingleton < SyncD >
	{
	public:
		SyncD(){}
		~SyncD(){}

		int	FixedUpdate();

		void ProcessJoin();

		void ProcessSync();
		void SendToRoom(Comp_RoomData *room, Entity *me, char *sSync, uint32 size, int bExceptSelf = true);
		void SyncAction(Entity * pEntity, ProtoC2S_Action * pData, uint32 uSize);
		int PackEntity(Entity *e, ProtoAddPlayer *pSync);
	};

}
