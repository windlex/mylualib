require "std.room"

local house = class(Room, {
	_ctor = function (self)
		Room._ctor(self)
		self.name = "府邸";
		self.residents = {};
	end,	
})

function house:addHouse(char)
	self.residents[char.name] = char;
end

function house:onActivity(char)
	print("house:onActivity")
end

return house;
