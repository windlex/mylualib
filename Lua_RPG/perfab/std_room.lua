std_room = class {}

function std_room:create(entity)
	entity:AddComponent("env")
end

return std_room;