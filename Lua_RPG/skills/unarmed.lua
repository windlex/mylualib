--unarmed
local skill = skill({
	id = "unarmed",
	name = "基本拳脚",
})

skill.actions = {
	{      
		["actionmsg"] =		"#A纵身跃起，一招#HIR#「庐山爆裂拳」#NOR#，双拳化作万重幻影击向#B的#l",
		["dodge"] =                -40,
		["parry"] =                -40,
		["force"] =                180,
		["damage_type"] =          "瘀伤",
		["weapon" ] =              "双掌",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
	{
		["actionmsg"] =		"#A似退反进，突然欺身向前，左收右进，一招#HIW#「庐山龙探睛」#NOR#，对准#B的#l一把刺了过去",
		["dodge"] =                -60,
		["parry"] =                -40,
		["force"] =                250,
		["damage_type"] =          "插伤",
		["weapon"] =               "右手食指",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
	{
		["actionmsg"] =		"只见#A一旋身，双拳舞动如风攻向#B。这一招#HIB#「庐山龙卷风」#NOR#当真是防不胜防",
		["dodge"] =                -50,
		["parry"] =                -40,
		["force"] =                250,
		["damage_type"] =          "内伤",
		["weapon"] =               "双拳",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
	{
		["actionmsg"] =		"#A催动小宇宙，一招#HIY#「庐山逆水流」#NOR#，啸声中和身而上，向#B直撞而来",
		["dodge"] =                -60,
		["parry"] =                -40,
		["force"] =                200,
		["damage_type"] =          "撞伤",
		["weapon"] =               "全身",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
	{
		["actionmsg"] =		"只见#A一个筋斗翻在半空，一招#HIC#「庐山击水流」#NOR#将发未发，但是全身劲气疾卷#B",
		["dodge"] =                -40,
		["parry"] =                -20,
		["force"] =                250,
		["damage_type"] =          "内伤",
		["weapon"] =               "劲气",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
	{ 
		["actionmsg"] =		"#A身形一变，冲到#B面前就是一拳。这招#HIG#「庐山百啸拳」#NOR#势若奔雷，气势如虹",
		["dodge"] =                -10,
		["parry"] =                -50,
		["force"] =                180,
		["damage_type"] =          "重伤",
		["weapon"] =               "拳头",
		["parry_msg"] =    "只听见「锵」一声，被#A劈手格开",
	},
};

return skill;
