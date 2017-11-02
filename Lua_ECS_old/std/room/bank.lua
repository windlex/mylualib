local bank = class(Room, {
	name = "钱庄",
	action = "bank",
})

function bank:_ctor(owner)
	self.owner = owner;
end

function bank:setup()

end

function bank:onActivity(char)
	print("bank:onActivity")
end

return bank;