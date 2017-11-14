
STD_ROOM = "std.room"

require "base.table"
require "base.callback"
require "VMInit"

require "base.global"
require "base.class"
require "base.component"
require "base.tag"

require "base.tabfile"

function ppt(t)
	print(Val2Str(t))
end
-- t = ff_GetTabFileTable("settings\\skills.csv",1,{
-- }, ppt, ',')
-- ppt(t)
-- t = ff_GetTabFileTableEx("settings\\skills.csv",1,{
-- }, ppt, ',')
-- ppt(t)

require "object.daemon_base"

require "config"
require "system.manager"

player = PERFAB_D:spawnPerfab("player", "player");
ppt(Manager)
ppt(player)
WORLD_D:move(player, STARTROOM)

-- print("SIM", SIM )
-- if SIM then
-- 	print(SIM)
-- 	OnStart()

-- 	for i=1,10 do
-- 		--_Manager:FixedUpdate()
-- 	end
-- end