local room_env = class {

}

function room_env:_ctor(actor)
	self.actor = actor;
	self.objects = {};
end

function room_env:addActor(char)
	self.objects[char.name] = char;
	char.placement = self;
end
function room_env:removeActor(char)
	self.objects[char.name] = nil;
end

return room_env;
