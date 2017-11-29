local world_d = daemon_base("地图精灵")

function world_d:Init( )
	print("world Init ")
	daemon_base.Init(self);
	self:loadAllRooms()
	self.rooms = {}
end
function world_d:loadAllRooms()
	local room_templates = {}
	ff_GetTabFileTableEx("settings/rooms.csv", 2, {
		tonumber,-- id	
		nil,-- path	
		nil,-- name	
		nil,-- desc	
		nil,-- exits	
		nil,-- objects	
		nil,-- actions
	}, function (tLine)
		if tLine.name ~= "" then
			room_templates[tLine.path] = tLine;
			local strexits, exits = tLine.exits, {};
			local tstr = string.split(strexits, "|")
			for k, v in pairs(tstr) do
				local exit = string.split(v, "#")
				tinsert(exits, {exit[1], exit[2]});
			end
			tLine.exits = exits;
		end
	end, ',')
	--ppt(room_templates)
	self.room_templates = room_templates;
end

function world_d:move(actor, room)
	if type(room) == 'string' then
		room = self:loadRoom(room);
	end
	if not room then 

		return
	end
	--print("move to ", Val2Str(room))
	local place = actor:GetComponent("place");
	if place.env then
		place.env:removeActor(actor)
	end
	place:leaveEnv();
	local env = room:GetComponent("room_env");
	--ppt(getmetatable(env))
	place:enterEnv(env);
	env:addActor(actor)
	self:look(actor)
end

function world_d:loadRoom(roomPath)
	if self.rooms[roomPath] then
		return self.rooms[roomPath]
	end
	local template = self.room_templates[roomPath];
	if not template then
		print("no room named "..roomPath)
		return
	end
	local room = PERFAB_D:spawnPerfab("std_room")
	room.template = template;
	self:setup(room, template)
	self.rooms[roomPath] = room;
	return room;
end

function world_d:setup(room, template)
	room.name = template.name;
end

function world_d:look(actor)
	local place = actor:GetComponent("place");
	local env = place.env;
	if not env.actor then
		return print("你周围雾蒙蒙的,什么也看不清!");
	end
	local room = env.actor;
	-- ppt(room);

	local msg = "[" .. room.name .. ']';
	msg = msg .. "\n".. (room.desc or room.template.desc or "");

	--msg = msg .. self.placement:onLook();
	msg = msg.."\n这里有:\n"
	for k, char in pairs(env.objects) do
		msg = msg .. self:link(char).. ", "
	end

	--msg = msg .."\n" .. self:lookExits();
	if not room.template.exits then 
		msg = msg.. "这里没有明显的出口..." 
	else
		local msg = msg .. "这里的出口有:"
		--print(room.template.exits)
		for _, exit in pairs(room.template.exits) do
			--msg = msg .. link(exit, format("placement_onExit('%s')", exit)) .. ","
			--ppt(exit)
			cmd(exit[1], callback(self.onExit, self, actor, room, _, exit))
		end
	end

	--msg = msg .. self:lookFacility();
	--msg = msg .. RoomSys:showAction(self);

	print(msg);
	cmd("移动", self.showmap)
	return msg;
end

function world_d:onExit(actor, room, id, exit)
	print("world_d:onExit")
	--ppt(actor, room, exit)
	local exit = room.template.exits[id];
	self:move(actor, exit[2]);
end

function world_d:link(char)
	return link(char.name, format("Char_onTalk(%d)", char:getID()))
end

function world_d.showmap()
	print("world_d:showmap")
	local place = player:GetComponent("place");
	local env = place.env;
	local room = env.actor;
	--ppt(room);
	local area = gsub(room.template.path, "%.(.+)", "")
	--ppt(area)
	local msg = AREA_D:loadArea(area)
	print(msg)
end

function world_d:onMap(mapname)
	local place = player:GetComponent("place");
	local env = place.env;
	local room = env.actor;
	--ppt(room);
	local area = gsub(room.template.path, "%.(.+)", "")
	--ppt(area)
	self:move(player, area..'.'..mapname)
end

return world_d;
