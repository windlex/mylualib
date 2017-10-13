require "Lua.base.class"

System = class({
	name = "System",
})


SystemMgr = {
	_systems = {}
}

function SystemMgr:addSystem(sys)
	tinsert(_systems, sys);
end

function SystemMgr:start()
	--require "Lua.startup"

	player = Entity();
	CharSys:setupChar(player);

	user = Entity();
	
	print(Val2Str(user))
	print(Val2Str(getmetatable(user)))

	print(Val2Str(player))
	print(Val2Str(getmetatable(player)))

	print(Val2Str(STARTROOM))
	MoveSys:move(player, STARTROOM)
	--player:move("admin.void_room")
end
function SystemMgr:update()
	for i, sys in ipairs(self._systems) do
		sys:update();
	end
end
