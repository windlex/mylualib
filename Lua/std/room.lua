
room = class(Componentor, {
	name = "room",
	desc = "this is a room",
	_ctor = function(self, name)
		self.name = name;
		RoomD:addRoom(self);
		self.facilitys = {}
	end,
})

function room:queryAction()
	local actions = {};
	local comps = self:GetAllComponents();

	for k, v in pairs(comps) do
		if type(v.queryAction) == 'function' then
			print("get action:", Val2Str(v))
			actions = v:queryAction();
		end
	end
	return actions;
end

function room:addFacility(name)
	self.facilitys[name] = self:AddComponent("room."..name)
end
