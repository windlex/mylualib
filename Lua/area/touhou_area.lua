require "Lua.std.room"

local c = area("东方幻想乡") 

function c:setup()
	self.placement:addExit("红魔馆", "touhou.hongmouguan");
end

return c;