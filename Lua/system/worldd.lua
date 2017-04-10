WorldD = {
	areas = {}
}

function WorldD:loadArea(areapath)
	local area = require("Lua.area."..areapath);
	area:setup();
	area.path = areapath;
	self.areas[area.name] = area;
	return area;
end

