require "base.component"
require "base.tag"


EntityMgr = {
	entitys = {},
	idseed = 1234,
}

function EntityMgr:genID()
	self.idseed = self.idseed + 1;
	return self.idseed;
end

function EntityMgr:add(entity)
	if entity.id == nil then
		entity.id = self:genID();
	end
	self.entitys[entity.id] = entity;
end

function EntityMgr:get(id)
	if id == nil then return end
	return self.entitys[id];
end

-----------------------------------------------------------------------------
Entity = class(Componentor, Tag, {
	id = nil,
	name = "Entity",
	_ctor = function (self)
		Tag._ctor(self);
		Componentor._ctor(self);

		EntityMgr:add(self);
	end,
})
