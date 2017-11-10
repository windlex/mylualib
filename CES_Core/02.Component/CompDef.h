#pragma once

enum ComponentDef {
	COMP_POS = 1,
	COMP_SESSION,
};

namespace ECS {
	class Entity;
	class IComponent
	{
	public:
		virtual ~IComponent(){}

		Entity *GetOwner(){ return m_pOwner; }
		void SetOwner(Entity *pEntity)
		{
			if (!pEntity)
				return;
			m_pOwner = pEntity;
		}
	protected:
		Entity	*m_pOwner;
	};
}
