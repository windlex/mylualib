require "Lua.ECSBase.system_mgr"

MoveSys = System()

function MoveSys:update()
end

function MoveSys:move(entityActor, entityRoom)
	entityRoom = self:consideRoom(entityRoom)

	local position = entityActor:GetComponent("position");
	self:leavePlace(entityActor, position.place)

	local placement = entityRoom:GetComponent("placement");
	placement.chars[char.name] = char;
	
	self:enterPlace(entityActor, placement);
	position.place = placement;

	self:look();
end

function MoveSys:consideRoom(room)
	if type(room) == 'string' then
		room = RoomD:loadRoom(room);
		if not room then
			assert()
		end
	end
	return room;
end
function MoveSys:enterPlace(char, place)
	place.chars[char.name] = char;
	char.place = place;
end
function MoveSys:leavePlace(entityActor, place)
	place.chars[char.name] = nil;
	--todo: message leave
end




function MoveSys:addExit(exit, path)
	self.exits[exit] = path;
end
function MoveSys:removeExit(exit)
end
function MoveSys:lookExits(place)
	if not place.exits then return "这里没有明显的出口..." end
	local msg = "这里的出口有:"
	for exit, path in pairs(place.exits) do
		msg = msg .. link(exit, format("OnCommand('go', '%s')", exit)) .. ","
	end
	return msg;
end
function MoveSys:onExit(exit)
	if not self.exits[exit] then
		print("并不能去"..exit.."...")
		return
	end
	player:move(self.exits[exit]);
end

function MoveSys_onExit(exit)
	local place = player:getCurrentRoom();
	local this = room:GetComponent("room.MoveSys");
	this:onExit(exit)
end

function MoveSys:onLook(place)
	msg = "\n这里有:\n"
	for k, char in pairs(place.chars) do
		msg = msg .. char:link().. ", "
	end

	msg = msg .."\n" .. self:lookExits(place);
	return msg;
end
