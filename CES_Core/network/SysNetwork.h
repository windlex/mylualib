#pragma once
#include "..\03.System\SystemBase.h"
#include <map>
#include "KGPublic.h"
#include <engine\KSingleton.h>
#include "../01.Entity/Entity.h"
#include "KSession.h"
#include "KProtocolHandler.h"

namespace ECS {
	class SysNetwork : public TSystemBase<3>
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

class KClientHandler : public KProtocolMapHandler, public TSingleton < KClientHandler >
{
public:
	int Init();

	virtual int OnConnected(KSession *pSession);
	virtual int OnDisconnect(KSession *pSession);

	int OnLogin(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnPos(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnFire(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnHit(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnSceneLoaed(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnRoleData(KSession *pSession, char *szBuff, unsigned int uSize);
	int OnAction(KSession *pSession, char *szBuff, unsigned int uSize);
};
