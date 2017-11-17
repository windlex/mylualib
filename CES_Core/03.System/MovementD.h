#pragma once
#include "SystemBase.h"

namespace ECS {
	class MovementD : public TSystemBase<SYS_MOVEMENT>
	{
	public:
		MovementD(){}

		int	FixedUpdate();
	};
}