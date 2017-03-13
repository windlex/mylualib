require "Lua.std.skill"

SkillD = {
	skills = {},
}

function SkillD:getSkill(skillName)
	if not self.skills[skillName] then
		self:loadSkill(skillName)
	end
	local skill = self.skills[skillName];
	if not skill then
		error(format("[SkillD] No Skill Named %s", skillName));
		return
	end
	return skill;
end

function SkillD:loadSkill(skillName)
	local skill = require(SKILL_DIR.."."..skillName);
	self.skills[skillName] = skill;
end

