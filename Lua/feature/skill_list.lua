local skill_list = class {
	_ctor = function(self, actor)
		self.actor = actor;
	end,
}
function skill_list:queryAction(use_skill)
	local skill = SkillD:getSkill(use_skill);
	if not skill then return "no action!!!" end
	return skill:queryAction();
end
return skill_list;
