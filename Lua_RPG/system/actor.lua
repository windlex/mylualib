require "base.component"
require "base.tag"

-----------------------------------------------------------------------------
Actor = class(Componentor, Tag, {
	id = nil,
	entity = nil,
	name = "Entity",
	_ctor = function (self, entity)
		self.entity = entity;
		Tag._ctor(self);
		Componentor._ctor(self);
	end,
})

function Actor:getID()
	return self.entity.uuid;
end
