local action = class {}

function action:_ctor(actor)
	self.actor = actor;
end

local defaultAction = {
	msg = "$A向$B攻去",
	attack = 100,
	damage = 10,
}

function action:queryAction(actionType, target)
	if actionType == "attack" then
	--	print(self, actionType, target)
		return self:queryAttackAction(target);
	end
	return --defaultAction;
end

return action;