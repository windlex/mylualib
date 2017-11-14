local room_d = daemon_base("房间管理精灵")
 
function room_d:setup()
	local room = PERFAB_D:spawnPerfab("std_room")
end

return room_d
