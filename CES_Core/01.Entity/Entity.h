////////////////////////////////////////////////////////////////////////////////
//
//  FileName    : Entity.h
//  Version     : 1.0
//  Creator     : Windle
//  Create Date : 2017/10/12   16:25
//  Comment     : 
//
////////////////////////////////////////////////////////////////////////////////

#pragma once
#include <engine.h>
#include "..\ECS.h"
#include "..\02.Component\CompDef.h"

namespace ECS {
	enum {
		ERROR_UUID		= 0,
	};

	class Entity
	{
	public:
		Entity(uint32 _uuid) :uuid(_uuid){}
		~Entity(){
			RemoveAllComponent();
		}

	public:
		uint32		GetUUID()
		{
			return uuid;
		}
	protected:
		uint32		uuid;

	public:
		typedef std::vector<IComponent*>	ComponentList;
		int AddComponent(IComponent *pComp)
		{
			pComp->SetOwner(this);
			m_ComponentList.push_back(pComp);
			Manager::GetInstance()->RegisterComponent(pComp);
			return true;
		}
		template<class T>
		T *AddComponent()
		{
			T *pComp = new T();
			AddComponent(pComp);
			return pComp;
		}

		template<class T>
		T *GetComponent()
		{
			ComponentList::iterator it = m_ComponentList.begin();
			for (; it != m_ComponentList.end(); ++it)
			{
				T *pComp = dynamic_cast<T*>(*it);
				if (pComp != NULL)
					return pComp;
			}
			return NULL;
		}
		void RemoveComponent(IComponent *pComp)
		{
			ComponentList::iterator it = m_ComponentList.begin();
			for (; it != m_ComponentList.end(); ++it)
			{
				if (pComp == *it)
				{
					Manager::GetInstance()->UnRegisterComponent(pComp);
					m_ComponentList.erase(it);
					delete pComp;
					return;
				}
			}
		}
		void RemoveAllComponent()
		{
			ComponentList::iterator it = m_ComponentList.begin();
			for (; it != m_ComponentList.end(); ++it)
			{
				IComponent *pComp = *it;
				Manager::GetInstance()->UnRegisterComponent(pComp);
				delete pComp;
			}
			m_ComponentList.clear();
		}
		ComponentList	*GetAllComponent(){ return &m_ComponentList; }
	protected:
		ComponentList	m_ComponentList;
	};

	typedef std::vector<Entity *>	EntityList;

}
