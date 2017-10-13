local placement = class({
	name = "",
	action = "placement",
})

function placement:_ctor(owner)
	self.owner = owner;
	self.exits = {};
	self.chars = {};
	owner.placement = self;
end

function placement:setup()

end

function placement:addChar(char)
	self.chars[char.name] = char;
	char.placement = self;
end
function placement:removeChar(char)
	self.chars[char.name] = nil;
end

function placement:addExit(exit, path)
	self.exits[exit] = path;
end
function placement:removeExit(exit)
end
function placement:lookExits()
	if not self.exits then return "这里没有明显的出口..." end
	local msg = "这里的出口有:"
	for exit, path in pairs(self.exits) do
		msg = msg .. link(exit, format("placement_onExit('%s')", exit)) .. ","
	end
	return msg;
end
function placement:onExit(exit)
	if not self.exits[exit] then
		print("并不能去"..exit.."...")
		return
	end
	player:move(self.exits[exit]);
end

function placement_onExit(exit)
	local room = player:getCurrentRoom();
	local this = room:GetComponent("room.placement");
	this:onExit(exit)
end

function placement:onLook()
	msg = "\n这里有:\n"
	for k, char in pairs(self.chars) do
		msg = msg .. char:link().. ", "
	end

	msg = msg .."\n" .. self:lookExits();
	return msg;
end

return placement;