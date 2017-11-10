perfab_d = daemon_base("预设物件管理精灵")

function perfab_d:Init()
	self:loadPerfabs();
end

function perfab_d:loadPerfabs()

end

function perfab_d:spawnPerfab(perfabName, name)
	local actor = Manager:CreateActor();
	local perfab = require("perfab."..perfabName)
	if not perfab then
		error("no perfab perfabNamed "..perfabName)
		return
	end

	perfab:create(actor, name);
	return actor;
end

return perfab_d;
