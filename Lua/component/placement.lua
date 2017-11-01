local placement = class(Component, {
	name = "placement",
	action = "placement",
})

function placement:_ctor(owner)
	self.owner = owner;
	self.exits = {};
	self.chars = {};
	owner.placement = self;
end

return placement;
