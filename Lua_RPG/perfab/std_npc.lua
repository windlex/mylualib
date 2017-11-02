local std_npc = Entity ({
	name = "npc",
	_ctor = function(self, name, inst)
		self.inst = inst;
		self.name = name;

	end,
})

function std_npc:create(entity)
	entity:AddComponent("damageable");
	entity:AddComponent("skills");
	entity:AddComponent("dbase")
	return entity;
end

return std_npc;
