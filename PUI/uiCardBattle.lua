local uiCardBattle = {}

function uiCardBattle:Init()
	self.go = VM.Logic.uiCardBattle or uiBase:findChild("CardBattle");
	print("uiCardBattle.go = ", self.go)
	self.go:SetActive(true)
	local goPlayer = uiBase:findChild("CardBattle/Player")
	local tPlayer = {
		Player = goPlayer;
		imgPlayer = goPlayer:GetComponent("Image");
		barHP = uiBase:GetChildComponent("CardBattle/Player/HPBar", "Slider");
	}
	self.Player = tPlayer;

	self.Enemy = {}
	for i = 1, 4 do
		local tRole = {};
		local role = uiBase:findChild("CardBattle/Enemys/E" .. i);
		tRole.role = role;
		tRole.imgRoleA = role:GetComponent("Image")
		tRole.barHP = uiBase:GetChildComponent("CardBattle/Enemys/E" .. i .. "/HPBar", "Slider")
		tRole.barHP.value = 0.5
		tRole.id = i;
		self.Enemy[i] = tRole;
	end

	self.CombatMsg = uiBase:GetChildComponent("CardBattle/CombatMsg", "UIScrollText")
	self.CombatMsg:AppendText("obabalblaboao")
end
function uiCardBattle:pl(msg)
	self.CombatMsg:AppendText(msg)
end
function uiCardBattle:SetPlayerHP(fHP)
	self.Player.barHP.value = fHP;
end
function uiCardBattle:SetEnemyHP(roleId, fHP)
	for i = 1, 4 do
		if self.Enemy [i].id == roleId then
			self.Enemy [i].barHP.value = fHP;
			if fHP <= 0 then
				self.Enemy[i].role:SetActive(false)
			end
			return
		end
	end
end

function uiCardBattle:StartBattle()

end

uiCardBattle:Init();
uiCardBattle:pl("boablaslb") 
uiCardBattle:pl("boablaslb") 
uiCardBattle:SetPlayerHP(0.1)
uiCardBattle:SetEnemyHP(1, 0.2) 
uiCardBattle:SetEnemyHP(2, 0) 
return uiCardBattle;