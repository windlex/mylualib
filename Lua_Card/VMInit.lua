_print = print
--print("Text",CS.Text.Encoding.UTF8)
--print("Text",CS.Text.Encoding.GetEncoding("GBK"))
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
	Convert = CS.MyUtils.Convert
}
print(VM)
function VM.strcolor(str)
	return str:gsub("#HIR#", "<color=red>")
		:gsub("#HIC#", "<color=pink>")
		:gsub("#HIG#", "<color=green>")
		:gsub("#HIB#", "<color=blue>")
		:gsub("#HIW#", "<color=yellow>")
		:gsub("#HIY#", "<color=yellow>")
		:gsub("#NOR#", "</color>")
end
-- VM.Logic:AddTextEx("textInfo", "textInfo");
-- VM.Logic:AddTextEx("textInv", "textInv");
-- VM.Logic:AddTextEx("textStatus", "textStatus");
-- VM.Logic:AddTextEx("textLog", "textLog");
-- VM.Logic:AddTextEx("textMap", "textMap");


-- VM.Logic:ClearEx("textInfo");
-- VM.Logic:ClearEx("textInv");
-- VM.Logic:ClearEx("textStatus");
-- VM.Logic:ClearEx("textLog");
-- VM.Logic:ClearEx("textMap");


function VM.pl(...)
	local arg = table.pack(...)
	local str = "";
	for k,v in ipairs(arg) do
		str = str .. tostring(v) .. "\t" ;
	end
	str = VM.strcolor(str)
	VM.Logic:AddText(str);
end
function VM.Clear()
	VM.Logic:Clear()
end 
function VM.cmd(str, cb, ...)
	if type(cb) == 'string' then
		VM.Logic:AddCommand(str, cb)
	elseif type(cb) == 'function' then
		VM.Logic:AddCommand(str, callback(VM.start, cb, ...))
	--elseif type(cb) == 'table' then
	--	VM.Logic:AddCommand(str, callback(VM.start, 
	else
		print("[Error Cmd]", str, cb);
	end
end
function VM.select(str, cb, ...)
	if type(cb) == 'string' then
		VM.Logic:AddSelect(str, cb)
	elseif type(cb) == 'function' then
		VM.Logic:AddSelect(str, callback(VM.start, cb, ...))
	--elseif type(cb) == 'table' then
	--	VM.Logic:AddSelect(str, callback(VM.start, 
	else
		print("[Error select]", str, cb);
	end
end
function VM.plEx(pad, ...)
	local arg = table.pack(...)
	local str = "";
	for k, v in ipairs(arg) do
		str = str .. tostring(v) .. "\t";
	end
	str = VM.strcolor(str)
	VM.Logic:AddTextEx(pad, str);
end 
function VM.ClearEx(pad)
	VM.Logic:ClearEx(pad)
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
function slink(name, cmd)
	--print(name, cmd)
	return format("<quad act=%s a=%s width=%d />", cmd, name, #name);
end
function OnUpdate()
	--SystemMgr:update();
end
function OnStart()
	print("OnStar111t");
	--Manager:OnStart();
	--STORY_D:playStory("第一章_乱世废帝（介绍）")
	--STORY_D:playStory("新手村_出生")
	--cmd("aaa",'print("bbb")')
	--select("aaa",'print("bbb")')
end
function OnCommand(cmdtype, cmdparam)
	local cmd = player:GetComponent("command");
	CmdSys:addCommand(cmd,cmdtype,cmdparam)
end
function CallDaemonInit(daemonName)
--	print("CallDaemonInit", daemonName);
	local daemon = require("daemons."..daemonName)
	daemon:Init();
end
function CallDaemonUnInit(daemonName)
--print("CallDaemonInit", daemonName);
	local daemon = require("daemons." .. daemonName)
	daemon:UnInit();
end
function CallDaemonFixedUpdate(daemonName)
--print("CallDaemonFixedUpdate ", daemonName);
	local daemon = require("daemons." .. daemonName)
	daemon:FixedUpdate ();
end
function CallDaemonUpdate(daemonName)
	local daemon = require("daemons."..daemonName)
	daemon:Update();
end
 
-------------------------------------------------------
function openfile(file, ...)
	if WIN then
		file = gsub(file, "/", "\\");
	else --if IOS then
		file = gsub(file, "\\", "/");
	end
	return io.open(file, ...);
end
close = io.close
read = io.read
tinsert = table.insert

pl = VM.pl
cmd = VM.cmd
select = VM.select;
start = VM.start
cls = VM.cls
wait = VM.wait
-- print = VM.pl
format = string.format
random = math.random
notify_fail = print
log = CS.Debug.Log
logError = CS.Debug.LogError
warn = CS.Debug.LogWarn
PlayerInst = VM.PlayerInst
gbk2utf8 = callback(VM.Convert, "GBK")
printEx = print--VM.plEx
clearEx = cls--VM.ClearEx
print(log)
if SIM then
	pl = _print
	print = _print
end
print(VM)

