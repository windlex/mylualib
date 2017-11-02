local room_d = daemon_base("房间管理精灵")
 
function room_d:Init()
	self:loadRoomConfig();
end

function room_d:loadRoomConfig()
end

function room_d:loadArea(path)

end

function room_d:loadRoom(path)
	local room = CreateEntity();
end
return room_d
