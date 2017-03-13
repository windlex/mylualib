Char = class(Actor, {
	name = "Char",
	desc = "this is a Char",
	_ctor = function (self, name)
		self.name = name;
		print("Char:_ctor")
		Actor._ctor(self);
		self.dbase = self:AddComponent("dbase");
		self.skill_list = self:AddComponent("skill_list");
		self.action = self:AddComponent("action");
	end,
})

function Char:dead()
	if self.dbase.hp <= 0 then return 1 end
end
