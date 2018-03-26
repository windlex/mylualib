
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

Console = require "console"
Console:Print("aaa")
Console:Flush();
UIRoleState = require "case.ui_role_state"
UIRoleState:Paint()
do return end
print [[西涼　　　　　　　　　　　　　　　　　　　　　┏━━代県━━┳━━━北平
　┃　　　　　　　　　　　　　　　　　┏━━晋陽　　　　　　南皮　　　　
　┣━━安定　　　　　　　　　　　　上党　　　　　　　　　　┃　　　　　
　┃　　　┗┓　　　　　　　　　　　　┗┓　　　┏平原━━━┫　　　　　
天水　　　　┗◇┓　　　　　　　　　　　┗ゴ━━┛　┃　　　┃　　　　　
　┃　　　　　　┗┓　　　　　　　　　　　　　　　　┃　　北海━┳━城陽
　┃　　　　　　　┗長安━━━洛陽　　　　　　　┏濮陽　　　　　┃　　　
武都━┓　　　　　　┃　　　　　┃　　　　　　　┃　　　　　　　┃　　　
　　　┃　　　　　　┃　　　　　┗━┓　　┏━陳留　　　　小柿━┻━下ヒ
　　漢中━━◇━━上庸　　　　　　　許昌━┛　　┗┓　　　　┃　　　　┃
　　　┃　　　　　　┃　　　　　　　┃　　　　　　┗━シ━━┛　　　　┃
　　　┃　　　　　　┃　　　　　　　┃　　　　　　　┏┛　　　　　┏◇
　　　◇┓　　　　　襄陽━┳━新野━┻━汝南┓　　　┃　　　　　　┃　　
　　　　┃　　　　　　　　┃　　　　　　　　┗┓　寿春━━◇━━建業　　
　　┏━梓潼┓　　　　　　┃　　　　　　　　　┃　┏┛　　　　　　┗━呉
　　┃　　　┃　　　　　　江陵　　　　　┏━江夏━┛　　　　　　　　　┃
　成都　　　┗永安┓　　　┗┓　　　　　┃　　　　　　　　　　　　　　┃
　　┗┓　　　　　┗┓　　　┗┓　　　柴桑━━◇━━廬江　　　　　　会稽
　　　┗江州　　　　◇　　　　◇　　　　┗┓　　　　　┃　　　　　　　┃
　　　　┃　　　　　┗┓　　　┃　　　　　┃　　　┏━┛　　　　　　　
　　　　┃　　　　　　┗武陵━┻━長沙━━◇━━予章　　　　　　　建安┛
　　　　◇　　　　　　　┃　　　　　┃　　　　　　┃　　　　　　　┃　
　　　　┃　　　　　　　┃　　　　　┃　　　　　　┗━┓　　　　　┃　
雲南━━建寧　　　　　　零陵━━━桂陽　　　　　　　　廬陵━━◇━┛　　
]]
print [[
 ┏━━━━━◇━━━━━夢世界━━━━━◇━━━━━━┿静寂海┓　┏━桃源郷　月兎街━┓
 ┃┌桃園┓─┏竜遣寮┐┏━━━◇━━鳥船遺跡━━◇━┓｜　┃　◇　┃　　┗綿月亭┛┃　┃
 ┃｜┃┏総領娘宅┓┃｜┃┌────地霊殿────┐　┃｜　┃　┗豊穣海　　　┃　薬搗場┃
 ┃｜有頂天━━天人都┿┛┏灼熱跡━┛┃┗━血の池┿┓┗┿表月面━━◇━━━月の都━━━┛
 ┃└─┗━◇┓天界─┘　┃┏┛┏━旧街道━┓┗┓｜┃//└──────────╂──月面─
 ╂妖怪の山─╂────┐◇┗温泉街┓┃┏歓楽街┛｜┗━◇━━┓┏是非曲//////┗━━━┓//
 ┃　　　　┏山頂━━┓｜┃────途絶橋─旧都─┘┏渡船所━彼岸━━━◇━━┓//////┃//
 ┗風神湖┓┃　　┏━┃┿┛　　　　　┗◇┓　　　　◇////┏◇┛┗┓//////┏最果て┓//┃// 
 　　　守矢神社　┃　┃｜　　┏◇━中有道━━三途川┛//魂待処┓//┃////旅行社//魔界庁┃// 
 　　　┏┛┃┗間欠泉┃｜┏無縁塚────╂魔法の森┐　//┏白玉楼┗◇┓┃┗大都会┛//◇// 
 ┏━蝦蟇池┗◇┓　　┃｜┃　┃｜┏━━森北部━━┓｜┏大階段┗西行妖┃┗法界//┗┓//┃// 
 ┃　　┗┓　　┗九天滝┿┛　◇｜┃　┏┛　┗┓　┃｜◇//┗◇┓//////┃////┃┏霊魔殿┃// 
 ┃┏━未渓谷━━┛┃　│　　┃｜┃人偶館━魔法店┃｜┃　//八雲宅━◇━━幻夢界━━━┃┓
 ┃◇　　┗━┓┏玄武沢┿◇━森西部　┗┓　┏┛　森東部　┏◇┛//////┃////┃////////┃┃
 ┃┗華仙敷　山麓　　　｜　　　│┗━━森南部━━┛┃┗迷い家　　////┗┓//◇//異界　┃┃
 ┃　┏━◇━┛┗山樹海┿┓　　└────╂────┗◇┓┏墓地━◇━大祀廟┛//////┏┛┃
 ╂─╂────────┘┗━◇━━┓┏香霖堂　　┏━命蓮寺　　　　　//┗神霊廟//大結界┃
 ◇　┃紅魔館━━━妖精森━━┓　┌╂╂─────╂─┐┃　　┌素敵な神社──┐　　┃//◇
 ┃　┃　┃┗図書館┏┛湖周辺┃┏┿鈴奈庵━━━住宅街┿━┓　│　┏━裏手池━┿◇━┛　┃
 ┃　┗霧の湖━━湖の畔━◇━人里畑┃┗━阿求館━┛┃｜┃┗◇━博麗神社┗┓　│　　　　┃
 ┃廃洋館┛　┏◇━┛┏◇━━┛┃｜┃┏━┛　┗━┓┃｜┗┓　│　┃　┏裏山道┿◇┓　　┃
 ┃┗◇┓┏太陽畑━━┛　　　　┗┿霧雨店━━━寺子屋┿━━◇┿水楢木┛　┃　│　┃　　┃
 ┃┏無名丘┏┛┏◇━━永遠亭━◇┓───人里─╂─╂┘　┃　｜┃┗裏山湖┛　｜夢遺跡━┛
 ┃◇　┃　┃　┃┏兎集落┛┏━竹林東━◇━薬屋道┓┃　　◇┓└╂──╂───┘//┗研究室
 ┃┗┓┗◇━竹林西━━━筍の里━┓┗━━━━━━妹紅宅━忘去道┛　　◇　////┏夢幻館┓//
 ┗輝針城━┃━━━━◇━━━━竹林南━━━◇━━━鰻屋台━┛　　　　┗━夢幻門//////┃//
 　　　　　┗━━━━━━━━━━━━━◇━━━━━━━━━━━━━━━━━┛┗夢幻界┛//
 ]]
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

--BATTLE_D:doBattle(fa, fb, battleArea)
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