#include "ecs_stdafx.h"
#include "PlayerSaveLoadD.h"
#include "engine\kglog.h"
#include "..\timeline\TimelineD.h"

namespace ECS {
#define MAX_SAVE_SIZE	64 * 1024
	PlayerSaveLoadD::PlayerSaveLoadD()
	{

	}

	int PlayerSaveLoadD::FixedUpdate()
	{
		GET_COMPONENT_GROUP(CompSave, group);
		for (CompSave *m : group)
		{
			uint32 now = TimelineD::GetInstance()->now();
			if (now - m->m_uLastSave < TIME_SAVE_INTERVAL)
				continue;
			char szBuffer[MAX_SAVE_SIZE] = { 0 };
			char *pData = szBuffer;
			Entity *e = m->GetOwner();
			Entity::ComponentList *pList = e->GetAllComponent();
			for (IComponent *c : *pList)
			{
				SerializeableComponent *pSC = dynamic_cast<SerializeableComponent*>(c);
				uint32 nSize = 0;
				int nRetCode = pSC->Pack(pData, nSize);
				if (!nRetCode)
				{
					LogError("[PlayerSaveLoadD] [Pack Error]", 123);
				}
				pData += nSize;
			}
		}
			return TRUE;
	}

};
