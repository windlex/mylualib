--------------------------------------------------------------------------------
--
--  FileName    : \script\class.lua
--  Creator     : Windle
--  Create Date : 2017/2/24 10:36:39
--  Version     : 0.1
--  Comment     : inherit	 	带super的引用继承,基类引用到self.getmetatable()._super中
--				: class			copy继承, 所有基类的成员都copy到当前metatable
--				: 
--				: 解决循环引用问题
--				:
--	Usage		: A = inherit {...};  a = A:new();
--				: B = A {...}
--				: C = inherit(A, B, {...})
--				: B:super():f();							调用基类的函数同时使用基类的变量
--				: B:super().f(B); self:super().f(self);		调用基类的函数同时使用派生类的变量
--				:
--	Todo		: RTTI
--------------------------------------------------------------------------------
if __class_file_flag__ then return end
__class_file_flag__ = 1

local _debug = nothing

gt_CLASS_NAMESPACE = {
	_classMap = {},
	classCopy = function(self, from, to)
		if not from or not to then return end
		for k,v in pairs(from) do
			if not to[k] then
				if type(v) == "table" then
					local tablekey = tostring(v);
					if not self._classMap[tablekey] then	-- 循环引用
						self._classMap[tablekey] = {};
						self:classCopy(v, self._classMap[tablekey]);
					end
					to[k] = self._classMap[tablekey];
				else
					to[k] = v;
				end
			end
		end
		return to;
	end,
	newClass = function(self, ...)
		self._classMap = {};
		local c, tBase = {}, table.pack(...);
		for i = #tBase, 1, -1 do
			self:classCopy(tBase[i], c);
		end
		c.__index = c;
		local class_metatable = {
			__call = function(self, ...)
				local k = {};
				setmetatable(k, c);
				if c._ctor then
					c._ctor(k, ...)
				end
				return k;
			end,
		}
		setmetatable(c, class_metatable);
		self._classMap = {};
		return c;
	end
}
function class(...)
	return gt_CLASS_NAMESPACE:newClass(...);
end

--TEST Class----------------------------------------------------
--print("--TEST Class----------------------------------------------------")
--S = {name="S"}
----S.s = S;
--A = class(S, {name="A"});
--print("A",Val2Str(A))
--b = A:new();
--print("b",Val2Str(b))
--
--A.a = A;
--B = A {};
--print("B",Val2Str(B))
--
--A = {}
--B = {}
--A.b = B;
--B.a = A;
--c = class (A, B)
--print("c", Val2Str(c));
--
--tBase = class {
--	a = 1,
--	f = function(self)
--		print("base", self.a);
--	end,
--}
--print("tBase",Val2Str(tBase));
--tBase:f()
---------
--tBase2 = tBase:new();
--print("tBase2",Val2Str(tBase2));
--tBase2:f()
--
--tDrive = tBase {
--	a = 2,
--}
--print("tDrive",Val2Str(tDrive));
--tDrive:f()
--
--tDrive2 = tDrive {
--	f = function(self)
--		print("tDrive2", self.a);
--	end
--}
--print("tDrive2", Val2Str(tDrive2));
--tDrive2:f()
--
--tBaseB = class {
--	b = 1,
--}
--print("tBaseB",Val2Str(tBaseB));
--
--tDriveB = class(tBase,tBaseB, {c = 1,})
--print("tDriveB",Val2Str(tDriveB));
--tDriveB:f()
--
--A = class { a = 1 }
--B = class { a = 2 }
--ab = class(A, B, {f3 = print});
--print(ab.a);
--
--A = class { a = 1 }
--a = A {};
--print(a.a);
--A.a = 2;
--print(a.a);

