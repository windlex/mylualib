require "std.char"

local slave = Char();

function slave:setup()
	Char.setup(self);
	self.AddComponent("trainable")
end

function slave:onTalk()
	print("Slave:onTalk")
end
return slave;