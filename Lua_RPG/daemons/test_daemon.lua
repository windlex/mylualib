local daemon = {
	name = "test_Daemon",
	t=0,
}
function daemon:Init()
	print("test_Daemon Init ")
	local a = PERFAB_D:spawnPerfab("std_npc");
	print(Val2Str(a))
	local b = PERFAB_D:spawnPerfab("std_npc");
	COMBAT_D:MakeEnemy(a, b);
end
function daemon:UnInit()
	print("test_Daemon UnInit  ")
end
function daemon:FixedUpdate()
	self.t = self.t + 1
	--if self.t > 1 then
		--print("test_Daemon FixedUpdate  ")
		self.t = 0;
	--end
end
function daemon:Update()
	print("test_Daemon Update  ")
end

return daemon