local skill_d = daemon_base("技能精灵")

skill_d.skills = {}

function skill_d:Init()
	daemon_base.Init(self);
	self:loadSkills(); 
end
function skill_d:UnInit()
end
function skill_d:FixedUpdate()
end
function skill_d:Update()
end

function skill_d:loadSkills()
	local skills = {}
	ff_GetTabFileTableEx("settings\\skills.csv", 2, {
		tonumber, 	-- ID, 
		nil, 		-- SkillName, 
		tonumber, 	-- SkillType
	}, function (tLine)
		skills[tLine.SkillName] = tLine;
	end, ",")
	self.skills = skills;
	ppt(self);
end
function skill_d:querySkill(skillname)
	--return self.skills[skillname];
	return require("skills.unarmed")
end
function skill_d:queryAction(actor)
	local skilllist = actor:GetComponent("skilllist")
	local curskill = skilllist.curSkill;
	local skill = SKILL_D:querySkill(skilllist.activeSkills[curskill]);
	curskill = curskill + 1;
	if curskill > #skilllist.activeSkills then
		curskill = 1;
	end
	skilllist.curSkill = curskill;
	return table.random(skill.actions)
end

return skill_d;
