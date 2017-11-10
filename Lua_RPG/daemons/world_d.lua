local world_d = daemon_base("地图精灵")

function world_d:Init( )
	print("world Init ")
	daemon_base.Init(self);
	self:loadAllRooms()
end
function world_d:loadAllRooms()
	local rooms = ff_GetTabFileTableEx("settings\\rooms.csv", 2, {
		tonumber,-- id	
		nil,-- path	
		nil,-- name	
		nil,-- desc	
		nil,-- exits	
		nil,-- objects	
		nil,-- actions
	}, function (tLine)
		print("tLine", tLine.name)
		print(VM.Convert("GBK", tLine.name))
		print(gbk2utf8(tLine.name))
	end, ',')
	ppt(rooms)
	self.rooms = rooms;
end

function world_d:move(actor, env)
	local place = actor:GetComponent("placement");
	place:setEnv(env);
	env:addActor(actor)
end

function world_d:loadRoom(roomPath)
	return require("world." .. roomPath)
end

return world_d;
