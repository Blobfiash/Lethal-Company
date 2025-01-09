using GameNetcodeStuff;
using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpectralWave.Modules.Misc
{
    internal class PlayersOptions : TogglesLoad
    {
        public static List<PlayerControllerB> Playas = new List<PlayerControllerB>();

        public static void HealAll() => Playas.Where(p => p != GameNetworkManager.Instance.localPlayerController).ToList().ForEach(player => player.DamagePlayerFromOtherClientServerRpc(-20, Vector3.left, 0));

        public static void DamageAll() => Playas.Where(p => p != GameNetworkManager.Instance.localPlayerController).ToList().ForEach(player => player.DamagePlayerFromOtherClientServerRpc(20, Vector3.left, 0));

        public static void KillAll() => Playas.Where(p => p != GameNetworkManager.Instance.localPlayerController).ToList().ForEach(player => player.DamagePlayerFromOtherClientServerRpc(200, Vector3.left, 0));
    }
}
