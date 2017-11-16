#pragma once
#include "..\03.System\SystemBase.h"

namespace ECS {
	class CollidingD : public TSystemBase < SYS_COLLIDING >
	{
	public:
		CollidingD(){}

		int	FixedUpdate();
	};
}