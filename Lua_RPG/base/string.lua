
gsub = string.gsub
string._rep = string.rep;
function string.rep( s, n, rep )
	return string._rep(s, math.floor(n), rep)
end
function string.split(str, splitor)
	local tStr = {}
	splitor = splitor or "|";
	
	local fmt = string.format("([^%s]+)", splitor)
	gsub(str, fmt, function (s)
		table.insert( tStr, s)
	end)
	return tStr;
end

function string.utfstrlen(str)
	local len = #str;
	local left = len;
	local cnt = 0;
	local arr={0,0xc0,0xe0,0xf0,0xf8,0xfc};
	while left ~= 0 do
		local tmp=string.byte(str,-left);
		local i=#arr;
		while arr[i] do
			if tmp>=arr[i] then 
				left=left-i;
				break;
			end
			i=i-1;
		end
		cnt=cnt+1;
	end
	return cnt;
end