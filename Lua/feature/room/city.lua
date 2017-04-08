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
	local room = RoomD:getCurrentRoom();
	if not room.heros or #room.heros == 0 then
		return pl("这里没有任何出色的人物...")
	end
	for k,v in paris(self.heros) do

	end
end

function actionSheshi()
	print("actionSheshi----------------------------")
	local room = RoomD:getCurrentRoom();
	print(Val2Str(room))
	if not room.facilitys or #room.facilitys == 0 then
		return pl("");
	end
	print(Val2Str(room.facilitys))

	local msg = ""
	for k,v in pairs(self.facilitys) do
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