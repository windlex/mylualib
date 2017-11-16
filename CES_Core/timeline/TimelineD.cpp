#include "ecs_stdafx.h"
#include "TimelineD.h"
#include "CompTimer.h"
#include <time.inl>

namespace ECS {
	int TimelineD::FixedUpdate()
	{
		GET_COMPONENT_GROUP(CompTimer, group);
		for (CompTimer *m : group)
		{
		}
		return TRUE;
	}

	uint32 TimelineD::now()
	{
		return time(NULL);
	}

};
