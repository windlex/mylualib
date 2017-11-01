
local function loadCmd(name)
	return require("cmd.train"..name)
end

Traind:addCommand("normal", "talk", loadCmd("comf0")); 