--Inherit----------------------------------------------------
gt_INHERIT_NAMESPACE = {
	baseClass = {
		new = function(self, ...)
			local t = gt_INHERIT_NAMESPACE.inherit(self);
			if type(t.init) == 'function' then
				t:init(...)
			end
			return t;
		end,
		super = function(self)
			local metatable = getmetatable(self);
			if not metatable then
				return 
			end
			return metatable._super;
		end
	},
	indexSuper = function(super, key)
		for i = #super, 1, -1 do
			if super[i][key] then
				return super[i][key];
			end
		end
	end,
	index = function(self, key)
		return gt_INHERIT_NAMESPACE.baseClass.super(self)[key];
	end,
	inherit = function(...)
		self = gt_INHERIT_NAMESPACE;
		local derive = {};
		local super = arg;
		table.insert(super, self.baseClass)
		local mt_super = {
			__index = self.indexSuper,
		}
		setmetatable(super, mt_super);

		local inherit_metatable = {
			__index = function(self, key)
				for i = getn(super), 1, -1 do
					if super[i][key] then
						return super[i][key];
					end
				end
			end,
			__call = self.inherit,
			_super = super,
		}
		setmetatable(derive, inherit_metatable);
		return derive;
	end,
}

function inherit(...)
	return gt_INHERIT_NAMESPACE.inherit(...);
end

--TEST inherit----------------------------------------------------
--print("--TEST inherit----------------------------------------------------")
--tBase = inherit {
--	a = 1,
--	f = function(self)
--		print("base", self.a);
--	end,
--}
--print("tBase",Val2Str(tBase));
--print("tBase.mt", Val2Str(getmetatable(tBase)));
--tBase:f()
--
--tBase2 = tBase:new();
--print("tBase2",Val2Str(tBase2));
--tBase2:f()
--
--tDrive = tBase {
--	a = 2,
--}
--print("tDrive",Val2Str(tDrive));
--tDrive:f()
--print("tDrive.mt", Val2Str(getmetatable(tDrive)));
--
--tdd = tDrive { b = 3 }
--print("tdd",Val2Str(tdd));
--print("tdd.mt", Val2Str(getmetatable(tdd)));
--print(tdd.a, tdd.b)
--tDrive2 = tDrive {
--	f = function(self)
--		print("tDrive2", self.a);
--	end
--}
--print("tDrive2",Val2Str(tDrive2));
--tDrive2:f()
--
--tDrive3 = tDrive2:new();
--print("tDrive3",Val2Str(tDrive3));
--tDrive3:f()
--
--tBaseB = inherit {
--	b = 1,
--}
--print("tBaseB",Val2Str(tBaseB));
--
--tDriveB = inherit(tBase, tBaseB, {c = 1,})
--print("tDriveB",Val2Str(tDriveB));
--tDriveB:f()
--print(tDriveB.a, tDriveB.b, tDriveB.c, tDriveB.f)
--
--tBaseBB = tDriveB:new();
--print("tBaseBB",Val2Str(tBaseBB));
----tBaseBB:f()
--print(tBaseBB.a, tBaseBB.b, tBaseBB.c, tBaseBB.f)
--
--A = inherit { a = 1, 
--	f3 = function(self) print("A", self.a) end,
--	f4 = function(self) print("4", self.a) end,
--}
--print("A", Val2Str(A));
--B = inherit { a = 2 }
--print("B", Val2Str(B));
--ab = inherit(A, B, {
--	f3 = function(self) print("C", self.a) end,
--	});
--print("ab", Val2Str(ab));
--
--print("new",ab.new)
--print("super", ab.super)
--print(ab.a);
--ab:f3();
--ab:f4();
--mt = getmetatable(ab);
--print("mt", Val2Str(mt));
--ab:super():f3();
--ab:super().f3(ab);
--
--A = inherit { a = 1 }
--a = A {};
--print(a.a);
--A.a = 2;
--print(a.a);
--
--
--A = inherit { a = 1, 
--	f = function(self) print("A", self.a) end,
--	f4 = function(self) print("4", self.b) end, 
--};
--B = A { 
--	a = 2,
--	b = 2,
--	f = function(self) print("B", self.b) end, 
--	f2 = function(self) 
--		f() 
--	end,
--	f3 = function(self)
--		print(self:f4());
--		local s1 = self.super(self)
--		local s2 = self:super();
--		print("s1, s2" ,Val2Str(s1), Val2Str(s2));
--		print(s1.f)
--		self:super().f(self)
--		self:super():f()
--	end
--};
--C = B { c=3}
--print("C", Val2Str(C), Val2Str(getmetatable(C)));
--C:f4()
--print(Val2Str(B))
--B:f();
--B:f2();
--B:f3();