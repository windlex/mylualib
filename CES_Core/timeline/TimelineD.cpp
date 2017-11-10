#include "ecs_stdafx.h"
#include "TimelineD.h"

namespace ECS {
	int TimelineD::FixedUpdate()
	{
		GET_COMPONENT_GROUP(CompTimer, group);
		for (CompTimer *m : group)
		{
		}
	}

	uint32 TimelineD::now()
	{

	}

};
