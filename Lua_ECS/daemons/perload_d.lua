PerloadD = System("Perloader")

function PerloadD:start()
	SystemMgr:addSystem("char_sys");
print("CharSys", CharSys)
	--SystemMgr:addSystem("cmd_sys");
	--SystemMgr:addSystem("move_sys");
	--SystemMgr:addSystem("room_sys");
	--SystemMgr:addSystem("world_d");
	print(Val2Str(SystemMgr))
	print("Perloaded!!!")
end

return PerloadD;
