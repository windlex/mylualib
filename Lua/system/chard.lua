CharD = {
	path2char = {},
}

function CharD:loadChar(path)
	local char = self.path2char[path];
	if not char then
		char = require ("Lua.char."..path);
		char:setup();
		self.path2char[path] = char;
	end
	return char;
end
