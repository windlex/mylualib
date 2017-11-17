#include "ecs_stdafx.h"
#include "KSession.h"
#include "Common\KG_Package.h"
#include "KProtocolHandler.h"
#include "CompSession.h"

KSession::KSession(IKG_SocketStream *ps)
: m_piSocketStream(ps), m_pBuffer(NULL), m_pHandler(NULL)
{
	m_pBuffer = KG_MemoryCreateBuffer(MAX_BUFFER_SIZE);
	timeval timeout = {0, 100};
	ps->SetTimeout(&timeout);
}

KSession::~KSession()
{
	KG_COM_RELEASE(m_pBuffer);
}

int KSession::Breathe()
{
	int nRet = FALSE;
	while (KG_Package_RecvBuffer(NULL, m_piSocketStream, &m_pBuffer) && (m_pBuffer != NULL))
	{
		char* pCharBuf = (char*)m_pBuffer->GetData();
		size_t uSize = (size_t)m_pBuffer->GetSize();
		OnRecv(pCharBuf, uSize);
		KG_COM_RELEASE(m_pBuffer);
	}
	//m_pHandler->Breathe();
	return nRet;
}

int KSession::Send(char *szBuff, unsigned int uSize)
{
	int nResult = FALSE;
	IKG_Buffer *piBuffer = NULL;
	KG_PROCESS_ERROR(uSize < 0xFFFF);

	piBuffer = KG_MemoryCreateBuffer(uSize);
	KG_PROCESS_ERROR(piBuffer);
	void *pData = piBuffer->GetData();
	memcpy(pData, szBuff, uSize);
	//printf("[KSession:Send] [Proto=%d, Size=%d]\n", *(uint8*)pData, uSize);
	nResult = m_piSocketStream->Send(piBuffer);
Exit0:
	KG_COM_RELEASE(piBuffer);
	return nResult;
}

int KSession::OnRecv(char *szBuff, unsigned int uSize)
{
	return m_pHandler->ProcessMessage(this, szBuff, uSize);
}

int KSession::IsAlive()
{
	return m_piSocketStream->IsAlive();
}

void KSession::SetHandler( KProtocolHandler *h )
{
	m_pHandler = h;
}

int KSession::OnDisconnect()
{
	struct in_addr			sRemoteIP;
	u_short uRemotePort = 0;

	int nRetCode = m_piSocketStream->GetRemoteAddress(&sRemoteIP, &uRemotePort);
	KGLOG_PROCESS_ERROR(nRetCode);

	char *pcszIP = inet_ntoa(sRemoteIP);
	int dwIP = sRemoteIP.s_addr;
	KGLOG_PROCESS_ERROR(pcszIP);

	KG_COM_RELEASE(m_piSocketStream);
	printf("[%s] Connection lost: %d(%s, %d)\n", "???", 0, pcszIP, uRemotePort);
Exit0:
	return m_pHandler->OnDisconnect(this);
}

void KSession::SetSessionComponent(ECS::CompSession *pComp)
{
	m_pSessionComponent = pComp;
}

//////////////////////////////////////////////////////////////////////////
int KSessionMgr::Open(int id, const char *szIp, int nPort, KProtocolHandler *pHandler, int bSecurity)
{
	timeval timeout = {0, 100};
	if (acceptors.find(id) != acceptors.end())
		return FALSE;

	int nRet = FALSE;
	KAcceptor *pAcceptor = new KAcceptor;
	nRet = pAcceptor->Open(szIp, nPort);
	KG_PROCESS_ERROR(nRet);
	acceptors[id] = pAcceptor;
	pAcceptor->bSecurity = bSecurity;
	pAcceptor->SetTimeout(&timeout);
	pAcceptor->m_pHandler = pHandler;
Exit0:
	if (!nRet)
		KG_DELETE(pAcceptor);
	return nRet;
}

int KSessionMgr::Close(int id)
{
	AcceptorMap::iterator it = acceptors.find(id);
	if (it == acceptors.end())
		return FALSE;
	else
	{
		KAcceptor *pAcceptor = it->second;
		pAcceptor->Close();
		acceptors.erase(it);
		KG_DELETE(pAcceptor);
	}
	return TRUE;
}

int KSessionMgr::Breathe()
{
	int nRet = FALSE;
	AcceptorMap::iterator it_acceptor = acceptors.begin();
	for (; it_acceptor != acceptors.end(); it_acceptor++)
	{
		KAcceptor *pAcceptor = it_acceptor->second;
		IKG_SocketStream *pss = NULL;
		if (pAcceptor->bSecurity == KSG_ENCODE_DECODE_NONE)
			pss = pAcceptor->Accept();
		else
			pss = pAcceptor->AcceptSecurity((ENCODE_DECODE_MODE)pAcceptor->bSecurity);
		if (!pss)
			continue;
		KSession *s = new KSession(pss);
		if (s)
		{
			s->SetHandler(pAcceptor->m_pHandler);
			pAcceptor->m_pHandler->OnConnected(s);

			sessions.insert(s);
		}
		else
		{
			printf("[KSessionMgr] [Accept Error]");
		}
	}
	for (it_acceptor = acceptors2.begin(); it_acceptor != acceptors2.end(); it_acceptor++)
	{
		KAcceptor2 *pAcceptor = (KAcceptor2 *)it_acceptor->second;
		pAcceptor->Breathe();
	}
	SessionList::iterator it_session = sessions.begin();
	while (it_session != sessions.end())
	{
		KSession *session = *it_session;
		if (!session->IsAlive())
		{
			it_session = sessions.erase(it_session);
			session->OnDisconnect();

			delete session;
		}
		else
		{
			session->Breathe();
			it_session++;
		}
	}
	return TRUE;
}

