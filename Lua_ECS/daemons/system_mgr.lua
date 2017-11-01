require "base.class"
require "obj.entity"

System = class({
	name = "System",
	_ctor = function(self, _name)
		self.name = _name;
	end,
})
function System:start()
	print(self.name.."加载成功!")
end
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
	local sys = require("daemons." .. syspath)
	table.insert(self._systems, sys);
	sys:start();
end

function SystemMgr:start()
end

function SystemMgr:update()
	for i, sys in ipairs(self._systems) do
		sys:update();
	end
end


