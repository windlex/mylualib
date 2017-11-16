#pragma once
#include "SystemBase.h"

namespace ECS {
	class SysMovement : public TSystemBase<SYS_MOVEMENT>
	{
	public:
		SysMovement(){}

		int	FixedUpdate();
	};
}