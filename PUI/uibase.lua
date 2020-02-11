uiBase = {}

function uiBase:findChild(szChild)
	local child = CS.UnityEngine.GameObject.Find(szChild)
	return child
end

function uiBase:GetChildComponent(szChild, compType)
	local child = self:findChild(szChild)
	if not child then return end
	return child:GetComponent(compType) 
end

function uiBase:LoadSprite(szpath)
	local spr = CS.Utl.LoadSprite("Assets/Resources/Image/"..szpath)
	return spr;
end

-- □■
function uiBase:Bar(cur, max, len)
	max = max or 100
	len = len or 10
	local per = math.floor(cur / max * len)
	local bar = string.rep("■", per)..string.rep("□", (len - per))
	print(bar)
	return bar
end

return uiBase