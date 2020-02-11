Battle = ClassEx( {}, function (nBattleId, player)
	local b = self:Make{
		nBattleId = nBattleId,
		player = player,
		camp = {},
	}
	b.sgi = SGMgr:InstanceSG(b, 'SG_Battle');
	b.camp[1] = BattleHander:New(player)
	b.camp[2] = BattleHander:New(AI):LoadBattle(nBattleId);
	return b;
end)

function Battle:Start()
	self.sgi:GoToState("StartBattle")
end

function Battle:Round()
	self.nRound = self.nRound + 1
	self:SortHero();
	for each in self.Hander do
		local Hander = self:NextHander()
		if Hander then
			Hander:Turn()
		end
	end
	self:EndRound()
end

function Battle:Turn(pHander)
	pHander:InitResource();
	pHander:DrawCard();
	pHander:BuffEff();
	todo:wait(pHander);
	self:EndTurn(pHander)
end

BattleMgr = ClassEx {}
function BattleMgr:StartBattle(nBattleId, player)
	local bt = Battle:New(nBattleId, player)
	return bt:Start();
end

