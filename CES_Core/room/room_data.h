#pragma once
#include "..\01.Entity\Entity.h"
#include "room_d.h"

namespace ECS {
	class CompJoinRoom : public Component
	{
	public:
		int		nRoomId;
	};
	class Comp_RoomData : public Component
	{
	public:
		typedef std::vector<Entity *>	EntityList;
		int			m_nRoomId;
		EntityList	m_entityList;
	};

	class SComp_RoomMap : public TSingleton<SComp_RoomMap>
	{
	public:
		typedef std::map<int, Comp_RoomData *>	RoomMap;
		RoomMap		m_kRoomMap;

		Comp_RoomData *CreateRoom(int nRoomId)
		{
			RoomMap::iterator it = m_kRoomMap.find(nRoomId);
			if (it != m_kRoomMap.end())
				return it->second;
			Comp_RoomData *pRoom = new Comp_RoomData();
			pRoom->m_nRoomId = nRoomId;
			m_kRoomMap[nRoomId] = pRoom;
			return pRoom;
		}
		Comp_RoomData *GetRoom(int nRoomId)
		{
			RoomMap::iterator it = m_kRoomMap.find(nRoomId);
			if (it != m_kRoomMap.end())
				return it->second;
			return nullptr;
		}
	};

	class Comp_RoomId : public Component
	{
	public:
		Comp_RoomId()
			:m_nRoomId(0)
		{}
		~Comp_RoomId();

		int m_nRoomId;
	};
}