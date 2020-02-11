PrefabList = {
	test = "Prefab/test.prefab";
}

function PrefabList:LoadUI(name)
	local prefabPath = self[name] 
	if not prefabPath then
		LogErr("No UI Named: ", name)
		return
	end
	local obj = MC:LoadResource(prefabPath)
	if not obj then
		LogErr("Load Ui Error: ", name, prefabPath);
		return
	end
	return obj;
end

function UiStation:OpenUI(name)

end
