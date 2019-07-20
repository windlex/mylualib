require "std.entity"

--------------------------------------------------------------------
Actor = class(Entity, {
	id = nil,
	name = "Actor",
	_ctor = function (self)
		print("Actor:_ctor")
		Entity._ctor(self);
	end,
})

function Actor:addMethod(name, method)
	print("Actor:addMethod", name, method)
	if self[name] then
		logError("no name")
		return
	end
	self[name] = method;
end
