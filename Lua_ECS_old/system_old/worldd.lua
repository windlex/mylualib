WorldD = {
	areas = {}
}

function WorldD:loadArea(areapath)
	local area = require("Lua.area."..areapath);
	self.areas[area.name] = area;
	area:setup();
	area.path = areapath;
	return area;
end

