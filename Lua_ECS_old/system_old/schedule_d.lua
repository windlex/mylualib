-----------------------------------------------------------------
-- 简单调度系统
-- todo: 长时间任务调度 coroutine支持
-----------------------------------------------------------------
Schedule = {
	_taskId = 1,
	_tasks = {},
	currentTick = 0,
}

function Schedule:AddTask(time, callback)
	self._tasks[self._taskId] = {time, callback};
	self._taskId = self._taskId + 1;
end

function Schedule:RemoveTask(taskId)
	self._tasks[taskId] = nil;
end

function Schedule:Breathe()
	self.currentTick = self.currentTick + 1;	-- todo: 调用优化
	for k, task in pairs(self._tasks) do
		if task[1] <= self.currentTick then
			local ret = task[2]();
			if not ret or ret <= 0 then
				self:RemoveTask(k);
			else
				task[1] = task[1] + ret;
			end
		end
	end
end
