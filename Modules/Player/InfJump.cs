using static SpectralWave.ToggleManager.ToggleManager;
using SpectralWave.TogglesLoadManager;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.Collections;
using GameNetcodeStuff;

namespace SpectralWave.Modules.Player
{
    [HarmonyPatch(typeof(PlayerControllerB), "Jump_performed")]
    internal class InfJump : TogglesLoad
    {
        static bool Prefix(PlayerControllerB __instance)
        {
            if (!BInfJump || !__instance.isPlayerControlled || __instance.inSpecialInteractAnimation || __instance.isTypingChat || __instance.quickMenuManager.isMenuOpen)
                return true;

            __instance.sprintMeter = Mathf.Clamp(__instance.sprintMeter - 0.08f, 0f, 1f);
            __instance.movementAudio.PlayOneShot(StartOfRound.Instance.playerJumpSFX);

            var Fields = new[] { "playerSlidingTimer", "isJumping", "jumpCoroutine" };
            var values = new object[3];
            for (int i = 0; i < 3; i++) values[i] = typeof(PlayerControllerB).GetField(Fields[i], BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(__instance);

            typeof(PlayerControllerB).GetField(Fields[0], BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(__instance, 0f);
            typeof(PlayerControllerB).GetField(Fields[1], BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(__instance, true);
            if (values[2] != null) __instance.StopCoroutine((Coroutine)values[2]);

            var jumpMeth = typeof(PlayerControllerB).GetMethod("PlayerJump", BindingFlags.NonPublic | BindingFlags.Instance);
            if (jumpMeth != null)
                typeof(PlayerControllerB).GetField(Fields[2], BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(__instance, __instance.StartCoroutine((IEnumerator)jumpMeth.Invoke(__instance, null)));

            return false;
        }
    }
}
