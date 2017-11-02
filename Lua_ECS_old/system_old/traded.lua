TradeD = {}

TradeD.shops = {
	[1] = {
		["技能"] = {
			{"基础枪械", 100,}
		},
		["血统"] = {
			{"绿巨人血清", 200},
			{"美队血清",300},
			{"吸血鬼血统",50},
			{"巨龙之血",400}
		}, 
		["武器"] = {},
		["防具"] = {},
		["图纸"] = {
			{"钢铁侠图纸",999},
		},
		["杂物"] = {
			{"工作台",1}, 
		},
	}
}
function TradeD:load(shopId)
	return self.shops[shopId];
end

function TradeD:listGoods(shopId)
	local tShop = self:load(shopId)
	if not tShop then return notify_fail("木有这个商店") end
	local msg = "-----------------------------------------------\n"
	for shopType, shopGroup in pairs(tShop) do
		msg = msg .. "["..shopType.."]\n"
		for i = 1, #shopGroup  do
			local goods = shopGroup [i]
			local title = string.format("%s - %d", (goods.name or goods[1]), (goods.cost or goods[2]))
			local cmd = string.format("TradeD_onTrade(%d,'%s',%d)", shopId, shopType, i)
			msg = msg .. link(title, cmd) .. "\n";
		end
	end
	print( msg);
end

function TradeD_onTrade(shopId, shopType, goodsId)
	local tShop = TradeD:load(shopId);
	local shopGroup = tShop[shopType];
	local goods = shopGroup[goodsId];
	print(string.format("你假装用%d买了一个【%s】\n", goods[2], goods[1]))
end
print("TradeD Startup")