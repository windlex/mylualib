
require "Lua.asset"

player = Char("player");
enemy  = Char("enemy");

print("player=", Val2Str(player));
print("player.meta=", Val2Str(getmetatable(player)));

player.action.flag="balblalba";

print("player=", Val2Str(player));
print("player.meta=", Val2Str(getmetatable(player)));
print("enemy=", Val2Str(enemy));

print("Lua Main");
print(Val2Str(VM.Logic.cmdList))
print("Lua Main");
--CombatD:fight(player, enemy)
print("请立即装备<quad act=blalba a=[木剑] width=3 />  <quad img=xb_b size=250 width=1 />武器")
print("test Image <quad img=xb_b size=40 width=1 />test Imagetest Image <quad img=xb_a size=40 width=1 />test Imagetest Image <quad img=xb_b size=40 width=1 />test Imagetest Image <quad img=xb_a size=40 width=1 />test Imagetest Image <quad img=xb_b size=40 width=1 />test Imagetest Image <quad img=xb_a size=40 width=1 />test Image")
print("<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a111<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a<quad width=0><quad act=blalba a=[木剑] width=3 />a")
function blalba()
	print("balblabla");
end
map = [[
紅魔館 ===============================================
■■■■■■■■■■■■■■■■■■■■■■■■■■■
■　　　　　　　　　　　　[6] 　　　　　　　　│ [5]■
■　　　　　　　　　　　　　　　　　　　　　　■■■■
■　　　　　　　　　　　　　　　　　　　　　　　　　■
■　　■■■■■■■■■■―■■■■■■■■■■　　■
■　　■　　　│　 [13]　　 ■■<[18] ■ [11] ■　　■
■　　■ [14] ■―■■■■■■■■■　■―■―■　　■
■　　■　　　■　l>　　 [17] 　　<l　■　　　■　　■
■　　■　　　│　￣￣￣】↑【￣￣￣　■　　　■　　■
■　　■■■■■　　　　　　　　　　　■　　　■　　■
■　　■[16]│　　　　　　[9] 　　　　│ [10] ■　　■
■　　■■■■―■■■■■―■■■■■■　　　■　　■
■　　　　■[15]■＿＿　　　　　  ＿＿■　　　■　　■
■　　　　■　　■　 ∥ 木　 木　∥　 ■―■―■　　■
■　　　　■　　■[8]∥ 木[2]木　∥[7]■ [12] ■　　■
■　　　　■■■■　 ∥ 木　 木　∥　 ■■■■■　　■
■　　　　　　　　￣￣　木　 木   ￣￣　　　　　　　■
■■■■　　　　　　　　木　 木 　　　　　　　■■■■
■ [3]│　　　　　　　　　　　 　　　　　　 　│[4] ■
■■■■■■■■■■■●  [1] ●■■■■■■■■■■■

]]
--print(map)
map = gsub(map, "%[(%d+)%]", function(id) 
	local s = string.format("<quad act=onMap(%s) a=[%s] width=%d />", id, id, #id)
	--print(s);
	return s;
end)
--print(map);
tRoom = {
	[1]  = "正門 ",
	[2]  = "庭 ",
	[3]  = "守衛小屋 ",
	[4]  = "空的小屋 ",
	[5]  = "仓库 ",
	[6]  = "裏庭 ",
	[7]  = "東侧阳台 ",
	[8]  = "西侧阳台 ",
	[9]  = "大厅 ",
	[10] = "図書館 ",
	[11] = "帕秋莉私室 ",
	[12] = "小悪魔私室 ",
	[13] = "厨房 ",
	[14] = "食堂 ",
	[15] = "応接間 ",
	[16] = "一階厕所 ",
	[17] = "大楼梯 ",
	[18] = "地下楼梯 ",
}
msg = ""
for i = 1, #tRoom do
	local btn = format("%2d : %-10s", i, tRoom[i])
	msg = msg .. format("<quad act=onMap(%d) a=[%s] width=%d />", i, btn, 1);
	if math.fmod(i, 4) == 0 then
		msg = msg .. "\n"
	end
end
--print(msg);

room1 = require("Lua.std.area.xiangyang");
room1:setup()
RoomSys:setCurrentRoomPath(room1)
RoomSys:showAction(room1);

ActionD:addAction('env', 'test', function () print("test") end)
ActionD:addAction('cmd', 'test2', callout(print, 'test2'));
ActionD:addAction('sys', 'test3', "test3");
ActionD:showAction();

function onMap(l)
	print(format("你来到了%s！", tRoom[l]));
end
function onNewGame()
	pl("<color=red>也暂未实装!!</color>");
	pl("");
	pl("");
	pl("");
	title();
end

function onLoadGame()
	pl("<color=blue>暂未实装!!</color>");
	wait();
	pl("");
	pl("");
	pl("");
	title();
	title();
end
function choice(n)
	pl(n);
	title();
end
function title()
	--cls();
	pl("UniEro");
	pl("Ver 0.000001");
	pl("");
	wait();
	pl("[balbalblablablalb]");
	pl("邪恶正在蔓延...");
	cmd("New Game", "onNewGame");
	cmd("choice 1", "choice");
	cmd("choice 2", choice, 2);
	cmd("Load Game", onLoadGame);
end

--start(title)
--debug.log(Val2Str(VM))