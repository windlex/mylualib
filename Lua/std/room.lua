require "ECSBase.entity"

Room = class(Entity, {
	name = "room",
	desc = "this is a room",
	_ctor = function(self, name)
		Entity._ctor(self)

		self.name = name;
		RoomSys:addRoom(self);
		self:AddComponent("room.placement");
		self.facilitys = {};
		self._actions = {}
	end,
})

Room.isRoom = true;

function Room:addAction(name, method)
	self._actions[name] = method;
end
function Room:onAction(act)
	if self.actions[act] then
		self.actions[act]()
	end
end
function Room:resetAction()
	local actions = table.copy(self._actions);
print(Val2Str(self._actions))
print(Val2Str(actions))

	local comps = self:GetAllComponents();

	for k, v in pairs(comps) do
		if type(v.queryAction) == 'function' then
			print("get action:", Val2Str(v))
			actions = table.merge(actions, v:queryAction());
		end
	end
	self.actions = actions;
	return actions;
end
function Room:queryAction()
	return self.actions;
end

function Room:addFacility(name)
	local facility = require("feature.room."..name);
	self.facilitys[name] = facility();
end
function Room:getFacility(name)
	return self.facilitys[name]
end
function Room:removeFacility(name)
	self.facilitys[name] = nil;
	--self:RemoveComponent(name);
end
function Room:lookFacility()
	if not self.facilitys or #self.facilitys == 0 then return "" end
	local msg = "\n这里的设施有:\n";
	for k, fac in pairs(self.facilitys) do
		msg = msg .. link(fac.name, format("Room_onFacility('%s')", k)) .. ", "
	end
	return msg;
end
function Room_onFacility(name)
	local room = player:getCurrentRoom();
	room:onFacility(name)
end
function Room:onFacility(name)
	self.facilitys[name]:onActivity(player);
	--self.facilitys[name]:onActivity(player);
end

function Room:onLook(char)
	local msg = "[" .. self.name .. ']';
	msg = msg .. "\n".. self.desc;

	msg = msg .. self.placement:onLook();

	msg = msg .. self:lookFacility();
	
	msg = msg .. RoomSys:showAction(self);
	return msg;
end

----------------------------------------------------------------------------
area = class (Room, {
	name = "area",
	desc = "here is a area",
	_ctor = function (self, name)
		Room._ctor(self)
		self.name = name;
		self.facilitys = {};
	end,
})

