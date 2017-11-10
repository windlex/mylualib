#include "ecs_stdafx.h"

#include "ECS.h"
#include "01.Entity\Entity.h"
#include "02.Component\CompMove.h"
#include "03.System\SysMovement.h"
#include "network\SysNetwork.h"
#include "utils\Utils.h"
#include "room\room_d.h"
#include "..\..\base\include\engine\kg_time.h"

using namespace ECS;

class Disp : public TSystemBase<2>
{
public:
	Disp(){}
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
int test()
{
	Manager *mgr = Manager::GetInstance();
	mgr->AddSystem(new SysMovement());
	mgr->AddSystem(new Disp());

	for (int i = 0; i < 10; i++)
	{
		Entity *e = mgr->CreateEntity();
		Vector3 pos = { Random(1, 5), Random(1, 5), 0 };
		Vector3 v = { Random(1, 5), Random(1, 5), 0 };
		Vector3 a = { Random(1, 5), Random(1, 5), 0 };
		e->AddComponent(CompPosition::Create(pos));
		e->AddComponent(CompMove::Create(v, a));
	}

	for (int i = 0; i < 100; i++)
	{
		mgr->FixedUpdate();
	}
	return true;
}

namespace ECS
{
	class FPSTest : public TSystemBase < 111 >
	{
	public:
		int Update()
		{
			static int fps = 0;
			static uint32 lastSecond = time(nullptr);
			uint32 now = time(nullptr);
			if (now <= lastSecond)
				fps++;
			else
			{
				FPS1 = fps + 1;
				fps = 0;
				lastSecond = now;
			}
			return TRUE;
		}
		int FixedUpdate()
		{
			static int fps = 0;
			static uint32 lastSecond = time(nullptr);
			uint32 now = time(nullptr);
			if (now <= lastSecond)
				fps++;
			else
			{
				FPS2 = fps + 1;
				fps = 0;
				lastSecond = now;
				printf("\r[FPS] %d / %d, Entity:%d, Component:%d ", FPS1, FPS2, 
					Manager::GetInstance()->EntityCount(),
					Manager::GetInstance()->ComponentCount());
			}
			return TRUE;
		}

		int FPS1;
		int FPS2;
	};
	void setup()
	{
		//test();
		Manager *mgr = Manager::GetInstance();
		mgr->AddSystem(new SysNetwork());
		mgr->AddSystem(RoomD::GetInstance());
		mgr->AddSystem(new FPSTest());
	}
}
