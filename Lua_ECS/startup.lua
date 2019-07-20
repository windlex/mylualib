if not package._path then
	package._path = package.path
	package.path = package.path .. ";Lua_ECS/?.lua;"
end

require "VMInit"
require "config"
require "base.global"
require "base.class"
require "base.component"
require "base.table"
require "base.tag"
require "base.callback"

require "base.class"
require "base.component"
require "base.table"
require "base.tag"

print('加载System')
require "daemons.system_mgr"
print("CharSys3", CharSys)

