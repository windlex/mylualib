#pragma once
#include "engine\KSingleton.h"
#include "KProtocolHandler.h"
#include "K_GSnC_Protocol.h"

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
