require "Lua.std.actor"

Char = class(Actor, {
	name = "Char",
	desc = "this is a Char",
	_ctor = function (self, name)
		print("Create Char1", name)
		self.name = name;
		Actor._ctor(self);
		print("Create Char2", name)
		self.dbase = self:AddComponent("dbase");
		self.skill_list = self:AddComponent("skill_list");
		self.action = self:AddComponent("action");
		print("Create Char21", name)
		self:AddComponent("moveable");
		print("Create Char22", name)
		self:AddComponent("interactive")
		print("Create Char3", name)
		self:AddComponent("trainable")
		print("Create Char4", name)
	end,
})

function Char:dead()
	if self.dbase.hp <= 0 then return 1 end
end

function Char:look()
	return self:lookRoom()
end

function Char:lookRoom()
	local room = self:getCurrentRoom();
	local msg = room:onLook(self)
	print(msg);
end

function Char:link()
	return link(self.name, format("Char_onTalk(%d)", self.id))
end

function Char:onTalk()
	print("基本对话");
end
function Char_onTalk(id)
	local char = ActorMgr:Get(id)
	char:onTalk();
end

function Char:setHouse(roompath)
	local room = RoomD:loadRoom(roompath);
	local house = room:getFacility("house");
	--house:addHouse(self);
end