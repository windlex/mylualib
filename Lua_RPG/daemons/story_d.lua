local story_d = daemon_base("剧本精灵")
story_d.storys = {}

function story_d:Init()
	daemon_base.Init(self);
	self:loadStory();
end
function story_d:FixedUpdate()
	OnClick()
end
function story_d:loadStory()
	local storyname, tStory = nil, {}
	ff_GetTabFileTableEx("settings\\story.txt", 2, {
		nil, --story_name	
		nil, --CTRL	
		string.lower, --action	
		nil, --param1	
		nil, --param2	
		nil, --param3	
		nil, --param4	
		nil, --comment
	}, function (tLine)
		if #tLine.story_name > 0 then
			if storyname and #storyname > 0 then
				story_d.storys[storyname] = tStory;
			end
			tStory = {}
			storyname = tLine.story_name;
		else
			if #tLine.CTRL > 0 or #tLine.action > 0 then
				table.insert(tStory, tLine);
			end
		end
	end)
	if storyname and #storyname > 0 then
		story_d.storys[storyname] = tStory;
		tStory = {}
	end
	--ppt(self)
end

function story_d:playStory(storyname)
	start(story_d._playStory,story_d,storyname)
end
function story_d:_playStory(storyname)
	local story = self.storys[storyname];
	if not story then
		return notify_fail("no story named ".. storyname);
	end
	for i, line in ipairs(story) do
		--ppt(line);
		local handler = self.handlers[line.action]
		if not handler then
			print("[Error]:", ppt(line));
		else
			handler(line.param1,line.param2,line.param3,line.param4)
		end
		wait()
	end
end
function story_d:getHandler(cb)
	local handler = self.handlers[cb]
	return self.handlers[cb]
end

story_d.handlers = {
	story = function (s)
			print("story", s)
			story_d:playStory(s)
		end,
	dialog = function (s)
			print(s)
		end,
	["goto"] = function (s)
			WORLD_D:move(s)
		end,
	addaction = function (s, cb, st)
			print(s,cb,st)
			local fcb = story_d:getHandler(string.lower(cb))
			print(fcb)
			cmd(s, fcb, st);
		end,
}

return story_d;
