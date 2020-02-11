--==============================--
--desc: ClassEx
--time:2020-02-06 01:06:25
--Usage:
	-- A = ClassEx({a = 1})
	-- B = ClassEx(function(self) self.b = 1 end)
	-- C = ClassEx(A, {c=1}, function(self) self.c=c end)
	-- D = ClassEx(C, D, {}, _ctor)
	-- d1 = D:make({x=1})
	-- d2 = D:new({...}, 1)
--==============================---
local ClassBase = {}
function ClassBase.New(self, ...)
	local d = self:Make {}
	self._ctor(d, ...)
	return d
end
function ClassBase.Make(self, data)
	local class_mt = {
		__index = self;
	}
	setmetatable(data, mt)
end
function ClassBase.Super(self)
	local mt = getmetatable(self)
	if mt._super then
		return mt._super;
	end
end
function ClassBase.IsA(self, cls)
	local super = ClassBase.Super(self)
	for i = #super, 1, - 1 do	--后面的覆盖前面的
		if cls == super[i] then
			return true;
		end
		if ClassBase.IsA(super[i], cls) then
			return true;
		end
	end
	return false;
end
function ClassBase.__index(self, k)
	local super = ClassBase.Super(self)
	for i = #super, 1, - 1 do	--后面的覆盖前面的
		if super[i][key] then
			return super[i][key];
		end
	end
	if ClassBase[key] then
		return ClassBase[key]
	end
end
function ClassBase.Inherit(self, ...)
	local base = {...}
	local mt = getmetatable(self)
	mt._super = base;
end
function ClassEx(...)
	local base = {...}
	local ctor = base[#base]
	if ctor and type(ctor) == 'function' then
		c._ctor = ctor
		table.remove(base, #base)
	end
	local c = base[#base]
	if c and type(c) == 'table' then
		table.remove(base, #base)
	else
		c = {}
	end
	table.insert(base, ClassBase)
	local mt = {
		__index = ClassBase.__index,
		__call = function(self, ...)
			return self:New(...)
		end,
		_super = base,
	}
	setmetatable(c, mt)
	return c;
end
function ClassExx(c, ctor)
	if not ctor and type(c) == 'function' then
		ctor = c;
		c = nil;
	end
	if not c then c = {} end
	local mt = {
		__index = ClassBase.__index,
		__call = ClassBase.New,
	}
	setmetatable(c, mt)
	return c;
end