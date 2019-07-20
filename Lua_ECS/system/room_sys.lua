RoomSys = System("房间系统")

RoomSys.rooms = {}
RoomSys.path2room = {}


function RoomSys:addRoom(room)
	self.rooms[room.name] = room;
end

function RoomSys:loadRoom(roompath)
	local room = self.path2room[roompath];
	if not room then
		room = require("area."..roompath);
		self.path2room[roompath] = room;
		room:setup()
		room:resetAction();
		room.path = roompath;
	end
	return room;
end


function RoomSys:showAction(room)
	print("RoomSys:showAction")
	local tActions = room:queryAction();
	print(Val2Str(tActions))
	local msg = "\n你可以在这里执行：\n";

	if not tActions then return end

	local bResult = false;
	for k,v in pairs(tActions) do
		msg = msg .. link(k, format("Room_onAction('%s')", k))  .. "\n";
		bResult = true;
	end
	if not bResult then return "" end
	
	pl(msg);
	return msg
end

function Room_onAction(act)
	local room = player:getCurrentRoom();
	room:onAction(act)
end

return RoomSys;
