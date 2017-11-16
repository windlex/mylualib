#include "ecs_stdafx.h"
#include "CollidingD.h"
#include "CompCollider.h"

namespace ECS {
	int CollidingD::FixedUpdate()
	{
		GET_COMPONENT_GROUP(CompCollider, group);
		for (CompCollider *m : group)
		{
		}
		return TRUE;
	}
}
