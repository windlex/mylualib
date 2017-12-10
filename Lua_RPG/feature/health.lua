health = class {
	health_max = 100,
	health_cur = 100,
	_ctor = function(self, actor)

	end,
}

function health:_ctor(actor)
	self.actor = actor
end

function health:setMaxHealth(nMax)
	self.health_max = nMax;
end

function health:recvDamage(damage)
	if damage < 0 then
		return notify("没有造成任何伤害!")
	end
	self.health_cur = self.health_cur - damage;
	pl(format("%s受到了%d点伤害!", self.actor.name, damage));
	if self.health_cur < 0 then
		self:die();
	end
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
	pl(format("%s 死掉了!", self.actor.name));
	COMBAT_D:removeAllEnemy(self.actor);
	BATTLE_D:onActorDie(self.actor);
end

return health;
