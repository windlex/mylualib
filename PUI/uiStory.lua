local uiStory = {}

function uiStory:Init()
	self.go = VM.Logic.uiStory or uiBase:findChild("Story");
	print(VM.Logic.cmdList)
	print(VM.Logic.uiStory)
	print("story.go = ", self.go)
	print(tostring(uiBase:findChild("Story")))

	self.BG = uiStory.go:GetComponent("Image");
	--print("BG", uiStory.BG)
	uiStory.BG.sprite = uiBase:LoadSprite("001-Gameover01.jpg") 
	
	self.Role = {}
	for i = 1, 3 do
		uiStory.Role[i] = uiBase:GetChildComponent("Story/Talk/Role"..i, "Image") 
		uiStory.Role[i].sprite = uiBase:LoadSprite("08_米拉米.png") 
	end

	uiStory.Talking = uiBase:GetChildComponent("Story/Talk/Talking", "Text")
	--print(uiStory.Talking)
	uiStory.Talking.text = "alblablalbal"
end

function uiStory:SetBG(imagepath)
	local spr = uiBase:LoadSprite(imagepath);
	self.BG.sprite = spr;
end

function uiStory:SetFace(nFace, facePath)
	local spr = uiBase:LoadSprite(facePath );
	self.Role[nFace].sprite = spr
end

function uiStory:SetDialog(szDialog)
	self.Talking.text = szDialog;
end

uiStory:Init()
uiStory:SetBG("1.jpg")
uiStory:SetFace(1, "aBalloon.png")
uiStory:SetDialog("HHHHHHH")
return uiStory;

