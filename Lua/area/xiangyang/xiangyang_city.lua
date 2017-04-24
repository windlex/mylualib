require "Lua.std.room"

local this = room("襄阳") 

function this:setup()
	--self:AddComponent("room.city");

	self:addFacility("bank")
	self:addFacility("house")

	self.placement:addChar(CharD:loadChar("girl"))

	self.placement:addExit("襄阳城外", "xiangyang_area");
end

return this;