require "Lua.std.char"

local girl = Char();

function girl:setup()
	self.name = "美女";
end

function girl:onTalk()
	print("girl对话");
end

return girl;
