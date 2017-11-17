////////////////////////////////////////////////////////////////////////////////
//
//  FileName    : System.h
//  Version     : 1.0
//  Creator     : Windle
//  Create Date : 2017/10/12   16:36
//  Comment     : 
//
////////////////////////////////////////////////////////////////////////////////

#pragma once

namespace ECS {
	
	enum emSYSTEMS
	{
		SYS_MOVEMENT,
		SYS_NETWORK,
		SYS_ROOM,
		SYS_JOINROOM,
		SYS_SYNCROOM,
		SYS_COLLIDING,

		SYS_MAGICATTR = 10,
		SYS_PLAYERSAVELOAD,
		SYS_TIMELINE,
		SYS_HALL,

		SYS_TEST = 100,
		SYS_FPS,
	};

	class SystemBase 
	{
	public:
		SystemBase(int id)
			:m_ID(id)
		{}
		virtual ~SystemBase() {}

		virtual int Init() { return 1; }
		virtual int	Update() { return 0; }
		virtual int	FixedUpdate() = 0;

		int GetID()
		{
			return m_ID;
		}

		int m_ID;
	};

	template <int SysID>
	class TSystemBase : public SystemBase
	{
	public:
		TSystemBase()
			: SystemBase(SysID)
		{}
	};

#define GET_COMPONENT_GROUP(COMPNAME, GROUP)\
std::vector<COMPNAME *> GROUP;\
Manager::GetInstance()->ComponentItr<COMPNAME>(GROUP);


}