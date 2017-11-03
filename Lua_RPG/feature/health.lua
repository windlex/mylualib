health = class {
	health_max = 100,
	health_cur = 100,
	_ctor = function(self, actor)

	end,
}

function health:setup(actor)

end

function health:setMaxHealth(nMax)
	self.health_max = nMax;
end

function health:recvDamag(damage)
	if damage < 0 then
		return notify("没有造成任何伤害!")
	end
	self.health_cur = self.health_cur - damage;
	if self.health_cur < 0 then
		self:die();
	end
	pl(format("%s受到了%d点伤害!", self.actor.name, damage));
	return damage;
end

function health:recvHeal(heal)
	self.health_cur = self.health_cur + heal;
	if self.health_cur > self.health_max then
		self.health_cur = self.health_max;
	end
	pl(format("%s回复了%d点生命!", self.actor.name, damage));
end

function health:die()
	pl(format("%s SHI掉了!", self.actor.name));
end

return health;
