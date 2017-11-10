// ECS.cpp : 定义控制台应用程序的入口点。
//

#include "ecs_stdafx.h"
#include <map>
#include "ECS.h"
#include "01.Entity\Entity.h"
#include "03.System\SystemBase.h"
using namespace std;

namespace ECS {
	Manager::Manager()
	{

	}

	Manager::~Manager()
	{

	}

	int Manager::Update()
	{
		for (auto &s : m_SystemMap)
		{
			s.second->Update();
		}
		return TRUE;
	}

	int Manager::FixedUpdate()
	{
		for (auto &s : m_SystemMap)
		{
			s.second->FixedUpdate();
		}
		return TRUE;
	}
	//--------------------------------------------------------------------
	Entity	* Manager::CreateEntity()
	{
		static uint32	uuidSeed = 1;
		Entity *pEntity = new Entity(uuidSeed++);
		if (!pEntity){
			//Debug.LogError("CreateEntity Error");
			return NULL;
		}
		m_EntityMap[pEntity->GetUUID()] = pEntity;
		return pEntity;
	}
	void Manager::DestroyEntity(uint32 uuid)
	{
		EntityMap::iterator it = m_EntityMap.find(uuid);
		if (it == m_EntityMap.end())
		{
			return;
		}
		Entity *e = it->second;
		m_EntityMap.erase(it);
		delete e;
	}
	//--------------------------------------------------------------------
	//SystemBase *Manager::GetSystem()
	//{
	//	return NULL;
	//}


	int Manager::AddSystem(SystemBase *pSystem)
	{
		m_SystemMap.insert(std::make_pair(pSystem->GetID(), pSystem));
		pSystem->Init();
		return TRUE;
	}


}