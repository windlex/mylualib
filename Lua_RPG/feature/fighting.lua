fighting = class({
	enemys = {},
	_ctor = function(self, actor, enemys)
		self.actor = actor;
		self.enemys = enemys;
	end,
	actions = {},
	cur_action = 1,
})

-- Combat Data
function fighting:queryAttack()
	return self.actor.dbase.str * 5;
end
function fighting:queryDodge()
	return self.actor.dbase.dex;
end
function fighting:queryDamage()
	return self.actor.dbase.str;
end
function fighting:queryArmor()
	return self.actor.dbase.con;
end

function fighting:addEnemy(enemy)
	-- if not enemy:GetComponent("attackable") then
	-- 	return print("can't attack target " .. toname(enemy))
	-- end
	table.insert(self.enemys, enemy);
end

function fighting:setAction(actions)
	self.actions = actions
end

return fighting;
