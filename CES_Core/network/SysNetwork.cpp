#include "ecs_stdafx.h"
#include "SysNetwork.h"
#include "..\02.Component\CompMove.h"
#include "..\ECS.h"
#include "K_GSnC_Protocol.h"
#include "..\utils\Utils.h"
#include "SessionComponent.h"
#include "..\02.Component\CompDisp.h"
#include "..\room\room_d.h"
#include "..\room\comp_joinroom.h"

using namespace ECS;
namespace ECS {

	int SysNetwork::Init()
	{
		KClientHandler::GetInstance()->Init();
		mk_SessionMgr.Open2(1, "0.0.0.0", 5555, KClientHandler::GetInstance());
		return TRUE;
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

int KClientHandler::Init()
{
	REGISTER_HANDLE(PROTO_C2GS_LOGIN, KClientHandler::OnLogin, sizeof(ProtoLogin));
	REGISTER_HANDLE(PROTO_C2GS_SCENE_LOADED, KClientHandler::OnSceneLoaed, sizeof(ProtoSceneLoaded));
	REGISTER_HANDLE(PROTO_C2GS_POS, KClientHandler::OnPos, sizeof(ProtoPos));
	REGISTER_HANDLE(PROTO_C2GS_FIRE, KClientHandler::OnFire, sizeof(ProtoFire));
	REGISTER_HANDLE(PROTO_C2GS_HIT, KClientHandler::OnHit, sizeof(ProtoHit));
	REGISTER_HANDLE(PROTO_C2GS_ROLE_DATA, KClientHandler::OnRoleData, -1);
	REGISTER_HANDLE(PROTO_C2GS_ACTION, KClientHandler::OnAction, -1);
	return TRUE;
}

int KClientHandler::OnConnected(KSession *pSession)
{
	Entity *pPlayer = ECS::CreatePlayer();
	SessionCompnent *sc = new SessionCompnent();
	KGLOG_PROCESS_ERROR(sc);
	sc->pSession = pSession;
	pSession->SetSessionComponent(sc);
	pPlayer->AddComponent(sc);

	return TRUE;
Exit0:
	return FALSE;
}

int KClientHandler::OnDisconnect(KSession *pSession)
{
	SessionCompnent *sc = pSession->GetSessionComponent();
	Manager::GetInstance()->DestroyEntity(sc->GetOwner()->GetUUID());
	return FALSE;
}

int KClientHandler::OnLogin(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoLogin *pRequire = (ProtoLogin *)szBuff;
	SessionCompnent *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	CompDisp *disp = pEntity->AddComponent<CompDisp>();
	disp->SetName(pRequire->szName);

	ProtoLoginResult sResult;
	sResult.nResult = TRUE;
	sResult.uuid = pEntity->GetUUID();

	pSession->Send((char*)&sResult, sizeof(sResult));
	return TRUE;
}
int KClientHandler::OnSceneLoaed(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoSceneLoaded *pRequire = (ProtoSceneLoaded *)szBuff;
	SessionCompnent *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	CompPosition *pPos = sc->Sibling<CompPosition>();
	pPos->pos = Vector3(pRequire->x, pRequire->y, pRequire->z);

	//RoomD::GetInstance()->AddEntity(pEntity);
	CompJoinRoom *pJoin = pEntity->AddComponent<CompJoinRoom>();
	pJoin->nRoomId = 1;

	return TRUE;
}
int KClientHandler::OnPos(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoPos *pRequire = (ProtoPos *)szBuff;
	SessionCompnent *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	CompPosition *pPos = sc->Sibling<CompPosition>();
	pPos->pos = Vector3(pRequire->x, pRequire->y, pRequire->z);
	pPos->ndir = pRequire->dir;
	pPos->moveX = pRequire->moveX;
	pPos->moveZ = pRequire->moveZ;
	pPos->bUpdate = 1;

	return TRUE;
}
int KClientHandler::OnFire(KSession *pSession, char *szBuff, unsigned int uSize)
{
	return TRUE;
}
int KClientHandler::OnHit(KSession *pSession, char *szBuff, unsigned int uSize)
{
	return TRUE;
}

int KClientHandler::OnRoleData(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoC2S_RoleData *pData = (ProtoC2S_RoleData *)szBuff;
	SessionCompnent *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	CompRoleData *pRoleData = pEntity->GetComponent<CompRoleData>();
	if (!pRoleData)
		pRoleData = pEntity->AddComponent<CompRoleData>();
	pRoleData->SetData(pData->Data, pData->Size);

	return TRUE;
}

int KClientHandler::OnAction(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoC2S_Action *pData = (ProtoC2S_Action *)szBuff;
	SessionCompnent *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	RoomD::GetInstance()->SyncAction(pEntity, pData, uSize);

	return TRUE;
}

