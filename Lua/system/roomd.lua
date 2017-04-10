RoomD = {
	rooms = {},
	path2room = {},
}


function RoomD:addRoom(room)
	self.rooms[room.name] = room;
end

function RoomD:loadRoom(roompath)
	local room = self.path2room[roompath];
	if not room then
		room = require("Lua.area."..roompath);
		room:setup()
		room.path = roompath;
		self.path2room[roompath] = room;
	end
	return room;
end


function RoomD:showAction(room)
	print("RoomD:showAction")
	local tActions = room:queryAction();
	local msg = format("%-10s ==============%s\n", room.name, os.date());

	if not tActions then return end

	for k,v in pairs(tActions) do
		msg = msg .. link(k, v) .. "\n";
	end
	pl(msg);
end
