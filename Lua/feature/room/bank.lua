local bank = class(Room, {
	name = "钱庄",
	action = "bank",
})

function bank:_ctor(owner)
	self.owner = owner;
end

function bank:setup()

end

return bank;