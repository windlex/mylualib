function callback(fn, ...)
	local arg = table.pack(...);
	return function(...)
		fn(table.unpack(arg), ...);
	end
end

fn = callback(print, 1,2,3)
fn(4,5,6)