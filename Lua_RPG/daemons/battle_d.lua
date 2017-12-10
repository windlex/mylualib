local battle_d = daemon_base("战场精灵")
battle_d.battles = {}

function battle_d:FixedUpdate()
	--print("battle breathe")
	for _, battle in pairs(self.battles) do
		local result = self:runRound(battle);
		if not result then
			self:endBattle(battle);
			self.battles[_] = nil;
		end
	end
end

function battle_d:runRound(battle)
	--ppt(battle)
	if self:checkEnd(battle) == true then
		return false;
	end
	if battle.round >= battle.maxRound then
		return self:finalRound(battle);
	end
	self:beforeRound(battle)
	self:sortActors(battle);
	for _, actor in ipairs(battle.actionList) do
		self:doAction(battle, actor);
	end
	self:endRound(battle)
	return true;
end

function battle_d:checkEnd(battle)
	if #battle.campA == 0 or #battle.campB == 0 then
		return true;
	end
	return false;
end
function battle_d:beforeRound(battle)
	print(string.format("Round (%d) Start!", battle.round))
end
function battle_d:endRound(battle)
	battle.round = battle.round + 1
end

function battle_d:sortActors(battle)
	local actors = {}
	for _, actor in pairs(battle.campA) do
		table.insert(actors, actor);
	end
	for _, actor in pairs(battle.campB) do
		table.insert(actors, actor);
	end
	battle.actionList = actors;
	return actors;
end
function battle_d:doAction(battle, actor)
	--print(actor.name.." Action!")
	local fa = actor:GetComponent("fighting")
	--print("camp=",fa.camp)
	local target = table.random(battle.campB)
	if fa.camp == 2 then
		target = table.random(battle.campA);
	end
	--ppt(actor);
	--ppt(target)
	local action = SKILL_D:queryAction(actor);
	COMBAT_D:Attack(actor, target, action)
end
function battle_d:finalRound(battle)

end
function battle_d:endBattle(battle)

end
function battle_d:doBattle(formationA, formationB, battleArea)
	local battle = {
		campA = formationA,
		campB = formationB,
		battleArea = battleArea,
		round = 1,
		maxRound = 5,
		actionList = {},	-- 行动队列，每Round Actor排序后根据队列行动
		death = {{}, {}},	-- 分camp记录已死亡的Actors 
	}
	for i = 1, #formationA do
		local actor = formationA[i];
		local fa = actor:GetComponent("fighting")
		fa.camp = 1;
		fa.battle = battle;
	end
	for i = 1, #formationB do
		local actor = formationB[i];
		local fa = actor:GetComponent("fighting")
		fa.camp = 2;
		fa.battle = battle;
	end
	table.insert(self.battles, battle);
end

function battle_d:onActorDie(actor)
	local fa = actor:GetComponent("fighting");
	local battle = fa.battle;

	local camp;
	if fa.camp == 1 then 
		camp = campA;
	else
		camp = campB;
	end
	table.erase(actor);
	table.insert(battle.death[fa.comp], actor);
end 
return battle_d;