local city = class {
	name = "city",
}

function city:_ctor(owner)
	self.owner = owner;
end

actionForce = {
	["内政"] = actionNeiZhen,
	["外交"] = actionWaijiao,
	["军备"] = actionJunbei,
	["战争"] = actionZhanzhen,
}

function actionFuDi()
	local room = RoomSys:getCurrentRoom();
	if not room.heros or #room.heros == 0 then
		return pl("这里没有任何出色的人物...")
	end
	for k,v in paris(self.heros) do

	end
end

function actionSheshi()
	print("actionSheshi----------------------------")
	local room = RoomSys:getCurrentRoom();
	print(Val2Str(room))
	print(Val2Str(room.facilitys))
	if not room.facilitys then
		return pl("");
	end

	local msg = ""
	for k,v in pairs(room.facilitys) do
		msg = msg .. link(v.name, v.action) .. "\n";
	end
	pl(msg);
end

city.actionCity = {
	["府邸"] = "actionFuDi",
	["设施"] = "actionSheshi",
}
function city:queryAction()

	return city.actionCity;
end

return city