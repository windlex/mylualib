#pragma once
#include "..\01.Entity\Entity.h"
#include "Component.h"

struct Vector2
{
	int		x;
	int		y;

	Vector2()
		:x(0), y(0)
	{}
	Vector2(int x, int y)
		:x(x), y(y)
	{}

	Vector2 operator + (Vector2 &r)
	{
		x += r.x;
		y += r.y;
		return *this;
	}
	void operator +=(Vector2 &r)
	{
		x += r.x;
		y += r.y;
	}
};
struct Vector3 : public Vector2
{
	int		z;

	Vector3()
		:Vector2(), z(0)
	{}
	Vector3(int x, int y, int z)
		:Vector2(x, y), z(z)
	{}
	Vector3 operator + (Vector3 &r)
	{
		x += r.x;
		y += r.y;
		z += r.z;
		return *this;
	}
	void operator +=(Vector3 &r)
	{
		x += r.x;
		y += r.y;
		z += r.z;
	}
};
namespace ECS {

	struct CompPosition : public Component
	{
		CompPosition()
			:pos({ 0, 0, 0 }), ndir(0), moveX(0), moveZ(0), bUpdate(0)
		{}

		Vector3		pos;
		int			ndir;
		int			bUpdate;	// 同步标记,改成comp?
	};

	struct CompMove : public Component
	{
		CompMove()
			:moveX(0), moveZ(0)
		{}

		int			moveX;
		int			moveZ;
	};

}