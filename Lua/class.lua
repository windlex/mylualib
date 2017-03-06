--------------------------------------------------------------------------------
--
--  FileName    : \script\class\class.lua
--  Creator     : Windle
--  Create Date : 2013/01/04   17:34:53
--  Version     : 1.3
--  Comment     : inherit		¼òµ¥ÒýÓÃ¼Ì³Ð, Ê¹ÓÃ±Ø°ü°Ñ»ùÀàÒýÓÃµ½upvalueÖÐ
--				: superInherit 	´øsuperµÄÒýÓÃ¼Ì³Ð,»ùÀàÒýÓÃµ½self.getmetatable()._superÖÐ
--				: class			¼òµ¥copy¼Ì³Ð, ËùÓÐ»ùÀàµÄ³ÉÔ±¶¼copyµ½µ±Ç°table
--				: superClass	´øsuperµÄcopy¼Ì³Ð, ËùÓÐ»ùÀàµÄ³ÉÔ±¶¼copyµ½self._superÖÐ
--				: 
--				: ½â¾öÑ­»·ÒýÓÃÎÊÌâ
--				:
--	Usage		: A = inherit {...};  a = A:new();
--				: B = A {...}
--				: C = inherit(A, B, {...})
--				: A:super():f();							µ÷ÓÃ»ùÀàµÄº¯ÊýÍ¬Ê±Ê¹ÓÃ»ùÀàµÄ±äÁ¿
--				: A:super().f(A); self:super().f(self);		µ÷ÓÃ»ùÀàµÄº¯ÊýÍ¬Ê±Ê¹ÓÃÅÉÉúÀàµÄ±äÁ¿
--
--------------------------------------------------------------------------------

gt_CLASS_NAMESPACE = {
	baseClass = {
		new = function(self)
			return gt_CLASS_NAMESPACE:newClass(self);
		end,
	},
	_classMap = {},
	classCopy = function(self, super, derive)
		for k,v in super do
			if type(v) == "table" then
				local tablekey = tostring(v);
				if not self._classMap[tablekey] then	-- for turn copy
					self._classMap[tablekey] = {};
					self:classCopy(v, self._classMap[tablekey]);
				end
				derive[k] = self._classMap[tablekey];
			else
				derive[k] = v;
			end
		end
		return derive;
	end,
	newClass = function(self, ...)
		self._classMap = {};
		local derive, tBase = {}, arg;
		table.insert(tBase, 1, self.baseClass);
		for i = getn(tBase), 1, -1 do
			self:classCopy(tBase[i], derive);
		end
		local class_metatable = {
			__call = class;
		}
		setmetatable(derive, class_metatable);
		self._classMap = {};
		return derive;
	end
}
function class(...)
	return gt_CLASS_NAMESPACE:newClass(...);
end

--TEST Class----------------------------------------------------
--print("--TEST Class----------------------------------------------------")
--S = {name="S"}
--S.s = S;
--A = class(S, {name="A"});
--print("A",Val2Str(A))
--b = A:new();
--print("b",Val2Str(b))
--A.a = A;
--B = A {};
--print("B",Val2Str(B))
--A = {}
--B = {}
--A.b = B;
--B.a = A;
--c = class (A, B)
--print("c", Val2Str(c));
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
		new = function(self)
			return gt_INHERIT_NAMESPACE.inherit(self, {});
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
	inherit = function(self, ...)
		local derive = arg[#arg];
		arg[#arg] = nil;
		local super = arg;
		local mt_super = {
			__index = gt_INHERIT_NAMESPACE.indexSuper,
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
			__call = gt_INHERIT_NAMESPACE.inherit,
			_super = super;
		}
		setmetatable(derive, inherit_metatable);
		return derive;
	end,
}

function inherit(...)
	return gt_INHERIT_NAMESPACE:inherit(arg);
end

--TEST superInherit----------------------------------------------------
--print("--TEST superInherit----------------------------------------------------")
--tBase = superInherit {
--	a = 1,
--	f = function(self)
--		print("base", self.a);
--	end,
--}
--print("tBase",Val2Str(tBase));
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
--
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
--tBaseB = superInherit {
--	b = 1,
--}
--print("tBaseB",Val2Str(tBaseB));
--
--tDriveB = superInherit(tBase, tBaseB, {c = 1,})
--print("tDriveB",Val2Str(tDriveB));
--tDriveB:f()
--print(tDriveB.a, tDriveB.b, tDriveB.c, tDriveB.f)
--
--tBaseBB = tDriveB:new();
--print("tBaseBB",Val2Str(tBaseBB));
----tBaseBB:f()
--print(tBaseBB.a, tBaseBB.b, tBaseBB.c, tBaseBB.f)
--
--A = superInherit { a = 1, 
--	f3 = function(self) print("A", self.a) end,
--	f4 = function(self) print("4", self.a) end,
--}
--print("A", Val2Str(A));
--B = superInherit { a = 2 }
--print("B", Val2Str(B));
--ab = superInherit(A, B, {
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
--A = superInherit { a = 1 }
--a = A {};
--print(a.a);
--A.a = 2;
--print(a.a);
--
--
--A = superInherit { a = 1, 
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