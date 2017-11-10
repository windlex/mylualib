#pragma once
#include "KProtocolHandler.h"

#pragma pack(push, 1)

enum PROTO_C2GS
{
	PROTO_C2GS_LOGIN		= 1,
	PROTO_C2GS_SCENE_LOADED,
	PROTO_C2GS_POS,
	PROTO_C2GS_FIRE,
	PROTO_C2GS_HIT,
	PROTO_C2GS_ROLE_DATA,
	PROTO_C2GS_ACTION,
};

enum PROTO_GS2C
{
	PROTO_GS2C_LOGIN	= 1,
	PROTO_GS2C_ADD_PLAYER,
	PROTO_GS2C_REMOVE_PLAYER,
	PROTO_GS2C_POS,
	PROTO_GS2C_ROLE_DATA,
	PROTO_GS2C_ACTION,
};

struct ProtoLogin : public TProtoHead<PROTO_C2GS_LOGIN>
{
	char	szName[32];
};
struct ProtoLoginResult : public TProtoHead<PROTO_GS2C_LOGIN>
{
	int		nResult;
	int		uuid;
};
struct ProtoSceneLoaded : public TProtoHead < PROTO_C2GS_SCENE_LOADED >
{
	int		x;
	int		y;
	int		z;
};
struct ProtoAddPlayer : public TProtoHead < PROTO_GS2C_ADD_PLAYER >
{
	int		uuid;
	char	szName[32];
	int		x;
	int		y;
	int		z;
};
struct ProtoRemovePlayer : public TProtoHead < PROTO_GS2C_REMOVE_PLAYER >
{
	int		uuid;
};

struct ProtoPos : public TProtoHead<PROTO_C2GS_POS>
{
	int		x;
	int		y;
	int		z;
	int		dir;
	int		moveX;
	int		moveZ;
};
struct ProtoS2CPos : public TProtoHead < PROTO_GS2C_POS >
{
	int		uuid;
	int		x;
	int		y;
	int		z;
	int		dir;
	int		moveX;
	int		moveZ;
};
struct ProtoFire : TProtoHead<PROTO_C2GS_FIRE>
{

};

struct ProtoHit : TProtoHead <PROTO_C2GS_HIT>
{

};
struct ProtoC2S_RoleData : TProtoHeadLength < PROTO_C2GS_ROLE_DATA >
{
	char Data[1];
};
struct ProtoS2C_RoleData : TProtoHeadLength<PROTO_GS2C_ROLE_DATA >
{
	char	Data[1];

};
struct ProtoC2S_Action : TProtoHeadLength < PROTO_C2GS_ACTION >
{
	char	Data[1];
};
struct ProtoS2C_Action : TProtoHeadLength < PROTO_GS2C_ACTION >
{
	char	Data[1];
};
#pragma pack(pop)
