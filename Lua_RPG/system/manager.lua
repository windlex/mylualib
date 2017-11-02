Manager = {
	inst = VM.Manager,

}

function Manager:AddDaemon(name)
	self.inst:AddScriptDaemon(name);
end

function Manager:SpawnPerfab(name)
	return perfab_d:spawnPerfab(name)
end
