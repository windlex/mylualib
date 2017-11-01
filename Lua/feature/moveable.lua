local moveable = class {}

function moveable:_ctor(actor)
	actor.move = self.move;
	actor.getCurrentRoom = self.getCurrentRoom;
	--actor.setCurrentRoomPath = self.setCurrentRoomPath;
	--actor:addMethod('setCurrentRoomPath', self.setCurrentRoomPath);

end

function moveable:move(room)
	if type(room) == 'string' then
		room = RoomSys:loadRoom(room);
		if not room then
			assert()
		end
	end
	room.placement:addChar(self)
	self.currentRoom = room;
	self:look();
end

function moveable:getCurrentRoom()
	return self.currentRoom;
end
function moveable:setCurrentRoom(room)
	self.currentRoom = room;
end

function moveable:setCurrentRoomPath(roomPath)
	self.currentRoomPath = roomPath;
end

return moveable;