skilllist = class {}

function skilllist:_ctor(actor)
	self.skills = {}
end

function skilllist:improve(skillname, nExp)
	local skill = self.skills[skillname];
	skill.exp = skill.exp + nExp;

	local lvupExp = self:levelupExp(skillname)
	if skill.exp > lvupExp then
		if (self:levelup(skillname)) then
			self.exp = self.exp - lvupExp;
		end
	end
end
function skilllist:levelup(skillname)
	local skill = self.skills[skillname];
	if skill.lv < skill.maxlv then
		skill.lv = skill.lv + 1;
		return true;
	end
end
function skilllist:levelupExp(skillname)
	local skill = self.skills[skillname];
	return skill.lv * skill.lv
end

function skilllist:queryAction(skillname)
	local skill = self.skills[skillname];
	if not skill.actions then return end
	local action = table.random(skill.actions];
	--print(Val2Str(action))
	return action;
end

