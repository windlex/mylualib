#include "ecs_stdafx.h"
#include "KClientHandler.h"
#include "..\01.Entity\Entity.h"
#include "CompSession.h"
#include "..\utils\Utils.h"
#include "..\02.Component\CompDisp.h"
#include "..\02.Component\CompMove.h"
#include "..\room\RoomD.h"
#include "..\room\room_data.h"

using namespace ECS;

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
	CompSession *sc = new CompSession();
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
	CompSession *sc = pSession->GetSessionComponent();
	Manager::GetInstance()->DestroyEntity(sc->GetOwner()->GetUUID());
	return FALSE;
}

int KClientHandler::OnLogin(KSession *pSession, char *szBuff, unsigned int uSize)
{
	ProtoLogin *pRequire = (ProtoLogin *)szBuff;
	CompSession *sc = pSession->GetSessionComponent();
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
	CompSession *sc = pSession->GetSessionComponent();
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
	CompSession *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	CompPosition *pPos = sc->Sibling<CompPosition>();
	if (pPos)
	{
		pPos->pos = Vector3(pRequire->x, pRequire->y, pRequire->z);
		pPos->ndir = pRequire->dir;
		pPos->bUpdate = 1;
	}

	CompMove *move = sc->Sibling<CompMove>();
	if (move)
	{
		move->moveX = pRequire->moveX;
		move->moveZ = pRequire->moveZ;
	}

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
	CompSession *sc = pSession->GetSessionComponent();
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
	CompSession *sc = pSession->GetSessionComponent();
	Entity *pEntity = sc->GetOwner();

	SyncD::GetInstance()->SyncAction(pEntity, pData, uSize);

	return TRUE;
}

