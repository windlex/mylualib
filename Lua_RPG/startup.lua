
STD_ROOM = "std.room"

require "base.table"
require "base.callback"
require "VMInit"

require "base.global"
require "base.class"
require "base.component"
require "base.tag"

require "object.daemon_base"

require "config"
require "system.manager"

if SIM then
	print(SIM)
	OnStart()

	for i=1,10 do
		_Manager:FixedUpdate()
	end
end