----State-------------------------------------------------------------
local State = ClassEx {}
-- name
-- events = { {event, fn}, ...}
-- timeline = { {time, fn}, ...}
function State:AddEvent(event, fnHandle)
	self.events[Event] = fnHandle
end

----StateGraph-------------------------------------------------------------
local StateGraph = ClassEx {}
-- .name
-- .events
-- .states
-- .defaultState

----StateGraphInst------------------------------------------------------------
local StateGraphInst = ClassEx({
}, function (self, owner, sg)
	self.sg = sg;
	self.currentState = nil;
	self.owner = owner;
	self.mem = {};
	self.stateMem = {};
	return sgi;
end)
function StateGraphInst:OnEvent(event, ...)
	local fn = self.currentState.events[event] or self.sg.events[event]
	if not fn then
		LogErr("[State:OnEvent] No Event Hander", self.name, event);
		return
	elseif type(fn) == "function" then
		fn(self, event, data)
	elseif type(fn) == "string" then
		self:GoToState(fn)
	end
end
function StateGraphInst:Update()
	local dt = 0
	if self.lastupdatetime then
		dt = GetTime() - self.lastupdatetime;
	end
	self.lastupdatetime = GetTime()

	self:UpdateState(dt)
end
function StateGraphInst:UpdateState(dt)
	self.time = self.time + dt;
	local curS = self.currentState;
	while true do
		local idx = self.timeIdx
		self.timeIdx = idx + 1;
		if curS.timeline[self.timeIdx][1] >= self.time then
			local fn = curS.timeline[idx][2]
			if type(fn) == 'function' then
				fn(self);
			elseif type(fn) == "string" then
				self:OnEvent(fn)
			end
		end
		if curS ~= self.currentState then
			return
		end
	end
end
function StateGraphInst:GoToState(sName)
	local state = self.sg.states[sName]
	if not state then
		LogErr("No State", sName)
		return
	end

	if self.currentState then
		self.currentState:OnEvent("Exit")
	end
	self.currentState = state;
	state:OnEvent("Enter")
end
----SGMgr-------------------------------------------------------------
SGMgr = {
	sgMap = {},
}
function SGMgr:State(s)
	local s = State:Make(s)
end
function SGMgr:StageGraph(name, states, events)
	local sg = StateGraph:Make {
		name = name,
		states = states,
		events = events,
	}
	self.sgMap[name] = sg;
	return sg;
end

function SGMgr:InstanceSG(owner, sgName)
	local sg = self.sgMap[sgName]
	local sgInst = StageGraphInst:New(owner, sg)
	return sgInst;
end

function SGMgr:Start(sgi)
	self.living:insert(sgi)
end
function SGMgr:Stop(sgi)
	self.living:remove(sgi)
	self.sleeping:remove(sgi)
end
function SGMgr:Sleep(sgi)
	self.living:remove(sgi)
	self.sleeping:insert(sgi);
end
function SGMgr:Update()
	for _, sgi in pairs(self.living) do
		sgi:Update();
	end
end

-----------------------------------------------------------------
