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
		SYS_MAGICATTR,
		SYS_PLAYERSAVELOAD,
		SYS_TIMELINE,
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
}