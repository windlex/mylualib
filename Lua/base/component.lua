Componentor = {
	AddComponent = function (self, key, tcomp)
		if tcomp == nil then
			tcomp = require(FEATURE_DIR.."."..key);
		end
		if tcomp == nil then
			debug.error("[Error] no feature named ".. key);
			return
		end
		self._components = self._components or {}

		local _comp = tcomp(self);
		self._components[key] = _comp;
		return _comp;
	end,
	GetComponent = function (self, key)
		self._components = self._components or {}
		return self._components[key];
	end,
	GetAllComponents = function (self)
		return self._components;
	end,
	RemoveComponent = function (self, key)
		self._components = self._components or {}
		self._components[key] = nil;
	end,
}
