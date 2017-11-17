#pragma once
#include "..\02.Component\Component.h"

namespace ECS {

	struct CompCollider : public Component
	{
		CompCollider(){}

	};
	struct CompCollider_Bullet : CompCollider
	{

	};
	struct CompCollider_Tank : CompCollider
	{

	};
	struct CompCollider_Building : CompCollider
	{

	};
	struct CompCollider_Food : CompCollider
	{

	};
}
