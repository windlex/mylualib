table = table or {}

function table.merge(...)
	local t, arg = {}, table.pack(...)
	for i = 1, #arg do
		for k,v in pairs(arg[i]) do
			t[k] = v;
		end
	end
	return t;
end
function table.combine(...)
	local t, arg = {}, table.pack(...)
	for i = 1, #arg do
		for k, v in ipairs(arg[i]) do
			table.insert(t, v);
		end
	end
	return t;
end
function table.copy(tb)
	local tt = {}
	for k,v in pairs(tb) do
		tt[k] = v;
	end
	return tt;
end
