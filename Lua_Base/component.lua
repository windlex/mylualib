Componentor = {
	_ctor = function (self)
		self._components = {}
	end,
	AddComponent = function (self, key, tcomp)
		if tcomp == nil then
			tcomp = require(FEATURE_DIR.."."..key);
		end
		if tcomp == nil then
			debug.error("[Error] no feature named ".. key);
			return
		end
		local _comp = tcomp(self);
		self._components[key] = _comp;
		Manager:onAddComponent(self, key, _comp)
		return _comp;
	end,
	GetComponent = function (self, key)
		return self._components[key];
	end,
	GetAllComponents = function (self)
		return self._components;
	end,
	RemoveComponent = function (self, key)
		self._components[key] = nil;
		Manager:onRemoveComponent(self, key);
	end,
}

function Sibling(comp, key)
	local actor = comp.actor;
	local anotherComp = actor:GetComponent(key);
	return anotherComp;
end
