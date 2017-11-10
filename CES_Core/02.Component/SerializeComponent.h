#pragma once
#include "CompDef.h"
#include "Component.h"


class ISerializeable
{
public:
	virtual int Pack(char *pData, unsigned int &pnSize) = 0;
	virtual int UnPack(char *pData, int nSize, uint8 nVersion) = 0;

};

namespace ECS {
	class SerializeableComponent : public IComponent, public ISerializeable
	{
	public:
		SerializeableComponent(){}
		virtual ~SerializeableComponent(){}

	public:
		virtual int Pack(char *pData, unsigned int &pnSize);
		virtual int UnPack(char *pData, int nSize, uint8 nVersion);

	protected:
	};
}