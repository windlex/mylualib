local this = class ();

function this:_ctor(room)
	if room.isRoom ~= true then return end
	self.room = room;
end 

function this:queryAction()
	return {
		["研究"] = function()
			print("你假装在研究。。。");
		end,
	}
end

return this;
