print("MMMMMMMMMMMMMMMMM++++++++++++");
CS.System.Console.WriteLine('hello world')

local T = CS.Terraria
local TMain = T.Main
local ChatManager = T.UI.Chat.ChatManager
local Vector2 = CS.Microsoft.Xna.Framework.Vector2

print(Vector2.One)

function Main()
	print(CS)
	print(T)
	print(TMain)
	print(ChatManager)
	for k,v in pairs(T) do print(k,v) end
	print("TTTTTTTTTTTTTTTTTTTTT")
end

function OnEnterWorld(player)
	print("OnEnterWorld---------------------------")
	print(type(player))
	--ChatManager.AddChatText(TMain.fontMouseText, "balblablabla", Vector2.One)
	if player then
		gPlayer = player
		print(player.name)
		player.statLifeMax = 999
		player.statLifeMax2 = 999
	end
end

function OnNpcSpawn()
	print("OnNpcSpawn---------------------------")
end

--==============================--
--desc:
--time:2019-08-29 04:22:45
--@return 
--==============================----------------------
IslandHouse = T.WorldGen.IslandHouse
floor = math.floor
function BuildHouse()
	print("Try Build House")
	if not gPlayer then return end
	local x,y = floor(gPlayer.position.X/16), floor(gPlayer.position.Y/16)
	print(x,y)
	--IslandHouse(x,y)
	package.loaded["Lua.building"] = nil
	local tBlueprint = require "Lua.building"
	tBlueprint:place(x,y)
end
function Reload()
	package.loaded['main'] = nil
	require 'main'
	print("Reloaded!!!!!")
end
function AddItem()
	if not gPlayer then return end
	local x,y = floor(gPlayer.position.X), floor(gPlayer.position.Y)
	local itype = math.random(1, 3929);
	print(x,y, gPlayer.width, gPlayer.height, itype, 1, false, 0, false, false)
	T.Item.NewItem(x,y, gPlayer.width, gPlayer.height, itype, 1, false, 0, false, false);
	lastKey = nil;
end
FnKey = {
	[113] = BuildHouse,
	[114] = AddItem,
	[116] = Reload,
}
function OnKeyEvent(key)
	if lastKey == key then return end
	print("OnKeyEvent---------------------------", key)
	lastKey = key

	local fnKey = FnKey[key];
	if fnKey then
		fnKey()
	end
end
