RoomD = {
	rooms = {},
}


function RoomD:addRoom(r)
	self.rooms[r.name] = r;
end

function RoomD:getCurrentRoom()
	return self.currentRoom;
end
function RoomD:setCurrentRoom(room)
	self.currentRoom = room;
end

function RoomD:showAction(room)
	print("RoomD:showAction")
	local tActions = room:queryAction();
	local msg = format("%-10s ==============%s", room.name, os.date());

	if not tActions then return end

	for k,v in pairs(tActions) do
		msg = msg .. link(k, v) .. "\n";
	end
	pl(msg);
end
