using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System.Linq;
using System.Collections.Generic;

namespace RespawnBalance
{
	partial class EventHandler
	{
		private Player GetPlayer(int id)
		{
			return instance.Server.GetPlayers().FirstOrDefault(x => x.PlayerId == id);
		}
	}
}
