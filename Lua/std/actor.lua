
ActorMgr = {
	actors = {},
	idseed = 1234,
}

function ActorMgr:genID()
	self.idseed = self.idseed + 1;
	return self.idseed;
end

function ActorMgr:Add(actor)
	if actor.id == nil then
		actor.id = self:genID();
	end
	self.actors[actor.id] = actor;
end

function ActorMgr:Get(id)
	if id == nil then return end
	return self.actors[id];
end

--------------------------------------------------------------------
Actor = class(Componentor, {
	id = nil,
	name = "Actor",
	_ctor = function (self)
		ActorMgr:Add(self);
	end,
})

function Actor:addMethod(name, method)
	if self.name then
		error()
	end
	self.name = method;
end
