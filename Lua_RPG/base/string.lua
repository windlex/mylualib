
gsub = string.gsub
function string.split(str, splitor)
	local tStr = {}
	splitor = splitor or "|";
	
	local fmt = string.format("([^%s]+)", splitor)
	gsub(str, fmt, function (s)
		table.insert( tStr, s)
	end)
	return tStr;
end
