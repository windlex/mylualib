#pragma once
#include "..\01.Entity\Entity.h"

namespace ECS {

	struct CompDisp : public Component
	{
		CompDisp()
		{
			memset(szName, 0, sizeof(szName));
		}
		void SetName(char *pszName)
		{
			strncpy(szName, pszName, sizeof(szName) - 1);
		}
		char	szName[32];
	};

#define MAX_DATA_SIZE	1024
	struct CompRoleData : public Component
	{
		uint32	size;
		char	szData[MAX_DATA_SIZE];
		int		bUpdate;

		CompRoleData()
		{
			memset(szData, 0, sizeof(szData));
			size = 0;
			bUpdate = 0;
		}
		void SetData(char *pData, uint32 size)
		{
			this->size = size;
			//todo: if size > max_data_size ??
			memcpy(szData, pData, size);
			bUpdate = TRUE;
		}
	};
}
