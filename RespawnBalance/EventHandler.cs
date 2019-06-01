using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System.Linq;
using System.Collections.Generic;

namespace RespawnBalance
{
	partial class EventHandler : IEventHandlerTeamRespawn, IEventHandlerRoundRestart, IEventHandlerSpawn
	{
		private Plugin instance;

		private Dictionary<int, int> pRespawnCount = new Dictionary<int, int>();

		public EventHandler(Plugin pl) => instance = pl;

		public void OnRoundRestart(RoundRestartEvent ev)
		{
			pRespawnCount.Clear();
		}

		public void OnSpawn(PlayerSpawnEvent ev)
		{
			if (ev.Player.TeamRole.Team != Smod2.API.Team.SPECTATOR)
			{
				if (!pRespawnCount.ContainsKey(ev.Player.PlayerId))
				{
					pRespawnCount.Add(ev.Player.PlayerId, 0);
				}

				pRespawnCount[ev.Player.PlayerId]++;
			}
		}

		public void OnTeamRespawn(TeamRespawnEvent ev)
		{
			foreach (Player player in instance.Server.GetPlayers().Where(x => !pRespawnCount.ContainsKey(x.PlayerId)))
			{
				pRespawnCount.Add(player.PlayerId, 0);
			}

			ev.PlayerList = pRespawnCount.OrderBy(x => x.Value)
				.Select(x => GetPlayer(x.Key))
				.Where(x => x?.TeamRole.Team == Smod2.API.Team.SPECTATOR)
				.Take(ev.PlayerList.Count)
				.ToList();
		}
	}
}
