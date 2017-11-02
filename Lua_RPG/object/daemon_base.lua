daemon_base = class ({
	_ctor = function(name)
		self.name = name;
	end,
})

function daemon_base:Init()
	print(self.name.."启动成功!")
end
function daemon_base:UnInit()
end
function daemon_base:FixedUpdate()
end

return daemon_base;
