local moveable = class {}

function moveable:_ctor(actor)
	actor.move = self.move;
	actor.getCurrentRoom = self.getCurrentRoom;
	actor.setCurrentRoomPath = self.setCurrentRoomPath;
end

function moveable:move(room)
	if type(room) == 'string' then
		room = RoomD:loadRoom(room);
		if not room then
			assert()
		end
	end
	self.currentRoomPath = room.path;
	room:addChar(self)
	self:look();
end

function moveable:getCurrentRoom()
	return RoomD:loadRoom(self.currentRoomPath);

end
function moveable:setCurrentRoomPath(room)
	self.currentRoom = room;
end

return moveable;