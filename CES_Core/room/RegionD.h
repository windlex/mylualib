#pragma once
#include <vector>
#include "..\03.System\SystemBase.h"
#include "..\01.Entity\Entity.h"
#include "room_data.h"
#include "..\network\K_GSnC_Protocol.h"

namespace ECS
{
	class RegionD : public TSystemBase<SYS_ROOM>
	{
	public:
		int	FixedUpdate();

		static int UpdateRegion(CompPosition *pos);
	};
}
