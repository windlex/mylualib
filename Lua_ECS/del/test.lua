print("CharSys4", CharSys)
player = Entity();
CharSys:setupChar(player);

user = Entity();

print("user", Val2Str(user))
print("user meta", Val2Str(getmetatable(user)))

print("player", Val2Str(player))
print("player meta", Val2Str(getmetatable(player)))

print("STARTROOM", Val2Str(STARTROOM))
--MoveSys:move(player, STARTROOM)

print("player", Val2Str(player))
--player:move("admin.void_room")


-- 
print(VM.TileMap)
print(VM.TileMap:SetAutoTile(1,1,-1,1))
print(VM.TileMap:SetAutoTile(1,1,-1,0))

print(VM.TileMap)
print(PlayerInst)
pos = PlayerInst.transform.position;
print(pos)
print(pos.x*100/32, -pos.y*100/32)
print(VM.RpgMapHelper)
print(VM.RpgMapHelper.GetTileIdxByPosition(pos))
print(VM.RpgMapHelper.GetAutoTileByPosition(pos, 0).Id)
print(VM.RpgMapHelper.SetAutoTileByPosition(pos, 3, 0))
