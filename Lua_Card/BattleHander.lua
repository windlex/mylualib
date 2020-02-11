BattleHander = ClassEx( function()
	local h = self:Make {
		LibraryCards = {},
		HandCards = {},
		Hero = {},
		Minions = {},
		MagicCards = {},
		FieldCard = nil,
		Grayard = {},
		DestroyCards = {},
		ResourceCards = {},
	}
	h.sgi = SGMgr:InstanceSG(h, "SG_Hander");
	return h
end)

function BattleHander:NewPlayer(player)
	return self:New()
end
function BattleHander:NewAI(nBattleId)
	local h = self:New()
	h:LoadBattle(nBattleId);
	return h
end

function BattleHander:Untap()
	self.nEnerge = Lib:Copy(self.ResourceCards);	-- todo:
end

function BattleHander:DrawCard()
	for i = 1, self.nDrawCount do
		todo:DrawACard()
	end
end
function BattleHander:DrawACard()
	local nRand = Lib:Random(#self.LibraryCards)
	local cardInfo = self.LibraryCards[nRand]
	table.remove(self.LibraryCards, nRand);
	local aCard = CardMgr:SpawnCard(cardInfo)
	table.insert(self.HandCards, aCard);
	PlayAnim("DrawCard", aCard)
end
function BattleHander:BuffEffect()

end

-- Commend Process ---------------------------------
function BattleHander:ProcessCommend(cmd, ...)
	if self[cmdType] then
		self[cmdType](self, ...)
	end
end
function BattleHander:PlayCard(...)
	self.sgi:OnEvent("PlayCard", ...) 
end
function BattleHander:EndTurn()
	self.sgi:OnEvent("EndTurn")
end
function BattleHander:Say()
end
function BattleHander:Attack(myUnit, target)
end
function BattleHander:Surrender()
end

-- SGI Process ---------------------------------
function BattleHander.fnBeginTurn(self)
end
function BattleHander.fnDrawCard(self)
end
function BattleHander.fnUntap(self)
end

function BattleHander.fnPlayCard(self, ...)

end
function BattleHander.fnTimeout(self)
end
