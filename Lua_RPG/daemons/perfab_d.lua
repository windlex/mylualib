perfab_d = daemon_base("预设物件管理精灵")

function perfab_d:Init()
	self:loadPerfabs();
end

function perfab_d:loadPerfabs()

end

function perfab_d:spawnPerfab(name)
	local actor = Manager:CreateActor();
	local perfab = require("perfab."..name)
	if not perfab then
		error("no perfab named "..name)
		return
	end

	return perfab:create(actor);
end

return perfab_d;
