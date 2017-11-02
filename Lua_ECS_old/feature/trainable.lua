local trainable = class {
	BASE = {
		['精力'] = 0,
		['体力'] = 0,
	},
	MAXBASE = {

	},
	SOURCE = {},
	TALENT = {},
	ABL = {},
}

function trainable:add(group, attr, val)
	self[group][attr] = (self[group] [attr] or 0) + val;
end

function trainable:dec(group, attr, val)
	self[group][attr] = (self[group] [attr] or 0) - val; 
end 

function trainable:set(group, attr, val)
	self[group][attr] = val;
end

function trainable:get(group, attr)
	return self[group][attr];
end

return trainable;
