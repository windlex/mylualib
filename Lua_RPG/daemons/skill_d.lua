local skill_d = daemon_base("技能精灵")

skill_d.skills = {}

function skill_d:Init()
end
function skill_d:UnInit()
end
function skill_d:FixedUpdate()
end
function skill_d:Update()
end

function skill_d:loadSkill(skillname)
	local skill = self.skills[skillname];
	if not skill then
		skill = require("skills." .. skillname)
		if not skill then
			return error("Load Skill Error!"..skillname);
		end
		self.skills[skillname] = skill;
	end
	return skill;
end

return skill_d