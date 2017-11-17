#include "ecs_stdafx.h"
#include "..\01.Entity\Entity.h"
#include "..\02.Component\CompMove.h"
#include "Utils.h"
#include "..\02.Component\CompDef.h"
#include "..\battle\CompCollider.h"

namespace ECS {
	Entity *CreatePlayer()
	{
		Entity *pEntity = Manager::GetInstance()->CreateEntity();
		CompPosition *comp = pEntity->AddComponent<CompPosition>();
		pEntity->AddComponent<CompMove>();
		pEntity->AddComponent<CompCollider>();
		return pEntity;
	}
}

int Random(int a, int b)
{
	return (int)rand() % (b - a) + a;
}
