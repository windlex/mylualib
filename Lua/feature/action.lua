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
function action:queryAttackAction(target)
	--local weapon = self.inventory["weapon"];
	local use_skill = "unarmed";
	if weapon then
		skill = weapon:querySkill();
	end
	return self.actor.skill_list:queryAction(use_skill);
end

-- Combat Data
function action:queryAttack()
	return self.actor.dbase.str * 5;
end
function action:queryDodge()
	return self.actor.dbase.dex;
end
function action:queryDamage()
	return self.actor.dbase.str;
end
function action:queryArmor()
	return self.actor.dbase.con;
end
function action:receiveDamage(damage)
	damage = damage - random(1, self:queryArmor());
	if (damage > 0) then
		pl(format("%s受到了%d点伤害!", self.actor.name, damage));
		self.actor.dbase.hp = self.actor.dbase.hp - damage;

		if (self.actor.dbase.hp <= 0) then
			self:die();
		end
	else
		pl(format("但是被%s挡住了!", self.actor.name));
	end
	return damage;
end
function action:die()
	pl(format("%s SHI掉了!", self.actor.name));
end
return action;