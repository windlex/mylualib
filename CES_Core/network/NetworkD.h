#pragma once
#include "..\03.System\SystemBase.h"
#include "ksession.h"

namespace ECS {
	class NetworkD : public TSystemBase<SYS_NETWORK>
	{
	public:
		NetworkD(){}

		int Init();
		int	FixedUpdate();
		int Update();

	protected:
		KSessionMgr mk_SessionMgr;
	};
}
