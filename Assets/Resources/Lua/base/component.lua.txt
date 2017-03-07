Componentor = {
	_components = {},
	AddComponent = function (self, key, tcomp)
		if tcomp == nil then
			tcomp = require("Lua.feature."..key);
			tcomp = tcomp();
		end
		if tcomp == nil then
			debug.error("[Error] no feature named ".. key);
			return
		end
		self._components[key] = tcomp;
		tcomp._self = self;
		return tcomp;
	end,
	GetComponent = function (self, key)
		return self._components[key];
	end,
	GetAllComponents = function (self)
		return self._components;
	end,
	RemoveComponent = function (self, key)
		self._components[key] = nil;
	end,
}
