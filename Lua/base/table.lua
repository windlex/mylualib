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
