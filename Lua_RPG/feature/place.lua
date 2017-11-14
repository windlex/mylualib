local place = class {}

function place:_ctor()
end

function place:enterEnv(env)
	self.env = env;
end
function place:leaveEnv(env)
	self.env = nil;
end
return place;