const int MAX_ACCEPT_EACH_WAIT = 8;
int KSessionMgr::Open2( int id, const char *szIp, int nPort, KProtocolHandler *pHandler, int bSecurity /*= -1*/ )
{
	KAcceptor2 *acceptor = new KAcceptor2;
	int nRet = acceptor->Init(szIp, nPort, MAX_ACCEPT_EACH_WAIT, 8192, 102400, KSG_ENCODE_DECODE_NONE, NULL);
	KGLOG_PROCESS_ERROR(nRet);
	acceptor->m_pHandler = pHandler;

	acceptors2[id] = acceptor;

	printf("Open2 OK\n");
Exit0:
	return nRet;
}

KSession	* KSessionMgr::Connect(const char *szIp, int nPort, KProtocolHandler *pHandler, const char *bindIp /*= NULL*/, int bindPort /*= 0*/)
{
	int nRet = FALSE;
	KSession *session = NULL;
	KG_SocketConnector *pConn = new KG_SocketConnector;
	nRet = pConn->Bind(bindIp, bindPort);
	KGLOG_PROCESS_ERROR(nRet);
	IKG_SocketStream *pss = pConn->ConnectSecurity(szIp, nPort, KSG_ENCODE_DECODE);
	KGLOG_PROCESS_ERROR(pss);
	session = new KSession(pss);
	session->SetHandler(pHandler);
	KG_PROCESS_ERROR(session);
	sessions.insert(session);
	pHandler->OnConnected(session);
Exit0:
	if (!nRet)
		KG_DELETE(session);
	KG_DELETE(pConn);
	return session;
}


//-----------------------------------------------------------
int KAcceptor2::Breathe()
{
//	printf("KAcceptor2::Breathe ...\n");
	while (true)
	{
		int                 nEventCount     = 0;
		KG_SOCKET_EVENT*    pSocketEvent    = NULL;
		KG_SOCKET_EVENT*    pSocketEventEnd = NULL;

		int nRetCode = Wait(MAX_SOCKET_EVENT, m_pSocketEvents, &nEventCount);
		KGLOG_PROCESS_ERROR(nRetCode);

		if (nEventCount == 0)
			break;

		pSocketEventEnd = m_pSocketEvents + nEventCount;
		for (pSocketEvent = m_pSocketEvents; pSocketEvent < pSocketEventEnd; pSocketEvent++)
		{
			if (pSocketEvent->uEventFlag & KG_SOCKET_EVENT_ACCEPT)
			{
				ProcessNewConnection(pSocketEvent->piSocket);
				continue;
			}

			if (!(pSocketEvent->uEventFlag & KG_SOCKET_EVENT_IN))
			{
				KGLogPrintf(KGLOG_DEBUG, "Unexpected socket event: %u", pSocketEvent->uEventFlag);
				KG_COM_RELEASE(pSocketEvent->piSocket);
				continue;
			}

			ProcessPackage(pSocketEvent->piSocket);
		}
	}
Exit0:
	return 0;
}

int KAcceptor2::ProcessNewConnection( IKG_SocketStream *piSocket )
{
	int					nResult         = false;
	int					nRetCode        = false;
	u_short				uRemotePort     = 0;
	const char*			pcszIP          = NULL;
	DWORD				dwIP			= 0;
	struct in_addr		sRemoteIP;

	assert(piSocket);
	KSession *pSession = new KSession(piSocket);
	int nSession = snSessionSeed++;
	piSocket->SetUserData((void *)nSession);
	m_kSessionMap[nSession] = pSession;

	nRetCode = piSocket->GetRemoteAddress(&sRemoteIP, &uRemotePort);
	KGLOG_PROCESS_ERROR(nRetCode);

	pcszIP = inet_ntoa(sRemoteIP);
	dwIP = sRemoteIP.s_addr;
	KGLOG_PROCESS_ERROR(pcszIP);

	KGLogPrintf(KGLOG_INFO, "New connection from %s:%u, index = %d\n", pcszIP, uRemotePort, "???");

	printf("[%s] New connection from %s:%u, index = %d\n", "???", pcszIP, uRemotePort, 0);

	pSession->SetHandler(m_pHandler);
	m_pHandler->OnConnected(pSession);

	nResult = true;
Exit0:
	return nResult;
}

int KAcceptor2::ProcessPackage( IKG_SocketStream *piSocket )
{
	int					nResult         = false;
	int					nRetCode        = false;
	int					nSessionId		= 0;
	KSession*			pSession		= NULL;
	IKG_Buffer*			piBuffer        = NULL;
	char*				pData			= NULL;
	size_t				uDataLen		= 0;

	assert(piSocket);

	nSessionId = (int)piSocket->GetUserData();
	SessionMap::iterator it = m_kSessionMap.find(nSessionId);
	if (it == m_kSessionMap.end())
	{
		KGLOG_PROCESS_ERROR(0);
	}
	pSession = it->second;
	KGLOG_PROCESS_ERROR(pSession);

	while (true)
	{
		KG_COM_RELEASE(piBuffer);		

		nRetCode = piSocket->Recv(&piBuffer);

		if (nRetCode == -2)
			break;
		if (nRetCode == -1)
		{
			printf("[%s] Connection lost: %d(%s, %d)\n", "???", 0, "??", 0);
			pSession->OnDisconnect();
			break;
		}

		KGLOG_PROCESS_ERROR(piBuffer);

		//pPlayer->nLastPingTime = m_pGateway->m_nTimeNow;

		pData = (char *)piBuffer->GetData();
		KGLOG_PROCESS_ERROR(pData);

		uDataLen = piBuffer->GetSize();

		pSession->OnRecv(pData, uDataLen);
	}

	nResult = true;
Exit0:
	KG_COM_RELEASE(piBuffer);
	return nResult;
}

