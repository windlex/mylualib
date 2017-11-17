#pragma once
#include "RoomD.h"
#include "..\02.Component\Component.h"

namespace ECS {
	class CompRegion : public Component
	{
	public:
		int m_nRoomId;
		int regionX;
		int regionY;

		EntityList	m_entityList;

	};

}