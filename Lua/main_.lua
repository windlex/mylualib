STD_ROOM = "std.room"

require "VMInit"
require "config"
require "base.global"
require "base.class"
require "base.component"
require "base.table"
require "base.tag"
print('加载System')
require "system.system"

require "std.entity"
require "std.actor"
require "std.char"
require "std.user"

--require "startup"

user = User();
player = Char();
user:link(player)

print(Val2Str(user))
print(Val2Str(getmetatable(user)))

print(Val2Str(player))
print(Val2Str(getmetatable(player)))

print(Val2Str(STARTROOM))
player:move(STARTROOM)
--player:move("admin.void_room")

print(VM.TileMap)
print(VM.TileMap.Instance:SetAutoTile(1,1,-1,1))
print(VM.TileMap.Instance:SetAutoTile(1,1,-1,0))