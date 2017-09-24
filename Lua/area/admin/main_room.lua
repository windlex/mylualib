require(STD_ROOM);

local this = room("主神空间")

function this:setup()
	self.desc = [[
    这里是无限空间的主神空间，光洁的地板看不出是什么材质，房间中间有一个光球，那就是传说中的奴隶主--主神！
]]
	self:addAction("修复", function (xx)
		print("你的身体假装恢复了！")
	end)
	self:addAction("兑换", function ()
		TradeD:listGoods(1)
	end)
	self:addAction("任务", function ()

	end)
	self.placement:addExit("home", "admin.home");
	self:AddComponent("room.library")
end

return this;
