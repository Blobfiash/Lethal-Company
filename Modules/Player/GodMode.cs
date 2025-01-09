using GameNetcodeStuff;
using HarmonyLib;
using SpectralWave.UI;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;
namespace SpectralWave.Modules.Player
{
    [HarmonyPatch]
    internal class GodMode : TogglesLoadManager.TogglesLoad
    {
        public override void Update()
        {
            if (BGodMode && SpectralUI.PlayerB != null) SpectralUI.PlayerB.health = 100;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.DamagePlayer))]
        public static bool PrefixDamagePlayer() => !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.KillPlayer))]
        public static bool PrefixKillPlayer() => !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(FlowermanAI), nameof(FlowermanAI.KillPlayerAnimationServerRpc))]
        public static bool PrefixFlowerman(int playerObjectId) => playerObjectId != (int)SpectralUI.PlayerB.playerClientId || !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ForestGiantAI), nameof(ForestGiantAI.GrabPlayerServerRpc))]
        public static bool PrefixGiant(int playerId) => playerId != (int)SpectralUI.PlayerB.playerClientId || !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(JesterAI), nameof(JesterAI.KillPlayerServerRpc))]
        public static bool PrefixJester(int playerId) => playerId != (int)SpectralUI.PlayerB.playerClientId || !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MaskedPlayerEnemy), nameof(MaskedPlayerEnemy.KillPlayerAnimationServerRpc))]
        public static bool PrefixMaskedPlayer(int playerObjectId) => playerObjectId != (int)SpectralUI.PlayerB.playerClientId || !BGodMode;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MouthDogAI), nameof(MouthDogAI.OnCollideWithPlayer))]
        public static bool PrefixDog(MouthDogAI __instance, Collider other)
        {
            PlayerControllerB player = __instance.MeetsStandardPlayerCollisionConditions(other);
            return player == null || player.playerClientId != SpectralUI.PlayerB.playerClientId || !BGodMode;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CentipedeAI), nameof(CentipedeAI.OnCollideWithPlayer))]
        public static bool PrefixCentipede(CentipedeAI __instance, Collider other)
        {
            PlayerControllerB player = __instance.MeetsStandardPlayerCollisionConditions(other);
            return player == null || player.playerClientId != SpectralUI.PlayerB.playerClientId || !BGodMode;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(RadMechAI), nameof(RadMechAI.OnCollideWithPlayer))]
        public static bool PrefixRadMechKill(RadMechAI __instance, Collider other)
        {
            PlayerControllerB player = __instance.MeetsStandardPlayerCollisionConditions(other);
            return player == null || player.playerClientId != SpectralUI.PlayerB.playerClientId || !BGodMode;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BushWolfEnemy), nameof(BushWolfEnemy.OnCollideWithPlayer))]
        public static bool PrefixBushWolfEnemy(BushWolfEnemy __instance, Collider other)
        {
            PlayerControllerB player = __instance.MeetsStandardPlayerCollisionConditions(other);
            return player == null || player.playerClientId != SpectralUI.PlayerB.playerClientId || !BGodMode;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CaveDwellerAI), nameof(CaveDwellerAI.OnCollideWithPlayer))]
        public static bool PrefixCaveDwellerAI(CaveDwellerAI __instance, Collider other)
        {
            PlayerControllerB player = __instance.MeetsStandardPlayerCollisionConditions(other);
            return player == null || player.playerClientId != SpectralUI.PlayerB.playerClientId || !BGodMode;
        }
    }
}
