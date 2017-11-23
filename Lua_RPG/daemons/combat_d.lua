combat_d = daemon_base("战斗系统")

function combat_d:FixedUpdate(  )
	local group = Manager:getAllComponent("fighting")
	for _, fighting in pairs(group) do
		if fighting.actor:hasTag("fighting") then
			self:dofight(fighting)
		end
	end
end

function combat_d:MakeEnemy(A, B)
	local f1 = A:GetComponent("fighting");
	local f2 = B:GetComponent("fighting");
	if f1 then 
		f1:addEnemy(B)
		A:addTag("fighting")
	end
	if f2 then 
		f2:addEnemy(A) 
		B:addTag("fighting")
	end
end
function combat_d:endfight(actor)
	actor:removeTag("fighting")
end
function combat_d:dofight(fighting)
	local me = fighting.actor;
	local target, loop = nil, 0;
	while not target do
		loop = loop + 1;
		if loop > 100 then
			print("overflow!!!")
			return
		end
		if not fighting.enemys or #fighting.enemys == 0 then
			self:endfight(fighting.actor);
			return
		end
	
		--todo:busy

		target = table.random(fighting.enemys);
		if target:GetComponent("health").health_cur < 0 then
			fighting:removeEnemy(target);
			target = nil
		end
	end
	self:Attack(me, target);
end

-- A攻击B 1次
function combat_d:Attack(A, B)
	local fa, fb = A:GetComponent("fighting"), B:GetComponent("fighting")
	local action = self:queryAttackAction(A, B);
	if not action then
		return print("No Action", A);
	end
	--print(Val2Str(action));
	local msg = action.actionmsg;
	msg = msg:gsub("#A", A.name)
		:gsub("#B", B.name)
	pl(msg);
	
	-- 闪避，招架，命中 轮盘
	local attack = fa:queryAttack()
	local dodge = fb:queryDodge();

	local damage = 0;
	if attack * 100 / (attack + dodge) > random(100) then
		local attack = fa:queryDamage() * 3;
		local defance = fb:queryArmor();
		damage = attack - random(1, defance);
		if damage > 0 then
			B:GetComponent("health"):recvDamage(damage);
		else
			pl(format("但是被%s挡住了!", B.name));
		end
	else
		pl("但是没有命中!")
	end
end

function combat_d:queryAttackAction(fa, fb)
	-- --local weapon = self.inventory["weapon"];
	-- local using_skill = "unarmed";
	-- if weapon then
	-- 	using_skill = weapon:querySkill();
	-- end
	-- return me.skill_list:queryAction(using_skill);
	local skill = SKILL_D:loadSkill("unarmed");
	return table.random(skill.actions)
end

function combat_d:removeAllEnemy(actor)
	local fighting = actor:GetComponent("fighting");
	fighting:removeAllEnemy();
end

return combat_d;
