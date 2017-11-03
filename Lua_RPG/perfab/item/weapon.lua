local weapon = class ({
	name = "npc",
	_ctor = function(self, name, inst)
		self.inst = inst;
		self.name = name;

	end,
})

function weapon:create(actor)
	actor:AddComponent("equipable");
end

return weapon;
