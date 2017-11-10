#pragma once
#include "..\01.Entity\Entity.h"
#include "CompSave.h"
#include "..\03.System\SystemBase.h"
#include "..\02.Component\SerializeComponent.h"

#define GET_COMPONENT_GROUP(COMPNAME, GROUP)\
std::vector<COMPNAME *> GROUP;\
Manager::GetInstance()->ComponentItr<COMPNAME>(GROUP);

namespace ECS {
	class PlayerSaveLoadD : public TSystemBase<SYS_PLAYERSAVELOAD>
	{
	public:
		PlayerSaveLoadD();

		int FixedUpdate();
	};

};
