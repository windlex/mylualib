require "std.room"

local this = area("襄阳地区") 

function this:setup()
	self.placement:addExit("襄阳城", "xiangyang.xiangyang_city");
end

return this;
