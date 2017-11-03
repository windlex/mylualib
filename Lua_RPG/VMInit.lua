_print = print

if not CS then
	SIM = true
	CS = {}
	CS.Logic = {}
	CS.Logic.Instance = {}
	CS.Logic.Instance.AddText = print
	Debug=print
	CS.Debug = {}
	CS.Debug.LogError = print
	CS.CreativeSpore = {RpgMapEditor={AutoTileMap={}}}
	CS.GameMgr= {Instance={}}
	require "SIM"
end

if SIM_DEBUG then return end

VM = {
	Logic = CS.Logic.Instance,
	waiting = false,
	TileMap = CS.CreativeSpore.RpgMapEditor.AutoTileMap.Instance,
	RpgMapHelper = CS.CreativeSpore.RpgMapEditor.RpgMapHelper,
	PlayerInst = CS.GameMgr.Instance.Player;
	Manager = CS.Manager.Instance;
}

function VM.pl(...)
	local arg = table.pack(...)
	local str = "";
	for k,v in ipairs(arg) do
		str = str .. tostring(v) .. "\t" ;
	end
	VM.Logic:AddText(str);
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
	if type(f) == 'function' then
		VM.co = coroutine.wrap(f)
		VM.co(...);
	end
end

function OnClick()
	if VM.waiting then
		VM.co();
	end
end

function VM.cls()
	VM.Logic:ClearText()
end

function link(name, cmd)
	--print(name, cmd)
	return format("<quad act=%s a=[%s] width=%d />", cmd, name, #name);
end
function OnUpdate()
	--SystemMgr:update();
end
function OnStart()
	--SystemMgr:start();
	Manager:AddDaemon("test_daemon")
	Manager:AddDaemon("combat_d")
end
function OnCommand(cmdtype, cmdparam)
	local cmd = player:GetComponent("command");
	CmdSys:addCommand(cmd,cmdtype,cmdparam)
end
function CallDaemonInit(daemonName)
	local daemon = require("daemons."..daemonName)
	daemon:Init();
end
function CallDaemonUnInit(daemonName)
	local daemon = require("daemons." .. daemonName)
	daemon:UnInit();
end
function CallDaemonFixedUpdate(daemonName)
	local daemon = require("daemons." .. daemonName)
	daemon:FixedUpdate ();
end
function CallDaemonUpdate(daemonName)
	local daemon = require("daemons."..daemonName)
	daemon:Update();
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
notify_fail = print
logError = CS.Debug.LogError
warn = CS.Debug.LogWarn
PlayerInst = VM.PlayerInst

if SIM then
	pl = _print
	print = _print
end
