require "system.actor"

Manager = {
	inst = VM.Manager,
	comps = {},
	actors = {},
	actorCount = 0,
}

function Manager:AddDaemon(name)
	self.inst:AddScriptDaemon(name);
end

function Manager:SpawnPerfab(name)
	return perfab_d:spawnPerfab(name)
end

function Manager:CreateActor()
	local entity = self.inst:CreateEntity()
	local actor = Actor(entity);
	self.actors[entity.uuid] = actor;
	self.actorCount = self.actorCount + 1;
	return actor;
end
function Manager:DestoryActor(uuid)
	self.actors[uuid] = nil;
	self.inst:DestoryEntity(uuid);
	self.actorCount = self.actorCount - 1;
end
function Manager:GetActor(uuid)
	return self.actors[uuid];
end

function Manager:onAddComponent(actor, compName, comp)
	self.comps[compName] = self.comps[compName] or {}
	table.insert(self.comps[compName], comp);
end
function Manager:onRemoveComponent(actor, compName)
	self.comps[compName] = nil;
end
function Manager:getAllComponent(compName)
	return self.comps[compName] or {};
end

print("Manager Loaded!!!!")