Char = class(Actor, {
	name = "Char",
	desc = "this is a Char",
	init = function (self)
		Actor._ctor(self);
		self.skill = self:AddComponent("skill");
		self.action = self:AddComponent("action");
		self.dbase = self:AddComponent("dbase");
	end,
})

function Char:dead()
	if self.dbase.hp <= 0 then return 1 end
end
