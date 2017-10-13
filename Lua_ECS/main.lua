STD_ROOM = "Lua.std.room"

require "Lua.VMInit"
require "Lua.config"
require "Lua.base.global"

require "Lua.base.class"
require "Lua.base.component"
require "Lua.base.table"
require "Lua.base.tag"

print('加载System')
require "Lua.ECSBase.system_mgr"


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
