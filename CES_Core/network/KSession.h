#ifndef _PART_KSESSION_H__
#define _PART_KSESSION_H__

#include <map>
#include "Common/KG_Socket.h"
#include "KGPublic.h"
#include "SessionComponent.h"

const int MAX_BUFFER_SIZE = 0xFFFF;

class KSession;
class KProtocolHandler;

class KAcceptor : public KG_SocketAcceptor
{
	friend class KSessionMgr;
public:

protected:
	int		bSecurity;
	KProtocolHandler *m_pHandler;
};

#define MAX_WAIT_ACCEPT     16
#define MAX_SOCKET_EVENT    1024 + MAX_WAIT_ACCEPT

class KAcceptor2 : public KAcceptor, public KG_SocketServerAcceptor
{
public:
	KAcceptor2()
		:m_pSocketEvents(NULL), snSessionSeed(1234)
	{
		m_pSocketEvents = new KG_SOCKET_EVENT[MAX_SOCKET_EVENT];
	}
	~KAcceptor2()
	{
		KG_DELETE_ARRAY(m_pSocketEvents);
	}
	int Breathe();
	int ProcessPackage(IKG_SocketStream *piSocket);
	int ProcessNewConnection(IKG_SocketStream *piSocket);

	typedef std::map<int, KSession *> SessionMap;
private:
	int					snSessionSeed;
	KG_SOCKET_EVENT		*m_pSocketEvents;
	SessionMap			m_kSessionMap;
};

namespace ECS
{
	class SessionCompnent;
}

class KSession
{
public:
	KSession(IKG_SocketStream *ps);
	~KSession(void);

	int		Breathe();
	int		Send(char *szBuff, unsigned int uSize);
	int		IsAlive();
	void	SetHandler(KProtocolHandler *h);
	int		OnRecv(char *szBuff, unsigned int uSize);
	int		OnDisconnect();

protected:
	IKG_SocketStream	*m_piSocketStream;
	IKG_Buffer			*m_pBuffer;
	KProtocolHandler	*m_pHandler;

public:
	void SetSessionComponent(ECS::SessionCompnent *pComp);
	ECS::SessionCompnent *GetSessionComponent(){ return m_pSessionComponent; }
protected:
	ECS::SessionCompnent		*m_pSessionComponent;
};

class KSessionMgr
{
public:
	KSessionMgr(){};
	~KSessionMgr(){};

	typedef std::map<int, KAcceptor*>	AcceptorMap;
	typedef std::set<KSession*>			SessionList;

	int			Open(int id, const char *szIp, int nPort, KProtocolHandler *pHandler, int bSecurity = -1);
	int			Open2(int id, const char *szIp, int nPort, KProtocolHandler *pHandler, int bSecurity = -1);
	KSession	*Connect(const char *szIp, int nPort, KProtocolHandler *pHandler, const char *bindIp = NULL, int bindPort = 0);
	int			Breathe();
	int			Close(int id);
protected:
	AcceptorMap	acceptors;
	AcceptorMap	acceptors2;
	SessionList	sessions;
	SessionList autoSessions;
};

#endif //_PART_KSESSION_H__
