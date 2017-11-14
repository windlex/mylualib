local std_npc = require "perfab.std_npc"
local perfabPlayer = class (std_npc, {

})

function perfabPlayer:create(actor, name)
	print("create player!")
	std_npc:create(actor, name)
end

return perfabPlayer;
