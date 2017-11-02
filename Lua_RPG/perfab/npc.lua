local std_npc = Entity ({
	name = "npc",
	_ctor = function(self, name, inst)
		self.inst = inst;
		self.name = name;

		self:AddComponent("damageable");
		self:AddComponent("skills");
		self:AddComponent("dbase")
	end,
})

return std_npc;
