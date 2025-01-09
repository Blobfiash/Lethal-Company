using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    [HarmonyPatch]
    internal class CanBuild : TogglesLoad
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipBuildModeManager), "PlayerMeetsConditionsToBuild")]
        public static bool Prefix(ShipBuildModeManager __instance, ref bool __result)
        {
            if (BCanBuild)
            {
                __result = true;
                return false;
            }
            return true;
        }
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipBuildModeManager), "Update")]
        public static void Postfix(ref bool ___CanConfirmPosition, ref PlaceableShipObject ___placingObject, ref bool ___InBuildMode)
        {
            if (BCanBuild& ___InBuildMode)
            {
                ___CanConfirmPosition = true;
                ___placingObject.AllowPlacementOnWalls = true;
                ___placingObject.AllowPlacementOnCounters = true;
            }
        }
    }
}

