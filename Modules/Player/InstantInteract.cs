using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    [HarmonyPatch(typeof(HUDManager), "HoldInteractionFill")]
    internal class InstantInteract : TogglesLoad
    {
        [HarmonyPrefix]
        public static bool Prefix(HUDManager __instance)
        {
            if (BInstantInteract)
            {
                return false;
            }
            return true;
        }
    }
}

