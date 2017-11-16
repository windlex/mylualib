#pragma once
#include "..\01.Entity\Entity.h"
#include "CompSave.h"
#include "..\03.System\SystemBase.h"
#include "..\02.Component\SerializeComponent.h"

namespace ECS {
#define TIME_SAVE_INTERVAL	(5 * 60)
	class PlayerSaveLoadD : public TSystemBase<SYS_PLAYERSAVELOAD>
	{
	public:
		PlayerSaveLoadD();

		int FixedUpdate();
	};

};
