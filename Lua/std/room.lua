
room = class(Componentor, {
	name = "room",
	desc = "this is a room",
	_ctor = function(self, name)
		self.name = name;
		RoomD:addRoom(self);
		self:AddComponent("room.placement");
		self.facilitys = {};
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
	local facility = require("Lua.feature.room."..name);
	self.facilitys[name] = facility();
end
function room:getFacility(name)
	return self.facilitys[name]
end
function room:removeFacility(name)
	self.facilitys[name] = nil;
	self:RemoveComponent(name);
end
function room:lookFacility()
	local msg = "\n这里的设施有:\n";
	for k, fac in pairs(self.facilitys) do
		msg = msg .. link(fac.name, format("room_onFacility('%s')", k)) .. ", "
	end
	return msg;
end
function room_onFacility(name)
	local room = player:getCurrentRoom();
	room:onFacility(name)
end
function room:onFacility(name)
	self.facilitys[name]:onActivity(player);
	--self.facilitys[name]:onActivity(player);
end

function room:onLook(char)
	local msg = "这里是"..self.name;
	msg = msg .. "\n".. self.desc;

	msg = msg .. self.placement:onLook();

	msg = msg .. self:lookFacility();
	
	return msg;
end

----------------------------------------------------------------------------
area = class (room, {
	name = "area",
	desc = "here is a area",
	_ctor = function (self, name)
		room._ctor(self)
		self.name = name;
		self.facilitys = {};
	end,
})

