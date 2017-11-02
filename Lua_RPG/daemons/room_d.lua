local room_d = {
	name = "test_Daemon",
	t=0,
}
function room_d:Init()
	print("test_Daemon Init ")
end
function room_d:UnInit()
	print("test_Daemon UnInit  ")
end
function room_d:FixedUpdate()
end
function room_d:Update()
	print("test_Daemon Update  ")
end

function room_d:loadRoom(path)
	local room = CreateEntity();
end
return room_d
