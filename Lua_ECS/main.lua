if not _path then
package.path = package.path .. ";Lua_ECS/?.lua"
_path = 1
end

require "VMInit"
require "config"

require "base.global"
require "base.class"
require "base.component"
require "base.table"
require "base.tag"
require "base.callback"

print('加载System')
require "daemons.system_mgr"
print("CharSys3", CharSys)

