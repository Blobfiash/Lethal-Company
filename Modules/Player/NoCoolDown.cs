using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    [HarmonyPatch]
    internal class NoCoolDown : TogglesLoad
    {
        [HarmonyPrefix, HarmonyPatch(typeof(InteractTrigger), "Interact")]
        public static bool InteractPrefix(InteractTrigger __instance) => !BNoCoolDown;

        [HarmonyPrefix, HarmonyPatch(typeof(GrabbableObject), "RequireCooldown")]
        public static bool Prefix(GrabbableObject __instance, ref bool __result)
        {
            if (BNoCoolDown) __result = false;
            return !BNoCoolDown;
        }
    }
}
