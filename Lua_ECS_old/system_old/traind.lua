--train
Traind = {
	cmds = {},
}

function Traind:addCommand(name, cmd)
	self.cmds[name] = cmd;
end

function Traind:showCommands()
	for name, cmd in pairs(self.cmds) do
		if cmd:check() then

		end
	end
end
