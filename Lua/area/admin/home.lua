require(STD_ROOM);

local this = room("个人空间")

function this:setup()
	self.placement:addExit("外出", "admin.main_room");
end

return this;	