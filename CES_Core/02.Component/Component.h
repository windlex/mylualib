#pragma once
#include "CompDef.h"
#include "..\01.Entity\Entity.h"

namespace ECS {
	class Entity;
	class Component : public IComponent
	{
	public:
		Component(){}
		virtual ~Component(){}

	public:
		template<class T>
		T * Sibling()
		{
			return m_pOwner->GetComponent<T>();
		}
	};
}