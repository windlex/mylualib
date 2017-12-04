
STD_ROOM = "std.room"

require "base.table"
require "base.callback"
require "base.string"
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
local skilllist = player:GetComponent("skilllist")
skilllist.activeSkills = {"基本拳脚"}

local fa = {player}
local a = PERFAB_D:spawnPerfab("std_npc", "A");
local skilllist = a:GetComponent("skilllist")
skilllist.activeSkills = {"基本拳脚"}
local b = PERFAB_D:spawnPerfab("std_npc", "B");
local skilllist = b:GetComponent("skilllist")
skilllist.activeSkills = {"基本拳脚"}
local fb = {a, b}

BATTLE_D:doBattle(fa, fb, battleArea)
--ppt(Manager)
ppt(string.split("离开#world.汴京|进入#daocaoyuan.大路", "#|"))

-- function printa()
-- 	print("a")
-- end
-- select("a", printa)
-- select("b", "printa")
-- select("ccccccccccccccccccc", callback(print, 'cccc'))
-- function d()
-- 	for i = 1, 20 do
-- 		select("d"..i, printa)
-- 	end
-- end
-- select("d", d)
-- --ppt(Manager)

--ppt(player)
WORLD_D:move(player, STARTROOM)
--print(AREA_D:loadArea("jingduwai"))
--print("准确的说是被废黜的皇帝，就在几天前，十三岁的少帝刘辩被权倾朝野的奸臣董卓强行废除帝号，改立八岁的陈留王刘协为帝，将仅仅才做了一百多天皇帝的刘辩废为弘农王，限期离京，前往一百多里之外的弘农居住。")
-- print("SIM", SIM )
-- if SIM then
-- 	print(SIM)
-- 	OnStart()

-- 	for i=1,10 do
-- 		--_Manager:FixedUpdate()
-- 	end
-- end