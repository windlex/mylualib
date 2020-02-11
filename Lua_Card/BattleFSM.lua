local states = {
	SGMgr:State {
		name = "Waiting",
		events = {
			Action = "BeginTurn"
		},
		timeline = {},
	},
	SGMgr:State{
		name = 'BeginTurn';
		events = {
			Enter = BattleHander.fnBeginTurn,
			Exit = "Playing",
		},
		timeline = {
			{2, BattleHander.fnDrawCard},
			{5, BattleHander.fnUntap},
			{15, 'Exit'},
		}
	},
	SGMgr:State {
		name = 'Playing', 
		events = {
			EndTurn = 'Ending',
			PlayCard = BattleHander.fnPlayCard,
		},
		timeline = {
			{FPS*30, BattleHander.fnTimeout,},
		}
	},
	SGMgr:State {
		name = "Ending",
		events = {
			Exit = "Waiting";
		},
		timeline = {
			{5, "Exit"}
		},
	},
	SGMgr:State {
		name = "Effecting",
		events = {},
		timeline = {},
	},
}
local events = {

}
SG_Hander = SGMgr:StateGraph("Hander", states, events)
------------------------------------------------------------------------

local states = {
	SGMgr:State {
		name = 'StartRound',
		events = {
			Enter = fnStartRound,
		}
	},
	SGMgr:State {
		name = "Turning",
		events = {
			NextTurn = function(sgi)
				if sgi.owner:NextPlayer() then
					-- sgi:GoToState("Turning")
				else
					sgi:GoToState("EndRound")
				end
			end,
		}
	},
	SGMgr:State {
		name = "EndRound",
		events = {
			Enter = fnEndRound
		}
	}
}

SG_Round = SGMgr:StateGraph("Round", events)
------------------------------------------------------------------------
local states = {
	SGMgr:State {
		name = 'StartBattle',
		events = {
			Enter = fnStartBattle,
		}
	},
	SGMgr:State {
		name = "NextRound",
		events = {
			NextRound = function(sgi)
				if sgi.owner:NextRound() then
					sgi:GoToState("BeginRound")
				else
					sgi:GoToState("EndBattle")
				end
			end,
		}
	},
	SGMgr:State {
		name = "BeginRound",
		timeline = {
			{2, fnBeginRound},
			{10, "Turning"},	-- todo:
		},
		events = {
			
		}
	},
	SGMgr:State {
		name = "Turning",
		events = {
			EndTurn = function(self)
				if self.owner:NextTurn() then
					self:GoToState("Turning")
				else
					self:GoToState("EndRound")
				end
			end
		},
		timeline = {}
	},
	SGMgr:State {
		name = "EndRound",
		events = {},
		timeline = {
			{5, "NextRound"}
		}
	},
	SGMgr:State {
		name = "EndBattle",
		events = {
			Enter = fnEndBattle,
		}
	}
}

local events = {
	EndBattle = function(self)
		self:GoToState("EndBattle")
	end
}
SG_Battle = SGMgr:StateGraph("Battle", states, events)