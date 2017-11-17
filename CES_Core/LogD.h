#pragma once
#include "engine.h"
#include "engine\KSingleton.h"

class LogD : public TSingleton < LogD >
{
public:
	static void Init();
	static void Log(char *szType, ...);
	static void Error(...);
};
