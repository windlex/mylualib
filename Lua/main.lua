require "Lua.VMInit"
require "Lua.config"
require "Lua.base.global"
require "Lua.base.class"
require "Lua.base.component"
require "Lua.system.system"
require "Lua.std.actor"
require "Lua.std.char"
require "Lua.std.user"

--require "Lua.startup"

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
