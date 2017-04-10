
room = class(Componentor, {
	name = "room",
	desc = "this is a room",
	_ctor = function(self, name)
		self.name = name;
		RoomD:addRoom(self);
		self.facilitys = {};
		self.exits = {};
		self.chars = {};
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
end

function room:addExit(exit, path)
	self.exits[exit] = path;
end
function room:removeExit(exit)
end
function room:lookExits()
	if not self.exits then return "这里没有明显的出口..." end
	local msg = "这里的出口有:"
	for exit, path in pairs(self.exits) do
		msg = msg .. link(exit, format("room_onExit('%s')", exit)) .. ","
	end
	return msg;
end
function room:onExit(exit)
	if not self.exits[exit] then
		print("并不能去"..exit.."...")
		return
	end
	player:move(self.exits[exit]);
end
function room_onExit(exit)
	local room = player:getCurrentRoom();
	room:onExit(exit)
end
function room:addChar(char)
	self.chars[char.name] = char;
end
function room:removeChar(char)
	self.chars[char.name] = nil;
end

function room:onLook(char)
	local msg = "这里是"..self.name;
	msg = msg .. "\n".. self.desc;

	msg = msg .. "\n这里有:\n"
	for k, char in pairs(self.chars) do
		msg = msg .. char:link().. ", "
	end

	msg = msg .. self:lookFacility();

	msg = msg .."\n" .. self:lookExits();
	
	return msg;
end

----------------------------------------------------------------------------
area = class (room, {
	name = "area",
	desc = "here is a area",
	_ctor = function (self, name)
		self.name = name;
		self.facilitys = {};
		self.exits = {};
		self.chars = {};
	end,
})

