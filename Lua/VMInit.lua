VM = {
	Logic = CS.Logic.Instance,
	waiting = false,
}
function VM.pl(...)
	local arg = table.pack(...)
	local str = "";
	for k,v in ipairs(arg) do
		str = str .. v;
	end
	VM.Logic:AddText(str.."\n");
end
function VM.cmd(str, cb, ...)
	if type(cb) == 'string' then
		VM.Logic:AddCommand(str, cb)
	elseif type(cb) == 'function' then
		VM.Logic:AddCommand(str, callout(VM.start, cb, ...))
	--elseif type(cb) == 'table' then
	--	VM.Logic:AddCommand(str, callout(VM.start, 
	else
		print("[Error Cmd]", str, cb);
	end
end

function VM.wait()
	self = VM;
	self.waiting = true;
	coroutine.yield();
	self.waiting = false;
end

function VM.start(f, ...)
	VM.co = coroutine.wrap(f)
	VM.co(...);
end

function OnClick()
	if VM.waiting then
		VM.co();
	end
end

function VM.cls()
	VM.Logic:ClearText()
end

-------------------------------------------------------
pl = VM.pl
cmd = VM.cmd
start = VM.start
cls = VM.cls
wait = VM.wait
print = VM.pl
format = string.format
random = math.random
