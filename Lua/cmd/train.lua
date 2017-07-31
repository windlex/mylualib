
local function loadCmd(name)
	return require("Lua.cmd.train"..name)
end

Traind:addCommand("normal", "talk", loadCmd("comf0")); 