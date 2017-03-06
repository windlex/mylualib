if __global_file_flag__ then return end
__global_file_flag__ = 1

nothing = function() end

debug = {
	log = nothing,
}

pairs = pairs or function(t) return t end
strsub = strsub or string.sub
gsub = gsub or string.gsub
function Val2Str(value, ind)
	ind = ind or "";
	if type(value) == "table" then
		if strlen(ind) > 10 then return "..." end
		local str = '{\n';
		local tmp_ind = ind..'\t'
		for k,v in pairs(value) do
			str = str .. tmp_ind .. '['..Val2Str(k)..'] = ' .. Val2Str(v, tmp_ind) .. ',\n';
		end
		str = str .. ind .. '}';
		return str;
	elseif type(value) == 'function' then
		return '"#FUNCTION' .. strsub(tostring(value), 10) ..'"';
	elseif type(value) == 'string' then
		if strsub(value,1,1) == '@' then
			return strsub(value,2);
		else
			value = gsub(value, "\n", "\\n");
			value = gsub(value, "\t", "\\t");
			return '"'..value..'"';
		end
	elseif type(value) == 'boolean' then
		return '"'..tostring(value)..'"';
	else
		return tostring(value);
	end
end

require "class"
