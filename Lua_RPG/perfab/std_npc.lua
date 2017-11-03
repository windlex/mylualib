local std_npc = class ({
	name = "std_npc",
	_ctor = function(self, name, inst)
		self.inst = inst;
		self.name = name;

	end,
})

function std_npc:create(actor)
	local dbase = actor:AddComponent("dbase")
	local health = actor:AddComponent("health")
	health:setMaxHealth(500);
	local fighting = actor:AddComponent("fighting");
	fighting:setAction({"unarmed"})
	return actor;
end

return std_npc;
