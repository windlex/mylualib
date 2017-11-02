function CreateEntity(perfabName)
	local perfab = require("perfab." .. perfabName);
	if not perfab then
		error("No Perfab Named " .. perfabName);
		return 
	end
	local entity = Manager:CreateEntity();
	local obj = perfab(entity);
	return obj;
end
