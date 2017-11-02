Manager = {
	inst = VM.Manager,

}

function Manager:AddDaemon(name)
	self.inst:AddScriptDaemon(name);
end
