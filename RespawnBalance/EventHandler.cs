using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System.Linq;
using System.Collections.Generic;

namespace RespawnBalance
{
	partial class EventHandler : IEventHandlerTeamRespawn, IEventHandlerRoundRestart
	{
		private Plugin instance;

		private Dictionary<int, int> pRespawnCount = new Dictionary<int, int>();

		public EventHandler(Plugin pl) => instance = pl;

		public void OnRoundRestart(RoundRestartEvent ev)
		{
			pRespawnCount.Clear();
		}

		public void OnTeamRespawn(TeamRespawnEvent ev)
		{
			foreach (Player player in instance.Server.GetPlayers().Where(x => !pRespawnCount.ContainsKey(x.PlayerId)))
			{
				pRespawnCount.Add(player.PlayerId, 0);
			}

			ev.PlayerList = pRespawnCount.OrderBy(x => x.Value).Take(1).Select(x => GetPlayer(x.Key)).ToList();

			foreach (Player player in ev.PlayerList)
			{
				pRespawnCount[player.PlayerId]++;
			}
		}
	}
}
