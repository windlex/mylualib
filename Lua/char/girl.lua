require "Lua.std.char"

local girl = Char("girl");

function girl:setup()
	self.name = "美女";
	self:setHouse("xiangyang.xiangyang_city");
end

function girl:onTalk()
	print("girl对话");
end

return girl;
