debug = callback(print, "debug")
warning = callback(print, "warning")
error = callback(print, "error")

_Manager = {
	daemons = {}
}

function _Manager:AddScriptDaemon(d)
	table.insert(self.daemons, d); 

	CallDaemonInit(d)	
end
function _Manager:FixedUpdate( )
	for _, d in pairs(self.daemons) do
		CallDaemonFixedUpdate(d)
	end
end
function _Manager:CreateEntity()
	return {uuid=1234}
end

CS.Manager = {}
CS.Manager.Instance = _Manager
print("SIM Loaded!!!")