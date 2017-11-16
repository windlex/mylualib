#include "ecs_stdafx.h"

#include "ECS.h"
#include "01.Entity\Entity.h"
#include "02.Component\CompMove.h"
#include "03.System\SysMovement.h"
#include "network\SysNetwork.h"
#include "utils\Utils.h"
#include "room\room_d.h"
#include "..\..\base\include\engine\kg_time.h"

namespace ECS
{
	class FPSTest : public TSystemBase <SYS_FPS>
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
