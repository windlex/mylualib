#pragma once
#include "..\01.Entity\Entity.h"

namespace ECS {
	class CompTimer : public IComponent
	{
	public:
		int		m_uLastSave;
	};
};
