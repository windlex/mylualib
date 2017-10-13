CmdSys = System("指令系统")

function CmdSys:update()
	for _, cmdComp in pairs(SystemMgr:getComponentGroup("command")) do
		for _, cmd in ipairs(cmdComp._cmdList) do
			self:process(cmd);
		end
		cmdComp._cmdList = {}
	end
end

function CmdSys:addCommand(cmd, cmdtype, cmdparam)
	table.insert(cmd, {cmdtype, cmdparam});
end

function CmdSys:loadCmd(cmdtype)
	local handler, help = require("cmd.".. cmdtype);
	if not help then
		help = self.defaultHelp
	end
	self.help[cmdtype] = help;

	if not handler then
		return notify_fail("no command ".. cmdtype)
	end
	self.handlers[cmdtype] = handler;
	return handler, help;
end

function CmdSys:process(cmd)
	local en = cmd.owner;
	local cmdtype = cmd[1];
	local handler = self.handlers[cmdtype];
	if not handler then
		handler = self:loadCmd(cmdtype);
		if not handler then return end
	end
	handler(cmd[2], en);
end

function CmdSys.help(cmd, en)
	local cmdtype = cmd;
	local fnhelp = self.help[cmdtype];
	if not fnhelp then
		_, fnhelp = self:loadCmd(cmdtype);
	end
	if not fnhelp then
		return ""
	end
	fnhelp();
end
function CmdSys.defaultHelp()
	print("no help doc!")
end

CmdSys.handlers = {
	help = CmdSys.help,
}

return CmdSys;