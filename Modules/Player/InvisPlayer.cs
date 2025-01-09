using GameNetcodeStuff;
using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class InvisPlayer : TogglesLoad
    {
        /*   Fix From FatherBone  */ 

        static Vector3 Pos;
        static bool Elevator, ShipRoom, Exhausted, Grounded;

        [HarmonyPatch("UpdatePlayerPositionServerRpc")]
        static void Prefix(ulong id, ref Vector3 pos, ref bool elevator, ref bool shipRoom, ref bool exhausted, ref bool grounded)
        {
            if (!BInvisPlayer || SpectralUI.PlayerB?.actualClientId != id) return;
            Pos = pos; Elevator = elevator; ShipRoom = shipRoom; Exhausted = exhausted; Grounded = grounded;
            pos = new Vector3(0, -100, 0); elevator = shipRoom = exhausted = false; grounded = true;
        }

        [HarmonyPatch("UpdatePlayerPositionClientRpc")]
        static void Prefix(PlayerControllerB instance, ref Vector3 pos, ref bool elevator, ref bool ship, ref bool exhausted, ref bool grounded)
        {
            if (!BInvisPlayer || instance != SpectralUI.PlayerB) return;
            pos = Pos; elevator = Elevator; ship = ShipRoom; exhausted = Exhausted; grounded = Grounded;
        }
    }
}
