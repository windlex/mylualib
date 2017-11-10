#include "ecs_stdafx.h"
#include "KProtocolHandler.h"
#include <Engine\KGLog.h>
#include "K_GSnC_Protocol.h"

KProtocolHandler::KProtocolHandler(void)
{
}

KProtocolHandler::~KProtocolHandler(void)
{
}

int KProtocolHandler::ProcessMessage(KSession *pSession, char *szBuff, unsigned int uSize)
{
	return 0;
}

//////////////////////////////////////////////////////////////////////////
int KProtocolMapHandler::ProcessMessage(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoHead *pHead = (ProtoHead *)szBuff;
	if (m_SizeMap[pHead->cProtocol] >= 0 && m_SizeMap[pHead->cProtocol] != uSize)
	{
		KGLogPrintf(KGLOG_ERR, "[ProtocolMapHandler] [Error Buff Size] [recvSize=%d, checkSize=%d]",
			uSize, m_SizeMap[pHead->cProtocol]);
		return FALSE;
	}
	HandleFunc pFunc = m_HandlerMap[pHead->cProtocol];
	if (!pFunc)
	{
		KGLogPrintf(KGLOG_ERR, "[ProtocolMapHandler] [Error Msg Handler] [Protocol=%d, Size=%d]",
			pHead->cProtocol, uSize);
		return FALSE;
	}
	printf("[ProtocolMapHandler] [RECV] [Protocol=%d, Size=%d]\n",
		pHead->cProtocol, uSize);
	return (this->*pFunc)(pSession, szBuff, uSize);
}
