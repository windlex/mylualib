package.dir = "Lua_RPG"

print("Loading Lua_RPG")
if not package._path then
	package._path = package.path
	package.path = string.format("%s/?.lua;ui/?.lua;", package.dir) .. package.path; 
	print(package.path)
end

require(string.format("%s.startup", package.dir));

