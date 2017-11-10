#pragma once
#include "..\01.Entity\Entity.h"

namespace ECS {
	class CompJoinRoom : public Component
	{
	public:
		int		nRoomId;
	};
}