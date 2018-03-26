Console = require("ui.console")

UIRoleState = class({
	TABMAX = 3,
});

local Role = {
	{
		name = "sss1",
		len=4,
		TALENT = {},
	},
	{
		name = "つかう",
		len=6,
		TALENT = {},
	},
	{
		name = "事前に算出",
		len=10,
		TALENT = {},
	},
}
function UIRoleState:PaintHead(MODE)
	-------キャラタブ（３行）---
	--ボタン割り当て1-9
	--前準備
	local NAMESTRSUM = {}
	for i = 1, 3 do
		if Role[i] then
			--タブのラベル部分に表示する内容の長さを事前に算出（名前+括弧+ボタン）
			NAMESTRSUM[i] = string.utfstrlen(Role[i].name)
			--タブの表示には全角文字をつかうので文字数を偶数にしておく
			if NAMESTRSUM[i] % 2 == 1 then
				NAMESTRSUM[i] = NAMESTRSUM[i] + 1
			end
		end
	end
	
	--タブ上部
	Console:Printform "　"
	Console:Printform "┌"
	for i = 1, 3 do
		if Role[i] then
			Console:Printform(string.rep("─",Role[i].len / 2+4))
			if i < MODE then
				Console:Printform "┌"
			else
				Console:Printform "┐"
			end
		end
	end
	Console:PrintL()
	
	--タブ中部
	Console:Printform "　"
	Console:Printform "│"
	for i = 1, 3 do
		if Role[i] then
			Console:SetColor( i == MODE and 0xFFFF70 or 0x00FF00 )
			Console:PrintButton(string.format("[ %s]【%s】", i, Role[i].name), i);
			Console:ResetColor()
			Console:Printform "│"
		end
	end
	Console:PrintL()
	
	--タブ下部
	Console:Printform "─"
	Console:Printform (MODE == 1 and "┘" or "┴")
	for i = 1, 3 do
		if Role[i] then
			Console:Printform( string.rep((i == MODE and "　" or "─"), Role[i].len / 2+4) )
			if i == MODE then
				Console:Printform "└"
			elseif i + 1 == MODE then
				Console:Printform "┘"
			else
				Console:Printform "┴"
			end
		else
			Console:Print "─"
		end
	end
	local LOCAL = 0
	for i = 1, 3 do
		LOCAL = LOCAL + (NAMESTRSUM[i] or 0)
	end
	Console:Printform(string.rep("─",(90 - LOCAL) / 2))
	Console:PrintL()
end

function UIRoleState:SHOW_SIMPLE_STATUS(role)
	Console:PrintL("SHOW_SIMPLE_STATUS:"..(role and role.name or "nil"))
end
function UIRoleState:SHOW_EQUIP_LIST(role)
	Console:PrintL("SHOW_EQUIP_LIST:"..(role and role.name or "nil"))
end
function UIRoleState:CHECK_STATUS_TAB3(role)
	Console:PrintL("<color=blue>CHECK_STATUS_TAB3</color>:"..(role and role.name or "nil"))
end
function UIRoleState:SHOW_TALENT_LIST(role)
	Console:SetColor("red")
	Console:PrintL("SHOW_TALENT_LIST:"..(role and role.name or "nil"))
	Console:ResetColor()
end
function UIRoleState:SHOW_MARK_LIST(role)
	Console:PrintL("SHOW_MARK_LIST:"..(role and role.name or "nil"))
end

