#include "ecs_stdafx.h"
#include "..\01.Entity\Entity.h"
#include "..\02.Component\CompMove.h"
#include "Utils.h"
#include "..\02.Component\CompDef.h"

namespace ECS {
	Entity *CreatePlayer()
	{
		Entity *pEntity = Manager::GetInstance()->CreateEntity();
		Vector3 pos = { -1, -1, -1 };
		pEntity->AddComponent(CompPosition::Create(pos));

		return pEntity;
	}
}

int Random(int a, int b)
{
	return (int)rand() % (b - a) + a;
}
