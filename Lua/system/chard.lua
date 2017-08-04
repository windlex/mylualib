CharD = {
	path2char = {},
}

function CharD:loadChar(path)
	print("CharD:loadChar", path)
	local char = self.path2char[path];
	if not char then
		char = require ("Lua.char."..path);
		self.path2char[path] = char;
		char:setup();
	end
	return char;
end
