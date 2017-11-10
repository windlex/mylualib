local this = Room("襄阳城门") 

function this:setup()
	--self:AddComponent("room.city");

	self.placement:addChar(CharD:loadChar("girl"))
	
	self.placement:addExit("襄阳城外", "xiangyang_area");
end

return this;