Tag = {}

function Tag:_ctor()
	self._tag = {};
end
function Tag:addTag(tag)
	self._tag[tag] = 1;
end
function Tag:removeTag(tag)
	self._tag[tag] = nil;
end

function Tag:hasTag(tag)
	return self._tag[tag]
end
function Tag:getTag()
	return self._tag;
end
