function callback(fn, ...)
	local _arg = pack(...);
	return function(...)
		fn(unpack(table.combine(_arg, pack(...))));
	end
end

fn = callback(print, 1,2,3)
fn(4,5,6)