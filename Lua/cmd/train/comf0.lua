-- 会话

local cmd = {}

function cmd:perform(me, target, assister)
--@COM300
--会話

	--会話累積値が閾値を超えると失敗
	if target:get(TCVAR, 302) and not target:get(TALENT, '恋慕') then
		print "虽然想向"..target.name.."搭话可是不知道该说些什么"
		print "四周弥漫着尴尬的气氛…"
		TIME = TIME + 10
		if CHK_DATENOW(target:get(CFLAG, '约会中') then
			target:add(LOSEBASE, '気力', 50)
			me:add(LOSE, '気力', 50)
			target:set(TFLAG, 193, 1)
			CALL DATE_GOES_ON(1)
		else
			target:add(LOSEBASE, '気力', 100)
			me:add(DOWNBASE, '気力', 100)
			target:set(TFLAG, 193, -1);
		end
		return 1
	end
	if target:get(MARK, '反発刻印') >= 3 then
		print (target.name.."似乎不想理睬"..me.name.."的样子")
		target:set(SOURCE, '反感', 300)
		me:dec(BASE, '気力', 100)
		return -1
	end
	LOCAL = math.random(100)
	LOCAL1 = 90 + GET_SUCCESS_RATE() / 5
	if LOCAL1 > 99 then
		LOCAL1 = 99
	end

	--相手が烂醉中だと大成功にも失敗にもならない
	if target:get(TCVAR, '烂醉') then
		LOCAL = 50
	end
	if LOCAL <= 9 then
		--10％で大成功
		target:set(TFLAG, 193, 1)
		target:set(TFLAG, 98, 2)
		me.add(EXP, '会話経験', 1)
		if CHK_DATENOW(target:get(CFLAG, '约会中')
			target:add(EXP, '约会経験', 1);
			me:add(EXP, '约会経験', 1)
		end
	elseif LOCAL >= LOCAL1 then
		--10～1％で失敗
		target:set(TFLAG, 193, -1);
		target:set(TFLAG, 98, -1);
	else
		--残りは成功
		target:set(TFLAG, 19, 0)
		target:set(TFLAG, 98, 0)
	end
	--先制発生時は失敗しない
	if target:get(TCVAR, 20) > 0 then
		target:set(TFLAG,193, MAX(target:get(TFLAG,193),0))
	if target:get(CFLAG, '陪睡中') then
		target:add(DOWNBASE, '気力', 10)
		target:set(SOURCE, '情愛', 200)
	else
		DOWNBASE:気力 += 20
		DOWNBASE:MASTER:気力 += 20
	end

	if ABL:教養 > ABL:MASTER:教養 + 3
		TFLAG:193 = -2

	--固定で獲得するソース
	SOURCE:歓楽 = 200

	--ABL:親密をみる
	if ABL:親密 <= 1
		SOURCE:歓楽 += (ABL:親密 * 40)
	ELSEIF ABL:親密 <= 3
		SOURCE:歓楽 += 200 + (ABL:親密 * 40)
	ELSEIF ABL:親密 <= 5
		SOURCE:歓楽 += 500 + (ABL:親密 * 40)
	ELSEIF ABL:親密 <= 8
		SOURCE:歓楽 += 750 + (ABL:親密 * 60)
	ELSEIF ABL:親密 <= 10
		SOURCE:歓楽 += 1000 + (ABL:親密 * 60)
	else
		SOURCE:歓楽 += 1600 + (ABL:親密 * 30)
	end

	--好感度をみる
	--if CFLAG:2 <= 1000
	--	SOURCE:歓楽 += CFLAG:2
	--ELSEIF CFLAG:2 <= 5000
	--	SOURCE:歓楽 += 500 + (CFLAG:2 - 500) / 3
	--else
	--	SOURCE:歓楽 += 2000 + (CFLAG:2 - 5000) / 5
	--end

	SOURCE:歓楽 = LIMIT(SOURCE:歓楽,0,5000)


	SOURCE:受動 = 100 + 100 * ABL:従順
	SOURCE:征服 = 100 + 100 * ABL:施虐属性

	if TFLAG:193 == -1 || TFLAG:193 == -2
		TIMES SOURCE:歓楽 , 0.10
		TIMES SOURCE:征服 , 0.50
		TIMES SOURCE:受動 , 0.50
	ELSEIF TFLAG:193 == 0
		TIMES SOURCE:歓楽 , 1.00
		TIMES SOURCE:征服 , 1.00
		TIMES SOURCE:受動 , 1.00
	else
		TIMES SOURCE:歓楽 , 2.00
		TIMES SOURCE:征服 , 2.00
		TIMES SOURCE:受動 , 2.00
	end
	SELECTCASE ABL:MASTER:話術技能
		CASE 0
			TIMES SOURCE:歓楽 , 0.20
			TIMES SOURCE:征服 , 0.20
			TIMES SOURCE:受動 , 0.20
		CASE 1
			TIMES SOURCE:歓楽 , 0.40
			TIMES SOURCE:征服 , 0.40
			TIMES SOURCE:受動 , 0.40
		CASE 2
			TIMES SOURCE:歓楽 , 0.70
			TIMES SOURCE:征服 , 0.70
			TIMES SOURCE:受動 , 0.70
		CASE 3
			TIMES SOURCE:歓楽 , 1.00
			TIMES SOURCE:征服 , 1.00
			TIMES SOURCE:受動 , 1.00
		CASE 4
			TIMES SOURCE:歓楽 , 1.20
			TIMES SOURCE:征服 , 1.20
			TIMES SOURCE:受動 , 1.20
		CASEELSE
			TIMES SOURCE:歓楽 , 1.50
			TIMES SOURCE:征服 , 1.50
			TIMES SOURCE:受動 , 1.50
	ENDSELECT

	--会話累積値
	if CHK_DATENOW(CFLAG:TARGET:约会中)
		TCVAR:301 += 100 / (2 + ABL:MASTER:話術技能)
	else
		TCVAR:301 += 200 / (2 + ABL:MASTER:話術技能)
	end

	TIME += 10
	--if TARGET == 110
	--	print 因为用筆談所以花了不少时间…
	--	TIME += 15
	--end
	EXP:MASTER:会話経験 ++
	if CHK_DATENOW(CFLAG:TARGET:约会中)
		EXP:MASTER:约会経験 ++
		EXP:TARGET:约会経験 ++
		CALL DATE_GOES_ON(1)
	end

	--相手が烂醉中だと効果大幅低減
	if TCVAR:烂醉
		TIMES SOURCE:歓楽 , 0.10
		TIMES SOURCE:征服 , 0.10
		TIMES SOURCE:受動 , 0.10
	end
	return 1
end
---------------------------------------------------
--実行判定
---------------------------------------------------
function cmd:check(me, target, assister)
--@COM_ABLE300
	--会話実行判定
	if target:get(TFLAG, 100) == 0 then
		return 0
	end
	--一括管理
	if GLOBAL_COMABLE(300) then
		return RESULT
	end
	--睡眠中
	if target:get(CFLAG, 睡眠) and not target:get(CFLAG, 陪睡中) then
		return 0
	end
	--気力0
	if me:get(BASE, 気力) <= 0 then
		return 0
	end
	--停止中は不可
	if target:get(FLAG, 70) > 0 then
		return 0
	end
	return 1
end

return cmd;
