#ifndef __KPROTOCOLHANDLER_H__
#define __KPROTOCOLHANDLER_H__

#include <string.h>
#include "engine.h"

#define MAX_PROTO_COUNT	1024
#pragma pack(push, 1)
struct ProtoHead
{
	uint8	cProtocol;

	ProtoHead(uint8 proto)
		:cProtocol(proto)
	{}
};
template<int proto>
struct TProtoHead : public ProtoHead
{
	TProtoHead()
		:ProtoHead(proto)
	{}
};

struct ProtoHeadLength : public ProtoHead
{
	uint16	Size;

	ProtoHeadLength(uint8 proto)
		:ProtoHead(proto)
	{}
};
template<int proto>
struct TProtoHeadLength : ProtoHeadLength
{
	TProtoHeadLength()
		:ProtoHeadLength(proto)
	{}
};
#pragma pack(pop)

class KSession;
class KProtocolHandler
{
public:
	KProtocolHandler(void);
	~KProtocolHandler(void);

	virtual int OnConnected(KSession *pSession) = 0;
	virtual int OnDisconnect(KSession *pSession) = 0;
	virtual	int ProcessMessage(KSession *pSession, char *szBuff, unsigned int uSize);
};


class KProtocolMapHandler : public KProtocolHandler
{
public:
	KProtocolMapHandler()
	{
		memset(m_HandlerMap, 0, sizeof(m_HandlerMap));
		memset(m_SizeMap, 0, sizeof(m_SizeMap));
	}
	~KProtocolMapHandler(){};

	typedef int (KProtocolMapHandler::*HandleFunc)(KSession *pSession, char *szBuff, unsigned int uSize);

	virtual int ProcessMessage(KSession *pSession, char *szBuff, unsigned int uSize);
protected:
	HandleFunc		m_HandlerMap[MAX_PROTO_COUNT];
	int				m_SizeMap[MAX_PROTO_COUNT];
};
#define REGISTER_HANDLE(id, handler, size) \
	m_HandlerMap[id] = (HandleFunc)&handler;\
	m_SizeMap[id] = size;

#endif //__KPROTOCOLHANDLER_H__
