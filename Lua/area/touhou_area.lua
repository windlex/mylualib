require "Lua.std.room"

local c = room("襄阳") 

function c:setup()
	self:AddComponent("room.city");
	self:addFacility("bank")
end

print(Val2Str(c))
return c;