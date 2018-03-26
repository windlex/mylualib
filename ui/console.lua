Console = {
	msg = "",
	width = 90,
	co = coroutine.create(function ()
		return coroutine.yield()
	end)
}

function Console:Printform(s)
	self.msg = self.msg .. s;
end
function Console:SetColor(color)
	self.msg = self.msg .. string.format("<color=%s>",color);
end
function Console:ResetColor()
	self.msg = self.msg .. "</color>";
end
function Console:PrintL(s)
	s = s or ""
	self.msg = self.msg .. s .. "\n";
end
function Console:ClearLine(n)
end
function Console:DrawLine(s)
	s = s or "-"
	self.msg = self.msg .. string.rep(s,self.width/#s) .."("..#s.."/"..self.width/#s.. "\n";
end
function Console:PrintButton(sButton, nButton)
	self.msg = self.msg .. slink(sButton, string.format("Console:DoBtn(%d)", nButton));
end
function Console:Flush()
	print(self.msg)
	self.msg = "";
end
function Console:Print(s)
	self.msg = self.msg .. s;
end
function Console:DoBtn(nInput)
	self.cb(nInput);
end
function Console:WaitInput(cb)
	self.cb = cb;
end

return Console;
