local area_d = daemon_base("区域精灵")
area_d.maps = {}

function area_d:loadArea(areaname)
	local map = self.maps[areaname];
	if map then
		return map;
	end
	map = require ("world."..areaname);
	map = gsub(map, "%[(.-)%]", function(id) 
		local s = string.format("<quad act=WORLD_D:onMap('%s') a=[%s] width=%d />", id, id, #id)
		--print(s);
		return s;
	end)
	self.maps[areaname] = map;
	return map;
end

return area_d;
