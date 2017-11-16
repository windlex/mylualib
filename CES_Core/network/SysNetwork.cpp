#include "ecs_stdafx.h"
#include "SysNetwork.h"
#include "engine.h"
#include "KClientHandler.h"
#include "KGameCenterHandler.h"

namespace ECS {

	int SysNetwork::Init()
	{
		int nRet = 0;
		nRet = KClientHandler::GetInstance()->Init();
		KG_PROCESS_ERROR(nRet);
		//mk_SessionMgr.Connect("127.0.0.1", 5551, KLoginHandler::GetInstance());
		//mk_SessionMgr.Connect("127.0.0.1", 5552, KGoddessHandler::GetInstance());
		mk_SessionMgr.Connect("127.0.0.1", 5553, KGameCenterHandler::GetInstance());
		mk_SessionMgr.Open2(1, "0.0.0.0",  5555, KClientHandler::GetInstance());

		nRet = TRUE;
	Exit0:
		return nRet;
	}

	int SysNetwork::Update()
	{
		mk_SessionMgr.Breathe();
		return TRUE;
	}

	int SysNetwork::FixedUpdate()	// todo: Update
	{
		return TRUE;
	}
}
