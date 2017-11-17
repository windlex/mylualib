#include "ecs_stdafx.h"
#include "MovementD.h"
#include "..\02.Component\CompMove.h"
#include "..\ECS.h"
#include "..\room\regiond.h"

namespace ECS {
	int MovementD::FixedUpdate()
	{
		std::vector<CompMove *> group;
		Manager::GetInstance()->ComponentItr<CompMove>(group);
		for (CompMove *m : group)
		{
			CompPosition *p = m->Sibling<CompPosition>();
			p->pos.x += m->moveX;
			p->pos.z += m->moveZ;

			RegionD::UpdateRegion(p);
			p->bUpdate = TRUE;
		}
		return TRUE;
	}

	/*struct phy {
		CompMove *m_Move;
		CompPosition *m_Pos;
	}
	void PhySys::Tick()
	{
		IWorld *pw = GetWorld();
		pw->Update();

		for (phy &t : GetPhy())
		{
			IProxy *pxy = pw->GetProx(t.phy->pxy);

			CopyTransform(t.m_txx, proxy);
		}
	}
	SomeSystem::Update()
	{
		for (SomeComp *d : ComponentItr<SomeCome>(m_admin))
		{
		d->m_time += timestep;
		this->HerpYouDerp(d, d->Sibling<OtherComp>())
		}
	}*/
}