using GameNetcodeStuff;
using HarmonyLib;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    [HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.PlayerIsTargetable))]
    internal class Invis : TogglesLoadManager.TogglesLoad
    {
        [HarmonyPrefix]
        public static bool Prefix(PlayerControllerB playerScript, bool cannotBeInShip = false, bool overrideInsideFactoryCheck = false)
        {
            if (BInvisibleToEnemys && SpectralUI.PlayerB != null && SpectralUI.PlayerB.playerClientId == playerScript.playerClientId)
            {
                return false;
            }
            return true;
        }
    }
}
