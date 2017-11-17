#include "ecs_stdafx.h"
#include "KGameCenterHandler.h"
#include "NetworkD.h"

using namespace ECS;

int KGameCenterHandler::Init()
{
	//REGISTER_HANDLE(PROTO_C2GS_LOGIN, KClientHandler::OnLogin, sizeof(ProtoLogin));
	//REGISTER_HANDLE(PROTO_C2GS_SCENE_LOADED, KClientHandler::OnSceneLoaed, sizeof(ProtoSceneLoaded));
	//REGISTER_HANDLE(PROTO_C2GS_POS, KClientHandler::OnPos, sizeof(ProtoPos));
	//REGISTER_HANDLE(PROTO_C2GS_FIRE, KClientHandler::OnFire, sizeof(ProtoFire));
	//REGISTER_HANDLE(PROTO_C2GS_HIT, KClientHandler::OnHit, sizeof(ProtoHit));
	//REGISTER_HANDLE(PROTO_C2GS_ROLE_DATA, KClientHandler::OnRoleData, -1);
	//REGISTER_HANDLE(PROTO_C2GS_ACTION, KClientHandler::OnAction, -1);
	return TRUE;
}

int KGameCenterHandler::OnConnected(KSession *pSession)
{
	CompSession *sc = new CompSession();
	KGLOG_PROCESS_ERROR(sc);
	sc->pSession = pSession;
	pSession->SetSessionComponent(sc);

	Entity *pEntity = Manager::GetInstance()->CreateEntity();
	pEntity->AddComponent(sc);

	return TRUE;
Exit0:
	return FALSE;
}

int KGameCenterHandler::OnDisconnect(KSession *pSession)
{
	CompSession *sc = pSession->GetSessionComponent();
	Manager::GetInstance()->DestroyEntity(sc->GetOwner()->GetUUID());
	return FALSE;
}

