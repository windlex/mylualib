#include "ecs_stdafx.h"
#include "CollidingD.h"
#include "CompCollider.h"

namespace ECS {
	int CollidingD::FixedUpdate()
	{
		/*
			groupBullet <---> groupBullet
			groupBullet <---> groupTank
			groupBullet <---> groupBuilding
			groupTank	<---> groupTank
			groupTank	<---> groupBuilding
			groupTank	<---> groupFood
		*/
		GET_COMPONENT_GROUP(CompCollider_Bullet,	groupBullet);
		GET_COMPONENT_GROUP(CompCollider_Tank,		groupTank);
		GET_COMPONENT_GROUP(CompCollider_Building,	groupBuilding);
		GET_COMPONENT_GROUP(CompCollider_Food,		groupFood);
		for (CompCollider *m : groupBullet)
		{
		}
		return TRUE;
	}
}
