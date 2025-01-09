using static SpectralWave.ToggleManager.ToggleManager;
using HarmonyLib;
using GameNetcodeStuff;
using System.Reflection;
using SpectralWave.TogglesLoadManager;

namespace SpectralWave.Modules.Misc
{
    [HarmonyPatch]
    internal class InfItems : TogglesLoad
    {
        [HarmonyPrefix, HarmonyPatch(typeof(StunGrenadeItem), "ItemActivate")]
        public static bool Prefix(StunGrenadeItem __instance) => BInfItems ? (__instance.itemUsedUp = __instance.pinPulled = __instance.hasExploded = __instance.DestroyGrenade = false) : true;

        [HarmonyPrefix, HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.DestroyObjectInHand))]
        public static bool Prefix(PlayerControllerB playerHolding, ref bool __result) =>  BInfItems ? (__result = true) : true;
    }
}
