////////////////////////////////////////////////////////////////////////////////
//
//  FileName    : ECS.h
//  Version     : 1.0
//  Creator     : Windle
//  Create Date : 2017/10/12   16:18
//  Comment     : Entity Component System
//
////////////////////////////////////////////////////////////////////////////////

#pragma once
#include "engine.h"
#include <engine\KSingleton.h>
#include <vector>
#include "02.Component\CompDef.h"

namespace ECS {
	class Entity;
	class SystemBase;
	class Component;
	class Manager : public TSingleton < Manager > 
	{
	public:
		Manager();
		~Manager();

		int		Init();
		void	UnInit();
		int		Update();
		int		FixedUpdate();
	//--------------------------------------------------------------
	public:
		typedef std::map<uint32, Entity *>		EntityMap;
		Entity	*CreateEntity();
		Entity	*GetEntity(uint32 uuid);
		template<class T>
		std::vector<Entity *> GetEntities()
		{

		}
		void DestroyEntity(uint32 uuid);
		int EntityCount(){ return m_EntityMap.size(); }
	protected:
		EntityMap	m_EntityMap;
	//--------------------------------------------------------------
	public:
		typedef std::map<int, SystemBase *>		SystemMap;
		int		AddSystem(SystemBase *pSystem);
	protected:
		SystemMap	m_SystemMap;
		//--------------------------------------------------------------
	public:
		typedef std::vector<IComponent *>	ComponentList;

		template<class T>
		int ComponentItr(std::vector<T*> &group)	// todo: ”≈ªØ
		{
			for (IComponent *c : m_ComponentList)
			{
				T* pComp = dynamic_cast<T*>(c);
				if (pComp)
					group.push_back(pComp);
			}
			return TRUE;
		}

		void RegisterComponent(IComponent *pComp)
		{
			m_ComponentList.push_back(pComp);
		}
		void UnRegisterComponent(IComponent *pComp)
		{
			ComponentList::iterator it = m_ComponentList.begin();
			for (; it != m_ComponentList.end(); ++it)
			{
				IComponent *pTemp = *it;
				if (pTemp == pComp)
				{
					m_ComponentList.erase(it);
					return;
				}
			}
		}
		int ComponentCount(){ return m_ComponentList.size(); }
	protected:
		ComponentList	m_ComponentList;
	};
}
