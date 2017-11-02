ActionD = {
	env = {},
	inv = {},
	cmd = {},
	sys = {},
}

function ActionD:makeLink(stype, key)
	print(stype, key);
	return link(key, format("ActionD:onAction('%s','%s')", stype, key));
end

function ActionD:showAction()
	local msg = ""

	for k,v in pairs(self.env) do
		msg = msg .. self:makeLink('env', k);
	end
	for k,v in pairs(self.inv) do
		msg = msg .. self:makeLink('inv', k);
	end
	for k,v in pairs(self.cmd) do
		msg = msg .. self:makeLink('cmd', k);
	end
	for k,v in pairs(self.sys) do
		msg = msg .. self:makeLink('sys', k);
	end
	print(msg);
end

function ActionD:onAction(stype, key)
	local cmd = self[stype][key];
	if type(cmd) == 'function' then
		cmd();
	else
		pcall(loadstring(cmd));
	end
end

function ActionD:addAction(stype, name, cmd)
	self[stype][name] = cmd
end
