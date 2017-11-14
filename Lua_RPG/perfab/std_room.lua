std_room = class {}

function std_room:create(entity)
	entity:AddComponent("room_env")
end

return std_room;