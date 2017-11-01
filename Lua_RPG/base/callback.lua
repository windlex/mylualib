function callback(fn, ...)
	local arg = table.pack(...);
	return function(...)
		fn(table.unpack(table.combine(arg, table.pack(...))));
	end
end

fn = callback(print, 1,2,3)
fn(4,5,6)