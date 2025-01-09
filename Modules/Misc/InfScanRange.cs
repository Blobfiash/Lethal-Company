using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Reflection.Emit;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    /*  FatherBone  */

    [HarmonyPatch(typeof(HUDManager))]
    internal class InfScanRange : TogglesLoad
    {
        [HarmonyPatch("AssignNewNodes")]
        static IEnumerable<CodeInstruction> Range(IEnumerable<CodeInstruction> instructions)
        {
            if (!BInfScanRange) yield break;
            bool NodeSeen = false;
            foreach (var structs in instructions)
            {
                if (structs.opcode == OpCodes.Ldc_R4 && structs.operand.Equals(20.0f)) structs.operand = 50.0f;
                else if (!NodeSeen && structs.opcode == OpCodes.Ldc_R4 && structs.operand.Equals(80.0f)) { NodeSeen = true; structs.operand = float.MaxValue; }
                yield return structs;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("MeetsScanNodeRequirements")]
        static bool Prefix(ScanNodeProperties node, ref bool __result)
        {
            if (!BInfScanRange) return true;
            __result = true;
            return false;
        }
    }
}
