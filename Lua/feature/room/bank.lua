local bank = class {
	name = "bank",
	action = "bank",
}

function bank:_ctor(owner)
	self.owner = owner;
end

return bank;