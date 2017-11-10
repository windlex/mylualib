#pragma once
#include "SystemBase.h"

namespace ECS {
	class SysMovement : public TSystemBase<1>
	{
	public:
		SysMovement(){}

		int	FixedUpdate();
	};
}