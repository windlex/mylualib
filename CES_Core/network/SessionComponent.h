////////////////////////////////////////////////////////////////////////////////
//
//  FileName    : Component.h
//  Version     : 1.0
//  Creator     : Windle
//  Create Date : 2017/10/12   16:30
//  Comment     : 
//
////////////////////////////////////////////////////////////////////////////////

#pragma once
#include "..\01.Entity\Entity.h"
#include "KSession.h"
#include "..\02.Component\Component.h"

class KSession;
namespace ECS {
	class SessionCompnent : public Component
	{
	public:
		SessionCompnent(){}
		~SessionCompnent(){}

		KSession *pSession;
	};
}
