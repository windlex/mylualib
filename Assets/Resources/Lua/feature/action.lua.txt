local action = class {}

local defaultAction = {
	msg = "$A向$B攻去",
	attack = 100,
	damage = 10,
}

function action:queryAction(actionType, target)
	return defaultAction;
end
function action:queryAttack()
	return self._self.dbase.str;
end
function action:queryDodge()
	return self._self.dbase.dex;
end
function action:queryDamage()
	return self._self.dbase.str;
end
function action:queryArmor()
	return self._self.dbase.con;
end
function action:receiveDamage(damage)
	damage = damage - random(1, self:queryArmor());
	if (damage > 0) then
		pl(format("%s受到了%d点伤害!", self._self.name, damage));
		self._self.dbase.hp = self._self.dbase.hp - damage;

		if (self._self.dbase.hp <= 0) then
			self:die();
		end
	else
		pl(format("但是被%s挡住了!", self._self.name));
	end
	return damage;
end
function action:die()
	pl(format("%s SHI掉了!", self._self.name));
end
return action;