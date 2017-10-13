require "Lua.base.class"
require "Lua.ECSBase.entity"

System = class({
	name = "System",
	_ctor = function(self, _name)
		self.name = _name;
	end,
})
function System:update()
end


SystemMgr = {
	_systems = {},
	_components = {}
}

function SystemMgr:onAddComponent(en, key, _comp)
	self._components[key] = self._components[key] or {}
	self._components[key][en.id] = _comp;
end
function  SystemMgr:onRemoveComponent(en, key, _comp)
	self._components[key][en.id] = nil;
end
function SystemMgr:getComponentGroup(key)
	return self._components[key] or {};
end

function SystemMgr:addSystem(syspath)
	local sys = require("Lua.system." .. syspath)
	table.insert(self._systems, sys);
end

function SystemMgr:start()
	--require "Lua.startup"
	self:Perload();

	player = Entity();
	CharSys:setupChar(player);

	user = Entity();
	
	print("user", Val2Str(user))
	print("user meta", Val2Str(getmetatable(user)))

	print("player", Val2Str(player))
	print("player meta", Val2Str(getmetatable(player)))

	print("STARTROOM", Val2Str(STARTROOM))
	MoveSys:move(player, STARTROOM)

	print("player", Val2Str(player))
	--player:move("admin.void_room")
end
function SystemMgr:update()
	for i, sys in ipairs(self._systems) do
		sys:update();
	end
end

function SystemMgr:Perload()
	self:addSystem("char_sys");
	self:addSystem("cmd_sys");
	self:addSystem("move_sys");
	self:addSystem("room_sys");
	print(Val2Str(SystemMgr))
end
