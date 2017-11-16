#pragma once
#include "..\03.System\SystemBase.h"
#include "ksession.h"

namespace ECS {
	class SysNetwork : public TSystemBase<SYS_NETWORK>
	{
	public:
		SysNetwork(){}

		int Init();
		int	FixedUpdate();
		int Update();

	protected:
		KSessionMgr mk_SessionMgr;
	};
}
