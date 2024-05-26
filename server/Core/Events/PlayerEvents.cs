using AltV.Net;
using AltV.Net.Async;
using Server.Core.Entities;
using Server.Core.Services;

namespace Server.Core.Events {
    public class PlayerEvents {

        [AsyncScriptEvent(ScriptEventType.PlayerConnect)]
        public async Task OnPlayerConnect(Player player, string reason) {
            LogService.Log("Server", $"Player {player.Name} connected.");
        }

        [AsyncScriptEvent(ScriptEventType.PlayerDisconnect)]
        public async Task OnPlayerDisconnect(Player player, string reason) {
            LogService.Log("Server", $"Player {player.Name} disconnected.");
        }
    }
}
