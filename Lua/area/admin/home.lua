require(STD_ROOM);

local this = Room("个人空间")

function this:setup()
	self.placement:addExit("外出", "admin.main_room");
end

return this;	