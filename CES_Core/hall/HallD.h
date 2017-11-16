#pragma once
#include "..\03.System\SystemBase.h"
#include "engine\KSingleton.h"

namespace ECS{
	class HallD : public TSystemBase<SYS_HALL>, TSingleton < HallD >
	{
	public:
		HallD();
	};
}