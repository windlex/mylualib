local uiCombat = {}

function uiCombat:Init()
	ppt(VM.Logic.uiCombat)
	self.go = VM.Logic.uiCombat;
	print("uiCombat .go = ", self.go)
	self.go:SetActive(true)
	self.Role = {}
	for i = 1, 2 do
		local tRole = {};
		local role = uiBase:findChild("Combat/Role"..i);
		tRole.role = role;
		tRole.imgRoleA = role:GetComponent("Image")
		tRole.barHP = uiBase:GetChildComponent("Combat/Role"..i.."/HPBar", "Slider")
		tRole.barHP.value = 0.5
		self.Role[i] = tRole;
	end
	self.CombatMsg = uiBase:GetChildComponent("Combat/CombatMsg", "UIScrollText")
	self.CombatMsg:AppendText("obabalblaboao")
end

function uiCombat:StartCombat(roldId1, roldId2)
	self.go:SetActive(true)
	self.CombatMsg:Clear()
	self.Role[1].id = roldId1
	self.Role[2].id = roldId2
end
function uiCombat:pl(msg)
	self.CombatMsg:AppendText(msg)
end
function uiCombat:SetHP(roleId, fHP)
	for i = 1, 2 do
		if self.Role[i].id == roleId then
			self.Role[i].barHP.value = fHP;
			return
		end
	end
end

uiCombat:Init();
return uiCombat;
