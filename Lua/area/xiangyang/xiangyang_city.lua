require "std.room"

local this = Room("襄阳") 

function this:setup()
	--self:AddComponent("room.city");
print('setup')
	self.bank = self:addFacility("bank")
print('bank ')
	self.house = self:addFacility("house")
print('house ')

	self.placement:addChar(CharD:loadChar("girl"))
print('addChar  ')
	
	self.placement:addExit("襄阳城外", "xiangyang_area");
print('襄阳城外')
end

return this;