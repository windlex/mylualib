local uiHAct = {}
uiHAct.goName = "HAct"

function uiHAct:Init()
	self.go = uiBase:findChild(self.goName);
	print("uiHAct.go = ", self.go)
	self.go:SetActive(true)

	self.txtState = {}
	for i = 1, 2 do
		self.txtState[i] = uiBase:GetChildComponent(self.goName.."/txtState"..i, "Text")
		self.txtState[i].text = string.format([[Name: Role%d
TA:%s
TB:%s
TC:%s]], i, uiBase:Bar(45), uiBase:Bar(1), uiBase:Bar(10, 10, 5));
	end

	self.Msg = uiBase:GetChildComponent(self.goName.."/Msg", "UIScrollText")
	self.Msg:AppendText("obabalblaboao")
end

function uiHAct:UpdateState(i, pRole)

end
function uiHAct:AddMsg(msg)
	self.Msg:AppendText(msg)
end

function uiHAct:ClearMsg()
	self.Msg:Clear()
end

uiHAct:Init()

return uiHAct;
