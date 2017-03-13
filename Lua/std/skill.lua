skill = class {
	lv = 0,
	maxlv = 100,
	exp = 0,
}

function skill:improve(nExp)
	self.exp = self.exp + nExp;
	if self.exp > self:levelupExp() then
		if (self:levelup()) then
			self.exp = self.exp - self:levelupExp();
		end
	end
end
function skill:levelup()
	if self.lv < self.maxlv then
		self.lv = self.lv + 1;
		return true;
	end
end
function skill:levelupExp()
	return self.lv * self.lv
end

function skill:queryAction()
	if not self.actions then return end
	local action = self.actions[random(#self.actions)];
	--print(Val2Str(action))
	return action;
end

return skill;