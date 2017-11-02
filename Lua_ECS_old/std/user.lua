User = class {
	name = "User",
	desc = "this is a User",
}

function User:link(player)
	user.body = player;
	player.soul = user;
end
