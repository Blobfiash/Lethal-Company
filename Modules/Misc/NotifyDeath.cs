using GameNetcodeStuff;
using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    [HarmonyPatch]
    internal class NotifyDeath : TogglesLoad
    {
        [HarmonyPostfix, HarmonyPatch("KillPlayerClientRpc")]
        private static void KillPlayerClientRpc(PlayerControllerB __instance, int playerId)
        {
            if (BNotifyDeath) HUDManager.Instance.DisplayTip(__instance.playerUsername, "Died!!!", false, false, "LC_Tip1");
        }
    }
}
