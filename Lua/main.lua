if not package._path then
package._path = package.path
package.path = package.path .. ";Lua/?.lua;"
end

STD_ROOM = "std.room"

require "VMInit"
require "config"
require "base.global"

require "base.class"
require "base.component"
require "base.table"
require "base.tag"

print('加载System')
require "ECSBase.system_mgr"


-- print(VM.TileMap)
-- print(VM.TileMap:SetAutoTile(1,1,-1,1))
-- print(VM.TileMap:SetAutoTile(1,1,-1,0))

-- print(VM.TileMap)
-- print(PlayerInst)
-- pos = PlayerInst.transform.position;
-- print(pos)
-- print(VM.RpgMapHelper)
-- print(VM.RpgMapHelper.GetTileIdxByPosition(pos))
-- print(VM.RpgMapHelper.GetAutoTileByPosition(pos, 0).Id)
-- print(VM.RpgMapHelper.SetAutoTileByPosition(pos, 3, 0))
