#include "ecs_stdafx.h"

#include "ECS.h"
#include "01.Entity\Entity.h"
#include "02.Component\CompMove.h"
#include "03.System\SysMovement.h"

using namespace ECS;

class Disp : public SystemBase
{
public:
	Disp()
		:SystemBase(2)
	{}
	~Disp(){}

	int FixedUpdate()
	{
		std::vector<CompPosition *> group;
		Manager::GetInstance()->ComponentItr<CompPosition>(group);
		for (CompPosition *p : group)
		{
			int eid = p->GetOwner()->GetUUID();
			CompMove *m = p->Sibling<CompMove>();
			printf("[%d] pos:{%d,%d}, v:{%d, %d}, a:{%d, %d}\n", eid,
				p->pos.x, p->pos.y,
				m->velocity.x, m->velocity.y,
				m->acceleration.x, m->acceleration.y);
		}
		return TRUE;
	}
};
int Random(int a, int b)
{
	return (int)rand()% (b - a) + a;
}
int test()
{
	Manager *mgr = Manager::GetInstance();
	mgr->AddSystem(new SysMovement());
	mgr->AddSystem(new Disp());

	for (int i = 0; i < 10; i++)
	{
		Entity *e = mgr->CreateEntity();
		Vector2 pos = { Random(1, 5), Random(1, 5) };
		Vector2 v = { Random(1, 5), Random(1, 5) };
		Vector2 a = { Random(1, 5), Random(1, 5) };
		e->AddComponent(1, CompPosition::Create(pos));
		e->AddComponent(2, CompMove::Create(v, a));
	}

	for (int i = 0; i < 100; i++)
	{
		mgr->FixedUpdate();
	}
	return true;
}

int main()
{
	test();
	return 0;
}