function UIRoleState:Paint(ARG_1)
	--print("UIRoleState:Paint")
	local LINEDEL = 0
	for kk = 1,1 do
		-------前表示消去-----
		--追加素質（淫乱など）で47行以上になった場合表示がずれる
		if LINEDEL > 0 then
			Console:ClearLine(47)
			LINEDEL = 0
		end
		MODE = MODE or 1

		Console:DrawLine("=")
		self:PaintHead(MODE)

		-------選択キャラステータス------
		
		-----メイン---
		self: SHOW_SIMPLE_STATUS(Role[MODE])

		-----装備---
		Console:DrawLine(".")
		self: SHOW_EQUIP_LIST(Role[MODE])

		-----タブ（３行）---
		--ボタン割り当て10-19
		
		--タブ上部
		TABMAX = self.TABMAX
		TABN = self.TABN or 1
		Console:Printform "　"
		Console:Printform "┌"
		for i = 1, TABMAX do
			Console:Printform "──────"
			if i < TABN then
				Console:Printform "┌"
			else
				Console:Printform "┐"
			end
		end
		Console:PrintL()
		
		
		--タブ中部
		Console:Printform "　"
		Console:Printform "│"
		for i = 1, TABMAX do
			Console:SetColor( i == TABN and 0xFFFF70 or 0x00FF00)
			if i == 1 then
				Console:PrintButton ("[10]全　般  ",10)
			elseif i == 2 then
				Console:PrintButton ("[11]素　質  ",11)
			elseif i == 3 then
				Console:PrintButton ("[12]刻　印  ",12)
			else
				Console:PrintButton (string.format("[%d]未定義  ", (10 + i), 10 + i))
			end
			Console:ResetColor()
			Console:Printform "│"
		end
		Console:PrintL()
		
		
		--タブ下部
		Console:Printform "─"
		Console:Printform (TABN == 1 and '┘' or "┴")
		for i = 1, TABMAX do
			Console:Printform (i == TABN and "　　　　　　" or "──────")
			if i == TABN then
				Console:Printform "└"
			elseif i + 1 == TABN then
				Console:Printform "┘"
			else
				Console:Printform "┴"
			end
			
		end
		
		for i = 1, 4 - TABMAX do
			Console:Printform "───────"
		end
		Console:PrintL "──────"
		
		
		--＝＝＝＝＝タブの内容表示ここから＝＝＝＝＝
		local LINECOUNTBAK = LINECOUNT
		if TABN == 1 then
			--全般
			--CALL CHECK_STATUS_TAB1(Role[MODE])
			self: CHECK_STATUS_TAB3(Role[MODE])
		elseif TABN == 2 then
			--素質
			self: SHOW_TALENT_LIST(Role[MODE])

		elseif TABN == 3 then
			--刻印
			self: SHOW_MARK_LIST(Role[MODE])
		end
		
		-----余白自動調整---
		--for i = 1, 30 - (LINECOUNT - LINECOUNTBAK) do
		--	Console:PrintL()
		--end
		--＝＝＝＝＝タブの内容表示ここまで＝＝＝＝＝
		
		-----その他のコマンド---
		Console:PrintButton( "[ 0]返回　",0)
		if ARG_1 == 1 then
			Console:PrintButton( "[20]変更愛称　", 20)
			--変幻自在持ち
			if Role[MODE].TALENT[139] then
				Console:PrintButton( "[21]変更能力　", 21)
			end
		end
		Console:PrintL()
		Console:DrawLine("=")
		Console:DrawLine("─")

		--ppt(Console)
		Console:Flush();
		Console:WaitInput(self.OnInput);
		-----案内---
		--REUSELASTLINE %CALLNAME:(Role[MODE])%的状態
		--REDRAW 1
		--＝＝＝入力処理ここから＝＝＝
		--INPUT
	end
	--≡≡≡≡≡ループここまで≡≡≡≡≡
end
function UIRoleState.OnInput(INPUT)
	self = UIRoleState;
	if INPUT == 0 then
		return;
	elseif INPUT >= 1 and INPUT <= 3 and Role[(INPUT)]  then
		MODE = INPUT
		LINEDEL = 1
	elseif INPUT >= 10 and INPUT <= (9 + self.TABMAX) then
		self.TABN = INPUT - 9
		LINEDEL = 1
	elseif INPUT == 20 and ARG_1 == 1 then
		--愛称変更
		self:CHECK_STATUS_CHANGE_CALLNAME(Role[MODE])
	elseif INPUT == 21 and ARG_1 == 1 and Role[MODE].TALENT[139] then
		--能力変更
		self: CHANGE_PERSONAL_STATUS(Role[MODE])
	else
		LINEDEL = 1
	end
	self:Paint(MODE)
end
return UIRoleState;
