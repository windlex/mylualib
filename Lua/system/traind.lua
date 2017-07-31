--train
Traind = {
	cmds = {},
}

function Traind:addCmdGroup(stype)
	if self.cmds[stype] then return end
	self.cmds[stype] = {
		enable = true,
		
	}
end

function Traind:addCommand(stype, name, cmd)
	if not self.cmds[stype] then
	end
	self.cmds[stype][name] = cmd;
end

function Traind:showCommands(me, target, assister)
	for name, cmd in pairs(self.cmds) do
		if cmd:check(me, target, assister) then

		end
	end
end
