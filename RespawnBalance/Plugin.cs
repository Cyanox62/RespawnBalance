using Smod2.Attributes;

namespace RespawnBalance
{
	[PluginDetails(
	author = "Cyanox",
	name = "RespawnBalance",
	description = "Alters respawn lists to make sure all players spawn in equally often.",
	id = "cyan.respawnbalance",
	version = "1.0.0",
	SmodMajor = 3,
	SmodMinor = 0,
	SmodRevision = 0
	)]
	public class Plugin : Smod2.Plugin
	{
		public override void OnDisable() { }

		public override void OnEnable() { }

		public override void Register()
		{
			AddEventHandlers(new EventHandler(this));
		}
	}
}
