require "Lua.std.char"

local slave = Char();

function slave:setup()
	Char.setup(self);
	self.AddComponent("trainable")
end
return slave;