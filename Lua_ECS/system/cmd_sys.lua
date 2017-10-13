CmdSys = System()

function CmdSys:update()
	for _, cmdComp in pairs(ECSMgr:GetComponents("cmd")) do
		for _, cmd in ipairs(cmdComp._cmdList) do
			self:process(cmd);
		end
	end
end

function CmdSys:addCommand(cmd, cmdtype, cmdparam)
	tinsert(cmd, {cmdtype, cmdparam});
end

function CmdSys:process(cmd)
	local en = cmd.owner;
	local handler = self.handlers[cmd.cmdtype]
	handler(cmd, en);
end

function CmdSys.go(cmd, entity)
	MoveSys:onExit(cmd.param)
end

CmdSys.handlers = {
	go = CmdSys.go,
}
